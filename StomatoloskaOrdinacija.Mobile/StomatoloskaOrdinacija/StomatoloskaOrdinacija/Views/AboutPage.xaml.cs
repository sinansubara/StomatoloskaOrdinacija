using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StomatoloskaOrdinacija.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StomatoloskaOrdinacija.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        private AboutViewModel model = null;
        public AboutPage()
        {
            InitializeComponent();
            
            BindingContext = model = new AboutViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}