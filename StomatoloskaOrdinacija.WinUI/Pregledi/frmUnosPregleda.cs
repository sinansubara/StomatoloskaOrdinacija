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
    public partial class frmUnosPregleda : Form
    {
        private readonly APIService _serviceLijek = new APIService("Lijek");
        private readonly APIService _serviceDijagnoza = new APIService("Dijagnoza");
        private readonly APIService _serviceTermin = new APIService("Termin");
        private readonly APIService _serviceSkladiste = new APIService("Skladiste");
        private readonly APIService _serviceKorisnici = new APIService("Korisnici");
        private readonly APIService _servicePregled = new APIService("Pregled");
        
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
            cmbLijek.DataSource = result;
            cmbLijek.DisplayMember = "Naziv";
            cmbLijek.ValueMember = "LijekId";
        }

        private async Task LoadDijagnoze()
        {
            var result = await _serviceDijagnoza.GetAll<List<Model.Dijagnoza>>(null);
            cmbDijagnoza.DataSource = result;
            cmbDijagnoza.DisplayMember = "Naziv";
            cmbDijagnoza.ValueMember = "DijagnozaId";
        }
        private async Task LoadTermine()
        {
            var result = await _serviceTermin.GetAll<List<Model.Termin>>(null);
            cmbTermin.DataSource = result;
            cmbTermin.DisplayMember = "Razlog";
            cmbTermin.ValueMember = "TerminId";
            txtImeIPrezime.Text = result[0].Pacijent.Korisnici.Ime+ " "+result[0].Pacijent.Korisnici.Prezime;
            txtTerminNapomena.Text = result[0].DatumVrijeme.ToString("F");
        }
        private async Task LoadMaterijali()
        {
            var result = await _serviceSkladiste.GetAll<List<Model.Skladiste>>(null);
            cmbMaterijal.DataSource = result;
            cmbMaterijal.DisplayMember = "Naziv";
            cmbMaterijal.ValueMember = "SkladisteId";
            txtStanjeNaSkladistu.Text = result[0].Kolicina.ToString();
        }


        

        private async void cmbTermin_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbTermin.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadPacijenta(id);
            }
        }
        private async Task LoadPacijenta(int id)
        {
            var result = await _serviceTermin.GetById<Model.Termin>(id);
            txtImeIPrezime.Text = result.Pacijent.Korisnici.Ime + " " + result.Pacijent.Korisnici.Prezime;
            txtTerminNapomena.Text = result.DatumVrijeme.ToString("F");
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

        private PregledInsertRequest insertRequest = new PregledInsertRequest();
        private PregledInsertRequest UpdateRequest = new PregledInsertRequest();
        private async void txtSnimiPregled_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var korisnici = await _serviceKorisnici.GetAll<List<Model.Korisnici>>(null);

                foreach (var korisnik in korisnici)
                {
                    if (korisnik.KorisnickoIme == APIService.Username)
                    {
                        APIService.KorisnikId = korisnik.KorisnikId;
                    }
                }
                if (_id.HasValue)
                {
                    insertRequest.KorisnikId = APIService.KorisnikId;
                    insertRequest.TerminId = int.Parse(cmbTermin.SelectedValue.ToString());
                    insertRequest.DijagnozaId = int.Parse(cmbDijagnoza.SelectedValue.ToString());
                    insertRequest.LijekId = int.Parse(cmbLijek.SelectedValue.ToString());
                    insertRequest.SkladisteId = int.Parse(cmbMaterijal.SelectedValue.ToString());
                    insertRequest.KolicinaOdabranogMaterijala = decimal.Parse(txtKolicina.Text);
                    insertRequest.TrajanjePregleda = int.Parse(txtTrajanje.Text);
                    insertRequest.Napomena = txtNapomenaPregleda.Text;

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
                    insertRequest.TerminId = int.Parse(cmbTermin.SelectedValue.ToString());
                    insertRequest.DijagnozaId = int.Parse(cmbDijagnoza.SelectedValue.ToString());
                    insertRequest.LijekId = int.Parse(cmbLijek.SelectedValue.ToString());
                    insertRequest.SkladisteId = int.Parse(cmbMaterijal.SelectedValue.ToString());
                    insertRequest.KolicinaOdabranogMaterijala = decimal.Parse(txtKolicina.Text);
                    insertRequest.TrajanjePregleda = int.Parse(txtTrajanje.Text);
                    insertRequest.Napomena = txtNapomenaPregleda.Text;
                    
                    try
                    {
                        var temp = await _servicePregled.Insert<Model.Pregled>(insertRequest);
                        if (temp != null)
                        {
                            MessageBox.Show("Uspješno ste dodali pregled!");
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
    }
}
