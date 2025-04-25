using Gestion_inventaire.Models;
using Gestion_inventaire.Models.Gestion_inventaire.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Gestion_inventaire.DataAccess
{
    public class MouvementRepository
    {
        private readonly string connectionString;

        public MouvementRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //  Ajoute un mouvement d'entrée ou de sortie dans la base de données
        public bool AjouterMouvement(MvtStocks mouvement)
        {
            using (var conn = ConnexionManager.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // 1 Enregistre le mouvement dans la table MouvementsStock

                    string insertQuery = @"
                INSERT INTO MouvementsStock (ProduitId, Type, QuantiteEnStock, Remarque, DateOperation)
                VALUES (@ProduitId, @Type, @Quantite, @Remarque, CURRENT_TIMESTAMP);";

                    using (var cmd = new NpgsqlCommand(insertQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ProduitId", mouvement.ProduitId);
                        cmd.Parameters.AddWithValue("@Type", mouvement.Type);
                        cmd.Parameters.AddWithValue("@Quantite", mouvement.QuantiteEnStock);
                        cmd.Parameters.AddWithValue("@Remarque", mouvement.Remarque ?? "");
                        cmd.ExecuteNonQuery();
                    }

                    //  Mise à jour de la quantité du produit
                    int delta = mouvement.Type == "ENTREE" ? mouvement.QuantiteEnStock : -mouvement.QuantiteEnStock;

                    string updateQuery = @"
                UPDATE Produits
                SET QuantiteEnStock = QuantiteEnStock + @Delta
                WHERE Id = @ProduitId;";

                    using (var cmdUpdate = new NpgsqlCommand(updateQuery, conn, transaction))
                    {
                        cmdUpdate.Parameters.AddWithValue("@Delta", delta);
                        cmdUpdate.Parameters.AddWithValue("@ProduitId", mouvement.ProduitId);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    // 3. Génération automatique d'une notification si stock faible après une SORTIE
                    if (mouvement.Type == "SORTIE")
                    {
                        string checkQuery = @"
                    SELECT Nom, QuantiteEnStock, SeuilAlerte
                    FROM Produits
                    WHERE Id = @ProduitId AND QuantiteEnStock <= SeuilAlerte;";

                        using (var cmdCheck = new NpgsqlCommand(checkQuery, conn, transaction))
                        {
                            cmdCheck.Parameters.AddWithValue("@ProduitId", mouvement.ProduitId);
                            using (var reader = cmdCheck.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string nomProduit = reader.GetString(0);
                                    int quantite = reader.GetInt32(1);

                                    reader.Close(); // Fermer pour lancer une nouvelle commande

                                    string insertNotif = @"
                                INSERT INTO Notifications (ProduitId, Message, TypeNotification, Statut)
                                SELECT @ProduitId, @Message, 'Stock faible', 'Non lue'
                                WHERE NOT EXISTS (
                                    SELECT 1 FROM Notifications 
                                    WHERE ProduitId = @ProduitId AND TypeNotification = 'Stock faible' AND Statut = 'Non lue');";

                                    using (var cmdNotif = new NpgsqlCommand(insertNotif, conn, transaction))
                                    {
                                        cmdNotif.Parameters.AddWithValue("@ProduitId", mouvement.ProduitId);
                                        cmdNotif.Parameters.AddWithValue("@Message", $"📦 Alerte : Le produit {nomProduit} est en stock faible ({quantite} unités restantes).");
                                        cmdNotif.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Erreur lors du mouvement : " + ex.Message);
                    return false;
                }
            }
        }

        //  Récupère les mouvements filtrés par type (ENTREE / SORTIE) et/ou par produit
        public List<MouvementDisplay> GetAllAvecFiltres(string type, int? produitId)
        {
            var mouvements = new List<MouvementDisplay>();

            using (var conn = ConnexionManager.GetConnection())
            {
                var query = @"
            SELECT 
                m.Type,
                p.Nom AS ProduitNom,
                m.QuantiteEnStock AS Quantite,
                m.DateOperation,
                m.Remarque,
                m.ProduitId
            FROM MouvementsStock m
            INNER JOIN Produits p ON p.Id = m.ProduitId
            WHERE (m.Type = @Type OR @Type IS NULL)
              AND (m.ProduitId = @ProduitId OR @ProduitId IS NULL)
            ORDER BY m.DateOperation DESC;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Type", type != null ? (object)type : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProduitId", produitId.HasValue ? (object)produitId.Value : DBNull.Value);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mouvements.Add(new MouvementDisplay
                            {
                                Type = reader.GetString(0),
                                Produit = reader.GetString(1),
                                Quantite = reader.GetInt32(2),
                                DateHeure = reader.GetDateTime(3),
                                Remarque = reader.IsDBNull(4) ? null : reader.GetString(4),
                                ProduitId = reader.GetInt32(5)
                            });
                        }
                    }
                }
            }

            return mouvements;
        }

        //  Récupère tous les mouvements sans filtre
        public List<MouvementDisplay> ObtenirTousLesMouvements()
        {
            var mouvements = new List<MouvementDisplay>();

            using (var conn = ConnexionManager.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT m.Type, p.Nom AS ProduitNom, m.QuantiteEnStock, m.DateOperation, m.Remarque
            FROM MouvementsStock m
            JOIN Produits p ON m.ProduitId = p.Id
            ORDER BY m.DateOperation DESC";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mouvements.Add(new MouvementDisplay
                        {
                            Type = reader.GetString(0),
                            Produit = reader.GetString(1),
                            Quantite = reader.GetInt32(2),
                            DateHeure = reader.GetDateTime(3),
                            Remarque = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            ProduitId = reader.GetInt32(5)
                        });
                    }
                }
            }

            return mouvements;
        }

        //  Utilisé pour les statistiques sur le dashboard : nombre de mouvements par jour
        public Dictionary<string, int> GetMouvementsParJour()
        {
            var result = new Dictionary<string, int>();

            using (var conn = ConnexionManager.GetConnection())
            {
                string query = @"
            SELECT TO_CHAR(DateOperation, 'Day') AS JourSemaine,
                   COUNT(*) AS NbMouvements
            FROM MouvementsStock
            GROUP BY JourSemaine
            ORDER BY MIN(DATE_PART('dow', DateOperation));";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string jour = reader.GetString(0).Trim(); // enlève les espaces de TO_CHAR
                        int count = reader.GetInt32(1);
                        result[jour] = count;
                    }
                }
            }

            return result;
        }



    }
}
