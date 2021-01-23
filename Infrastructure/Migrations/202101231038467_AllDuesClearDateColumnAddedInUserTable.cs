namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllDuesClearDateColumnAddedInUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AllDuesClearDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AllDuesClearDate");
        }
    }
}
