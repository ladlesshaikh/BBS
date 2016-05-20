namespace BBS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetNo = c.String(),
                        SubUrb = c.String(),
                        CityOrTown = c.String(),
                        PostalCode = c.String(),
                        Telephone = c.String(),
                        Email = c.String(),
                        Fax = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BankDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Branch = c.String(),
                        Account = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CKregNo = c.String(),
                        AddressDetails_Id = c.Int(),
                        Bank_Id = c.Int(),
                        Tax_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.AddressDetails_Id)
                .ForeignKey("dbo.BankDetails", t => t.Bank_Id)
                .ForeignKey("dbo.TaxDetails", t => t.Tax_Id)
                .Index(t => t.AddressDetails_Id)
                .Index(t => t.Bank_Id)
                .Index(t => t.Tax_Id);
            
            CreateTable(
                "dbo.TaxDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaxNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddressDetails_Id = c.Int(),
                        TaxDetails_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.AddressDetails_Id)
                .ForeignKey("dbo.TaxDetails", t => t.TaxDetails_Id)
                .Index(t => t.AddressDetails_Id)
                .Index(t => t.TaxDetails_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "TaxDetails_Id", "dbo.TaxDetails");
            DropForeignKey("dbo.Customers", "AddressDetails_Id", "dbo.Address");
            DropForeignKey("dbo.Companies", "Tax_Id", "dbo.TaxDetails");
            DropForeignKey("dbo.Companies", "Bank_Id", "dbo.BankDetails");
            DropForeignKey("dbo.Companies", "AddressDetails_Id", "dbo.Address");
            DropIndex("dbo.Customers", new[] { "TaxDetails_Id" });
            DropIndex("dbo.Customers", new[] { "AddressDetails_Id" });
            DropIndex("dbo.Companies", new[] { "Tax_Id" });
            DropIndex("dbo.Companies", new[] { "Bank_Id" });
            DropIndex("dbo.Companies", new[] { "AddressDetails_Id" });
            DropTable("dbo.Customers");
            DropTable("dbo.TaxDetails");
            DropTable("dbo.Companies");
            DropTable("dbo.BankDetails");
            DropTable("dbo.Address");
        }
    }
}
