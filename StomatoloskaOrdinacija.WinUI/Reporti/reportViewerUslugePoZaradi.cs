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
    public partial class reportViewerUslugePoZaradi : Form
    {
        private readonly APIService _service = new APIService("Usluga/uslugepozaradi");
        public reportViewerUslugePoZaradi()
        {
            InitializeComponent();
        }

        private async void reportViewerUslugePoZaradi_Load(object sender, EventArgs e)
        {
            var temp = await _service.GetAll<List<Model.Usluga>>();
            

            bsUsluge.DataSource = temp;
            ReportDataSource rds = new ReportDataSource("dsUslugePoZaradi", bsUsluge);
            this.rpvUsluge.LocalReport.DataSources.Add(rds);
            this.rpvUsluge.RefreshReport();
        }
    }
}
