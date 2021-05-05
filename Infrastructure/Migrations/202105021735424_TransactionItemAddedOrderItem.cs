namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionItemAddedOrderItem : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TransactionItems", name: "InventoryOrderItemId", newName: "PurchaseOrderItemId");
            RenameIndex(table: "dbo.TransactionItems", name: "IX_InventoryOrderItemId", newName: "IX_PurchaseOrderItemId");
            AddColumn("dbo.TransactionItems", "SaleOrderItemId", c => c.Int());
            AddColumn("dbo.TransactionItems", "CostPriceRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TransactionItems", "CostPriceTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.TransactionItems", "SaleOrderItemId");
            AddForeignKey("dbo.TransactionItems", "SaleOrderItemId", "dbo.OrderItems", "Id");
            DropColumn("dbo.TransactionItems", "Rate");
            DropColumn("dbo.TransactionItems", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransactionItems", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TransactionItems", "Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.TransactionItems", "SaleOrderItemId", "dbo.OrderItems");
            DropIndex("dbo.TransactionItems", new[] { "SaleOrderItemId" });
            DropColumn("dbo.TransactionItems", "CostPriceTotal");
            DropColumn("dbo.TransactionItems", "CostPriceRate");
            DropColumn("dbo.TransactionItems", "SaleOrderItemId");
            RenameIndex(table: "dbo.TransactionItems", name: "IX_PurchaseOrderItemId", newName: "IX_InventoryOrderItemId");
            RenameColumn(table: "dbo.TransactionItems", name: "PurchaseOrderItemId", newName: "InventoryOrderItemId");
        }
    }
}
