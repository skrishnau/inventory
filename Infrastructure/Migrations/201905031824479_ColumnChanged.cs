namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "LotNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "LotNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "LotNo", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "LotNumber");
        }
    }
}
