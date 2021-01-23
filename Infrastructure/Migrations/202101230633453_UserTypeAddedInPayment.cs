namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTypeAddedInPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "UserType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "UserType");
        }
    }
}
