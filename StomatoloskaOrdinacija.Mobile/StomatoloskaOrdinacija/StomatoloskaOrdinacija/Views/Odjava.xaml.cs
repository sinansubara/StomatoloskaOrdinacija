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
    public partial class Odjava : ContentPage
    {
        public Odjava()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            App.Current.MainPage = new Login();
        }
    }
}