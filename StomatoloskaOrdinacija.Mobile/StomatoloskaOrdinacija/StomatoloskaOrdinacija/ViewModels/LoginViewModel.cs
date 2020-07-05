using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StomatoloskaOrdinacija.Model.Requests;
using StomatoloskaOrdinacija.Views;
using Xamarin.Forms;

namespace StomatoloskaOrdinacija.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Korisnici/login");

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
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

        async Task Login()
        {
            IsBusy = true;
            APIService.Username = Username;
            APIService.Password = Password;
            KorisniciLoginRequest newLogin = new KorisniciLoginRequest{Password = APIService.Password, Username = APIService.Username};
            try
            {
                await _service.Login<Model.Korisnici>(newLogin);
                Application.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
