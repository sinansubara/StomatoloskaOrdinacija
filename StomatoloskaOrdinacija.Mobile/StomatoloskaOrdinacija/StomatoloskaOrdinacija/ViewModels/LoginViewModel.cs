using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StomatoloskaOrdinacija.Model.Requests;
using StomatoloskaOrdinacija.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StomatoloskaOrdinacija.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Korisnici/login");
        private readonly APIService _serviceKorisnikPacijenti = new APIService("Korisnici/pacijenti");
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
            RegisterCommand = new Command(async () => await Register());
            ZaboravljenaLozinkaCommand = new Command(async () => await ZaboravljenaLozinka());
        }

        bool usernameValidate = false;
        public bool UsernameValidation
        {
            get { return usernameValidate; }
            set { SetProperty(ref usernameValidate, value); }
        }

        bool passwordValidate = false;
        public bool PasswordValidation
        {
            get { return passwordValidate; }
            set { SetProperty(ref passwordValidate, value); }
        }

        private string _username = string.Empty;

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _password = string.Empty;

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand ZaboravljenaLozinkaCommand { get; set; }
        
        async Task Login()
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                UsernameValidation = true;
                if (string.IsNullOrWhiteSpace(Password))
                {
                    PasswordValidation = true;
                }
                else
                {
                    PasswordValidation = false;
                }
            }
            else if (string.IsNullOrWhiteSpace(Password))
            {
                UsernameValidation = false;
                PasswordValidation = true;
            }
            else
            {
                UsernameValidation = false;
                PasswordValidation = false;
                IsBusy = true;
                APIService.Username = Username;
                APIService.Password = Password;
                KorisniciLoginRequest newLogin = new KorisniciLoginRequest{Password = APIService.Password, Username = APIService.Username};
                try
                {
                    var temp = await _service.Login<Model.Korisnici>(newLogin);
                    APIService.KorisnikId = temp.KorisnikId;
                    APIService.Permisije = temp.UlogaId;
                    if (APIService.Permisije == 4)
                    {
                        Application.Current.MainPage = new MainPage();
                   
                        var temp2 = await _serviceKorisnikPacijenti.GetById<Model.KorisnikPacijent>(temp.KorisnikId);
                        APIService.PacijentId = temp2.PacijentId;
                    }
                    else
                    {
                        IsBusy = false;
                        Username = string.Empty;
                        Password = string.Empty;
                        await Application.Current.MainPage.DisplayAlert("Greška", "Mobilna aplikacija je namjenjena samo za pacijente!", "OK");
                    }
                    
                }
                catch (Exception)
                {
                    IsBusy = false;
                    Password = string.Empty;
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste unijeli ispravne login podatke!", "OK");
                }
            }
        }
        async Task Register()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Registracija());
        }
        async Task ZaboravljenaLozinka()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ZaboravljenaLozinka());
        }
    }
}
