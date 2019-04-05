namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WarehouseUpdatedAgain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Warehouses", "Location", c => c.String());
            DropColumn("dbo.Warehouses", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Warehouses", "Name", c => c.String());
            DropColumn("dbo.Warehouses", "Location");
        }
    }
}
