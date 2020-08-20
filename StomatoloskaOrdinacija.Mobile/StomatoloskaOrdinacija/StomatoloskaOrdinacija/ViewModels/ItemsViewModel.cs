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
        private readonly APIService _gradService = new APIService("Usluga");

        public ItemsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Usluga> UslugeList { get; set; } = new ObservableCollection<Usluga>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var list = await _gradService.GetAll<List<Model.Usluga>>(null);

            UslugeList.Clear();
            foreach (var usluga in list)
            {
                UslugeList.Add(usluga);
            }
        }
    }
}