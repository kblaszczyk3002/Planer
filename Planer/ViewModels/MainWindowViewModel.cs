using Planer.Models;
using Planer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Planer.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        internal GlobalViewModel globalViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public IncomesAndExpensesList incomesAndExpensesList;

        public DatabaseListWindow _databaseListWindow;

        public ConfigurationWindow _configurationWindow;

        public UsersListWindow _usersListWindow;

        public UserSession _actualUserSession;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindowViewModel(GlobalViewModel _globalViewModel)
        {
            globalViewModel = _globalViewModel;
        }

        public void InfoOProgramie()
        {
            //this.globalViewModel._mainWindow.Left = globalViewModel._mainWindow.Left + globalViewModel._mainWindow.Width / 4;
            //this.globalViewModel._mainWindow.Top = globalViewModel._mainWindow.Top + globalViewModel._mainWindow.Height / 4;

                try
                {
                this.globalViewModel.UruchomInfoOProgramie();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                }
        }

        public void ListaPrzychodowIWydatkow()
        {
            //this.globalViewModel._mainWindow.Left = globalViewModel._mainWindow.Left + globalViewModel._mainWindow.Width / 2;
            //this.globalViewModel._mainWindow.Top = globalViewModel._mainWindow.Top + globalViewModel._mainWindow.Height / 2;
        
            incomesAndExpensesList = new IncomesAndExpensesList();

            int recordCount;
            int maxValue = 0;

            incomesAndExpensesList.Show();

            //int sampleRecord = (from d in this.globalViewModel._dataContext.IncomesAndExpenses
            //                   select d.Id).SingleOrDefault();

            //if(sampleRecord > 0)

            //{
            recordCount = (from r in this.globalViewModel._dataContext.IncomesAndExpenses
                           select r).Count();

            if(recordCount > 0)

                maxValue = (from d in this.globalViewModel._dataContext.IncomesAndExpenses
                                   select d.Id).Max();

                this.globalViewModel._incomesAndExpensesListViewModel.FillList(maxValue);
            //}
        }

        public void ZamknijListePrzychodowIWydatkow()
        {
            incomesAndExpensesList.Close();
        }

        public void ListaBaz()
        {
            _databaseListWindow = new DatabaseListWindow();

            _databaseListWindow.Show();

            globalViewModel._databaseListViewModel.GetDatabaseList();
        }

        public void ZamknijListeBaz()
        {
            _databaseListWindow.Close();
        }

        public void OtworzKonfiguracje()
        {
            _configurationWindow = new ConfigurationWindow();

            _configurationWindow.ShowDialog();
        }

        public void ZamknijKonfiguracje()
        {
            _configurationWindow.Close();
        }
        public void ListaUzytkownikow()
        {
            int recordCount;
            int maxValue = 0;

            _usersListWindow = new UsersListWindow();

            _usersListWindow.Show();

            recordCount = (from r in this.globalViewModel._dataContext.Users
                           select r).Count();

            if (recordCount > 0)

                maxValue = (from d in this.globalViewModel._dataContext.Users
                            select d.Id).Max();

            globalViewModel._usersListViewModel.WypelnijListeUzytkownikow(maxValue);
        }

        public void ZamknijListeUzytkownikow()
        {
            _usersListWindow.Close();
        }

        public void Zamknij()
        {
            MessageBoxResult _message = MessageBox.Show("Czy chcesz zakonczyć pracę?", "Zamykanie aplikacji", MessageBoxButton.YesNo);

            if (_message == MessageBoxResult.Yes)
            {
                _actualUserSession = globalViewModel.PobierzSesjeUzytkownika();

                if(_actualUserSession != null)
                {

                    _actualUserSession.SessionEnd = DateTime.Now;

                    globalViewModel._dataContext.SaveChanges();

                    Application.Current.Shutdown();
                }
                else
                {
                    Application.Current.Shutdown();
                }

            }
        }
    }
}
