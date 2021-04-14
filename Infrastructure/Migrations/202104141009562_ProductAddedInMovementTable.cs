namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductAddedInMovementTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movements", "ProductId", c => c.Int());
            CreateIndex("dbo.Movements", "ProductId");
            AddForeignKey("dbo.Movements", "ProductId", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movements", "ProductId", "dbo.Products");
            DropIndex("dbo.Movements", new[] { "ProductId" });
            DropColumn("dbo.Movements", "ProductId");
        }
    }
}
