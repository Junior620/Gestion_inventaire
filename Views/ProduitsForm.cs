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
using Gestion_inventaire.DataAccess;
using Gestion_inventaire.Controllers;
using Gestion_inventaire.Services;


namespace Gestion_inventaire.Views
{
    public partial class ProduitsForm : Form
    {
        
        private readonly NotificationRepository notificationRepo = new NotificationRepository();

        // Méthodes pour eviter les erreus de conversion null/vides
        private int ConvertSafeToInt(object value)
        {
            return int.TryParse(value?.ToString(), out int result) ? result : 0;
        }

        private decimal ConvertSafeToDecimal(object value)
        {
            return decimal.TryParse(value?.ToString(), out decimal result) ? result : 0m;
        }

        int pageSize = 15; // Nombre de produits par page
        int pageIndex = 1; // Page actuelle
        private ProduitController produitController = new ProduitController();
        private ProduitRepository produitRepo = new ProduitRepository();
        private List<Produit> produits = new List<Produit>();

        //List<Produit> produits = new List<Produit>();
        public ProduitsForm()
        {
            InitializeComponent();
            ChargerProduitsFictifs();
            dataGridView1.RowPostPaint += dgvProduits_RowPostPaint; // Événement pour le numéro de ligne
            FormaterDataGridView();
            ChargerProduitsFictifs(); // Charge toute la liste
            ChargerPage();            // Affiche la première page
            ChargerProduitsBD();
        }

        

        // Fonction de chargement fictive
        private void ChargerProduitsFictifs()
        {
    
        }

        // Fonction de chargement depuis la base de données
        private void ChargerProduitsBD()
        {
            produits = produitRepo.GetAll();
            ChargerPage();
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

        // Ajout de la numérotation des lignes + surbrillance de stock faible
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
            
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
                return;

            var row = dataGridView1.CurrentRow;

            // Affichage dans le panneau de droite
            lblNomSelected.Text = "Nom : " + (row.Cells["Nom"].Value?.ToString() ?? "—");
            lblCategorieSelected.Text = "Catégorie : " + (row.Cells["Categorie"].Value?.ToString() ?? "—");
            lblStockSelected.Text = "Stock : " + (row.Cells["QuantiteEnStock"].Value?.ToString() ?? "—");

            var prix = row.Cells["PrixUnitaire"].Value;
            lblPrixSelected.Text = "Prix : " + (prix != null ? string.Format("{0:0.00} €", prix) : "—");

            // Pré-remplissage des champs de modification
            txtNomProduit.Text = row.Cells["Nom"].Value?.ToString() ?? "";
            cmbCategorie.Text = row.Cells["Categorie"].Value?.ToString() ?? "";

            numQuantite.Value = ConvertSafeToInt(row.Cells["QuantiteEnStock"].Value);
            numSeuil.Value = ConvertSafeToInt(row.Cells["SeuilAlerte"].Value);
            numPrix.Value = ConvertSafeToDecimal(row.Cells["PrixUnitaire"].Value);

            // Activer ou désactiver le bouton Modifier
            btnModifier.Enabled = true;

        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
           
            var resultats = produitController.RechercherParNom(searchbox.Text);
            dataGridView1.DataSource = resultats;
        }

