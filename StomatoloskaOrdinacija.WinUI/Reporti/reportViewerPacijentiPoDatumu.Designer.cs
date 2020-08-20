namespace StomatoloskaOrdinacija.WinUI.Reporti
{
    partial class reportViewerPacijentiPoDatumu
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
            this.rpvPacijenti = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bsPacijenti = new System.Windows.Forms.BindingSource(this.components);
            this.MaterijaliBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtpDatumOd = new System.Windows.Forms.DateTimePicker();
            this.dtpDatumDo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsPacijenti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaterijaliBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvPacijenti
            // 
            this.rpvPacijenti.LocalReport.ReportEmbeddedResource = "StomatoloskaOrdinacija.WinUI.Reporti.rptPacijentiPoDatumuRegistracije.rdlc";
            this.rpvPacijenti.Location = new System.Drawing.Point(1, 80);
            this.rpvPacijenti.Name = "rpvPacijenti";
            this.rpvPacijenti.ServerReport.BearerToken = null;
            this.rpvPacijenti.Size = new System.Drawing.Size(828, 505);
            this.rpvPacijenti.TabIndex = 0;
            // 
            // MaterijaliBindingSource
            // 
            this.MaterijaliBindingSource.DataSource = typeof(StomatoloskaOrdinacija.Model.Materijali);
            // 
            // dtpDatumOd
            // 
            this.dtpDatumOd.Location = new System.Drawing.Point(120, 54);
            this.dtpDatumOd.Name = "dtpDatumOd";
            this.dtpDatumOd.Size = new System.Drawing.Size(200, 20);
            this.dtpDatumOd.TabIndex = 1;
            this.dtpDatumOd.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDatumOd.ValueChanged += new System.EventHandler(this.dtpDatumOd_ValueChanged);
            // 
            // dtpDatumDo
            // 
            this.dtpDatumDo.Location = new System.Drawing.Point(468, 54);
            this.dtpDatumDo.Name = "dtpDatumDo";
            this.dtpDatumDo.Size = new System.Drawing.Size(200, 20);
            this.dtpDatumDo.TabIndex = 2;
            this.dtpDatumDo.ValueChanged += new System.EventHandler(this.dtpDatumDo_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Datum od";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(546, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Datum do";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(220, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(346, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Izvjestaj pacijenata po datumu registracije";
            // 
            // reportViewerPacijentiPoDatumu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 585);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDatumDo);
            this.Controls.Add(this.dtpDatumOd);
            this.Controls.Add(this.rpvPacijenti);
            this.Name = "reportViewerPacijentiPoDatumu";
            this.Text = "reportViewerPacijentiPoDatumu";
            this.Load += new System.EventHandler(this.reportViewerPacijentiPoDatumu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsPacijenti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaterijaliBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPacijenti;
        private System.Windows.Forms.BindingSource bsPacijenti;
        private System.Windows.Forms.BindingSource MaterijaliBindingSource;
        private System.Windows.Forms.DateTimePicker dtpDatumOd;
        private System.Windows.Forms.DateTimePicker dtpDatumDo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}