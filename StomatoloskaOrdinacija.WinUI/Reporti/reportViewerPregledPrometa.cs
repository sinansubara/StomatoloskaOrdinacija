using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using StomatoloskaOrdinacija.Model.Requests;

namespace StomatoloskaOrdinacija.WinUI.Reporti
{
    public partial class reportViewerPregledPrometa : Form
    {
        private readonly APIService _servicePregledi = new APIService("MedicinskiKarton/getallbydatum");
        public reportViewerPregledPrometa()
        {
            InitializeComponent();
        }

        private async void reportViewerPregledPrometa_Load(object sender, EventArgs e)
        {

            //dtpDatum.Value = DateTime.Now;
            //treba uzet datum sa reporta
            var temp = await _servicePregledi.GetAll<List<Model.MedicinskiKarton>>(new MedicinskiKartonSearchRequest
            {
                DatumPretrageReport = dtpDatum.Value
            });
            var datumTemp = dtpDatum.Value.ToString("dd.MM.yyyy");
            bsPromet.DataSource = temp;
            ReportDataSource rds = new ReportDataSource("DataSet1", bsPromet);
            this.rpvPromet.LocalReport.DataSources.Add(rds);
            this.rpvPromet.LocalReport.SetParameters(new ReportParameter("DatumPrometa", datumTemp));
            this.rpvPromet.RefreshReport();
        }

        private async Task LoadData()
        {
            var result = await _servicePregledi.GetAll<List<Model.MedicinskiKarton>>(new MedicinskiKartonSearchRequest
            {
                DatumPretrageReport = dtpDatum.Value
            });
            var datumTemp = dtpDatum.Value.ToString("dd.MM.yyyy");
            if (result != null)
            {
                
                bsPromet.DataSource = result;
                ReportDataSource rds = new ReportDataSource("DataSet1", bsPromet);
                this.rpvPromet.LocalReport.DataSources.Add(rds);
                this.rpvPromet.LocalReport.SetParameters(new ReportParameter("DatumPrometa", datumTemp));
                this.rpvPromet.RefreshReport();
            }
            else
            {
                bsPromet.DataSource = result;
                ReportDataSource rds = new ReportDataSource("DataSet1", bsPromet);
                this.rpvPromet.LocalReport.DataSources.Add(rds);
                this.rpvPromet.LocalReport.SetParameters(new ReportParameter("DatumPrometa", datumTemp));
                this.rpvPromet.RefreshReport();
            }
            
        }

        private async void dtpDatum_ValueChanged(object sender, EventArgs e)
        {
            await LoadData();
        }
    }
}
