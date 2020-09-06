using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;
using Xamarin.Forms;

namespace StomatoloskaOrdinacija.ViewModels
{
    public class PretplateViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Pretplata");

        public PretplateViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Pretplata> PretplateList { get; set; } = new ObservableCollection<Pretplata>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            UserDialogs.Instance.ShowLoading("Učitavanje pretplata..");
            var request = new PretplataSearchRequest {PacijentId = APIService.PacijentId};
            var list = await _service.GetAll<IEnumerable<Pretplata>>(request);

            PretplateList.Clear();
            foreach (var usluga in list)
            {
                PretplateList.Add(usluga);
            }
            UserDialogs.Instance.HideLoading();
        }
}
}
