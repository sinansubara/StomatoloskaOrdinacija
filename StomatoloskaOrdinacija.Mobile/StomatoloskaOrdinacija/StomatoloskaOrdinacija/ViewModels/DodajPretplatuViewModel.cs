using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Mvvm;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;
using Xamarin.Forms;

namespace StomatoloskaOrdinacija.ViewModels
{
    public class DodajPretplatuViewModel : BindableBase
    {
        private readonly APIService _uslugaService = new APIService("Usluga");
        private readonly APIService _uslugaPretplata = new APIService("Pretplata");
        public DodajPretplatuViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SnimiCommand = new Command(async () => await Snimi());
        }
        public ObservableCollection<Usluga> uslugeList { get; set; } = new ObservableCollection<Usluga>();

        public ICommand InitCommand { get; set; }
        public ICommand SnimiCommand { get; set; }
        private Usluga _selectedUsluga = null;

        public Usluga SelectedUsluga
        {
            get { return _selectedUsluga; }
            set { SetProperty(ref _selectedUsluga, value); }
        }


        public async Task Init()
        {

            var search = new UslugaSearchRequest
            {
                IsPretplacen = "Ne",
                PacijentId = APIService.PacijentId
            };
            var usluge = await _uslugaService.GetAll<List<Usluga>>(search);
            if (uslugeList.Count == 0 && usluge.Count > 0)
            {
                foreach (var usluga in usluge)
                {
                    uslugeList.Add(usluga);
                }
                SelectedUsluga = usluge[0];
            }
            if(uslugeList.Count > 0 && usluge.Count > 0)
            {
                uslugeList.Clear();
                foreach (var usluga in usluge)
                {
                    uslugeList.Add(usluga);
                }
                SelectedUsluga = usluge[0];
            }
        }

        public async Task Snimi()
        {
            var request = new PretplataInsertRequest
                {
                    IsAktivna = true,
                    PacijentId = APIService.PacijentId,
                    UslugaId = _selectedUsluga.UslugaId
                };
            var temp = await _uslugaPretplata.Insert<Model.Pretplata>(request);
            if(temp != null)
            {
                await Application.Current.MainPage.DisplayAlert("Info", "Uspjesno dodana pretplata!", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Niste dodali pretplatu!", "OK");
            }

            await Init();

        }
    }
}
