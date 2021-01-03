namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentTableAdded1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DiscountPercent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "DiscountAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "PaidAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "PaymentCompleteDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PaymentCompleteDate");
            DropColumn("dbo.Orders", "PaidAmount");
            DropColumn("dbo.Orders", "DiscountAmount");
            DropColumn("dbo.Orders", "DiscountPercent");
        }
    }
}
