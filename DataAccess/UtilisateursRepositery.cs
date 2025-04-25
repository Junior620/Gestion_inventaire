using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_inventaire.Models;
using Npgsql;

namespace Gestion_inventaire.DataAccess
{
    /// Cette classe permet de gérer les opérations en base de données liées aux utilisateurs.
    public class UtilisateurRepository
    {

        public bool CreerUtilisateur(Utilisateur user)
        {
            using (var conn = ConnexionManager.GetConnection())
            {
                string query = @"INSERT INTO Utilisateurs (Nom, Email, MotDePasse, Role)
                                 VALUES (@Nom, @Email, @MotDePasse, @Role);";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Nom", user.Nom);
                    cmd.Parameters.AddWithValue("Email", user.Login); // Login = Email
                    cmd.Parameters.AddWithValue("MotDePasse", user.MotDePasse);
                    cmd.Parameters.AddWithValue("Role", user.Role);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

    }
}
