using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planer.Models
{
    [Table("dbo.Users")]
    public class User
    {
        [Key, Column("Id")]
        public Int32 Id { get; set; }
        [Column("Acronym")]
        public string Acronym { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Surname")]
        public string Surname { get; set; }
        [Column("eMail")]
        public string eMail { get; set; }
        [Column("PESEL")]
        public string PESEL { get; set; }
        [Column("Gender")]
        public byte Gender { get; set; }
        [Column("StreetName")]
        public string StreetName { get; set; }
        [Column("StreetNumber")]
        public string StreetNumber { get; set; }
        [Column("HouseNumber")]
        public string HouseNumber { get; set; }
        [Column("PostalCode")]
        public string PostalCode { get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("Province")]
        public string Province { get; set; }
        [Column("ConfigAuthorization")]
        public bool ConfigAuthorization { get; set; }
        [Column("DatabaseManagerAuthorization")]
        public bool DatabaseManagerAuthorization { get; set; }
        [Column("IncomesAndExpensesListAuthorization")]
        public bool IncomesAndExpensesListAuthorization { get; set; }
        [Column("UsersListAuthorization")]
        public bool UsersListAuthorization { get; set; }
        [Column("IsAdmin")]
        public bool IsAdmin { get; set; }
        [Column("ViewOtherUsersRecords")]
        public bool ViewOtherUsersRecords { get; set; }
        [Column("DeletingOtherUsersRecords")]
        public bool DeletingOtherUsersRecords { get; set; }
        [Column("EditingOtherUsersRecords")]
        public bool EditingOtherUsersRecords { get; set; }

        public User()
        {

        }


        public User(Int32 _Id, string _acronym, string _password, string _name, string _surname, string _email, string _pesel, byte _gender, string _streetName,
            string _streetNumber, string _houseNumber, string _postalCode, string _city, string _province, bool _configAuthorization, bool _databaseManagerAuthorization,
            bool _incomesAndExpensesListAuthorization, bool _usersListAuthorization, bool _isAdmin, bool _viewOtherUsersRecords, bool _deletingOtherUsersRecords,
            bool _editingOtherUsersRecords)
        {
            Id = _Id;
            Acronym = _acronym;
            Password = _password;
            Name = _name;
            Surname = _surname;
            eMail = _email;
            PESEL = _pesel;
            Gender = _gender;
            StreetName = _streetName;
            StreetNumber = _streetNumber;
            HouseNumber = _houseNumber;
            PostalCode = _postalCode;
            City = _city;
            Province = _province;
            ConfigAuthorization = _configAuthorization;
            DatabaseManagerAuthorization = _databaseManagerAuthorization;
            IncomesAndExpensesListAuthorization = _incomesAndExpensesListAuthorization;
            UsersListAuthorization = _usersListAuthorization;
            IsAdmin = _isAdmin;
            ViewOtherUsersRecords = _viewOtherUsersRecords;
            DeletingOtherUsersRecords = _deletingOtherUsersRecords;
            EditingOtherUsersRecords = _editingOtherUsersRecords;
        }
    }
}
