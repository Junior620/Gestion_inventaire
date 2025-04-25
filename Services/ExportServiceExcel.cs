using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using Gestion_inventaire.Models;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using Gestion_inventaire.DataAccess;

namespace Gestion_inventaire.Services
{
  
    public static class ExportServiceExcel
    {
        private static ProduitRepository produitRepo = new ProduitRepository();
        private static HistoriqueRepository historiqueRepo = new HistoriqueRepository();
        public static void Export(List<HistoriqueDisplay> historiques, string filePath)
        {

            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("Historique");

                // En-têtes
                sheet.Cells[1, 1].Value = "Date";
                sheet.Cells[1, 2].Value = "Action";
                sheet.Cells[1, 3].Value = "Produit";
                sheet.Cells[1, 4].Value = "Quantité";

                // Données
                for (int i = 0; i < historiques.Count; i++)
                {
                    sheet.Cells[i + 2, 1].Value = historiques[i].Date.ToString("yyyy-MM-dd HH:mm");
                    sheet.Cells[i + 2, 2].Value = historiques[i].Action;
                    sheet.Cells[i + 2, 3].Value = historiques[i].Produit;
                    sheet.Cells[i + 2, 4].Value = historiques[i].Quantite;
                }

                package.SaveAs(new FileInfo(filePath));
            }
        }
        public static void Export(string cheminFichier,

            int stockTotal,
            int produitsEnRupture,
            decimal valeurStock,
            List<Produit> stocksFaibles,
            List<Produit> produitsEnStock,
            List<HistoriqueDisplay> historiques)
        {

            using (var package = new ExcelPackage())
            {
                // 1. Résumé
                var wsResume = package.Workbook.Worksheets.Add("Résumé");
                wsResume.Cells[1, 1].Value = "Stock total";
                wsResume.Cells[1, 2].Value = stockTotal;
                wsResume.Cells[2, 1].Value = "Produits en rupture";
                wsResume.Cells[2, 2].Value = produitsEnRupture;
                wsResume.Cells[3, 1].Value = "Valeur du stock (€)";
                wsResume.Cells[3, 2].Value = valeurStock;

                // 2. Stocks faibles
                var wsFaibles = package.Workbook.Worksheets.Add("Stocks faibles");
                wsFaibles.Cells[1, 1].Value = "Nom";
                wsFaibles.Cells[1, 2].Value = "Quantité";
                int row = 2;
                foreach (var p in stocksFaibles)
                {
                    wsFaibles.Cells[row, 1].Value = p.Nom;
                    wsFaibles.Cells[row, 2].Value = p.QuantiteEnStock;
                    row++;
                }

                // 3. Produits en stock
                var wsStock = package.Workbook.Worksheets.Add("Produits en stock");
                wsStock.Cells[1, 1].Value = "Nom";
                wsStock.Cells[1, 2].Value = "Quantité";
                row = 2;
                foreach (var p in produitsEnStock)
                {
                    wsStock.Cells[row, 1].Value = p.Nom;
                    wsStock.Cells[row, 2].Value = p.QuantiteEnStock;
                    row++;
                }

                // 4. Historique
                var wsHistorique = package.Workbook.Worksheets.Add("Historique");
                wsHistorique.Cells[1, 1].Value = "Date";
                wsHistorique.Cells[1, 2].Value = "Action";
                wsHistorique.Cells[1, 3].Value = "Produit";
                wsHistorique.Cells[1, 4].Value = "Quantité";

                row = 2;
                foreach (var h in historiques)
                {
                    wsHistorique.Cells[row, 1].Value = h.Date.ToString("yyyy-MM-dd HH:mm");
                    wsHistorique.Cells[row, 2].Value = h.Action;
                    wsHistorique.Cells[row, 3].Value = h.Produit;
                    wsHistorique.Cells[row, 4].Value = h.Quantite;
                    row++;
                }

                // Sauvegarde
                FileInfo fi = new FileInfo(cheminFichier);
                package.SaveAs(fi);
            }
        }

        public static void Export(List<Produit> produits, string filePath)
        {
            // Fix for CS0117 and CS0234: Ensure the correct namespace and property are used.  
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Produits");

                // En-têtes  
                worksheet.Cells[1, 1].Value = "Nom";
                worksheet.Cells[1, 2].Value = "Catégorie";
                worksheet.Cells[1, 3].Value = "Quantité";
                worksheet.Cells[1, 4].Value = "Seuil";
                worksheet.Cells[1, 5].Value = "Prix";

                // Données  
                for (int i = 0; i < produits.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = produits[i].Nom;
                    worksheet.Cells[i + 2, 2].Value = produits[i].Categorie;
                    worksheet.Cells[i + 2, 3].Value = produits[i].QuantiteEnStock;
                    worksheet.Cells[i + 2, 4].Value = produits[i].SeuilAlerte;
                    worksheet.Cells[i + 2, 5].Value = produits[i].PrixUnitaire;
                }

                package.SaveAs(new FileInfo(filePath));
            }
        }


    }


}
