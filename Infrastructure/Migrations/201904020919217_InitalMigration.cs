namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayName = c.String(),
                        Value = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BasicInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCompany = c.Boolean(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        DOB = c.DateTime(),
                        Address = c.String(),
                        Phone = c.String(),
                        Gender = c.String(),
                        IsMarried = c.Boolean(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BasicInfoId = c.Int(nullable: false),
                        DeliveryAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BasicInfoes", t => t.BasicInfoId)
                .Index(t => t.BasicInfoId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BasicInfoId = c.Int(nullable: false),
                        Fax = c.String(),
                        Website = c.String(),
                        PhoneSecond = c.String(),
                        ContactPersonName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BasicInfoes", t => t.BasicInfoId)
                .Index(t => t.BasicInfoId);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillNo = c.Int(nullable: false),
                        BIllDate = c.DateTime(nullable: false),
                        BillTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        BranchId = c.Int(nullable: false),
                        Code = c.String(),
                        CanMoveStocksToBranch = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProductId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        QuantityInStock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LatestUnitCostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LatestUnitSellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Alert = c.Boolean(nullable: false),
                        AlertThreshold = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentCategoryId = c.Int(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.ProductAttributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Attribute = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.VariantAttributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VariantId = c.Int(nullable: false),
                        ProductAttributeId = c.Int(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductAttributes", t => t.ProductAttributeId)
                .ForeignKey("dbo.Variants", t => t.VariantId)
                .Index(t => t.VariantId)
                .Index(t => t.ProductAttributeId);
            
            CreateTable(
                "dbo.Variants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SKU = c.String(),
                        QuantityInStock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LatestUnitCostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LatestUnitSellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Alert = c.Boolean(),
                        MinStockCountForAlert = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Counters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BranchId = c.Int(nullable: false),
                        OutOfOrder = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierId = c.Int(),
                        ReceiptNo = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.PurchaseItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseId = c.Int(nullable: false),
                        VariantId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId)
                .ForeignKey("dbo.Variants", t => t.VariantId)
                .Index(t => t.PurchaseId)
                .Index(t => t.VariantId);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        LotNo = c.Int(nullable: false),
                        WarehouseId = c.Int(),
                        OrderDate = c.DateTime(nullable: false),
                        RequestedDate = c.DateTime(nullable: false),
                        PromisedDate = c.DateTime(),
                        ReceivedDate = c.DateTime(),
                        ClosedOn = c.DateTime(),
                        CreatedById = c.Int(),
                        RequestedById = c.Int(),
                        ApprovedById = c.Int(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApprovedById)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId)
                .ForeignKey("dbo.Users", t => t.RequestedById)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId)
                .Index(t => t.PurchaseId)
                .Index(t => t.SupplierId)
                .Index(t => t.WarehouseId)
                .Index(t => t.CreatedById)
                .Index(t => t.RequestedById)
                .Index(t => t.ApprovedById);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        BasicInfoId = c.Int(nullable: false),
                        UserType = c.String(),
                        CanLogin = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BasicInfoes", t => t.BasicInfoId)
                .Index(t => t.BasicInfoId);
            
            CreateTable(
                "dbo.SaleItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleId = c.Int(nullable: false),
                        VariantId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDescription = c.String(),
                        SKU = c.String(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sales", t => t.SaleId)
                .ForeignKey("dbo.Variants", t => t.VariantId)
                .Index(t => t.SaleId)
                .Index(t => t.VariantId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNo = c.String(),
                        VatNo = c.String(),
                        CustomerId = c.Int(),
                        CustomerName = c.String(),
                        Address = c.String(),
                        MobileNo = c.String(),
                        Date = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.SaleOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleItems", "VariantId", "dbo.Variants");
            DropForeignKey("dbo.SaleItems", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.PurchaseOrders", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.PurchaseOrders", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseOrders", "RequestedById", "dbo.Users");
            DropForeignKey("dbo.PurchaseOrders", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseOrders", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.PurchaseOrders", "ApprovedById", "dbo.Users");
            DropForeignKey("dbo.Users", "BasicInfoId", "dbo.BasicInfoes");
            DropForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseItems", "VariantId", "dbo.Variants");
            DropForeignKey("dbo.PurchaseItems", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Counters", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.VariantAttributes", "VariantId", "dbo.Variants");
            DropForeignKey("dbo.Variants", "ProductId", "dbo.Products");
            DropForeignKey("dbo.VariantAttributes", "ProductAttributeId", "dbo.ProductAttributes");
            DropForeignKey("dbo.ProductAttributes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories");
            DropForeignKey("dbo.Brands", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Warehouses", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Suppliers", "BasicInfoId", "dbo.BasicInfoes");
            DropForeignKey("dbo.Customers", "BasicInfoId", "dbo.BasicInfoes");
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.SaleItems", new[] { "VariantId" });
            DropIndex("dbo.SaleItems", new[] { "SaleId" });
            DropIndex("dbo.Users", new[] { "BasicInfoId" });
            DropIndex("dbo.PurchaseOrders", new[] { "ApprovedById" });
            DropIndex("dbo.PurchaseOrders", new[] { "RequestedById" });
            DropIndex("dbo.PurchaseOrders", new[] { "CreatedById" });
            DropIndex("dbo.PurchaseOrders", new[] { "WarehouseId" });
            DropIndex("dbo.PurchaseOrders", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseOrders", new[] { "PurchaseId" });
            DropIndex("dbo.PurchaseItems", new[] { "VariantId" });
            DropIndex("dbo.PurchaseItems", new[] { "PurchaseId" });
            DropIndex("dbo.Purchases", new[] { "SupplierId" });
            DropIndex("dbo.Counters", new[] { "BranchId" });
            DropIndex("dbo.Variants", new[] { "ProductId" });
            DropIndex("dbo.VariantAttributes", new[] { "ProductAttributeId" });
            DropIndex("dbo.VariantAttributes", new[] { "VariantId" });
            DropIndex("dbo.ProductAttributes", new[] { "ProductId" });
            DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Brands", new[] { "ProductId" });
            DropIndex("dbo.Warehouses", new[] { "BranchId" });
            DropIndex("dbo.Suppliers", new[] { "BasicInfoId" });
            DropIndex("dbo.Customers", new[] { "BasicInfoId" });
            DropTable("dbo.SaleOrders");
            DropTable("dbo.Sales");
            DropTable("dbo.SaleItems");
            DropTable("dbo.Users");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.PurchaseItems");
            DropTable("dbo.Purchases");
            DropTable("dbo.Counters");
            DropTable("dbo.Variants");
            DropTable("dbo.VariantAttributes");
            DropTable("dbo.ProductAttributes");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
            DropTable("dbo.Warehouses");
            DropTable("dbo.Branches");
            DropTable("dbo.Bills");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Customers");
            DropTable("dbo.BasicInfoes");
            DropTable("dbo.AppSettings");
        }
    }
}
