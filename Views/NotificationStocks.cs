using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion_inventaire.DataAccess;
using Gestion_inventaire.Models;
using Gestion_inventaire.Services;
using Npgsql;

namespace Gestion_inventaire.Views
{
    public partial class NotificationStocks : Form
    {
        // Instance du repository pour accéder aux données de notification
        private readonly NotificationRepository notificationRepo = new NotificationRepository();

        public NotificationStocks()
        {
            InitializeComponent();

        }

        private void NotificationStocks_Load(object sender, EventArgs e)
        {
            ChargerNotifications();
            notificationRepo.GenererNotificationStockFaible();
            NotificationManager.VerifierEtGenererAlertes();
            //JouerSonAlerte();
            FiltrerNotifications();
            ActualiserNotifications();
            dvgNotification.RowPostPaint += dvgNotification_RowPostPaint;
            cbLue.CheckedChanged += cbLue_CheckedChanged;
            cbNonLue.CheckedChanged += cbNonLue_CheckedChanged;
            cbTout.CheckedChanged += cbTout_CheckedChanged;
        }

        // Méthode qui charge toutes les notifications
        private void ChargerNotifications() 
        {
            //AppliquerCouleursLignes();
            var notifications = notificationRepo.GetAll();

            dvgNotification.DataSource = null;
            dvgNotification.Columns.Clear(); // Essentiel pour éviter les colonnes dupliquées
            dvgNotification.AutoGenerateColumns = true;
            dvgNotification.DataSource = notifications;

            if (dvgNotification.Columns.Contains("Id"))
                dvgNotification.Columns["Id"].Visible = false;

            dvgNotification.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Numérotation des lignes dans le DataGridView
        private void dvgNotification_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = (DataGridView)sender;
            string rowIdx = (e.RowIndex + 1).ToString();

            using (SolidBrush brush = new SolidBrush(grid.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(
                    rowIdx,
                    grid.Font,
                    brush,
                    e.RowBounds.Location.X + 10,
                    e.RowBounds.Location.Y + 4
                );
            }
        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dvgNotification.Rows[e.RowIndex].DataBoundItem is Notification notification)
            {
                if (notification.Statut == "Non lue")
                {
                    dvgNotification.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    dvgNotification.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        public void JouerSonAlerte()
        {
            SoundPlayer player = new SoundPlayer("alerte.wav");
            player.Play();
        }


        // Applique les filtres (Tout, Lues, Non Lues)
        private void FiltrerNotifications()
        {
            var toutesLesNotifications = notificationRepo.GetAll(); // ← Ce GetAll() exclut déjà les supprimées

            var toutes = notificationRepo.GetAll();

            List<Notification> result;

            if (cbNonLue.Checked)
            {
                result = toutes.Where(n => n.Statut == "Non lue").ToList();
            }
            else if (cbLue.Checked)
            {
                result = toutes.Where(n => n.Statut == "Lue").ToList();
            }
            else
            {
                result = toutes;
            }

            dvgNotification.DataSource = null;
            dvgNotification.DataSource = result;

            if (dvgNotification.Columns.Contains("Id"))
                dvgNotification.Columns["Id"].Visible = false;

            AppliquerCouleursLignes();
        }


        private void cbTout_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTout.Checked)
            {
                cbNonLue.Checked = false;
                cbLue.Checked = false;
                FiltrerNotifications();
            }
        }

        private void cbNonLue_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNonLue.Checked)
            {
                cbTout.Checked = false;
                cbLue.Checked = false;
                FiltrerNotifications();
            }
        }

        private void cbLue_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLue.Checked)
            {
                cbTout.Checked = false;
                cbNonLue.Checked = false;
                FiltrerNotifications();
            }
        }



        private void btnDoneRead_Click(object sender, EventArgs e)
        {
            
            if (dvgNotification.CurrentRow != null)
            {
                // Récupère l'ID même si la colonne est masquée
                int id;
                object idValue = dvgNotification.CurrentRow.Cells["Id"].Value;

                if (idValue != null && int.TryParse(idValue.ToString(), out id))
                {
                    using (var conn = ConnexionManager.GetConnection())
                    {
                       
                        string query = "UPDATE Notifications SET Statut = 'Lue' WHERE Id = @Id";

                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", id);
                            int affected = cmd.ExecuteNonQuery();

                            if (affected > 0)
                            {
                                MessageBox.Show("Notification marquée comme lue !");
                                FiltrerNotifications();            // recharge les données filtrées
                                ActualiserNotifications();// moi
                                AppliquerCouleursLignes();         // met à jour les couleurs
                            }
                            else
                            {
                                MessageBox.Show("Aucune mise à jour effectuée. ID introuvable ?");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ID non valide.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une notification.");
            }
        }

        // Recharge toutes les notifications
        private void ActualiserNotifications()
        {
            var data = notificationRepo.GetAll();
            dvgNotification.DataSource = null;
            dvgNotification.Columns.Clear();
            dvgNotification.DataSource = data;

            if (dvgNotification.Columns.Contains("Id"))
                dvgNotification.Columns["Id"].Visible = false;

            dvgNotification.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            AppliquerStyleNotifications(data);
        }


        // Changement de couleur selon statut
        private void dvgNotification_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dvgNotification.Rows[e.RowIndex];
            var statut = row.Cells["Statut"].Value?.ToString();

            if (statut == "Non lue")
            {
                row.DefaultCellStyle.BackColor = Color.LightGray;
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ActualiserNotifications();

            //FiltrerNotifications();

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //dvgNotification.DataSource = null;
            //dvgNotification.Rows.Clear();
            foreach (DataGridViewRow row in dvgNotification.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    int id = (int)row.Cells["Id"].Value;

                    using (var conn = ConnexionManager.GetConnection())
                    {
                        string query = "UPDATE Notifications SET Supprimee = TRUE WHERE Id = @Id";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            MessageBox.Show("Notification supprimée visuellement !");
            FiltrerNotifications(); // Recharge sans celles supprimées
        }


        // Appliquer le style selon les statuts (coloration)
        private void AppliquerStyleNotifications(List<Notification> notifications)
        {
            for (int i = 0; i < dvgNotification.Rows.Count; i++)
            {
                var notif = notifications[i];
                if (notif.Statut == "Non lue")
                {
                    dvgNotification.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    dvgNotification.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void AppliquerCouleursLignes()
        {
            foreach (DataGridViewRow row in dvgNotification.Rows)
            {
                string statut = row.Cells["Statut"].Value?.ToString();

                if (statut == "Non lue")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
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
            this.Hide(); // Hide the current form
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
