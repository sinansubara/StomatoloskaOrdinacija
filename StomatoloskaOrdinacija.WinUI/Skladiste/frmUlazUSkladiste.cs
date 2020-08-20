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
using System.Text.RegularExpressions;

namespace StomatoloskaOrdinacija.WinUI.Skladiste
{
    public partial class frmUlazUSkladiste : Form
    {
        private readonly APIService _serviceKorisnici = new APIService("Korisnici");
        private readonly APIService _serviceUlazUSkladiste = new APIService("UlazUSkladiste");
        public frmUlazUSkladiste()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var ulaz = new UlazUSkladisteInsertRequest
                {
                    KorisnikId = APIService.KorisnikId,
                    BrojFakture = txtBrojFakture.Text,
                    IznosRacuna = decimal.Parse(txtIznosRacuna.Text)
                };
                var insertulaz = await _serviceUlazUSkladiste.Insert<Model.UlazUSkladiste>(ulaz);

                APIService.UlazUSkladisteId = insertulaz.UlazUSkladisteID;
                this.Hide();
                frmSkladisteDetalji frm = new frmSkladisteDetalji();

                frm.Show();
            }
        }

        private void txtBrojFakture_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrojFakture.Text))
            {
                errorProvider1.SetError(txtBrojFakture, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else if(txtBrojFakture.Text.Length >= 50)
            {
                errorProvider1.SetError(txtBrojFakture, "Broj fakture ne moze biti veci od 50 karaktera!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBrojFakture, null);
            }
        }

        private void txtIznosRacuna_Validating(object sender, CancelEventArgs e)
        {
            string pattern = "^[0-9]+([.][0-9]+)?$";//regex za decimalne brojeve gdje prihvata sa zarezom i tackom
            if (string.IsNullOrWhiteSpace(txtIznosRacuna.Text))
            {
                errorProvider1.SetError(txtIznosRacuna, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtIznosRacuna.Text, pattern))
            {
                errorProvider1.SetError(txtIznosRacuna, "Niste unijeli ispravan decimalni broj za iznos racuna!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtIznosRacuna, null);
            }
        }
    }
}
