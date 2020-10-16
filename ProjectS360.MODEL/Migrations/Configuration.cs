namespace ProjectS360.MODEL.Migrations
{
    using ProjectS360.MODEL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Principal;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectS360.MODEL.Context.ProjectContext>
    {
        #region Constructor
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        } 
        #endregion

        #region SeedMethod
        protected override void Seed(ProjectS360.MODEL.Context.ProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            AppUser user = new AppUser()
            {
                UserName = "admin",
                Password = "123",
                Role = Role.Admin,
                Status = CORE.Entity.Enum.Status.Active,
                CreatedDate = DateTime.Now,
                MasterID = null,
                CreatedComputerName = Environment.MachineName,
                CreatedIP = "123",
                CreatedADUserName = WindowsIdentity.GetCurrent().Name,
                Address = "Esenkent Mh. Aydýn Caddesi",
                PhoneNumber = "0001112233",
                Name = "Ayla",
                LastName = "Karacý"
            };

            Company company = new Company()
            {
                CompanyName = "S360",
                CompanyFullName = "S360 A.Þ.",
                CompanyEmail = "info@s360.com.tr",
                CompanyAddres = "Yeþilce Mah. Yunus Emre Cad. Nil Ticaret Merkezi No:8 Kat:1 34418 4.Levent, Ýstanbul",
                PhoneNumber = "+90 212 351 91 76 ",
                MasterID = null,
                CreatedComputerName = Environment.MachineName,
                CreatedIP = "123",
                CreatedADUserName = WindowsIdentity.GetCurrent().Name,

            };

            context.Users.AddOrUpdate(user);
            context.Companies.AddOrUpdate(company);

        } 
        #endregion
    }
}
