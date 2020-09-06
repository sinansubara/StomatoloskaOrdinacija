using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;
using Xamarin.Forms;

using StomatoloskaOrdinacija.Models;
using StomatoloskaOrdinacija.Views;

namespace StomatoloskaOrdinacija.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private readonly APIService _gradService = new APIService("Usluga/RecommendedUsluge");
        private readonly APIService _pretplataService = new APIService("Pretplata");

        public ItemsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Usluga> UslugeList { get; set; } = new ObservableCollection<Usluga>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var request = new PretplataSearchRequest
            {
                PacijentId = APIService.PacijentId,
                IsNaSnizenju = "Da"
            };
            var temp = await _pretplataService.GetAll<List<Model.Pretplata>>(request);
            if (temp.Count > 0)
            {
                string notifikacija = "";
                foreach (var pretplata in temp)
                {
                    notifikacija = notifikacija + pretplata.Usluga.Naziv + " | Cijena: " + pretplata.Usluga.Cijena + " KM --> Snizena cijena: " + pretplata.SnizenaCijena + " KM" +  "\n";
                }

                UserDialogs.Instance.Alert(notifikacija, "Usluge na akciji", "OK");
            }

            var list = await _gradService.GetById<IEnumerable<Usluga>>(APIService.PacijentId);

            UslugeList.Clear();
            foreach (var usluga in list)
            {
                UslugeList.Add(usluga);
            }
        }
    }
}