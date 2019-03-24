namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseTableUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseId = c.Int(nullable: false),
                        VariantId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId)
                .ForeignKey("dbo.Variants", t => t.VariantId)
                .Index(t => t.PurchaseId)
                .Index(t => t.VariantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseItems", "VariantId", "dbo.Variants");
            DropForeignKey("dbo.PurchaseItems", "PurchaseId", "dbo.Purchases");
            DropIndex("dbo.PurchaseItems", new[] { "VariantId" });
            DropIndex("dbo.PurchaseItems", new[] { "PurchaseId" });
            DropTable("dbo.PurchaseItems");
        }
    }
}
