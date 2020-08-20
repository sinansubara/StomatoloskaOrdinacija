﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StomatoloskaOrdinacija.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StomatoloskaOrdinacija.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OcjeniUslugu : ContentPage
    {
        private OcjeniUsluguViewModel model = null;
        public OcjeniUslugu(int uslugaId)
        {
            InitializeComponent();
            BindingContext = model = new OcjeniUsluguViewModel
            {
                UslugaId = uslugaId
            };
        }
    }
}