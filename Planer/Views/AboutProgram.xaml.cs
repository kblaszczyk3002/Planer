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
    /// Interaction logic for AboutProgram.xaml
    /// </summary>
    public partial class AboutProgram : Window
    {
        private GlobalViewModel VM;
        public AboutProgram()
        {
            InitializeComponent();
            VM = App.Current.Resources["GlobalViewModel"] as GlobalViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VM._aboutProgramViewModel.Zamknij();
        }
    }
}
