namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class POUPdaates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseOrders", "IsOrderSent", c => c.Boolean(nullable: false));
            AddColumn("dbo.PurchaseOrders", "OrderSentDate", c => c.DateTime());
            DropColumn("dbo.PurchaseOrders", "OrderDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseOrders", "OrderDate", c => c.DateTime());
            DropColumn("dbo.PurchaseOrders", "OrderSentDate");
            DropColumn("dbo.PurchaseOrders", "IsOrderSent");
        }
    }
}
