using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion_inventaire.Controllers;
using Gestion_inventaire.DataAccess;
using Gestion_inventaire.Models;
using iTextSharp.text.pdf;
using iTextSharp.text;
using OfficeOpenXml;
using Gestion_inventaire.Services;

namespace Gestion_inventaire.Views
{

    public partial class MouvementStocks : Form
    {
        private int pageSize = 10;
        private int currentPage = 1;
        // Liste des mouvements en mémoire
        private List<MouvementDisplay> mouvements = new List<MouvementDisplay>();
        //  Accès aux bases de données Produits et Mouvements
        private readonly ProduitRepository produitRepo = new ProduitRepository();
        private readonly MouvementRepository mouvementRepo = new MouvementRepository(ConnexionManager.ConnectionString);


        public MouvementStocks()
        {
            InitializeComponent();
            dataGridView1.RowPostPaint += DataGridView1_RowPostPaint;
            this.btnSuivant.Click += new System.EventHandler(this.btnSuivant_Click);
            btnPrecedent.Click += btnPrecedent_Click;
            btnSuivant.Click += btnSuivant_Click;


        }

        private void MouvementStocks_Load(object sender, EventArgs e)
        {
            // Chargement des types de mouvements (ENTREE/SORTIE) dans le ComboBox
            //NotificationManager.VerifierEtGenererAlertes();
            cmbType.Items.AddRange(new string[] { "ENTREE", "SORTIE" });
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            // Configuration des ComboBox de sélection produit
            cmtProduit.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduitSelect.DropDownStyle = ComboBoxStyle.DropDownList;

            radioTous.Checked = true;

            ChargerProduits();
            ChargerMouvements();

            //  Événements déclencheurs du rechargement des filtres
            cmbProduitSelect.SelectedIndexChanged += (s, ev) => ChargerMouvements();
            radioTous.CheckedChanged += (s, ev) => ChargerMouvements();
            radioEntrée.CheckedChanged += (s, ev) => ChargerMouvements();
            radioSortie.CheckedChanged += (s, ev) => ChargerMouvements();
        }


