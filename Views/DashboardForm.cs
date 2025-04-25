using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Gestion_inventaire.DataAccess;
using Gestion_inventaire.Services;
using iTextSharp.text;

namespace Gestion_inventaire.Views
{
    public partial class DashboardForm : Form
    {
        private HistoriqueRepository historiqueRepo = new HistoriqueRepository();
        private int pageSize = 10;
        private int currentPage = 1;
        private readonly ProduitRepository produitRepo = new ProduitRepository();
        public DashboardForm()
        {
            InitializeComponent();
            dvgProduitLow.RowPostPaint += DataGridView1_RowPostPaint;            //  Événement pour le numéro de ligne
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // Génère des alertes si besoin dès le chargement
            NotificationManager.VerifierEtGenererAlertes();
            // Affiche le nom de l'utilisateur connecté
            txtNomUser.Text = "Bienvenue : " + SessionManager.NomUtilisateur
            
            // Statistiques globales
            txtStockTotal.Text = produitRepo.GetStockTotal().ToString();
            txtRuptureTotal.Text = produitRepo.GetProduitsEnRupture().ToString();
            txtPrixTotalStock.Text = produitRepo.GetValeurStock().ToString("0.00") + " €";
            
            // Événements de coloration
            dvgProduitLow.RowPrePaint += dgvStockFaible_RowPrePaint;
            dvgProduitAvailale.RowPrePaint += dgvStockVert_RowPrePaint;
            dvgProduitAvailale.RowPostPaint += DgvStockVert_RowPostPaint;

            // Chargements des tableaux et graphiques
            ChargerGraphiqueMouvements();
            ChargerProduitsStockFaible();
            ChargerHistoriqueComplet();
            ChargerProduitsEnStock();

        }

        private void logout_Click(object sender, EventArgs e)
        {
            SessionManager.TerminerSession();
            this.Hide();
            new LoginFormUI().Show();

        }

        private void dvgProduitLow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ChargerProduitsStockFaible()
        {
            var repo = new ProduitRepository();
            var faibles = repo.GetProduitsStockFaible();

            dvgProduitLow.AutoGenerateColumns = false;
            dvgProduitLow.Columns.Clear();

            dvgProduitLow.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nom",
                DataPropertyName = "Nom",
                HeaderText = "Nom"
            });

