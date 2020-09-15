using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StomatoloskaOrdinacija.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private readonly APIService _gradService = new APIService("Grad");
        private readonly APIService _service = new APIService("Korisnici/pacijenti");
        private readonly APIService _servicePacijent = new APIService("Korisnici/pacijenti");
        public AboutViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SnimiCommand = new Command(async () => await Snimi());
        }
        public ObservableCollection<Grad> gradoviList { get; set; } = new ObservableCollection<Grad>();
        private Grad _selectedGrad = null;

        public Grad SelectedGrad
        {
            get { return _selectedGrad; }
            set { SetProperty(ref _selectedGrad, value); }
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


        bool _mobitelValidate = false;
        public bool MobitelValidate
        {
            get { return _mobitelValidate; }
            set { SetProperty(ref _mobitelValidate, value); }
        }

        bool _adresaValidate = false;
        public bool AdresaValidate
        {
            get { return _adresaValidate; }
            set { SetProperty(ref _adresaValidate, value); }
        }
        bool _gradValidate = false;
        public bool GradValidate
        {
            get { return _gradValidate; }
            set { SetProperty(ref _gradValidate, value); }
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


        private DateTime _datumRodjenja = DateTime.Now;

        public DateTime DatumRodjenja
        {
            get { return _datumRodjenja; }
            set { SetProperty(ref _datumRodjenja, value); }
        }

        private string _mobitel = string.Empty;
        public string Mobitel
        {
            get { return _mobitel; }
            set { SetProperty(ref _mobitel, value); }
        }

        private string _adresa = string.Empty;
        public string Adresa
        {
            get { return _adresa; }
            set { SetProperty(ref _adresa, value); }
        }
        private bool _alergija = false;
        public bool AlergijaNaLijekove
        {
            get { return _alergija; }
            set { SetProperty(ref _alergija, value); }
        }
        private bool _proteza = false;
        public bool Proteza
        {
            get { return _proteza; }
            set { SetProperty(ref _proteza, value); }
        }
        private bool _terapija = false;
        public bool Terapija
        {
            get { return _terapija; }
            set { SetProperty(ref _terapija, value); }
        }
        private bool _navlake = false;
        public bool Navlake
        {
            get { return _navlake; }
            set { SetProperty(ref _navlake, value); }
        }
        private bool _aparatic = false;
        public bool Aparatic
        {
            get { return _aparatic; }
            set { SetProperty(ref _aparatic, value); }
        }

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
            if (string.IsNullOrWhiteSpace(Mobitel) || Mobitel.Length >= 30)
            {
                IsValidated = false;
                MobitelValidate = true;
            }
            else
            {
                MobitelValidate = false;
            }
            if (string.IsNullOrWhiteSpace(Adresa) || Adresa.Length >= 200 || Adresa.Length < 3)
            {
                IsValidated = false;
                AdresaValidate = true;
            }
            else
            {
                AdresaValidate = false;
            }

            return IsValidated;
        }

        public ICommand InitCommand { get; set; }
        public ICommand SnimiCommand { get; set; }

        public async Task Init()
        {
            if (gradoviList.Count == 0)
            {
                var gradovi = await _gradService.GetAll<List<Grad>>(null);

                foreach (var grad in gradovi)
                {
                    gradoviList.Add(grad);
                }

                SelectedGrad = gradovi[0];
            }

            var temp = await _servicePacijent.GetById<Model.KorisnikPacijent>(APIService.KorisnikId);

            if (temp != null)
            {
                Ime = temp.Ime;
                Prezime = temp.Prezime;
                JMBG = temp.JMBG;
                Email = temp.Email;
                DatumRodjenja = temp.DatumRodjenja;
                Mobitel = temp.Mobitel;
                Adresa = temp.Adresa;
                SelectedGrad.GradId = temp.GradId;
                AlergijaNaLijekove = temp.AlergijaNaLijek;
                Navlake = temp.Navlake;
                Aparatic = temp.Aparatic;
                Proteza = temp.Proteza;
                Terapija = temp.Terapija;

            }


        }
        public async Task Snimi()
        {
            if (ValidateForm())
            {
                var request = new KorisniciPacijentUpdateRequest
                {
                    Ime = Ime,
                    Prezime = Prezime,
                    JMBG = JMBG,
                    Email = Email,
                    DatumRodjenja = DatumRodjenja,
                    Mobitel = Mobitel,
                    Adresa = Adresa,
                    GradId = SelectedGrad.GradId,
                    AlergijaNaLijek = AlergijaNaLijekove,
                    Navlake = Navlake,
                    Aparatic = Aparatic,
                    Proteza = Proteza,
                    Terapija = Terapija,
                    Status = true
                };
                var temp = await _service.Update<Model.KorisnikPacijent>(APIService.KorisnikId, request);
                if(temp != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Uspjesna promjena profila", "Promjenili ste profil!", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Greska", "Niste promjenili profil!", "OK");
                }
            }
           
        }
    }
}