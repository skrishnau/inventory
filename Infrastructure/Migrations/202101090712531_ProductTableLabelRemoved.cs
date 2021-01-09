namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductTableLabelRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Label");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Label", c => c.String());
        }
    }
}
