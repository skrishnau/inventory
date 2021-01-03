namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentMethod = c.String(),
                        Date = c.DateTime(nullable: false),
                        PaidBy = c.String(),
                        ChequeNo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .Index(t => t.OrderId);
            
            AddColumn("dbo.Orders", "PaymentDueDate", c => c.DateTime());
            DropColumn("dbo.Orders", "PaymentMethod");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "PaymentMethod", c => c.String());
            DropForeignKey("dbo.Payments", "OrderId", "dbo.Orders");
            DropIndex("dbo.Payments", new[] { "OrderId" });
            DropColumn("dbo.Orders", "PaymentDueDate");
            DropTable("dbo.Payments");
        }
    }
}
