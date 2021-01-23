namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentTableUpdated1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "DueAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Payments", "PaymentMethod", c => c.String());
            DropColumn("dbo.Payments", "PaymentType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "PaymentType", c => c.String());
            DropColumn("dbo.Payments", "PaymentMethod");
            DropColumn("dbo.Payments", "DueAmount");
        }
    }
}
