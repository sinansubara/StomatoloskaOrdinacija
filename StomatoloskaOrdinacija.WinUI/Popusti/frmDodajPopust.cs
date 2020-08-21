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

namespace StomatoloskaOrdinacija.WinUI.Popusti
{
    public partial class frmDodajPopust : Form
    {
        private readonly APIService _servicePopust = new APIService("Popust");
        private readonly APIService _serviceUsluge = new APIService("Usluga");
        private readonly APIService _serviceKorisnici = new APIService("Korisnici");
        public frmDodajPopust()
        {
            InitializeComponent();
        }

        private void dgvTermini_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void frmDodajPopust_Load(object sender, EventArgs e)
        {
            
            var request = await _servicePopust.GetAll<List<Model.Popust>>(null);
            dgvPopust.AutoGenerateColumns = false;
            dgvPopust.DataSource = request;
            if (dgvPopust.RowCount > 0)
            {
                dgvPopust.Columns[3].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                dgvPopust.Columns[4].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            }
            await LoadUsluge();
        }

        private void cmbUsluga_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private async Task LoadUsluge()
        {
            var result = await _serviceUsluge.GetAll<List<Model.Usluga>>(null);
            cmbUsluga.DataSource = result;
            cmbUsluga.DisplayMember = "Naziv";
            cmbUsluga.ValueMember = "UslugaId";
        }

        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                

                int.TryParse(cmbUsluga.SelectedValue.ToString(), out int convertUsluga);
                int.TryParse(txtVrijednostPopusta.Text, out int convertVrijednost);
                PopustInsertRequest request = new PopustInsertRequest
                {
                    KorisnikId = APIService.KorisnikId,
                    PopustDoDatuma = dtpDO.Value,
                    PopustOdDatuma = dtpOD.Value,
                    UslugaId = convertUsluga,
                    VrijednostPopusta = convertVrijednost
                };
                try
                {
                    var temp = await _servicePopust.Insert<Model.Popust>(request);
                    if (temp != null)
                    {
                        MessageBox.Show("Uspješno ste dodali popust!");
                    }
                    else
                    {
                        MessageBox.Show("Dodavanje popusta nije uspjelo!");
                    }
                    
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Operacija neuspjela! " + exception.Message);
                }
                

                var osvjezi = await _servicePopust.GetAll<List<Model.Popust>>(null);
                dgvPopust.AutoGenerateColumns = false;
                dgvPopust.DataSource = osvjezi;
                if (dgvPopust.RowCount > 0)
                {
                    dgvPopust.Columns[3].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                    dgvPopust.Columns[4].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                }
            }
        }

        private void txtVrijednostPopusta_Validating(object sender, CancelEventArgs e)
        {
            string pattern = "^[0-9]+$";
            if (string.IsNullOrWhiteSpace(txtVrijednostPopusta.Text))
            {
                errorProvider1.SetError(txtVrijednostPopusta, Properties.Resources.Validation_ObaveznoPolje);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtVrijednostPopusta.Text, pattern))
            {
                errorProvider1.SetError(txtVrijednostPopusta, "Samo cijeli brojevi su dozvoljeni!");
                e.Cancel = true;
            }
            else if (int.TryParse(txtVrijednostPopusta.Text, out int convertVrijednost))
            {
                if (convertVrijednost >= 100)
                {
                    errorProvider1.SetError(txtVrijednostPopusta, "Popust ne moze biti 100% i vise!");
                    e.Cancel = true;
                } else if (convertVrijednost <= 0)
                {
                    errorProvider1.SetError(txtVrijednostPopusta, "Popust ne moze biti 0% i manje!");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(txtVrijednostPopusta, null);
                }
            }
        }

        private async void btnDeletePopust_Click(object sender, EventArgs e)
        {
            if (dgvPopust.RowCount > 0)
            {
                var id = dgvPopust.SelectedRows[0].Cells[0].Value;
                
                try
                {
                    var temp = await _servicePopust.Delete<Model.Popust>(id);
                    if (temp != null)
                    {
                        MessageBox.Show("Uspješno ste izbrisali popust!");
                    }
                    else
                    {
                        MessageBox.Show("Brisanje popusta nije uspjelo!");
                    }
                    var osvjezi = await _servicePopust.GetAll<List<Model.Popust>>(null);
                    dgvPopust.AutoGenerateColumns = false;
                    dgvPopust.DataSource = osvjezi;
                    if (dgvPopust.RowCount > 0)
                    {
                        dgvPopust.Columns[3].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                        dgvPopust.Columns[4].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                    }
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Operacija neuspjela! " + exception.Message);
                }
            }
            else
            {
                MessageBox.Show("Lista još nije ucitana, pricekajte malo pa pokusajte ponovno.","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
