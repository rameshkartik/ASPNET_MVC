using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVC_Project_1.Models;

namespace MVC_Project_1.Dal
{
    public class GazDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Database.SetInitializer<GazRequest>(null);
            modelBuilder.Entity<GazRequest>().ToTable("GazOffRequests");
        }

        public DbSet<GazRequest> Requests { get; set; }
    }
}