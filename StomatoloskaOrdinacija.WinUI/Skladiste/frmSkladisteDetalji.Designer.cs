namespace StomatoloskaOrdinacija.WinUI.Skladiste
{
    partial class frmSkladisteDetalji
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
            this.btnSnimi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProizvodjac = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVrsta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMjernaJedinica = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKolicina = new System.Windows.Forms.Label();
            this.txtSlika = new System.Windows.Forms.TextBox();
            this.Slika = new System.Windows.Forms.Label();
            this.txtCijena = new System.Windows.Forms.Label();
            this.btnUploadSlika = new System.Windows.Forms.Button();
            this.pcbSlika = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtKolicina1 = new System.Windows.Forms.TextBox();
            this.txtCijena1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSlika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSnimi
            // 
            this.btnSnimi.Location = new System.Drawing.Point(115, 431);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(220, 28);
            this.btnSnimi.TabIndex = 0;
            this.btnSnimi.Text = "Snimi";
            this.btnSnimi.UseVisualStyleBackColor = true;
            this.btnSnimi.Click += new System.EventHandler(this.btnSnimi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Naziv";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(12, 44);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(159, 20);
            this.txtNaziv.TabIndex = 3;
            this.txtNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.txtNaziv_Validating);
            // 
            // txtOpis
            // 
            this.txtOpis.Location = new System.Drawing.Point(277, 44);
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(159, 20);
            this.txtOpis.TabIndex = 5;
            this.txtOpis.Validating += new System.ComponentModel.CancelEventHandler(this.txtOpis_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Opis";
            // 
            // txtProizvodjac
            // 
            this.txtProizvodjac.Location = new System.Drawing.Point(278, 92);
            this.txtProizvodjac.Name = "txtProizvodjac";
            this.txtProizvodjac.Size = new System.Drawing.Size(159, 20);
            this.txtProizvodjac.TabIndex = 9;
            this.txtProizvodjac.Validating += new System.ComponentModel.CancelEventHandler(this.txtProizvodjac_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Proizvodjac";
            // 
            // txtVrsta
            // 
            this.txtVrsta.Location = new System.Drawing.Point(13, 92);
            this.txtVrsta.Name = "txtVrsta";
            this.txtVrsta.Size = new System.Drawing.Size(159, 20);
            this.txtVrsta.TabIndex = 7;
            this.txtVrsta.Validating += new System.ComponentModel.CancelEventHandler(this.txtVrsta_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Vrsta";
            // 
            // txtMjernaJedinica
            // 
            this.txtMjernaJedinica.Location = new System.Drawing.Point(277, 141);
            this.txtMjernaJedinica.Name = "txtMjernaJedinica";
            this.txtMjernaJedinica.Size = new System.Drawing.Size(159, 20);
            this.txtMjernaJedinica.TabIndex = 13;
            this.txtMjernaJedinica.Validating += new System.ComponentModel.CancelEventHandler(this.txtMjernaJedinica_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Mjerna jedinica";
            // 
            // txtKolicina
            // 
            this.txtKolicina.AutoSize = true;
            this.txtKolicina.Location = new System.Drawing.Point(10, 125);
            this.txtKolicina.Name = "txtKolicina";
            this.txtKolicina.Size = new System.Drawing.Size(44, 13);
            this.txtKolicina.TabIndex = 10;
            this.txtKolicina.Text = "Kolicina";
            // 
            // txtSlika
            // 
            this.txtSlika.Location = new System.Drawing.Point(277, 193);
            this.txtSlika.Name = "txtSlika";
            this.txtSlika.Size = new System.Drawing.Size(159, 20);
            this.txtSlika.TabIndex = 17;
            // 
            // Slika
            // 
            this.Slika.AutoSize = true;
            this.Slika.Location = new System.Drawing.Point(275, 177);
            this.Slika.Name = "Slika";
            this.Slika.Size = new System.Drawing.Size(30, 13);
            this.Slika.TabIndex = 16;
            this.Slika.Text = "Slika";
            // 
            // txtCijena
            // 
            this.txtCijena.AutoSize = true;
            this.txtCijena.Location = new System.Drawing.Point(10, 177);
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(36, 13);
            this.txtCijena.TabIndex = 14;
            this.txtCijena.Text = "Cijena";
            // 
            // btnUploadSlika
            // 
            this.btnUploadSlika.Location = new System.Drawing.Point(277, 220);
            this.btnUploadSlika.Name = "btnUploadSlika";
            this.btnUploadSlika.Size = new System.Drawing.Size(159, 23);
            this.btnUploadSlika.TabIndex = 18;
            this.btnUploadSlika.Text = "Dodaj sliku";
            this.btnUploadSlika.UseVisualStyleBackColor = true;
            this.btnUploadSlika.Click += new System.EventHandler(this.btnUploadSlika_Click);
            // 
            // pcbSlika
            // 
            this.pcbSlika.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcbSlika.Location = new System.Drawing.Point(115, 253);
            this.pcbSlika.Name = "pcbSlika";
            this.pcbSlika.Size = new System.Drawing.Size(220, 162);
            this.pcbSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbSlika.TabIndex = 19;
            this.pcbSlika.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtKolicina1
            // 
            this.txtKolicina1.Location = new System.Drawing.Point(12, 141);
            this.txtKolicina1.Name = "txtKolicina1";
            this.txtKolicina1.Size = new System.Drawing.Size(159, 20);
            this.txtKolicina1.TabIndex = 20;
            this.txtKolicina1.Validating += new System.ComponentModel.CancelEventHandler(this.txtKolicina1_Validating);
            // 
            // txtCijena1
            // 
            this.txtCijena1.Location = new System.Drawing.Point(12, 193);
            this.txtCijena1.Name = "txtCijena1";
            this.txtCijena1.Size = new System.Drawing.Size(159, 20);
            this.txtCijena1.TabIndex = 21;
            this.txtCijena1.Validating += new System.ComponentModel.CancelEventHandler(this.txtCijena1_Validating);
            // 
            // frmSkladisteDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 471);
            this.Controls.Add(this.txtCijena1);
            this.Controls.Add(this.txtKolicina1);
            this.Controls.Add(this.pcbSlika);
            this.Controls.Add(this.btnUploadSlika);
            this.Controls.Add(this.txtSlika);
            this.Controls.Add(this.Slika);
            this.Controls.Add(this.txtCijena);
            this.Controls.Add(this.txtMjernaJedinica);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtKolicina);
            this.Controls.Add(this.txtProizvodjac);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVrsta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOpis);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSnimi);
            this.Name = "frmSkladisteDetalji";
            this.Text = "frmSkladisteDetalji";
            this.Load += new System.EventHandler(this.frmSkladisteDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbSlika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSnimi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProizvodjac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVrsta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMjernaJedinica;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtKolicina;
        private System.Windows.Forms.TextBox txtSlika;
        private System.Windows.Forms.Label Slika;
        private System.Windows.Forms.Label txtCijena;
        private System.Windows.Forms.Button btnUploadSlika;
        private System.Windows.Forms.PictureBox pcbSlika;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtCijena1;
        private System.Windows.Forms.TextBox txtKolicina1;
    }
}