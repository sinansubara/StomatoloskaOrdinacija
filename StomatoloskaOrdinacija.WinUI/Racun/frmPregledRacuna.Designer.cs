namespace StomatoloskaOrdinacija.WinUI.Racun
{
    partial class frmPregledRacuna
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
            this.btnNaplati = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvRacuni = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.btnPretraga = new System.Windows.Forms.Button();
            this.cbNeuplaceni = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RacunId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RacunDoktorIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PregledPacijentIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PregledUslugaNaziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PregledMaterijalNaziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PregledMaterijalKolicina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumIzdavanjaRacuna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UkupnaCijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPlatio = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacuni)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNaplati
            // 
            this.btnNaplati.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnNaplati.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNaplati.Location = new System.Drawing.Point(968, 17);
            this.btnNaplati.Name = "btnNaplati";
            this.btnNaplati.Size = new System.Drawing.Size(158, 38);
            this.btnNaplati.TabIndex = 25;
            this.btnNaplati.Text = "Naplati i printaj racun";
            this.btnNaplati.UseVisualStyleBackColor = false;
            this.btnNaplati.Click += new System.EventHandler(this.btnNaplati_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvRacuni);
            this.groupBox1.Location = new System.Drawing.Point(27, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1102, 475);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Racuni";
            // 
            // dgvRacuni
            // 
            this.dgvRacuni.AllowUserToAddRows = false;
            this.dgvRacuni.AllowUserToDeleteRows = false;
            this.dgvRacuni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRacuni.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RacunId,
            this.RacunDoktorIme,
            this.PregledPacijentIme,
            this.PregledUslugaNaziv,
            this.PregledMaterijalNaziv,
            this.PregledMaterijalKolicina,
            this.DatumIzdavanjaRacuna,
            this.UkupnaCijena,
            this.IsPlatio});
            this.dgvRacuni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRacuni.Location = new System.Drawing.Point(3, 16);
            this.dgvRacuni.Name = "dgvRacuni";
            this.dgvRacuni.ReadOnly = true;
            this.dgvRacuni.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRacuni.Size = new System.Drawing.Size(1096, 456);
            this.dgvRacuni.TabIndex = 0;
            this.dgvRacuni.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRacuni_CellContentClick);
            this.dgvRacuni.DoubleClick += new System.EventHandler(this.dgvRacuni_DoubleClick);
            this.dgvRacuni.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvRacuni_MouseDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Ime";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Prezime";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(57, 27);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(190, 20);
            this.txtIme.TabIndex = 38;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(337, 27);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(190, 20);
            this.txtPrezime.TabIndex = 39;
            // 
            // btnPretraga
            // 
            this.btnPretraga.Location = new System.Drawing.Point(726, 25);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(127, 23);
            this.btnPretraga.TabIndex = 40;
            this.btnPretraga.Text = "Pretrazi racune";
            this.btnPretraga.UseVisualStyleBackColor = true;
            this.btnPretraga.Click += new System.EventHandler(this.btnPretraga_Click);
            // 
            // cbNeuplaceni
            // 
            this.cbNeuplaceni.AutoSize = true;
            this.cbNeuplaceni.Location = new System.Drawing.Point(575, 29);
            this.cbNeuplaceni.Name = "cbNeuplaceni";
            this.cbNeuplaceni.Size = new System.Drawing.Size(112, 17);
            this.cbNeuplaceni.TabIndex = 41;
            this.cbNeuplaceni.Text = "Neuplaceni racuni";
            this.cbNeuplaceni.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Pretraga racuna prema osobnim podacima pacijenta";
            // 
            // RacunId
            // 
            this.RacunId.DataPropertyName = "RacunId";
            this.RacunId.HeaderText = "RacunId";
            this.RacunId.Name = "RacunId";
            this.RacunId.ReadOnly = true;
            this.RacunId.Visible = false;
            // 
            // RacunDoktorIme
            // 
            this.RacunDoktorIme.DataPropertyName = "RacunDoktorIme";
            this.RacunDoktorIme.HeaderText = "Doktor";
            this.RacunDoktorIme.Name = "RacunDoktorIme";
            this.RacunDoktorIme.ReadOnly = true;
            this.RacunDoktorIme.Width = 150;
            // 
            // PregledPacijentIme
            // 
            this.PregledPacijentIme.DataPropertyName = "PregledPacijentIme";
            this.PregledPacijentIme.HeaderText = "Pacijent";
            this.PregledPacijentIme.Name = "PregledPacijentIme";
            this.PregledPacijentIme.ReadOnly = true;
            this.PregledPacijentIme.Width = 150;
            // 
            // PregledUslugaNaziv
            // 
            this.PregledUslugaNaziv.DataPropertyName = "PregledUslugaNaziv";
            this.PregledUslugaNaziv.HeaderText = "Izvrsena usluga";
            this.PregledUslugaNaziv.Name = "PregledUslugaNaziv";
            this.PregledUslugaNaziv.ReadOnly = true;
            this.PregledUslugaNaziv.Width = 150;
            // 
            // PregledMaterijalNaziv
            // 
            this.PregledMaterijalNaziv.DataPropertyName = "PregledMaterijalNaziv";
            this.PregledMaterijalNaziv.HeaderText = "Materijal koristen";
            this.PregledMaterijalNaziv.Name = "PregledMaterijalNaziv";
            this.PregledMaterijalNaziv.ReadOnly = true;
            this.PregledMaterijalNaziv.Width = 120;
            // 
            // PregledMaterijalKolicina
            // 
            this.PregledMaterijalKolicina.DataPropertyName = "PregledMaterijalKolicina";
            this.PregledMaterijalKolicina.HeaderText = "Kolicina materijala";
            this.PregledMaterijalKolicina.Name = "PregledMaterijalKolicina";
            this.PregledMaterijalKolicina.ReadOnly = true;
            this.PregledMaterijalKolicina.Width = 120;
            // 
            // DatumIzdavanjaRacuna
            // 
            this.DatumIzdavanjaRacuna.DataPropertyName = "DatumIzdavanjaRacuna";
            this.DatumIzdavanjaRacuna.HeaderText = "Datum izdavanja racuna";
            this.DatumIzdavanjaRacuna.Name = "DatumIzdavanjaRacuna";
            this.DatumIzdavanjaRacuna.ReadOnly = true;
            this.DatumIzdavanjaRacuna.Width = 150;
            // 
            // UkupnaCijena
            // 
            this.UkupnaCijena.DataPropertyName = "UkupnaCijena";
            this.UkupnaCijena.HeaderText = "Ukupna cijena";
            this.UkupnaCijena.Name = "UkupnaCijena";
            this.UkupnaCijena.ReadOnly = true;
            this.UkupnaCijena.Width = 110;
            // 
            // IsPlatio
            // 
            this.IsPlatio.DataPropertyName = "IsPlatio";
            this.IsPlatio.HeaderText = "Placeno";
            this.IsPlatio.Name = "IsPlatio";
            this.IsPlatio.ReadOnly = true;
            // 
            // frmPregledRacuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 576);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbNeuplaceni);
            this.Controls.Add(this.btnPretraga);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnNaplati);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPregledRacuna";
            this.Text = "frmPregledRacuna";
            this.Load += new System.EventHandler(this.frmPregledRacuna_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacuni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNaplati;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvRacuni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Button btnPretraga;
        private System.Windows.Forms.CheckBox cbNeuplaceni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn RacunId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RacunDoktorIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn PregledPacijentIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn PregledUslugaNaziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn PregledMaterijalNaziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn PregledMaterijalKolicina;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumIzdavanjaRacuna;
        private System.Windows.Forms.DataGridViewTextBoxColumn UkupnaCijena;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsPlatio;
    }
}