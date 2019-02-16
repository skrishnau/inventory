namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addwarehouseIcollectiontobranchtable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Branches", "Branch_Id", "dbo.Branches");
            DropIndex("dbo.Branches", new[] { "Branch_Id" });
            DropColumn("dbo.Branches", "Branch_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Branches", "Branch_Id", c => c.Int());
            CreateIndex("dbo.Branches", "Branch_Id");
            AddForeignKey("dbo.Branches", "Branch_Id", "dbo.Branches", "Id");
        }
    }
}
