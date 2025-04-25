namespace Gestion_inventaire.Views
{
    partial class NotificationStocks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dvgNotification = new System.Windows.Forms.DataGridView();
            this.notification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateheure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbTout = new System.Windows.Forms.CheckBox();
            this.cbNonLue = new System.Windows.Forms.CheckBox();
            this.btnDoneRead = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.cbLue = new System.Windows.Forms.CheckBox();
            this.linkDashboard = new System.Windows.Forms.LinkLabel();
            this.linkProd = new System.Windows.Forms.LinkLabel();
            this.linkHist = new System.Windows.Forms.LinkLabel();
            this.linkMVT = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dvgNotification)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Notification";
            // 
            // dvgNotification
            // 
            this.dvgNotification.AllowUserToDeleteRows = false;
            this.dvgNotification.AllowUserToOrderColumns = true;
            this.dvgNotification.BackgroundColor = System.Drawing.Color.White;
            this.dvgNotification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgNotification.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.notification,
            this.dateheure,
            this.statut,
            this.Id});
            this.dvgNotification.Location = new System.Drawing.Point(27, 72);
            this.dvgNotification.Name = "dvgNotification";
            this.dvgNotification.ReadOnly = true;
            this.dvgNotification.RowHeadersWidth = 51;
            this.dvgNotification.RowTemplate.Height = 24;
            this.dvgNotification.Size = new System.Drawing.Size(1003, 482);
            this.dvgNotification.TabIndex = 1;
            // 
            // notification
            // 
            this.notification.HeaderText = "Notification";
            this.notification.MinimumWidth = 6;
            this.notification.Name = "notification";
            this.notification.ReadOnly = true;
            this.notification.Width = 550;
            // 
            // dateheure
            // 
            this.dateheure.HeaderText = "Date/heure";
            this.dateheure.MinimumWidth = 6;
            this.dateheure.Name = "dateheure";
            this.dateheure.ReadOnly = true;
            this.dateheure.Width = 250;
            // 
            // statut
            // 
            this.statut.HeaderText = "Statut";
            this.statut.MinimumWidth = 6;
            this.statut.Name = "statut";
            this.statut.ReadOnly = true;
            this.statut.Width = 150;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 125;
            // 
            // cbTout
            // 
            this.cbTout.AutoSize = true;
            this.cbTout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTout.Location = new System.Drawing.Point(27, 576);
            this.cbTout.Name = "cbTout";
            this.cbTout.Size = new System.Drawing.Size(63, 24);
            this.cbTout.TabIndex = 2;
            this.cbTout.Text = "Tout";
            this.cbTout.UseVisualStyleBackColor = true;
            // 
            // cbNonLue
            // 
            this.cbNonLue.AutoSize = true;
            this.cbNonLue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNonLue.Location = new System.Drawing.Point(131, 576);
            this.cbNonLue.Name = "cbNonLue";
            this.cbNonLue.Size = new System.Drawing.Size(86, 24);
            this.cbNonLue.TabIndex = 3;
            this.cbNonLue.Text = "Non lue";
            this.cbNonLue.UseVisualStyleBackColor = true;
            // 
            // btnDoneRead
            // 
            this.btnDoneRead.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnDoneRead.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoneRead.Location = new System.Drawing.Point(27, 622);
            this.btnDoneRead.Name = "btnDoneRead";
            this.btnDoneRead.Size = new System.Drawing.Size(239, 46);
            this.btnDoneRead.TabIndex = 6;
            this.btnDoneRead.Text = "Marquer comme lue";
            this.btnDoneRead.UseVisualStyleBackColor = false;
            this.btnDoneRead.Click += new System.EventHandler(this.btnDoneRead_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Azure;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(340, 622);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(168, 46);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Actualiser";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.LightYellow;
            this.btnDel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(619, 622);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(168, 46);
            this.btnDel.TabIndex = 8;
            this.btnDel.Text = "Effacer";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // cbLue
            // 
            this.cbLue.AutoSize = true;
            this.cbLue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLue.Location = new System.Drawing.Point(254, 576);
            this.cbLue.Name = "cbLue";
            this.cbLue.Size = new System.Drawing.Size(56, 24);
            this.cbLue.TabIndex = 10;
            this.cbLue.Text = "Lue";
            this.cbLue.UseVisualStyleBackColor = true;
            // 
            // linkDashboard
            // 
            this.linkDashboard.AutoSize = true;
            this.linkDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkDashboard.Location = new System.Drawing.Point(613, 23);
            this.linkDashboard.Name = "linkDashboard";
            this.linkDashboard.Size = new System.Drawing.Size(85, 20);
            this.linkDashboard.TabIndex = 38;
            this.linkDashboard.TabStop = true;
            this.linkDashboard.Text = "Dashboard";
            this.linkDashboard.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDashboard_LinkClicked);
            // 
            // linkProd
            // 
            this.linkProd.AutoSize = true;
            this.linkProd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkProd.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkProd.Location = new System.Drawing.Point(960, 23);
            this.linkProd.Name = "linkProd";
            this.linkProd.Size = new System.Drawing.Size(65, 20);
            this.linkProd.TabIndex = 37;
            this.linkProd.TabStop = true;
            this.linkProd.Text = "Produits";
            this.linkProd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkProd_LinkClicked);
            // 
            // linkHist
            // 
            this.linkHist.AutoSize = true;
            this.linkHist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkHist.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkHist.Location = new System.Drawing.Point(850, 23);
            this.linkHist.Name = "linkHist";
            this.linkHist.Size = new System.Drawing.Size(85, 20);
            this.linkHist.TabIndex = 36;
            this.linkHist.TabStop = true;
            this.linkHist.Text = "Historiques";
            this.linkHist.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHist_LinkClicked);
            // 
            // linkMVT
            // 
            this.linkMVT.AutoSize = true;
            this.linkMVT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkMVT.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkMVT.Location = new System.Drawing.Point(735, 23);
            this.linkMVT.Name = "linkMVT";
            this.linkMVT.Size = new System.Drawing.Size(96, 20);
            this.linkMVT.TabIndex = 35;
            this.linkMVT.TabStop = true;
            this.linkMVT.Text = "Mouvements";
            this.linkMVT.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMVT_LinkClicked);
            // 
            // NotificationStocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1071, 715);
            this.Controls.Add(this.linkDashboard);
            this.Controls.Add(this.linkProd);
            this.Controls.Add(this.linkHist);
            this.Controls.Add(this.linkMVT);
            this.Controls.Add(this.cbLue);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDoneRead);
            this.Controls.Add(this.cbNonLue);
            this.Controls.Add(this.cbTout);
            this.Controls.Add(this.dvgNotification);
            this.Controls.Add(this.label1);
            this.Name = "NotificationStocks";
            this.Text = "NotificationStocks";
            this.Load += new System.EventHandler(this.NotificationStocks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgNotification)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dvgNotification;
        private System.Windows.Forms.DataGridViewTextBoxColumn notification;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateheure;
        private System.Windows.Forms.DataGridViewTextBoxColumn statut;
        private System.Windows.Forms.CheckBox cbTout;
        private System.Windows.Forms.CheckBox cbNonLue;
        private System.Windows.Forms.Button btnDoneRead;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.CheckBox cbLue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.LinkLabel linkDashboard;
        private System.Windows.Forms.LinkLabel linkProd;
        private System.Windows.Forms.LinkLabel linkHist;
        private System.Windows.Forms.LinkLabel linkMVT;
    }
}