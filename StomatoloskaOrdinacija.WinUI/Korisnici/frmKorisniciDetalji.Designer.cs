namespace StomatoloskaOrdinacija.WinUI.Korisnici
{
    partial class frmKorisniciDetalji
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
            this.components = new System.ComponentModel.Container();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJMBG = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpDatumRodjenja = new System.Windows.Forms.DateTimePicker();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.txtMobitel = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPotvrdaLozinke = new System.Windows.Forms.TextBox();
            this.txtLozinka = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtKorisnickoIme = new System.Windows.Forms.TextBox();
            this.btnSnimi = new System.Windows.Forms.Button();
            this.cbGrad = new System.Windows.Forms.ComboBox();
            this.cbUloga = new System.Windows.Forms.ComboBox();
            this.cbSpol = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pcbSlika = new System.Windows.Forms.PictureBox();
            this.txtSlikaInput = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSlika)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(12, 108);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(202, 20);
            this.txtIme.TabIndex = 0;
            this.txtIme.Validating += new System.ComponentModel.CancelEventHandler(this.txtIme_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Prezime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "JMBG";
            // 
            // txtJMBG
            // 
            this.txtJMBG.Location = new System.Drawing.Point(12, 173);
            this.txtJMBG.Name = "txtJMBG";
            this.txtJMBG.Size = new System.Drawing.Size(202, 20);
            this.txtJMBG.TabIndex = 6;
            this.txtJMBG.Validating += new System.ComponentModel.CancelEventHandler(this.txtJMBG_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mobitel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(520, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Adresa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Datum rođenja";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(266, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Grad";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(520, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Spol";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(266, 286);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Uloga";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(520, 286);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Status";
            // 
            // dtpDatumRodjenja
            // 
            this.dtpDatumRodjenja.Location = new System.Drawing.Point(12, 236);
            this.dtpDatumRodjenja.Name = "dtpDatumRodjenja";
            this.dtpDatumRodjenja.Size = new System.Drawing.Size(202, 20);
            this.dtpDatumRodjenja.TabIndex = 24;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(266, 108);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(202, 20);
            this.txtPrezime.TabIndex = 25;
            this.txtPrezime.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrezime_Validating);
            // 
            // txtMobitel
            // 
            this.txtMobitel.Location = new System.Drawing.Point(266, 173);
            this.txtMobitel.Name = "txtMobitel";
            this.txtMobitel.Size = new System.Drawing.Size(202, 20);
            this.txtMobitel.TabIndex = 26;
            this.txtMobitel.Validating += new System.ComponentModel.CancelEventHandler(this.txtMobitel_Validating);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(523, 108);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(202, 20);
            this.txtEmail.TabIndex = 29;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // txtAdresa
            // 
            this.txtAdresa.Location = new System.Drawing.Point(523, 173);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(202, 20);
            this.txtAdresa.TabIndex = 30;
            this.txtAdresa.Validating += new System.ComponentModel.CancelEventHandler(this.txtAdresa_Validating);
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Location = new System.Drawing.Point(523, 304);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(62, 17);
            this.cbStatus.TabIndex = 35;
            this.cbStatus.Text = "Aktivan";
            this.cbStatus.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "Upload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 286);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "Slika";
            // 
            // txtPotvrdaLozinke
            // 
            this.txtPotvrdaLozinke.Location = new System.Drawing.Point(523, 374);
            this.txtPotvrdaLozinke.Name = "txtPotvrdaLozinke";
            this.txtPotvrdaLozinke.PasswordChar = '*';
            this.txtPotvrdaLozinke.Size = new System.Drawing.Size(202, 20);
            this.txtPotvrdaLozinke.TabIndex = 44;
            this.txtPotvrdaLozinke.Validating += new System.ComponentModel.CancelEventHandler(this.txtPotvrdaLozinke_Validating);
            // 
            // txtLozinka
            // 
            this.txtLozinka.Location = new System.Drawing.Point(266, 374);
            this.txtLozinka.Name = "txtLozinka";
            this.txtLozinka.PasswordChar = '*';
            this.txtLozinka.Size = new System.Drawing.Size(202, 20);
            this.txtLozinka.TabIndex = 43;
            this.txtLozinka.Validating += new System.ComponentModel.CancelEventHandler(this.txtLozinka_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(520, 358);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Potvrda lozinke";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(263, 358);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "Lozinka";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 358);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "Korisničko ime";
            // 
            // txtKorisnickoIme
            // 
            this.txtKorisnickoIme.Location = new System.Drawing.Point(12, 374);
            this.txtKorisnickoIme.Name = "txtKorisnickoIme";
            this.txtKorisnickoIme.Size = new System.Drawing.Size(202, 20);
            this.txtKorisnickoIme.TabIndex = 39;
            this.txtKorisnickoIme.Validating += new System.ComponentModel.CancelEventHandler(this.txtKorisnickoIme_Validating);
            // 
            // btnSnimi
            // 
            this.btnSnimi.Location = new System.Drawing.Point(584, 464);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(141, 33);
            this.btnSnimi.TabIndex = 45;
            this.btnSnimi.Text = "Sačuvaj";
            this.btnSnimi.UseVisualStyleBackColor = true;
            this.btnSnimi.Click += new System.EventHandler(this.btnSnimi_Click);
            // 
            // cbGrad
            // 
            this.cbGrad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrad.FormattingEnabled = true;
            this.cbGrad.Location = new System.Drawing.Point(266, 239);
            this.cbGrad.Name = "cbGrad";
            this.cbGrad.Size = new System.Drawing.Size(202, 21);
            this.cbGrad.TabIndex = 46;
            // 
            // cbUloga
            // 
            this.cbUloga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUloga.FormattingEnabled = true;
            this.cbUloga.Location = new System.Drawing.Point(266, 302);
            this.cbUloga.Name = "cbUloga";
            this.cbUloga.Size = new System.Drawing.Size(202, 21);
            this.cbUloga.TabIndex = 47;
            // 
            // cbSpol
            // 
            this.cbSpol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpol.FormattingEnabled = true;
            this.cbSpol.Location = new System.Drawing.Point(523, 239);
            this.cbSpol.Name = "cbSpol";
            this.cbSpol.Size = new System.Drawing.Size(202, 21);
            this.cbSpol.TabIndex = 48;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // pcbSlika
            // 
            this.pcbSlika.Location = new System.Drawing.Point(23, 434);
            this.pcbSlika.Name = "pcbSlika";
            this.pcbSlika.Size = new System.Drawing.Size(284, 247);
            this.pcbSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbSlika.TabIndex = 87;
            this.pcbSlika.TabStop = false;
            // 
            // txtSlikaInput
            // 
            this.txtSlikaInput.Location = new System.Drawing.Point(12, 302);
            this.txtSlikaInput.Name = "txtSlikaInput";
            this.txtSlikaInput.Size = new System.Drawing.Size(121, 20);
            this.txtSlikaInput.TabIndex = 88;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmKorisniciDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 721);
            this.Controls.Add(this.txtSlikaInput);
            this.Controls.Add(this.pcbSlika);
            this.Controls.Add(this.cbSpol);
            this.Controls.Add(this.cbUloga);
            this.Controls.Add(this.cbGrad);
            this.Controls.Add(this.btnSnimi);
            this.Controls.Add(this.txtPotvrdaLozinke);
            this.Controls.Add(this.txtLozinka);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtKorisnickoIme);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.txtAdresa);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtMobitel);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.dtpDatumRodjenja);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtJMBG);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIme);
            this.Name = "frmKorisniciDetalji";
            this.Text = "frmKorisniciDetalji";
            this.Load += new System.EventHandler(this.frmKorisniciDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSlika)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtJMBG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpDatumRodjenja;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.TextBox txtMobitel;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.CheckBox cbStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPotvrdaLozinke;
        private System.Windows.Forms.TextBox txtLozinka;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtKorisnickoIme;
        private System.Windows.Forms.Button btnSnimi;
        private System.Windows.Forms.ComboBox cbGrad;
        private System.Windows.Forms.ComboBox cbUloga;
        private System.Windows.Forms.ComboBox cbSpol;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.PictureBox pcbSlika;
        private System.Windows.Forms.TextBox txtSlikaInput;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}