using StomatoloskaOrdinacija.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StomatoloskaOrdinacija.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Termini : ContentPage
    {
        public Termini()
        {
            InitializeComponent();
        }
        async void DodajButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TerminDodaj());
        }
        async void ZahtjevaniButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TerminiZahtjevani());
        }
        async void OdobreniButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TerminiOdobreni());
        }
        async void OdbijeniButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TerminiOdbijeni());
        }
    }
}