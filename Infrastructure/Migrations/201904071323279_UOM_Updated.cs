namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UOM_Updated : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Uoms", new[] { "BaseUnitId" });
            AlterColumn("dbo.Uoms", "BaseUnitId", c => c.Int());
            CreateIndex("dbo.Uoms", "BaseUnitId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Uoms", new[] { "BaseUnitId" });
            AlterColumn("dbo.Uoms", "BaseUnitId", c => c.Int(nullable: false));
            CreateIndex("dbo.Uoms", "BaseUnitId");
        }
    }
}
