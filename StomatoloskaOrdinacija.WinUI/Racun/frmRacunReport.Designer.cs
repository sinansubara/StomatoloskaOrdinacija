namespace StomatoloskaOrdinacija.WinUI.Racun
{
    partial class frmRacunReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rpvRacun = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bsRacun = new System.Windows.Forms.BindingSource(this.components);
            this.RacunBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsRacun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacunBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvRacun
            // 
            this.rpvRacun.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsRacunIzdavanje";
            reportDataSource1.Value = this.bsRacun;
            this.rpvRacun.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvRacun.LocalReport.ReportEmbeddedResource = "StomatoloskaOrdinacija.WinUI.Racun.rptRacunIzdavanje.rdlc";
            this.rpvRacun.Location = new System.Drawing.Point(0, 0);
            this.rpvRacun.Name = "rpvRacun";
            this.rpvRacun.ServerReport.BearerToken = null;
            this.rpvRacun.Size = new System.Drawing.Size(861, 482);
            this.rpvRacun.TabIndex = 0;
            // 
            // RacunBindingSource
            // 
            this.RacunBindingSource.DataSource = typeof(StomatoloskaOrdinacija.Model.Racun);
            // 
            // frmRacunReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 482);
            this.Controls.Add(this.rpvRacun);
            this.Name = "frmRacunReport";
            this.Text = "frmRacunReport";
            this.Load += new System.EventHandler(this.frmRacunReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsRacun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacunBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvRacun;
        private System.Windows.Forms.BindingSource RacunBindingSource;
        private System.Windows.Forms.BindingSource bsRacun;
    }
}