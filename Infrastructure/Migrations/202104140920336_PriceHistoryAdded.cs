namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceHistoryAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        PriceType = c.String(),
                        PackageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.PackageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PriceHistories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PriceHistories", "PackageId", "dbo.Packages");
            DropIndex("dbo.PriceHistories", new[] { "PackageId" });
            DropIndex("dbo.PriceHistories", new[] { "ProductId" });
            DropTable("dbo.PriceHistories");
        }
    }
}
