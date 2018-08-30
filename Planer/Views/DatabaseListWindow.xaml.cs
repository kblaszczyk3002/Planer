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
    /// Interaction logic for DatabaseListWindow.xaml
    /// </summary>
    public partial class DatabaseListWindow : Window
    {
        private GlobalViewModel VM;

        public DatabaseListWindow()
        {
            InitializeComponent();
            VM = App.Current.Resources["GlobalViewModel"] as GlobalViewModel;
        }

        private void NowaBaza(object sender, RoutedEventArgs e)
        {
            VM._databaseListViewModel.DodajNowaBaze();
        }

        private void ChangeDatabase(object sender, RoutedEventArgs e)
        {
            VM._databaseListViewModel.PodlaczBaze();
        }

        private void DeleteDatabase(object sender, RoutedEventArgs e)
        {
            VM._databaseListViewModel.UsunBaze();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            VM._mainWindowViewModel.ZamknijListeBaz();
        }
    }
}
