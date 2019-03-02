namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductId_added_in_Brand_table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "BrandId" });
            AddColumn("dbo.Brands", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Brands", "ProductId");
            AddForeignKey("dbo.Brands", "ProductId", "dbo.Products", "Id");
            DropColumn("dbo.Products", "BrandId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "BrandId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Brands", "ProductId", "dbo.Products");
            DropIndex("dbo.Brands", new[] { "ProductId" });
            DropColumn("dbo.Brands", "ProductId");
            CreateIndex("dbo.Products", "BrandId");
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "Id");
        }
    }
}
