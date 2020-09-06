using System;
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
    public partial class QRCodeGenerator : ContentPage
    {
        private QRCodeGeneratorViewModel model = null;
        public QRCodeGenerator(string code)
        {
            InitializeComponent();
            BindingContext = model = new QRCodeGeneratorViewModel()
            {
                Code = code
            };
        }
    }
}