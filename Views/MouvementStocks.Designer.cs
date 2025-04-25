namespace Gestion_inventaire.Views
{
    partial class MouvementStocks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MouvementStocks));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmtProduit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.npdQunatite = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxRemarque = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbProduitSelect = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radioTous = new System.Windows.Forms.RadioButton();
            this.radioEntrée = new System.Windows.Forms.RadioButton();
            this.radioSortie = new System.Windows.Forms.RadioButton();
            this.btnValiderMove = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.typedemouvement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qauntité = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.logout = new System.Windows.Forms.PictureBox();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnSuivant = new System.Windows.Forms.Button();
            this.btnPrecedent = new System.Windows.Forms.Button();
            this.linkDashboard = new System.Windows.Forms.LinkLabel();
            this.linkProd = new System.Windows.Forms.LinkLabel();
            this.linkHist = new System.Windows.Forms.LinkLabel();
            this.linkMVT = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.npdQunatite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logout)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mouvement de Stock";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmbType
            // 
            this.cmbType.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(267, 75);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(522, 31);
            this.cmbType.TabIndex = 3;
            // 
            // cmtProduit
            // 
            this.cmtProduit.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmtProduit.FormattingEnabled = true;
            this.cmtProduit.Location = new System.Drawing.Point(267, 121);
            this.cmtProduit.Name = "cmtProduit";
            this.cmtProduit.Size = new System.Drawing.Size(522, 31);
            this.cmtProduit.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Produit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Quantité";
            // 
            // npdQunatite
            // 
            this.npdQunatite.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.npdQunatite.Location = new System.Drawing.Point(498, 173);
            this.npdQunatite.Name = "npdQunatite";
            this.npdQunatite.Size = new System.Drawing.Size(120, 27);
            this.npdQunatite.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 28);
            this.label5.TabIndex = 8;
            this.label5.Text = "Remarque";
            // 
            // txtBoxRemarque
            // 
            this.txtBoxRemarque.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxRemarque.Location = new System.Drawing.Point(267, 221);
            this.txtBoxRemarque.Name = "txtBoxRemarque";
            this.txtBoxRemarque.Size = new System.Drawing.Size(522, 30);
            this.txtBoxRemarque.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 28);
            this.label6.TabIndex = 10;
            this.label6.Text = "Produit";
            // 
            // cmbProduitSelect
            // 
            this.cmbProduitSelect.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProduitSelect.FormattingEnabled = true;
            this.cmbProduitSelect.Location = new System.Drawing.Point(267, 295);
            this.cmbProduitSelect.Name = "cmbProduitSelect";
            this.cmbProduitSelect.Size = new System.Drawing.Size(180, 31);
            this.cmbProduitSelect.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(504, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 28);
            this.label7.TabIndex = 12;
            this.label7.Text = "Type";
            // 
            // radioTous
            // 
            this.radioTous.AutoSize = true;
            this.radioTous.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioTous.Location = new System.Drawing.Point(572, 297);
            this.radioTous.Name = "radioTous";
            this.radioTous.Size = new System.Drawing.Size(56, 21);
            this.radioTous.TabIndex = 14;
            this.radioTous.TabStop = true;
            this.radioTous.Text = "Tous";
            this.radioTous.UseVisualStyleBackColor = true;
            // 
            // radioEntrée
            // 
            this.radioEntrée.AutoSize = true;
            this.radioEntrée.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioEntrée.Location = new System.Drawing.Point(634, 297);
            this.radioEntrée.Name = "radioEntrée";
            this.radioEntrée.Size = new System.Drawing.Size(66, 21);
            this.radioEntrée.TabIndex = 15;
            this.radioEntrée.TabStop = true;
            this.radioEntrée.Text = "Entrée";
            this.radioEntrée.UseVisualStyleBackColor = true;
            // 
            // radioSortie
            // 
            this.radioSortie.AutoSize = true;
            this.radioSortie.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSortie.Location = new System.Drawing.Point(706, 297);
            this.radioSortie.Name = "radioSortie";
            this.radioSortie.Size = new System.Drawing.Size(63, 21);
            this.radioSortie.TabIndex = 16;
            this.radioSortie.TabStop = true;
            this.radioSortie.Text = "Sortie";
            this.radioSortie.UseVisualStyleBackColor = true;
            // 
            // btnValiderMove
            // 
            this.btnValiderMove.BackColor = System.Drawing.Color.LimeGreen;
            this.btnValiderMove.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValiderMove.Location = new System.Drawing.Point(656, 165);
            this.btnValiderMove.Name = "btnValiderMove";
            this.btnValiderMove.Size = new System.Drawing.Size(133, 35);
            this.btnValiderMove.TabIndex = 17;
            this.btnValiderMove.Text = "Valider";
            this.btnValiderMove.UseVisualStyleBackColor = false;
            this.btnValiderMove.Click += new System.EventHandler(this.btnValiderMove_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(32, 354);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(277, 28);
            this.label8.TabIndex = 18;
            this.label8.Text = "Historique des mouvements";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typedemouvement,
            this.produit,
            this.qauntité,
            this.date,
            this.remarque});
            this.dataGridView1.Location = new System.Drawing.Point(35, 400);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(799, 350);
            this.dataGridView1.TabIndex = 19;
            // 
            // typedemouvement
            // 
            this.typedemouvement.HeaderText = "Type de Mouvement";
            this.typedemouvement.MinimumWidth = 6;
            this.typedemouvement.Name = "typedemouvement";
            this.typedemouvement.ReadOnly = true;
            this.typedemouvement.Width = 125;
            // 
            // produit
            // 
            this.produit.HeaderText = "Produit";
            this.produit.MinimumWidth = 6;
            this.produit.Name = "produit";
            this.produit.ReadOnly = true;
            this.produit.Width = 125;
            // 
            // qauntité
            // 
            this.qauntité.HeaderText = "Quantité";
            this.qauntité.MinimumWidth = 6;
            this.qauntité.Name = "qauntité";
            this.qauntité.ReadOnly = true;
            this.qauntité.Width = 125;
            // 
            // date
            // 
            this.date.HeaderText = "Date/Heure";
            this.date.MinimumWidth = 6;
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 125;
            // 
            // remarque
            // 
            this.remarque.HeaderText = "Remarque";
            this.remarque.MinimumWidth = 6;
            this.remarque.Name = "remarque";
            this.remarque.ReadOnly = true;
            this.remarque.Width = 125;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.btnExcel);
            this.panel9.Controls.Add(this.pictureBox5);
            this.panel9.Location = new System.Drawing.Point(885, 628);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(158, 58);
            this.panel9.TabIndex = 21;
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Location = new System.Drawing.Point(66, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 48);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Text = "Export Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(18, 12);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(31, 29);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 1;
            this.pictureBox5.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Linen;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.btnExportPDF);
            this.panel8.Controls.Add(this.pictureBox4);
            this.panel8.Location = new System.Drawing.Point(885, 692);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(158, 58);
            this.panel8.TabIndex = 20;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPDF.Location = new System.Drawing.Point(66, 3);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(75, 48);
            this.btnExportPDF.TabIndex = 2;
            this.btnExportPDF.Text = "Export PDF";
            this.btnExportPDF.UseVisualStyleBackColor = true;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(18, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 29);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // logout
            // 
            this.logout.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.logout.Image = ((System.Drawing.Image)(resources.GetObject("logout.Image")));
            this.logout.Location = new System.Drawing.Point(1002, 13);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(41, 41);
            this.logout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logout.TabIndex = 31;
            this.logout.TabStop = false;
            this.logout.UseWaitCursor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(366, 753);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(81, 16);
            this.lblPageInfo.TabIndex = 32;
            this.lblPageInfo.Text = "Page 1 sur 3";
            // 
            // btnSuivant
            // 
            this.btnSuivant.BackColor = System.Drawing.Color.DarkGray;
            this.btnSuivant.Font = new System.Drawing.Font("Segoe UI Semilight", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuivant.Location = new System.Drawing.Point(759, 756);
            this.btnSuivant.Name = "btnSuivant";
            this.btnSuivant.Size = new System.Drawing.Size(75, 23);
            this.btnSuivant.TabIndex = 34;
            this.btnSuivant.Text = "Suivant";
            this.btnSuivant.UseVisualStyleBackColor = false;
            this.btnSuivant.Click += new System.EventHandler(this.btnSuivant_Click);
            // 
            // btnPrecedent
            // 
            this.btnPrecedent.BackColor = System.Drawing.Color.DarkGray;
            this.btnPrecedent.Font = new System.Drawing.Font("Segoe UI Semilight", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrecedent.Location = new System.Drawing.Point(657, 756);
            this.btnPrecedent.Name = "btnPrecedent";
            this.btnPrecedent.Size = new System.Drawing.Size(96, 23);
            this.btnPrecedent.TabIndex = 33;
            this.btnPrecedent.Text = "Précédent";
            this.btnPrecedent.UseVisualStyleBackColor = false;
            this.btnPrecedent.Click += new System.EventHandler(this.btnPrecedent_Click);
            // 
            // linkDashboard
            // 
            this.linkDashboard.AutoSize = true;
            this.linkDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkDashboard.Location = new System.Drawing.Point(578, 24);
            this.linkDashboard.Name = "linkDashboard";
            this.linkDashboard.Size = new System.Drawing.Size(85, 20);
            this.linkDashboard.TabIndex = 42;
            this.linkDashboard.TabStop = true;
            this.linkDashboard.Text = "Dashboard";
            this.linkDashboard.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDashboard_LinkClicked);
            // 
            // linkProd
            // 
            this.linkProd.AutoSize = true;
            this.linkProd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkProd.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkProd.Location = new System.Drawing.Point(907, 24);
            this.linkProd.Name = "linkProd";
            this.linkProd.Size = new System.Drawing.Size(65, 20);
            this.linkProd.TabIndex = 41;
            this.linkProd.TabStop = true;
            this.linkProd.Text = "Produits";
            this.linkProd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkProd_LinkClicked);
            // 
            // linkHist
            // 
            this.linkHist.AutoSize = true;
            this.linkHist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkHist.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkHist.Location = new System.Drawing.Point(797, 24);
            this.linkHist.Name = "linkHist";
            this.linkHist.Size = new System.Drawing.Size(85, 20);
            this.linkHist.TabIndex = 40;
            this.linkHist.TabStop = true;
            this.linkHist.Text = "Historiques";
            this.linkHist.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHist_LinkClicked);
            // 
            // linkMVT
            // 
            this.linkMVT.AutoSize = true;
            this.linkMVT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkMVT.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkMVT.Location = new System.Drawing.Point(682, 24);
            this.linkMVT.Name = "linkMVT";
            this.linkMVT.Size = new System.Drawing.Size(96, 20);
            this.linkMVT.TabIndex = 39;
            this.linkMVT.TabStop = true;
            this.linkMVT.Text = "Mouvements";
            this.linkMVT.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMVT_LinkClicked);
            // 
            // MouvementStocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1080, 845);
            this.Controls.Add(this.linkDashboard);
            this.Controls.Add(this.linkProd);
            this.Controls.Add(this.linkHist);
            this.Controls.Add(this.linkMVT);
            this.Controls.Add(this.btnSuivant);
            this.Controls.Add(this.btnPrecedent);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnValiderMove);
            this.Controls.Add(this.radioSortie);
            this.Controls.Add(this.radioEntrée);
            this.Controls.Add(this.radioTous);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbProduitSelect);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBoxRemarque);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.npdQunatite);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmtProduit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MouvementStocks";
            this.Text = "s";
            this.Load += new System.EventHandler(this.MouvementStocks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.npdQunatite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cmtProduit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown npdQunatite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxRemarque;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbProduitSelect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioTous;
        private System.Windows.Forms.RadioButton radioEntrée;
        private System.Windows.Forms.RadioButton radioSortie;
        private System.Windows.Forms.Button btnValiderMove;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox logout;
        private System.Windows.Forms.DataGridViewTextBoxColumn typedemouvement;
        private System.Windows.Forms.DataGridViewTextBoxColumn produit;
        private System.Windows.Forms.DataGridViewTextBoxColumn qauntité;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarque;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnSuivant;
        private System.Windows.Forms.Button btnPrecedent;
        private System.Windows.Forms.LinkLabel linkDashboard;
        private System.Windows.Forms.LinkLabel linkProd;
        private System.Windows.Forms.LinkLabel linkHist;
        private System.Windows.Forms.LinkLabel linkMVT;
    }
}