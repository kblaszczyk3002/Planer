using Planer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Planer.ViewModels
{
    public class LogViewModel : INotifyPropertyChanged
    {
        internal GlobalViewModel globalViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Komunikat msg;

        public ObservableCollection<Komunikat> Logs { get; set; }

        public string Tresc
        {
            get
            {
                if (msg.Tresc == null)
                {
                    return "";
                }
                else
                {
                    return msg.Tresc;
                }
            }
            set
            {
                msg.Tresc = value;
                OnPropertyChanged("Tresc");
            }
        }

        public string TypKomunikatu
        {
            get
            {
                return msg.TypKomunikatu;
            }
            set
            {
                msg.TypKomunikatu = value;
                OnPropertyChanged("TypKomunikatu");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public LogViewModel(GlobalViewModel _globalViewModel)
        {
            globalViewModel = _globalViewModel;

            msg = new Komunikat();

            Logs = new ObservableCollection<Komunikat>();
        }

        public void DodajTekst(Komunikat komunikat)
        {
            this.Logs.Add(new Komunikat() { TypKomunikatu = komunikat.TypKomunikatu, Tresc = komunikat.Tresc });
        }
    }
}
