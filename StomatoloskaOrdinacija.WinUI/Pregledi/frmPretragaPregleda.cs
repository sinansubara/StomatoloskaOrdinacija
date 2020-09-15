﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StomatoloskaOrdinacija.Model.Requests;

namespace StomatoloskaOrdinacija.WinUI.Pregledi
{
    public partial class frmPretragaPregleda : Form
    {

        private readonly APIService _servicePregled = new APIService("Pregled");
        private readonly APIService _serviceDijagnoza = new APIService("Dijagnoza");
        private readonly APIService _serviceTermin = new APIService("Termin");
        private readonly APIService _serviceSkladiste = new APIService("Skladiste");
        private readonly APIService _serviceKorisnici = new APIService("Korisnici");

        public frmPretragaPregleda(int? pregledId = null)
        {
            InitializeComponent();
        }

        private void btnDodajNovog_Click(object sender, EventArgs e)
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

        private async void frmPretragaPregleda_Load(object sender, EventArgs e)
        {
            var list = await _servicePregled.GetAll<IList<Model.Pregled>>(new PregledSearchRequest() {KorisnikId = APIService.KorisnikId});
            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = list;

            await LoadTermine();
            await LoadOsoblje();
            await LoadMaterijale();

        }

        private async Task LoadOsoblje()
        {
            var result = await _serviceKorisnici.GetAll<List<Model.Korisnici>>(null);
            var newResult = new List<Model.Korisnici>();
            foreach (var res in result)
            {
                if (res.UlogaId == 1 || res.UlogaId == 2)
                {
                    newResult.Add(res);
                }
            }

            newResult.Insert(0, new Model.Korisnici());
            
            cmbKorisnik.DisplayMember = "ImeIPrezime";
            cmbKorisnik.ValueMember = "KorisnikId";
            cmbKorisnik.DataSource = newResult;
        }
        private async Task LoadTermine()
        {
            var result =
                await _serviceTermin.GetAll<List<Model.Termin>>(new TerminSearchRequest {IsIskoristenRequest = "Da"});
            
            result.Insert(0, new Model.Termin());
            
            cmbTermin.DisplayMember = "UslugaIme";
            cmbTermin.ValueMember = "TerminId";
            cmbTermin.DataSource = result;
        }
        private async Task LoadMaterijale()
        {
            var result = await _serviceSkladiste.GetAll<List<Model.Skladiste>>(null);
            result.Insert(0, new Model.Skladiste());
            
            cmbMaterijal.DisplayMember = "NazivVrsta";
            cmbMaterijal.ValueMember = "SkladisteId";
            cmbMaterijal.DataSource = result;
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            
            try
            {

                int.TryParse(cmbKorisnik.SelectedValue.ToString(), out int convertKorisnik);
                int.TryParse(cmbMaterijal.SelectedValue.ToString(), out int convertMaterijal);
                int.TryParse(cmbTermin.SelectedValue.ToString(), out int convertTermin);


                PregledSearchRequest searchRequest = new PregledSearchRequest
                {
                    KorisnikId = convertKorisnik,
                    Napomena = txtNapomena.Text,
                    SkladisteId = convertMaterijal,
                    TerminId = convertTermin
                };
                var list = await _servicePregled.GetAll<IList<Model.Pregled>>(searchRequest);
                dgvKorisnici.AutoGenerateColumns = false;
                dgvKorisnici.DataSource = list;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Greska pri pretrazivanju pregleda, prikazat ce se citava lista pregleda!" + exception.Message);
                var list2 = await _servicePregled.GetAll<IList<Model.Pregled>>(null);
                dgvKorisnici.AutoGenerateColumns = false;
                dgvKorisnici.DataSource = list2;
            }


        }

        private void dgvKorisnici_DoubleClick(object sender, EventArgs e)
        {
            if (dgvKorisnici.RowCount > 0)
            {
                var id = dgvKorisnici.SelectedRows[0].Cells[0].Value;
                int.TryParse(id.ToString(), out int convertDetalji);
                frmDetaljiPregleda frm = new frmDetaljiPregleda(convertDetalji);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Lista još nije ucitana, pricekajte malo pa pokusajte ponovno.","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            if (dgvKorisnici.RowCount > 0)
            {
                var id = dgvKorisnici.SelectedRows[0].Cells[0].Value;
                int.TryParse(id.ToString(), out int convertDetalji);
                frmDetaljiPregleda frm = new frmDetaljiPregleda(convertDetalji);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Lista još nije ucitana, pricekajte malo pa pokusajte ponovno.","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnSviPregleda_Click(object sender, EventArgs e)
        {
            
            var list2 = await _servicePregled.GetAll<IList<Model.Pregled>>(null);
            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = list2;
        }
    }
}
