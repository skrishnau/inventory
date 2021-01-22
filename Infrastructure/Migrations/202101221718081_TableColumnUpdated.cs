namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableColumnUpdated : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Payments", name: "OrderId", newName: "Order_Id");
            RenameIndex(table: "dbo.Payments", name: "IX_OrderId", newName: "IX_Order_Id");
            AddColumn("dbo.Orders", "IsVoid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IsVoid");
            RenameIndex(table: "dbo.Payments", name: "IX_Order_Id", newName: "IX_OrderId");
            RenameColumn(table: "dbo.Payments", name: "Order_Id", newName: "OrderId");
        }
    }
}
