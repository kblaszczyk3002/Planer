using Planer.Helpers;
using Planer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Planer.ViewModels
{
    public class IncomesAndExpensesRecordViewModel : WindowHelpers, INotifyPropertyChanged
    {
        private GlobalViewModel globalViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public IncomesAndExpenses _IncomesAndExpenses;

        public bool CreateMode { get; set; }
        public bool EditMode { get; set; }
        public bool ViewMode { get; set; }

        public UserSession actualUserSession;

        public Int32 Id
        {
            get
            {
                return _IncomesAndExpenses.Id;
            }
            set
            {
                _IncomesAndExpenses.Id = value;
                OnNotifyPropertyChanged("Id");
            }
        }

        public Nullable<Int32> UserId
        {
            get
            {
                return GetUserId();
            }
            set
            {
                //if(_IncomesAndExpenses.UserId == null)
                //{
                //    _IncomesAndExpenses.UserId = 1;
                //}
                //else
                //{
                    _IncomesAndExpenses.UserId = value;
                    OnNotifyPropertyChanged("UserId");
                //}
            }
        }
        public DateTime ReportDate
        {
            get
            {
                if (_IncomesAndExpenses.ReportDate == new DateTime(1,1,1))
                {
                    return DateTime.Now;
                }
                else
                {
                    return _IncomesAndExpenses.ReportDate;
                }
            }
            set
            {
                _IncomesAndExpenses.ReportDate = value;
                OnNotifyPropertyChanged("ReportDate");
            }
        }
        public Nullable<decimal> Salary
        {
            get
            {
                if(_IncomesAndExpenses.Salary == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Salary;
                }
            }
            set
            {
                if(_IncomesAndExpenses.Salary == null)
                {
                    _IncomesAndExpenses.Salary = 0.00m;
                }
                else
                {
                    _IncomesAndExpenses.Salary = value;
                    OnNotifyPropertyChanged("Salary");
                }
            }
        }
        public Nullable<decimal> Training
        {
            get
            {
                if(_IncomesAndExpenses.Training == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Training;
                }
            }
            set
            {
                _IncomesAndExpenses.Training = value;
                OnNotifyPropertyChanged("Training");
            }
        }
        public Nullable<decimal> Bonus
        {
            get
            {
                if(_IncomesAndExpenses.Bonus == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Bonus;
                }
            }
            set
            {
                _IncomesAndExpenses.Bonus = value;
                OnNotifyPropertyChanged("Bonus");
            }
        }
        public Nullable<decimal> AdditionalBenefits
        {
            get
            {
                if(_IncomesAndExpenses.AdditionalBenefits == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.AdditionalBenefits;
                }
            }
            set
            {
                _IncomesAndExpenses.AdditionalBenefits = value;
                OnNotifyPropertyChanged("AdditionalBenefits");
            }
        }
        public Nullable<decimal> Painting
        {
            get
            {
                if(_IncomesAndExpenses.Painting == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Painting;
                }
            }
            set
            {
                _IncomesAndExpenses.Painting = value;
                OnNotifyPropertyChanged("Painting");
            }
        }
        public Nullable<decimal> ComputerProgramming
        {
            get
            {
                if(_IncomesAndExpenses.ComputerProgramming == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.ComputerProgramming;
                }
            }
            set
            {
                _IncomesAndExpenses.ComputerProgramming = value;
                OnNotifyPropertyChanged("ComputerProgramming");
            }
        }
        public Nullable<decimal> Service
        {
            get
            {
                if(_IncomesAndExpenses.Service == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Service;
                }
            }
            set
            {
                _IncomesAndExpenses.Service = value;
                OnNotifyPropertyChanged("Service");
            }
        }
        public Nullable<decimal> OtherCommissionIncomes
        {
            get
            {
                if(_IncomesAndExpenses.OtherCommissionIncomes == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.OtherCommissionIncomes;
                }
            }
            set
            {
                _IncomesAndExpenses.OtherCommissionIncomes = value;
                OnNotifyPropertyChanged("OtherCommissionIncomes");
            }
        }
        public Nullable<decimal> AllegroSales
        {
            get
            {
                if (_IncomesAndExpenses.AllegroSales == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.AllegroSales;
                }
            }
            set
            {
                _IncomesAndExpenses.AllegroSales = value;
                OnNotifyPropertyChanged("AllegroSales");
            }
        }
        public Nullable<decimal> EBaySales
        {
            get
            {
                if(_IncomesAndExpenses.EBaySales == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.EBaySales;
                }
            }
            set
            {
                _IncomesAndExpenses.EBaySales = value;
                OnNotifyPropertyChanged("EBaySales");
            }
        }
        public Nullable<decimal> MiniaturesSales
        {
            get
            {
                if(_IncomesAndExpenses.MiniaturesSales == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.MiniaturesSales;
                }
            }
            set
            {
                _IncomesAndExpenses.MiniaturesSales = value;
                OnNotifyPropertyChanged("MiniaturesSales");
            }
        }
        public Nullable<decimal> OtherSalesIncomes
        {
            get
            {
                if(_IncomesAndExpenses.OtherSalesIncomes == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.OtherSalesIncomes;
                }
            }
            set
            {
                _IncomesAndExpenses.OtherSalesIncomes = value;
                OnNotifyPropertyChanged("OtherSalesIncomes");
            }
        }
        public Nullable<decimal> MoneyFromFamily
        {
            get
            {
                if(_IncomesAndExpenses.MoneyFromFamily == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.MoneyFromFamily;
                }
            }
            set
            {
                _IncomesAndExpenses.MoneyFromFamily = value;
                OnNotifyPropertyChanged("MoneyFromFamily");
            }
        }
        public Nullable<decimal> Lottery
        {
            get
            {
                if(_IncomesAndExpenses.Lottery == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Lottery;
                }
            }
            set
            {
                _IncomesAndExpenses.Lottery = value;
                OnNotifyPropertyChanged("Lottery");
            }
        }
        public Nullable<decimal> Inheritance
        {
            get
            {
                if(_IncomesAndExpenses.Inheritance == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Inheritance;
                }
            }
            set
            {
                _IncomesAndExpenses.Inheritance = value;
                OnNotifyPropertyChanged("Inheritance");
            }
        }
        public Nullable<decimal> OtherPresentsIncomes
        {
            get
            {
                if(_IncomesAndExpenses.OtherPresentsIncomes == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.OtherPresentsIncomes;
                }
            }
            set
            {
                _IncomesAndExpenses.OtherPresentsIncomes = value;
                OnNotifyPropertyChanged("OtherPresentsIncomes");
            }
        }
        public Nullable<decimal> OtherIncomes
        {
            get
            {
                if(_IncomesAndExpenses.OtherIncomes == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.OtherIncomes;
                }
            }
            set
            {
                _IncomesAndExpenses.OtherIncomes = value;
                OnNotifyPropertyChanged("OtherIncomes");
            }
        }
        public Nullable<decimal> Vegetables
        {
            get
            {
                if(_IncomesAndExpenses.Vegetables == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Vegetables;
                }
            }
            set
            {
                _IncomesAndExpenses.Vegetables = value;
                OnNotifyPropertyChanged("Vegetables");
            }
        }
        public Nullable<decimal> Fruit
        {
            get
            {
                if(_IncomesAndExpenses.Fruit == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Fruit;
                }
            }
            set
            {
                _IncomesAndExpenses.Fruit = value;
                OnNotifyPropertyChanged("Fruit");
            }
        }
        public Nullable<decimal> Sweets
        {
            get
            {
                if (_IncomesAndExpenses.Sweets == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Sweets;
                }
            }
            set
            {
                _IncomesAndExpenses.Sweets = value;
                OnNotifyPropertyChanged("Sweets");
            }
        }
        public Nullable<decimal> JunkFood
        {
            get
            {
                if (_IncomesAndExpenses.JunkFood == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.JunkFood;
                }
            }
            set
            {
                _IncomesAndExpenses.JunkFood = value;
                OnNotifyPropertyChanged("JunkFood");
            }
        }
        public Nullable<decimal> DinnerIngredients
        {
            get
            {
                if(_IncomesAndExpenses.DinnerIngredients == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.DinnerIngredients;
                }
            }
            set
            {
                _IncomesAndExpenses.DinnerIngredients = value;
                OnNotifyPropertyChanged("DinnerIngredients");
            }
        }
        public Nullable<decimal> BreakfastIngredients
        {
            get
            {
                if(_IncomesAndExpenses.BreakfastIngredients == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.BreakfastIngredients;
                }
            }
            set
            {
                _IncomesAndExpenses.BreakfastIngredients = value;
                OnNotifyPropertyChanged("BreakfastIngredients");
            }
        }
        public Nullable<decimal> Multisport
        {
            get
            {
                if(_IncomesAndExpenses.Multisport == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Multisport;
                }
            }
            set
            {
                _IncomesAndExpenses.Multisport = value;
                OnNotifyPropertyChanged("Multisport");
            }
        }
        public Nullable<decimal> DanceCourse
        {
            get
            {
                if(_IncomesAndExpenses.DanceCourse == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.DanceCourse;
                }
            }
            set
            {
                _IncomesAndExpenses.DanceCourse = value;
                OnNotifyPropertyChanged("DanceCourse");
            }
        }
        public Nullable<decimal> Supplements
        {
            get
            {
                if(_IncomesAndExpenses.Supplements == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Supplements;
                }
            }
            set
            {
                _IncomesAndExpenses.Supplements = value;
                OnNotifyPropertyChanged("Supplements");
            }
        }
        public Nullable<decimal> Water
        {
            get
            {
                if(_IncomesAndExpenses.Water == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Water;
                }
            }
            set
            {
                _IncomesAndExpenses.Water = value;
                OnNotifyPropertyChanged("Water");
            }
        }
        public Nullable<decimal> Rent
        {
            get
            {
                if(_IncomesAndExpenses.Rent == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Rent;
                }
            }
            set
            {
                _IncomesAndExpenses.Rent = value;
                OnNotifyPropertyChanged("Rent");
            }
        }
        public Nullable<decimal> Internet
        {
            get
            {
                if(_IncomesAndExpenses.Internet == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Internet;
                }
            }
            set
            {
                _IncomesAndExpenses.Internet = value;
                OnNotifyPropertyChanged("Internet");
            }
        }
        public Nullable<decimal> FlatRepairs
        {
            get
            {
                if(_IncomesAndExpenses.FlatRepairs == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.FlatRepairs;
                }
            }
            set
            {
                _IncomesAndExpenses.FlatRepairs = value;
                OnNotifyPropertyChanged("FlatRepairs");
            }
        }
        public Nullable<decimal> OtherFlatExpenses
        {
            get
            {
                if(_IncomesAndExpenses.OtherFlatExpenses == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.OtherFlatExpenses;
                }
            }
            set
            {
                _IncomesAndExpenses.OtherFlatExpenses = value;
                OnNotifyPropertyChanged("OtherFlatIncomes");
            }
        }
        public Nullable<decimal> MonthlyPublicTransportTicket
        {
            get
            {
                if(_IncomesAndExpenses.MonthlyPublicTransportTicket == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.MonthlyPublicTransportTicket;
                }
            }
            set
            {
                _IncomesAndExpenses.MonthlyPublicTransportTicket = value;
                OnNotifyPropertyChanged("MonthlyPublicTransportTicket");
            }
        }
        public Nullable<decimal> BusTickets
        {
            get
            {
                if(_IncomesAndExpenses.BusTickets == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.BusTickets;
                }
            }
            set
            {
                _IncomesAndExpenses.BusTickets = value;
                OnNotifyPropertyChanged("BusTickets");
            }
        }
        public Nullable<decimal> TrainTickets
        {
            get
            {
                if(_IncomesAndExpenses.TrainTickets == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.TrainTickets;
                }
            }
            set
            {
                _IncomesAndExpenses.TrainTickets = value;
                OnNotifyPropertyChanged("TrainTickets");
            }
        }
        public Nullable<decimal> Gas
        {
            get
            {
                if(_IncomesAndExpenses.Gas == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Gas;
                }
            }
            set
            {
                _IncomesAndExpenses.Gas = value;
                OnNotifyPropertyChanged("Gas");
            }
        }
        public Nullable<decimal> Telephone
        {
            get
            {
                if(_IncomesAndExpenses.Telephone == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Telephone;
                }
            }
            set
            {
                _IncomesAndExpenses.Telephone = value;
                OnNotifyPropertyChanged("Telephone");
            }
        }
        public Nullable<decimal> Cinema
        {
            get
            {
                if(_IncomesAndExpenses.Cinema == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Cinema;
                }
            }
            set
            {
                _IncomesAndExpenses.Cinema = value;
                OnNotifyPropertyChanged("Cinema");
            }
        }
        public Nullable<decimal> Theatre
        {
            get
            {
                if(_IncomesAndExpenses.Theatre == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Theatre;
                }
            }
            set
            {
                _IncomesAndExpenses.Theatre = value;
                OnNotifyPropertyChanged("Theatre");
            }

        }
        public Nullable<decimal> Presents
        {
            get
            {
                if(_IncomesAndExpenses.Presents == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Presents;
                }
            }
            set
            {
                _IncomesAndExpenses.Presents = value;
                OnNotifyPropertyChanged("Presents");
            }
        }
        public Nullable<decimal> Alcohol
        {
            get
            {
                if(_IncomesAndExpenses.Alcohol == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.Alcohol;
                }
            }
            set
            {
                _IncomesAndExpenses.Alcohol = value;
                OnNotifyPropertyChanged("Alcohol");
            }
        }
        public Nullable<decimal> OtherBeverages
        {
            get
            {
                if(_IncomesAndExpenses.OtherBeverages == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.OtherBeverages;
                }
            }
            set
            {
                _IncomesAndExpenses.OtherBeverages = value;
                OnNotifyPropertyChanged("OtherBeverages");
            }
        }
        public Nullable<decimal> OtherPartyExpenses
        {
            get
            {
                if(_IncomesAndExpenses.OtherPartyExpenses == null)
                {
                    return 0.00m;
                }
                else
                {
                    return _IncomesAndExpenses.OtherPartyExpenses;
                }
            }
            set
            {
                _IncomesAndExpenses.OtherPartyExpenses = value;
                OnNotifyPropertyChanged("OtherPartyExpenses");
            }
        }

        public IncomesAndExpensesRecordViewModel(GlobalViewModel _globalViewModel)
        {
            globalViewModel = _globalViewModel;

           // if(globalViewModel._incomesAndExpensesListViewModel._incomesAndExpensesRecord.CreateMode == true)
                 _IncomesAndExpenses  = new IncomesAndExpenses();
        }

        public int GetUserId()
        {
            actualUserSession = globalViewModel.PobierzSesjeUzytkownika();

            int userID = actualUserSession.UserId;

            return userID;
        }

        public void Zapisz()
        {
            try
            {
                if(EditMode == true)
                {
                    //IncomesAndExpenses _editableRecord = new IncomesAndExpenses();
                    IncomesAndExpenses _editableRecord = globalViewModel._dataContext.IncomesAndExpenses.Find(Id);

                    _editableRecord.Id = Id;
                    _editableRecord.UserId = UserId;
                    _editableRecord.ReportDate = ReportDate;
                    _editableRecord.Salary = Salary;
                    _editableRecord.Training = Training;
                    _editableRecord.Bonus = Bonus;
                    _editableRecord.AdditionalBenefits = AdditionalBenefits;
                    _editableRecord.Painting = Painting;
                    _editableRecord.ComputerProgramming = ComputerProgramming;
                    _editableRecord.Service = Service;
                    _editableRecord.OtherCommissionIncomes = OtherCommissionIncomes;
                    _editableRecord.AllegroSales = AllegroSales;
                    _editableRecord.EBaySales = EBaySales;
                    _editableRecord.MiniaturesSales = MiniaturesSales;
                    _editableRecord.OtherSalesIncomes = OtherSalesIncomes;
                    _editableRecord.MoneyFromFamily = MoneyFromFamily;
                    _editableRecord.Lottery = Lottery;
                    _editableRecord.Inheritance = Inheritance;
                    _editableRecord.OtherPresentsIncomes = OtherPresentsIncomes;
                    _editableRecord.OtherIncomes = OtherIncomes;
                    _editableRecord.Vegetables = Vegetables;
                    _editableRecord.Fruit = Fruit;
                    _editableRecord.Sweets = Sweets;
                    _editableRecord.JunkFood = JunkFood;
                    _editableRecord.BreakfastIngredients = BreakfastIngredients;
                    _editableRecord.DinnerIngredients = DinnerIngredients;
                    _editableRecord.Multisport = Multisport;
                    _editableRecord.DanceCourse = DanceCourse;
                    _editableRecord.Supplements = Supplements;
                    _editableRecord.Water = Water;
                    _editableRecord.Rent = Rent;
                    _editableRecord.Internet = Internet;
                    _editableRecord.FlatRepairs = FlatRepairs;
                    _editableRecord.OtherFlatExpenses = OtherFlatExpenses;
                    _editableRecord.MonthlyPublicTransportTicket = MonthlyPublicTransportTicket;
                    _editableRecord.BusTickets = BusTickets;
                    _editableRecord.TrainTickets = TrainTickets;
                    _editableRecord.Gas = Gas;
                    _editableRecord.Telephone = Telephone;
                    _editableRecord.Cinema = Cinema;
                    _editableRecord.Theatre = Theatre;
                    _editableRecord.Presents = Presents;
                    _editableRecord.Alcohol = Alcohol;
                    _editableRecord.OtherBeverages = OtherBeverages;
                    _editableRecord.OtherPartyExpenses = OtherPartyExpenses;

                    if (globalViewModel._dataContext.Entry(_editableRecord).State == System.Data.Entity.EntityState.Modified)
                    {
                        MessageBoxResult _message = MessageBox.Show("Czy zapisać zmiany?", "Powiadomienie o zapisie zmian", MessageBoxButton.YesNoCancel);
                        if(_message == MessageBoxResult.Yes)
                        {
                            globalViewModel._dataContext.SaveChanges();
                            int recordCount = (from d in this.globalViewModel._dataContext.IncomesAndExpenses
                                               select d.Id).Max();

                            globalViewModel._incomesAndExpensesListViewModel.FillList(recordCount);

                            globalViewModel._incomesAndExpensesListViewModel.SumIncomes = globalViewModel._incomesAndExpensesListViewModel.ZwrocSumePrzychodow();

                            globalViewModel._incomesAndExpensesListViewModel.SumExpenses = globalViewModel._incomesAndExpensesListViewModel.ZwrocSumeWydatkow();

                            globalViewModel._incomesAndExpensesListViewModel.ActualBudget = globalViewModel._incomesAndExpensesListViewModel.ZwrocAktualnyBudzet();

                            globalViewModel._incomesAndExpensesListViewModel._incomesAndExpensesRecord.Close();
                        }
                        else if(_message == MessageBoxResult.No)
                        {
                            globalViewModel._incomesAndExpensesListViewModel._incomesAndExpensesRecord.Close();
                        }
                    }
                    else
                    {
                        globalViewModel._incomesAndExpensesListViewModel._incomesAndExpensesRecord.Close();
                    }
                }
                else
                {
                    IncomesAndExpenses _newIncomesAndExpenses;

                    _newIncomesAndExpenses = new IncomesAndExpenses(Id, UserId, ReportDate, Salary, Training, Bonus, AdditionalBenefits, Painting, ComputerProgramming,
                     Service, OtherCommissionIncomes, AllegroSales, EBaySales, MiniaturesSales, OtherSalesIncomes, MoneyFromFamily, Lottery, Inheritance, OtherPresentsIncomes,
                     OtherIncomes, Vegetables, Fruit, Sweets, JunkFood, BreakfastIngredients, DinnerIngredients, Multisport, DanceCourse, Supplements, Water, Rent, Internet, FlatRepairs,
                     OtherFlatExpenses, MonthlyPublicTransportTicket, BusTickets, TrainTickets, Gas, Telephone, Cinema, Theatre, Presents, Alcohol, OtherBeverages,
                     OtherPartyExpenses, Salary + Training + Bonus + AdditionalBenefits, Painting + ComputerProgramming + Service + OtherCommissionIncomes,
                     AllegroSales + EBaySales + MiniaturesSales + OtherSalesIncomes, MoneyFromFamily + Lottery + Inheritance + OtherPresentsIncomes,
                     Vegetables + Fruit + Sweets + JunkFood + DinnerIngredients + BreakfastIngredients, Multisport + Supplements + Water + DanceCourse,
                     Rent + Internet + FlatRepairs + OtherFlatExpenses + Telephone, MonthlyPublicTransportTicket + BusTickets + TrainTickets + Gas,
                     Cinema + Theatre + Alcohol + OtherBeverages + OtherPartyExpenses);

                    globalViewModel._dataContext.IncomesAndExpenses.Add(_IncomesAndExpenses);

                    globalViewModel._dataContext.SaveChanges();

                    int recordCount = (from d in this.globalViewModel._dataContext.IncomesAndExpenses
                                       select d.Id).Max();

                    globalViewModel._incomesAndExpensesListViewModel.FillList(recordCount);

                    globalViewModel._incomesAndExpensesListViewModel.SumIncomes = globalViewModel._incomesAndExpensesListViewModel.ZwrocSumePrzychodow();

                    globalViewModel._incomesAndExpensesListViewModel.SumExpenses = globalViewModel._incomesAndExpensesListViewModel.ZwrocSumeWydatkow();

                    globalViewModel._incomesAndExpensesListViewModel.ActualBudget = globalViewModel._incomesAndExpensesListViewModel.ZwrocAktualnyBudzet();

                    globalViewModel._incomesAndExpensesListViewModel._incomesAndExpensesRecord.Close();
                }

            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }

        public void Edycja(int ID, bool editMode)
        {
            IncomesAndExpenses _editableIncomesAndExpenses = new IncomesAndExpenses();
            _editableIncomesAndExpenses = globalViewModel._dataContext.IncomesAndExpenses.Find(ID);

            Id = _editableIncomesAndExpenses.Id;
            UserId = _editableIncomesAndExpenses.UserId;
            ReportDate = _editableIncomesAndExpenses.ReportDate;
            Salary = _editableIncomesAndExpenses.Salary;
            Training = _editableIncomesAndExpenses.Training;
            Bonus = _editableIncomesAndExpenses.Bonus;
            AdditionalBenefits = _editableIncomesAndExpenses.AdditionalBenefits;
            Painting = _editableIncomesAndExpenses.Painting;
            ComputerProgramming = _editableIncomesAndExpenses.ComputerProgramming;
            Service = _editableIncomesAndExpenses.Service;
            OtherCommissionIncomes = _editableIncomesAndExpenses.OtherCommissionIncomes;
            AllegroSales = _editableIncomesAndExpenses.AllegroSales;
            EBaySales = _editableIncomesAndExpenses.EBaySales;
            MiniaturesSales = _editableIncomesAndExpenses.MiniaturesSales;
            OtherSalesIncomes = _editableIncomesAndExpenses.OtherSalesIncomes;
            MoneyFromFamily = _editableIncomesAndExpenses.MoneyFromFamily;
            Lottery = _editableIncomesAndExpenses.Lottery;
            Inheritance = _editableIncomesAndExpenses.Inheritance;
            OtherPresentsIncomes = _editableIncomesAndExpenses.OtherPresentsIncomes;
            OtherIncomes = _editableIncomesAndExpenses.OtherIncomes;
            Vegetables = _editableIncomesAndExpenses.Vegetables;
            Fruit = _editableIncomesAndExpenses.Fruit;
            Sweets = _editableIncomesAndExpenses.Sweets;
            JunkFood = _editableIncomesAndExpenses.JunkFood;
            BreakfastIngredients = _editableIncomesAndExpenses.BreakfastIngredients;
            DinnerIngredients = _editableIncomesAndExpenses.DinnerIngredients;
            Multisport = _editableIncomesAndExpenses.Multisport;
            DanceCourse = _editableIncomesAndExpenses.DanceCourse;
            Supplements = _editableIncomesAndExpenses.Supplements;
            Water = _editableIncomesAndExpenses.Water;
            Rent = _editableIncomesAndExpenses.Rent;
            Internet = _editableIncomesAndExpenses.Internet;
            FlatRepairs = _editableIncomesAndExpenses.FlatRepairs;
            OtherFlatExpenses = _editableIncomesAndExpenses.OtherFlatExpenses;
            MonthlyPublicTransportTicket = _editableIncomesAndExpenses.MonthlyPublicTransportTicket;
            BusTickets = _editableIncomesAndExpenses.BusTickets;
            TrainTickets = _editableIncomesAndExpenses.TrainTickets;
            Gas = _editableIncomesAndExpenses.Gas;
            Telephone = _editableIncomesAndExpenses.Telephone;
            Cinema = _editableIncomesAndExpenses.Cinema;
            Theatre = _editableIncomesAndExpenses.Theatre;
            Presents = _editableIncomesAndExpenses.Presents;
            Alcohol = _editableIncomesAndExpenses.Alcohol;
            OtherBeverages = _editableIncomesAndExpenses.OtherBeverages;
            OtherPartyExpenses = _editableIncomesAndExpenses.OtherPartyExpenses;

            EditMode = editMode;
        }

        public override void Btn_previousClick(TabControl tcSample)
        {
            int newIndex = tcSample.SelectedIndex - 1;

            if (newIndex < 0)
                newIndex = tcSample.Items.Count - 1;
            tcSample.SelectedIndex = newIndex;
        }

        public override void Btn_nextClick(TabControl tcSample)
        {
            int newIndex = tcSample.SelectedIndex + 1;

            if (newIndex >= tcSample.Items.Count)
                newIndex = 0;
            tcSample.SelectedIndex = newIndex;
        }
    }
}
