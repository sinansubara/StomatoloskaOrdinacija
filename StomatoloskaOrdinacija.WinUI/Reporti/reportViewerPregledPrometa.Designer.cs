namespace StomatoloskaOrdinacija.WinUI.Reporti
{
    partial class reportViewerPregledPrometa
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
            this.rpvPromet = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bsPromet = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsPromet)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvPromet
            // 
            this.rpvPromet.LocalReport.ReportEmbeddedResource = "StomatoloskaOrdinacija.WinUI.Reporti.rptPregledPrometa.rdlc";
            this.rpvPromet.Location = new System.Drawing.Point(-1, 78);
            this.rpvPromet.Name = "rpvPromet";
            this.rpvPromet.ServerReport.BearerToken = null;
            this.rpvPromet.Size = new System.Drawing.Size(713, 459);
            this.rpvPromet.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(153, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "PREGLED PROMETA PACIJENATA";
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(257, 36);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpDatum.TabIndex = 2;
            this.dtpDatum.ValueChanged += new System.EventHandler(this.dtpDatum_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Datum pretrage";
            // 
            // reportViewerPregledPrometa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 534);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rpvPromet);
            this.Name = "reportViewerPregledPrometa";
            this.Text = "reportViewerPregledPrometa";
            this.Load += new System.EventHandler(this.reportViewerPregledPrometa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsPromet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPromet;
        private System.Windows.Forms.BindingSource bsPromet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.Label label2;
    }
}