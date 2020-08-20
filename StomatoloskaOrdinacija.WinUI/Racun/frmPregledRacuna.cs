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

namespace StomatoloskaOrdinacija.WinUI.Racun
{
    public partial class frmPregledRacuna : Form
    {
        private readonly APIService _servicePregled = new APIService("Pregled");
        private readonly APIService _serviceRacun = new APIService("Racun");
        public frmPregledRacuna()
        {
            InitializeComponent();
        }

        private async void frmPregledRacuna_Load(object sender, EventArgs e)
        {
            var list = await _serviceRacun.GetAll<IList<Model.Racun>>();
            dgvRacuni.AutoGenerateColumns = false;
            dgvRacuni.DataSource = list;
            if (dgvRacuni.RowCount > 0)
            {
                dgvRacuni.Columns[6].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            }
        }

        private void cmbPregled_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            var pretraga = new RacunSearchRequest
            {
                NijeUplatioRequest = cbNeuplaceni.Checked,
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text
            };
            var list = await _serviceRacun.GetAll<IList<Model.Racun>>(pretraga);
            dgvRacuni.AutoGenerateColumns = false;
            dgvRacuni.DataSource = list;
            if (dgvRacuni.RowCount > 0)
            {
                dgvRacuni.Columns[6].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            }
        }

        private async void btnNaplati_Click(object sender, EventArgs e)
        {
            if (dgvRacuni.RowCount > 0)
            {
                if (APIService.Permisije == 1 || APIService.Permisije == 3)
                {
                    var id = dgvRacuni.SelectedRows[0].Cells[0].Value;
                    int.TryParse(id.ToString(), out int convertRacun);

                    var temp = await _serviceRacun.Update<Model.Racun>(convertRacun, new RacunUpdateRequest {IsPlatio = true});

                    frmRacunReport frm = new frmRacunReport(convertRacun);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Ova funkcija je za medicinsko osoblje samo!", "Autorizacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lista još nije ucitana, pricekajte malo pa pokusajte ponovno.","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvRacuni_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvRacuni_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private async void dgvRacuni_DoubleClick(object sender, EventArgs e)
        {
            if (dgvRacuni.RowCount > 0)
            {
                if (APIService.Permisije == 1 || APIService.Permisije == 3)
                {
                    var id = dgvRacuni.SelectedRows[0].Cells[0].Value;
                    int.TryParse(id.ToString(), out int convertRacun);

                    var temp = await _serviceRacun.Update<Model.Racun>(convertRacun, new RacunUpdateRequest {IsPlatio = true});

                    frmRacunReport frm = new frmRacunReport(convertRacun);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Ova funkcija je za medicinsko osoblje samo!", "Autorizacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lista još nije ucitana, pricekajte malo pa pokusajte ponovno.","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
