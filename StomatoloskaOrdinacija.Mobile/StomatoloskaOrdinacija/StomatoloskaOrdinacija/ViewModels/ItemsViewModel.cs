using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using StomatoloskaOrdinacija.Model;
using Xamarin.Forms;

using StomatoloskaOrdinacija.Models;
using StomatoloskaOrdinacija.Views;

namespace StomatoloskaOrdinacija.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private readonly APIService _gradService = new APIService("Usluga/RecommendedUsluge");

        public ItemsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Usluga> UslugeList { get; set; } = new ObservableCollection<Usluga>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            //eventsList = await _eventsService.GetRecommendedEvents<IEnumerable<EventDto>>(user.Id);
            //var list = await _gradService.GetAll<List<Model.Usluga>>(null);
            var list = await _gradService.GetById<IEnumerable<Usluga>>(APIService.PacijentId);

            UslugeList.Clear();
            foreach (var usluga in list)
            {
                UslugeList.Add(usluga);
            }
        }
    }
}