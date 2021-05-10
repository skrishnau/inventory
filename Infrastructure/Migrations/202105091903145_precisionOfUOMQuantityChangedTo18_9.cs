namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class precisionOfUOMQuantityChangedTo18_9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Uoms", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 9));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Uoms", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
