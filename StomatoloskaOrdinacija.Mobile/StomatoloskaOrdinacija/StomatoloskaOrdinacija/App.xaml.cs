using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StomatoloskaOrdinacija.Services;
using StomatoloskaOrdinacija.Views;

namespace StomatoloskaOrdinacija
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new Login()); 
            //MainPage = new Login();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
