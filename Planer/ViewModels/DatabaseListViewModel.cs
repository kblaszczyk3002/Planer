using Planer.Models;
using Planer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planer.ViewModels
{
    public class DatabaseListViewModel : INotifyPropertyChanged
    {
        internal GlobalViewModel globalViewModel;

        public DatabaseCreator _databaseCreator;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public BazaDanych _bazaDanych;

        public ObservableCollection<BazaDanych> _databaseNamesList { get; set; }

        public BazaDanych SelectedRecord
        {
            get
            {
                return _bazaDanych;
            }
            set
            {
                _bazaDanych = value;
                OnPropertyChanged("SelectedRecord");
            }
        }

        public int ID
        {
            get
            {
                return _bazaDanych.Id;
            }
            set
            {
                _bazaDanych.Id = value;
                OnPropertyChanged("ID");
            }
        }

        public string DatabaseName
        {
            get
            {
                return _bazaDanych.NazwaBazy;
            }
            set
            {
                _bazaDanych.NazwaBazy = value;
                OnPropertyChanged("DatabaseName");
            }
        }

        public DatabaseListViewModel(GlobalViewModel _globalViewModel)
        {
            globalViewModel = _globalViewModel;

            _bazaDanych = new BazaDanych();

            _databaseNamesList = new ObservableCollection<BazaDanych>();
        }

        public void GetDatabaseList()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Entities"].ConnectionString))
                {
                    con.Open();

                    _databaseNamesList.Clear();


                    // Set up a command with the given query and associate
                    // this with the current connection.
                    using (SqlCommand cmd = new SqlCommand("select database_id, name from sys.databases where database_id > 6", con))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {

                                _bazaDanych = new BazaDanych();

                                if (_bazaDanych.Id != 0 && _bazaDanych.NazwaBazy != null)

                                    _bazaDanych.Id = dr.GetInt32(0);
                                    _bazaDanych.NazwaBazy = dr[1].ToString();

                                    _databaseNamesList.Add(_bazaDanych);
                            }

                            dr.Close();
                        }
                    }

                    con.Close();
                }
            }

            catch(Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }

        public void DodajNowaBaze()
        {
            _databaseCreator = new DatabaseCreator();

            _databaseCreator.ShowDialog();
        }

        public void PodlaczBaze()
        {

            DialogResult message = MessageBox.Show("Czy na pewno chcesz podłączyć wskazaną bazę?", "Podłączanie bazy", MessageBoxButtons.YesNo);

            if (message == DialogResult.Yes)
            {
                globalViewModel.UruchomLog();

                globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "informacja", Tresc = "Podłączanie nowej bazy danych" });

                try
                {

                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                    connectionStringsSection.ConnectionStrings["Entities"].ConnectionString = "data source=chupakomputer; initial catalog=" + _bazaDanych.NazwaBazy.ToString() + "; user id=sa; password=wknpim21DD; Asynchronous Processing=true";
                    config.Save();
                    ConfigurationManager.RefreshSection("connectionStrings");
                }
                catch (Exception Ex)
                {
                    globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "błąd", Tresc = Ex.ToString() });

                    globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "błąd", Tresc = "Nie udało się podłączyć bazy danych" });
                }

                globalViewModel._logViewModel.DodajTekst(new Komunikat() { TypKomunikatu = "informacja", Tresc = "Podłączono bazę danych" });

                DialogResult databaseChangedMessage = MessageBox.Show("Baza podłączona. W celu rozpoczęcia pracy konieczne jest ponowne uruchomienie aplikacji. Czy chciał byś ponownie uruchomić teraz/", "Ponowne uruchomienie", MessageBoxButtons.YesNo);

                if (databaseChangedMessage == DialogResult.Yes)
                {
                    globalViewModel._mainWindowViewModel.Zamknij();
                    System.Windows.Forms.Application.Restart();
                }
            }
        }

        public void UsunBaze()
        {
            if(_bazaDanych == null)
            {
                MessageBox.Show("Nie wybrałeś bazy do usunięcia");
            }
            else
            {
                DialogResult _deletingDatabase = MessageBox.Show("Czy chcesz usunąć zaznaczoną bazę?", "Usuwanie bazy", MessageBoxButtons.YesNo);

                if(_deletingDatabase == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Entities"].ConnectionString))
                        {
                            con.Open();

                            using (SqlCommand cmd = new SqlCommand(
                                " USE[master] " +
                               // " GO " +
                                " ALTER DATABASE " + "[" + _bazaDanych.NazwaBazy + "]" + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE " +
                               // " GO " +
                                " DROP DATABASE " + "[" + _bazaDanych.NazwaBazy + "]", con))
                            {
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Usunięto bazę");

                            }

                            con.Close();

                            globalViewModel._databaseListViewModel.GetDatabaseList();
                        }
                    }
                    catch(Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("To po chuj to kliknąłeś :P ");
                }

            }
        }

        public void ZamknijKreatorBazy()
        {
            _databaseCreator.Close();
        }
    }
}
