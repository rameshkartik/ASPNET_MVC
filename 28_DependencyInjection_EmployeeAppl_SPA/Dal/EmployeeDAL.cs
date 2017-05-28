using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Models;
namespace Dal
{
    public class EmployeeDAL:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer<EmployeeDAL>(null);
            modelBuilder.Entity<Employee>().
                    ToTable("EmployeeDiscount")
                    .Map<EmpDiscountbySalary>(x => x.Requires("EmployeeType").HasValue("S"))
                        .Map<EmpDiscountbyAge>(x => x.Requires("EmployeeType").HasValue("A"))
                            .Map<EmpDiscountbyDOJ>(x => x.Requires("EmployeeType").HasValue("J"));

        }
        public DbSet<Employee> Employees { get; set; }

    }
}