namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryUnitsUpdates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InventoryUnits", "LotNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InventoryUnits", "LotNumber", c => c.Int(nullable: false));
        }
    }
}
