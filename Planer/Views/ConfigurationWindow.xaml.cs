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
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        private GlobalViewModel VM;

        public ConfigurationWindow()
        {
            InitializeComponent();

            VM = App.Current.Resources["GlobalViewModel"] as GlobalViewModel;
        }

        private void PreviousTab(object sender, RoutedEventArgs e)
        {
            VM._configurationViewModel.Btn_previousClick(TabConfig);
        }

        private void NextTab(object sender, RoutedEventArgs e)
        {
            VM._configurationViewModel.Btn_nextClick(TabConfig);
        }

        public void Close(object sender, RoutedEventArgs e)
        {
            VM._mainWindowViewModel.ZamknijKonfiguracje();
        }

        public void Save(object sender, RoutedEventArgs e)
        {
            VM._configurationViewModel.ZapiszKonfiguracje();
        }
    }
}
