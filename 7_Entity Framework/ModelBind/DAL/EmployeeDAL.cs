using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ModelBind.Models;
namespace ModelBind.DAL
{
    public class EmployeeDAL:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer<EmployeeDAL>(null);
            modelBuilder.Entity<Employee>().ToTable("Employee");

        }
        public DbSet<Employee> Employees { get; set; }

    }
} 