        private void btnValiderMove_Click(object sender, EventArgs e)
        {
            // Vérification du produit et du type sélectionné
            if (cmtProduit.SelectedItem is Produit selectedProduit && cmbType.SelectedItem is string type)
            {
                int quantite = (int)npdQunatite.Value;

                // Vérifier si c'est un mouvement de SORTIE et si le stock est suffisant
                if (type == "SORTIE")
                {
                    var produitRepo = new ProduitRepository(); // assure-toi que ce repo est accessible
                    int stockActuel = produitRepo.GetQuantiteStockParId(selectedProduit.Id);

                    if (quantite > stockActuel)
                    {
                        MessageBox.Show("Stock insuffisant pour effectuer la sortie !");
                        return;
                    }
                }

                // Création d'un objet mouvement
                var mouvement = new MvtStocks
                {
                    ProduitId = selectedProduit.Id,
                    Type = type,
                    QuantiteEnStock = quantite,
                    Remarque = txtBoxRemarque.Text,
                    UtilisateurId = SessionManager.IdSessionActive
                };

                // Exécution de l’ajout en base via le contrôleur
                var controller = new MouvementController(ConnexionManager.ConnectionString);
                if (controller.AjouterMouvement(mouvement))
                {
                    MessageBox.Show("Mouvement ajouté !");
                    ChargerProduits();     // rafraîchir le stock affiché
                    ChargerMouvements();   // rafraîchir la liste des mouvements
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'ajout.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
            }
        }

        //  Recharge la liste des mouvements avec filtres
        private void ChargerMouvements()
        {
            string typeFiltre = radioEntrée.Checked ? "ENTREE" :
                                radioSortie.Checked ? "SORTIE" : null;

            var selectedProduit = cmbProduitSelect.SelectedItem as Produit;
            int? produitIdFiltre = selectedProduit?.Id;
            //if (cmbProduitSelect.SelectedItem == null || produitIdFiltre == null)
            //    produitIdFiltre = null;

            var mouvements = mouvementRepo.GetAllAvecFiltres(typeFiltre, produitIdFiltre);

            int totalPages = (int)Math.Ceiling((double)mouvements.Count / pageSize);
            var mouvementsPage = mouvements
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = mouvements;
            dataGridView1.DataSource = mouvementsPage;

            lblPageInfo.Text = $"Page {currentPage} sur {Math.Max(1, totalPages)}";
            btnPrecedent.Enabled = currentPage > 1;
            btnSuivant.Enabled = currentPage < totalPages;


        }

        //  Charge les produits dans les deux ComboBox
        private void ChargerProduits()
        {
            var produits = produitRepo.GetAll();

            if (produits.Count == 0)
            {
                MessageBox.Show("Aucun produit trouvé dans la base de données.");
                return;
            }

            cmtProduit.DataSource = produits.ToList();
            cmtProduit.DisplayMember = "Nom";
            cmtProduit.ValueMember = "Id";

            cmbProduitSelect.DataSource = produits.ToList();
            cmbProduitSelect.DisplayMember = "Nom";
            cmbProduitSelect.ValueMember = "Id";

        }

        private void logout_Click(object sender, EventArgs e)
        {
            SessionManager.TerminerSession();
            this.Hide();
            new LoginFormUI().Show();
        }

        private void rdbFiltrage_CheckedChanged(object sender, EventArgs e) => ChargerMouvements();
        private void cmbFiltreProduit_SelectedIndexChanged(object sender, EventArgs e) => ChargerMouvements();
        private void label2_Click(object sender, EventArgs e) { }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                ChargerMouvements();
            }
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)mouvements.Count / pageSize);

            if (totalPages == 0) return;

            if (currentPage < totalPages)
            {
                currentPage++;
                ChargerMouvements();
            }

        }

        //  Numérotation automatique des lignes
        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            string rowIndex = ((pageSize * (currentPage - 1)) + e.RowIndex + 1).ToString();

            using (SolidBrush brush = new SolidBrush(grid.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(rowIndex,
                    grid.RowHeadersDefaultCellStyle.Font,
                    brush,
                    e.RowBounds.Location.X + 15,
                    e.RowBounds.Location.Y + 4);
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            // Recharge les mouvements filtrés
            string typeFiltre = radioEntrée.Checked ? "ENTREE" :
                                radioSortie.Checked ? "SORTIE" : null;
            var selectedProduit = cmbProduitSelect.SelectedItem as Produit;
            int? produitIdFiltre = selectedProduit?.Id;
            var mouvementsExport = mouvementRepo.GetAllAvecFiltres(typeFiltre, produitIdFiltre);

            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "PDF files (*.pdf)|*.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();
                    PdfPTable table = new PdfPTable(4);
                    table.AddCell("Type");
                    table.AddCell("Produit");
                    table.AddCell("Quantité");
                    table.AddCell("Date/Heure");

                    foreach (var m in mouvementsExport)
                    {
                        table.AddCell(m.Type);
                        table.AddCell(m.Produit);
                        table.AddCell(m.Quantite.ToString());
                        table.AddCell(m.DateHeure.ToString("g"));
                    }

                    doc.Add(table);
                    doc.Close();

                    MessageBox.Show("Exportation PDF réussie !");
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            // Recharge les mouvements filtrés
            string typeFiltre = radioEntrée.Checked ? "ENTREE" :
                                radioSortie.Checked ? "SORTIE" : null;
            var selectedProduit = cmbProduitSelect.SelectedItem as Produit;
            int? produitIdFiltre = selectedProduit?.Id;
            var mouvementsExport = mouvementRepo.GetAllAvecFiltres(typeFiltre, produitIdFiltre);

            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "Excel files (*.xlsx)|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var package = new ExcelPackage())
                    {
                        var ws = package.Workbook.Worksheets.Add("Mouvements");
                        ws.Cells[1, 1].Value = "Type";
                        ws.Cells[1, 2].Value = "Produit";
                        ws.Cells[1, 3].Value = "Quantité";
                        ws.Cells[1, 4].Value = "Date/Heure";

                        for (int i = 0; i < mouvementsExport.Count; i++)
                        {
                            var m = mouvementsExport[i];
                            ws.Cells[i + 2, 1].Value = m.Type;
                            ws.Cells[i + 2, 2].Value = m.Produit;
                            ws.Cells[i + 2, 3].Value = m.Quantite;
                            ws.Cells[i + 2, 4].Value = m.DateHeure.ToString("g");
                        }

                        File.WriteAllBytes(sfd.FileName, package.GetAsByteArray());
                        MessageBox.Show("Exportation Excel réussie !");
                    }
                }
            }
        }

        private void linkDashboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var DashboardForm = new DashboardForm();
            DashboardForm.Show();
            this.Hide(); // Hide the current form
        }

        private void linkMVT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var MouvementStocksForm = new MouvementStocks();
            MouvementStocksForm.Show();
            this.Hide();

        }

        private void linkHist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var HistoriqueForm = new HistoriqueStocks();
            HistoriqueForm.Show();
            this.Hide(); // Hide the current form
        }

        private void linkProd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var ProduitsForm = new ProduitsForm();
            ProduitsForm.Show();
            this.Hide(); // Hide the current form
        }
    }
}
