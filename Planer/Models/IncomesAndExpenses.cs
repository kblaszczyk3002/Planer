using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planer.Models
{
    [Table("dbo.IncomesAndExpenses")]
    public class IncomesAndExpenses
    {
        [Key, Column("Id")]
        public Int32 Id { get; set; }
        [Column("UserId")]
        public Nullable<Int32> UserId { get; set; }
        [Column("ReportDate")]
        public DateTime ReportDate { get; set; }
        [Column("Salary")]
        public Nullable<decimal> Salary { get; set; }
        [Column("Training")]
        public Nullable<decimal> Training { get; set; }
        [Column("Bonus")]
        public Nullable<decimal> Bonus { get; set; }
        [Column("AdditionalBenefits")]
        public Nullable<decimal> AdditionalBenefits { get; set; }
        [Column("Painting")]
        public Nullable<decimal> Painting { get; set; }
        [Column("ComputerProgramming")]
        public Nullable<decimal> ComputerProgramming { get; set; }
        [Column("Service")]
        public Nullable<decimal> Service { get; set; }
        [Column("OtherCommissionIncomes")]
        public Nullable<decimal> OtherCommissionIncomes { get; set; }
        [Column("AllegroSales")]
        public Nullable<decimal> AllegroSales { get; set; }
        [Column("EBaySales")]
        public Nullable<decimal> EBaySales { get; set; }
        [Column("MiniaturesSales")]
        public Nullable<decimal> MiniaturesSales { get; set; }
        [Column("OtherSalesIncomes")]
        public Nullable<decimal> OtherSalesIncomes { get; set; }
        [Column("MoneyFromFamily")]
        public Nullable<decimal> MoneyFromFamily { get; set; }
        [Column("Lottery")]
        public Nullable<decimal> Lottery { get; set; }
        [Column("Inheritance")]
        public Nullable<decimal> Inheritance { get; set; }
        [Column("OtherPresentsIncomes")]
        public Nullable<decimal> OtherPresentsIncomes { get; set; }
        [Column("OtherIncomes")]
        public Nullable<decimal> OtherIncomes { get; set; }
        [Column("Vegetables")]
        public Nullable<decimal> Vegetables { get; set; }
        [Column("Fruit")]
        public Nullable<decimal> Fruit { get; set; }
        [Column("Sweets")]
        public Nullable<decimal> Sweets { get; set; }
        [Column("JunkFood")]
        public Nullable<decimal> JunkFood { get; set; }
        [Column("DinnerIngredients")]
        public Nullable<decimal> DinnerIngredients { get; set; }
        [Column("BreakfastIngredients")]
        public Nullable<decimal> BreakfastIngredients { get; set; }
        [Column("Multisport")]
        public Nullable<decimal> Multisport { get; set; }
        [Column("DanceCourse")]
        public Nullable<decimal> DanceCourse { get; set; }
        [Column("Supplements")]
        public Nullable<decimal> Supplements { get; set; }
        [Column("Water")]
        public Nullable<decimal> Water { get; set; }
        [Column("Rent")]
        public Nullable<decimal> Rent { get; set; }
        [Column("Internet")]
        public Nullable<decimal> Internet { get; set; }
        [Column("FlatRepairs")]
        public Nullable<decimal> FlatRepairs { get; set; }
        [Column("OtherFlatExpenses")]
        public Nullable<decimal> OtherFlatExpenses { get; set; }
        [Column("MonthlyPublicTransportTicket")]
        public Nullable<decimal> MonthlyPublicTransportTicket { get; set; }
        [Column("BusTickets")]
        public Nullable<decimal> BusTickets { get; set; }
        [Column("TrainTickets")]
        public Nullable<decimal> TrainTickets { get; set; }
        [Column("Gas")]
        public Nullable<decimal> Gas { get; set; }
        [Column("Telephone")]
        public Nullable<decimal> Telephone { get; set; }
        [Column("Cinema")]
        public Nullable<decimal> Cinema { get; set; }
        [Column("Theatre")]
        public Nullable<decimal> Theatre { get; set; }
        [Column("Presents")]
        public Nullable<decimal> Presents { get; set; }
        [Column("Alcohol")]
        public Nullable<decimal> Alcohol { get; set; }
        [Column("OtherBeverages")]
        public Nullable<decimal> OtherBeverages { get; set; }
        [Column("OtherPartyExpenses")]
        public Nullable<decimal> OtherPartyExpenses { get; set; }
        [Column("SumWorkIncomes")]
        public Nullable<decimal> SumWorkIncomes { get; set; }
        [Column("SumOtherWorkIncomes")]
        public Nullable<decimal> SumOtherWorkIncomes { get; set; }
        [Column("SumSalesIncomes")]
        public Nullable<decimal> SumSalesIncomes { get; set; }
        [Column("SumPresentsIncomes")]
        public Nullable<decimal> SumPresentsIncomes { get; set; }
        [Column("SumFoodExpenses")]
        public Nullable<decimal> SumFoodExpenses { get; set; }
        [Column("SumSportExpenses")]
        public Nullable<decimal> SumSportExpenses { get; set; }
        [Column("SumFlatExpenses")]
        public Nullable<decimal> SumFlatExpenses { get; set; }
        [Column("SumTransportExpenses")]
        public Nullable<decimal> SumTransportExpenses { get; set; }
        [Column("SumPartyExpenses")]
        public Nullable<decimal> SumPartyExpenses { get; set; }


        public IncomesAndExpenses()
        {

        }

        public IncomesAndExpenses(Int32 _Id, Nullable<Int32> _userId, DateTime _reportDate, Nullable<decimal> _salary, Nullable<decimal> _training, Nullable<decimal> _bonus,
            Nullable<decimal> _additionalBenefits, Nullable<decimal> _painting, Nullable<decimal> _computerProgramming, Nullable<decimal> _service, Nullable<decimal> _otherCommissionIncomes,
            Nullable<decimal> _allegroSales, Nullable<decimal> _eBaySales, Nullable<decimal> _miniaturesSales, Nullable<decimal> _otherSalesIncomes, Nullable<decimal> _moneyFromFamily,
            Nullable<decimal> _lottery, Nullable<decimal> _inheritance, Nullable<decimal> _otherPresentIncomes, Nullable<decimal> _otherIncomes, Nullable<decimal> _vegetables,
            Nullable<decimal> _fruit, Nullable<decimal> _sweets, Nullable<decimal> _junkFood, Nullable<decimal> _breakfastIngredients, Nullable<decimal> _dinnerIngredients, Nullable<decimal> _multisport, Nullable<decimal> _danceCourse,
            Nullable<decimal> _supplements, Nullable<decimal> _water, Nullable<decimal> _rent, Nullable<decimal> _internet, Nullable<decimal> _flatRepairs, Nullable<decimal> _otherFlatExpenses,
            Nullable<decimal> _monthlyPublicTransportTicket, Nullable<decimal> _busTickets, Nullable<decimal> _trainTickets, Nullable<decimal> _gas, Nullable<decimal> _telephone,
            Nullable<decimal> _cinema, Nullable<decimal> _theatre, Nullable<decimal> _presents, Nullable<decimal> _alcohol, Nullable<decimal> _otherBeverages, Nullable<decimal> _otherPartyExpenses,
            Nullable<decimal> _sumWorkIncomes, Nullable<decimal> _sumOtherWorkIncomes, Nullable<decimal> _sumSalesIncomes, Nullable<decimal> _sumPresentsIncomes,
            Nullable<decimal> _sumFoodExpenses, Nullable<decimal> _sumSportExpenses, Nullable<decimal> _sumFlatExpenses, Nullable<decimal> _sumTransportExpenses,
            Nullable<decimal> _sumPartyExpenses )
        {
            Id = _Id;
            UserId = _userId;
            ReportDate = _reportDate;
            Salary = _salary;
            Training = _training;
            Bonus = _bonus;
            AdditionalBenefits = _additionalBenefits;
            Painting = _painting;
            ComputerProgramming = _computerProgramming;
            Service = _service;
            OtherCommissionIncomes = _otherCommissionIncomes;
            AllegroSales = _allegroSales;
            EBaySales = _eBaySales;
            MiniaturesSales = _miniaturesSales;
            OtherSalesIncomes = _otherSalesIncomes;
            MoneyFromFamily = _moneyFromFamily;
            Lottery = _lottery;
            Inheritance = _inheritance;
            OtherPresentsIncomes = _otherPresentIncomes;
            OtherIncomes = _otherIncomes;
            Vegetables = _vegetables;
            Fruit = _fruit;
            Sweets = _sweets;
            JunkFood = _junkFood;
            BreakfastIngredients = _breakfastIngredients;
            DinnerIngredients = _dinnerIngredients;
            Multisport = _multisport;
            DanceCourse = _danceCourse;
            Supplements = _supplements;
            Water = _water;
            Rent = _rent;
            Internet = _internet;
            FlatRepairs = _flatRepairs;
            OtherFlatExpenses = _otherFlatExpenses;
            MonthlyPublicTransportTicket = _monthlyPublicTransportTicket;
            BusTickets = _busTickets;
            TrainTickets = _trainTickets;
            Gas = _gas;
            Telephone = _telephone;
            Cinema = _cinema;
            Theatre = _theatre;
            Presents = _presents;
            Alcohol = _alcohol;
            OtherBeverages = _otherBeverages;
            OtherPartyExpenses = _otherPartyExpenses;
            SumWorkIncomes = _sumWorkIncomes;
            SumOtherWorkIncomes = _sumOtherWorkIncomes;
            SumSalesIncomes = _sumSalesIncomes;
            SumPresentsIncomes = _sumPresentsIncomes;
            SumFoodExpenses = _sumFoodExpenses;
            SumSportExpenses = _sumSportExpenses;
            SumFlatExpenses = _sumFlatExpenses;
            SumTransportExpenses = _sumTransportExpenses;
            SumPartyExpenses = _sumPartyExpenses;
        }
    }
}
