namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WarehouseUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Warehouses", "BranchId", "dbo.Branches");
            DropIndex("dbo.Warehouses", new[] { "BranchId" });
            AddColumn("dbo.Warehouses", "Name", c => c.String());
            AddColumn("dbo.Warehouses", "Hold", c => c.Boolean(nullable: false));
            AddColumn("dbo.Warehouses", "MixedProduct", c => c.Boolean(nullable: false));
            AddColumn("dbo.Warehouses", "Staging", c => c.Boolean(nullable: false));
            DropColumn("dbo.Warehouses", "Location");
            DropColumn("dbo.Warehouses", "BranchId");
            DropColumn("dbo.Warehouses", "Code");
            DropColumn("dbo.Warehouses", "CanMoveStocksToBranch");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Warehouses", "CanMoveStocksToBranch", c => c.Boolean(nullable: false));
            AddColumn("dbo.Warehouses", "Code", c => c.String());
            AddColumn("dbo.Warehouses", "BranchId", c => c.Int(nullable: false));
            AddColumn("dbo.Warehouses", "Location", c => c.String());
            DropColumn("dbo.Warehouses", "Staging");
            DropColumn("dbo.Warehouses", "MixedProduct");
            DropColumn("dbo.Warehouses", "Hold");
            DropColumn("dbo.Warehouses", "Name");
            CreateIndex("dbo.Warehouses", "BranchId");
            AddForeignKey("dbo.Warehouses", "BranchId", "dbo.Branches", "Id");
        }
    }
}
