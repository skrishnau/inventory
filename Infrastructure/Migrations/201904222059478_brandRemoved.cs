namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class brandRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Brands", "ProductId", "dbo.Products");
            DropIndex("dbo.Brands", new[] { "ProductId" });
            DropTable("dbo.Brands");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProductId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Brands", "ProductId");
            AddForeignKey("dbo.Brands", "ProductId", "dbo.Products", "Id");
        }
    }
}
