using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Flurl;
using StomatoloskaOrdinacija.Model.Requests;

namespace StomatoloskaOrdinacija.WinUI.Korisnici
{
    public partial class frmKorisnicics : Form
    {
        APIService _korisniciService = new APIService("Korisnici");
        public frmKorisnicics()
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

            var list = await _korisniciService.GetAll<IList<Model.Korisnici>>(searchRequest);
            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = list;
        }

        private void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKorisnici_DoubleClick(object sender, EventArgs e)
        {
            if (APIService.Permisije == 1)
            {
                var id = dgvKorisnici.SelectedRows[0].Cells[0].Value;
                int.TryParse(id.ToString(), out int convertKorisnici);
                frmKorisniciDetalji frm = new frmKorisniciDetalji(convertKorisnici);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Ova funkcija je za administratora samo, ako želite izmjeniti podatke pacijenta, morate otići na tab namjenjen za pacijente!", "Autorizacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            if (APIService.Permisije == 1)
            {
                var id = dgvKorisnici.SelectedRows[0].Cells[0].Value;
                int.TryParse(id.ToString(), out int convertDetalji);
                frmKorisniciDetalji frm = new frmKorisniciDetalji(convertDetalji);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Ova funkcija je za administratora samo, ako želite izmjeniti podatke pacijenta, morate otići na tab namjenjen za pacijente!", "Autorizacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnIzbrisi_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDodajNovog_Click(object sender, EventArgs e)
        {
            if (APIService.Permisije == 1)
            {
                frmKorisniciDetalji frm = new frmKorisniciDetalji();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Ova funkcija je za administratora samo, ako želite dodati novog pacijenta, morate otići na tab namjenjen za pacijente!", "Autorizacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }

        private async void frmKorisnicics_Load(object sender, EventArgs e)
        {
            var list = await _korisniciService.GetAll<IList<Model.Korisnici>>(null);
            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = list;
        }
    }
}
