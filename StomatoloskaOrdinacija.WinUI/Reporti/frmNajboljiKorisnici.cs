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

namespace StomatoloskaOrdinacija.WinUI.Reporti
{
    public partial class frmNajboljiKorisnici : Form
    {
        private readonly APIService _serviceKorisnici = new APIService("Korisnici/najboljistomatolog");
        private readonly APIService _serviceOsoblje = new APIService("Korisnici/najboljeosoblje");
        private readonly APIService _serviceparcijent = new APIService("Korisnici/najboljipacijent");
        public frmNajboljiKorisnici()
        {
            InitializeComponent();
        }

        private async void frmNajboljiKorisnici_Load(object sender, EventArgs e)
        {
            await LoadNajboljegStomatologa();
            await LoadNajboljeOsoblje();
            await LoadNajboljegPacijenta();
        }
        private async Task LoadNajboljegStomatologa()
        {
            var result = await _serviceKorisnici.Insert<Model.Korisnici>(new KorisniciSearchRequest());
            if (result != null)
            {
                txtNajboljiStomatolog.Text = result.Ime + " "+ result.Prezime;
                txtObavljenoPregleda.Text = result.obavljenoPregleda.ToString();
            }
            
        }
        private async Task LoadNajboljeOsoblje()
        {
            var result = await _serviceOsoblje.Insert<Model.Korisnici>(new KorisniciSearchRequest());
            if (result != null)
            {
                txtNajboljeOsoblje.Text = result.Ime + " "+ result.Prezime;
                txtObavljenihEvidencija.Text = result.obavljenoPregleda.ToString();
            }
            
        }
        private async Task LoadNajboljegPacijenta()
        {
            var result = await _serviceparcijent.Insert<Model.Korisnici>(new KorisniciSearchRequest());
            if (result != null)
            {
                txtNajboljiPacijent.Text = result.Ime + " "+ result.Prezime;
                txtNovcaUtrošeno.Text = result.obavljenoPregleda.ToString();
            }
            
        }
    }
}
