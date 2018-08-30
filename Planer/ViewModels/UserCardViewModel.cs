using Planer.Helpers;
using Planer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static Planer.Helpers.Provinces;

namespace Planer.ViewModels
{
    public class UserCardViewModel : WindowHelpers, INotifyPropertyChanged
    {
        private GlobalViewModel globalViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservableCollection<string> _listaWojewodztw { get; set; }

        public User _uzytkownik;

        public bool CreateMode { get; set; }
        public bool EditMode { get; set; }
        public bool ViewMode { get; set; }

        public int Id
        {
            get
            {
                return _uzytkownik.Id;
            }
            set
            {
                _uzytkownik.Id = value;
                OnNotifyPropertyChanged("Id");
            }
        }

        public string Acronym
        {
            get
            {
                //if(_uzytkownik.Acronym == null)
                //{
                //    return " ";
                //}
                //else
                //{
                    return _uzytkownik.Acronym;
                //}
            }
            set
            {
                //if(_uzytkownik.Acronym == null)
                //{
                //    _uzytkownik.Acronym = " ";
                //}
                //else
                //{
                    _uzytkownik.Acronym = value;
                    OnNotifyPropertyChanged("Acronym");
                //}
            }
        }

        public string Password
        {
            get
            {
                //if (_uzytkownik.Password == null)
                //{
                //    return " ";
                //}
                //else
                //{
                    return _uzytkownik.Password;
                //}
            }
            set
            {
                //if (_uzytkownik.Password == null)
                //{
                //    _uzytkownik.Password = " ";
                //}
                //else
                //{
                    _uzytkownik.Password = value;
                    OnNotifyPropertyChanged("Password");
                //}
            }
        }

        public string Name
        {
            get
            {
                //if (_uzytkownik.Name == null)
                //{
                //    return " ";
                //}
                //else
                //{
                    return _uzytkownik.Name;
                //}
            }
            set
            {
                //if (_uzytkownik.Name == null)
                //{
                //    _uzytkownik.Name = " ";
                //}
                //else
                //{
                    _uzytkownik.Name = value;
                    OnNotifyPropertyChanged("Name");
                //}
            }
        }

        public string Surname
        {
            get
            {
                //if (_uzytkownik.Surname == null)
                //{
                //    return " ";
                //}
                //else
                //{
                    return _uzytkownik.Surname;
                //}
            }
            set
            {
                //if (_uzytkownik.Surname == null)
                //{
                //    _uzytkownik.Surname = " ";
                //}
                //else
                //{
                    _uzytkownik.Surname = value;
                    OnNotifyPropertyChanged("Surname");
                //}
            }
        }

        public string eMail
        {
            get
            {
                //if (_uzytkownik.eMail == null)
                //{
                //    return " ";
                //}
                //else
                //{
                    return _uzytkownik.eMail;
                //}
            }
            set
            {
                //if (_uzytkownik.eMail == null)
                //{
                //    _uzytkownik.eMail = " ";
                //}
                //else
                //{
                    _uzytkownik.eMail = value;
                    OnNotifyPropertyChanged("eMail");
                //}
            }
        }

        public string PESEL
        {
            get
            {
                //if (_uzytkownik.PESEL == null)
                //{
                //    return " ";
                //}
                //else
                //{
                    return _uzytkownik.PESEL;
                //}
            }
            set
            {
                //if (_uzytkownik.PESEL == null)
                //{
                //    _uzytkownik.PESEL = " ";
                //}
                //else
                //{
                    _uzytkownik.PESEL = value;
                    OnNotifyPropertyChanged("PESEL");
                //}
            }
        }

        public byte Gender
        {
            get
            {
                if (_uzytkownik.Gender == 0)
                {
                    return 1;
                }
                else
                {
                    return _uzytkownik.Gender;
                }
            }
            set
            {
                if (_uzytkownik.Gender == 0)
                {
                    _uzytkownik.Gender = 1;
                }
                else
                {
                    _uzytkownik.Gender = value;
                    OnNotifyPropertyChanged("Gender");
                }
            }
        }

