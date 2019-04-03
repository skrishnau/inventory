namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsMarried_changed_to_string : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BasicInfoes", "IsMarried", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BasicInfoes", "IsMarried", c => c.Boolean());
        }
    }
}
