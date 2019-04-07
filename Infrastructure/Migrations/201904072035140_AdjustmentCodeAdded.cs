namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustmentCodeAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdjustmentCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        AffectsDemand = c.Boolean(nullable: false),
                        Use = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdjustmentCodes");
        }
    }
}
