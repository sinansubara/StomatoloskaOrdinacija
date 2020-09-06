using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Prism.Mvvm;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;
using Xamarin.Forms;

namespace StomatoloskaOrdinacija.ViewModels
{
    public class RacuniViewModel : BindableBase
    {
        private readonly APIService _service = new APIService("Racun");

        public RacuniViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        bool _praznaLista = false;
        public bool IsPraznaLista
        {
            get { return _praznaLista; }
            set { SetProperty(ref _praznaLista, value); }
        }

        public ObservableCollection<Racun> RacuniList { get; set; } = new ObservableCollection<Racun>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            IsPraznaLista = false;
            var request = new RacunSearchRequest();
            request.NijeUplatioRequest = true;
            request.PacijentId = APIService.PacijentId;
            UserDialogs.Instance.ShowLoading("Učitavanje podataka o računima..");
            var list = await _service.GetAll<List<Model.Racun>>(request);
           
            RacuniList.Clear();
            foreach (var racun in list)
            {
                RacuniList.Add(racun);
            }

            if (RacuniList.Count == 0)
            {
                IsPraznaLista = true;
            }
            UserDialogs.Instance.HideLoading();
        }
    }
}
