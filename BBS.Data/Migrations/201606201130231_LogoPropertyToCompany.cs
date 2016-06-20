namespace BBS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogoPropertyToCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "LogoImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "LogoImage");
        }
    }
}
