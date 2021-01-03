namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedcolumnnames : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OrderItems", name: "PurchaseOrderId", newName: "OrderId");
            RenameIndex(table: "dbo.OrderItems", name: "IX_PurchaseOrderId", newName: "IX_OrderId");
            AddColumn("dbo.OrderItems", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.OrderItems", "TotalAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.OrderItems", "Total");
            RenameIndex(table: "dbo.OrderItems", name: "IX_OrderId", newName: "IX_PurchaseOrderId");
            RenameColumn(table: "dbo.OrderItems", name: "OrderId", newName: "PurchaseOrderId");
        }
    }
}
