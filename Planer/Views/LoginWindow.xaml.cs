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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private GlobalViewModel VM;

        public LoginWindow()
        {
            InitializeComponent();

            VM = App.Current.Resources["GlobalViewModel"] as GlobalViewModel;
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            VM._loginWindowViewModel.Zaloguj(Pass.Password);
        }

        private void ZamknijProgram(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VM.ZamknijAplikacje();
        }
    }
}
