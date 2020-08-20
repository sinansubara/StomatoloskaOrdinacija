using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StomatoloskaOrdinacija.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TerminDodaj : ContentPage
    {
        private TerminDodajViewModel model = null;
        public TerminDodaj()
        {
            InitializeComponent();
            BindingContext = model = new TerminDodajViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        async void RezervisiButtonClicked(object sender, EventArgs e)
        {
            await model.Rezervisi();
            //await Navigation.PopAsync();
        }
    }
}