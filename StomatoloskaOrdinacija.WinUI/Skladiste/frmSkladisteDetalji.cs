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
using StomatoloskaOrdinacija.Model.Requests;

namespace StomatoloskaOrdinacija.WinUI.Skladiste
{
    public partial class frmSkladisteDetalji : Form
    {
        private readonly APIService _serviceSkladiste = new APIService("Skladiste");
        private readonly APIService _serviceKorisnici = new APIService("Korisnici");
        private int? _id = null;
        public frmSkladisteDetalji(int? skladisteId = null)
        {
            InitializeComponent();
            _id = skladisteId;
        }

        private async void frmSkladisteDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var skladiste = await _serviceSkladiste.GetById<Model.Skladiste>(_id);
                
                APIService.UlazUSkladisteId = skladiste.UlazUSkladisteId;
                txtNaziv.Text = skladiste.Naziv;
                txtOpis.Text = skladiste.Opis;
                txtVrsta.Text = skladiste.Vrsta;
                txtProizvodjac.Text = skladiste.Proizvodjac;
                txtKolicina1.Text = skladiste.Kolicina.ToString();
                txtMjernaJedinica.Text = skladiste.MjernaJedinica;
                txtCijena1.Text = skladiste.Cijena.ToString();
                pcbSlika.Image = GetImage(skladiste.Slika);
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
        SkladisteInsertRequest UpdateRequest = new SkladisteInsertRequest();
        SkladisteInsertRequest insertRequest = new SkladisteInsertRequest();
        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (_id.HasValue)
                {
                    
                    UpdateRequest.Naziv = txtNaziv.Text;
                    UpdateRequest.Opis = txtOpis.Text;
                    UpdateRequest.Vrsta = txtVrsta.Text;
                    UpdateRequest.Proizvodjac = txtProizvodjac.Text;
                    UpdateRequest.Kolicina = decimal.Parse(txtKolicina1.Text);
                    UpdateRequest.MjernaJedinica = txtMjernaJedinica.Text;
                    UpdateRequest.Cijena = decimal.Parse(txtCijena1.Text);
                    UpdateRequest.UlazUSkladisteId = APIService.UlazUSkladisteId;
                    try
                    {
                        var temp = await _serviceSkladiste.Update<Model.Skladiste>(_id, UpdateRequest);
                        
                        MessageBox.Show("Uspješno ste uredili skladište!");
                        
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Operacija neuspjela! " + exception.Message);
                    }
                    
                }
                else
                {
                    insertRequest.Naziv = txtNaziv.Text;
                    insertRequest.Opis = txtOpis.Text;
                    insertRequest.Vrsta = txtVrsta.Text;
                    insertRequest.Proizvodjac = txtProizvodjac.Text;
                    insertRequest.Kolicina = decimal.Parse(txtKolicina1.Text);
                    insertRequest.MjernaJedinica = txtMjernaJedinica.Text;
                    insertRequest.Cijena = decimal.Parse(txtCijena1.Text);
                    insertRequest.UlazUSkladisteId = APIService.UlazUSkladisteId;
                    try
                    {
                        var temp = await _serviceSkladiste.Insert<Model.Skladiste>(insertRequest);
                        if (temp != null)
                        {
                            MessageBox.Show("Uspješno ste dodali materijal na skladište!");
                        }
                        else
                        {
                            MessageBox.Show("Dodavanje materijala nije uspjelo!");
                        }
                        
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Operacija neuspjela! " + exception.Message);
                    }
                    
                }

                
            }
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNaziv, null);
            }
        }

        private void btnUploadSlika_Click(object sender, EventArgs e)
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

                txtSlika.Text = filename;
                Image image = Image.FromFile(filename);
                pcbSlika.Image = image;
            }
        }

        private void txtOpis_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOpis.Text))
            {
                errorProvider1.SetError(txtOpis, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtOpis, null);
            }
        }

        private void txtVrsta_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVrsta.Text))
            {
                errorProvider1.SetError(txtVrsta, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtVrsta, null);
            }
        }

        private void txtProizvodjac_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProizvodjac.Text))
            {
                errorProvider1.SetError(txtProizvodjac, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtProizvodjac, null);
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void txtKolicina1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKolicina1.Text))
            {
                errorProvider1.SetError(txtKolicina1, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else if (decimal.Parse(txtKolicina1.Text) <= decimal.Parse("0"))
            {
                errorProvider1.SetError(txtKolicina1, "Ne možete unijeti vrijednost manju ili jednaku 0!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtKolicina1, null);
            }
        }

        private void txtMjernaJedinica_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMjernaJedinica.Text))
            {
                errorProvider1.SetError(txtMjernaJedinica, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtMjernaJedinica, null);
            }
        }

        private void txtCijena1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKolicina1.Text))
            {
                errorProvider1.SetError(txtKolicina1, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else if (decimal.Parse(txtKolicina1.Text) <= decimal.Parse("0"))
            {
                errorProvider1.SetError(txtKolicina1, "Ne možete unijeti vrijednost manju ili jednaku 0!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtKolicina1, null);
            }
        }
    }
}
