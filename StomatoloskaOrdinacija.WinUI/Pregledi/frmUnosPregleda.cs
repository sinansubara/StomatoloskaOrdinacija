using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using StomatoloskaOrdinacija.Model.Requests;

namespace StomatoloskaOrdinacija.WinUI.Pregledi
{
    public partial class frmUnosPregleda : Form
    {
        private readonly APIService _serviceLijek = new APIService("Lijek");
        private readonly APIService _serviceDijagnoza = new APIService("Dijagnoza");
        private readonly APIService _serviceTermin = new APIService("Termin");
        private readonly APIService _serviceSkladiste = new APIService("Skladiste");
        private readonly APIService _serviceKorisnici = new APIService("Korisnici");
        private readonly APIService _servicePregled = new APIService("Pregled");
        private readonly APIService _serviceRacun = new APIService("Racun");

        private int? _id = null;
        public frmUnosPregleda(int? pregledId = null)
        {
            InitializeComponent();
            _id = pregledId;
        }
        private async void frmUnosPregleda_Load(object sender, EventArgs e)
        {
            
            await LoadTermine();
            await LoadDijagnoze();
            await LoadLijekovi();
            await LoadMaterijali();
            if (_id.HasValue)
            {
                
                var pregled = await _servicePregled.GetById<Model.Pregled>(_id);
                txtKolicina.Text = pregled.KolicinaOdabranogMaterijala.ToString();
                txtTrajanje.Text = pregled.TrajanjePregleda.ToString();
                txtNapomenaPregleda.Text = pregled.Napomena;
                cmbDijagnoza.SelectedValue = pregled.DijagnozaId;
                cmbTermin.SelectedValue = pregled.TerminId;
                cmbLijek.SelectedValue = pregled.LijekId;
                cmbMaterijal.SelectedValue = pregled.SkladisteId;

            }
           
        }



        private async Task LoadLijekovi()
        {
            var result = await _serviceLijek.GetAll<List<Model.Lijek>>(null);
            
            cmbLijek.DisplayMember = "Naziv";
            cmbLijek.ValueMember = "LijekId";
            cmbLijek.DataSource = result;
        }

        private async Task LoadDijagnoze()
        {
            var result = await _serviceDijagnoza.GetAll<List<Model.Dijagnoza>>(null);
            
            cmbDijagnoza.DisplayMember = "Naziv";
            cmbDijagnoza.ValueMember = "DijagnozaId";
            cmbDijagnoza.DataSource = result;
        }
        private async Task LoadTermine()
        {
            var result = await _serviceTermin.GetAll<List<Model.Termin>>( new TerminSearchRequest {IsIskoristenRequest = "Ne"});
            
            cmbTermin.DisplayMember = "UslugaIme";
            cmbTermin.ValueMember = "TerminId";
            cmbTermin.DataSource = result;
            txtImeIPrezime.Text = result[0].Pacijent.Korisnici.Ime+ " "+result[0].Pacijent.Korisnici.Prezime;
            txtTerminNapomena.Text = result[0].DatumVrijeme.ToString("F");
            txtRazlogTermina.Text = result[0].Razlog;
        }
        private async Task LoadMaterijali()
        {
            var result = await _serviceSkladiste.GetAll<List<Model.Skladiste>>(null);
            
            cmbMaterijal.DisplayMember = "Naziv";
            cmbMaterijal.ValueMember = "SkladisteId";
            cmbMaterijal.DataSource = result;
            txtStanjeNaSkladistu.Text = result[0].Kolicina.ToString();
        }


        

