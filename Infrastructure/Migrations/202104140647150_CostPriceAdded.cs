namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CostPriceAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CostPriceTotal", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.OrderItems", "CostPriceRate", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.OrderItems", "CostPriceTotal", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Transactions", "CostPriceTotal", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "CostPriceTotal");
            DropColumn("dbo.OrderItems", "CostPriceTotal");
            DropColumn("dbo.OrderItems", "CostPriceRate");
            DropColumn("dbo.Orders", "CostPriceTotal");
        }
    }
}
