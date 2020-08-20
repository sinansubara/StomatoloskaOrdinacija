using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StomatoloskaOrdinacija.Model.Requests;
using Xamarin.Forms;

namespace StomatoloskaOrdinacija.ViewModels
{
    public class PromjeniLozinkuViewModel : BaseViewModel
    {
        private readonly APIService _servicePromjeni = new APIService("Lozinka/promjena");


        public PromjeniLozinkuViewModel()
        {
            SnimiCommand = new Command(async () => await Snimi());
        }

        private string _korisnickoIme = string.Empty;
        public string KorisnickoIme
        {
            get { return _korisnickoIme; }
            set { SetProperty(ref _korisnickoIme, value); }
        }
        private string _vrijednost = string.Empty;
        public string Vrijednost
        {
            get { return _vrijednost; }
            set { SetProperty(ref _vrijednost, value); }
        }
        private string _lozinka = string.Empty;
        public string Lozinka
        {
            get { return _lozinka; }
            set { SetProperty(ref _lozinka, value); }
        }
        private string _potvrdaLozinke = string.Empty;
        public string PotvrdaLozinke
        {
            get { return _potvrdaLozinke; }
            set { SetProperty(ref _potvrdaLozinke, value); }
        }


        public ICommand SnimiCommand { get; set; }


        async Task Snimi()
        {
            
            var request = new PromjenaLozinkeVrijednostInsertRequest
            {
                KorisnickoIme = KorisnickoIme,
                Lozinka = Lozinka,
                PotvrdaLozinke = PotvrdaLozinke,
                Vrijednost = Vrijednost
            };
            //APIService.Context = "Registracija";
            var temp = await _servicePromjeni.GetAll<Model.PromjenaLozinke>(request);
            if (temp != null)
            {
                await Application.Current.MainPage.DisplayAlert("Lozinka izmjenjena", "Lozinka je izmjenjena mozete se logirati!", "OK");
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Lozinka nije izmjenjena", "Niste unijeli ispravne podatke!", "OK");
            }
        }
    }
}
