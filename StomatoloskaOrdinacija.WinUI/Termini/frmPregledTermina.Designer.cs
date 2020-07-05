namespace StomatoloskaOrdinacija.WinUI.Termini
{
    partial class frmPregledTermina
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
            this.cbNacekanju = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTermini = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOdobri = new System.Windows.Forms.Button();
            this.btnOdbij = new System.Windows.Forms.Button();
            this.TerminId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Razlog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumVrijeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hitan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsOdobren = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsNaCekanju = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTermini)).BeginInit();
            this.SuspendLayout();
            // 
            // cbNacekanju
            // 
            this.cbNacekanju.AutoSize = true;
            this.cbNacekanju.Location = new System.Drawing.Point(567, 33);
            this.cbNacekanju.Name = "cbNacekanju";
            this.cbNacekanju.Size = new System.Drawing.Size(87, 17);
            this.cbNacekanju.TabIndex = 0;
            this.cbNacekanju.Text = "Na čekanju?";
            this.cbNacekanju.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTermini);
            this.groupBox1.Location = new System.Drawing.Point(10, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(949, 475);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Korisnici";
            // 
            // dgvTermini
            // 
            this.dgvTermini.AllowUserToAddRows = false;
            this.dgvTermini.AllowUserToDeleteRows = false;
            this.dgvTermini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTermini.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TerminId,
            this.Razlog,
            this.DatumVrijeme,
            this.Hitan,
            this.IsOdobren,
            this.IsNaCekanju});
            this.dgvTermini.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTermini.Location = new System.Drawing.Point(3, 16);
            this.dgvTermini.Name = "dgvTermini";
            this.dgvTermini.ReadOnly = true;
            this.dgvTermini.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTermini.Size = new System.Drawing.Size(943, 456);
            this.dgvTermini.TabIndex = 0;
            this.dgvTermini.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKorisnici_CellContentClick);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(671, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 34);
            this.button1.TabIndex = 19;
            this.button1.Text = "Osvježi tabelu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOdobri
            // 
            this.btnOdobri.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOdobri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOdobri.Location = new System.Drawing.Point(822, 12);
            this.btnOdobri.Name = "btnOdobri";
            this.btnOdobri.Size = new System.Drawing.Size(134, 23);
            this.btnOdobri.TabIndex = 20;
            this.btnOdobri.Text = "Odobri";
            this.btnOdobri.UseVisualStyleBackColor = false;
            this.btnOdobri.Click += new System.EventHandler(this.btnOdobri_Click);
            // 
            // btnOdbij
            // 
            this.btnOdbij.BackColor = System.Drawing.Color.Crimson;
            this.btnOdbij.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOdbij.Location = new System.Drawing.Point(822, 47);
            this.btnOdbij.Name = "btnOdbij";
            this.btnOdbij.Size = new System.Drawing.Size(134, 23);
            this.btnOdbij.TabIndex = 21;
            this.btnOdbij.Text = "Odbij";
            this.btnOdbij.UseVisualStyleBackColor = false;
            this.btnOdbij.Click += new System.EventHandler(this.btnOdbij_Click);
            // 
            // TerminId
            // 
            this.TerminId.DataPropertyName = "TerminId";
            this.TerminId.HeaderText = "TerminId";
            this.TerminId.Name = "TerminId";
            this.TerminId.ReadOnly = true;
            this.TerminId.Visible = false;
            // 
            // Razlog
            // 
            this.Razlog.DataPropertyName = "Razlog";
            this.Razlog.HeaderText = "Razlog";
            this.Razlog.Name = "Razlog";
            this.Razlog.ReadOnly = true;
            this.Razlog.Width = 150;
            // 
            // DatumVrijeme
            // 
            this.DatumVrijeme.DataPropertyName = "DatumVrijeme";
            this.DatumVrijeme.HeaderText = "DatumVrijeme";
            this.DatumVrijeme.Name = "DatumVrijeme";
            this.DatumVrijeme.ReadOnly = true;
            this.DatumVrijeme.Width = 200;
            // 
            // Hitan
            // 
            this.Hitan.DataPropertyName = "Hitan";
            this.Hitan.HeaderText = "Hitan";
            this.Hitan.Name = "Hitan";
            this.Hitan.ReadOnly = true;
            this.Hitan.Width = 150;
            // 
            // IsOdobren
            // 
            this.IsOdobren.DataPropertyName = "IsOdobren";
            this.IsOdobren.HeaderText = "Odobren";
            this.IsOdobren.Name = "IsOdobren";
            this.IsOdobren.ReadOnly = true;
            this.IsOdobren.Width = 150;
            // 
            // IsNaCekanju
            // 
            this.IsNaCekanju.DataPropertyName = "IsNaCekanju";
            this.IsNaCekanju.HeaderText = "Na čekanju";
            this.IsNaCekanju.Name = "IsNaCekanju";
            this.IsNaCekanju.ReadOnly = true;
            this.IsNaCekanju.Width = 150;
            // 
            // frmPregledTermina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 576);
            this.Controls.Add(this.btnOdbij);
            this.Controls.Add(this.btnOdobri);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbNacekanju);
            this.Name = "frmPregledTermina";
            this.Text = "frmPregledTermina";
            this.Load += new System.EventHandler(this.frmPregledTermina_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTermini)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbNacekanju;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTermini;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOdobri;
        private System.Windows.Forms.Button btnOdbij;
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Razlog;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumVrijeme;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Hitan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsOdobren;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsNaCekanju;
    }
}