        // Gère la pagination
        private void ChargerPage()
        {
            

            int totalProduits = produits.Count;
            int totalPages = (int)Math.Ceiling((double)totalProduits / pageSize);

            var produitsPage = produits
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // 🔧 Colonnes manuelles
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nom", DataPropertyName = "Nom", HeaderText = "Nom" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Categorie", DataPropertyName = "Categorie", HeaderText = "Catégorie" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "QuantiteEnStock", DataPropertyName = "QuantiteEnStock", HeaderText = "Quantité en Stock" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "SeuilAlerte", DataPropertyName = "SeuilAlerte", HeaderText = "Seuil d'alerte" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "PrixUnitaire", DataPropertyName = "PrixUnitaire", HeaderText = "Prix Unitaire" });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id", // <-- c’est ce nom qu’on utilisera dans .Cells["Id"]
                DataPropertyName = "Id",
                HeaderText = "ID",
                Visible = false // tu peux la masquer ici
            });


            //  Source de données
            dataGridView1.DataSource = produitsPage;

            //  Pagination
            lblPageInfo.Text = $"Page {pageIndex} / {totalPages}";
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
            Produit nouveau = new Produit
            {
                Nom = txtNomProduit.Text.Trim(),
                Categorie = cmbCategorie.Text.Trim(),
                QuantiteEnStock = (int)numQuantite.Value,
                SeuilAlerte = (int)numSeuil.Value,
                PrixUnitaire = numPrix.Value

            };

            if (string.IsNullOrWhiteSpace(nouveau.Nom) || string.IsNullOrWhiteSpace(nouveau.Categorie))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            if (produitController.AjouterProduit(nouveau))
            //int idAjoute = produitRepo.AjouterProduitEtRetournerId(nouveau);
            //if (idAjoute > 0)
            {
                //nouveau.Id = idAjoute;
                MessageBox.Show("Produit ajouté !");
                // ici
                //new HistoriqueStocks().LogAction("Ajouter", SessionManager.UtilisateurId, nouveau.QuantiteEnStock, nouveau.Id);
                new HistoriqueStocks().LogAction("Ajouter", nouveau.Nom, nouveau.QuantiteEnStock);
                notificationRepo.GenererNotificationStockFaible(); // ✅ ICI
                RafraichirProduits();
                ReinitialiserChamps();
            }

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow == null) return;

            Produit produitModifie = new Produit
            {
                Id = (int)dataGridView1.CurrentRow.Cells["Id"].Value,
                Nom = txtNomProduit.Text.Trim(),
                Categorie = cmbCategorie.Text.Trim(),
                QuantiteEnStock = (int)numQuantite.Value,
                SeuilAlerte = (int)numSeuil.Value,
                PrixUnitaire = numPrix.Value
            };

            if (produitController.ModifierProduit(produitModifie))
            {
                MessageBox.Show("Produit modifié !");
                //new HistoriqueStocks().LogAction("Modifier", SessionManager.IdSessionActive, produitModifie.QuantiteEnStock, produitModifie.Id);
                new HistoriqueStocks().LogAction("Modifier", produitModifie.Nom, produitModifie.QuantiteEnStock);
                notificationRepo.GenererNotificationStockFaible(); // ✅ ICI
                RafraichirProduits();
                ReinitialiserChamps();
            }
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
            

            if (dataGridView1.CurrentRow == null) return;

            int id = (int)dataGridView1.CurrentRow.Cells["Id"].Value;

            var confirm = MessageBox.Show("Supprimer ce produit ?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes && produitController.SupprimerProduit(id))
            {
                MessageBox.Show("Produit supprimé !");
                //new HistoriqueStocks().LogAction("Supprimer", SessionManager.IdSessionActive, 0, id);

                RafraichirProduits();
                ReinitialiserChamps();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            
            ReinitialiserChamps();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportServiceExcel.Export(produits, sfd.FileName);
                    MessageBox.Show("Export Excel réussi !");
                }
            }


        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Fichier PDF|*.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportServicePdf.Export(produits, sfd.FileName);
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

        private void logout_Click(object sender, EventArgs e)
        {
            SessionManager.TerminerSession();
            this.Hide();
            new LoginFormUI().Show();

        }

        private void RafraichirProduits()
        {
            produits = produitController.ObtenirTous();
            ChargerPage(); // recharge la page actuelle avec les données à jour
        }

        private void ReinitialiserChamps()
        {
            txtNomProduit.Text = "";
            cmbCategorie.SelectedIndex = -1;
            numQuantite.Value = 0;
            numSeuil.Value = 0;
            numPrix.Value = 0;
            txtNomProduit.Focus();
            dataGridView1.ClearSelection();
        }


        private void ProduitsForm_Load(object sender, EventArgs e)
        {
            NotificationManager.VerifierEtGenererAlertes();
        }

        private void linkMVT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var MouvementStocks = new MouvementStocks();
            MouvementStocks.Show();
            this.Hide(); // Cacher le formulaire actuel
        }

        private void linkHist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var HistoriqueStocks = new HistoriqueStocks();
            HistoriqueStocks.Show();
            this.Hide(); // Cacher le formulaire actuel
        }

        private void linkProd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var produitsForm = new ProduitsForm();
            produitsForm.Show();
            this.Hide(); // Cacher le formulaire actuel
        }

        private void linkDashboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var DashboardForm = new DashboardForm();
            DashboardForm.Show();
            this.Hide(); // Cacher le formulaire actuel
        }
    }
}
