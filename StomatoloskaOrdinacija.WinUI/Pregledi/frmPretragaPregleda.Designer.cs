namespace StomatoloskaOrdinacija.WinUI.Pregledi
{
    partial class frmPretragaPregleda
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
            this.btnDodajNovog = new System.Windows.Forms.Button();
            this.btnDetalji = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNapomena = new System.Windows.Forms.TextBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvKorisnici = new System.Windows.Forms.DataGridView();
            this.PregledId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoktorIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TerminImePacijenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TerminRazlog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DijagnozaTekst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LijekTekst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Materijal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KolicinaOdabranogMaterijala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbTermin = new System.Windows.Forms.ComboBox();
            this.cmbMaterijal = new System.Windows.Forms.ComboBox();
            this.cmbKorisnik = new System.Windows.Forms.ComboBox();
            this.btnSviPregleda = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDodajNovog
            // 
            this.btnDodajNovog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDodajNovog.Location = new System.Drawing.Point(788, 128);
            this.btnDodajNovog.Name = "btnDodajNovog";
            this.btnDodajNovog.Size = new System.Drawing.Size(148, 23);
            this.btnDodajNovog.TabIndex = 32;
            this.btnDodajNovog.Text = "Dodaj novi pregled";
            this.btnDodajNovog.UseVisualStyleBackColor = true;
            this.btnDodajNovog.Click += new System.EventHandler(this.btnDodajNovog_Click);
            // 
            // btnDetalji
            // 
            this.btnDetalji.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetalji.Location = new System.Drawing.Point(788, 94);
            this.btnDetalji.Name = "btnDetalji";
            this.btnDetalji.Size = new System.Drawing.Size(148, 23);
            this.btnDetalji.TabIndex = 31;
            this.btnDetalji.Text = "Detalji pregleda";
            this.btnDetalji.UseVisualStyleBackColor = true;
            this.btnDetalji.Click += new System.EventHandler(this.btnDetalji_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Napomena";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Termin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Materijal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Doktor";
            // 
            // txtNapomena
            // 
            this.txtNapomena.Location = new System.Drawing.Point(25, 128);
            this.txtNapomena.Name = "txtNapomena";
            this.txtNapomena.Size = new System.Drawing.Size(703, 20);
            this.txtNapomena.TabIndex = 23;
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrikazi.Location = new System.Drawing.Point(788, 59);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(148, 23);
            this.btnPrikazi.TabIndex = 18;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvKorisnici);
            this.groupBox1.Location = new System.Drawing.Point(22, 162);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 403);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Korisnici";
            // 
            // dgvKorisnici
            // 
            this.dgvKorisnici.AllowUserToAddRows = false;
            this.dgvKorisnici.AllowUserToDeleteRows = false;
            this.dgvKorisnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKorisnici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PregledId,
            this.DoktorIme,
            this.TerminImePacijenta,
            this.TerminRazlog,
            this.DijagnozaTekst,
            this.LijekTekst,
            this.Materijal,
            this.KolicinaOdabranogMaterijala});
            this.dgvKorisnici.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKorisnici.Location = new System.Drawing.Point(3, 16);
            this.dgvKorisnici.Name = "dgvKorisnici";
            this.dgvKorisnici.ReadOnly = true;
            this.dgvKorisnici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKorisnici.Size = new System.Drawing.Size(844, 384);
            this.dgvKorisnici.TabIndex = 0;
            this.dgvKorisnici.DoubleClick += new System.EventHandler(this.dgvKorisnici_DoubleClick);
            // 
            // PregledId
            // 
            this.PregledId.DataPropertyName = "PregledId";
            this.PregledId.HeaderText = "PregledId";
            this.PregledId.Name = "PregledId";
            this.PregledId.ReadOnly = true;
            this.PregledId.Visible = false;
            // 
            // DoktorIme
            // 
            this.DoktorIme.DataPropertyName = "DoktorIme";
            this.DoktorIme.HeaderText = "DoktorIme";
            this.DoktorIme.Name = "DoktorIme";
            this.DoktorIme.ReadOnly = true;
            // 
            // TerminImePacijenta
            // 
            this.TerminImePacijenta.DataPropertyName = "TerminImePacijenta";
            this.TerminImePacijenta.HeaderText = "TerminImePacijenta";
            this.TerminImePacijenta.Name = "TerminImePacijenta";
            this.TerminImePacijenta.ReadOnly = true;
            this.TerminImePacijenta.Width = 150;
            // 
            // TerminRazlog
            // 
            this.TerminRazlog.DataPropertyName = "TerminRazlog";
            this.TerminRazlog.HeaderText = "TerminRazlog";
            this.TerminRazlog.Name = "TerminRazlog";
            this.TerminRazlog.ReadOnly = true;
            // 
            // DijagnozaTekst
            // 
            this.DijagnozaTekst.DataPropertyName = "DijagnozaTekst";
            this.DijagnozaTekst.HeaderText = "DijagnozaTekst";
            this.DijagnozaTekst.Name = "DijagnozaTekst";
            this.DijagnozaTekst.ReadOnly = true;
            this.DijagnozaTekst.Width = 150;
            // 
            // LijekTekst
            // 
            this.LijekTekst.DataPropertyName = "LijekTekst";
            this.LijekTekst.HeaderText = "LijekTekst";
            this.LijekTekst.Name = "LijekTekst";
            this.LijekTekst.ReadOnly = true;
            // 
            // Materijal
            // 
            this.Materijal.DataPropertyName = "Materijal";
            this.Materijal.HeaderText = "Materijal";
            this.Materijal.Name = "Materijal";
            this.Materijal.ReadOnly = true;
            // 
            // KolicinaOdabranogMaterijala
            // 
            this.KolicinaOdabranogMaterijala.DataPropertyName = "KolicinaOdabranogMaterijala";
            this.KolicinaOdabranogMaterijala.HeaderText = "KolicinaOdabranogMaterijala";
            this.KolicinaOdabranogMaterijala.Name = "KolicinaOdabranogMaterijala";
            this.KolicinaOdabranogMaterijala.ReadOnly = true;
            // 
            // cmbTermin
            // 
            this.cmbTermin.FormattingEnabled = true;
            this.cmbTermin.Location = new System.Drawing.Point(25, 32);
            this.cmbTermin.Name = "cmbTermin";
            this.cmbTermin.Size = new System.Drawing.Size(703, 21);
            this.cmbTermin.TabIndex = 35;
            // 
            // cmbMaterijal
            // 
            this.cmbMaterijal.FormattingEnabled = true;
            this.cmbMaterijal.Location = new System.Drawing.Point(372, 79);
            this.cmbMaterijal.Name = "cmbMaterijal";
            this.cmbMaterijal.Size = new System.Drawing.Size(356, 21);
            this.cmbMaterijal.TabIndex = 36;
            // 
            // cmbKorisnik
            // 
            this.cmbKorisnik.FormattingEnabled = true;
            this.cmbKorisnik.Location = new System.Drawing.Point(25, 79);
            this.cmbKorisnik.Name = "cmbKorisnik";
            this.cmbKorisnik.Size = new System.Drawing.Size(323, 21);
            this.cmbKorisnik.TabIndex = 37;
            // 
            // btnSviPregleda
            // 
            this.btnSviPregleda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSviPregleda.Location = new System.Drawing.Point(788, 19);
            this.btnSviPregleda.Name = "btnSviPregleda";
            this.btnSviPregleda.Size = new System.Drawing.Size(148, 34);
            this.btnSviPregleda.TabIndex = 38;
            this.btnSviPregleda.Text = "Svi pregledi";
            this.btnSviPregleda.UseVisualStyleBackColor = true;
            this.btnSviPregleda.Click += new System.EventHandler(this.btnSviPregleda_Click);
            // 
            // frmPretragaPregleda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 593);
            this.Controls.Add(this.btnSviPregleda);
            this.Controls.Add(this.cmbKorisnik);
            this.Controls.Add(this.cmbMaterijal);
            this.Controls.Add(this.cmbTermin);
            this.Controls.Add(this.btnDodajNovog);
            this.Controls.Add(this.btnDetalji);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNapomena);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPretragaPregleda";
            this.Text = "frmPretragaPregleda";
            this.Load += new System.EventHandler(this.frmPretragaPregleda_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDodajNovog;
        private System.Windows.Forms.Button btnDetalji;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNapomena;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvKorisnici;
        private System.Windows.Forms.ComboBox cmbTermin;
        private System.Windows.Forms.ComboBox cmbMaterijal;
        private System.Windows.Forms.ComboBox cmbKorisnik;
        private System.Windows.Forms.Button btnSviPregleda;
        private System.Windows.Forms.DataGridViewTextBoxColumn PregledId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoktorIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminImePacijenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminRazlog;
        private System.Windows.Forms.DataGridViewTextBoxColumn DijagnozaTekst;
        private System.Windows.Forms.DataGridViewTextBoxColumn LijekTekst;
        private System.Windows.Forms.DataGridViewTextBoxColumn Materijal;
        private System.Windows.Forms.DataGridViewTextBoxColumn KolicinaOdabranogMaterijala;
    }
}