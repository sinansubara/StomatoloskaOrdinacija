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

namespace StomatoloskaOrdinacija.WinUI.Reporti
{
    public partial class frmKorisniciPoDatumuRegistracije : Form
    {
        private readonly APIService _serviceKorisnici = new APIService("Korisnici/getalldatumoddo");
        public frmKorisniciPoDatumuRegistracije()
        {
            InitializeComponent();
        }

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            await LoadData();
        }
        private async Task LoadData()
        {
            var result = await _serviceKorisnici.GetAll<List<Model.Korisnici>>(new KorisniciSearchRequest
            {
                OD = dateTimePicker1.Value,
                DO = dateTimePicker2.Value
            });
            if (result != null)
            {
                dgvKorisnici.AutoGenerateColumns = false;
                dgvKorisnici.DataSource = result;
            }
            
        }

        private async void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void frmKorisniciPoDatumuRegistracije_Load(object sender, EventArgs e)
        {
            await LoadData();
        }
    }
}
