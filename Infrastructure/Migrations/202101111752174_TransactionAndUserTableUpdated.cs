namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionAndUserTableUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Debit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transactions", "Credit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transactions", "DrCr", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "TotalAmount");
            DropColumn("dbo.Users", "PaidAmount");
            DropColumn("dbo.Transactions", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Users", "PaidAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Users", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transactions", "DrCr", c => c.Short(nullable: false));
            DropColumn("dbo.Transactions", "Credit");
            DropColumn("dbo.Transactions", "Debit");
        }
    }
}
