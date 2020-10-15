namespace ProjectS360.MODEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyTableUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "PhoneNumber", c => c.String());
            DropColumn("dbo.Companies", "LogoPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "LogoPath", c => c.String());
            DropColumn("dbo.Companies", "PhoneNumber");
        }
    }
}
