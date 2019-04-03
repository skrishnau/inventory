namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInfoUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasicInfoes", "Website", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BasicInfoes", "Website");
        }
    }
}
