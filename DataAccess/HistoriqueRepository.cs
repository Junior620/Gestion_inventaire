using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Gestion_inventaire.Models;
using NpgsqlTypes; // à mettre tout en haut


namespace Gestion_inventaire.DataAccess

{
    public class HistoriqueRepository
    {
        /// Récupère la liste des actions historiques (Ajouter, Modifier, Supprimer) avec option de filtre par type d'action.
        public List<HistoriqueDisplay> GetHistorique(string actionFiltre = null)
        {
            var historiques = new List<HistoriqueDisplay>();

            using (var conn = ConnexionManager.GetConnection())
            {
                //var query = @"
                //    SELECT h.Date, h.Action, p.Nom AS Produit, h.Quantite
                //    FROM HistoriqueActions h
                //    JOIN Produits p ON p.Id = h.ProduitId
                //    WHERE (@Action IS NULL OR h.Action = @Action)
                //    ORDER BY h.Date DESC";
                var query = @"
                        SELECT Date, Action, Produit, Quantite
                        FROM HistoriqueActions
                        WHERE (@Action IS NULL OR Action = @Action)
                        ORDER BY Date DESC";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    // Paramètre de filtre pour l'action (exemple: "Ajouter")
                    cmd.Parameters.Add("@Action", NpgsqlTypes.NpgsqlDbType.Text);
                    cmd.Parameters["@Action"].Value = actionFiltre ?? (object)DBNull.Value;

                    using (var reader = cmd.ExecuteReader())
                    {
                        // Lecture des résultats ligne par ligne
                        while (reader.Read())
                        {
                            historiques.Add(new HistoriqueDisplay
                            {
                                Date = reader.GetDateTime(0),
                                Action = reader.GetString(1),
                                Produit = reader.GetString(2),
                                Quantite = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }

            return historiques;
        }

        /// Fusionne les mouvements de stock (ENTREE/SORTIE) et les actions (AJOUT/MODIF/SUPPR) pour un historique global.
        public List<HistoriqueDisplay> GetToutesLesOperations()
        {
            var historiques = new List<HistoriqueDisplay>();

            using (var conn = ConnexionManager.GetConnection())
            {
                // Cette requête combine deux sources d'historique (MouvementsStock et HistoriqueActions)
                string query = @"
                SELECT 
                    m.DateOperation AS Date, 
                    m.Type AS Action, 
                    p.Nom AS Produit, 
                    m.QuantiteEnStock AS Quantite
                FROM MouvementsStock m
                JOIN Produits p ON p.Id = m.ProduitId

                UNION ALL

                SELECT 
                    h.Date AS Date, 
                    h.Action AS Action, 
                    h.Produit AS Produit, 
                    h.Quantite AS Quantite
                FROM HistoriqueActions h

                ORDER BY Date DESC";


                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        historiques.Add(new HistoriqueDisplay
                        {
                            Date = reader.GetDateTime(0),
                            Action = reader.GetString(1),
                            Produit = reader.GetString(2),
                            Quantite = reader.GetInt32(3)
                        });
                    }
                }
            }

            return historiques;
        }

    }



}
