using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StomatoloskaOrdinacija.Model;
using Xamarin.Forms;

namespace StomatoloskaOrdinacija.ViewModels
{
    public class TerminiViewModel
    {
        private readonly APIService _terminiService = new APIService("Termin");
        public TerminiViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Termin> TerminiList { get; set; } = new ObservableCollection<Termin>();
        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var list = await _terminiService.GetAll<IList<Model.Termin>>(null);

            TerminiList.Clear();
            foreach (var termin in list)
            {
                TerminiList.Add(termin);
            }
        }
    }
}
