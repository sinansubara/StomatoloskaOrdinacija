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
        private TerminiViewModel model = null;
        public Termini()
        {
            InitializeComponent();
            BindingContext = model = new TerminiViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}