using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planer.ViewModels
{
    public class LoginWindowViewModel : INotifyPropertyChanged
    {
        internal GlobalViewModel globalViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string _login { get; set; }

        public bool _passValid { get; set; }

        public bool validation;

        public bool PassValid
        {
            get
            {
                return _passValid;

            }
            set
            {
                _passValid = value;
                OnNotifyPropertyChanged("PassValid");
            }
        }

        public LoginWindowViewModel(GlobalViewModel _globalViewModel)
        {
            globalViewModel = _globalViewModel;
        }

        public bool ValidateUser(string _pass)
        {
            if(_login != null && _pass != null)
            {
                string encodedPassword = SzyfrujHaslo(_pass);

                var login = (from l in globalViewModel._dataContext.Users
                             where l.Acronym == _login && l.Password == encodedPassword
                             select l.Id).SingleOrDefault();

                if (login == 0)
                {
                    return false;
                }
                else
                {
                    globalViewModel.KreujSesjeUzytkownika(login);

                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        public void Zaloguj(string _password)
        {

            validation = ValidateUser(_password);

            if(validation == true)
            {
                PassValid = false;

                globalViewModel._loginWindow.Close();

                globalViewModel.UruchomStroneGlowna();
            }
            else
            {
                PassValid = true;
            }
        }

        public string SzyfrujHaslo(string value)
        {
            var hash = System.Security.Cryptography.SHA1.Create();
            var encoder = new System.Text.ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");

        }
    }
}
