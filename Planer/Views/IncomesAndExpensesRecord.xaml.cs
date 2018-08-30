using Planer.Models;
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
    /// Interaction logic for IncomesAndExpensesRecord.xaml
    /// </summary>
    public partial class IncomesAndExpensesRecord : Window
    {
        private GlobalViewModel VM;

        public IncomesAndExpensesRecord(bool _createMode, bool _editMode, bool _viewMode)
        {
            InitializeComponent();
            VM = App.Current.Resources["GlobalViewModel"] as GlobalViewModel;

            VM._incomesAndExpensesRecordViewModel.CreateMode = _createMode;
            VM._incomesAndExpensesRecordViewModel.EditMode = _editMode;
            VM._incomesAndExpensesRecordViewModel.ViewMode = _viewMode;

            VM._incomesAndExpensesRecordViewModel.UserId = VM._incomesAndExpensesRecordViewModel.GetUserId();
            VM._incomesAndExpensesRecordViewModel.AdditionalBenefits = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Alcohol = 0.00m;
            VM._incomesAndExpensesRecordViewModel.AllegroSales = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Bonus = 0.00m;
            VM._incomesAndExpensesRecordViewModel.BreakfastIngredients = 0.00m;
            VM._incomesAndExpensesRecordViewModel.BusTickets = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Cinema = 0.00m;
            VM._incomesAndExpensesRecordViewModel.ComputerProgramming = 0.00m;
            VM._incomesAndExpensesRecordViewModel.DanceCourse = 0.00m;
            VM._incomesAndExpensesRecordViewModel.DinnerIngredients = 0.00m;
            VM._incomesAndExpensesRecordViewModel.EBaySales = 0.00m;
            VM._incomesAndExpensesRecordViewModel.FlatRepairs = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Fruit = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Gas = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Inheritance = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Internet = 0.00m;
            VM._incomesAndExpensesRecordViewModel.JunkFood = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Lottery = 0.00m;
            VM._incomesAndExpensesRecordViewModel.MiniaturesSales = 0.00m;
            VM._incomesAndExpensesRecordViewModel.MoneyFromFamily = 0.00m;
            VM._incomesAndExpensesRecordViewModel.MonthlyPublicTransportTicket = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Multisport = 0.00m;
            VM._incomesAndExpensesRecordViewModel.OtherBeverages = 0.00m;
            VM._incomesAndExpensesRecordViewModel.OtherCommissionIncomes = 0.00m;
            VM._incomesAndExpensesRecordViewModel.OtherFlatExpenses = 0.00m;
            VM._incomesAndExpensesRecordViewModel.OtherIncomes = 0.00m;
            VM._incomesAndExpensesRecordViewModel.OtherPartyExpenses = 0.00m;
            VM._incomesAndExpensesRecordViewModel.OtherPresentsIncomes = 0.00m;
            VM._incomesAndExpensesRecordViewModel.OtherSalesIncomes = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Painting = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Presents = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Rent = 0.00m;
            VM._incomesAndExpensesRecordViewModel.ReportDate = DateTime.Now;
            VM._incomesAndExpensesRecordViewModel.Salary = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Service = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Supplements = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Sweets = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Telephone = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Theatre = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Training = 0.00m;
            VM._incomesAndExpensesRecordViewModel.TrainTickets = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Vegetables = 0.00m;
            VM._incomesAndExpensesRecordViewModel.Water = 0.00m;
        }

        public IncomesAndExpensesRecord(int ID, bool EditMode)
        {
            InitializeComponent();
            VM = App.Current.Resources["GlobalViewModel"] as GlobalViewModel;

            VM._incomesAndExpensesRecordViewModel.Edycja(ID, EditMode);
        }

        private void PreviousTab(object sender, RoutedEventArgs e)
        {
            VM._incomesAndExpensesRecordViewModel.Btn_previousClick(TabIncomesAndExpenses);
        }

        private void NextTab(object sender, RoutedEventArgs e)
        {
            VM._incomesAndExpensesRecordViewModel.Btn_nextClick(TabIncomesAndExpenses);
        }

        private void PreviousInnerTab(object sender, RoutedEventArgs e)
        {
            VM._incomesAndExpensesRecordViewModel.Btn_previousClick(TabIncomes);
        }

        private void NextInnerTab(object sender, RoutedEventArgs e)
        {
            VM._incomesAndExpensesRecordViewModel.Btn_nextClick(TabIncomes);
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            VM._incomesAndExpensesRecordViewModel.Zapisz();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            VM._incomesAndExpensesListViewModel.Zamknij();
        }
    }
}
