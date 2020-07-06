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
    public partial class frmDetaljiPregleda : Form
    {
        private readonly APIService _serviceLijek = new APIService("Lijek");
        private readonly APIService _serviceDijagnoza = new APIService("Dijagnoza");
        private readonly APIService _serviceTermin = new APIService("Termin");
        private readonly APIService _serviceSkladiste = new APIService("Skladiste");
        private readonly APIService _serviceKorisnici = new APIService("Korisnici");
        private readonly APIService _servicePregled = new APIService("Pregled");


        private int? _id = null;
        public frmDetaljiPregleda(int? pregledId = null)
        {
            InitializeComponent();
            _id = pregledId;
        }

        private async void frmDetaljiPregleda_Load(object sender, EventArgs e)
        {
           
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
                cmbLijek.SelectedValue = pregled.LijekId;
                cmbMaterijal.SelectedValue = pregled.SkladisteId;
                
                await LoadPacijenta(_id);
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

        private async Task LoadPacijenta(int? id)
        {
            if (id.HasValue)
            {
                //var result = await _serviceTermin.GetById<Model.Termin>(id);
                var result = await _servicePregled.GetById<Model.Pregled>(id);
                txtTermin.Text = result.Termin.Usluga.Naziv;
                txtImeIPrezime.Text = result.Termin.Pacijent.Korisnici.Ime + " " + result.Termin.Pacijent.Korisnici.Prezime;
                txtTerminNapomena.Text = result.Termin.DatumVrijeme.ToString("F");
                txtRazlogTermina.Text = result.Termin.Razlog;
                //txtTermin.Text = result.Usluga.Naziv;
                //txtImeIPrezime.Text = result.Pacijent.Korisnici.Ime + " " + result.Pacijent.Korisnici.Prezime;
                //txtTerminNapomena.Text = result.DatumVrijeme.ToString("F");
                //txtRazlogTermina.Text = result.Razlog;
            }
        }
        private async Task LoadMaterijali()
        {
            var result = await _serviceSkladiste.GetAll<List<Model.Skladiste>>(null);
            
            cmbMaterijal.DisplayMember = "Naziv";
            cmbMaterijal.ValueMember = "SkladisteId";
            cmbMaterijal.DataSource = result;
            txtStanjeNaSkladistu.Text = result[0].Kolicina.ToString();
        }
        private async void cmbMaterijal_SelectedIndexChanged_1(object sender, EventArgs e)
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
            if (string.IsNullOrWhiteSpace(txtKolicina.Text))
            {
                errorProvider1.SetError(txtKolicina, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else if(decimal.Parse(txtKolicina.Text) > decimal.Parse(txtStanjeNaSkladistu.Text))
            {
                errorProvider1.SetError(txtKolicina, "Unijeli ste više materijala nego što imate na stanju!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtKolicina, null);
            }
        }

        private void txtTrajanje_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTrajanje.Text))
            {
                errorProvider1.SetError(txtTrajanje, Properties.Resources.Validation_ObaveznoPolje);
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
            else
            {
                errorProvider1.SetError(txtNapomenaPregleda, null);
            }
        }

        private PregledInsertRequest UpdateRequest = new PregledInsertRequest();

        private async void txtSnimiPregled_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var korisnici = await _serviceKorisnici.GetAll<List<Model.Korisnici>>(null);
                int.TryParse(cmbDijagnoza.SelectedValue.ToString(), out int convertDijagnoza);
                int.TryParse(cmbLijek.SelectedValue.ToString(), out int convertLijek);
                int.TryParse(cmbMaterijal.SelectedValue.ToString(), out int convertMaterijal);
                int.TryParse(txtTrajanje.Text, out int convertTrajanje);
                decimal.TryParse(txtKolicina.Text, out decimal convertKolicina);
                foreach (var korisnik in korisnici)
                {
                    if (korisnik.KorisnickoIme == APIService.Username)
                    {
                        APIService.KorisnikId = korisnik.KorisnikId;
                    }
                }
                if (_id.HasValue)
                {
                    UpdateRequest.KorisnikId = APIService.KorisnikId;
                    UpdateRequest.TerminId = int.Parse(_id.ToString());
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
            }
        }
    }
}
