namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VoidAddedInPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "IsVoid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "IsVoid");
        }
    }
}
