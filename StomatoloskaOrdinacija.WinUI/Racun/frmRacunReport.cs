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

namespace StomatoloskaOrdinacija.WinUI.Racun
{
    public partial class frmRacunReport : Form
    {
        private readonly APIService _service = new APIService("Racun");
        private int _id;
        public frmRacunReport(int racunId)
        {
            InitializeComponent();
            _id = racunId;
        }

        private async void frmRacunReport_Load(object sender, EventArgs e)
        {
            var temp = await _service.GetAll<List<Model.Racun>>(new RacunSearchRequest{ RacunId = _id });
            
            bsRacun.DataSource = temp;
            ReportDataSource rds = new ReportDataSource("dsRacunIzdavanje", bsRacun);
            this.rpvRacun.LocalReport.DataSources.Add(rds);
            this.rpvRacun.LocalReport.SetParameters(new ReportParameter("Doktor", temp[0].RacunDoktorIme));
            this.rpvRacun.LocalReport.SetParameters(new ReportParameter("Pacijent", temp[0].PregledPacijentIme));
            this.rpvRacun.RefreshReport();
        }
    }
}
