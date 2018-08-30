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
    /// Interaction logic for IncomesAndExpensesList.xaml
    /// </summary>
    public partial class IncomesAndExpensesList : Window
    {
        private GlobalViewModel VM;

        public IncomesAndExpensesList()
        {
            InitializeComponent();
            VM = App.Current.Resources["GlobalViewModel"] as GlobalViewModel;
        }

        private void DodajRekord(object sender, RoutedEventArgs e)
        {
            VM._incomesAndExpensesListViewModel.DodajRekord(true, false, false);
        }

        private void EdytujRekord(object sender, RoutedEventArgs e)
        {
            VM._incomesAndExpensesListViewModel.EdytujRekord(false, true, false);
        }

        private void UsunRekord(object sender, RoutedEventArgs e)
        {
            VM._incomesAndExpensesListViewModel.UsunRekord();
        }

        private void Previous(object sender, RoutedEventArgs e)
        {
            VM._incomesAndExpensesListViewModel.Btn_previousClick(TabIncomesAndExpensesList);
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            VM._incomesAndExpensesListViewModel.Btn_nextClick(TabIncomesAndExpensesList);
        }

        private void ListWindowClose(object sender, RoutedEventArgs e)
        {
            VM._mainWindowViewModel.ZamknijListePrzychodowIWydatkow();
        }
    }
}
