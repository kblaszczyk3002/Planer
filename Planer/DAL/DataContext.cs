using Planer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planer.DAL
{
    public class DataContext : DbContext
    {
        static DataContext()
        {
            Database.SetInitializer<DataContext>(null);
        }

        public DataContext()
            : base("Entities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Entity<IncomesAndExpenses>().ToTable("IncomesAndExpenses", "dbo");
            modelBuilder.Entity<User>().ToTable("Users", "dbo");
            modelBuilder.Entity<UserSession>().ToTable("UsersSessions", "dbo");
        }

        public DbSet<IncomesAndExpenses> IncomesAndExpenses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSession> UsersSessions { get; set; }
    }
}
