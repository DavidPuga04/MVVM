using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    class CambiodivisasViewModel : INotifyPropertyChanged
    {
        private string _valorUSD;
        private string _valorEUR;

        public string ValorUSD { 
            get=>_valorUSD;
            set{
                if (_valorUSD != value)
                {
                    _valorUSD = value;
                    OnPropertyChanged();
                    CambiarDeDolaresAEuros();
                }
            }
        }

        public string ValorEUR
        {
            get => _valorEUR;
            set
            {
                if (_valorEUR != value)
                {
                    _valorEUR = value;
                    OnPropertyChanged();
                    //CambiarEurosADolares();
                }
            }
        }

        public ICommand ComandoReiniciarValores { get; set; }

        public CambiodivisasViewModel()
        {
            ComandoReiniciarValores = new Command(async ()=> await ReiniciarValores());
        }

        public async Task ReiniciarValores()
        {
            ValorUSD = "0";
            ValorEUR = "0";
        }

        public void CambiarDeDolaresAEuros()
        {
            if (double.TryParse(ValorUSD, out double dolares))
            {
                double euros = dolares * 0.87;
                ValorEUR = euros.ToString("0.00");
            }
            else
            {
                ValorEUR = "0.00";
            }
        }


        public void CambiarEurosADolares()
        {
            if (double.TryParse(ValorEUR, out double euros))
            {
                double dolares = euros * 1.15;
                ValorUSD = dolares.ToString("0.00");
            }
            else
            {
                ValorUSD = "0.00";
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
