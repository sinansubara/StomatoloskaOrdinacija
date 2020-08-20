using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using StomatoloskaOrdinacija.Model.Requests;
using StomatoloskaOrdinacija.Views;
using Xamarin.Forms;

namespace StomatoloskaOrdinacija.ViewModels
{
    public class ZaboravljenaLozinkaViewModel : BaseViewModel
    {
        private readonly APIService _serviceZaboravljenaLozinka = new APIService("Lozinka");

        public ZaboravljenaLozinkaViewModel()
        {
            PosaljiCommand = new Command(async () => await Posalji());
        }


        bool _emailValidate = false;
        public bool EmailValidate
        {
            get { return _emailValidate; }
            set { SetProperty(ref _emailValidate, value); }
        }

        private string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        public ICommand PosaljiCommand { get; set; }

        private bool ValidateForm()
        {
            bool IsValidated = true;
            string pattern =
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

            if (string.IsNullOrWhiteSpace(Email) || Email.Length >= 320 || !Regex.IsMatch(Email, pattern))
            {
                IsValidated = false;
                EmailValidate = true;
            }
            else
            {
                EmailValidate = false;
            }

            return IsValidated;
        }


        async Task Posalji()
        {
            if (ValidateForm())
            {
                var request = new PromjenaLozinkeInsertRequest
                {
                    Email = Email
                };
                //APIService.Context = "Registracija";
                var temp = await _serviceZaboravljenaLozinka.GetAll<Model.PromjenaLozinke>(request);
                if (temp != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Mail poslan", "Slanje maila je uspjesno, potrazite kod u zadnjoj nasoj poruci!", "OK");
                    await Application.Current.MainPage.Navigation.PushAsync(new PromjeniLozinku());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Mail nije poslan", "Doslo je do greske!", "OK");
                }
                
            }
        }
    }
}
