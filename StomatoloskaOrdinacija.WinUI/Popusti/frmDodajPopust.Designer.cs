namespace StomatoloskaOrdinacija.WinUI.Popusti
{
    partial class frmDodajPopust
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPopust = new System.Windows.Forms.DataGridView();
            this.PopustId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UslugaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PopustOdDatuma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PopustDoDatuma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrijednostPopusta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.cmbUsluga = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpOD = new System.Windows.Forms.DateTimePicker();
            this.dtpDO = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVrijednostPopusta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPopust);
            this.groupBox1.Location = new System.Drawing.Point(12, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 324);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Popusti";
            // 
            // dgvPopust
            // 
            this.dgvPopust.AllowUserToAddRows = false;
            this.dgvPopust.AllowUserToDeleteRows = false;
            this.dgvPopust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPopust.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PopustId,
            this.UslugaId,
            this.PopustOdDatuma,
            this.PopustDoDatuma,
            this.VrijednostPopusta});
            this.dgvPopust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPopust.Location = new System.Drawing.Point(3, 16);
            this.dgvPopust.Name = "dgvPopust";
            this.dgvPopust.ReadOnly = true;
            this.dgvPopust.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPopust.Size = new System.Drawing.Size(590, 305);
            this.dgvPopust.TabIndex = 0;
            this.dgvPopust.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTermini_CellContentClick);
            // 
            // PopustId
            // 
            this.PopustId.DataPropertyName = "PopustId";
            this.PopustId.HeaderText = "PopustId";
            this.PopustId.Name = "PopustId";
            this.PopustId.ReadOnly = true;
            this.PopustId.Visible = false;
            // 
            // UslugaId
            // 
            this.UslugaId.DataPropertyName = "UslugaId";
            this.UslugaId.HeaderText = "UslugaId";
            this.UslugaId.Name = "UslugaId";
            this.UslugaId.ReadOnly = true;
            // 
            // PopustOdDatuma
            // 
            this.PopustOdDatuma.DataPropertyName = "PopustOdDatuma";
            this.PopustOdDatuma.HeaderText = "PopustOdDatuma";
            this.PopustOdDatuma.Name = "PopustOdDatuma";
            this.PopustOdDatuma.ReadOnly = true;
            this.PopustOdDatuma.Width = 150;
            // 
            // PopustDoDatuma
            // 
            this.PopustDoDatuma.DataPropertyName = "PopustDoDatuma";
            this.PopustDoDatuma.HeaderText = "PopustDoDatuma";
            this.PopustDoDatuma.Name = "PopustDoDatuma";
            this.PopustDoDatuma.ReadOnly = true;
            this.PopustDoDatuma.Width = 150;
            // 
            // VrijednostPopusta
            // 
            this.VrijednostPopusta.DataPropertyName = "VrijednostPopusta";
            this.VrijednostPopusta.HeaderText = "VrijednostPopusta";
            this.VrijednostPopusta.Name = "VrijednostPopusta";
            this.VrijednostPopusta.ReadOnly = true;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(464, 169);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(141, 47);
            this.btnDodaj.TabIndex = 20;
            this.btnDodaj.Text = "Dodaj popust";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // cmbUsluga
            // 
            this.cmbUsluga.FormattingEnabled = true;
            this.cmbUsluga.Location = new System.Drawing.Point(15, 39);
            this.cmbUsluga.Name = "cmbUsluga";
            this.cmbUsluga.Size = new System.Drawing.Size(313, 21);
            this.cmbUsluga.TabIndex = 21;
            this.cmbUsluga.SelectedIndexChanged += new System.EventHandler(this.cmbUsluga_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Usluga";
            // 
            // dtpOD
            // 
            this.dtpOD.Location = new System.Drawing.Point(15, 96);
            this.dtpOD.Name = "dtpOD";
            this.dtpOD.Size = new System.Drawing.Size(313, 20);
            this.dtpOD.TabIndex = 24;
            // 
            // dtpDO
            // 
            this.dtpDO.Location = new System.Drawing.Point(15, 148);
            this.dtpDO.Name = "dtpDO";
            this.dtpDO.Size = new System.Drawing.Size(313, 20);
            this.dtpDO.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Početak popusta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Kraj popusta";
            // 
            // txtVrijednostPopusta
            // 
            this.txtVrijednostPopusta.Location = new System.Drawing.Point(15, 196);
            this.txtVrijednostPopusta.Name = "txtVrijednostPopusta";
            this.txtVrijednostPopusta.Size = new System.Drawing.Size(313, 20);
            this.txtVrijednostPopusta.TabIndex = 28;
            this.txtVrijednostPopusta.Validating += new System.ComponentModel.CancelEventHandler(this.txtVrijednostPopusta_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Vrijednost popusta";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmDodajPopust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 571);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtVrijednostPopusta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDO);
            this.Controls.Add(this.dtpOD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbUsluga);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDodajPopust";
            this.Text = "frmDodajPopust";
            this.Load += new System.EventHandler(this.frmDodajPopust_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPopust;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.ComboBox cmbUsluga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpOD;
        private System.Windows.Forms.DateTimePicker dtpDO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVrijednostPopusta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn PopustId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UslugaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PopustOdDatuma;
        private System.Windows.Forms.DataGridViewTextBoxColumn PopustDoDatuma;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrijednostPopusta;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}