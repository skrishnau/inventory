namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeysMadeNullableInProduct : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.InventoryUnits", new[] { "WarehouseId" });
            DropIndex("dbo.InventoryUnits", new[] { "UomId" });
            DropIndex("dbo.InventoryUnits", new[] { "PackageId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "PackageId" });
            DropIndex("dbo.Products", new[] { "BaseUomId" });
            DropIndex("dbo.Products", new[] { "WarehouseId" });
            DropIndex("dbo.OrderItems", new[] { "UomId" });
            DropIndex("dbo.OrderItems", new[] { "PackageId" });
            AlterColumn("dbo.InventoryUnits", "WarehouseId", c => c.Int());
            AlterColumn("dbo.InventoryUnits", "UomId", c => c.Int());
            AlterColumn("dbo.InventoryUnits", "PackageId", c => c.Int());
            AlterColumn("dbo.Products", "CategoryId", c => c.Int());
            AlterColumn("dbo.Products", "PackageId", c => c.Int());
            AlterColumn("dbo.Products", "BaseUomId", c => c.Int());
            AlterColumn("dbo.Products", "WarehouseId", c => c.Int());
            AlterColumn("dbo.OrderItems", "UomId", c => c.Int());
            AlterColumn("dbo.OrderItems", "PackageId", c => c.Int());
            CreateIndex("dbo.InventoryUnits", "WarehouseId");
            CreateIndex("dbo.InventoryUnits", "UomId");
            CreateIndex("dbo.InventoryUnits", "PackageId");
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Products", "PackageId");
            CreateIndex("dbo.Products", "BaseUomId");
            CreateIndex("dbo.Products", "WarehouseId");
            CreateIndex("dbo.OrderItems", "UomId");
            CreateIndex("dbo.OrderItems", "PackageId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrderItems", new[] { "PackageId" });
            DropIndex("dbo.OrderItems", new[] { "UomId" });
            DropIndex("dbo.Products", new[] { "WarehouseId" });
            DropIndex("dbo.Products", new[] { "BaseUomId" });
            DropIndex("dbo.Products", new[] { "PackageId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.InventoryUnits", new[] { "PackageId" });
            DropIndex("dbo.InventoryUnits", new[] { "UomId" });
            DropIndex("dbo.InventoryUnits", new[] { "WarehouseId" });
            AlterColumn("dbo.OrderItems", "PackageId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderItems", "UomId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "WarehouseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "BaseUomId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "PackageId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.InventoryUnits", "PackageId", c => c.Int(nullable: false));
            AlterColumn("dbo.InventoryUnits", "UomId", c => c.Int(nullable: false));
            AlterColumn("dbo.InventoryUnits", "WarehouseId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "PackageId");
            CreateIndex("dbo.OrderItems", "UomId");
            CreateIndex("dbo.Products", "WarehouseId");
            CreateIndex("dbo.Products", "BaseUomId");
            CreateIndex("dbo.Products", "PackageId");
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.InventoryUnits", "PackageId");
            CreateIndex("dbo.InventoryUnits", "UomId");
            CreateIndex("dbo.InventoryUnits", "WarehouseId");
        }
    }
}
