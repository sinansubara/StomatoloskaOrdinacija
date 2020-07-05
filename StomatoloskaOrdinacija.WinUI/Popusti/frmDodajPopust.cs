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

namespace StomatoloskaOrdinacija.WinUI.Popusti
{
    public partial class frmDodajPopust : Form
    {
        private readonly APIService _servicePopust = new APIService("Popust");
        private readonly APIService _serviceUsluge = new APIService("Usluga");
        private readonly APIService _serviceKorisnici = new APIService("Korisnici");
        public frmDodajPopust()
        {
            InitializeComponent();
        }

        private void dgvTermini_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void frmDodajPopust_Load(object sender, EventArgs e)
        {
            var request = await _servicePopust.GetAll<List<Model.Popust>>(null);
            await LoadUsluge();
            dgvPopust.AutoGenerateColumns = false;
            dgvPopust.DataSource = request;
            dgvPopust.Columns[2].DefaultCellStyle.Format = "F";
        }

        private async void cmbUsluga_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var idObj = cmbUsluga.SelectedValue;

            //var result = await _serviceUsluge.GetAll<List<Model.Usluga>>(new PopustSearchRequest
            //{
            //    UslugaId = int.Parse(idObj.ToString())
            //});
            //cmbUsluga.DataSource = result;
            //cmbUsluga.DisplayMember = "Naziv";
            //cmbUsluga.ValueMember = "UslugaId";
        }
        private async Task LoadUsluge()
        {
            var result = await _serviceUsluge.GetAll<List<Model.Usluga>>(null);
            cmbUsluga.DataSource = result;
            cmbUsluga.DisplayMember = "Naziv";
            cmbUsluga.ValueMember = "UslugaId";
        }

        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            var korisnici = await _serviceKorisnici.GetAll<List<Model.Korisnici>>(null);

            foreach (var korisnik in korisnici)
            {
                if (korisnik.KorisnickoIme == APIService.Username)
                {
                    APIService.KorisnikId = korisnik.KorisnikId;
                }
            }

            PopustInsertRequest request = new PopustInsertRequest
            {
                KorisnikId = APIService.KorisnikId,
                PopustDoDatuma = dtpDO.Value,
                PopustOdDatuma = dtpOD.Value,
                UslugaId = int.Parse(cmbUsluga.SelectedValue.ToString()),
                VrijednostPopusta = int.Parse(txtVrijednostPopusta.Text)
            };
            await _servicePopust.Insert<Model.Popust>(request);
            MessageBox.Show("Uspješno ste dodali popust!");
        }

        private void txtVrijednostPopusta_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVrijednostPopusta.Text))
            {
                errorProvider1.SetError(txtVrijednostPopusta, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtVrijednostPopusta, null);
            }
        }
    }
}