        public string StreetName
        {
            get
            {
                //if (_uzytkownik.StreetName == null)
                //{
                //    return " ";
                //}
                //else
                //{
                    return _uzytkownik.StreetName;
                //}
            }
            set
            {
                //if (_uzytkownik.StreetName == null)
                //{
                //    _uzytkownik.StreetName = " ";
                //}
                //else
                //{
                    _uzytkownik.StreetName = value;
                    OnNotifyPropertyChanged("StreetName");
                //}
            }
        }

        public string StreetNumber
        {
            get
            {
                //if (_uzytkownik.StreetNumber == null)
                //{
                //    return " ";
                //}
                //else
                //{
                    return _uzytkownik.StreetNumber;
                //}
            }
            set
            {
                //if (_uzytkownik.StreetNumber == null)
                //{
                //    _uzytkownik.StreetNumber = " ";
                //}
                //else
                //{
                    _uzytkownik.StreetNumber = value;
                    OnNotifyPropertyChanged("StreetNumber");
                //}
            }
        }

        public string HouseNumber
        {
            get
            {
                //if (_uzytkownik.HouseNumber == null)
                //{
                //    return " ";
                //}
                //else
                //{
                    return _uzytkownik.HouseNumber;
                //}
            }
            set
            {
                //if (_uzytkownik.HouseNumber == null)
                //{
                //    _uzytkownik.HouseNumber = " ";
                //}
                //else
                //{
                    _uzytkownik.HouseNumber = value;
                    OnNotifyPropertyChanged("HouseNumber");
                //}
            }
        }

        public string PostalCode
        {
            get
            {
                //if (_uzytkownik.PostalCode == null)
                //{
                //    return " ";
                //}
                //else
                //{
                    return _uzytkownik.PostalCode;
                //}
            }
            set
            {
                //if (_uzytkownik.PostalCode == null)
                //{
                //    _uzytkownik.PostalCode = " ";
                //}
                //else
                //{
                    _uzytkownik.PostalCode = value;
                    OnNotifyPropertyChanged("PostalCode");
                //}
            }
        }

        public string City
        {
            get
            {
                //if (_uzytkownik.City == null)
                //{
                //    return " ";
                //}
                //else
                //{
                    return _uzytkownik.City;
                //}
            }
            set
            {
                //if (_uzytkownik.City == null)
                //{
                //    _uzytkownik.City = " ";
                //}
                //else
                //{
                    _uzytkownik.City = value;
                    OnNotifyPropertyChanged("City");
                //}
            }
        }

        public string Province
        {
            get
            {
                if (_uzytkownik.Province == null)
                {
                    return " ";
                }
                else
                {
                    return _uzytkownik.Province;
                }
            }
            set
            {
                if (_uzytkownik.Province == null)
                {
                    _uzytkownik.Province = " ";
                }
                else
                {
                    _uzytkownik.Province = value;
                    OnNotifyPropertyChanged("Province");
                }
            }
        }

        public bool ConfigAuthorization
        {
            get
            {
                return _uzytkownik.ConfigAuthorization;
            }
            set
            {
                _uzytkownik.ConfigAuthorization = value;
                OnNotifyPropertyChanged("ConfigAuthorization");
            }
        }

        public bool DatabaseManagerAuthorization
        {
            get
            {
                return _uzytkownik.DatabaseManagerAuthorization;
            }
            set
            {
                _uzytkownik.DatabaseManagerAuthorization = value;
                OnNotifyPropertyChanged("DatabaseManagerAuthorization");
            }
        }

        public bool IncomesAndExpensesListAuthorization
        {
            get
            {
                return _uzytkownik.IncomesAndExpensesListAuthorization;
            }
            set
            {
                _uzytkownik.IncomesAndExpensesListAuthorization = value;
                OnNotifyPropertyChanged("IncomesAndExpensesListAuthorization");
            }
        }

