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
    public partial class PlacanjeRacuna : ContentPage
    {
        private PlacanjeRacunaViewModel model = null;
        public PlacanjeRacuna(Racun racun)
        {
            InitializeComponent();
            BindingContext = model = new PlacanjeRacunaViewModel
            {
                Racun = racun
            };
            model.Navigation = Navigation;
        }

        protected override void OnAppearing()
        {
            Submit_Button.IsEnabled = false;
            ErrorLabel_CardNumber.IsVisible = true;
            ErrorLabel_Cvv.IsVisible = true;
            ErrorLabel_Month.IsVisible = true;
            ErrorLabel_Year.IsVisible = true;
        }
        private void CardNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CardNumber.Text.Length > 16)
            {
                ErrorLabel_CardNumber.IsVisible = true;
                CardNumber.Text = RemoveLastCharacter(CardNumber.Text);
                ErrorLabel_CardNumber.Text = "Neispravan broj kartice!";
            }
            else if (CardNumber.Text.Length < 1)
            {
                ErrorLabel_CardNumber.IsVisible = true;
                ErrorLabel_CardNumber.Text = "Unesite broj kartice!";

            }
            else
            {
                ErrorLabel_CardNumber.IsVisible = false;

            }
            EnableSubmitButton();
        }
        private void CardNumber_Completed(object sender, System.EventArgs e)
        {
            if (CardNumber.Text.Length > 16 || CardNumber.Text.Length < 12)
            {
                ErrorLabel_CardNumber.IsVisible = true;
                ErrorLabel_CardNumber.Text = "Neispravan broj kartice!";
                EnableSubmitButton();
            }
            else
            {
                ErrorLabel_CardNumber.IsVisible = false;
            }
            CardNumber.Unfocus();
            Month.Focus();
            EnableSubmitButton();
        }

        private void Month_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Month.Text.Length < 1)
            {
                ErrorLabel_Month.IsVisible = true;
                ErrorLabel_Month.Text = "Unesite mjesec!";
            }
            else if (Month.Text.Length > 2)
            {
                Month.Text = RemoveLastCharacter(Month.Text);
                ErrorLabel_Month.IsVisible = true;
                ErrorLabel_Month.Text = "Unesite mjesec u ispravnom formatu!";
            }
            else
            {
                ErrorLabel_Month.IsVisible = false;
                EnableSubmitButton();
            }
            EnableSubmitButton();
        }
        private void Month_Completed(object sender, System.EventArgs e)
        {
            Month.Unfocus();
            Year.Focus();
        }

        private void Year_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Year.Text.Length < 1)
            {
                ErrorLabel_Year.IsVisible = true;
                ErrorLabel_Year.Text = "Unesite godinu!";
            }
            else if (Year.Text.Length > 2)
            {
                Year.Text = RemoveLastCharacter(Year.Text);
                ErrorLabel_Year.IsVisible = true;
                ErrorLabel_Year.Text = "Unesite godinu u ispravnom formatu!";
            }
            else
            {
                ErrorLabel_Year.IsVisible = false;
                EnableSubmitButton();
            }
            EnableSubmitButton();
        }
        private void Year_Completed(object sender, System.EventArgs e)
        {
            Year.Unfocus();
            Cvv.Focus();
        }

        private void Cvv_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Cvv.Text.Length < 1)
            {
                ErrorLabel_Cvv.IsVisible = true;
                ErrorLabel_Cvv.Text = "Unesite CVV!";
            }
            else if (Cvv.Text.Length > 3)
            {
                Cvv.Text = RemoveLastCharacter(Cvv.Text);
                ErrorLabel_Cvv.IsVisible = true;
                ErrorLabel_Cvv.Text = "Neispravan CVV!";
            }
            else
            {
                ErrorLabel_Cvv.IsVisible = false;
                EnableSubmitButton();
            }

            EnableSubmitButton();
        }
        private void Cvv_Completed(object sender, System.EventArgs e)
        {
            Cvv.Unfocus();
        }
        private void EnableSubmitButton()
        {
            if (ErrorLabel_CardNumber.IsVisible || ErrorLabel_Cvv.IsVisible || ErrorLabel_Month.IsVisible || ErrorLabel_Year.IsVisible)
            {
                Submit_Button.IsEnabled = false;
            }
            else
            {
                Submit_Button.IsEnabled = true;
            }
        }
        private string RemoveLastCharacter(string str)
        {
            int l = str.Length;
            string text = str.Remove(l - 1, 1);
            return text;
        }
    }
}