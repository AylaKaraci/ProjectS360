using ProjectS360.CORE.Entity;
using ProjectS360.MODEL.Entities;
using ProjectS360.MODEL.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProjectS360.MODEL.Context
{
    public class ProjectContext : DbContext
    {
        #region Constructor
        public ProjectContext() : base("Name=ProjectContext")
        {

        }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Hazırladığımız map sınıflarındaki konfügirasyonları da dahil ediyoruz.
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CompanyMap());

            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region Entities
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        #endregion

        #region SaveChangesMethod
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now;
            int user = 1;
            string ip = "1";

            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;

                if (item != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.CreatedADUserName = identity;
                        entity.CreatedComputerName = computerName;
                        entity.CreatedDate = dateTime;
                        entity.CreatedBy = user;
                        entity.CreatedIP = ip;

                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.ModifiedADUserName = identity;
                        entity.ModifiedComputerName = computerName;
                        entity.ModifiedDate = dateTime;
                        entity.ModifiedBy = user;
                        entity.ModifiedIP = ip;
                    }
                }
            }
            return base.SaveChanges();
        } 
        #endregion
    }
}
