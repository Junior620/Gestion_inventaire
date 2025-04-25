namespace Gestion_inventaire.Views
{
    partial class ProduitsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProduitsForm));
            this.produit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomProduit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCategorie = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numQuantite = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numSeuil = new System.Windows.Forms.NumericUpDown();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categories = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seuil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantiteEnStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.searchbox = new System.Windows.Forms.TextBox();
            this.btnExportPdf = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.titreProduit = new System.Windows.Forms.Label();
            this.panelProduitSelectionne = new System.Windows.Forms.Panel();
            this.lblPrixSelected = new System.Windows.Forms.Label();
            this.lblStockSelected = new System.Windows.Forms.Label();
            this.lblCategorieSelected = new System.Windows.Forms.Label();
            this.lblNomSelected = new System.Windows.Forms.Label();
            this.btnSuivant = new System.Windows.Forms.Button();
            this.btnPrecedent = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.numPrix = new System.Windows.Forms.NumericUpDown();
            this.logout = new System.Windows.Forms.PictureBox();
            this.linkMVT = new System.Windows.Forms.LinkLabel();
            this.linkHist = new System.Windows.Forms.LinkLabel();
            this.linkProd = new System.Windows.Forms.LinkLabel();
            this.linkDashboard = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeuil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelProduitSelectionne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logout)).BeginInit();
            this.SuspendLayout();
            // 
            // produit
            // 
            this.produit.AutoSize = true;
            this.produit.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produit.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.produit.Location = new System.Drawing.Point(11, 44);
            this.produit.Name = "produit";
            this.produit.Size = new System.Drawing.Size(105, 31);
            this.produit.TabIndex = 0;
            this.produit.Text = "Produits";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(32, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nom";
            // 
            // txtNomProduit
            // 
            this.txtNomProduit.Location = new System.Drawing.Point(231, 90);
            this.txtNomProduit.Name = "txtNomProduit";
            this.txtNomProduit.Size = new System.Drawing.Size(621, 22);
            this.txtNomProduit.TabIndex = 2;
            this.txtNomProduit.TextChanged += new System.EventHandler(this.txtNomProduit_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(32, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Catégories";
            // 
            // cmbCategorie
            // 
            this.cmbCategorie.FormattingEnabled = true;
            this.cmbCategorie.Location = new System.Drawing.Point(231, 139);
            this.cmbCategorie.Name = "cmbCategorie";
            this.cmbCategorie.Size = new System.Drawing.Size(621, 24);
            this.cmbCategorie.TabIndex = 4;
            this.cmbCategorie.SelectedIndexChanged += new System.EventHandler(this.cmbCategorie_SelectedIndexChanged);
            this.cmbCategorie.Click += new System.EventHandler(this.cmbCategorie_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label3.Location = new System.Drawing.Point(32, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Quantité en Stock";
            // 
            // numQuantite
            // 
            this.numQuantite.Location = new System.Drawing.Point(714, 203);
            this.numQuantite.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numQuantite.Name = "numQuantite";
            this.numQuantite.Size = new System.Drawing.Size(138, 22);
            this.numQuantite.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label4.Location = new System.Drawing.Point(32, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "Seuil d\'alerte";
            // 
            // numSeuil
            // 
            this.numSeuil.Location = new System.Drawing.Point(714, 250);
            this.numSeuil.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSeuil.Name = "numSeuil";
            this.numSeuil.Size = new System.Drawing.Size(138, 22);
            this.numSeuil.TabIndex = 8;
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.Lime;
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.Location = new System.Drawing.Point(1126, 79);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(122, 35);
            this.btnAjouter.TabIndex = 9;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.Yellow;
            this.btnModifier.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.Location = new System.Drawing.Point(1126, 134);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(122, 35);
            this.btnModifier.TabIndex = 10;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.Red;
            this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.Location = new System.Drawing.Point(1126, 190);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(122, 35);
            this.btnSupprimer.TabIndex = 11;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click_1);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Cyan;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(1126, 245);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(122, 35);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Rénitialiser";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label5.Location = new System.Drawing.Point(11, 369);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 31);
            this.label5.TabIndex = 13;
            this.label5.Text = "Produits en Stocks";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.nom,
            this.categories,
            this.seuil,
            this.QuantiteEnStock,
            this.prix});
            this.dataGridView1.Location = new System.Drawing.Point(29, 434);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1155, 357);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // nom
            // 
            this.nom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nom.DataPropertyName = "Nom";
            this.nom.HeaderText = "Nom";
            this.nom.MinimumWidth = 6;
            this.nom.Name = "nom";
            this.nom.ReadOnly = true;
            // 
            // categories
            // 
            this.categories.HeaderText = "Catégories";
            this.categories.MinimumWidth = 6;
            this.categories.Name = "categories";
            this.categories.ReadOnly = true;
            this.categories.Width = 125;
            // 
            // seuil
            // 
            this.seuil.HeaderText = "Seuil d\'alerte";
            this.seuil.MinimumWidth = 6;
            this.seuil.Name = "seuil";
            this.seuil.ReadOnly = true;
            this.seuil.Width = 125;
            // 
            // QuantiteEnStock
            // 
            this.QuantiteEnStock.DataPropertyName = "QuantiteEnStock";
            this.QuantiteEnStock.HeaderText = "Quantite En Stock";
            this.QuantiteEnStock.MinimumWidth = 6;
            this.QuantiteEnStock.Name = "QuantiteEnStock";
            this.QuantiteEnStock.ReadOnly = true;
            this.QuantiteEnStock.Width = 125;
            // 
            // prix
            // 
            this.prix.HeaderText = "Prix Unitaire";
            this.prix.MinimumWidth = 6;
            this.prix.Name = "prix";
            this.prix.ReadOnly = true;
            this.prix.Width = 125;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label6.Location = new System.Drawing.Point(32, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 28);
            this.label6.TabIndex = 16;
            this.label6.Text = "Prix Unitaire";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(839, 395);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // searchbox
            // 
            this.searchbox.Location = new System.Drawing.Point(884, 401);
            this.searchbox.Name = "searchbox";
            this.searchbox.Size = new System.Drawing.Size(240, 22);
            this.searchbox.TabIndex = 18;
            this.searchbox.TextChanged += new System.EventHandler(this.searchbox_TextChanged);
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.BackColor = System.Drawing.Color.MintCream;
            this.btnExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPdf.Location = new System.Drawing.Point(1220, 703);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(174, 35);
            this.btnExportPdf.TabIndex = 21;
            this.btnExportPdf.Text = "Exporter vers PDF";
            this.btnExportPdf.UseVisualStyleBackColor = false;
            this.btnExportPdf.Click += new System.EventHandler(this.btnExportPdf_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.MintCream;
            this.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Location = new System.Drawing.Point(1220, 756);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(174, 35);
            this.btnExportExcel.TabIndex = 22;
            this.btnExportExcel.Text = "Exporter vers Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.LawnGreen;
            this.pictureBox2.Location = new System.Drawing.Point(29, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // titreProduit
            // 
            this.titreProduit.AutoSize = true;
            this.titreProduit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titreProduit.Location = new System.Drawing.Point(50, 14);
            this.titreProduit.Name = "titreProduit";
            this.titreProduit.Size = new System.Drawing.Size(160, 20);
            this.titreProduit.TabIndex = 25;
            this.titreProduit.Text = "Produit Séclectionné :";
            this.titreProduit.Click += new System.EventHandler(this.titreProduit_Click);
            // 
            // panelProduitSelectionne
            // 
            this.panelProduitSelectionne.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelProduitSelectionne.Controls.Add(this.lblPrixSelected);
            this.panelProduitSelectionne.Controls.Add(this.lblStockSelected);
            this.panelProduitSelectionne.Controls.Add(this.lblCategorieSelected);
            this.panelProduitSelectionne.Controls.Add(this.lblNomSelected);
            this.panelProduitSelectionne.Controls.Add(this.titreProduit);
            this.panelProduitSelectionne.Controls.Add(this.pictureBox2);
            this.panelProduitSelectionne.Location = new System.Drawing.Point(1194, 434);
            this.panelProduitSelectionne.Name = "panelProduitSelectionne";
            this.panelProduitSelectionne.Size = new System.Drawing.Size(240, 216);
            this.panelProduitSelectionne.TabIndex = 26;
            this.panelProduitSelectionne.Paint += new System.Windows.Forms.PaintEventHandler(this.panelProduitSelectionne_Paint);
            // 
            // lblPrixSelected
            // 
            this.lblPrixSelected.AutoSize = true;
            this.lblPrixSelected.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrixSelected.Location = new System.Drawing.Point(3, 171);
            this.lblPrixSelected.Name = "lblPrixSelected";
            this.lblPrixSelected.Size = new System.Drawing.Size(44, 20);
            this.lblPrixSelected.TabIndex = 29;
            this.lblPrixSelected.Text = "Prix :";
            // 
            // lblStockSelected
            // 
            this.lblStockSelected.AutoSize = true;
            this.lblStockSelected.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockSelected.Location = new System.Drawing.Point(3, 135);
            this.lblStockSelected.Name = "lblStockSelected";
            this.lblStockSelected.Size = new System.Drawing.Size(55, 20);
            this.lblStockSelected.TabIndex = 28;
            this.lblStockSelected.Text = "Stock :";
            // 
            // lblCategorieSelected
            // 
            this.lblCategorieSelected.AutoSize = true;
            this.lblCategorieSelected.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategorieSelected.Location = new System.Drawing.Point(3, 98);
            this.lblCategorieSelected.Name = "lblCategorieSelected";
            this.lblCategorieSelected.Size = new System.Drawing.Size(84, 20);
            this.lblCategorieSelected.TabIndex = 27;
            this.lblCategorieSelected.Text = "Catégorie :";
            // 
            // lblNomSelected
            // 
            this.lblNomSelected.AutoSize = true;
            this.lblNomSelected.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomSelected.Location = new System.Drawing.Point(3, 59);
            this.lblNomSelected.Name = "lblNomSelected";
            this.lblNomSelected.Size = new System.Drawing.Size(52, 20);
            this.lblNomSelected.TabIndex = 26;
            this.lblNomSelected.Text = "Nom :";
            // 
            // btnSuivant
            // 
            this.btnSuivant.BackColor = System.Drawing.Color.DarkGray;
            this.btnSuivant.Font = new System.Drawing.Font("Segoe UI Semilight", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuivant.Location = new System.Drawing.Point(1109, 797);
            this.btnSuivant.Name = "btnSuivant";
            this.btnSuivant.Size = new System.Drawing.Size(75, 23);
            this.btnSuivant.TabIndex = 1;
            this.btnSuivant.Text = "Suivant";
            this.btnSuivant.UseVisualStyleBackColor = false;
            this.btnSuivant.Click += new System.EventHandler(this.btnSuivant_Click);
            // 
            // btnPrecedent
            // 
            this.btnPrecedent.BackColor = System.Drawing.Color.DarkGray;
            this.btnPrecedent.Font = new System.Drawing.Font("Segoe UI Semilight", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrecedent.Location = new System.Drawing.Point(1007, 797);
            this.btnPrecedent.Name = "btnPrecedent";
            this.btnPrecedent.Size = new System.Drawing.Size(96, 23);
            this.btnPrecedent.TabIndex = 0;
            this.btnPrecedent.Text = "Précédent";
            this.btnPrecedent.UseVisualStyleBackColor = false;
            this.btnPrecedent.Click += new System.EventHandler(this.btnPrecedent_Click);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(600, 804);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(81, 16);
            this.lblPageInfo.TabIndex = 28;
            this.lblPageInfo.Text = "Page 1 sur 3";
            // 
            // numPrix
            // 
            this.numPrix.Location = new System.Drawing.Point(714, 295);
            this.numPrix.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPrix.Name = "numPrix";
            this.numPrix.Size = new System.Drawing.Size(138, 22);
            this.numPrix.TabIndex = 29;
            // 
            // logout
            // 
            this.logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logout.Image = ((System.Drawing.Image)(resources.GetObject("logout.Image")));
            this.logout.Location = new System.Drawing.Point(1379, 12);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(41, 41);
            this.logout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logout.TabIndex = 30;
            this.logout.TabStop = false;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // linkMVT
            // 
            this.linkMVT.AutoSize = true;
            this.linkMVT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkMVT.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkMVT.Location = new System.Drawing.Point(1021, 24);
            this.linkMVT.Name = "linkMVT";
            this.linkMVT.Size = new System.Drawing.Size(96, 20);
            this.linkMVT.TabIndex = 31;
            this.linkMVT.TabStop = true;
            this.linkMVT.Text = "Mouvements";
            this.linkMVT.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMVT_LinkClicked);
            // 
            // linkHist
            // 
            this.linkHist.AutoSize = true;
            this.linkHist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkHist.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkHist.Location = new System.Drawing.Point(1136, 24);
            this.linkHist.Name = "linkHist";
            this.linkHist.Size = new System.Drawing.Size(85, 20);
            this.linkHist.TabIndex = 32;
            this.linkHist.TabStop = true;
            this.linkHist.Text = "Historiques";
            this.linkHist.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHist_LinkClicked);
            // 
            // linkProd
            // 
            this.linkProd.AutoSize = true;
            this.linkProd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkProd.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkProd.Location = new System.Drawing.Point(1246, 24);
            this.linkProd.Name = "linkProd";
            this.linkProd.Size = new System.Drawing.Size(65, 20);
            this.linkProd.TabIndex = 33;
            this.linkProd.TabStop = true;
            this.linkProd.Text = "Produits";
            this.linkProd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkProd_LinkClicked);
            // 
            // linkDashboard
            // 
            this.linkDashboard.AutoSize = true;
            this.linkDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkDashboard.Location = new System.Drawing.Point(899, 24);
            this.linkDashboard.Name = "linkDashboard";
            this.linkDashboard.Size = new System.Drawing.Size(85, 20);
            this.linkDashboard.TabIndex = 34;
            this.linkDashboard.TabStop = true;
            this.linkDashboard.Text = "Dashboard";
            this.linkDashboard.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDashboard_LinkClicked);
            // 
            // ProduitsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1460, 854);
            this.Controls.Add(this.linkDashboard);
            this.Controls.Add(this.linkProd);
            this.Controls.Add(this.linkHist);
            this.Controls.Add(this.linkMVT);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.numPrix);
            this.Controls.Add(this.btnSuivant);
            this.Controls.Add(this.btnPrecedent);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.panelProduitSelectionne);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnExportPdf);
            this.Controls.Add(this.searchbox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.numSeuil);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numQuantite);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCategorie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNomProduit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.produit);
            this.Name = "ProduitsForm";
            this.Text = "ProduitsForm";
            this.Load += new System.EventHandler(this.ProduitsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeuil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelProduitSelectionne.ResumeLayout(false);
            this.panelProduitSelectionne.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label produit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomProduit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCategorie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numQuantite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numSeuil;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox searchbox;
        private System.Windows.Forms.Button btnExportPdf;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label titreProduit;
        private System.Windows.Forms.Panel panelProduitSelectionne;
        private System.Windows.Forms.Label lblNomSelected;
        private System.Windows.Forms.Label lblPrixSelected;
        private System.Windows.Forms.Label lblStockSelected;
        private System.Windows.Forms.Label lblCategorieSelected;
        private System.Windows.Forms.Button btnSuivant;
        private System.Windows.Forms.Button btnPrecedent;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.NumericUpDown numPrix;
        private System.Windows.Forms.PictureBox logout;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn categories;
        private System.Windows.Forms.DataGridViewTextBoxColumn seuil;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantiteEnStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn prix;
        private System.Windows.Forms.LinkLabel linkMVT;
        private System.Windows.Forms.LinkLabel linkHist;
        private System.Windows.Forms.LinkLabel linkProd;
        private System.Windows.Forms.LinkLabel linkDashboard;
    }
}