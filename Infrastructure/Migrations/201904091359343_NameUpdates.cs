namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameUpdates : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Uoms", name: "BaseUnitId", newName: "BaseUomId");
            RenameIndex(table: "dbo.Uoms", name: "IX_BaseUnitId", newName: "IX_BaseUomId");
            AddColumn("dbo.Uoms", "Name", c => c.String());
            AddColumn("dbo.Warehouses", "Name", c => c.String());
            AddColumn("dbo.Warehouses", "Use", c => c.Boolean(nullable: false));
            DropColumn("dbo.Uoms", "Unit");
            DropColumn("dbo.Warehouses", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Warehouses", "Location", c => c.String());
            AddColumn("dbo.Uoms", "Unit", c => c.String());
            DropColumn("dbo.Warehouses", "Use");
            DropColumn("dbo.Warehouses", "Name");
            DropColumn("dbo.Uoms", "Name");
            RenameIndex(table: "dbo.Uoms", name: "IX_BaseUomId", newName: "IX_BaseUnitId");
            RenameColumn(table: "dbo.Uoms", name: "BaseUomId", newName: "BaseUnitId");
        }
    }
}
