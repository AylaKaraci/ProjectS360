namespace ProjectS360.MODEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class App : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Logo = c.String(),
                        LogoPath = c.String(),
                        CompanyName = c.String(),
                        CompanyFullName = c.String(),
                        CompanyEmail = c.String(),
                        CompanyAddres = c.String(),
                        MasterID = c.Int(),
                        Status = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(),
                        CreatedIP = c.String(),
                        CreatedADUserName = c.String(),
                        CreatedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(),
                        ModifiedIP = c.String(),
                        ModifiedADUserName = c.String(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 100),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        ImagePath = c.String(),
                        TitleName = c.String(),
                        Role = c.Int(),
                        BirthDate = c.DateTime(storeType: "date"),
                        CompanyID = c.Int(nullable: false),
                        MasterID = c.Int(),
                        Status = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(),
                        CreatedIP = c.String(),
                        CreatedADUserName = c.String(),
                        CreatedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(),
                        ModifiedIP = c.String(),
                        ModifiedADUserName = c.String(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Users", new[] { "CompanyID" });
            DropTable("dbo.Users");
            DropTable("dbo.Companies");
        }
    }
}
