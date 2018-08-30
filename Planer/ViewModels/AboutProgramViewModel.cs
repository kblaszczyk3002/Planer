using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Planer.ViewModels
{
    public class AboutProgramViewModel : INotifyPropertyChanged
    {
        internal GlobalViewModel _globalViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public AboutProgramViewModel(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }

        public void Zamknij()
        {
            this._globalViewModel.ZamknijInfoOProgramie();
        }
    }
}
