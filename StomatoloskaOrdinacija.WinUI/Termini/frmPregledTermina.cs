using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StomatoloskaOrdinacija.Model.Requests;

namespace StomatoloskaOrdinacija.WinUI.Termini
{
    public partial class frmPregledTermina : Form
    {
        private readonly APIService _serviceTermin = new APIService("Termin");
        private readonly APIService odbijTermin = new APIService("Termin/odbij");
        private readonly APIService prihvatiTermin = new APIService("Termin/prihvati");
        public frmPregledTermina()
        {
            InitializeComponent();
        }

        private async void frmPregledTermina_Load(object sender, EventArgs e)
        {
            var sviTermini = await _serviceTermin.GetAll<List<Model.Termin>>(null);

            dgvTermini.AutoGenerateColumns = false;
            dgvTermini.DataSource = sviTermini;
            dgvTermini.Columns[2].DefaultCellStyle.Format = "F";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var requestSearch = cbNacekanju.Checked;
            TerminSearchRequest termin = new TerminSearchRequest
            {
                IsNaCekanju = requestSearch
            };
            var sviTermini = await _serviceTermin.GetAll<List<Model.Termin>>(termin);

            dgvTermini.AutoGenerateColumns = false;
            dgvTermini.DataSource = sviTermini;
            dgvTermini.Columns[2].DefaultCellStyle.Format = "F";
        }

        private void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private async void btnOdobri_Click(object sender, EventArgs e)
        {
            var id = dgvTermini.SelectedRows[0].Cells[0].Value;
            await prihvatiTermin.Update<object>(id, new TerminSearchRequest());

            var requestSearch = cbNacekanju.Checked;
            TerminSearchRequest termin = new TerminSearchRequest
            {
                IsNaCekanju = requestSearch
            };
            var sviTermini = await _serviceTermin.GetAll<List<Model.Termin>>(termin);

            dgvTermini.AutoGenerateColumns = false;
            dgvTermini.DataSource = sviTermini;
            dgvTermini.Columns[2].DefaultCellStyle.Format = "F";
        }

        private async void btnOdbij_Click(object sender, EventArgs e)
        {
            var id = dgvTermini.SelectedRows[0].Cells[0].Value;
            await odbijTermin.Update<object>(id, new TerminSearchRequest());

            var requestSearch = cbNacekanju.Checked;
            TerminSearchRequest termin = new TerminSearchRequest
            {
                IsNaCekanju = requestSearch
            };
            var sviTermini = await _serviceTermin.GetAll<List<Model.Termin>>(termin);

            dgvTermini.AutoGenerateColumns = false;
            dgvTermini.DataSource = sviTermini;
            dgvTermini.Columns[2].DefaultCellStyle.Format = "F";
        }
    }
}
