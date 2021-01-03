namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentMethodAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PaymentMethod", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PaymentMethod");
        }
    }
}
