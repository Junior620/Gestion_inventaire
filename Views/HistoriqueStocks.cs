using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion_inventaire.DataAccess;
using Gestion_inventaire.Models;
using Gestion_inventaire.Services;
using Npgsql;
using NpgsqlTypes;
using static Gestion_inventaire.Views.SignUpForm;


namespace Gestion_inventaire.Views
{

    public partial class HistoriqueStocks : Form
    {
        // Liste complète des historiques chargés pour pagination
        private List<HistoriqueDisplay> tousLesHistoriques = new List<HistoriqueDisplay>();
        // Accès aux opérations sur la base de données
        private readonly HistoriqueRepository historiqueRepo = new HistoriqueRepository();
        private int pageSize = 10;
        private int currentPage = 1;
        public HistoriqueStocks()
        {
            InitializeComponent();
            dataGridView1.RowPostPaint += DataGridView1_RowPostPaint;            //  Événement pour le numéro de ligne
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void ChargerHistorique()
        {
            // Récupère le filtre sélectionné (Ajout, Modif…)
            string actionFiltre = cmbFiltre.SelectedItem?.ToString();
            // Charge les données depuis le dépôt
            tousLesHistoriques = historiqueRepo.GetHistorique(actionFiltre);
            // Calcule le nombre total de pages
            int totalPages = (int)Math.Ceiling((double)tousLesHistoriques.Count / pageSize);
            // Applique la pagination
            var pageData = tousLesHistoriques
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var data = historiqueRepo.GetHistorique(actionFiltre);

            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = data;

            // Actualise les infos de page
            lblPageInfo.Text = $"Page {currentPage} sur {Math.Max(1, totalPages)}";
            btnPrecedent.Enabled = currentPage > 1;
            btnSuivant.Enabled = currentPage < totalPages;
        }


        private void HistoriqueStocks_Load(object sender, EventArgs e)
        {
            cmbFiltre.Items.AddRange(new string[] { "Ajouter", "Modifier", "Supprimer" });
            cmbFiltre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltre.SelectedIndexChanged += (s, ev) => ChargerHistorique();

            ChargerHistorique();
        }

        public void LogAction(string action, string produitNom, int quantite)
        {
            using (var conn = ConnexionManager.GetConnection())
            {
                var query = @"INSERT INTO HistoriqueActions (Action, Produit, Quantite)
                      VALUES (@Action, @Produit, @Quantite)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@Produit", produitNom);
                    cmd.Parameters.AddWithValue("@Quantite", quantite);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        private void logout_Click(object sender, EventArgs e)
        {
            SessionManager.TerminerSession();
            this.Hide();
            new LoginFormUI().Show();

        }

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

        private void lblPageInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportServiceExcel.Export(tousLesHistoriques, sfd.FileName);
                    MessageBox.Show("Export Excel réussi !");
                }
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Fichier PDF|*.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportServicePdf.Export(tousLesHistoriques, sfd.FileName);
                    MessageBox.Show("Export PDF réussi !");
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
            var MouvementForm = new MouvementStocks();
            MouvementForm.Show();
            this.Hide();
        }

        private void linkHist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var HistoriqueForm = new HistoriqueStocks();
            HistoriqueForm.Show();
            this.Hide();
        }

        private void linkProd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var ProduitsForm = new ProduitsForm();
            ProduitsForm.Show();
            this.Hide(); // Hide the current form
        }
    }
}
