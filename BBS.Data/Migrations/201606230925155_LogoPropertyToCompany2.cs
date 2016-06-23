namespace BBS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogoPropertyToCompany2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.InvoiceDocuments", "SubTotal");
            DropColumn("dbo.InvoiceDocuments", "Tax");
            DropColumn("dbo.InvoiceDocuments", "TotalAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvoiceDocuments", "TotalAmount", c => c.Double(nullable: false));
            AddColumn("dbo.InvoiceDocuments", "Tax", c => c.Double(nullable: false));
            AddColumn("dbo.InvoiceDocuments", "SubTotal", c => c.Double(nullable: false));
        }
    }
}
