namespace StomatoloskaOrdinacija.WinUI.Racun
{
    partial class frmQRCodeReader
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKamera = new System.Windows.Forms.ComboBox();
            this.pbPrikaz = new System.Windows.Forms.PictureBox();
            this.txtQRReader = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbPrikaz)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(720, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Pokreni kameru";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kamera: ";
            // 
            // cmbKamera
            // 
            this.cmbKamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKamera.FormattingEnabled = true;
            this.cmbKamera.Location = new System.Drawing.Point(267, 27);
            this.cmbKamera.Name = "cmbKamera";
            this.cmbKamera.Size = new System.Drawing.Size(232, 21);
            this.cmbKamera.TabIndex = 2;
            // 
            // pbPrikaz
            // 
            this.pbPrikaz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPrikaz.Location = new System.Drawing.Point(12, 81);
            this.pbPrikaz.Name = "pbPrikaz";
            this.pbPrikaz.Size = new System.Drawing.Size(649, 471);
            this.pbPrikaz.TabIndex = 3;
            this.pbPrikaz.TabStop = false;
            // 
            // txtQRReader
            // 
            this.txtQRReader.Location = new System.Drawing.Point(667, 146);
            this.txtQRReader.Multiline = true;
            this.txtQRReader.Name = "txtQRReader";
            this.txtQRReader.Size = new System.Drawing.Size(259, 140);
            this.txtQRReader.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmQRCodeReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 582);
            this.Controls.Add(this.txtQRReader);
            this.Controls.Add(this.pbPrikaz);
            this.Controls.Add(this.cmbKamera);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "frmQRCodeReader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QR Code Reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQRCodeReader_FormClosing);
            this.Load += new System.EventHandler(this.frmQRCodeReader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPrikaz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKamera;
        private System.Windows.Forms.PictureBox pbPrikaz;
        private System.Windows.Forms.TextBox txtQRReader;
        private System.Windows.Forms.Timer timer1;
    }
}