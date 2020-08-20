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

namespace StomatoloskaOrdinacija.WinUI.Reporti
{
    public partial class reportViewerTopPacijenti : Form
    {
        private readonly APIService _service = new APIService("Korisnici/toppacijenti");
        public reportViewerTopPacijenti()
        {
            InitializeComponent();
        }

        private async void reportViewerTopPacijenti_Load(object sender, EventArgs e)
        {
            var temp = await _service.GetAll<IList<Model.Korisnici>>();
            

            bsTopPacijenti.DataSource = temp;
            ReportDataSource rds = new ReportDataSource("dsTopPacijenti", bsTopPacijenti);
            this.rpvTopPacijenti.LocalReport.DataSources.Add(rds);
            this.rpvTopPacijenti.RefreshReport();
            
        }
    }
}
