namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UOM_Table_Refined : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Uoms", "BaseUomId", "dbo.Uoms");
            DropForeignKey("dbo.Products", "BaseUomId", "dbo.Uoms");
            DropForeignKey("dbo.Products", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.OrderItems", "UomId", "dbo.Uoms");
            DropForeignKey("dbo.InventoryUnits", "UomId", "dbo.Uoms");
            DropIndex("dbo.InventoryUnits", new[] { "UomId" });
            DropIndex("dbo.OrderItems", new[] { "UomId" });
            DropIndex("dbo.Products", new[] { "PackageId" });
            DropIndex("dbo.Products", new[] { "BaseUomId" });
            DropIndex("dbo.Uoms", new[] { "BaseUomId" });
            CreateTable(
                "dbo.ProductPackages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        PackageId = c.Int(nullable: false),
                        IsBasePackage = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.PackageId);
            
            AddColumn("dbo.Uoms", "PackageId", c => c.Int(nullable: false));
            AddColumn("dbo.Uoms", "RelatedPackageId", c => c.Int(nullable: false));
            AddColumn("dbo.Uoms", "ProductId", c => c.Int());
            CreateIndex("dbo.Uoms", "PackageId");
            CreateIndex("dbo.Uoms", "RelatedPackageId");
            CreateIndex("dbo.Uoms", "ProductId");
            AddForeignKey("dbo.Uoms", "PackageId", "dbo.Packages", "Id");
            AddForeignKey("dbo.Uoms", "ProductId", "dbo.Products", "Id");
            AddForeignKey("dbo.Uoms", "RelatedPackageId", "dbo.Packages", "Id");
            DropColumn("dbo.InventoryUnits", "UomId");
            DropColumn("dbo.OrderItems", "UomId");
            DropColumn("dbo.Products", "PackageId");
            DropColumn("dbo.Products", "BaseUomId");
            DropColumn("dbo.Uoms", "Name");
            DropColumn("dbo.Uoms", "BaseUomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Uoms", "BaseUomId", c => c.Int());
            AddColumn("dbo.Uoms", "Name", c => c.String());
            AddColumn("dbo.Products", "BaseUomId", c => c.Int());
            AddColumn("dbo.Products", "PackageId", c => c.Int());
            AddColumn("dbo.OrderItems", "UomId", c => c.Int());
            AddColumn("dbo.InventoryUnits", "UomId", c => c.Int());
            DropForeignKey("dbo.Uoms", "RelatedPackageId", "dbo.Packages");
            DropForeignKey("dbo.Uoms", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Uoms", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.ProductPackages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductPackages", "PackageId", "dbo.Packages");
            DropIndex("dbo.Uoms", new[] { "ProductId" });
            DropIndex("dbo.Uoms", new[] { "RelatedPackageId" });
            DropIndex("dbo.Uoms", new[] { "PackageId" });
            DropIndex("dbo.ProductPackages", new[] { "PackageId" });
            DropIndex("dbo.ProductPackages", new[] { "ProductId" });
            DropColumn("dbo.Uoms", "ProductId");
            DropColumn("dbo.Uoms", "RelatedPackageId");
            DropColumn("dbo.Uoms", "PackageId");
            DropTable("dbo.ProductPackages");
            CreateIndex("dbo.Uoms", "BaseUomId");
            CreateIndex("dbo.Products", "BaseUomId");
            CreateIndex("dbo.Products", "PackageId");
            CreateIndex("dbo.OrderItems", "UomId");
            CreateIndex("dbo.InventoryUnits", "UomId");
            AddForeignKey("dbo.InventoryUnits", "UomId", "dbo.Uoms", "Id");
            AddForeignKey("dbo.OrderItems", "UomId", "dbo.Uoms", "Id");
            AddForeignKey("dbo.Products", "PackageId", "dbo.Packages", "Id");
            AddForeignKey("dbo.Products", "BaseUomId", "dbo.Uoms", "Id");
            AddForeignKey("dbo.Uoms", "BaseUomId", "dbo.Uoms", "Id");
        }
    }
}
