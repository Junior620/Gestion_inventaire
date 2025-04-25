using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_inventaire.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

// Pour Exporter des données vers PDF

namespace Gestion_inventaire.Services
{
    public static class ExportServicePdf
    {
        public static void Export(List<Produit> produits, string filePath)
        {
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            doc.Add(new Paragraph("Liste des produits\n\n"));

            PdfPTable table = new PdfPTable(5); // Nombre de colonnes

            table.AddCell("Nom");
            table.AddCell("Catégorie");
            table.AddCell("Quantité");
            table.AddCell("Seuil");
            table.AddCell("Prix");

            foreach (var p in produits)
            {
                table.AddCell(p.Nom);
                table.AddCell(p.Categorie);
                table.AddCell(p.QuantiteEnStock.ToString());
                table.AddCell(p.SeuilAlerte.ToString());
                table.AddCell(p.PrixUnitaire.ToString("0.00"));
            }

            doc.Add(table);
            doc.Close();
        }
        public static void Export(List<HistoriqueDisplay> historiques, string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                Document doc = new Document(PageSize.A4);
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                doc.Add(new Paragraph("Historique des actions\n\n"));

                PdfPTable table = new PdfPTable(4);
                table.AddCell("Date");
                table.AddCell("Action");
                table.AddCell("Produit");
                table.AddCell("Quantité");

                foreach (var h in historiques)
                {
                    table.AddCell(h.Date.ToString("yyyy-MM-dd HH:mm"));
                    table.AddCell(h.Action);
                    table.AddCell(h.Produit);
                    table.AddCell(h.Quantite.ToString());
                }

                doc.Add(table);
                doc.Close();
            }
        }
        public static void Export(
            int stockTotal,
            int produitsRupture,
            decimal valeurStock,
            List<Produit> stocksFaibles,
            List<Produit> produitsEnStock,
            List<HistoriqueDisplay> historiques,
            string chemin)
        {
            Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter.GetInstance(doc, new FileStream(chemin, FileMode.Create));
            doc.Open();

            Font titre = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            Font normal = FontFactory.GetFont(FontFactory.HELVETICA, 12);

            // 🔰 Titre principal
            doc.Add(new Paragraph("Rapport d’Inventaire - Export PDF\n\n", titre));

            // 🔹 Résumé global
            doc.Add(new Paragraph($"📦 Stock total : {stockTotal}", normal));
            doc.Add(new Paragraph($"❌ Produits en rupture : {produitsRupture}", normal));
            doc.Add(new Paragraph($"💰 Valeur totale du stock : {valeurStock} €\n\n", normal));

            // 🔻 Stocks faibles
            AjouterTableProduits(doc, "Stocks Faibles", stocksFaibles);

            // ✅ Produits en stock
            AjouterTableProduits(doc, "Produits en Stock", produitsEnStock);

            // 🕘 Historique
            AjouterTableHistorique(doc, "Historique des Actions", historiques);

            doc.Close();
        }

        private static void AjouterTableProduits(Document doc, string titre, List<Produit> produits)
        {
            Font titreFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
            doc.Add(new Paragraph($"\n{titre}\n", titreFont));

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.AddCell("Nom");
            table.AddCell("Quantité");

            foreach (var p in produits)
            {
                table.AddCell(p.Nom);
                table.AddCell(p.QuantiteEnStock.ToString());
            }

            doc.Add(table);
        }

        private static void AjouterTableHistorique(Document doc, string titre, List<HistoriqueDisplay> historiques)
        {
            Font titreFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
            doc.Add(new Paragraph($"\n{titre}\n", titreFont));

            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.AddCell("Date");
            table.AddCell("Action");
            table.AddCell("Produit");
            table.AddCell("Quantité");

            foreach (var h in historiques)
            {
                table.AddCell(h.Date.ToString("dd/MM/yyyy HH:mm"));
                table.AddCell(h.Action);
                table.AddCell(h.Produit);
                table.AddCell(h.Quantite.ToString());
            }

            doc.Add(table);
        }
    }

}
