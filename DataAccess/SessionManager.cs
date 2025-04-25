using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_inventaire.Models;
using System.Windows.Forms;
using Gestion_inventaire.DataAccess;
using Npgsql;

namespace Gestion_inventaire.DataAccess
{
    /// Classe statique pour gérer les sessions utilisateur (connexion / déconnexion)
    public static class SessionManager
    {
        public static string NomUtilisateur { get; private set; }
        public static int IdSessionActive { get; private set; } = 0;
        public static int UtilisateurId { get; private set; } = 0; // ici

        /// Démarre une nouvelle session pour l'utilisateur connecté
        public static void DemarrerSession(Utilisateur utilisateur)
        {
            NomUtilisateur = utilisateur.Nom;
            UtilisateurId = utilisateur.Id; // ici
            using (var conn = ConnexionManager.GetConnection())
            {
                string query = @"
                INSERT INTO SessionUtilisateurs (UtilisateurId, AdresseIP, Navigateur)
                VALUES ((SELECT Id FROM Utilisateurs WHERE Email = @Email), @IP, @Navigateur)
                RETURNING Id;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Email", utilisateur.Login);
                    cmd.Parameters.AddWithValue("IP", Environment.MachineName);
                    cmd.Parameters.AddWithValue("Navigateur", Environment.OSVersion.ToString());

                    IdSessionActive = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        /// Termine proprement la session en cours (met à jour l'heure de déconnexion)
        public static void TerminerSession()
        {
            if (IdSessionActive == 0) return;

            using (var conn = ConnexionManager.GetConnection())
            {
                string query = "UPDATE SessionUtilisateurs SET HeureDeconnexion = CURRENT_TIMESTAMP WHERE Id = @Id;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Id", IdSessionActive);
                    cmd.ExecuteNonQuery();
                }
            }

            // Réinitialise les valeurs après déconnexion
            IdSessionActive = 0;
            UtilisateurId = 0; //ici
        }
    }
}
