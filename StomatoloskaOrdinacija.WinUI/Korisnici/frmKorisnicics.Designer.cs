namespace StomatoloskaOrdinacija.WinUI.Korisnici
{
    partial class frmKorisnicics
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvKorisnici = new System.Windows.Forms.DataGridView();
            this.KorisnikId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobitel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JMBG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumRodjenja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.txtPretragaIme = new System.Windows.Forms.TextBox();
            this.txtPretragaPrezime = new System.Windows.Forms.TextBox();
            this.txtPretragaEmail = new System.Windows.Forms.TextBox();
            this.txtPretragaJMBG = new System.Windows.Forms.TextBox();
            this.txtPretragaGrad = new System.Windows.Forms.TextBox();
            this.txtPretragaDrzava = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDetalji = new System.Windows.Forms.Button();
            this.btnDodajNovog = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvKorisnici);
            this.groupBox1.Location = new System.Drawing.Point(12, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(949, 403);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Korisnici";
            // 
            // dgvKorisnici
            // 
            this.dgvKorisnici.AllowUserToAddRows = false;
            this.dgvKorisnici.AllowUserToDeleteRows = false;
            this.dgvKorisnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKorisnici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KorisnikId,
            this.Ime,
            this.Prezime,
            this.Email,
            this.Mobitel,
            this.JMBG,
            this.DatumRodjenja,
            this.Adresa,
            this.Spol,
            this.Status});
            this.dgvKorisnici.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKorisnici.Location = new System.Drawing.Point(3, 16);
            this.dgvKorisnici.Name = "dgvKorisnici";
            this.dgvKorisnici.ReadOnly = true;
            this.dgvKorisnici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKorisnici.Size = new System.Drawing.Size(943, 384);
            this.dgvKorisnici.TabIndex = 0;
            this.dgvKorisnici.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKorisnici_CellContentClick);
            this.dgvKorisnici.DoubleClick += new System.EventHandler(this.dgvKorisnici_DoubleClick);
            // 
            // KorisnikId
            // 
            this.KorisnikId.DataPropertyName = "KorisnikId";
            this.KorisnikId.HeaderText = "KorisnikId";
            this.KorisnikId.Name = "KorisnikId";
            this.KorisnikId.ReadOnly = true;
            this.KorisnikId.Visible = false;
            // 
            // Ime
            // 
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // Prezime
            // 
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.Name = "Prezime";
            this.Prezime.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Mobitel
            // 
            this.Mobitel.DataPropertyName = "Mobitel";
            this.Mobitel.HeaderText = "Mobitel";
            this.Mobitel.Name = "Mobitel";
            this.Mobitel.ReadOnly = true;
            // 
            // JMBG
            // 
            this.JMBG.DataPropertyName = "JMBG";
            this.JMBG.HeaderText = "JMBG";
            this.JMBG.Name = "JMBG";
            this.JMBG.ReadOnly = true;
            // 
            // DatumRodjenja
            // 
            this.DatumRodjenja.DataPropertyName = "DatumRodjenja";
            this.DatumRodjenja.HeaderText = "DatumRodjenja";
            this.DatumRodjenja.Name = "DatumRodjenja";
            this.DatumRodjenja.ReadOnly = true;
            // 
            // Adresa
            // 
            this.Adresa.DataPropertyName = "Adresa";
            this.Adresa.HeaderText = "Adresa";
            this.Adresa.Name = "Adresa";
            this.Adresa.ReadOnly = true;
            // 
            // Spol
            // 
            this.Spol.DataPropertyName = "Spol";
            this.Spol.HeaderText = "Spol";
            this.Spol.Name = "Spol";
            this.Spol.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrikazi.Location = new System.Drawing.Point(778, 29);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(148, 23);
            this.btnPrikazi.TabIndex = 1;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // txtPretragaIme
            // 
            this.txtPretragaIme.Location = new System.Drawing.Point(15, 31);
            this.txtPretragaIme.Name = "txtPretragaIme";
            this.txtPretragaIme.Size = new System.Drawing.Size(281, 20);
            this.txtPretragaIme.TabIndex = 2;
            // 
            // txtPretragaPrezime
            // 
            this.txtPretragaPrezime.Location = new System.Drawing.Point(15, 75);
            this.txtPretragaPrezime.Name = "txtPretragaPrezime";
            this.txtPretragaPrezime.Size = new System.Drawing.Size(281, 20);
            this.txtPretragaPrezime.TabIndex = 3;
            // 
            // txtPretragaEmail
            // 
            this.txtPretragaEmail.Location = new System.Drawing.Point(15, 115);
            this.txtPretragaEmail.Name = "txtPretragaEmail";
            this.txtPretragaEmail.Size = new System.Drawing.Size(281, 20);
            this.txtPretragaEmail.TabIndex = 4;
            // 
            // txtPretragaJMBG
            // 
            this.txtPretragaJMBG.Location = new System.Drawing.Point(393, 31);
            this.txtPretragaJMBG.Name = "txtPretragaJMBG";
            this.txtPretragaJMBG.Size = new System.Drawing.Size(281, 20);
            this.txtPretragaJMBG.TabIndex = 5;
            // 
            // txtPretragaGrad
            // 
            this.txtPretragaGrad.Location = new System.Drawing.Point(393, 75);
            this.txtPretragaGrad.Name = "txtPretragaGrad";
            this.txtPretragaGrad.Size = new System.Drawing.Size(281, 20);
            this.txtPretragaGrad.TabIndex = 6;
            // 
            // txtPretragaDrzava
            // 
            this.txtPretragaDrzava.Location = new System.Drawing.Point(393, 115);
            this.txtPretragaDrzava.Name = "txtPretragaDrzava";
            this.txtPretragaDrzava.Size = new System.Drawing.Size(281, 20);
            this.txtPretragaDrzava.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Prezime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(390, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "JMBG";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(390, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Grad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(390, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Država";
            // 
            // btnDetalji
            // 
            this.btnDetalji.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetalji.Location = new System.Drawing.Point(778, 73);
            this.btnDetalji.Name = "btnDetalji";
            this.btnDetalji.Size = new System.Drawing.Size(148, 23);
            this.btnDetalji.TabIndex = 15;
            this.btnDetalji.Text = "Detalji korisnika";
            this.btnDetalji.UseVisualStyleBackColor = true;
            this.btnDetalji.Click += new System.EventHandler(this.btnDetalji_Click);
            // 
            // btnDodajNovog
            // 
            this.btnDodajNovog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDodajNovog.Location = new System.Drawing.Point(778, 113);
            this.btnDodajNovog.Name = "btnDodajNovog";
            this.btnDodajNovog.Size = new System.Drawing.Size(148, 23);
            this.btnDodajNovog.TabIndex = 16;
            this.btnDodajNovog.Text = "Dodaj novog korisnika";
            this.btnDodajNovog.UseVisualStyleBackColor = true;
            this.btnDodajNovog.Click += new System.EventHandler(this.btnDodajNovog_Click);
            // 
            // frmKorisnicics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 573);
            this.Controls.Add(this.btnDodajNovog);
            this.Controls.Add(this.btnDetalji);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPretragaDrzava);
            this.Controls.Add(this.txtPretragaGrad);
            this.Controls.Add(this.txtPretragaJMBG);
            this.Controls.Add(this.txtPretragaEmail);
            this.Controls.Add(this.txtPretragaPrezime);
            this.Controls.Add(this.txtPretragaIme);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmKorisnicics";
            this.Text = "frmKorisnicics";
            this.Load += new System.EventHandler(this.frmKorisnicics_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvKorisnici;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.TextBox txtPretragaIme;
        private System.Windows.Forms.TextBox txtPretragaPrezime;
        private System.Windows.Forms.TextBox txtPretragaEmail;
        private System.Windows.Forms.TextBox txtPretragaJMBG;
        private System.Windows.Forms.TextBox txtPretragaGrad;
        private System.Windows.Forms.TextBox txtPretragaDrzava;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobitel;
        private System.Windows.Forms.DataGridViewTextBoxColumn JMBG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumRodjenja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Status;
        private System.Windows.Forms.Button btnDetalji;
        private System.Windows.Forms.Button btnDodajNovog;
    }
}