using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion_inventaire.Models;
using iTextSharp.text.pdf;
using iTextSharp.text;
using OfficeOpenXml;

namespace Gestion_inventaire.Views
{
    public partial class ProduitsForm : Form
    {
        int pageSize = 15; // Nombre de produits par page
        int pageIndex = 1; // Page actuelle
        List<Produit> produits = new List<Produit>();
        public ProduitsForm()
        {
            InitializeComponent();
            ChargerProduitsFictifs();
            dataGridView1.RowPostPaint += dgvProduits_RowPostPaint; // 🔄 Événement pour le numéro de ligne
            FormaterDataGridView();
            ChargerProduitsFictifs(); // Charge toute la liste
            ChargerPage();            // Affiche la première page

        }

        // Classe produit
        public class Produit
        {
            public string Nom { get; set; }
            public string Categorie { get; set; }
            public int QuantiteEnStock { get; set; }
            public int SeuilAlerte { get; set; }
            public decimal PrixUnitaire { get; set; }

        }

        // Fonction de chargement fictive
        private void ChargerProduitsFictifs()
        {
            produits = new List<Produit>
    {
        new Produit { Nom = "Ordinateur portable", Categorie = "Informatique", QuantiteEnStock = 10, SeuilAlerte = 3, PrixUnitaire = 700 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 4, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Accessoire", Categorie = "Ecouteur", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Accessoire", Categorie = "Ecouteur", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 },
        new Produit { Nom = "Smartphone", Categorie = "Informatique", QuantiteEnStock = 15, SeuilAlerte = 5, PrixUnitaire = 450 }

    };

            dataGridView1.Columns.Clear();              // 🔄 Supprime les colonnes existantes
            dataGridView1.DataSource = null;            // 🔁 Réinitialise la source
            dataGridView1.DataSource = produits;
        }


        private void txtNomProduit_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormaterDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = false;

        }

        private void dgvProduits_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = (DataGridView)sender;
            string rowNumber = (e.RowIndex + 1).ToString(); // commence à 1

            // Calculer la position de dessin
            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var row = dataGridView1.Rows[e.RowIndex];
            int stock = Convert.ToInt32(row.Cells["QuantiteEnStock"].Value);
            int seuil = Convert.ToInt32(row.Cells["SeuilAlerte"].Value);
            if (stock <= seuil)
                row.DefaultCellStyle.BackColor = Color.LightCoral;

            System.Drawing.Rectangle headerBounds = new System.Drawing.Rectangle(
                e.RowBounds.Left,
                e.RowBounds.Top,
                grid.RowHeadersWidth,
                e.RowBounds.Height);

