using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ModelBind.Models;
namespace ModelBind.DAL
{
    public class DataAccessLayer:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer<DataAccessLayer>(null);
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Login>().ToTable("credentials");

        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Login> UserCredentials { get; set; }

    }
}