namespace StomatoloskaOrdinacija.WinUI.Reporti
{
    partial class reportViewerUslugePoZaradi
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
            this.UslugaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvUsluge = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bsUsluge = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UslugaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsluge)).BeginInit();
            this.SuspendLayout();
            // 
            // UslugaBindingSource
            // 
            this.UslugaBindingSource.DataSource = typeof(StomatoloskaOrdinacija.Model.Usluga);
            // 
            // rpvUsluge
            // 
            this.rpvUsluge.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsUslugePoZaradi";
            reportDataSource1.Value = this.bsUsluge;
            this.rpvUsluge.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvUsluge.LocalReport.ReportEmbeddedResource = "StomatoloskaOrdinacija.WinUI.Reporti.rptUslugePoZaradi.rdlc";
            this.rpvUsluge.Location = new System.Drawing.Point(0, 0);
            this.rpvUsluge.Name = "rpvUsluge";
            this.rpvUsluge.ServerReport.BearerToken = null;
            this.rpvUsluge.Size = new System.Drawing.Size(662, 525);
            this.rpvUsluge.TabIndex = 0;
            // 
            // reportViewerUslugePoZaradi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 525);
            this.Controls.Add(this.rpvUsluge);
            this.Name = "reportViewerUslugePoZaradi";
            this.Text = "reportViewerUslugePoZaradi";
            this.Load += new System.EventHandler(this.reportViewerUslugePoZaradi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UslugaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsluge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvUsluge;
        private System.Windows.Forms.BindingSource UslugaBindingSource;
        private System.Windows.Forms.BindingSource bsUsluge;
    }
}