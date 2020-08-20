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

namespace StomatoloskaOrdinacija.WinUI.Termini
{
    public partial class frmPregledTermina : Form
    {
        private readonly APIService _serviceTermin = new APIService("Termin");
        private readonly APIService odbijTermin = new APIService("Termin/odbij");
        private readonly APIService prihvatiTermin = new APIService("Termin/prihvati");
        public frmPregledTermina()
        {
            InitializeComponent();
        }

        private async void frmPregledTermina_Load(object sender, EventArgs e)
        {
            var sviTermini = await _serviceTermin.GetAll<List<Model.Termin>>(null);

            dgvTermini.AutoGenerateColumns = false;
            dgvTermini.DataSource = sviTermini;
            if (dgvTermini.RowCount > 0)
            {
                dgvTermini.Columns[4].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private async void btnOdobri_Click(object sender, EventArgs e)
        {
            if (dgvTermini.RowCount > 0)
            {
                try
                {
                    var id = dgvTermini.SelectedRows[0].Cells[0].Value;
                    await prihvatiTermin.Update<object>(id, new TerminSearchRequest());
                    MessageBox.Show("Uspjesno ste odobrili termin.","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Niste oznacili termin za izmjenu.","Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                var requestSearch = cbNacekanju.Checked;
                TerminSearchRequest termin = new TerminSearchRequest
                {
                    IsNaCekanju = requestSearch
                };
                var sviTermini = await _serviceTermin.GetAll<List<Model.Termin>>(termin);

                dgvTermini.AutoGenerateColumns = false;
                dgvTermini.DataSource = sviTermini;
                if (dgvTermini.RowCount > 0)
                {
                    dgvTermini.Columns[4].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                }
            }
            else
            {
                MessageBox.Show("Lista jos nije ucitana, pricekajte malo pa pokusajte ponovno.","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnOdbij_Click(object sender, EventArgs e)
        {
            if (dgvTermini.RowCount > 0)
            {
                try
                {
                    var id = dgvTermini.SelectedRows[0].Cells[0].Value;
                    await odbijTermin.Update<object>(id, new TerminSearchRequest());
                    MessageBox.Show("Uspjesno ste odbili termin.","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Niste oznacili termin za izmjenu.","Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                var requestSearch = cbNacekanju.Checked;
                TerminSearchRequest termin = new TerminSearchRequest
                {
                    IsNaCekanju = requestSearch
                };
                var sviTermini = await _serviceTermin.GetAll<List<Model.Termin>>(termin);

                dgvTermini.AutoGenerateColumns = false;
                dgvTermini.DataSource = sviTermini;
                if (dgvTermini.RowCount > 0)
                {
                    dgvTermini.Columns[4].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                }
            }
            else
            {
                MessageBox.Show("Lista još nije ucitana, pricekajte malo pa pokusajte ponovno.","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void cbNacekanju_CheckedChanged(object sender, EventArgs e)
        {
            var requestSearch = cbNacekanju.Checked;
            TerminSearchRequest termin = new TerminSearchRequest
            {
                IsNaCekanju = requestSearch
            };
            var sviTermini = await _serviceTermin.GetAll<List<Model.Termin>>(termin);

            dgvTermini.AutoGenerateColumns = false;
            dgvTermini.DataSource = sviTermini;
            if (dgvTermini.RowCount > 0)
            {
                dgvTermini.Columns[4].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            }
        }
    }
}
