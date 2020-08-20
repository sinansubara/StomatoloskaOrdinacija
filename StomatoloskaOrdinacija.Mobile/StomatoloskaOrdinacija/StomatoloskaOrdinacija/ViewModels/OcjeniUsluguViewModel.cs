using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using StomatoloskaOrdinacija.Model.Requests;
using Xamarin.Forms;

namespace StomatoloskaOrdinacija.ViewModels
{
    public class OcjeniUsluguViewModel : BaseViewModel
    {
        private readonly APIService _serviceOcjena = new APIService("Ocjene");
        public int UslugaId { get; set; }


        public OcjeniUsluguViewModel()
        {
            SnimiCommand = new Command(async () => await Snimi());
        }
        bool _ocjenaValidation = false;
        public bool OcjenaValidation
        {
            get { return _ocjenaValidation; }
            set { SetProperty(ref _ocjenaValidation, value); }
        }
        bool _komentarValidation = false;
        public bool KomentarValidation
        {
            get { return _komentarValidation; }
            set { SetProperty(ref _komentarValidation, value); }
        }

        private string _ocjena = string.Empty;
        public string Ocjena
        {
            get { return _ocjena; }
            set { SetProperty(ref _ocjena, value); }
        }

        private string _komentar = string.Empty;
        public string Komentar
        {
            get { return _komentar; }
            set { SetProperty(ref _komentar, value); }
        }


        public ICommand SnimiCommand { get; set; }



        private bool ValidateForm()
        {
            bool IsValidated = true;
            string pattern = "^[0-9]+([.][0-9]+)?$";

            if (string.IsNullOrWhiteSpace(Ocjena) || !Regex.IsMatch(Ocjena, pattern))
            {
                IsValidated = false;
                OcjenaValidation = true;
            }
            else
            {
                OcjenaValidation = false;
            }
            if (string.IsNullOrWhiteSpace(Komentar) || Komentar.Length >= 300)
            {
                IsValidated = false;
                KomentarValidation = true;
            }
            else
            {
                KomentarValidation = false;
            }

            return IsValidated;
        }

        async Task Snimi()
        {
            if (ValidateForm())
            {
                var tempocjena = decimal.Parse(Ocjena);
                var request = new OcjeneUpsertRequest
                {
                    Komentar = Komentar,
                    Ocjena = tempocjena,
                    UslugaId = UslugaId,
                    PacijentId = APIService.PacijentId
                };
                var temp = await _serviceOcjena.Insert<Model.Ocjene>(request);
                if (temp != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Ocjena dodana", "Uspjesno ste dodali ocjenu na odabranu uslugu!", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Ocjena nije dodana", "Ocjena nije unesena!", "OK");
                }
            }

        }
    }
}
