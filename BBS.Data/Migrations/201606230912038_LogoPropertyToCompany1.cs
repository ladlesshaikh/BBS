namespace BBS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogoPropertyToCompany1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceDocuments", "SubTotal", c => c.Double(nullable: false));
            AddColumn("dbo.InvoiceDocuments", "Tax", c => c.Double(nullable: false));
            AddColumn("dbo.InvoiceDocuments", "TotalAmount", c => c.Double(nullable: false));
            AddColumn("dbo.InvoiceDocuments", "PaidAmount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceDocuments", "PaidAmount");
            DropColumn("dbo.InvoiceDocuments", "TotalAmount");
            DropColumn("dbo.InvoiceDocuments", "Tax");
            DropColumn("dbo.InvoiceDocuments", "SubTotal");
        }
    }
}
