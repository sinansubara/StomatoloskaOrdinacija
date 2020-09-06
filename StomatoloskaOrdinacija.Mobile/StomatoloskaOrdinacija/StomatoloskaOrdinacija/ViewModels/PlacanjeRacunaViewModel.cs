using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;
using StomatoloskaOrdinacija.Models;
using StomatoloskaOrdinacija.Views;
using Stripe;
using Xamarin.Forms;

namespace StomatoloskaOrdinacija.ViewModels
{
    public class PlacanjeRacunaViewModel : BindableBase
    {
        //servisi pozivat
        private readonly APIService _service = new APIService("Racun");

        public INavigation Navigation { get; set; }

        //varijable
        #region Variable
        public Racun Racun { get; set; }

        private KreditnaKarticaModel _kreditnaKarticaModel;
        private TokenService Tokenservice;
        private Token stripeToken;
        private bool _isCarcValid;
        private bool _isTransectionSuccess;
        private string _expMonth;
        private string _expYear;
        private string _title;
        #endregion Variable

        //public ICommand InitCommand { get; set; }

        //public async Task Init()
        //{

        //}

        #region Public Property
        private string StripeTestApiKey = "sk_test_51HOA3VJTK2vMUPcgav83EnwJEbdPdXfVl1yDIlimoYBY1GDaKqszIRytyY9hqSrs8My5rGxvepPqeR0iGtT6jbgg00mucT8PGy";
        public string ExpMonth
        {
            get { return _expMonth; }
            set { SetProperty(ref _expMonth, value); }
        }

        public bool IsCarcValid
        {
            get { return _isCarcValid; }
            set { SetProperty(ref _isCarcValid, value); }
        }

        public bool IsTransectionSuccess
        {
            get { return _isTransectionSuccess; }
            set { SetProperty(ref _isTransectionSuccess, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string ExpYear
        {
            get { return _expYear; }
            set { SetProperty(ref _expYear, value); }
        }

        public KreditnaKarticaModel KreditnaKartica
        {
            get { return _kreditnaKarticaModel; }
            set { SetProperty(ref _kreditnaKarticaModel, value); }
        }
        #endregion Public Property

        #region Constructor

        public PlacanjeRacunaViewModel()
        {
            KreditnaKartica = new KreditnaKarticaModel();
            Title = "Card Details";
            //InitCommand = new Command(async () => await Init());
        }

        #endregion Constructor



        #region Command


        public DelegateCommand SubmitCommand => new DelegateCommand(async () =>
        {

            KreditnaKartica.ExpMonth = Convert.ToInt64(ExpMonth);
            KreditnaKartica.ExpYear = Convert.ToInt64(ExpYear);
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            try
            {
                UserDialogs.Instance.ShowLoading("Izvršavanje uplate...");
                await Task.Run(async () =>
                {

                    var Token = CreateToken();
                    Console.Write("Payment Gateway" + "Token :" + Token);
                    if (Token != null)
                    {
                        IsTransectionSuccess = MakePayment(Token);
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Unesite ispravne podatke o kartici", null, "OK");
                    }
                });
            }
            catch (Exception ex)
            {
                IsTransectionSuccess = false;
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert(ex.Message, null, "OK");
                Console.Write("Payment Gatway" + ex.Message);
            }
            finally
            {
                if (IsTransectionSuccess)
                {
                    Console.Write("Payment Gateway" + "Payment Successful ");
                    var request = new RacunUpdateRequest
                    {
                        IsPlatio = true
                    };


                    
                    var entity = await _service.Update<Racun>(Racun.RacunId, request); // treba id pokupit sa odabranog racuna



                    UserDialogs.Instance.Alert("Uspješno ste izvršili uplatu", "OK", "OK");
                    UserDialogs.Instance.HideLoading();

                    var stringCode = "PregledId=" + entity.PregledId + " / DoktorId=" + entity.KorisnikId +
                                     " / Uplaceno=" + entity.UkupnaCijena + " / DatumUplate=" +
                                     entity.DatumIzdavanjaRacuna + " / Pacijent=" + APIService.LogiraniKorisnik.Ime +
                                     " " + APIService.LogiraniKorisnik.Prezime;

                    await Navigation.PushAsync(new QRCodeGenerator(stringCode));
                    //await Navigation.PopAsync();
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.Alert("Uplata nije izvršena", "Greška", "OK");
                    Console.Write("Plaćanje" + "Uplata neuspješna ");
                }
            }

        });


        #endregion Command


        #region Method

        private string CreateToken()
        {
            try
            {
                StripeConfiguration.ApiKey = StripeTestApiKey;
                var service = new ChargeService();
                var Tokenoptions = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = KreditnaKartica.Broj,
                        ExpYear = KreditnaKartica.ExpYear,
                        ExpMonth = KreditnaKartica.ExpMonth,
                        Cvc = KreditnaKartica.Cvc,
                        Name = APIService.LogiraniKorisnik.Ime + " " + APIService.LogiraniKorisnik.Prezime,
                        AddressCity = APIService.LogiraniKorisnik.Grad.Naziv,
                        AddressCountry = APIService.LogiraniKorisnik.Grad.Drzava.Naziv,
                        Currency = "bam",
                    }
                };

                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(Tokenoptions);
                return stripeToken.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool MakePayment(string token)
        {
            try
            {
                StripeConfiguration.ApiKey = StripeTestApiKey;
                
                var options = new ChargeCreateOptions
                {
                    Amount = (long)Racun.UkupnaCijena * 100,
                    Currency = "bam",
                    Description = "Uplata na ime: " + APIService.LogiraniKorisnik.Ime + " " + APIService.LogiraniKorisnik.Prezime,

                    Source = stripeToken.Id,
                    StatementDescriptor = "Custom descriptor",
                    Capture = true,
                    ReceiptEmail = APIService.LogiraniKorisnik.Email,
                };

                var service = new ChargeService();
                Charge charge = service.Create(options);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("Payment Gatway (CreateCharge)" + ex.Message);
                throw ex;
            }
        }

        private bool ValidateCard()
        {
            if (KreditnaKartica.Broj.Length == 16 && ExpMonth.Length == 2 && ExpYear.Length == 2 && KreditnaKartica.Cvc.Length == 3)
            {
            }
            return true;
        }

        #endregion Method

    }
}
