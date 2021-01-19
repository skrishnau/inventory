namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyColumnAddedInUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Company", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Company");
        }
    }
}
