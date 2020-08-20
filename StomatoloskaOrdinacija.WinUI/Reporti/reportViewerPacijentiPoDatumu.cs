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
    public partial class reportViewerPacijentiPoDatumu : Form
    {
        private readonly APIService _serviceKorisnici = new APIService("Korisnici/getalldatumoddo");
        public reportViewerPacijentiPoDatumu()
        {
            InitializeComponent();
        }

        private async void reportViewerPacijentiPoDatumu_Load(object sender, EventArgs e)
        {
            dtpDatumDo.Value = DateTime.Now;
            //treba uzet datum sa reporta
            var temp = await _serviceKorisnici.GetAll<List<Model.Korisnici>>(new KorisniciSearchRequest
            {
                OD = dtpDatumOd.Value,
                DO = dtpDatumDo.Value
            });
            var datumOdTemp = dtpDatumOd.Value.ToString("dd.MM.yyyy");
            var datumDoTemp = dtpDatumDo.Value.ToString("dd.MM.yyyy");
            bsPacijenti.DataSource = temp;
            ReportDataSource rds = new ReportDataSource("dsPacijentiPoDatumu", bsPacijenti);
            this.rpvPacijenti.LocalReport.DataSources.Add(rds);
            this.rpvPacijenti.LocalReport.SetParameters(new ReportParameter("DatumOd", datumOdTemp));
            this.rpvPacijenti.LocalReport.SetParameters(new ReportParameter("DatumDo", datumDoTemp));
            this.rpvPacijenti.RefreshReport();
        }
        private async Task LoadData()
        {
            if (dtpDatumOd.Value > dtpDatumDo.Value)
            {
                var temp = dtpDatumDo.Value;
                dtpDatumDo.Value = dtpDatumOd.Value;
                dtpDatumOd.Value = temp;
            }
            var result = await _serviceKorisnici.GetAll<List<Model.Korisnici>>(new KorisniciSearchRequest
            {
                OD = dtpDatumOd.Value,
                DO = dtpDatumDo.Value
            });
            var datumOdTemp = dtpDatumOd.Value.ToString("dd.MM.yyyy");
            var datumDoTemp = dtpDatumDo.Value.ToString("dd.MM.yyyy");
            if (result != null)
            {
                
                bsPacijenti.DataSource = result;
                ReportDataSource rds = new ReportDataSource("dsPacijentiPoDatumu", bsPacijenti);
                this.rpvPacijenti.LocalReport.DataSources.Add(rds);
                this.rpvPacijenti.LocalReport.SetParameters(new ReportParameter("DatumOd", datumOdTemp));
                this.rpvPacijenti.LocalReport.SetParameters(new ReportParameter("DatumDo", datumDoTemp));
                this.rpvPacijenti.RefreshReport();
            }
            else
            {
                bsPacijenti.DataSource = null;
                ReportDataSource rds = new ReportDataSource("dsPacijentiPoDatumu", bsPacijenti);
                this.rpvPacijenti.LocalReport.DataSources.Add(rds);
                this.rpvPacijenti.LocalReport.SetParameters(new ReportParameter("DatumOd", datumOdTemp));
                this.rpvPacijenti.LocalReport.SetParameters(new ReportParameter("DatumDo", datumDoTemp));
                this.rpvPacijenti.RefreshReport();
            }
            
        }
        private void bsPacijenti_CurrentChanged(object sender, EventArgs e)
        {

        }

        private async void dtpDatumOd_ValueChanged(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void dtpDatumDo_ValueChanged(object sender, EventArgs e)
        {
            await LoadData();
        }
    }
}
