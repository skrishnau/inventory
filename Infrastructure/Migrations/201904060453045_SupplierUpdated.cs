namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupplierUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasicInfoes", "Fax", c => c.String());
            AddColumn("dbo.BasicInfoes", "Notes", c => c.String());
            AddColumn("dbo.Suppliers", "SalesPerson", c => c.String());
            AddColumn("dbo.Suppliers", "MyCustomerAccount", c => c.String());
            DropColumn("dbo.Suppliers", "Fax");
            DropColumn("dbo.Suppliers", "Website");
            DropColumn("dbo.Suppliers", "PhoneSecond");
            DropColumn("dbo.Suppliers", "ContactPersonName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "ContactPersonName", c => c.String());
            AddColumn("dbo.Suppliers", "PhoneSecond", c => c.String());
            AddColumn("dbo.Suppliers", "Website", c => c.String());
            AddColumn("dbo.Suppliers", "Fax", c => c.String());
            DropColumn("dbo.Suppliers", "MyCustomerAccount");
            DropColumn("dbo.Suppliers", "SalesPerson");
            DropColumn("dbo.BasicInfoes", "Notes");
            DropColumn("dbo.BasicInfoes", "Fax");
        }
    }
}
