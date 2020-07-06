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
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;

namespace StomatoloskaOrdinacija.WinUI.Korisnici
{
    public partial class frmKorisniciDetalji : Form
    {
        private readonly APIService _service = new APIService("Korisnici");
        private readonly APIService _serviceGradovi = new APIService("Grad");
        private readonly APIService _serviceUloge = new APIService("Uloge");
        private int? _id = null;
        public frmKorisniciDetalji(int? korisnikId = null)
        {
            InitializeComponent();
            _id = korisnikId;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private static Image GetImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return (Image.FromStream(ms));
            }
        }
        private KorisniciUpdateRequest UpdateRequest = new KorisniciUpdateRequest();
        private KorisniciInsertRequest insertRequest = new KorisniciInsertRequest();
        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                int.TryParse(cbUloga.SelectedValue.ToString(), out int convertUloga);
                int.TryParse(cbGrad.SelectedValue.ToString(), out int convertGrad);
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
                    UpdateRequest.UlogaId = convertUloga;
                    UpdateRequest.GradId = convertGrad;
                    
                    try
                    {
                        var temp = await _service.Update<Model.Korisnici>(_id, UpdateRequest);
                        if (temp.KorisnickoIme == APIService.Username)
                        {
                            APIService.Password = UpdateRequest.Password;
                            APIService.Permisije = UpdateRequest.UlogaId;
                        }

                        MessageBox.Show("Uspješno ste uredili korisnika!");
                        
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
                    insertRequest.UlogaId = convertUloga;
                    insertRequest.GradId = convertGrad;
                    
                    try
                    {
                        var temp = await _service.Insert<Model.Korisnici>(insertRequest);
                        if (temp != null)
                        {
                            MessageBox.Show("Uspješno ste dodali korisnika!");
                        }
                        else
                        {
                            MessageBox.Show("Dodavanje korisnika nije uspjelo!");
                        }
                        
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Operacija neuspjela! " + exception.Message);
                    }
                    
                }

                
            }

            
            
        }

        private async void frmKorisniciDetalji_Load(object sender, EventArgs e)
        {
            await LoadGradove();
            await LoadUloge();
            LoadSpolove();
            if (_id.HasValue)
            {
                var korisnik = await _service.GetById<Model.Korisnici>(_id);
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
                cbUloga.SelectedValue = korisnik.UlogaId;
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
        private async Task LoadUloge()
        {
            var result = await _serviceUloge.GetAll<List<Model.Uloge>>(null);
            cbUloga.DataSource = result;
            cbUloga.DisplayMember = "Naziv";
            cbUloga.ValueMember = "UlogaId";
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider.SetError(txtIme, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider.SetError(txtPrezime, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPrezime, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtJMBG_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJMBG.Text))
            {
                errorProvider.SetError(txtJMBG, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtJMBG, null);
            }
        }

        private void txtMobitel_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMobitel.Text))
            {
                errorProvider.SetError(txtMobitel, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtMobitel, null);
            }
        }

        private void txtAdresa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdresa.Text))
            {
                errorProvider.SetError(txtAdresa, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtAdresa, null);
            }
        }

        private void txtKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text))
            {
                errorProvider.SetError(txtKorisnickoIme, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtKorisnickoIme, null);
            }
        }

        private void txtLozinka_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLozinka.Text))
            {
                errorProvider.SetError(txtLozinka, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtLozinka, null);
            }
        }

        private void txtPotvrdaLozinke_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPotvrdaLozinke.Text))
            {
                errorProvider.SetError(txtPotvrdaLozinke, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else if(txtLozinka.Text != txtPotvrdaLozinke.Text)
            {
                errorProvider.SetError(txtPotvrdaLozinke, "Niste unijeli tačno potvrdu lozinke!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPotvrdaLozinke, null);
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
