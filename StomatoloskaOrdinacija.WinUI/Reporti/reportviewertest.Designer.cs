namespace StomatoloskaOrdinacija.WinUI.Reporti
{
    partial class reportviewertest
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
            this.bsProizvodi = new System.Windows.Forms.BindingSource(this.components);
            this.rpvProizvodi = new Microsoft.Reporting.WinForms.ReportViewer();
            this.MaterijaliBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsProizvodi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaterijaliBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvProizvodi
            // 
            this.rpvProizvodi.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsTop10Proizvoda";
            reportDataSource1.Value = this.bsProizvodi;
            this.rpvProizvodi.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvProizvodi.LocalReport.ReportEmbeddedResource = "StomatoloskaOrdinacija.WinUI.Reporti.rptTop10Proizvoda.rdlc";
            this.rpvProizvodi.Location = new System.Drawing.Point(0, 0);
            this.rpvProizvodi.Name = "rpvProizvodi";
            this.rpvProizvodi.ServerReport.BearerToken = null;
            this.rpvProizvodi.Size = new System.Drawing.Size(641, 629);
            this.rpvProizvodi.TabIndex = 0;
            // 
            // MaterijaliBindingSource
            // 
            this.MaterijaliBindingSource.DataSource = typeof(StomatoloskaOrdinacija.Model.Materijali);
            // 
            // reportviewertest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 629);
            this.Controls.Add(this.rpvProizvodi);
            this.Name = "reportviewertest";
            this.Text = "reportviewertest";
            this.Load += new System.EventHandler(this.reportviewertest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsProizvodi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaterijaliBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvProizvodi;
        private System.Windows.Forms.BindingSource bsProizvodi;
        private System.Windows.Forms.BindingSource MaterijaliBindingSource;
    }
}