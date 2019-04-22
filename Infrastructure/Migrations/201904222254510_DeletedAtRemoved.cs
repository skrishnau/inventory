namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedAtRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Branches", "DeletedAt");
            DropColumn("dbo.Counters", "DeletedAt");
            DropColumn("dbo.Products", "DeletedAt");
            DropColumn("dbo.Warehouses", "DeletedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Warehouses", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Products", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Counters", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Branches", "DeletedAt", c => c.DateTime());
        }
    }
}
