namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Brands",
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
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        QuantityInStock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LatestUnitCostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LatestUnitSellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShowStockAlerts = c.Boolean(nullable: false),
                        MinStockCountForAlert = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.BrandId);
            
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
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeliveryAddress = c.String(),
                        BasicInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BasicInfoes", t => t.BasicInfo_Id)
                .Index(t => t.BasicInfo_Id);
            
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
                        CreatedById = c.Int(nullable: false),
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
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Code = c.String(),
                        CanMoveStocksToBranch = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        Branch_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.Branch_Id)
                .Index(t => t.Branch_Id);
            
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
                "dbo.SaleOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        InvoiceNo = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.PurchaseOrders", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Warehouses", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.PurchaseOrders", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseOrders", "RequestedById", "dbo.Users");
            DropForeignKey("dbo.PurchaseOrders", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseOrders", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.PurchaseOrders", "ApprovedById", "dbo.Users");
            DropForeignKey("dbo.Users", "BasicInfoId", "dbo.BasicInfoes");
            DropForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "BasicInfoId", "dbo.BasicInfoes");
            DropForeignKey("dbo.Customers", "BasicInfo_Id", "dbo.BasicInfoes");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.Warehouses", new[] { "Branch_Id" });
            DropIndex("dbo.Users", new[] { "BasicInfoId" });
            DropIndex("dbo.PurchaseOrders", new[] { "ApprovedById" });
            DropIndex("dbo.PurchaseOrders", new[] { "RequestedById" });
            DropIndex("dbo.PurchaseOrders", new[] { "CreatedById" });
            DropIndex("dbo.PurchaseOrders", new[] { "WarehouseId" });
            DropIndex("dbo.PurchaseOrders", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseOrders", new[] { "PurchaseId" });
            DropIndex("dbo.Suppliers", new[] { "BasicInfoId" });
            DropIndex("dbo.Purchases", new[] { "SupplierId" });
            DropIndex("dbo.Customers", new[] { "BasicInfo_Id" });
            DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Sales");
            DropTable("dbo.SaleOrders");
            DropTable("dbo.Branches");
            DropTable("dbo.Warehouses");
            DropTable("dbo.Users");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.BasicInfoes");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Purchases");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
            DropTable("dbo.Bills");
        }
    }
}
