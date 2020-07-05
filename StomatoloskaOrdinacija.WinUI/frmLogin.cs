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

namespace StomatoloskaOrdinacija.WinUI
{
    public partial class frmLogin : Form
    {
        APIService _service = new APIService("Korisnici/login");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                APIService.Username = txtUsername.Text;
                APIService.Password = txtPassword.Text;

                KorisniciLoginRequest newLogin = new KorisniciLoginRequest{Password = txtPassword.Text, Username = txtUsername.Text};

                var temp = await _service.Login<Model.Korisnici>(newLogin);
                APIService.Permisije = temp.UlogaId;
                if (APIService.Permisije == 4)
                {
                    MessageBox.Show("Pacijentima nije dozvoljeno se logovat na desktop aplikaciju!", "Autorizacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //this.Hide();
                    frmIndex frm = new frmIndex();
                    frm.Show();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Authentikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
