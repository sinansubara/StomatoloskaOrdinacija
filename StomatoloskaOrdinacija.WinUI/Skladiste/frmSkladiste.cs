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

namespace StomatoloskaOrdinacija.WinUI.Skladiste
{
    public partial class frmSkladiste : Form
    {
        APIService _serviceSkladiste = new APIService("Skladiste");
        public frmSkladiste()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            SkladisteSearchRequest searchRequest = new SkladisteSearchRequest()
            {
                Naziv = txtPretragaNaziv.Text,
                Vrsta = txtPretragaVrsta.Text,
                Proizvodjac = txtPretragaProizvodjac.Text
            };

            var list = await _serviceSkladiste.GetAll<IList<Model.Skladiste>>(searchRequest);
            dgvSkladiste.AutoGenerateColumns = false;
            dgvSkladiste.DataSource = list;
        }

        private void dgvSkladiste_DoubleClick(object sender, EventArgs e)
        {
            var id = dgvSkladiste.SelectedRows[0].Cells[0].Value;
            frmSkladisteDetalji frm = new frmSkladisteDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            var id = dgvSkladiste.SelectedRows[0].Cells[0].Value;
            frmSkladisteDetalji frm = new frmSkladisteDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private void btnDodajNovog_Click(object sender, EventArgs e)
        {
            frmUlazUSkladiste frm = new frmUlazUSkladiste();
            frm.Show();
        }
    }
}
