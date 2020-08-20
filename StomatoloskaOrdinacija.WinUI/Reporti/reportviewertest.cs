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
    public partial class reportviewertest : Form
    {
        private readonly APIService _service = new APIService("Materijali");
        public reportviewertest()
        {
            InitializeComponent();
        }

        private async void reportviewertest_Load(object sender, EventArgs e)
        {
            var temp = await _service.GetAll<List<Model.Materijali>>();
            

            bsProizvodi.DataSource = temp;
            ReportDataSource rds = new ReportDataSource("dsTop10Proizvoda", bsProizvodi);
            this.rpvProizvodi.LocalReport.DataSources.Add(rds);
            this.rpvProizvodi.RefreshReport();
        }
    }
}
