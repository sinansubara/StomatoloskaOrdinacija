using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StomatoloskaOrdinacija.Model;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using StomatoloskaOrdinacija.Model.Requests;
using Xamarin.Essentials;

namespace StomatoloskaOrdinacija.ViewModels
{
    public class RegistracijaViewModel : BaseViewModel
    {
        private readonly APIService _serviceRegistracija = new APIService("Korisnici/registracija");
        private readonly APIService _serviceGradovi = new APIService("Grad");
        public RegistracijaViewModel()
        {
            RegisterCommand = new Command(async () => await Register());
        }

        #region ValidacijaRegistracije
        bool _imeValidate = false;
        public bool ImeValidation
        {
            get { return _imeValidate; }
            set { SetProperty(ref _imeValidate, value); }
        }

        bool _prezimeValidate = false;
        public bool PrezimeValidate
        {
            get { return _prezimeValidate; }
            set { SetProperty(ref _prezimeValidate, value); }
        }

        bool _jmbgValidate = false;
        public bool JMBGValidate
        {
            get { return _jmbgValidate; }
            set { SetProperty(ref _jmbgValidate, value); }
        }

        bool _emailValidate = false;
        public bool EmailValidate
        {
            get { return _emailValidate; }
            set { SetProperty(ref _emailValidate, value); }
        }

        bool _korisnickoImeValidate = false;
        public bool KorisnickoImeValidation
        {
            get { return _korisnickoImeValidate; }
            set { SetProperty(ref _korisnickoImeValidate, value); }
        }

        bool _lozinkaValidate = false;
        public bool LozinkaValidate
        {
            get { return _lozinkaValidate; }
            set { SetProperty(ref _lozinkaValidate, value); }
        }

        bool _potvrdaLozinkeValidate = false;
        public bool PotvrdaLozinkeValidate
        {
            get { return _potvrdaLozinkeValidate; }
            set { SetProperty(ref _potvrdaLozinkeValidate, value); }
        }

        #endregion

        #region Inicijalizacija
        private string _ime = string.Empty;
        public string Ime
        {
            get { return _ime; }
            set { SetProperty(ref _ime, value); }
        }

        private string _prezime = string.Empty;
        public string Prezime
        {
            get { return _prezime; }
            set { SetProperty(ref _prezime, value); }
        }
        
        private string _jmbg = string.Empty;
        public string JMBG
        {
            get { return _jmbg; }
            set { SetProperty(ref _jmbg, value); }
        }

        private string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _korisnickoIme = string.Empty;
        public string KorisnickoIme
        {
            get { return _korisnickoIme; }
            set { SetProperty(ref _korisnickoIme, value); }
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

        private DateTime _datumRodjenja = DateTime.Now;

        public DateTime DatumRodjenja
        {
            get { return _datumRodjenja; }
            set { SetProperty(ref _datumRodjenja, value); }
        }

        public ICommand RegisterCommand { get; set; }
        #endregion

        private bool ValidateForm()
        {
            bool IsValidated = true;
            string pattern =
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

            if (string.IsNullOrWhiteSpace(Ime) || Ime.Length >= 100)
            {
                IsValidated = false;
                ImeValidation = true;
            }
            else
            {
                ImeValidation = false;
            }
            if (string.IsNullOrWhiteSpace(Prezime) || Prezime.Length >= 100)
            {
                IsValidated = false;
                PrezimeValidate = true;
            }
            else
            {
                PrezimeValidate = false;
            }
            if (string.IsNullOrWhiteSpace(JMBG) || JMBG.Length != 13)
            {
                IsValidated = false;
                JMBGValidate = true;
            }
            else
            {
                JMBGValidate = false;
            }
            if (string.IsNullOrWhiteSpace(Email) || Email.Length >= 320 || !Regex.IsMatch(Email, pattern))
            {
                IsValidated = false;
                EmailValidate = true;
            }
            else
            {
                EmailValidate = false;
            }
            if (string.IsNullOrWhiteSpace(KorisnickoIme) || KorisnickoIme.Length >= 100 || KorisnickoIme.Length < 4)
            {
                IsValidated = false;
                KorisnickoImeValidation = true;
            }
            else
            {
                KorisnickoImeValidation = false;
            }
            if (string.IsNullOrWhiteSpace(Lozinka) || Lozinka.Length < 4)
            {
                IsValidated = false;
                LozinkaValidate = true;
            }
            else
            {
                LozinkaValidate = false;
            }

            if (string.IsNullOrWhiteSpace(PotvrdaLozinke) || PotvrdaLozinke != Lozinka)
            {
                IsValidated = false;
                PotvrdaLozinkeValidate = true;
            }
            else
            {
                PotvrdaLozinkeValidate = false;
            }

            return IsValidated;
        }
        async Task Register()
        {
            if (ValidateForm())
            {
                var insertRequest = new KorisniciRegistracijaRequest
                {
                    Ime = Ime,
                    Prezime = Prezime,
                    Email = Email,
                    KorisnickoIme = KorisnickoIme,
                    JMBG = JMBG,
                    DatumRodjenja = DatumRodjenja,
                    Mobitel = "061000000",
                    Adresa = "Adresa",
                    Password = Lozinka,
                    PasswordPotvrda = PotvrdaLozinke,
                    Spol = "Muško",
                    Status = true,
                    GradId = 1,
                    AlergijaNaLijek = false,
                    Aparatic = false,
                    Navlake = false,
                    Proteza = false,
                    Terapija = false,
                    Slika = null
                };
                

                APIService.Context = "Registracija";


                var temp = await _serviceRegistracija.Registracija<Model.Korisnici>(insertRequest);
                if (temp != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Registracija uspjesna", "Uspjesno ste se registrovali, mozete se prijaviti!", "OK");
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Registracija nije uspjela!", "OK");
                }
                
            }



            
        }
    }
}
