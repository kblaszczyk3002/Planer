using Planer.Models;
using Planer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Planer.ViewModels
{
    public class DatabaseCreatorViewModel : INotifyPropertyChanged
    {
        internal GlobalViewModel globalViewModel;

        public Polaczenie _conn;

        public string _server { get; set; }

        public string _database { get; set; }

        public string _login { get; set; }

        public string _pass { private get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public DatabaseCreatorViewModel(GlobalViewModel _globalViewModel)
        {
            globalViewModel = _globalViewModel;
        }

        public void KreujBaze(string _password)
        {
            SqlConnection _connection = new SqlConnection(@"Server=" + _server + ";User ID=" + _login + ";Password=" + _password);

            string createDatabase = "CREATE DATABASE " + "[" + _database.ToString() + "]";

            string dropDatabase = "DROP DATABASE " + "[" + _database.ToString() + "]";

            string createTableAppConfiguration = "USE [" + _database.ToString() + "]" +
                "CREATE TABLE AppConfiguration " +
                "([Id]  INT IDENTITY (1,1) NOT NULL, [UseStrongPass] BIT NULL, PRIMARY KEY CLUSTERED ([Id] ASC))";

            string createTableUsers = "USE [" + _database.ToString() + "]" +
                "CREATE TABLE Users" +
                "([Id] INT IDENTITY(1, 1) NOT NULL, [Acronym] VARCHAR(20) NULL, [Password] VARCHAR(35) NULL, [Name] VARCHAR(20) NULL, [Surname] VARCHAR(35) NULL" +
                ", [eMail] VARCHAR(30) NULL, [PESEL] VARCHAR(15) NULL, [Gender] TINYINT NULL, [StreetName] VARCHAR(35) NULL, [StreetNumber] VARCHAR(10) NULL" +
                ", [HouseNumber] VARCHAR(8) NULL, [PostalCode] VARCHAR(8) NULL, [City] VARCHAR(20) NULL, [Province] VARCHAR(25) NULL, [ConfigAuthorization] BIT NULL" +
                ", [DatabaseManagerAuthorization] BIT NULL, [IncomesAndExpensesListAuthorization] BIT NULL, [UsersListAuthorization] BIT NULL, [IsAdmin] BIT NULL" +
                ", [ViewOtherUsersRecords] BIT NULL, [DeletingOtherUsersRecords] BIT NULL, [EditingOtherUsersRecords] BIT NULL" +
                ", PRIMARY KEY CLUSTERED([Id] ASC));";

            string createPredefinedUser = "USE [" + _database.ToString() + "]" +
                "INSERT INTO Users " +
                "([Acronym], [Password], [Name], [Surname] " +
                ", [eMail], [PESEL], [Gender], [StreetName], [StreetNumber] " +
                ", [HouseNumber], [PostalCode], [City], [Province], [ConfigAuthorization] " +
                ", [DatabaseManagerAuthorization], [IncomesAndExpensesListAuthorization], [UsersListAuthorization], [IsAdmin] " +
                ", [ViewOtherUsersRecords], [DeletingOtherUsersRecords], [EditingOtherUsersRecords]) " +
                "VALUES " +
                "('ADMIN', '', 'Administrator', 'Systemu' " +
                ", '', '', 1, '', '' " +
                ", '', '', '', '', 1 " +
                ", 1, 1, 1, 1 " +
                ", 1, 1, 1) ";

            string createTableUsersSessions = "USE [" + _database.ToString() + "]" +
                "CREATE TABLE UsersSessions " +
                "([Id] INT IDENTITY(1,1) NOT NULL, [UserId] INT NULL, [UserAcronym] VARCHAR(50) NULL, [SessionStart] DateTime2 NULL, [SessionEnd] DateTime2 NULL" +
                ", PRIMARY KEY CLUSTERED([Id] ASC));";

            string createTableIncomesAndExpenses = " USE [" + _database.ToString() + "]" +
            " CREATE TABLE IncomesAndExpenses" +
            " ([Id]     INT       IDENTITY (1, 1) NOT NULL, [UserId] INT NULL, [ReportDate] DateTime2 NULL, [Salary] DECIMAL(15,2) NULL, [Training] DECIMAL(15,2) NULL, [Bonus] DECIMAL(15,2) NULL" +
            ", AdditionalBenefits DECIMAL(15,2) NULL, Painting DECIMAL(15,2) NULL, ComputerProgramming DECIMAL(15,2) NULL, Service DECIMAL(15,2) NULL" +
            ", OtherCommissionIncomes DECIMAL(15,2) NULL, AllegroSales DECIMAL(15,2) NULL, EBaySales DECIMAL(15,2) NULL, MiniaturesSales DECIMAL(15,2) NULL" +
            ", OtherSalesIncomes DECIMAL(15,2) NULL, MoneyFromFamily DECIMAL(15,2) NULL, Lottery DECIMAL(15,2) NULL, Inheritance DECIMAL(15,2) NULL" +
            ", OtherPresentsIncomes DECIMAL(15,2) NULL, OtherIncomes DECIMAL(15,2) NULL, Vegetables DECIMAL(15,2) NULL, Fruit DECIMAL(15,2) NULL, Sweets DECIMAL(15,2) NULL" +
            ", JunkFood DECIMAL(15,2) NULL, DinnerIngredients DECIMAL(15,2) NULL, BreakfastIngredients DECIMAL(15,2) NULL, Multisport DECIMAL(15,2) NULL, DanceCourse DECIMAL(15,2) NULL" +
            ", Supplements DECIMAL(15,2) NULL, Water DECIMAL(15,2) NULL, Rent DECIMAL(15,2) NULL, Internet DECIMAL(15,2) NULL, FlatRepairs DECIMAL(15,2) NULL" +
            ",OtherFlatExpenses DECIMAL(15,2) NULL, MonthlyPublicTransportTicket DECIMAL(15,2) NULL, BusTickets DECIMAL(15,2) NULL, TrainTickets DECIMAL(15,2) NULL" +
            ", Gas DECIMAL(15,2) NULL, Telephone DECIMAL(15,2) NULL, Cinema DECIMAL(15,2) NULL, Theatre DECIMAL(15,2) NULL, Presents DECIMAL(15,2) NULL" +
            ", Alcohol DECIMAL(15,2) NULL, OtherBeverages DECIMAL(15,2) NULL, OtherPartyExpenses DECIMAL(15,2) NULL, SumWorkIncomes DECIMAL(15,2) NULL" +
            ", SumOtherWorkIncomes DECIMAL(15,2) NULL, SumSalesIncomes DECIMAL(15,2) NULL, SumPresentsIncomes DECIMAL(15,2) NULL, SumFoodExpenses DECIMAL(15,2) NULL" +
            ", SumSportExpenses DECIMAL(15,2) NULL, SumFlatExpenses DECIMAL(15,2) NULL, SumTransportExpenses DECIMAL(15,2) NULL, SumPartyExpenses DECIMAL(15,2) NULL" +
            ",PRIMARY KEY CLUSTERED ([Id] ASC));";

            SqlCommand databaseCreateCommand = new SqlCommand(createDatabase, _connection);

            SqlCommand tableAppConfigurationCreateCommand = new SqlCommand(createTableAppConfiguration, _connection);

            SqlCommand tableUsersCreateCommand = new SqlCommand(createTableUsers, _connection);

            SqlCommand predefindUserCreateCommand = new SqlCommand(createPredefinedUser, _connection);

            SqlCommand tableUsersSessionsCreateCommand = new SqlCommand(createTableUsersSessions, _connection);

            SqlCommand tableIncomesAndExpensesCreateCommand = new SqlCommand(createTableIncomesAndExpenses, _connection);

            SqlCommand dropDatabaseCommand = new SqlCommand(dropDatabase, _connection);

            globalViewModel.UruchomLog();

            _connection.Open();

            try
            {
                globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "informacja", Tresc = "Kreacja bazy danych." });

                databaseCreateCommand.ExecuteNonQuery();

                globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "Informacja", Tresc = "Kreacja tabeli AppConfiguration" });

                tableAppConfigurationCreateCommand.ExecuteNonQuery();

                globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "Informacja", Tresc = "Kreacja tabeli Users" });

                tableUsersCreateCommand.ExecuteNonQuery();

                globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "Informacja", Tresc = "Kreacja predefiniowanego użytkownika ADMIN" });

                predefindUserCreateCommand.ExecuteNonQuery();

                globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "Informacja", Tresc = "Kreacja tabeli UsersSessions" });

                tableUsersSessionsCreateCommand.ExecuteNonQuery();

                globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "informacja", Tresc = " Kreacja tabeli IncomesAndExpenses." });

                tableIncomesAndExpensesCreateCommand.ExecuteNonQuery();

                globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "informacja", Tresc = "Pomyślnie zakonczono kreację bazy danych" });

                DialogResult message = MessageBox.Show("Baza wykreowana. Czy chciał byś ją teraz podłaczyć w celu rozpoczęcia pracy?", "Podłączanie bazy", MessageBoxButtons.YesNo);

                if(message == DialogResult.Yes)
                {
                    globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "informacja", Tresc = "Podłączanie nowej bazy danych" });

                    try
                    {

                        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                        connectionStringsSection.ConnectionStrings["Entities"].ConnectionString = "data source=chupakomputer; initial catalog=" + _database.ToString() + "; user id=sa; password=wknpim21DD; Asynchronous Processing=true";
                        config.Save();
                        ConfigurationManager.RefreshSection("connectionStrings");
                    }
                    catch(Exception Ex)
                    {
                        globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "błąd", Tresc = Ex.ToString() });

                        globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "błąd", Tresc = "Nie udało się podłączyć bazy danych" });
                    }

                    globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "informacja", Tresc = "Podłączono bazę danych" });

                    Thread.Sleep(500);

                    DialogResult databaseChangedMessage = MessageBox.Show("Baza podłączona. W celu rozpoczęcia pracy konieczne jest ponowne uruchomienie aplikacji. Czy chciał byś ponownie uruchomić teraz/", "Ponowne uruchomienie", MessageBoxButtons.YesNo);

                    if(databaseChangedMessage == DialogResult.Yes)
                    {
                        globalViewModel._mainWindowViewModel.Zamknij();
                        System.Windows.Forms.Application.Restart();
                    }
                }
                else
                {
                    globalViewModel._databaseListViewModel.GetDatabaseList();
                }
            }

            catch(Exception Ex)
            {
                globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "błąd", Tresc = Ex.ToString() });

                globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "błąd", Tresc = "Kreacja bazy przebiegła z błędem" });

                globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "informacja", Tresc = "Próba usunięcia bazy z serwera" });

                try
                {
                    dropDatabaseCommand.ExecuteNonQuery();
                }
                catch(Exception _exception)
                {
                    globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "błąd", Tresc = _exception.ToString() });
                    globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "błąd", Tresc = "Nie powiodła się próba bazy z serwera. Zalecane ręczne usunięcie bazy z serwera." });

                    globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "informacja", Tresc = "Zakończono kreację bazy danych." });
                }

                globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "informacja", Tresc = "Usunięto bazę z serwera." });

                globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "informacja", Tresc = "Zakończono kreację bazy danych." });
            }
            finally
            {
                _connection.Close();
            }

        }

        public void Zamknij()
        {
            this.globalViewModel._databaseListViewModel.ZamknijKreatorBazy();
        }
    }
}
