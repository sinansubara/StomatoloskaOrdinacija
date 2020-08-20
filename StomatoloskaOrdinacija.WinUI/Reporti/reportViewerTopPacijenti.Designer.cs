namespace StomatoloskaOrdinacija.WinUI.Reporti
{
    partial class reportViewerTopPacijenti
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
            this.KorisniciBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvTopPacijenti = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bsTopPacijenti = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.KorisniciBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTopPacijenti)).BeginInit();
            this.SuspendLayout();
            // 
            // KorisniciBindingSource
            // 
            this.KorisniciBindingSource.DataSource = typeof(StomatoloskaOrdinacija.Model.Korisnici);
            // 
            // rpvTopPacijenti
            // 
            this.rpvTopPacijenti.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsTopPacijenti";
            reportDataSource1.Value = this.bsTopPacijenti;
            this.rpvTopPacijenti.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvTopPacijenti.LocalReport.ReportEmbeddedResource = "StomatoloskaOrdinacija.WinUI.Reporti.rptTop10Pacijenata.rdlc";
            this.rpvTopPacijenti.Location = new System.Drawing.Point(0, 0);
            this.rpvTopPacijenti.Name = "rpvTopPacijenti";
            this.rpvTopPacijenti.ServerReport.BearerToken = null;
            this.rpvTopPacijenti.Size = new System.Drawing.Size(800, 450);
            this.rpvTopPacijenti.TabIndex = 0;
            // 
            // reportViewerTopPacijenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpvTopPacijenti);
            this.Name = "reportViewerTopPacijenti";
            this.Text = "reportViewerTopPacijenti";
            this.Load += new System.EventHandler(this.reportViewerTopPacijenti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KorisniciBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTopPacijenti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvTopPacijenti;
        private System.Windows.Forms.BindingSource KorisniciBindingSource;
        private System.Windows.Forms.BindingSource bsTopPacijenti;
    }
}