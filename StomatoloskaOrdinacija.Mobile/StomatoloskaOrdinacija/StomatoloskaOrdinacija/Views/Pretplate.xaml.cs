using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using StomatoloskaOrdinacija.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StomatoloskaOrdinacija.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pretplate : ContentPage
    {
        private readonly APIService _service = new APIService("Pretplata");
        private PretplateViewModel model = null;

        public Pretplate()
        {
            InitializeComponent();
            BindingContext = model = new PretplateViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void IzbrisiPretplatu_Clicked(object sender, EventArgs e)
        {
            var preID = ((Button) sender).BindingContext;
            int PretplataId = int.Parse(preID.ToString());
            await _service.Delete<Model.Pretplata>(preID);
            await model.Init();
        }

        private async void DodajPretplatu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DodajPretplatu());
        }
    }
}