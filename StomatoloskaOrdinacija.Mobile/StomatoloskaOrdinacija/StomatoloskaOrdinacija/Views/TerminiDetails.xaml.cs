using System;
using System.Collections.Generic;
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
    public partial class TerminiDetails : ContentPage
    {
        private TerminiDetailsViewModels model = null;
        public TerminiDetails(Termin termin)
        {
            InitializeComponent();
            BindingContext = model = new TerminiDetailsViewModels()
            {
                Termin = termin
            };

        }

        async void DodajOcjenuButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OcjeniUslugu(model.Termin.UslugaId));
        }
        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    await model.Init();
        //}
    }
}