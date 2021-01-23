namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPaymentTypeInPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PaymentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "PaymentType");
        }
    }
}
