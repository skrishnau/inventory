namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Variant_and_VariantOption_tables_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Variants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SKU = c.String(),
                        QuantityInStock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LatestUnitCostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LatestUnitSellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShowStockAlerts = c.Boolean(),
                        MinStockCountForAlert = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.VariantOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VariantId = c.Int(nullable: false),
                        OptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Options", t => t.OptionId)
                .ForeignKey("dbo.Variants", t => t.VariantId)
                .Index(t => t.VariantId)
                .Index(t => t.OptionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VariantOptions", "VariantId", "dbo.Variants");
            DropForeignKey("dbo.VariantOptions", "OptionId", "dbo.Options");
            DropForeignKey("dbo.Variants", "ProductId", "dbo.Products");
            DropIndex("dbo.VariantOptions", new[] { "OptionId" });
            DropIndex("dbo.VariantOptions", new[] { "VariantId" });
            DropIndex("dbo.Variants", new[] { "ProductId" });
            DropTable("dbo.VariantOptions");
            DropTable("dbo.Variants");
        }
    }
}