        private async void cmbTermin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                
            }
            else
            {
                var idObj = cmbTermin.SelectedValue;

                if (int.TryParse(idObj.ToString(), out int id))
                {
                    await LoadPacijenta(id);
                }
            }
            
        }
        private async Task LoadPacijenta(int id)
        {
            var result = await _serviceTermin.GetById<Model.Termin>(id);

            txtImeIPrezime.Text = result.Pacijent.Korisnici.Ime + " " + result.Pacijent.Korisnici.Prezime;
            txtTerminNapomena.Text = result.DatumVrijeme.ToString("F");
            txtRazlogTermina.Text = result.Razlog;
        }

        private async void cmbMaterijal_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbMaterijal.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadStanjaMaterijala(id);
            }
        }
        private async Task LoadStanjaMaterijala(int id)
        {
            var result = await _serviceSkladiste.GetById<Model.Skladiste>(id);
            txtStanjeNaSkladistu.Text = result.Kolicina.ToString();
        }

        private void txtKolicina_Validating(object sender, CancelEventArgs e)
        {
            string pattern = "^[0-9]+([.][0-9]+)?$";
            if (string.IsNullOrWhiteSpace(txtKolicina.Text))
            {
                errorProvider1.SetError(txtKolicina, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtKolicina.Text, pattern))
            {
                errorProvider1.SetError(txtKolicina, "Niste unijeli ispravan decimalni broj za kolicinu!");
                e.Cancel = true;
            }
            else
            {
                var novaKolicina = decimal.Parse(txtKolicina.Text);
                var postojeceStanjeNaSkladistu = decimal.Parse(txtStanjeNaSkladistu.Text);
                if (novaKolicina > postojeceStanjeNaSkladistu)
                {
                    errorProvider1.SetError(txtKolicina, "Unijeli ste više materijala nego što imate na stanju!");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(txtKolicina, null);
                }
            }
        }

        private void txtTrajanje_Validating(object sender, CancelEventArgs e)
        {
            string pattern = "^[0-9]+$";
            if (string.IsNullOrWhiteSpace(txtTrajanje.Text))
            {
                errorProvider1.SetError(txtTrajanje, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtTrajanje.Text, pattern))
            {
                errorProvider1.SetError(txtTrajanje, "Samo cijeli brojevi su dozvoljeni!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtTrajanje, null);
            }
        }

        private void txtNapomenaPregleda_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNapomenaPregleda.Text))
            {
                errorProvider1.SetError(txtNapomenaPregleda, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else if(txtNapomenaPregleda.Text.Length >= 200)
            {
                errorProvider1.SetError(txtNapomenaPregleda, "Napomena za pregled ne moze biti duza od 200 karaktera!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNapomenaPregleda, null);
            }
        }

        private PregledInsertRequest insertRequest = new PregledInsertRequest();
        private PregledInsertRequest UpdateRequest = new PregledInsertRequest();
        private async void txtSnimiPregled_Click(object sender, EventArgs e)
        {
            if (APIService.Permisije == 1 || APIService.Permisije == 2)
            {
               if (this.ValidateChildren())
               {
                   
                   int.TryParse(cmbTermin.SelectedValue.ToString(), out int convertTermin);
                   int.TryParse(cmbDijagnoza.SelectedValue.ToString(), out int convertDijagnoza);
                   int.TryParse(cmbLijek.SelectedValue.ToString(), out int convertLijek);
                   int.TryParse(cmbMaterijal.SelectedValue.ToString(), out int convertMaterijal);
                   int.TryParse(txtTrajanje.Text, out int convertTrajanje);
                   decimal.TryParse(txtKolicina.Text, out decimal convertKolicina);
                  
                   if (_id.HasValue)
                   {
                       UpdateRequest.KorisnikId = APIService.KorisnikId;
                       UpdateRequest.TerminId = convertTermin;
                       UpdateRequest.DijagnozaId = convertDijagnoza;
                       UpdateRequest.LijekId = convertLijek;
                       UpdateRequest.SkladisteId = convertMaterijal;
                       UpdateRequest.KolicinaOdabranogMaterijala = convertKolicina;
                       UpdateRequest.TrajanjePregleda = convertTrajanje;
                       UpdateRequest.Napomena = txtNapomenaPregleda.Text;
                       try
                       {
                           var temp = await _servicePregled.Update<Model.Korisnici>(_id, UpdateRequest);
                           MessageBox.Show("Uspješno ste uredili pregled!");
                       }
                       catch (Exception exception)
                       {
                           MessageBox.Show("Operacija neuspjela! " + exception.Message);
                       }
                   }
                   else
                   {
                       insertRequest.KorisnikId = APIService.KorisnikId;
                       insertRequest.TerminId = convertTermin;
                       insertRequest.DijagnozaId = convertDijagnoza;
                       insertRequest.LijekId = convertLijek;
                       insertRequest.SkladisteId = convertMaterijal;
                       insertRequest.KolicinaOdabranogMaterijala = convertKolicina;
                       insertRequest.TrajanjePregleda = convertTrajanje;
                       insertRequest.Napomena = txtNapomenaPregleda.Text;
                       try
                       {
                           var temp = await _servicePregled.Insert<Model.Pregled>(insertRequest);
                           if (temp != null)
                           {
                               MessageBox.Show("Uspješno ste dodali pregled!");
                               await _serviceRacun.Insert<Model.Racun>(new RacunInsertRequest
                               {
                                   KorisnikId = temp.KorisnikId,
                                   PregledId = temp.PregledId
                               });
                           }
                           else
                           {
                               MessageBox.Show("Dodavanje pregleda nije uspjelo!");
                           }
                       }
                       catch (Exception exception)
                       {
                           MessageBox.Show("Operacija neuspjela! " + exception.Message);
                       }
                   }
               }
            }
            else
            {
                MessageBox.Show("Samo stomatolog moze mjenjati informacije o pregledima pacijenata!", "Autorizacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
