using RealMerchPlan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace RealMerchPlan.DAL
{
    public class RealMerchContext : DbContext
    {
        public RealMerchContext() : base("RealMerchContext")
        { }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Bay> Bays { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}