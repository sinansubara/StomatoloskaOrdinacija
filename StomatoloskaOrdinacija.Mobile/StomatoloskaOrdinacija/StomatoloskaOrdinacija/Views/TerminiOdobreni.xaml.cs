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
    public partial class TerminiOdobreni : ContentPage
    {
        private TerminiOdobreniViewModels model = null;
        public TerminiOdobreni()
        {
            InitializeComponent();
            BindingContext = model = new TerminiOdobreniViewModels();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private void Termin_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                this.Navigation.PushAsync(new TerminiDetails((e.Item as Termin)));
            }
        }
    }
}