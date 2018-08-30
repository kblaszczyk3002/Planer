using Planer.Interfaces;
using Planer.Models;
using Planer.Views;
using Planer.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Planer.ViewModels
{
    public class IncomesAndExpensesListViewModel : WindowHelpers, INotifyPropertyChanged, IListFiller
    {
        internal GlobalViewModel _globalViewModel;

        public IncomesAndExpensesRecord _incomesAndExpensesRecord;

        public event PropertyChangedEventHandler PropertyChanged;

        public TabControl tcSample;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public IncomesAndExpenses _IncomesAndExpenses;

        public Nullable<decimal> sumIncomes;
        public Nullable<decimal> sumExpenses;
        public Nullable<decimal> actualBudget;
        public bool isVisible;

        public ObservableCollection<IncomesAndExpenses> _IncomesAndExpensesList { get; set; }

        public IncomesAndExpenses SelectedRecord
        {
            get
            {
                return _IncomesAndExpenses;
            }
            set
            {
                _IncomesAndExpenses = value;
                OnPropertyChanged("SelectedRecord");
            }
        }

        public Nullable<decimal> SumIncomes
        {
            get
            {
                return ZwrocSumePrzychodow();
            }
            set
            {
                sumIncomes = value;
                OnPropertyChanged("SumIncomes");
            }
        }

        public Nullable<decimal> SumExpenses
        {
            get
            {
                return ZwrocSumeWydatkow();
            }
            set
            {
                sumExpenses = value;
                OnPropertyChanged("SumExpenses");
            }
        }

        public Nullable<decimal> ActualBudget
        {
            get
            {
                return ZwrocAktualnyBudzet();
            }
            set
            {
                actualBudget = value;
                OnPropertyChanged("ActualBudget");
            }
        }

        public Nullable<decimal> SumWorkIncomes
        {
            get
            {
                return _IncomesAndExpenses.SumWorkIncomes = _IncomesAndExpenses.Salary + _IncomesAndExpenses.Training + _IncomesAndExpenses.Bonus + _IncomesAndExpenses.AdditionalBenefits;
            }
            set
            {
                _IncomesAndExpenses.SumWorkIncomes = value;
                OnPropertyChanged("SumWorkIncomes");
            }
        }

        public Nullable<decimal> SumOtherWorkIncomes
        {
            get
            {
                return _IncomesAndExpenses.SumOtherWorkIncomes = _IncomesAndExpenses.Painting + _IncomesAndExpenses.ComputerProgramming + _IncomesAndExpenses.Service + _IncomesAndExpenses.OtherCommissionIncomes;
            }
            set
            {
                _IncomesAndExpenses.SumOtherWorkIncomes = value;
                OnPropertyChanged("SumOtherWorkIncomes");
            }
        }

        public Nullable<decimal> SumSalesIncomes
        {
            get
            {
                return _IncomesAndExpenses.SumSalesIncomes = _IncomesAndExpenses.AllegroSales + _IncomesAndExpenses.EBaySales + _IncomesAndExpenses.MiniaturesSales + _IncomesAndExpenses.OtherSalesIncomes;
            }
            set
            {
                _IncomesAndExpenses.SumSalesIncomes = value;
                OnPropertyChanged("SumSalesIncomes");
            }
        }

        public Nullable<decimal> SumPresentsIncomes
        {
            get
            {
                return _IncomesAndExpenses.SumPresentsIncomes = _IncomesAndExpenses.MoneyFromFamily + _IncomesAndExpenses.Lottery + _IncomesAndExpenses.Inheritance + _IncomesAndExpenses.OtherPresentsIncomes;
            }
            set
            {
                _IncomesAndExpenses.SumPresentsIncomes = value;
                OnPropertyChanged("SumPResentsIncomes");
            }
        }

        public Nullable<decimal> SumFoodExpenses
        {
            get
            {
                return _IncomesAndExpenses.SumFoodExpenses = _IncomesAndExpenses.Vegetables + _IncomesAndExpenses.Fruit + _IncomesAndExpenses.Sweets + _IncomesAndExpenses.JunkFood + _IncomesAndExpenses.DinnerIngredients + _IncomesAndExpenses.BreakfastIngredients;
            }
            set
            {
                _IncomesAndExpenses.SumFoodExpenses = value;
                OnPropertyChanged("SumFoodExpenses");
            }
        }

        public Nullable<decimal> SumSportExpenses
        {
            get
            {
                return _IncomesAndExpenses.SumSportExpenses = _IncomesAndExpenses.Multisport + _IncomesAndExpenses.Supplements + _IncomesAndExpenses.Water + _IncomesAndExpenses.DanceCourse;
            }
            set
            {
                _IncomesAndExpenses.SumSportExpenses = value;
                OnPropertyChanged("SumSportExpenses");
            }
        }

        public Nullable<decimal> SumFlatExpenses
        {
            get
            {
                return _IncomesAndExpenses.SumFlatExpenses = _IncomesAndExpenses.Rent + _IncomesAndExpenses.Internet + _IncomesAndExpenses.Telephone + _IncomesAndExpenses.FlatRepairs + _IncomesAndExpenses.OtherFlatExpenses;
            }
            set
            {
                _IncomesAndExpenses.SumFlatExpenses = value;
                OnPropertyChanged("SumFlatExpenses");
            }
        }

        public Nullable<decimal> SumTransportExpenses
        {
            get
            {
                return _IncomesAndExpenses.SumTransportExpenses = _IncomesAndExpenses.MonthlyPublicTransportTicket + _IncomesAndExpenses.BusTickets + _IncomesAndExpenses.TrainTickets + _IncomesAndExpenses.Gas;
            }
            set
            {
                _IncomesAndExpenses.SumTransportExpenses = value;
                OnPropertyChanged("SumTransportExpenses");
            }
        }

        public Nullable<decimal> SumPartyExpenses
        {
            get
            {
                return _IncomesAndExpenses.SumPartyExpenses = _IncomesAndExpenses.Cinema + _IncomesAndExpenses.Theatre + _IncomesAndExpenses.Alcohol + _IncomesAndExpenses.OtherBeverages + _IncomesAndExpenses.OtherPartyExpenses;
            }
            set
            {
                _IncomesAndExpenses.SumPartyExpenses = value;
                OnPropertyChanged("SumPartyExpenses");
            }
        }

        public Int32 Id
        {
            get
            {
                return _IncomesAndExpenses.Id;
            }
            set
            {
                _IncomesAndExpenses.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public Nullable<Int32> UserId
        {
            get
            {
                return _IncomesAndExpenses.UserId;
            }
            set
            {
                _IncomesAndExpenses.UserId = value;
                OnPropertyChanged("UserId");
            }
        }

        public DateTime ReportDate
        {
            get
            {
                return _IncomesAndExpenses.ReportDate;
            }
            set
            {
                _IncomesAndExpenses.ReportDate = value;
                OnPropertyChanged("ReportDate");
            }
        }

        public Nullable<decimal> Salary
        { get
            {
                return _IncomesAndExpenses.Salary;
            }
            set
            {
                _IncomesAndExpenses.Salary = value;
                OnPropertyChanged("Salary");
            }
        }

        public Nullable<decimal> Training
        {
            get
            {
                return _IncomesAndExpenses.Training;
            }
            set
            {
                _IncomesAndExpenses.Training = value;
                OnPropertyChanged("Training");
            }
        }

        public Nullable<decimal> Bonus
        {
            get
            {
                return _IncomesAndExpenses.Bonus;
            }
            set
            {
                _IncomesAndExpenses.Bonus = value;
                OnPropertyChanged("Bonus");
            }
        }

        public Nullable<decimal> AdditionalBenefits
        {
            get
            {
                return _IncomesAndExpenses.AdditionalBenefits;
            }
            set
            {
                _IncomesAndExpenses.AdditionalBenefits = value;
                OnPropertyChanged("AdditionalBenefits");
            }
        }

        public Nullable<decimal> Painting
        {
            get
            {
                return _IncomesAndExpenses.Painting;
            }
            set
            {
                _IncomesAndExpenses.Painting = value;
                OnPropertyChanged("Painting");
            }
        }

        public Nullable<decimal> ComputerProgramming
        {
            get
            {
                return _IncomesAndExpenses.ComputerProgramming;
            }
            set
            {
                _IncomesAndExpenses.ComputerProgramming = value;
                OnPropertyChanged("ComputerProgramming");
            }
        }

        public Nullable<decimal> Service
        {
            get
            {
                return _IncomesAndExpenses.Service;
            }
            set
            {
                _IncomesAndExpenses.Service = value;
                OnPropertyChanged("Service");
            }
        }

        public Nullable<decimal> OtherCommissionIncomes
        {
            get
            {
                return _IncomesAndExpenses.OtherCommissionIncomes;
            }
            set
            {
                _IncomesAndExpenses.OtherCommissionIncomes = value;
                OnPropertyChanged("OtherCommissionIncomes");
            }
        }

        public Nullable<decimal> AllegroSales
        {
            get
            {
                return _IncomesAndExpenses.AllegroSales;
            }
            set
            {
                _IncomesAndExpenses.AllegroSales = value;
                OnPropertyChanged("AllegroSales");
            }
        }

        public Nullable<decimal> EBaySales
        {
            get
            {
                return _IncomesAndExpenses.EBaySales;
            }
            set
            {
                _IncomesAndExpenses.EBaySales = value;
                OnPropertyChanged("EBaySales");
            }
        }

        public Nullable<decimal> MiniaturesSales
        {
            get
            {
                return _IncomesAndExpenses.MiniaturesSales;
            }
            set
            {
                _IncomesAndExpenses.MiniaturesSales = value;
                OnPropertyChanged("MiniaturesSales");
            }
        }

        public Nullable<decimal> OtherSalesIncomes
        {
            get
            {
                return _IncomesAndExpenses.OtherSalesIncomes;
            }
            set
            {
                _IncomesAndExpenses.OtherSalesIncomes = value;
                OnPropertyChanged("OtherSalesIncomes");
            }
        }

        public Nullable<decimal> MoneyFromFamily
        {
            get
            {
                return _IncomesAndExpenses.MoneyFromFamily;
            }
            set
            {
                _IncomesAndExpenses.MoneyFromFamily = value;
                OnPropertyChanged("MoneyFromFamily");
            }
        }

        public Nullable<decimal> Lottery
        {
            get
            {
                return _IncomesAndExpenses.Lottery;
            }
            set
            {
                _IncomesAndExpenses.Lottery = value;
                OnPropertyChanged("Lottery");
            }
        }

        public Nullable<decimal> Inheritance
        {
            get
            {
                return _IncomesAndExpenses.Inheritance;
            }
            set
            {
                _IncomesAndExpenses.Inheritance = value;
                OnPropertyChanged("Inheritance");
            }
        }

        public Nullable<decimal> OtherPresentsIncomes
        {
            get
            {
                return _IncomesAndExpenses.OtherPresentsIncomes;
            }
            set
            {
                _IncomesAndExpenses.OtherPresentsIncomes = value;
                OnPropertyChanged("OtherPresentsIncomes");
            }
        }

        public Nullable<decimal> OtherIncomes
        {
            get
            {
                return _IncomesAndExpenses.OtherIncomes;
            }
            set
            {
                _IncomesAndExpenses.OtherIncomes = value;
                OnPropertyChanged("OtherIncomes");
            }
        }

        public Nullable<decimal> Vegetables
        {
            get
            {
                return _IncomesAndExpenses.Vegetables;
            }
            set
            {
                _IncomesAndExpenses.Vegetables = value;
                OnPropertyChanged("Vegetables");
            }
        }

        public Nullable<decimal> Fruit
        {
            get
            {
                return _IncomesAndExpenses.Fruit;
            }
            set
            {
                _IncomesAndExpenses.Fruit = value;
                OnPropertyChanged("Fruit");
            }
        }

        public Nullable<decimal> Sweets
        {
            get
            {
                return _IncomesAndExpenses.Sweets;
            }
            set
            {
                _IncomesAndExpenses.Sweets = value;
                OnPropertyChanged("Sweets");
            }
        }

        public Nullable<decimal> JunkFood
        {
            get
            {
                return _IncomesAndExpenses.JunkFood;
            }
            set
            {
                _IncomesAndExpenses.JunkFood = value;
                OnPropertyChanged("JunkFood");
            }
        }

        public Nullable<decimal> DinnerIngredients
        {
            get
            {
                return _IncomesAndExpenses.DinnerIngredients;
            }
            set
            {
                _IncomesAndExpenses.DinnerIngredients = value;
                OnPropertyChanged("DinnerIngredients");
            }
        }

        public Nullable<decimal> BreakfastIngredients
        {
            get
            {
                return _IncomesAndExpenses.BreakfastIngredients;
            }
            set
            {
                _IncomesAndExpenses.BreakfastIngredients = value;
                OnPropertyChanged("BreakFastIngredients");
            }
        }

        public Nullable<decimal> Multisport
        {
            get
            {
                return _IncomesAndExpenses.Multisport;
            }
            set
            {
                _IncomesAndExpenses.Multisport = value;
                OnPropertyChanged("Multisport");
            }
        }

        public Nullable<decimal> DanceCourse
        {
            get
            {
                return _IncomesAndExpenses.DanceCourse;
            }
            set
            {
                _IncomesAndExpenses.DanceCourse = value;
                OnPropertyChanged("DanceCourse");
            }
        }

        public Nullable<decimal> Supplements
        {
            get
            {
                return _IncomesAndExpenses.Supplements;
            }
            set
            {
                _IncomesAndExpenses.Supplements = value;
                OnPropertyChanged("Supplements");
            }
        }

        public Nullable<decimal> Water
        {
            get
            {
                return _IncomesAndExpenses.Water;
            }
            set
            {
                _IncomesAndExpenses.Water = value;
                OnPropertyChanged("Water");
            }
        }

        public Nullable<decimal> Rent
        {
            get
            {
                return _IncomesAndExpenses.Rent;
            }
            set
            {
                _IncomesAndExpenses.Rent = value;
                OnPropertyChanged("Rent");
            }
        }

        public Nullable<decimal> Internet
        {
            get
            {
                return _IncomesAndExpenses.Internet;
            }
            set
            {
                _IncomesAndExpenses.Internet = value;
                OnPropertyChanged("Internet");
            }
        }

        public Nullable<decimal> FlatRepairs
        {
            get
            {
                return _IncomesAndExpenses.FlatRepairs;
            }
            set
            {
                _IncomesAndExpenses.FlatRepairs = value;
                OnPropertyChanged("FlatRepairs");
            }
        }

        public Nullable<decimal> OtherFlatExpenses
        {
            get
            {
                return _IncomesAndExpenses.OtherFlatExpenses;
            }
            set
            {
                _IncomesAndExpenses.OtherFlatExpenses = value;
                OnPropertyChanged("OtherFlatExpenses");
            }
        }

        public Nullable<decimal> MonthlyPublicTransportTicket
        {
            get
            {
                return _IncomesAndExpenses.MonthlyPublicTransportTicket;
            }
            set
            {
                _IncomesAndExpenses.MonthlyPublicTransportTicket = value;
                OnPropertyChanged("MonthlyPublicTransportTicket");
            }
        }

        public Nullable<decimal> BusTickets
        {
            get
            {
                return _IncomesAndExpenses.BusTickets;
            }
            set
            {
                _IncomesAndExpenses.BusTickets = value;
                OnPropertyChanged("BusTickets");
            }
        }

        public Nullable<decimal> TrainTickets
        {
            get
            {
                return _IncomesAndExpenses.TrainTickets;
            }
            set
            {
                _IncomesAndExpenses.TrainTickets = value;
                OnPropertyChanged("TrainTickets");
            }
        }

        public Nullable<decimal> Gas
        {
            get
            {
                return _IncomesAndExpenses.Gas;
            }
            set
            {
                _IncomesAndExpenses.Gas = value;
                OnPropertyChanged("Gas");
            }
        }

        public Nullable<decimal> Telephone
        {
            get
            {
                return _IncomesAndExpenses.Telephone;
            }
            set
            {
                _IncomesAndExpenses.Telephone = value;
                OnPropertyChanged("Telephone");
            }
        }

        public Nullable<decimal> Cinema
        {
            get
            {
                return _IncomesAndExpenses.Cinema;
            }
            set
            {
                _IncomesAndExpenses.Cinema = value;
                OnPropertyChanged("Cinema");
            }
        }

        public Nullable<decimal> Theatre
        {
            get
            {
                return _IncomesAndExpenses.Theatre;
            }
            set
            {
                _IncomesAndExpenses.Theatre = value;
                OnPropertyChanged("Theatre");
            }
        }

        public Nullable<decimal> Presents
        {
            get
            {
                return _IncomesAndExpenses.Presents;
            }
            set
            {
                _IncomesAndExpenses.Presents = value;
                OnPropertyChanged("Presents");
            }
        }

        public Nullable<decimal> Alcohol
        {
            get
            {
                return _IncomesAndExpenses.Alcohol;
            }
            set
            {
                _IncomesAndExpenses.Alcohol = value;
                OnPropertyChanged("Alcohol");
            }
        }

        public Nullable<decimal> OtherBeverages
        {
            get
            {
                return _IncomesAndExpenses.OtherBeverages;
            }
            set
            {
                _IncomesAndExpenses.OtherBeverages = value;
                OnPropertyChanged("OtherBeverages");
            }
        }

        public Nullable<decimal> OtherPartyExpenses
        {
            get
            {
                return _IncomesAndExpenses.OtherPartyExpenses;
            }
            set
            {
                _IncomesAndExpenses.OtherPartyExpenses = value;
                OnPropertyChanged("OtherPartyExpenses");
            }
        }
        public IncomesAndExpensesListViewModel(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;

            _IncomesAndExpenses = new IncomesAndExpenses();

            this._IncomesAndExpensesList = new ObservableCollection<IncomesAndExpenses>();
        }

        public void DodajRekord(bool createMode, bool editMode, bool viewMode)
        {
            _incomesAndExpensesRecord = new IncomesAndExpensesRecord(createMode, editMode, viewMode);

            //_globalViewModel._incomesAndExpensesRecordViewModel.Salary = 0.00m;

            _incomesAndExpensesRecord.Show();
        }

        public void EdytujRekord(bool createMode, bool editMode, bool viewMode)
        {
            IncomesAndExpenses _editableIncomesAndExpenses = new IncomesAndExpenses();

            _editableIncomesAndExpenses = _globalViewModel._dataContext.IncomesAndExpenses.Find(SelectedRecord.Id);

            //_globalViewModel._incomesAndExpensesRecordViewModel.Salary = 0.00m;

            _incomesAndExpensesRecord = new IncomesAndExpensesRecord(_editableIncomesAndExpenses.Id, editMode);

            _incomesAndExpensesRecord.Show();

        }

        public void UsunRekord()
        {
            IncomesAndExpenses _deletedIncomesAndExpenses = _globalViewModel._dataContext.IncomesAndExpenses.Find(SelectedRecord.Id);

            if (_deletedIncomesAndExpenses == null)
            {
                MessageBox.Show("Nie wybrałeś rekordu do usunięcia!");
            }
            else
            {
                MessageBoxResult _deletingMessage = MessageBox.Show("Czy chcesz ususnąć zaznaczony rekord?", "Usuwanie wpisu", MessageBoxButton.YesNo);

                if (_deletingMessage == MessageBoxResult.Yes)
                {

                    _globalViewModel._dataContext.IncomesAndExpenses.Remove(_deletedIncomesAndExpenses);

                    _globalViewModel._dataContext.SaveChanges();

                    int recordCount;
                    int maxValue = 0;

                    recordCount = (from r in this._globalViewModel._dataContext.IncomesAndExpenses
                                   select r).Count();

                    if (recordCount > 0)

                        maxValue = (from d in this._globalViewModel._dataContext.IncomesAndExpenses
                                    select d.Id).Max();

                    this._globalViewModel._incomesAndExpensesListViewModel.FillList(maxValue);

                    SumIncomes = ZwrocSumePrzychodow();

                    SumExpenses = ZwrocSumeWydatkow();

                    ActualBudget = ZwrocAktualnyBudzet();
                }
                else
                {
                    MessageBox.Show("To po chuj to kliknąłeś :P ");
                }
            }
        }

        public void Zamknij()
        {
            _incomesAndExpensesRecord.Close();
        }

        public void FillList(int _recordsNumber)
        {
            int records = _recordsNumber;

            if(records > 0)
            {
                _IncomesAndExpensesList.Clear();

                for (int i = 1; i <= records; i++)
                {
                    try
                    {
                        var singleRecord = (from s in _globalViewModel._dataContext.IncomesAndExpenses
                                            where s.Id == i
                                            select s).SingleOrDefault();

                        if (singleRecord != null)
                        {

                            _IncomesAndExpensesList.Add(new IncomesAndExpenses(singleRecord.Id, singleRecord.UserId, singleRecord.ReportDate, singleRecord.Salary,
                                singleRecord.Training, singleRecord.Bonus, singleRecord.AdditionalBenefits, singleRecord.Painting, singleRecord.ComputerProgramming,
                                singleRecord.Service, singleRecord.OtherCommissionIncomes, singleRecord.AllegroSales, singleRecord.EBaySales, singleRecord.MiniaturesSales,
                                singleRecord.OtherSalesIncomes, singleRecord.MoneyFromFamily, singleRecord.Lottery, singleRecord.Inheritance, singleRecord.OtherPresentsIncomes,
                                singleRecord.OtherIncomes, singleRecord.Vegetables, singleRecord.Fruit, singleRecord.Sweets, singleRecord.JunkFood, singleRecord.BreakfastIngredients, singleRecord.DinnerIngredients,
                                singleRecord.Multisport, singleRecord.DanceCourse, singleRecord.Supplements, singleRecord.Water, singleRecord.Rent, singleRecord.Internet,
                                singleRecord.FlatRepairs, singleRecord.OtherFlatExpenses, singleRecord.MonthlyPublicTransportTicket, singleRecord.BusTickets, singleRecord.TrainTickets,
                                singleRecord.Gas, singleRecord.Telephone, singleRecord.Cinema, singleRecord.Theatre, singleRecord.Presents, singleRecord.Alcohol, singleRecord.OtherBeverages,
                                singleRecord.OtherPartyExpenses, singleRecord.Salary + singleRecord.Training + singleRecord.Bonus + singleRecord.AdditionalBenefits,
                                singleRecord.Painting + singleRecord.ComputerProgramming + singleRecord.Service + singleRecord.OtherCommissionIncomes,
                                singleRecord.AllegroSales + singleRecord.EBaySales + singleRecord.MiniaturesSales + singleRecord.OtherSalesIncomes,
                                singleRecord.MoneyFromFamily + singleRecord.Lottery + singleRecord.Inheritance + singleRecord.OtherPresentsIncomes,
                                singleRecord.Vegetables + singleRecord.Fruit + singleRecord.Sweets + singleRecord.JunkFood + singleRecord.DinnerIngredients + singleRecord.BreakfastIngredients,
                                singleRecord.Multisport + singleRecord.Supplements + singleRecord.Water + singleRecord.DanceCourse,
                                singleRecord.Rent + singleRecord.Internet + singleRecord.FlatRepairs + singleRecord.OtherFlatExpenses + singleRecord.Telephone,
                                singleRecord.MonthlyPublicTransportTicket + singleRecord.BusTickets + singleRecord.TrainTickets + singleRecord.Gas,
                                singleRecord.Cinema + singleRecord.Theatre + singleRecord.Alcohol + singleRecord.OtherBeverages + singleRecord.OtherPartyExpenses));
                        }
                    }

                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString());
                    }
                }
            }
            else
            {
                _IncomesAndExpensesList.Clear();
            }
        }

        public Nullable<decimal> ZwrocSumePrzychodow()
        {
            Nullable<decimal> returnValue = 0.00m;

            int recordCount = (from r in _globalViewModel._dataContext.IncomesAndExpenses
                               select r.Id).Max();

            if(recordCount > 0)
            {
                Nullable<decimal> sumIncomes = 0.00m;

                    var salary = (from s in _globalViewModel._dataContext.IncomesAndExpenses
                                  select s.Salary).Sum();

                    var training = (from t in _globalViewModel._dataContext.IncomesAndExpenses
                                  select t.Training).Sum();

                var bonus = (from t in _globalViewModel._dataContext.IncomesAndExpenses
                                select t.Bonus).Sum();

                var additionalBenefits = (from t in _globalViewModel._dataContext.IncomesAndExpenses
                                select t.AdditionalBenefits).Sum();

                var painting = (from t in _globalViewModel._dataContext.IncomesAndExpenses
                                         select t.Painting).Sum();

                var computerProgramming = (from t in _globalViewModel._dataContext.IncomesAndExpenses
                                         select t.ComputerProgramming).Sum();

                var service = (from t in _globalViewModel._dataContext.IncomesAndExpenses
                                         select t.Service).Sum();

                var otherCommissionIncomes = (from t in _globalViewModel._dataContext.IncomesAndExpenses
                                         select t.OtherCommissionIncomes).Sum();

                var allegroSales = (from t in _globalViewModel._dataContext.IncomesAndExpenses
                                              select t.AllegroSales).Sum();

                var ebaySales = (from t in _globalViewModel._dataContext.IncomesAndExpenses
                                              select t.EBaySales).Sum();

                var miniaturesSales = (from t in _globalViewModel._dataContext.IncomesAndExpenses
                                              select t.MiniaturesSales).Sum();

                var otherSalesIncomes = (from t in _globalViewModel._dataContext.IncomesAndExpenses
                                              select t.OtherSalesIncomes).Sum();

                var moneyFromFamily = (from t in _globalViewModel._dataContext.IncomesAndExpenses
                                         select t.MoneyFromFamily).Sum();

                var lottery = (from t in _globalViewModel._dataContext.IncomesAndExpenses
                                         select t.Lottery).Sum();

                var inheritance = (from t in _globalViewModel._dataContext.IncomesAndExpenses
                                         select t.Inheritance).Sum();

                var otherPresentsIncomes = (from t in _globalViewModel._dataContext.IncomesAndExpenses
                                         select t.OtherPresentsIncomes).Sum();

                var otherIncomes = (from t in _globalViewModel._dataContext.IncomesAndExpenses
                                         select t.OtherIncomes).Sum();

                sumIncomes = salary + training + bonus + additionalBenefits + painting + computerProgramming + service + otherCommissionIncomes +
                                allegroSales + ebaySales + miniaturesSales + otherSalesIncomes + moneyFromFamily + lottery + inheritance + otherPresentsIncomes +
                                otherIncomes;

                    returnValue = sumIncomes;

                if(returnValue == null)
                {
                    return 0.00m;
                }
                else
                {
                    return returnValue;
                }

            }
            else
            {
                return 0.00m;
            }
        }

        public Nullable<decimal> ZwrocSumeWydatkow()
        {
            Nullable<decimal> returnValue = 0.00m;

            int recordCount = (from r in _globalViewModel._dataContext.IncomesAndExpenses
                               select r.Id).Max();

            if(recordCount > 0)
            {
                Nullable<decimal> sumExpenses = 0.00m;

                var vegetables = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                                  select v.Vegetables).Sum();

                var fruit = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                             select v.Fruit).Sum();

                var sweets = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                              select v.Sweets).Sum();

                var junkFood = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                                select v.JunkFood).Sum();

                var dinnerIngredients = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                                         select v.DinnerIngredients).Sum();

                var breakfastIngredients = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                                            select v.BreakfastIngredients).Sum();

                var multisport = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                                  select v.Multisport).Sum();

                var danceCourse = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                                   select v.DanceCourse).Sum();

                var supplements = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                                   select v.Supplements).Sum();

                var water = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                             select v.Water).Sum();

                var rent = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                            select v.Rent).Sum();

                var internet = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                                select v.Internet).Sum();

                var flatRepairs = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                                   select v.FlatRepairs).Sum();

                var otherFlatExpenses = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                                         select v.OtherFlatExpenses).Sum();

                var monthlyPublicTransportTicket = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                                                    select v.MonthlyPublicTransportTicket).Sum();

                var busTickets = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                                  select v.BusTickets).Sum();

                var trainTickets = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                                    select v.TrainTickets).Sum();

                var gas = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                           select v.Gas).Sum();

                var telephone = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                                 select v.Telephone).Sum();

                var cinema = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                              select v.Cinema).Sum();

                var theatre = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                               select v.Theatre).Sum();

                var alcohol = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                               select v.Alcohol).Sum();

                var otherBeverages = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                                      select v.OtherBeverages).Sum();

                var otherPartyExpenses = (from v in _globalViewModel._dataContext.IncomesAndExpenses
                                          select v.OtherPartyExpenses).Sum();

                sumExpenses = vegetables + fruit + sweets + junkFood + dinnerIngredients + breakfastIngredients + multisport + danceCourse + supplements + water +
                    rent + internet + flatRepairs + otherFlatExpenses + monthlyPublicTransportTicket + busTickets + trainTickets + gas + telephone + cinema +
                    theatre + alcohol + otherBeverages + otherPartyExpenses;

                //var expenses = from e in _globalViewModel._dataContext.IncomesAndExpenses
                //               group e by 1 into n
                //               select new
                //               {
                //                   Vegetables = n.Sum(x => x.Vegetables),
                //                   Fruit = n.Sum(x => x.Fruit)
                //               };

                returnValue = sumExpenses;

                if(returnValue == null)
                {
                    return 0.00m;
                }
                else
                {
                    return returnValue;
                }

            }
            else
            {
                return 0.00m;
            }
        }

        public Nullable<decimal> ZwrocAktualnyBudzet()
        {
            Nullable<decimal> actualBudget = 0.00m;

            int recordCount = (from r in _globalViewModel._dataContext.IncomesAndExpenses
                               select r.Id).Max();

            if(recordCount > 0)
            {
                return actualBudget = SumIncomes - SumExpenses;
            }
            else
            {
                return 0.00m;
            }
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
