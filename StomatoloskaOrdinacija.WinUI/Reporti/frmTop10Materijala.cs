using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StomatoloskaOrdinacija.WinUI.Reporti
{
    public partial class frmTop10Materijala : Form
    {
        private readonly APIService _service = new APIService("Materijali");
        public frmTop10Materijala()
        {
            InitializeComponent();
        }

        private async void frmTop10Materijala_Load(object sender, EventArgs e)
        {
            var temp = await _service.GetAll<List<Model.Materijali>>();

            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = temp;
        }
    }
}
