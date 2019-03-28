namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GroupCOlumnAddedInAppSetting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppSettings", "Group", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppSettings", "Group");
        }
    }
}
