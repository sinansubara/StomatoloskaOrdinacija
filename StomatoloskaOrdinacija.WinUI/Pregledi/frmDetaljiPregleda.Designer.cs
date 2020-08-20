namespace StomatoloskaOrdinacija.WinUI.Pregledi
{
    partial class frmDetaljiPregleda
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
            this.txtRazlogTermina = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStanjeNaSkladistu = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSnimiPregled = new System.Windows.Forms.Button();
            this.txtNapomenaPregleda = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTrajanje = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtImeIPrezime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTerminNapomena = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKolicina = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMaterijal = new System.Windows.Forms.ComboBox();
            this.cmbLijek = new System.Windows.Forms.ComboBox();
            this.cmbDijagnoza = new System.Windows.Forms.ComboBox();
            this.txtTermin = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRazlogTermina
            // 
            this.txtRazlogTermina.Location = new System.Drawing.Point(100, 133);
            this.txtRazlogTermina.Name = "txtRazlogTermina";
            this.txtRazlogTermina.ReadOnly = true;
            this.txtRazlogTermina.Size = new System.Drawing.Size(233, 20);
            this.txtRazlogTermina.TabIndex = 45;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(97, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "Razlog";
            // 
            // txtStanjeNaSkladistu
            // 
            this.txtStanjeNaSkladistu.Location = new System.Drawing.Point(611, 251);
            this.txtStanjeNaSkladistu.Name = "txtStanjeNaSkladistu";
            this.txtStanjeNaSkladistu.ReadOnly = true;
            this.txtStanjeNaSkladistu.Size = new System.Drawing.Size(93, 20);
            this.txtStanjeNaSkladistu.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(608, 235);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Stanje na skladištu";
            // 
            // txtSnimiPregled
            // 
            this.txtSnimiPregled.Location = new System.Drawing.Point(223, 374);
            this.txtSnimiPregled.Name = "txtSnimiPregled";
            this.txtSnimiPregled.Size = new System.Drawing.Size(267, 55);
            this.txtSnimiPregled.TabIndex = 41;
            this.txtSnimiPregled.Text = "Snimi pregled";
            this.txtSnimiPregled.UseVisualStyleBackColor = true;
            this.txtSnimiPregled.Click += new System.EventHandler(this.txtSnimiPregled_Click);
            // 
            // txtNapomenaPregleda
            // 
            this.txtNapomenaPregleda.Location = new System.Drawing.Point(364, 311);
            this.txtNapomenaPregleda.Name = "txtNapomenaPregleda";
            this.txtNapomenaPregleda.Size = new System.Drawing.Size(233, 20);
            this.txtNapomenaPregleda.TabIndex = 40;
            this.txtNapomenaPregleda.Validating += new System.ComponentModel.CancelEventHandler(this.txtNapomenaPregleda_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(361, 295);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Napomena pregleda";
            // 
            // txtTrajanje
            // 
            this.txtTrajanje.Location = new System.Drawing.Point(100, 311);
            this.txtTrajanje.Name = "txtTrajanje";
            this.txtTrajanje.Size = new System.Drawing.Size(233, 20);
            this.txtTrajanje.TabIndex = 38;
            this.txtTrajanje.Validating += new System.ComponentModel.CancelEventHandler(this.txtTrajanje_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(97, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Trajanje pregleda(minute)";
            // 
            // txtImeIPrezime
            // 
            this.txtImeIPrezime.Location = new System.Drawing.Point(364, 81);
            this.txtImeIPrezime.Name = "txtImeIPrezime";
            this.txtImeIPrezime.ReadOnly = true;
            this.txtImeIPrezime.Size = new System.Drawing.Size(226, 20);
            this.txtImeIPrezime.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(361, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Ime i prezime pacijenta";
            // 
            // txtTerminNapomena
            // 
            this.txtTerminNapomena.Location = new System.Drawing.Point(364, 133);
            this.txtTerminNapomena.Name = "txtTerminNapomena";
            this.txtTerminNapomena.ReadOnly = true;
            this.txtTerminNapomena.Size = new System.Drawing.Size(226, 20);
            this.txtTerminNapomena.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(361, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Datum i vrijeme";
            // 
            // txtKolicina
            // 
            this.txtKolicina.Location = new System.Drawing.Point(364, 251);
            this.txtKolicina.Name = "txtKolicina";
            this.txtKolicina.Size = new System.Drawing.Size(226, 20);
            this.txtKolicina.TabIndex = 32;
            this.txtKolicina.Validating += new System.ComponentModel.CancelEventHandler(this.txtKolicina_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(361, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Količina";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Materijal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Lijek";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Dijagnoza";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Usluga";
            // 
            // cmbMaterijal
            // 
            this.cmbMaterijal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterijal.FormattingEnabled = true;
            this.cmbMaterijal.Location = new System.Drawing.Point(100, 251);
            this.cmbMaterijal.Name = "cmbMaterijal";
            this.cmbMaterijal.Size = new System.Drawing.Size(233, 21);
            this.cmbMaterijal.TabIndex = 26;
            this.cmbMaterijal.SelectedIndexChanged += new System.EventHandler(this.cmbMaterijal_SelectedIndexChanged_1);
            // 
            // cmbLijek
            // 
            this.cmbLijek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLijek.FormattingEnabled = true;
            this.cmbLijek.Location = new System.Drawing.Point(364, 185);
            this.cmbLijek.Name = "cmbLijek";
            this.cmbLijek.Size = new System.Drawing.Size(226, 21);
            this.cmbLijek.TabIndex = 25;
            // 
            // cmbDijagnoza
            // 
            this.cmbDijagnoza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDijagnoza.FormattingEnabled = true;
            this.cmbDijagnoza.Location = new System.Drawing.Point(100, 185);
            this.cmbDijagnoza.Name = "cmbDijagnoza";
            this.cmbDijagnoza.Size = new System.Drawing.Size(233, 21);
            this.cmbDijagnoza.TabIndex = 24;
            // 
            // txtTermin
            // 
            this.txtTermin.Location = new System.Drawing.Point(100, 81);
            this.txtTermin.Name = "txtTermin";
            this.txtTermin.ReadOnly = true;
            this.txtTermin.Size = new System.Drawing.Size(233, 20);
            this.txtTermin.TabIndex = 46;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmDetaljiPregleda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtTermin);
            this.Controls.Add(this.txtRazlogTermina);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtStanjeNaSkladistu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSnimiPregled);
            this.Controls.Add(this.txtNapomenaPregleda);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTrajanje);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtImeIPrezime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTerminNapomena);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtKolicina);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMaterijal);
            this.Controls.Add(this.cmbLijek);
            this.Controls.Add(this.cmbDijagnoza);
            this.Name = "frmDetaljiPregleda";
            this.Text = "frmDetaljiPregleda";
            this.Load += new System.EventHandler(this.frmDetaljiPregleda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRazlogTermina;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtStanjeNaSkladistu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button txtSnimiPregled;
        private System.Windows.Forms.TextBox txtNapomenaPregleda;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTrajanje;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtImeIPrezime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTerminNapomena;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKolicina;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMaterijal;
        private System.Windows.Forms.ComboBox cmbLijek;
        private System.Windows.Forms.ComboBox cmbDijagnoza;
        private System.Windows.Forms.TextBox txtTermin;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}