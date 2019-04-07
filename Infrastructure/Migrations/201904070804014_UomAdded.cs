namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UomAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Uoms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Unit = c.String(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseUnitId = c.Int(nullable: false),
                        Use = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Uoms", t => t.BaseUnitId)
                .Index(t => t.BaseUnitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Uoms", "BaseUnitId", "dbo.Uoms");
            DropIndex("dbo.Uoms", new[] { "BaseUnitId" });
            DropTable("dbo.Uoms");
        }
    }
}
