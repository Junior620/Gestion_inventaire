using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Gestion_inventaire.Models;
using System.Xml;
using Gestion_inventaire.DataAccess;
using Npgsql;


// Classe responsable de la logique d'authentification (connexion et inscription)
namespace Gestion_inventaire.Controllers
{
    /// Vérifie les identifiants (email et mot de passe) d’un utilisateur et retourne ses infos si valides.
    public class AuthControllers
    {
        public Utilisateur Connecter(string login, string motDePasse)
        {
            Utilisateur utilisateur = null;

            using (var conn = ConnexionManager.GetConnection())
            {
                string query = "SELECT * FROM Utilisateurs WHERE Email = @Email AND MotDePasse = @MotDePasse";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Email", login);
                    cmd.Parameters.AddWithValue("MotDePasse", motDePasse);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Création de l'objet Utilisateur avec les infos récupérées
                            utilisateur = new Utilisateur
                            {
                                Nom = reader["Nom"].ToString(),
                                Login = reader["Email"].ToString(),
                                MotDePasse = reader["MotDePasse"].ToString(),
                                Role = reader["Role"].ToString()
                            };
                        }
                    }
                }
            }

            // Si l’utilisateur a été trouvé, on enregistre sa connexion
            if (utilisateur != null)
            {
                EnregistrerConnexion(utilisateur);
            }

            return utilisateur;
        }

        /// Enregistre une session de connexion de l’utilisateur dans la table `SessionUtilisateurs`.
        public void EnregistrerConnexion(Utilisateur utilisateur)
        {
            using (var conn = ConnexionManager.GetConnection())
            {
                string query = @"INSERT INTO SessionUtilisateurs (UtilisateurId, AdresseIP, Navigateur)
                                 VALUES ((SELECT Id FROM Utilisateurs WHERE Email = @Email), @IP, @Navigateur);";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Email", utilisateur.Login);
                    cmd.Parameters.AddWithValue("IP", Environment.MachineName); // ou une méthode pour détecter IP
                    cmd.Parameters.AddWithValue("Navigateur", Environment.OSVersion.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// Inscrit un nouvel utilisateur dans la base de données.
        public bool Inscrire(Utilisateur utilisateur)
        {
            using (var conn = ConnexionManager.GetConnection())
            {
                string query = @"INSERT INTO Utilisateurs (Nom, Email, MotDePasse, Role)
                                 VALUES (@Nom, @Email, @MotDePasse, @Role);";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Nom", utilisateur.Nom);
                    cmd.Parameters.AddWithValue("Email", utilisateur.Login);
                    cmd.Parameters.AddWithValue("MotDePasse", utilisateur.MotDePasse);
                    cmd.Parameters.AddWithValue("Role", utilisateur.Role);

                    // Renvoie true si une ligne a bien été insérée
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
