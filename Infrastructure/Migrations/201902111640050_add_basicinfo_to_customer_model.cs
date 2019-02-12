namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_basicinfo_to_customer_model : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "BasicInfo_Id" });
            RenameColumn(table: "dbo.Customers", name: "BasicInfo_Id", newName: "BasicInfoId");
            AlterColumn("dbo.Customers", "BasicInfoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "BasicInfoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "BasicInfoId" });
            AlterColumn("dbo.Customers", "BasicInfoId", c => c.Int());
            RenameColumn(table: "dbo.Customers", name: "BasicInfoId", newName: "BasicInfo_Id");
            CreateIndex("dbo.Customers", "BasicInfo_Id");
        }
    }
}
