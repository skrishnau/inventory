namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTransactionItemTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionId = c.Int(nullable: false),
                        InventoryOrderItemId = c.Int(nullable: false),
                        UnitQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderItems", t => t.InventoryOrderItemId)
                .ForeignKey("dbo.Transactions", t => t.TransactionId)
                .Index(t => t.TransactionId)
                .Index(t => t.InventoryOrderItemId);
            
            AddColumn("dbo.InventoryUnits", "OrderItemId", c => c.Int());
            CreateIndex("dbo.InventoryUnits", "OrderItemId");
            AddForeignKey("dbo.InventoryUnits", "OrderItemId", "dbo.OrderItems", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionItems", "TransactionId", "dbo.Transactions");
            DropForeignKey("dbo.TransactionItems", "InventoryOrderItemId", "dbo.OrderItems");
            DropForeignKey("dbo.InventoryUnits", "OrderItemId", "dbo.OrderItems");
            DropIndex("dbo.TransactionItems", new[] { "InventoryOrderItemId" });
            DropIndex("dbo.TransactionItems", new[] { "TransactionId" });
            DropIndex("dbo.InventoryUnits", new[] { "OrderItemId" });
            DropColumn("dbo.InventoryUnits", "OrderItemId");
            DropTable("dbo.TransactionItems");
        }
    }
}
