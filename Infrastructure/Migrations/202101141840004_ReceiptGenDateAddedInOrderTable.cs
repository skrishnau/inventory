namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReceiptGenDateAddedInOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsReceiptGenerated", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "ReceiptGeneratedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "ReceiptGeneratedDate");
            DropColumn("dbo.Orders", "IsReceiptGenerated");
        }
    }
}
