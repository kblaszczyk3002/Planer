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
    /// Interaction logic for UsersListWindow.xaml
    /// </summary>
    public partial class UsersListWindow : Window
    {
        private GlobalViewModel VM;

        public UsersListWindow()
        {
            InitializeComponent();

            VM = App.Current.Resources["GlobalViewModel"] as GlobalViewModel;
        }

        private void DodajRekord(object sender, RoutedEventArgs e)
        {
            VM._usersListViewModel.NowyUzytkownik();
        }

        private void EdytujRekord(object sender, RoutedEventArgs e)
        {
            VM._usersListViewModel.EdytujUzytkownika();
        }

        private void UsunRekord(object sender, RoutedEventArgs e)
        {
            VM._usersListViewModel.UsunUzytkownika();
        }

        private void PreviousTab(object sender, RoutedEventArgs e)
        {
            VM._usersListViewModel.Btn_previousClick(TabUsersList);
        }

        private void NextTab(object sender, RoutedEventArgs e)
        {
            VM._usersListViewModel.Btn_nextClick(TabUsersList);
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            VM._mainWindowViewModel.ZamknijListeUzytkownikow();
        }
    }
}
