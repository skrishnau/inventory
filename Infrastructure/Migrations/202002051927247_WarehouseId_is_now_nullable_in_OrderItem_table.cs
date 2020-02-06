namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WarehouseId_is_now_nullable_in_OrderItem_table : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.OrderItems", new[] { "WarehouseId" });
            AlterColumn("dbo.OrderItems", "WarehouseId", c => c.Int());
            CreateIndex("dbo.OrderItems", "WarehouseId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrderItems", new[] { "WarehouseId" });
            AlterColumn("dbo.OrderItems", "WarehouseId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "WarehouseId");
        }
    }
}
