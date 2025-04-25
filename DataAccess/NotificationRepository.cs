using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_inventaire.Models;
using Npgsql;

namespace Gestion_inventaire.DataAccess
{
    /// Classe responsable de toutes les opérations d'accès aux données liées aux notifications.
    public class NotificationRepository
    {
        /// Récupère les notifications avec possibilité de filtrage (type, statut).
        public List<Notification> GetNotifications(string typeFiltre = null, string statutFiltre = null)
        {
            var notifications = new List<Notification>();
            using (var conn = ConnexionManager.GetConnection())
            {
                var query = @"
                SELECT Message, DateHeure, Statut
                FROM Notifications
                WHERE 
                    Supprimee =
                    FALSE ORDER BY DateHeure DESC";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    // Préparation des filtres
                    cmd.Parameters.Add("@Type", NpgsqlTypes.NpgsqlDbType.Varchar).Value = typeFiltre ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@Statut", NpgsqlTypes.NpgsqlDbType.Varchar).Value = statutFiltre ?? (object)DBNull.Value;


                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notifications.Add(new Notification
                            {
                                Message = reader.GetString(0),
                                DateHeure = reader.GetDateTime(1),
                                Statut = reader.GetString(2)
                            });
                        }
                    }
                }
            }
            return notifications;
        }

        /// Récupère toutes les notifications existantes (y compris leur ID).
        public List<Notification> GetAll()
        {
            var list = new List<Notification>();

            using (var conn = ConnexionManager.GetConnection())
            {
                var query = "SELECT Id, Message, DateHeure, Statut FROM Notifications ORDER BY DateHeure DESC";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Notification
                        {
                            Id = reader.GetInt32(0),
                            Message = reader.GetString(1),
                            DateHeure = reader.GetDateTime(2),
                            Statut = reader.GetString(3)
                        });
                    }
                }
            }

            return list;
        }

        /// Génère automatiquement des notifications pour les produits dont le stock est inférieur ou égal au seuil d'alerte.
        /// Évite les doublons de notifications non lues.
        public void GenererNotificationStockFaible()
        {
            using (var conn = ConnexionManager.GetConnection())
            {
                var query = @"
            INSERT INTO Notifications (ProduitId, Message, TypeNotification)
            SELECT p.Id,
                   CONCAT('📦 Alerte de stock faible : Le produit ', p.Nom, ' est en quantité limitée. Il reste seulement ', p.QuantiteEnStock, ' unités.')
                   AS Message,
                   'Stock faible'
            FROM Produits p
            WHERE p.QuantiteEnStock <= p.SeuilAlerte
            AND NOT EXISTS (
                SELECT 1 FROM Notifications n
                WHERE n.ProduitId = p.Id AND n.TypeNotification = 'Stock faible' AND n.Statut = 'Non lue'
            );";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// Vérifie s’il existe au moins une notification non lue.
        public bool AlerteNonLueExiste()
        {
            using (var conn = ConnexionManager.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Notifications WHERE Statut = 'Non lue'";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        /// Récupère la dernière notification non lue, utile pour les alertes instantanées ou toast.
        public Notification GetDerniereNotificationNonLue()
        {
            using (var conn = ConnexionManager.GetConnection())
            {
                string query = @"
            SELECT Id, Message, DateHeure, Statut
            FROM Notifications
            WHERE Statut = 'Non lue'
            ORDER BY Id DESC
            LIMIT 1";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Notification
                        {
                            Id = reader.GetInt32(0),
                            Message = reader.GetString(1),
                            DateHeure = reader.GetDateTime(2),
                            Statut = reader.GetString(3)
                        };
                    }
                }
            }

            return null;
        }



    }
}
