using Planer.Helpers;
using Planer.Models;
using Planer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Planer.ViewModels
{
    public class UsersListViewModel: WindowHelpers, INotifyPropertyChanged
    {
        private GlobalViewModel globalViewModel;

        public UserCardWindow _userCardWindow;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public User _uzytkownik;

        public ObservableCollection<User> _listaUzytkownikow { get; set; }

        public User SelectedUser
        {
            get
            {
                return _uzytkownik;
            }
            set
            {
                _uzytkownik = value;
                OnNotifyPropertyChanged("SelectedUser");
            }
        }

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
                return _uzytkownik.Acronym;
            }
            set
            {
                _uzytkownik.Acronym = value;
                OnNotifyPropertyChanged("Acronym");
            }
        }

        public string Name
        {
            get
            {
                return _uzytkownik.Name;
            }
            set
            {
                _uzytkownik.Name = value;
                OnNotifyPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get
            {
                return _uzytkownik.Surname;
            }
            set
            {
                _uzytkownik.Surname = value;
                OnNotifyPropertyChanged("Surname");
            }
        }

        public string eMail
        {
            get
            {
                return _uzytkownik.eMail;
            }
            set
            {
                _uzytkownik.eMail = value;
                OnNotifyPropertyChanged("eMail");
            }
        }

        public string PESEL
        {
            get
            {
                return _uzytkownik.PESEL;
            }
            set
            {
                _uzytkownik.PESEL = value;
                OnNotifyPropertyChanged("PESEL");
            }
        }

        public UsersListViewModel(GlobalViewModel _globalViewModel)
        {
            globalViewModel = _globalViewModel;

            _uzytkownik = new User();

            _listaUzytkownikow = new ObservableCollection<User>();
        }

        public void NowyUzytkownik()
        {
            _userCardWindow = new UserCardWindow(true, false, false);

            _userCardWindow.Show();

            globalViewModel._userCardViewModel.WypelnijListeWojewodztw();
        }

        public void EdytujUzytkownika()
        {
            User _edytowanyUzytkownik = new User();

            _edytowanyUzytkownik = globalViewModel._dataContext.Users.Find(SelectedUser.Id);

            _userCardWindow = new UserCardWindow(_edytowanyUzytkownik.Id, true);

            _userCardWindow.Show();
        }

        public void UsunUzytkownika()
        {
            User _deletedUser = globalViewModel._dataContext.Users.Find(SelectedUser.Id);

            if(_deletedUser == null)
            {
                MessageBox.Show("Nie wybrałeś użytkownika do usunięcia!");
            }
            else
            {
                MessageBoxResult _userDeletingMessage = MessageBox.Show("Czy chcesz usunąć wskazanego użytkownika?", "Usuwanie użytkownika", MessageBoxButton.YesNo);

                if(_userDeletingMessage == MessageBoxResult.Yes)
                {
                    globalViewModel._dataContext.Users.Remove(_deletedUser);

                    globalViewModel._dataContext.SaveChanges();

                    int recordCount;
                    int maxValue = 0;

                    recordCount = (from r in this.globalViewModel._dataContext.Users
                                   select r).Count();

                    if (recordCount > 0)

                        maxValue = (from d in this.globalViewModel._dataContext.Users
                                    select d.Id).Max();

                    this.globalViewModel._usersListViewModel.WypelnijListeUzytkownikow(maxValue);
                }
                else
                {
                    MessageBox.Show("Ok, nie to nie ...");
                }
            }
        }

        public void ZamknijKarteUzytkownika()
        {
            _userCardWindow.Close();
        }

        public void WypelnijListeUzytkownikow(int records)
        {
            if(records > 0)
            {
                _listaUzytkownikow.Clear();

                for(int i = 1; i <= records; i++)
                {
                    try
                    {
                        var singleUser = (from u in globalViewModel._dataContext.Users
                                          where u.Id == i
                                          select u).SingleOrDefault();

                        if (singleUser != null)
                        {
                            _listaUzytkownikow.Add(new User(singleUser.Id, singleUser.Acronym, singleUser.Password, singleUser.Name, singleUser.Surname, singleUser.eMail,
                                singleUser.PESEL, singleUser.Gender, singleUser.StreetName, singleUser.StreetNumber, singleUser.HouseNumber, singleUser.PostalCode,
                                singleUser.City, singleUser.Province, singleUser.ConfigAuthorization, singleUser.DatabaseManagerAuthorization, singleUser.IncomesAndExpensesListAuthorization,
                                singleUser.UsersListAuthorization, singleUser.IsAdmin, singleUser.ViewOtherUsersRecords, singleUser.DeletingOtherUsersRecords, singleUser.EditingOtherUsersRecords));
                        }
                    }
                    catch(Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString());
                    }
                }
            }
            else
            {
                _listaUzytkownikow.Clear();
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
