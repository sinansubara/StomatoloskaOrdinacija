using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;
using Xamarin.Forms;

namespace StomatoloskaOrdinacija.ViewModels
{
    public class TerminDodajViewModel : BaseViewModel
    {
        private readonly APIService _uslugeService = new APIService("Usluga");
        private readonly APIService _terminService = new APIService("Termin");
        public TerminDodajViewModel()
        {
            InitCommand = new Command(async () => await Init());
            RezervisiCommand = new Command(async () => await Rezervisi());
        }
        public ObservableCollection<Usluga> UslugaList { get; set; } = new ObservableCollection<Usluga>();
        public ICommand InitCommand { get; set; }
        public ICommand RezervisiCommand { get; set; }

        #region Inicijalizacija
        private Usluga _selectedUsluga = null;
        public Usluga SelectedUsluga
        {
            get { return _selectedUsluga; }
            set { SetProperty(ref _selectedUsluga, value); }
        }

        private DateTime _odabraniDatum = DateTime.Now;
        public DateTime DatumRezervacije
        {
            get { return _odabraniDatum; }
            set { SetProperty(ref _odabraniDatum, value); }
        }
        
        private TimeSpan _odabranoVrijeme = new TimeSpan(8, 0, 0);
        public TimeSpan VrijemeRezervacije
        {
            get { return _odabranoVrijeme; }
            set { SetProperty(ref _odabranoVrijeme, value); }
        }

        private string _razlogTermina = string.Empty;
        public string RazlogTermina
        {
            get { return _razlogTermina; }
            set { SetProperty(ref _razlogTermina, value); }
        }

        private bool _hitanTermina = false;
        public bool HitanTermin
        {
            get { return _hitanTermina; }
            set { SetProperty(ref _hitanTermina, value); }
        }

        #endregion
        

        #region ValidacijaTermina
        bool _uslugaValidation = false;
        public bool UslugaValidation
        {
            get { return _uslugaValidation; }
            set { SetProperty(ref _uslugaValidation, value); }
        }

        bool _datumValidation = false;
        public bool DatumValidation
        {
            get { return _datumValidation; }
            set { SetProperty(ref _datumValidation, value); }
        }

        bool _vrijemeValidation = false;
        public bool VrijemeValidation
        {
            get { return _vrijemeValidation; }
            set { SetProperty(ref _vrijemeValidation, value); }
        }

        bool _razlogValidation = false;
        public bool RazlogValidation
        {
            get { return _razlogValidation; }
            set { SetProperty(ref _razlogValidation, value); }
        }


        #endregion
        

        
        public async Task Init()
        {
            if (UslugaList.Count == 0)
            {
                var uslugeLista = await _uslugeService.GetAll<IList<Model.Usluga>>(null);
                UslugaList.Clear();

                foreach (var usluga in uslugeLista)
                {
                    UslugaList.Add(usluga);
                }
            }
        }
        private bool ValidateForm()
        {
            bool IsValidated = true;

            if (SelectedUsluga == null)
            {
                UslugaValidation = true;
                IsValidated = false;
            }
            else
            {
                UslugaValidation = false;
            }

            if (DatumRezervacije <= DateTime.Now)
            {
                DatumValidation = true;
                IsValidated = false;
            }
            else
            {
                DatumValidation = false;
            }

            if (VrijemeRezervacije.Hours < 8 || VrijemeRezervacije.Hours >= 20)
            {
                VrijemeValidation = true;
                IsValidated = false;
            }
            else
            {
                VrijemeValidation = false;
            }
            if (string.IsNullOrWhiteSpace(RazlogTermina) || RazlogTermina.Length >= 200)
            {
                RazlogValidation = true;
                IsValidated = false;
            }
            else
            {
                RazlogValidation = false;
            }

            return IsValidated;
        }
        public async Task Rezervisi()
        {
            if (ValidateForm())
            {
                DateTime datumIVrijemetemp = new DateTime(DatumRezervacije.Year, DatumRezervacije.Month,
                    DatumRezervacije.Day, VrijemeRezervacije.Hours, VrijemeRezervacije.Minutes,
                    VrijemeRezervacije.Seconds);

                var temp = await _terminService.Insert<Model.Termin>(new TerminInsertRequest
                {
                    UslugaId = SelectedUsluga.UslugaId,
                    DatumVrijeme = datumIVrijemetemp,
                    Hitan = HitanTermin,
                    PacijentId = APIService.PacijentId,
                    Razlog = RazlogTermina
                });

                if (temp != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Dodavanje uspjesno", "Uspjesno ste rezervisali termin!", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Rezervacija nije uspjela!", "OK");
                }
            }
            
        }
    }
}
