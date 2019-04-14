namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseUpdatesAndInventoryUnit : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.InventoryUnits", new[] { "SupplierId" });
            AddColumn("dbo.PurchaseOrders", "ReferenceNumber", c => c.String());
            AddColumn("dbo.PurchaseOrderItems", "ExpirationDate", c => c.DateTime());
            AddColumn("dbo.PurchaseOrderItems", "ProductionDate", c => c.DateTime());
            AddColumn("dbo.PurchaseOrderItems", "LotNumber", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseOrderItems", "ReferenceNumber", c => c.String());
            AddColumn("dbo.PurchaseOrderItems", "Adjustment", c => c.String());
            AddColumn("dbo.PurchaseOrderItems", "SupplierId", c => c.Int());
            AlterColumn("dbo.InventoryUnits", "ProductionDate", c => c.DateTime());
            AlterColumn("dbo.InventoryUnits", "ExpirationDate", c => c.DateTime());
            AlterColumn("dbo.InventoryUnits", "SupplierId", c => c.Int());
            CreateIndex("dbo.InventoryUnits", "SupplierId");
            CreateIndex("dbo.PurchaseOrderItems", "SupplierId");
            AddForeignKey("dbo.PurchaseOrderItems", "SupplierId", "dbo.Suppliers", "Id");
            DropColumn("dbo.PurchaseOrders", "OrderNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseOrders", "OrderNumber", c => c.String());
            DropForeignKey("dbo.PurchaseOrderItems", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.PurchaseOrderItems", new[] { "SupplierId" });
            DropIndex("dbo.InventoryUnits", new[] { "SupplierId" });
            AlterColumn("dbo.InventoryUnits", "SupplierId", c => c.Int(nullable: false));
            AlterColumn("dbo.InventoryUnits", "ExpirationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.InventoryUnits", "ProductionDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.PurchaseOrderItems", "SupplierId");
            DropColumn("dbo.PurchaseOrderItems", "Adjustment");
            DropColumn("dbo.PurchaseOrderItems", "ReferenceNumber");
            DropColumn("dbo.PurchaseOrderItems", "LotNumber");
            DropColumn("dbo.PurchaseOrderItems", "ProductionDate");
            DropColumn("dbo.PurchaseOrderItems", "ExpirationDate");
            DropColumn("dbo.PurchaseOrders", "ReferenceNumber");
            CreateIndex("dbo.InventoryUnits", "SupplierId");
        }
    }
}
