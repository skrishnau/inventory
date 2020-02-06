namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToWarehouseColumnAddedInOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ToWarehouseId", c => c.Int());
            CreateIndex("dbo.Orders", "ToWarehouseId");
            AddForeignKey("dbo.Orders", "ToWarehouseId", "dbo.Warehouses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ToWarehouseId", "dbo.Warehouses");
            DropIndex("dbo.Orders", new[] { "ToWarehouseId" });
            DropColumn("dbo.Orders", "ToWarehouseId");
        }
    }
}
