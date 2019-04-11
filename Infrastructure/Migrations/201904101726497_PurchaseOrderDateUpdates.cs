namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseOrderDateUpdates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseOrders", "OrderDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseOrders", "OrderDate", c => c.DateTime(nullable: false));
        }
    }
}
