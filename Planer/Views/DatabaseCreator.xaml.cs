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
    /// Interaction logic for DatabaseCreator.xaml
    /// </summary>
    public partial class DatabaseCreator : Window
    {
        private GlobalViewModel VM;

        public DatabaseCreator()
        {
            InitializeComponent();
            VM = App.Current.Resources["GlobalViewModel"] as GlobalViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VM._databaseCreatorViewModel.Zamknij();
            VM._databaseCreatorViewModel.KreujBaze(Haslo.Password);
        }
    }
}
