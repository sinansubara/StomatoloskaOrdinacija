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
using StomatoloskaOrdinacija.WinUI.Korisnici;
using StomatoloskaOrdinacija.WinUI.Pacijenti;
using StomatoloskaOrdinacija.WinUI.Popusti;
using StomatoloskaOrdinacija.WinUI.Pregledi;
using StomatoloskaOrdinacija.WinUI.Racun;
using StomatoloskaOrdinacija.WinUI.Reporti;
using StomatoloskaOrdinacija.WinUI.Skladiste;
using StomatoloskaOrdinacija.WinUI.Termini;

namespace StomatoloskaOrdinacija.WinUI
{
    public partial class frmIndex : Form
    {
        APIService _service = new APIService("Termin");
        private int childFormNumber = 0;

        public frmIndex()
        {
            InitializeComponent();
            notifyIcon1.Icon = this.Icon;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisnicics frm = new frmKorisnicics
            {
                MdiParent = this, WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void noviKorisnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (APIService.Permisije == 1)
            {
                frmKorisniciDetalji frm = new frmKorisniciDetalji();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Ova funkcija je za administratora samo, ako želite dodati novog pacijenta, morate otići na tab namjenjen za pacijente!", "Autorizacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void noviPacijentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPacijentiDetalji frm = new frmPacijentiDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPacijenti frm = new frmPacijenti
            {
                MdiParent = this, WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void pregledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSkladiste frm = new frmSkladiste
            {
                MdiParent = this, WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void unosMaterijalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUlazUSkladiste frm = new frmUlazUSkladiste();
            frm.Show();
        }

        private void unosNovogPregledaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (APIService.Permisije == 1 || APIService.Permisije == 2)
            {
                frmUnosPregleda frm = new frmUnosPregleda();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Samo stomatolog moze dodavati informacije o pregledima pacijenata!", "Autorizacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void pretragaPregledaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPretragaPregleda frm = new frmPretragaPregleda
            {
                MdiParent = this, WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void pregledSvihTerminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPregledTermina frm = new frmPregledTermina
            {
                MdiParent = this, WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void dodajNoviPopustToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDodajPopust frm = new frmDodajPopust
            {
                MdiParent = this, WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private async void frmIndex_Load(object sender, EventArgs e)
        {
            try
            {
                var lista = await _service.GetAll<IList<Model.Termin>>(new TerminSearchRequest {IsNaCekanju = true});
                var brojNovihTermina = lista.Count;
                if (brojNovihTermina > 0)
                {
                    notifyIcon1.ShowBalloonTip(4000, "Novi termini", "Broj novih termina: "+brojNovihTermina, ToolTipIcon.Info);
                }
            }
            catch (Exception)
            {
                
            }
        }
        

        private void najboljiKorisniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNajboljiKorisnici frm = new frmNajboljiKorisnici
            {
                MdiParent = this, WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void korisniciPoDatumuRegistrovanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void top10MaterijalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void noviReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            frmPregledTermina frm = new frmPregledTermina
            {
                MdiParent = this, WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void top10ProizvodaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportviewertest frm = new reportviewertest();
            frm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void najboljiPacijentiToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void pregledRacunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPregledRacuna frm = new frmPregledRacuna
            {
                MdiParent = this, WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void pacijentiPoDatumuRegistracijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportViewerPacijentiPoDatumu frm = new reportViewerPacijentiPoDatumu();
            frm.Show();
        }

        private void najznacajnijiPacijentiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportViewerTopPacijenti frm = new reportViewerTopPacijenti();
            frm.Show();
        }

        private void najboljeUslugeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportViewerUslugePoZaradi frm = new reportViewerUslugePoZaradi();
            frm.Show();
        }
    }
}
