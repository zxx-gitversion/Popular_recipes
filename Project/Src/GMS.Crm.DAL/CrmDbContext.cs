using System.Data.Entity;
using GMS.Core.Config;
using GMS.Core.Log;
using GMS.Crm.Contract;
using GMS.Framework.DAL;

namespace GMS.Crm.DAL
{
    public class CrmDbContext : DbContextBase
    {
        public CrmDbContext()
            : base(CachedConfigContext.Current.DaoConfig.Crm, new LogDbContext())
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<CrmDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<VisitRecord> VisitRecords { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Area> Areas { get; set; }
    }
}
