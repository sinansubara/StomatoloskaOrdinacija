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

namespace StomatoloskaOrdinacija.WinUI.Pacijenti
{
    public partial class frmPacijenti : Form
    {
        APIService _korisniciService = new APIService("Korisnici");
        APIService _pacijentService = new APIService("Korisnici/pacijenti");
        APIService _korisniciPacijentiService = new APIService("Korisnici/korisnikpacijenti");
        public frmPacijenti()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            KorisniciSearchRequest searchRequest = new KorisniciSearchRequest()
            {
                Ime = txtPretragaIme.Text,
                PrezimeFilter = txtPretragaPrezime.Text,
                Email = txtPretragaEmail.Text,
                JMBG = txtPretragaJMBG.Text,
                Grad = txtPretragaGrad.Text,
                Drzava = txtPretragaDrzava.Text
            };

            var list = await _korisniciPacijentiService.GetAll<IList<Model.KorisnikPacijent>>(searchRequest);
            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = list;
        }

        private void dgvKorisnici_DoubleClick(object sender, EventArgs e)
        {
            var id = dgvKorisnici.SelectedRows[0].Cells[0].Value;
            int.TryParse(id.ToString(), out int convertKorisnici);
            frmPacijentiDetalji frm = new frmPacijentiDetalji(convertKorisnici);
            frm.Show();
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            var id = dgvKorisnici.SelectedRows[0].Cells[0].Value;
            int.TryParse(id.ToString(), out int convertKorisnici);
            frmPacijentiDetalji frm = new frmPacijentiDetalji(convertKorisnici);
            frm.Show();
        }

        private void btnDodajNovog_Click(object sender, EventArgs e)
        {
            frmPacijentiDetalji frm = new frmPacijentiDetalji();
            frm.Show();
        }

        private async void frmPacijenti_Load(object sender, EventArgs e)
        {
            var list = await _korisniciPacijentiService.GetAll<IList<Model.KorisnikPacijent>>(null);
            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = list;
        }
    }
}
