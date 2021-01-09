namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaidAmountAddedInUserTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Payments", new[] { "OrderId" });
            AddColumn("dbo.Users", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Users", "PaidAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Payments", "UserId", c => c.Int());
            AlterColumn("dbo.Payments", "OrderId", c => c.Int());
            CreateIndex("dbo.Payments", "OrderId");
            CreateIndex("dbo.Payments", "UserId");
            AddForeignKey("dbo.Payments", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "UserId", "dbo.Users");
            DropIndex("dbo.Payments", new[] { "UserId" });
            DropIndex("dbo.Payments", new[] { "OrderId" });
            AlterColumn("dbo.Payments", "OrderId", c => c.Int(nullable: false));
            DropColumn("dbo.Payments", "UserId");
            DropColumn("dbo.Users", "PaidAmount");
            DropColumn("dbo.Users", "TotalAmount");
            CreateIndex("dbo.Payments", "OrderId");
        }
    }
}
