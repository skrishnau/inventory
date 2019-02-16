namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class error_fix1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Warehouses", new[] { "Branch_Id" });
            RenameColumn(table: "dbo.Warehouses", name: "Branch_Id", newName: "BranchId");
            AddColumn("dbo.Branches", "Branch_Id", c => c.Int());
            AlterColumn("dbo.Warehouses", "BranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Branches", "Branch_Id");
            CreateIndex("dbo.Warehouses", "BranchId");
            AddForeignKey("dbo.Branches", "Branch_Id", "dbo.Branches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branches", "Branch_Id", "dbo.Branches");
            DropIndex("dbo.Warehouses", new[] { "BranchId" });
            DropIndex("dbo.Branches", new[] { "Branch_Id" });
            AlterColumn("dbo.Warehouses", "BranchId", c => c.Int());
            DropColumn("dbo.Branches", "Branch_Id");
            RenameColumn(table: "dbo.Warehouses", name: "BranchId", newName: "Branch_Id");
            CreateIndex("dbo.Warehouses", "Branch_Id");
        }
    }
}