        public bool UsersListAuthorization
        {
            get
            {
                return _uzytkownik.UsersListAuthorization;
            }
            set
            {
                _uzytkownik.UsersListAuthorization = value;
                OnNotifyPropertyChanged("UsersListAuthorization");
            }
        }

        public bool IsAdmin
        {
            get
            {
                return _uzytkownik.IsAdmin;
            }
            set
            {
                _uzytkownik.IsAdmin = value;
                OnNotifyPropertyChanged("IsAdmin");
            }
        }

        public bool ViewOtherUsersRecords
        {
            get
            {
                return _uzytkownik.ViewOtherUsersRecords;
            }
            set
            {
                _uzytkownik.ViewOtherUsersRecords = value;
                OnNotifyPropertyChanged("ViewOtherUsersRecords");
            }
        }

        public bool DeletingOtherUsersRecords
        {
            get
            {
                return _uzytkownik.DeletingOtherUsersRecords;
            }
            set
            {
                _uzytkownik.DeletingOtherUsersRecords = value;
                OnNotifyPropertyChanged("DeletingOtherUsersRecords");
            }
        }

        public bool EditingOtherUsersRecords
        {
            get
            {
                return _uzytkownik.EditingOtherUsersRecords;
            }
            set
            {
                _uzytkownik.EditingOtherUsersRecords = value;
                OnNotifyPropertyChanged("EditingOtherUsersRecords");
            }
        }

        public UserCardViewModel(GlobalViewModel _globalViewModel)
        {
            globalViewModel = _globalViewModel;

            _uzytkownik = new User();

            _listaWojewodztw = new ObservableCollection<string>();
        }

