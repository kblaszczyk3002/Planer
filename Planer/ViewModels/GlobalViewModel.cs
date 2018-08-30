using Planer.DAL;
using Planer.Models;
using Planer.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Planer.ViewModels
{
    public class GlobalViewModel
    {
        public MainWindow _mainWindow;

        public AboutProgram _aboutProgram;

        public LogWindow _logWindow;

        public DataContext _dataContext;

        public IncomesAndExpensesList _incomesAndExpensesList;

        public DatabaseCreator _databaseCreator;

        public LoginWindow _loginWindow;

        public UserSession _actualUserSession;

        public MainWindowViewModel _mainWindowViewModel { get; set; }

        public AboutProgramViewModel _aboutProgramViewModel { get; set; }

        public IncomesAndExpensesListViewModel _incomesAndExpensesListViewModel { get; set; }

        public DatabaseCreatorViewModel _databaseCreatorViewModel { get; set; }

        public LogViewModel _logViewModel { get; set; }

        public IncomesAndExpensesRecordViewModel _incomesAndExpensesRecordViewModel { get; set; }

        public LoginWindowViewModel _loginWindowViewModel { get; set; }

        public DatabaseListViewModel _databaseListViewModel { get; set; }

        public ConfigurationViewModel _configurationViewModel { get; set; }

        public UsersListViewModel _usersListViewModel { get; set; }

        public UserCardViewModel _userCardViewModel { get; set; }

        internal void AppStart()
        {

            _logWindow = new LogWindow();

            _loginWindow = new LoginWindow();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Entities"].ConnectionString);

            if(conn.Database.ToString() == "")
            {
                MessageBox.Show("Z racji tego, że uruchamiasz aplikację po raz pierwszy, zostaniesz przeniesiony do kreatora nowej bazy danych. W oknie kreatora będziesz mógł wpisać nazwę dla nowo utworzonej bazy, na której rozpoczniesz pracę z programem");

                _databaseListViewModel.DodajNowaBaze();
            }
            else
            {
                _loginWindow.Show();

                _actualUserSession = new UserSession();
            }

        }

        public void KreujSesjeUzytkownika(int _userId)
        {
            string _userAcronym = (from a in _dataContext.Users
                                   where a.Id == _userId
                                   select a.Acronym).SingleOrDefault();

            _actualUserSession = new UserSession(_actualUserSession.Id, _userId, _userAcronym, DateTime.Now, new DateTime(1, 1, 1));

            try
            {
                _dataContext.UsersSessions.Add(_actualUserSession);

                _dataContext.SaveChanges();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }

        public UserSession PobierzSesjeUzytkownika()
        {
            return _actualUserSession;
        }

        public void UruchomStroneGlowna()
        {
            _mainWindow = new MainWindow();

            _mainWindow.Show();
        }

        public void ZamknijStroneGlowna()
        {
            _mainWindow.Close();
        }

        public void UruchomInfoOProgramie()
        {
            _aboutProgram = new AboutProgram();

            _aboutProgram.ShowDialog();
        }

        public void ZamknijInfoOProgramie()
        {
            _aboutProgram.Close();
        }

        public void UruchomLog()
        {
            _logWindow.Show();
        }

        public void ZamknijLog()
        {
            _logWindow.Close();
        }

        //public void ZakonczSesjeUzytkownika()
        //{
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Entities"].ConnectionString);

        //    string updateQuerry = "UPDATE UsersSession SET SessionEnd = " + DateTime.Now.ToString() + " WHERE Id = " + _actualUserSession.Id.ToString();

        //    SqlCommand updateSessionCommand = new SqlCommand(updateQuerry, con);

        //    updateSessionCommand.ExecuteNonQuery();
        //}

        public void ZamknijAplikacje()
        {
            Application.Current.Shutdown();
        }

        public GlobalViewModel()
        {

            _dataContext = new DataContext();

            _mainWindowViewModel = new MainWindowViewModel(this);

            _aboutProgramViewModel = new AboutProgramViewModel(this);

            _incomesAndExpensesListViewModel = new IncomesAndExpensesListViewModel(this);

            _databaseCreatorViewModel = new DatabaseCreatorViewModel(this);

            _logViewModel = new LogViewModel(this);

            _incomesAndExpensesRecordViewModel = new IncomesAndExpensesRecordViewModel(this);

            _loginWindowViewModel = new LoginWindowViewModel(this);

            _databaseListViewModel = new DatabaseListViewModel(this);

            _configurationViewModel = new ConfigurationViewModel(this);

            _usersListViewModel = new UsersListViewModel(this);

            _userCardViewModel = new UserCardViewModel(this);
        }
    }
}
