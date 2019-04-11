namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseUpdates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Variants", "ProductId", "dbo.Products");
            DropForeignKey("dbo.SaleItems", "VariantId", "dbo.Variants");
            DropIndex("dbo.Variants", new[] { "ProductId" });
            DropIndex("dbo.SaleItems", new[] { "VariantId" });
            DropColumn("dbo.PurchaseOrderItems", "DeletedAt");
            DropColumn("dbo.SaleItems", "VariantId");
            DropTable("dbo.Variants");
        }
        
        public override void Down()
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
                        Alert = c.Boolean(),
                        MinStockCountForAlert = c.Int(),
                        AttributesJSON = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SaleItems", "VariantId", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseOrderItems", "DeletedAt", c => c.DateTime());
            CreateIndex("dbo.SaleItems", "VariantId");
            CreateIndex("dbo.Variants", "ProductId");
            AddForeignKey("dbo.SaleItems", "VariantId", "dbo.Variants", "Id");
            AddForeignKey("dbo.Variants", "ProductId", "dbo.Products", "Id");
        }
    }
}