            e.Graphics.DrawString(rowNumber, this.Font, Brushes.Black, headerBounds, centerFormat);
        }





        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox_prix_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var row = dataGridView1.CurrentRow;

                lblNomSelected.Text = "Nom : " + row.Cells["Nom"].Value.ToString();
                lblCategorieSelected.Text = "Catégorie : " + row.Cells["Categorie"].Value.ToString();
                lblStockSelected.Text = "Stock : " + row.Cells["QuantiteEnStock"].Value.ToString();
                lblPrixSelected.Text = "Prix : " + string.Format("{0:0.00} €", row.Cells["PrixUnitaire"].Value);
            }


            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                var row = dataGridView1.CurrentRow;

                txtNomProduit.Text = row.Cells["Nom"].Value.ToString();
                cmbCategorie.Text = row.Cells["Categorie"].Value.ToString();
                numQuantite.Value = Convert.ToInt32(row.Cells["QuantiteEnStock"].Value);
                numSeuil.Value = Convert.ToInt32(row.Cells["SeuilAlerte"].Value);
                numPrix.Value = Convert.ToDecimal(row.Cells["PrixUnitaire"].Value);
            }
            // Activer ou désactiver le bouton Modifier
            btnModifier.Enabled = dataGridView1.CurrentRow != null;
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            var resultats = produits.Where(p => p.Nom.ToLower().Contains(searchbox.Text.ToLower())).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = resultats;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = resultats;
        }

        private void ChargerPage()
        {
            int totalProduits = produits.Count;
            int totalPages = (int)Math.Ceiling((double)totalProduits / pageSize);

            var produitsPage = produits
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = produitsPage;

            // Mise à jour du label de pagination
            lblPageInfo.Text = $"Page {pageIndex} / {totalPages}";

            // Désactiver les boutons si en début ou fin
            btnPrecedent.Enabled = pageIndex > 1;
            btnSuivant.Enabled = pageIndex < totalPages;
        }


        private void titreProduit_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panelProduitSelectionne_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            pageIndex++;
            ChargerPage();
        }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            pageIndex--;
            ChargerPage();
        }

        private void cmbCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // Lire les données depuis les champs de saisie
            string nom = txtNomProduit.Text.Trim();
            string categorie = cmbCategorie.Text.Trim();
            int quantite = (int)numQuantite.Value;
            int seuil = (int)numSeuil.Value;
            decimal prix = (decimal)numPrix.Value;

            // Vérification minimale
            if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(categorie))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            // Créer un nouveau produit
            Produit nouveauProduit = new Produit
            {
                Nom = nom,
                Categorie = categorie,
                QuantiteEnStock = quantite,
                SeuilAlerte = seuil,
                PrixUnitaire = prix
            };

            // Ajouter à la liste
            produits.Add(nouveauProduit);

            // Recalcul du nombre total de pages
            int totalPages = (int)Math.Ceiling((double)produits.Count / pageSize);
            int pageIndex = totalPages; // Aller à la dernière page

            // Rafraîchir la vue
            ChargerPage();

            // Réinitialiser le formulaire
            txtNomProduit.Text = "";
            cmbCategorie.SelectedIndex = -1;
            numQuantite.Value = 0;
            numSeuil.Value = 0;
            numPrix.Value = 0;

            txtNomProduit.Focus();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Veuillez d'abord sélectionner un produit à modifier.");
                return;
            }

            int indexGlobal = (pageIndex - 1) * pageSize + dataGridView1.CurrentRow.Index;

            // Vérifier l'index dans la liste globale
            if (indexGlobal >= produits.Count)
            {
                MessageBox.Show("Erreur de sélection.");
                return;
            }

            // Mettre à jour les champs
            produits[indexGlobal].Nom = txtNomProduit.Text.Trim();
            produits[indexGlobal].Categorie = cmbCategorie.Text.Trim();
            produits[indexGlobal].QuantiteEnStock = (int)numQuantite.Value;
            produits[indexGlobal].SeuilAlerte = (int)numSeuil.Value;
            produits[indexGlobal].PrixUnitaire = numPrix.Value;

            ChargerPage(); // Rafraîchir la page

            MessageBox.Show("Produit modifié avec succès.");

            // Réinitialiser les champs
            txtNomProduit.Text = "";
            cmbCategorie.SelectedIndex = -1;
            numQuantite.Value = 0;
            numSeuil.Value = 0;
            numPrix.Value = 0;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Veuillez sélectionner un produit à supprimer.");
                return;
            }

            // Demander confirmation
            DialogResult result = MessageBox.Show(
                "Êtes-vous sûr de vouloir supprimer ce produit ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes) return;

            // Calculer l'index réel dans la liste globale
            int indexGlobal = (pageIndex - 1) * pageSize + dataGridView1.CurrentRow.Index;

            if (indexGlobal >= produits.Count)
            {
                MessageBox.Show("Erreur lors de la suppression.");
                return;
            }

            // Supprimer le produit de la liste
            produits.RemoveAt(indexGlobal);

            // Recalculer le nombre de pages et ajuster la page si besoin
            int totalPages = (int)Math.Ceiling((double)produits.Count / pageSize);
            if (pageIndex > totalPages && totalPages > 0)
                pageIndex = totalPages;
            else if (totalPages == 0)
                pageIndex = 1;

            // Mettre à jour l'affichage
            ChargerPage();

            MessageBox.Show("Produit supprimé avec succès.");

            // Réinitialiser les champs
            txtNomProduit.Text = "";
            cmbCategorie.SelectedIndex = -1;
            numQuantite.Value = 0;
            numSeuil.Value = 0;
            numPrix.Value = 0;
        }

        private void btnSupprimer_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Veuillez sélectionner un produit à supprimer.");
                return;
            }

            // Demande confirmation
            DialogResult result = MessageBox.Show(
                "Êtes-vous sûr de vouloir supprimer ce produit ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes) return;

            // Calcule l'index réel dans la liste globale
            int indexGlobal = (pageIndex - 1) * pageSize + dataGridView1.CurrentRow.Index;

            if (indexGlobal >= produits.Count)
            {
                MessageBox.Show("Erreur lors de la suppression.");
                return;
            }

            // Supprime le produit de la liste
            produits.RemoveAt(indexGlobal);

            // Recalcule le nombre de pages et ajuster la page si besoin
            int totalPages = (int)Math.Ceiling((double)produits.Count / pageSize);
            if (pageIndex > totalPages && totalPages > 0)
                pageIndex = totalPages;
            else if (totalPages == 0)
                pageIndex = 1;

            // Mets à jour l'affichage
            ChargerPage();

            MessageBox.Show("Produit supprimé avec succès.");

            // Réinitialiser les champs
            txtNomProduit.Text = "";
            cmbCategorie.SelectedIndex = -1;
            numQuantite.Value = 0;
            numSeuil.Value = 0;
            numPrix.Value = 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Réinitialiser tous les champs
            txtNomProduit.Text = "";
            cmbCategorie.SelectedIndex = -1;
            numQuantite.Value = 0;
            numSeuil.Value = 0;
            numPrix.Value = 0;

            // Déselectionner la ligne sélectionnée dans le DataGridView
            dataGridView1.ClearSelection();

            // Remettre le focus sur le champ Nom
            txtNomProduit.Focus();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Produits");

                        worksheet.Cells[1, 1].Value = "Nom";
                        worksheet.Cells[1, 2].Value = "Catégorie";
                        worksheet.Cells[1, 3].Value = "Quantité";
                        worksheet.Cells[1, 4].Value = "Seuil";
                        worksheet.Cells[1, 5].Value = "Prix";

                        for (int i = 0; i < produits.Count; i++)
                        {
                            worksheet.Cells[i + 2, 1].Value = produits[i].Nom;
                            worksheet.Cells[i + 2, 2].Value = produits[i].Categorie;
                            worksheet.Cells[i + 2, 3].Value = produits[i].QuantiteEnStock;
                            worksheet.Cells[i + 2, 4].Value = produits[i].SeuilAlerte;
                            worksheet.Cells[i + 2, 5].Value = produits[i].PrixUnitaire;
                        }

                        package.SaveAs(new FileInfo(sfd.FileName));
                        MessageBox.Show("Export Excel réussi !");
                    }
                }
            }


        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog sfd = new SaveFileDialog() { Filter = "Fichier PDF|*.pdf" })
    {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    doc.Add(new Paragraph("Liste des produits\n\n"));

                    PdfPTable table = new PdfPTable(5);
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

                    MessageBox.Show("Export PDF réussi !");
                }
            }
        }

        private void cmbCategorie_Click(object sender, EventArgs e)
        {
            cmbCategorie.Items.Clear();
            cmbCategorie.Items.AddRange(new string[]
            {
        "Informatique",
        "Mobilier",
        "Bureautique",
        "Papeterie",
        "Accessoires"
            });

            cmbCategorie.DropDownStyle = ComboBoxStyle.DropDownList;

            ChargerProduitsFictifs();
            ChargerPage();
        }
    }
}
