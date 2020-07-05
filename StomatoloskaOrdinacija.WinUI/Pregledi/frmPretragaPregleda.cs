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

namespace StomatoloskaOrdinacija.WinUI.Pregledi
{
    public partial class frmPretragaPregleda : Form
    {

        private readonly APIService _servicePregled = new APIService("Pregled");
        private readonly APIService _serviceDijagnoza = new APIService("Dijagnoza");
        private readonly APIService _serviceTermin = new APIService("Termin");
        private readonly APIService _serviceSkladiste = new APIService("Skladiste");
        private readonly APIService _serviceKorisnici = new APIService("Korisnici");

        public frmPretragaPregleda(int? pregledId = null)
        {
            InitializeComponent();
        }

        private void btnDodajNovog_Click(object sender, EventArgs e)
        {
            frmUnosPregleda frm = new frmUnosPregleda();
            frm.Show();
        }

        private async void frmPretragaPregleda_Load(object sender, EventArgs e)
        {
            await LoadOsoblje();
            await LoadTermine();
            await LoadMaterijale();
        }

        private async Task LoadOsoblje()
        {
            var result = await _serviceKorisnici.GetAll<List<Model.Korisnici>>(null);
            var newResult = new List<Model.Korisnici>();
            foreach (var res in result)
            {
                if (res.UlogaId != 4)
                {
                    newResult.Add(res);
                }
            }
            cmbKorisnik.DataSource = newResult;
            cmbKorisnik.DisplayMember = "Prezime";
            cmbKorisnik.ValueMember = "KorisnikId";
        }
        private async Task LoadTermine()
        {
            var result = await _serviceTermin.GetAll<List<Model.Termin>>(null);
            cmbTermin.DataSource = result;
            cmbTermin.DisplayMember = "DatumVrijeme";
            cmbTermin.ValueMember = "TerminId";
            cmbTermin.FormatString = "F";
        }
        private async Task LoadMaterijale()
        {
            var result = await _serviceSkladiste.GetAll<List<Model.Skladiste>>(null);
            cmbMaterijal.DataSource = result;
            cmbMaterijal.DisplayMember = "Naziv";
            cmbMaterijal.ValueMember = "SkladisteId";
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            try
            {
                PregledSearchRequest searchRequest = new PregledSearchRequest
                {
                    KorisnikId = int.Parse(cmbKorisnik.SelectedValue.ToString()),
                    Napomena = txtNapomena.Text,
                    SkladisteId = int.Parse(cmbMaterijal.SelectedValue.ToString()),
                    TerminId = int.Parse(cmbTermin.SelectedValue.ToString())
                };
                var list = await _servicePregled.GetAll<IList<Model.Pregled>>(searchRequest);
                dgvKorisnici.AutoGenerateColumns = false;
                dgvKorisnici.DataSource = list;
            }
            catch (Exception exception)
            {
                PregledSearchRequest sear = new PregledSearchRequest
                {
                    KorisnikId = 0,
                    Napomena = "",
                    SkladisteId = 0,
                    TerminId = 0
                };
                var list2 = await _servicePregled.GetAll<IList<Model.Pregled>>(sear);
                dgvKorisnici.AutoGenerateColumns = false;
                dgvKorisnici.DataSource = list2;
            }


        }

        private void dgvKorisnici_DoubleClick(object sender, EventArgs e)
        {
            var id = dgvKorisnici.SelectedRows[0].Cells[0].Value;
            frmUnosPregleda frm = new frmUnosPregleda(int.Parse(id.ToString()));
            frm.Show();
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            var id = dgvKorisnici.SelectedRows[0].Cells[0].Value;
            frmUnosPregleda frm = new frmUnosPregleda(int.Parse(id.ToString()));
            frm.Show();
        }

        private async void btnSviPregleda_Click(object sender, EventArgs e)
        {
            PregledSearchRequest sear = new PregledSearchRequest
            {
                KorisnikId = 0,
                Napomena = "",
                SkladisteId = 0,
                TerminId = 0
            };
            var list2 = await _servicePregled.GetAll<IList<Model.Pregled>>(sear);
            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = list2;
        }
    }
}
