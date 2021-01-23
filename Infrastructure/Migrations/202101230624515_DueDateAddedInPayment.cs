namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DueDateAddedInPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "DueDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "DueDate");
        }
    }
}
