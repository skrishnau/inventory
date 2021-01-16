namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentDueDateAddedInUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PaymentDueDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PaymentDueDate");
        }
    }
}