            dvgProduitLow.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantite",
                DataPropertyName = "QuantiteEnStock",
                HeaderText = "Quantité"
            });

            dvgProduitLow.DataSource = faibles;
        }

        private void ChargerProduitsEnStock()
        {
            //var produits = produitRepo.GetProduitsEnStock();
            //dvgProduitAvailale.DataSource = produits;
            var produits = produitRepo.GetProduitsEnStock();

            dvgProduitAvailale.AutoGenerateColumns = false; // ⛔ Empêche les colonnes automatiques
            dvgProduitAvailale.Columns.Clear();

            dvgProduitAvailale.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nom",
                DataPropertyName = "Nom",
                HeaderText = "Nom"
            });

            dvgProduitAvailale.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "QuantiteEnStock",
                DataPropertyName = "QuantiteEnStock",
                HeaderText = "Quantité"
            });

            dvgProduitAvailale.DataSource = produits;
        }


        // Mise en rouge des lignes pour les stocks faibles
        private void dgvStockFaible_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid?.Rows[e.RowIndex] != null && !grid.Rows[e.RowIndex].IsNewRow)
            {
                grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                grid.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.DarkRed;
                grid.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
            }
        }

        // Mise en vert des lignes pour les produits disponibles
        private void dgvStockVert_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid?.Rows[e.RowIndex] != null && !grid.Rows[e.RowIndex].IsNewRow)
            {
                grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                grid.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.ForestGreen;
                grid.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
            }
        }

        // Numérotation lignes stock faible
        private void DgvStockVert_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            string rowIndex = (e.RowIndex + 1).ToString(); // numéro de ligne (1-based)

            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            System.Drawing.Rectangle headerBounds = new System.Drawing.Rectangle(
                e.RowBounds.Left,
                e.RowBounds.Top,
                grid.RowHeadersWidth,
                e.RowBounds.Height);

            e.Graphics.DrawString(rowIndex, this.Font, Brushes.Black, headerBounds, centerFormat);
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

        private void ChargerHistoriqueComplet()
        {
            var historiqueRepo = new HistoriqueRepository();
            var data = historiqueRepo.GetToutesLesOperations();

            dvgHistoAll.Columns.Clear();
            dvgHistoAll.AutoGenerateColumns = true;
            dvgHistoAll.DataSource = null;
            dvgHistoAll.DataSource = data;

            dvgHistoAll.DefaultCellStyle.BackColor = Color.LightCyan;
            dvgHistoAll.DefaultCellStyle.ForeColor = Color.Black;
            dvgHistoAll.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9);
            dvgHistoAll.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            dvgHistoAll.RowHeadersVisible = false;
            dvgHistoAll.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        private void ChargerGraphiqueMouvements()
        {
            var data = new MouvementRepository(ConnexionManager.ConnectionString).GetMouvementsParJour();

            //chartDataV.Series.Clear();
            ////var series = chartDataV.Series.Add("Mouvements");
            ////series.ChartType = SeriesChartType.Column;

            //// Jours fixes pour garder l’ordre de la semaine
            //var jours = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            ////foreach (var jour in jours)
            ////{
            ////    string j = jour;
            ////    int valeur = data.ContainsKey(j) ? data[j] : 0;
            ////    series.Points.AddXY(j, valeur);
            ////}


            // Remplir les points
            chartDataV.Series.Clear();
            chartDataV.Titles.Clear();
            chartDataV.ChartAreas.Clear();
            chartDataV.Legends.Clear();

            chartDataV.ChartAreas.Add(new ChartArea());

            var series = new Series("Mouvements");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Bold);
            series.LabelForeColor = Color.DarkBlue;
            series.Color = Color.SteelBlue;
            series.BorderWidth = 2;

            // Ajouter les points
            foreach (var jour in data)
            {
                series.Points.AddXY(jour.Key, jour.Value);
            }

            chartDataV.Series.Add(series);

            // Titre
            chartDataV.Titles.Add("Mouvements de Stock par Jour");
            chartDataV.Titles[0].Font = new System.Drawing.Font("Segoe UI", 12, FontStyle.Bold);
            chartDataV.Titles[0].ForeColor = Color.FromArgb(33, 45, 62);

            // Axe X (jours)
            var axisX = chartDataV.ChartAreas[0].AxisX;
            axisX.Title = "Jour";
            axisX.TitleFont = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            axisX.MajorGrid.LineColor = Color.LightGray;
            axisX.LabelStyle.Angle = -45;
            axisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9);
            axisX.Interval = 1;

            // Axe Y (nbre)
            var axisY = chartDataV.ChartAreas[0].AxisY;
            axisY.Title = "Nb Mouvements";
            axisY.TitleFont = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            axisY.MajorGrid.LineColor = Color.LightGray;
            axisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9);

            // Légende
            var legend = new Legend();
            legend.Font = new System.Drawing.Font("Segoe UI", 8);
            legend.ForeColor = Color.DarkSlateGray;
            chartDataV.Legends.Add(legend);

        }


        private void panel5_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var produitForm = new ProduitsForm();
            produitForm.Show();
            this.Hide(); // 
        }

        private void linkProduit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var produitForm = new ProduitsForm();
            produitForm.Show();
            this.Hide(); // 
        }

        private void btnProduitNav_Click(object sender, EventArgs e)
        {
            var produitForm = new ProduitsForm();
            produitForm.Show();
            this.Hide(); 
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var mouvementForm = new MouvementStocks();
            mouvementForm.Show();
            this.Hide();

        }

        private void linkMove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var mouvementForm = new MouvementStocks();
            mouvementForm.Show();
            this.Hide();
        }

        private void btnMoveNav_Click(object sender, EventArgs e)
        {
            var mouvementForm = new MouvementStocks();
            mouvementForm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var historiqueForm = new HistoriqueStocks();
            historiqueForm.Show();
            this.Hide();
        }

        private void linkHisto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var historiqueForm = new HistoriqueStocks();
            historiqueForm.Show();
            this.Hide();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var produits = produitRepo.GetAll();

                    ExportServiceExcel.Export(
                        cheminFichier: sfd.FileName,
                        stockTotal: produits.Sum(p => p.QuantiteEnStock),
                        produitsEnRupture: produits.Count(p => p.QuantiteEnStock == 0),
                        valeurStock: produits.Sum(p => p.QuantiteEnStock * p.PrixUnitaire),
                        stocksFaibles: produits.Where(p => p.QuantiteEnStock < p.SeuilAlerte).ToList(),
                        produitsEnStock: produits.Where(p => p.QuantiteEnStock > 0).ToList(),
                        historiques: historiqueRepo.GetHistorique()
                    );

                    MessageBox.Show("Export Excel complet terminé !");
                }
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "Fichier PDF|*.pdf" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var produits = produitRepo.GetAll();

                ExportServicePdf.Export(
                    stockTotal: produits.Sum(p => p.QuantiteEnStock),
                    produitsRupture: produits.Count(p => p.QuantiteEnStock == 0),
                    valeurStock: produits.Sum(p => p.QuantiteEnStock * p.PrixUnitaire),
                    stocksFaibles: produits.Where(p => p.QuantiteEnStock < p.SeuilAlerte).ToList(),
                    produitsEnStock: produits.Where(p => p.QuantiteEnStock > 0).ToList(),
                    historiques: new HistoriqueRepository().GetHistorique(),
                    chemin: sfd.FileName
                );

                MessageBox.Show("Export PDF effectué avec succès !");
            }
        }
    }
}
