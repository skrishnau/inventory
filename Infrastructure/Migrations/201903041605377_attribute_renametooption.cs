namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attribute_renametooption : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Attributes", newName: "Options");
            RenameTable(name: "dbo.ProductAttributes", newName: "ProductOptions");
            RenameColumn(table: "dbo.ProductOptions", name: "AttributeId", newName: "OptionId");
            RenameIndex(table: "dbo.ProductOptions", name: "IX_AttributeId", newName: "IX_OptionId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProductOptions", name: "IX_OptionId", newName: "IX_AttributeId");
            RenameColumn(table: "dbo.ProductOptions", name: "OptionId", newName: "AttributeId");
            RenameTable(name: "dbo.ProductOptions", newName: "ProductAttributes");
            RenameTable(name: "dbo.Options", newName: "Attributes");
        }
    }
}
