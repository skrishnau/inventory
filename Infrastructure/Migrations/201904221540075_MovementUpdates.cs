namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovementUpdates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movements", "ProductId", "dbo.Products");
            DropIndex("dbo.Movements", new[] { "ProductId" });
            DropColumn("dbo.Movements", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movements", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movements", "ProductId");
            AddForeignKey("dbo.Movements", "ProductId", "dbo.Products", "Id");
        }
    }
}
