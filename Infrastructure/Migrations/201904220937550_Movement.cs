namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Description = c.String(),
                        Reference = c.String(),
                        AdjustmentCode = c.String(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movements", "ProductId", "dbo.Products");
            DropIndex("dbo.Movements", new[] { "ProductId" });
            DropTable("dbo.Movements");
        }
    }
}
