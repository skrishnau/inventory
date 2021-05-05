namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableorderItemId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TransactionItems", new[] { "InventoryOrderItemId" });
            AlterColumn("dbo.TransactionItems", "InventoryOrderItemId", c => c.Int());
            CreateIndex("dbo.TransactionItems", "InventoryOrderItemId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TransactionItems", new[] { "InventoryOrderItemId" });
            AlterColumn("dbo.TransactionItems", "InventoryOrderItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.TransactionItems", "InventoryOrderItemId");
        }
    }
}
