using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using StomatoloskaOrdinacija.Models;
using StomatoloskaOrdinacija.Views;
using StomatoloskaOrdinacija.ViewModels;

namespace StomatoloskaOrdinacija.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel = null;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }



        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.Init();
        }
    }
}