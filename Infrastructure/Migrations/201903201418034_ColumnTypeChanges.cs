namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnTypeChanges : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PurchaseOrders", new[] { "CreatedById" });
            AlterColumn("dbo.PurchaseOrders", "CreatedById", c => c.Int());
            CreateIndex("dbo.PurchaseOrders", "CreatedById");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PurchaseOrders", new[] { "CreatedById" });
            AlterColumn("dbo.PurchaseOrders", "CreatedById", c => c.Int(nullable: false));
            CreateIndex("dbo.PurchaseOrders", "CreatedById");
        }
    }
}
