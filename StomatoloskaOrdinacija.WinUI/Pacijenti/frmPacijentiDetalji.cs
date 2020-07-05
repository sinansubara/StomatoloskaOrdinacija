using StomatoloskaOrdinacija.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StomatoloskaOrdinacija.WinUI.Pacijenti
{
    public partial class frmPacijentiDetalji : Form
    {
        private readonly APIService _service = new APIService("Korisnici/pacijenti");
        private readonly APIService _serviceRegistracija = new APIService("Korisnici/registracija");
        private readonly APIService _serviceGradovi = new APIService("Grad");
        private int? _id = null;
        public frmPacijentiDetalji(int? korisnikId = null)
        {
            InitializeComponent();
            _id = korisnikId;
        }

        private async Task LoadGradove()
        {
            var result = await _serviceGradovi.GetAll<List<Model.Grad>>(null);
            cbGrad.DataSource = result;
            cbGrad.DisplayMember = "Naziv";
            cbGrad.ValueMember = "GradId";
        }
        private void LoadSpolove()
        {
            cbSpol.Items.Add("Muško");
            cbSpol.Items.Add("Žensko");
            cbSpol.SelectedIndex = 0;
        }


        private async void frmPacijentiDetalji_Load(object sender, EventArgs e)
        {
            await LoadGradove();
            LoadSpolove();

            if (_id.HasValue)
            {
                var korisnik = await _service.GetById<Model.KorisnikPacijent>(_id);
                txtIme.Text = korisnik.Ime;
                txtPrezime.Text = korisnik.Prezime;
                txtAdresa.Text = korisnik.Adresa;
                txtEmail.Text = korisnik.Email;
                txtJMBG.Text = korisnik.JMBG;
                txtKorisnickoIme.Text = korisnik.KorisnickoIme;
                txtMobitel.Text = korisnik.Mobitel;
                dtpDatumRodjenja.Value = korisnik.DatumRodjenja;
                cbStatus.Checked = korisnik.Status;
                cbGrad.SelectedValue = korisnik.GradId;
                cbSpol.SelectedValue = korisnik.Spol;
                cbAlergijeNaLijekove.Checked = korisnik.AlergijaNaLijek;
                cbAparatic.Checked = korisnik.Aparatic;
                cbNavlake.Checked = korisnik.Navlake;
                cbProteza.Checked = korisnik.Proteza;
                cbTerapija.Checked = korisnik.Terapija;
                pcbSlika.Image = GetImage(korisnik.Slika);
            }
            else
            {
                var noimgpath = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
                noimgpath = noimgpath + "\\no_image.jpeg";


                var file = File.ReadAllBytes(noimgpath);
                
                insertRequest.Slika = file;
                
                Image image = Image.FromFile(noimgpath);
                pcbSlika.Image = image;

            }
        }
        private static Image GetImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return (Image.FromStream(ms));
            }
        }
        private KorisniciPacijentUpdateRequest UpdateRequest = new KorisniciPacijentUpdateRequest();
        private KorisniciRegistracijaRequest insertRequest = new KorisniciRegistracijaRequest();
        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (_id.HasValue)
                {

                    UpdateRequest.Ime = txtIme.Text;
                    UpdateRequest.Prezime = txtPrezime.Text;
                    UpdateRequest.Email = txtEmail.Text;
                    UpdateRequest.JMBG = txtJMBG.Text;
                    UpdateRequest.DatumRodjenja = dtpDatumRodjenja.Value;
                    UpdateRequest.Mobitel = txtMobitel.Text;
                    UpdateRequest.Adresa = txtAdresa.Text;
                    UpdateRequest.Password = txtLozinka.Text;
                    UpdateRequest.PasswordConfirm = txtPotvrdaLozinke.Text;
                    UpdateRequest.Status = cbStatus.Checked;
                    UpdateRequest.GradId = int.Parse(cbGrad.SelectedValue.ToString());
                    UpdateRequest.Aparatic = cbAparatic.Checked;
                    UpdateRequest.AlergijaNaLijek = cbAlergijeNaLijekove.Checked;
                    UpdateRequest.Proteza = cbProteza.Checked;
                    UpdateRequest.Terapija = cbTerapija.Checked;
                    UpdateRequest.Navlake = cbNavlake.Checked;
                    
                    try
                    {
                        var temp = await _service.Update<Model.Pacijent>(_id, UpdateRequest);
                        
                        MessageBox.Show("Uspješno ste uredili pacijenta!");
                        
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Operacija neuspjela! " + exception.Message);
                    }
                    
                }
                else
                {
                    insertRequest.Ime = txtIme.Text;
                    insertRequest.Prezime = txtPrezime.Text;
                    insertRequest.Email = txtEmail.Text;
                    insertRequest.KorisnickoIme = txtKorisnickoIme.Text;
                    insertRequest.JMBG = txtJMBG.Text;
                    insertRequest.DatumRodjenja = dtpDatumRodjenja.Value;
                    insertRequest.Mobitel = txtMobitel.Text;
                    insertRequest.Adresa = txtAdresa.Text;
                    insertRequest.Password = txtLozinka.Text;
                    insertRequest.PasswordPotvrda = txtPotvrdaLozinke.Text;
                    insertRequest.Spol = cbSpol.Text;
                    insertRequest.Status = cbStatus.Checked;
                    insertRequest.GradId = int.Parse(cbGrad.SelectedValue.ToString());
                    insertRequest.Aparatic = cbAparatic.Checked;
                    insertRequest.AlergijaNaLijek = cbAlergijeNaLijekove.Checked;
                    insertRequest.Proteza = cbProteza.Checked;
                    insertRequest.Terapija = cbTerapija.Checked;
                    insertRequest.Navlake = cbNavlake.Checked;
                    
                    try
                    {
                        var temp = await _serviceRegistracija.Insert<Model.Pacijent>(insertRequest);
                        if (temp != null)
                        {
                            MessageBox.Show("Uspješno ste dodali pacijenta!");
                        }
                        else
                        {
                            MessageBox.Show("Dodavanje pacijenta nije uspjelo!");
                        }
                        
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Operacija neuspjela! " + exception.Message);
                    }
                    
                }

                
            }
        }

        private void txtIme_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider1.SetError(txtIme, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider1.SetError(txtPrezime, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPrezime, null);
            }
        }

        private void txtEmail_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtJMBG_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJMBG.Text))
            {
                errorProvider1.SetError(txtJMBG, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtJMBG, null);
            }
        }

        private void txtMobitel_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMobitel.Text))
            {
                errorProvider1.SetError(txtMobitel, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtMobitel, null);
            }
        }

        private void txtAdresa_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdresa.Text))
            {
                errorProvider1.SetError(txtAdresa, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtAdresa, null);
            }
        }

        private void txtKorisnickoIme_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text))
            {
                errorProvider1.SetError(txtKorisnickoIme, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtKorisnickoIme, null);
            }
        }

        private void txtLozinka_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLozinka.Text))
            {
                errorProvider1.SetError(txtLozinka, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtLozinka, null);
            }
        }

        private void txtPotvrdaLozinke_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPotvrdaLozinke.Text))
            {
                errorProvider1.SetError(txtPotvrdaLozinke, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else if(txtLozinka.Text != txtPotvrdaLozinke.Text)
            {
                errorProvider1.SetError(txtPotvrdaLozinke, "Niste unijeli tačno potvrdu lozinke!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPotvrdaLozinke, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;
                var file = File.ReadAllBytes(filename);
                if (_id.HasValue)
                {
                    UpdateRequest.Slika = file;
                }
                else
                {
                    insertRequest.Slika = file;
                }

                txtSlikaInput.Text = filename;
                Image image = Image.FromFile(filename);
                pcbSlika.Image = image;
            }
        }
    }
}
