namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedSupplyPriceToRateAndSupplyAmountToTotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InventoryUnits", "Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InventoryUnits", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.InventoryUnits", "SupplyPrice");
            DropColumn("dbo.InventoryUnits", "TotalSupplyAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InventoryUnits", "TotalSupplyAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InventoryUnits", "SupplyPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.InventoryUnits", "Total");
            DropColumn("dbo.InventoryUnits", "Rate");
        }
    }
}
