namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentTableUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "ReferenceNumber", c => c.String());
            AddColumn("dbo.Payments", "PaymentType", c => c.String());
            AddColumn("dbo.Payments", "Bank", c => c.String());
            DropColumn("dbo.Payments", "PaymentMethod");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "PaymentMethod", c => c.String());
            DropColumn("dbo.Payments", "Bank");
            DropColumn("dbo.Payments", "PaymentType");
            DropColumn("dbo.Payments", "ReferenceNumber");
        }
    }
}
