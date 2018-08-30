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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Planer.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            VM = App.Current.Resources["GlobalViewModel"] as GlobalViewModel;
        }

        private GlobalViewModel VM;

        private void CloseApplication(object sender, RoutedEventArgs e)
        {
            VM._mainWindowViewModel.Zamknij();
        }

        private void AboutProgram(object sender, RoutedEventArgs e)
        {
            VM._mainWindowViewModel.InfoOProgramie();
        }

        private void IncomesAndExpensesList(object sender, RoutedEventArgs e)
        {
            VM._mainWindowViewModel.ListaPrzychodowIWydatkow();
        }

        private void DatabaseCreator(object sender, RoutedEventArgs e)
        {
            VM._databaseListViewModel.DodajNowaBaze();
        }

        private void Close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VM._mainWindowViewModel.Zamknij();
        }

        private void AddNewIncomesAndExpenses(object sender, RoutedEventArgs e)
        {
            VM._incomesAndExpensesListViewModel.DodajRekord(true, false, false);
        }

        private void DatabaseList(object sender, RoutedEventArgs e)
        {
            VM._mainWindowViewModel.ListaBaz();
        }

        private void AddNewUser(object sender, RoutedEventArgs e)
        {
            VM._usersListViewModel.NowyUzytkownik();
        }

        private void UsersList(object sender, RoutedEventArgs e)
        {
            VM._mainWindowViewModel.ListaUzytkownikow();
        }

        private void Configuration(object sender, RoutedEventArgs e)
        {
            VM._mainWindowViewModel.OtworzKonfiguracje();
        }
    }
}
