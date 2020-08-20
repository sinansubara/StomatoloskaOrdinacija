namespace StomatoloskaOrdinacija.WinUI.Pregledi
{
    partial class frmUnosPregleda
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
            this.cmbTermin = new System.Windows.Forms.ComboBox();
            this.cmbDijagnoza = new System.Windows.Forms.ComboBox();
            this.cmbLijek = new System.Windows.Forms.ComboBox();
            this.cmbMaterijal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKolicina = new System.Windows.Forms.TextBox();
            this.txtTerminNapomena = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImeIPrezime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTrajanje = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNapomenaPregleda = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSnimiPregled = new System.Windows.Forms.Button();
            this.txtStanjeNaSkladistu = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtRazlogTermina = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTermin
            // 
            this.cmbTermin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTermin.FormattingEnabled = true;
            this.cmbTermin.Location = new System.Drawing.Point(63, 73);
            this.cmbTermin.Name = "cmbTermin";
            this.cmbTermin.Size = new System.Drawing.Size(490, 21);
            this.cmbTermin.TabIndex = 0;
            this.cmbTermin.SelectedIndexChanged += new System.EventHandler(this.cmbTermin_SelectedIndexChanged);
            // 
            // cmbDijagnoza
            // 
            this.cmbDijagnoza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDijagnoza.FormattingEnabled = true;
            this.cmbDijagnoza.Location = new System.Drawing.Point(63, 177);
            this.cmbDijagnoza.Name = "cmbDijagnoza";
            this.cmbDijagnoza.Size = new System.Drawing.Size(233, 21);
            this.cmbDijagnoza.TabIndex = 1;
            // 
            // cmbLijek
            // 
            this.cmbLijek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLijek.FormattingEnabled = true;
            this.cmbLijek.Location = new System.Drawing.Point(327, 177);
            this.cmbLijek.Name = "cmbLijek";
            this.cmbLijek.Size = new System.Drawing.Size(226, 21);
            this.cmbLijek.TabIndex = 2;
            // 
            // cmbMaterijal
            // 
            this.cmbMaterijal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterijal.FormattingEnabled = true;
            this.cmbMaterijal.Location = new System.Drawing.Point(63, 243);
            this.cmbMaterijal.Name = "cmbMaterijal";
            this.cmbMaterijal.Size = new System.Drawing.Size(233, 21);
            this.cmbMaterijal.TabIndex = 3;
            this.cmbMaterijal.SelectedIndexChanged += new System.EventHandler(this.cmbMaterijal_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Termin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Dijagnoza";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Lijek";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Materijal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(324, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Količina";
            // 
            // txtKolicina
            // 
            this.txtKolicina.Location = new System.Drawing.Point(327, 243);
            this.txtKolicina.Name = "txtKolicina";
            this.txtKolicina.Size = new System.Drawing.Size(226, 20);
            this.txtKolicina.TabIndex = 9;
            this.txtKolicina.Validating += new System.ComponentModel.CancelEventHandler(this.txtKolicina_Validating);
            // 
            // txtTerminNapomena
            // 
            this.txtTerminNapomena.Location = new System.Drawing.Point(327, 125);
            this.txtTerminNapomena.Name = "txtTerminNapomena";
            this.txtTerminNapomena.ReadOnly = true;
            this.txtTerminNapomena.Size = new System.Drawing.Size(226, 20);
            this.txtTerminNapomena.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(324, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Datum i vrijeme";
            // 
            // txtImeIPrezime
            // 
            this.txtImeIPrezime.Location = new System.Drawing.Point(196, 29);
            this.txtImeIPrezime.Name = "txtImeIPrezime";
            this.txtImeIPrezime.ReadOnly = true;
            this.txtImeIPrezime.Size = new System.Drawing.Size(257, 20);
            this.txtImeIPrezime.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ime i prezime pacijenta";
            // 
            // txtTrajanje
            // 
            this.txtTrajanje.Location = new System.Drawing.Point(63, 303);
            this.txtTrajanje.Name = "txtTrajanje";
            this.txtTrajanje.Size = new System.Drawing.Size(233, 20);
            this.txtTrajanje.TabIndex = 15;
            this.txtTrajanje.Validating += new System.ComponentModel.CancelEventHandler(this.txtTrajanje_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Trajanje pregleda(minute)";
            // 
            // txtNapomenaPregleda
            // 
            this.txtNapomenaPregleda.Location = new System.Drawing.Point(327, 303);
            this.txtNapomenaPregleda.Name = "txtNapomenaPregleda";
            this.txtNapomenaPregleda.Size = new System.Drawing.Size(233, 20);
            this.txtNapomenaPregleda.TabIndex = 17;
            this.txtNapomenaPregleda.Validating += new System.ComponentModel.CancelEventHandler(this.txtNapomenaPregleda_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(324, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Napomena pregleda";
            // 
            // txtSnimiPregled
            // 
            this.txtSnimiPregled.Location = new System.Drawing.Point(186, 366);
            this.txtSnimiPregled.Name = "txtSnimiPregled";
            this.txtSnimiPregled.Size = new System.Drawing.Size(267, 55);
            this.txtSnimiPregled.TabIndex = 18;
            this.txtSnimiPregled.Text = "Snimi pregled";
            this.txtSnimiPregled.UseVisualStyleBackColor = true;
            this.txtSnimiPregled.Click += new System.EventHandler(this.txtSnimiPregled_Click);
            // 
            // txtStanjeNaSkladistu
            // 
            this.txtStanjeNaSkladistu.Location = new System.Drawing.Point(574, 243);
            this.txtStanjeNaSkladistu.Name = "txtStanjeNaSkladistu";
            this.txtStanjeNaSkladistu.ReadOnly = true;
            this.txtStanjeNaSkladistu.Size = new System.Drawing.Size(93, 20);
            this.txtStanjeNaSkladistu.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(571, 227);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Stanje na skladištu";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtRazlogTermina
            // 
            this.txtRazlogTermina.Location = new System.Drawing.Point(63, 125);
            this.txtRazlogTermina.Name = "txtRazlogTermina";
            this.txtRazlogTermina.ReadOnly = true;
            this.txtRazlogTermina.Size = new System.Drawing.Size(226, 20);
            this.txtRazlogTermina.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(60, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Razlog";
            // 
            // frmUnosPregleda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 441);
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
            this.Controls.Add(this.cmbTermin);
            this.Name = "frmUnosPregleda";
            this.Text = "frmUnosPregleda";
            this.Load += new System.EventHandler(this.frmUnosPregleda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTermin;
        private System.Windows.Forms.ComboBox cmbDijagnoza;
        private System.Windows.Forms.ComboBox cmbLijek;
        private System.Windows.Forms.ComboBox cmbMaterijal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKolicina;
        private System.Windows.Forms.TextBox txtTerminNapomena;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtImeIPrezime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTrajanje;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNapomenaPregleda;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button txtSnimiPregled;
        private System.Windows.Forms.TextBox txtStanjeNaSkladistu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtRazlogTermina;
        private System.Windows.Forms.Label label11;
    }
}