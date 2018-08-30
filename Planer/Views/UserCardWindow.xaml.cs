using Planer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Planer.Views
{
    /// <summary>
    /// Interaction logic for UserCardWindow.xaml
    /// </summary>
    public partial class UserCardWindow : Window
    {
        private GlobalViewModel VM;

        public UserCardWindow(bool createMode, bool editMode, bool viewMode)
        {
            InitializeComponent();

            VM = App.Current.Resources["GlobalViewModel"] as GlobalViewModel;
            VM._userCardViewModel.CreateMode = createMode;
            VM._userCardViewModel.EditMode = editMode;
            VM._userCardViewModel.ViewMode = viewMode;

            VM._userCardViewModel.Acronym = " ";
            VM._userCardViewModel.Name = " ";
            VM._userCardViewModel.Surname = " ";
            VM._userCardViewModel.Password = " ";
            VM._userCardViewModel.PESEL = " ";
            VM._userCardViewModel.eMail = " ";
            VM._userCardViewModel.City = " ";
            VM._userCardViewModel.Province = " ";
            VM._userCardViewModel.PostalCode = " ";
            VM._userCardViewModel.ConfigAuthorization = false;
            VM._userCardViewModel.DatabaseManagerAuthorization = false;
            VM._userCardViewModel.DeletingOtherUsersRecords = false;
            VM._userCardViewModel.EditingOtherUsersRecords = false;
            VM._userCardViewModel.HouseNumber = " ";
            VM._userCardViewModel.StreetName = " ";
            VM._userCardViewModel.StreetNumber = " ";
            VM._userCardViewModel.ViewOtherUsersRecords = false;
            VM._userCardViewModel.UsersListAuthorization = false;
            VM._userCardViewModel.IncomesAndExpensesListAuthorization = false;
            VM._userCardViewModel.Gender = 1;
            VM._userCardViewModel.IsAdmin = false;
        }

        public UserCardWindow(int ID, bool editMode)
        {
            InitializeComponent();

            VM = App.Current.Resources["GlobalViewModel"] as GlobalViewModel;

            var _pass = (from p in VM._dataContext.Users
                         where p.Id == ID
                         select p.Password).SingleOrDefault();

            haslo.Password = _pass;

            VM._userCardViewModel.WypelnijListeWojewodztw();

            VM._userCardViewModel.EdycjaUzytkownika(ID, editMode);
        }

        private void PreviousTab(object sender, RoutedEventArgs e)
        {
            VM._userCardViewModel.Btn_previousClick(TabUserCard);
        }

        private void NextTab(object sender, RoutedEventArgs e)
        {
            VM._userCardViewModel.Btn_nextClick(TabUserCard);
        }

        public void Close(object sender, RoutedEventArgs e)
        {
            VM._usersListViewModel.ZamknijKarteUzytkownika();
        }

        public void Save(object sender, RoutedEventArgs e)
        {
            VM._userCardViewModel.Zatwierdz(haslo.Password);
        }
    }
}