        public void Zatwierdz(string _pass)
        {
            try
            {
                if(EditMode == true)
                {
                    User _edytowanyUzytkownik = globalViewModel._dataContext.Users.Find(Id);

                    string encodedPass = globalViewModel._loginWindowViewModel.SzyfrujHaslo(_pass);

                    _edytowanyUzytkownik.Id = Id;
                    _edytowanyUzytkownik.Acronym = Acronym;
                    _edytowanyUzytkownik.Password = encodedPass;
                    _edytowanyUzytkownik.Name = Name;
                    _edytowanyUzytkownik.Surname = Surname;
                    _edytowanyUzytkownik.eMail = eMail;
                    _edytowanyUzytkownik.PESEL = PESEL;
                    _edytowanyUzytkownik.Gender = Gender;
                    _edytowanyUzytkownik.StreetName = StreetName;
                    _edytowanyUzytkownik.StreetNumber = StreetNumber;
                    _edytowanyUzytkownik.HouseNumber = HouseNumber;
                    _edytowanyUzytkownik.PostalCode = PostalCode;
                    _edytowanyUzytkownik.City = City;
                    _edytowanyUzytkownik.Province = Province;
                    _edytowanyUzytkownik.ConfigAuthorization = ConfigAuthorization;
                    _edytowanyUzytkownik.DatabaseManagerAuthorization = DatabaseManagerAuthorization;
                    _edytowanyUzytkownik.IncomesAndExpensesListAuthorization = IncomesAndExpensesListAuthorization;
                    _edytowanyUzytkownik.UsersListAuthorization = UsersListAuthorization;
                    _edytowanyUzytkownik.IsAdmin = IsAdmin;
                    _edytowanyUzytkownik.ViewOtherUsersRecords = ViewOtherUsersRecords;
                    _edytowanyUzytkownik.DeletingOtherUsersRecords = DeletingOtherUsersRecords;
                    _edytowanyUzytkownik.EditingOtherUsersRecords = EditingOtherUsersRecords;

                    if(globalViewModel._dataContext.Entry(_edytowanyUzytkownik).State == System.Data.Entity.EntityState.Modified)
                    {
                        MessageBoxResult _editMessage = MessageBox.Show("Czy chcesz zatwierdzić zmiany?", "Modyfikacja karty użytkownika", MessageBoxButton.YesNoCancel);
                        if(_editMessage == MessageBoxResult.Yes)
                        {
                            globalViewModel._dataContext.SaveChanges();

                            int recordCount = (from d in this.globalViewModel._dataContext.Users
                                               select d.Id).Max();

                            globalViewModel._usersListViewModel.WypelnijListeUzytkownikow(recordCount);

                            globalViewModel._usersListViewModel.ZamknijKarteUzytkownika();
                        }
                        else if(_editMessage == MessageBoxResult.No)
                        {
                            globalViewModel._usersListViewModel.ZamknijKarteUzytkownika();
                        }
                    }
                    else
                    {
                        globalViewModel._usersListViewModel.ZamknijKarteUzytkownika();
                    }

                }
                else
                {
                    User createdUser;

                    createdUser = new User(Id, Acronym, _pass, Name, Surname, eMail, PESEL, Gender, StreetName, StreetNumber, HouseNumber, PostalCode, City, Province,
                        ConfigAuthorization, DatabaseManagerAuthorization, IncomesAndExpensesListAuthorization, UsersListAuthorization, IsAdmin, ViewOtherUsersRecords,
                        DeletingOtherUsersRecords, EditingOtherUsersRecords);

                    globalViewModel._dataContext.Users.Add(_uzytkownik);

                    globalViewModel._dataContext.SaveChanges();

                    int recordCount = (from d in this.globalViewModel._dataContext.IncomesAndExpenses
                                       select d.Id).Max();

                    globalViewModel._usersListViewModel.WypelnijListeUzytkownikow(recordCount);

                    globalViewModel._usersListViewModel.ZamknijKarteUzytkownika();
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }

        public void EdycjaUzytkownika(int _userID, bool _editMode)
        {
            User _edytowanyUser = new User();

            _edytowanyUser = globalViewModel._dataContext.Users.Find(_userID);

            Id = _edytowanyUser.Id;
            Acronym = _edytowanyUser.Acronym;
            Name = _edytowanyUser.Name;
            Surname = _edytowanyUser.Surname;
            eMail = _edytowanyUser.eMail;
            PESEL = _edytowanyUser.PESEL;
            Gender = _edytowanyUser.Gender;
            StreetName = _edytowanyUser.StreetName;
            StreetNumber = _edytowanyUser.StreetNumber;
            HouseNumber = _edytowanyUser.HouseNumber;
            PostalCode = _edytowanyUser.PostalCode;
            City = _edytowanyUser.City;
            Province = _edytowanyUser.Province;
            ConfigAuthorization = _edytowanyUser.ConfigAuthorization;
            DatabaseManagerAuthorization = _edytowanyUser.DatabaseManagerAuthorization;
            IncomesAndExpensesListAuthorization = _edytowanyUser.IncomesAndExpensesListAuthorization;
            UsersListAuthorization = _edytowanyUser.UsersListAuthorization;
            IsAdmin = _edytowanyUser.IsAdmin;
            ViewOtherUsersRecords = _edytowanyUser.ViewOtherUsersRecords;
            DeletingOtherUsersRecords = _edytowanyUser.DeletingOtherUsersRecords;
            EditingOtherUsersRecords = _edytowanyUser.EditingOtherUsersRecords;

            EditMode = _editMode;
        }

        public void WypelnijListeWojewodztw()
        {
            var values = Enum.GetValues(typeof(Wojewodztwa)).Cast<Wojewodztwa>();

            foreach (var v in values)
            {
                _listaWojewodztw.Add(v.ToString());
            }
        }


        public override void Btn_previousClick(TabControl tcSample)
        {
            int newIndex = tcSample.SelectedIndex - 1;

            if (newIndex < 0)
                newIndex = tcSample.Items.Count - 1;
            tcSample.SelectedIndex = newIndex;
        }

        public override void Btn_nextClick(TabControl tcSample)
        {
            int newIndex = tcSample.SelectedIndex + 1;

            if (newIndex >= tcSample.Items.Count)
                newIndex = 0;
            tcSample.SelectedIndex = newIndex;
        }
    }
}
