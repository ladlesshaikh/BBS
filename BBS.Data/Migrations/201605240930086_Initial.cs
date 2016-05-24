namespace BBS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        BranchCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CKRegNo = c.String(),
                        Account = c.String(),
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
                        Rate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CreditTermsValidityTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                        Description = c.String(),
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
            
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        Quantity = c.Double(nullable: false),
                        UnitCost = c.Double(nullable: false),
                        InvoiceType_Id = c.Int(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InvoiceBillingTypes", t => t.InvoiceType_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.InvoiceType_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.InvoiceBillingTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceDocuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocDate = c.DateTime(nullable: false),
                        Reference = c.String(),
                        CreditTermsOrValidity_Id = c.Int(),
                        Customer_Id = c.Int(),
                        InvoiceBillingType_Id = c.Int(),
                        InvoiceDocumentType_Id = c.Int(),
                        PaymentBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditTermsValidityTypes", t => t.CreditTermsOrValidity_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.InvoiceBillingTypes", t => t.InvoiceBillingType_Id)
                .ForeignKey("dbo.InvoiceDocumentTypes", t => t.InvoiceDocumentType_Id)
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentBy_Id)
                .Index(t => t.CreditTermsOrValidity_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.InvoiceBillingType_Id)
                .Index(t => t.InvoiceDocumentType_Id)
                .Index(t => t.PaymentBy_Id);
            
            CreateTable(
                "dbo.InvoiceDocumentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceDocuments", "PaymentBy_Id", "dbo.PaymentTypes");
            DropForeignKey("dbo.InvoiceDocuments", "InvoiceDocumentType_Id", "dbo.InvoiceDocumentTypes");
            DropForeignKey("dbo.InvoiceDocuments", "InvoiceBillingType_Id", "dbo.InvoiceBillingTypes");
            DropForeignKey("dbo.InvoiceDocuments", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.InvoiceDocuments", "CreditTermsOrValidity_Id", "dbo.CreditTermsValidityTypes");
            DropForeignKey("dbo.Customers", "TaxDetails_Id", "dbo.TaxDetails");
            DropForeignKey("dbo.InvoiceItems", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.InvoiceItems", "InvoiceType_Id", "dbo.InvoiceBillingTypes");
            DropForeignKey("dbo.Customers", "AddressDetails_Id", "dbo.Address");
            DropForeignKey("dbo.Companies", "Tax_Id", "dbo.TaxDetails");
            DropForeignKey("dbo.Companies", "Bank_Id", "dbo.BankDetails");
            DropForeignKey("dbo.Companies", "AddressDetails_Id", "dbo.Address");
            DropIndex("dbo.InvoiceDocuments", new[] { "PaymentBy_Id" });
            DropIndex("dbo.InvoiceDocuments", new[] { "InvoiceDocumentType_Id" });
            DropIndex("dbo.InvoiceDocuments", new[] { "InvoiceBillingType_Id" });
            DropIndex("dbo.InvoiceDocuments", new[] { "Customer_Id" });
            DropIndex("dbo.InvoiceDocuments", new[] { "CreditTermsOrValidity_Id" });
            DropIndex("dbo.InvoiceItems", new[] { "Customer_Id" });
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceType_Id" });
            DropIndex("dbo.Customers", new[] { "TaxDetails_Id" });
            DropIndex("dbo.Customers", new[] { "AddressDetails_Id" });
            DropIndex("dbo.Companies", new[] { "Tax_Id" });
            DropIndex("dbo.Companies", new[] { "Bank_Id" });
            DropIndex("dbo.Companies", new[] { "AddressDetails_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.InvoiceDocumentTypes");
            DropTable("dbo.InvoiceDocuments");
            DropTable("dbo.InvoiceBillingTypes");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.Customers");
            DropTable("dbo.CreditTermsValidityTypes");
            DropTable("dbo.TaxDetails");
            DropTable("dbo.Companies");
            DropTable("dbo.BankDetails");
            DropTable("dbo.Address");
        }
    }
}
