namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseUpdatesAndInventoryUnit1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InventoryUnits", "ReceiveAdjustment", c => c.String());
            AddColumn("dbo.InventoryUnits", "IssueAdjustment", c => c.String());
            DropColumn("dbo.InventoryUnits", "ReceiveStatus");
            DropColumn("dbo.InventoryUnits", "IssueStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InventoryUnits", "IssueStatus", c => c.String());
            AddColumn("dbo.InventoryUnits", "ReceiveStatus", c => c.String());
            DropColumn("dbo.InventoryUnits", "IssueAdjustment");
            DropColumn("dbo.InventoryUnits", "ReceiveAdjustment");
        }
    }
}
