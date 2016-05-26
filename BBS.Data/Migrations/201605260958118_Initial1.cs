namespace BBS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceDocuments", "Company_Id", c => c.Int());
            CreateIndex("dbo.InvoiceDocuments", "Company_Id");
            AddForeignKey("dbo.InvoiceDocuments", "Company_Id", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceDocuments", "Company_Id", "dbo.Companies");
            DropIndex("dbo.InvoiceDocuments", new[] { "Company_Id" });
            DropColumn("dbo.InvoiceDocuments", "Company_Id");
        }
    }
}
