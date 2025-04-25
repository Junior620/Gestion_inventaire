using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Gestion_inventaire.Models;
using System.Collections.Generic;


namespace Gestion_inventaire.DataAccess
{
    public class ProduitRepository
    {
        /// Récupère la liste de tous les produits depuis la base de données.
        public List<Produit> GetAll()
        {
            var produits = new List<Produit>();
            using (var conn = ConnexionManager.GetConnection())
            {
                string query = "SELECT * FROM Produits ORDER BY Id";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        produits.Add(new Produit
                        {
                            Id = (int)reader["Id"],
                            Nom = reader["Nom"].ToString(),
                            Categorie = reader["Categorie"].ToString(),
                            QuantiteEnStock = (int)reader["QuantiteEnStock"],
                            SeuilAlerte = (int)reader["SeuilAlerte"],
                            PrixUnitaire = (decimal)reader["PrixUnitaire"]
                        });
                    }
                }
            }
            return produits;
        }

        /// Ajoute un produit et retourne son ID après insertion.
        public int AjouterProduitEtRetournerId(Produit p)
        {
            using (var conn = ConnexionManager.GetConnection())
            {
                string query = @"
            INSERT INTO Produits (Nom, Categorie, QuantiteEnStock, SeuilAlerte, PrixUnitaire)
            VALUES (@Nom, @Categorie, @Quantite, @Seuil, @Prix)
            RETURNING Id;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Nom", p.Nom);
                    cmd.Parameters.AddWithValue("Categorie", p.Categorie);
                    cmd.Parameters.AddWithValue("Quantite", p.QuantiteEnStock);
                    cmd.Parameters.AddWithValue("Seuil", p.SeuilAlerte);
                    cmd.Parameters.AddWithValue("Prix", p.PrixUnitaire);

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        /// Ajoute un produit sans retourner l'ID.
        public bool AjouterProduit(Produit p)
        {
            using (var conn = ConnexionManager.GetConnection())
            {
                string query = @"INSERT INTO Produits (Nom, Categorie, QuantiteEnStock, SeuilAlerte, PrixUnitaire)
                                 VALUES (@Nom, @Categorie, @Quantite, @Seuil, @Prix)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Nom", p.Nom);
                    cmd.Parameters.AddWithValue("Categorie", p.Categorie);
                    cmd.Parameters.AddWithValue("Quantite", p.QuantiteEnStock);
                    cmd.Parameters.AddWithValue("Seuil", p.SeuilAlerte);
                    cmd.Parameters.AddWithValue("Prix", p.PrixUnitaire);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// Modifie un produit existant dans la base.
        public bool ModifierProduit(Produit p)
        {
            using (var conn = ConnexionManager.GetConnection())
            {
                string query = @"UPDATE Produits
                                 SET Nom=@Nom, Categorie=@Categorie, QuantiteEnStock=@Quantite, SeuilAlerte=@Seuil, PrixUnitaire=@Prix
                                 WHERE Id=@Id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Id", p.Id);
                    cmd.Parameters.AddWithValue("Nom", p.Nom);
                    cmd.Parameters.AddWithValue("Categorie", p.Categorie);
                    cmd.Parameters.AddWithValue("Quantite", p.QuantiteEnStock);
                    cmd.Parameters.AddWithValue("Seuil", p.SeuilAlerte);
                    cmd.Parameters.AddWithValue("Prix", p.PrixUnitaire);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool SupprimerProduit(int id)
        {
            using (var conn = ConnexionManager.GetConnection())
            {
                string query = "DELETE FROM Produits WHERE Id = @Id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// Retourne la quantité totale de stock (somme des quantités de tous les produits).
        public int GetStockTotal()
        {
            using (var conn = ConnexionManager.GetConnection())
            using (var cmd = new NpgsqlCommand("SELECT SUM(QuantiteEnStock) FROM Produits", conn))
            {
                return Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
            }
        }

        /// Retourne le nombre de produits qui sont en rupture (stock == 0).
        public int GetProduitsEnRupture()
        {
            using (var conn = ConnexionManager.GetConnection())
            using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM Produits WHERE QuantiteEnStock = 0", conn))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /// Calcule la valeur totale du stock (quantité * prix).
        public decimal GetValeurStock()
        {
            using (var conn = ConnexionManager.GetConnection())
            using (var cmd = new NpgsqlCommand("SELECT SUM(QuantiteEnStock * PrixUnitaire) FROM Produits", conn))
            {
                return Convert.ToDecimal(cmd.ExecuteScalar() ?? 0);
            }
        }

        /// Retourne la liste des produits dont le stock est inférieur au seuil d’alerte.
        public List<Produit> GetProduitsStockFaible()
        {
            var produits = new List<Produit>();

            using (var conn = ConnexionManager.GetConnection())
            {
                string query = "SELECT * FROM Produits WHERE QuantiteEnStock < SeuilAlerte";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        produits.Add(new Produit
                        {
                            Id = reader.GetInt32(0),
                            Nom = reader.GetString(1),
                            Categorie = reader.GetString(2),
                            QuantiteEnStock = reader.GetInt32(3),
                            SeuilAlerte = reader.GetInt32(4),
                            PrixUnitaire = reader.GetDecimal(5)
                        });
                    }
                }
            }

            return produits;
        }

        /// Retourne la liste des produits dont le stock est supérieur au seuil.
        public List<Produit> GetProduitsEnStock()
        {
            var produits = new List<Produit>();

            using (var conn = ConnexionManager.GetConnection())
            {
                var query = "SELECT Nom, QuantiteEnStock FROM Produits WHERE QuantiteEnStock > SeuilAlerte";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        produits.Add(new Produit
                        {
                            Nom = reader.GetString(0),
                            QuantiteEnStock = reader.GetInt32(1)
                        });
                    }
                }
            }

            return produits;
        }

        /// Retourne la quantité de stock d’un produit par son ID.
        public int GetQuantiteStockParId(int produitId)
        {
            using (var conn = ConnexionManager.GetConnection())
            {
                string query = "SELECT QuantiteEnStock FROM Produits WHERE Id = @Id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", produitId);
                    object result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int quantite))
                    {
                        return quantite;
                    }

                    return 0; // Valeur par défaut si produit non trouvé
                }
            }
        }



    }
}
