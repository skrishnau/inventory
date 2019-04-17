namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
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
            
            CreateTable(
                "dbo.AppSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayName = c.String(),
                        Value = c.String(),
                        Group = c.String(),
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
                        Address = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        Gender = c.String(),
                        IsMarried = c.String(),
                        DOB = c.DateTime(),
                        Notes = c.String(),
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
                        SalesPerson = c.String(),
                        MyCustomerAccount = c.String(),
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
                        SKU = c.String(),
                        Barcode = c.String(),
                        Use = c.Boolean(nullable: false),
                        HasVariants = c.Boolean(nullable: false),
                        IsVariant = c.Boolean(nullable: false),
                        ParentProductId = c.Int(),
                        CategoryId = c.Int(nullable: false),
                        IsDiscontinued = c.Boolean(nullable: false),
                        PackageId = c.Int(nullable: false),
                        BaseUomId = c.Int(nullable: false),
                        UnitsInPackage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitNetWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitGrossWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsBuy = c.Boolean(nullable: false),
                        IsSell = c.Boolean(nullable: false),
                        IsBuild = c.Boolean(nullable: false),
                        IsNotMovable = c.Boolean(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        ReorderPoint = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReorderQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReorderAlert = c.Boolean(nullable: false),
                        LeadDays = c.Int(nullable: false),
                        EOQ = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MonthlyDemand = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InStockQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OnHoldQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CommittedQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OnOrderQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SupplyPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MarkupPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RetailPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Label = c.String(),
                        Manufacturer = c.String(),
                        Brand = c.String(),
                        Description = c.String(),
                        AttributesJSON = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Uoms", t => t.BaseUomId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Packages", t => t.PackageId)
                .ForeignKey("dbo.Products", t => t.ParentProductId)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId)
                .Index(t => t.ParentProductId)
                .Index(t => t.CategoryId)
                .Index(t => t.PackageId)
                .Index(t => t.BaseUomId)
                .Index(t => t.WarehouseId);
            
            CreateTable(
                "dbo.Uoms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseUomId = c.Int(),
                        Use = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Uoms", t => t.BaseUomId)
                .Index(t => t.BaseUomId);
            
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
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Use = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Hold = c.Boolean(nullable: false),
                        MixedProduct = c.Boolean(nullable: false),
                        Staging = c.Boolean(nullable: false),
                        Use = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InventoryUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        LotNumber = c.Int(nullable: false),
                        ReceiveReceipt = c.String(),
                        ReceiveAdjustment = c.String(),
                        ReceiveDate = c.DateTime(),
                        IssueReceipt = c.String(),
                        IssueAdjustment = c.String(),
                        IssueDate = c.DateTime(),
                        UnitQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackageQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SupplyPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalSupplyAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UomId = c.Int(nullable: false),
                        PackageId = c.Int(nullable: false),
                        SupplierId = c.Int(),
                        ProductionDate = c.DateTime(),
                        ExpirationDate = c.DateTime(),
                        IsHold = c.Boolean(nullable: false),
                        Remark = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .ForeignKey("dbo.Uoms", t => t.UomId)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId)
                .Index(t => t.ProductId)
                .Index(t => t.WarehouseId)
                .Index(t => t.UomId)
                .Index(t => t.PackageId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReferenceNumber = c.String(),
                        ParentPurchaseOrderId = c.Int(),
                        LotNo = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WarehouseId = c.Int(nullable: false),
                        SupplierInvoice = c.String(),
                        SupplierId = c.Int(),
                        ExpectedDate = c.DateTime(nullable: false),
                        IsOrderSent = c.Boolean(nullable: false),
                        OrderSentDate = c.DateTime(),
                        IsCancelled = c.Boolean(nullable: false),
                        CancelledDate = c.DateTime(),
                        IsReceived = c.Boolean(nullable: false),
                        ReceivedDate = c.DateTime(),
                        Note = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PurchaseOrders", t => t.ParentPurchaseOrderId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId)
                .Index(t => t.ParentPurchaseOrderId)
                .Index(t => t.WarehouseId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.PurchaseOrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseOrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        UnitQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackageQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsReceived = c.Boolean(nullable: false),
                        IsHold = c.Boolean(nullable: false),
                        LotNumber = c.Int(nullable: false),
                        Reference = c.String(),
                        Adjustment = c.String(),
                        UomId = c.Int(nullable: false),
                        PackageId = c.Int(nullable: false),
                        SupplierId = c.Int(),
                        ProductionDate = c.DateTime(),
                        ExpirationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .ForeignKey("dbo.Uoms", t => t.UomId)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId)
                .Index(t => t.PurchaseOrderId)
                .Index(t => t.ProductId)
                .Index(t => t.WarehouseId)
                .Index(t => t.UomId)
                .Index(t => t.PackageId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.SaleItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDescription = c.String(),
                        SKU = c.String(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sales", t => t.SaleId)
                .Index(t => t.SaleId);
            
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
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransferNumber = c.String(),
                        FromWarehouseId = c.Int(nullable: false),
                        ToWarehouseId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Warehouses", t => t.FromWarehouseId)
                .ForeignKey("dbo.Warehouses", t => t.ToWarehouseId)
                .Index(t => t.FromWarehouseId)
                .Index(t => t.ToWarehouseId);
            
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
                "dbo.WarehouseProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WarehouseId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        InStockQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OnHoldQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId)
                .Index(t => t.WarehouseId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WarehouseProducts", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.WarehouseProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Users", "BasicInfoId", "dbo.BasicInfoes");
            DropForeignKey("dbo.Transfers", "ToWarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Transfers", "FromWarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.SaleItems", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.PurchaseOrders", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.PurchaseOrders", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseOrderItems", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.PurchaseOrderItems", "UomId", "dbo.Uoms");
            DropForeignKey("dbo.PurchaseOrderItems", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseOrderItems", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PurchaseOrderItems", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.PurchaseOrders", "ParentPurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.InventoryUnits", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.InventoryUnits", "UomId", "dbo.Uoms");
            DropForeignKey("dbo.InventoryUnits", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.InventoryUnits", "ProductId", "dbo.Products");
            DropForeignKey("dbo.InventoryUnits", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Products", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.ProductAttributes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ParentProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories");
            DropForeignKey("dbo.Brands", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "BaseUomId", "dbo.Uoms");
            DropForeignKey("dbo.Uoms", "BaseUomId", "dbo.Uoms");
            DropForeignKey("dbo.Counters", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Suppliers", "BasicInfoId", "dbo.BasicInfoes");
            DropForeignKey("dbo.Customers", "BasicInfoId", "dbo.BasicInfoes");
            DropIndex("dbo.WarehouseProducts", new[] { "ProductId" });
            DropIndex("dbo.WarehouseProducts", new[] { "WarehouseId" });
            DropIndex("dbo.Users", new[] { "BasicInfoId" });
            DropIndex("dbo.Transfers", new[] { "ToWarehouseId" });
            DropIndex("dbo.Transfers", new[] { "FromWarehouseId" });
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.SaleItems", new[] { "SaleId" });
            DropIndex("dbo.PurchaseOrderItems", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseOrderItems", new[] { "PackageId" });
            DropIndex("dbo.PurchaseOrderItems", new[] { "UomId" });
            DropIndex("dbo.PurchaseOrderItems", new[] { "WarehouseId" });
            DropIndex("dbo.PurchaseOrderItems", new[] { "ProductId" });
            DropIndex("dbo.PurchaseOrderItems", new[] { "PurchaseOrderId" });
            DropIndex("dbo.PurchaseOrders", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseOrders", new[] { "WarehouseId" });
            DropIndex("dbo.PurchaseOrders", new[] { "ParentPurchaseOrderId" });
            DropIndex("dbo.InventoryUnits", new[] { "SupplierId" });
            DropIndex("dbo.InventoryUnits", new[] { "PackageId" });
            DropIndex("dbo.InventoryUnits", new[] { "UomId" });
            DropIndex("dbo.InventoryUnits", new[] { "WarehouseId" });
            DropIndex("dbo.InventoryUnits", new[] { "ProductId" });
            DropIndex("dbo.ProductAttributes", new[] { "ProductId" });
            DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
            DropIndex("dbo.Uoms", new[] { "BaseUomId" });
            DropIndex("dbo.Products", new[] { "WarehouseId" });
            DropIndex("dbo.Products", new[] { "BaseUomId" });
            DropIndex("dbo.Products", new[] { "PackageId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "ParentProductId" });
            DropIndex("dbo.Brands", new[] { "ProductId" });
            DropIndex("dbo.Counters", new[] { "BranchId" });
            DropIndex("dbo.Suppliers", new[] { "BasicInfoId" });
            DropIndex("dbo.Customers", new[] { "BasicInfoId" });
            DropTable("dbo.WarehouseProducts");
            DropTable("dbo.Users");
            DropTable("dbo.Transfers");
            DropTable("dbo.SaleOrders");
            DropTable("dbo.Sales");
            DropTable("dbo.SaleItems");
            DropTable("dbo.PurchaseOrderItems");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.InventoryUnits");
            DropTable("dbo.Warehouses");
            DropTable("dbo.ProductAttributes");
            DropTable("dbo.Packages");
            DropTable("dbo.Categories");
            DropTable("dbo.Uoms");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
            DropTable("dbo.Counters");
            DropTable("dbo.Branches");
            DropTable("dbo.Bills");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Customers");
            DropTable("dbo.BasicInfoes");
            DropTable("dbo.AppSettings");
            DropTable("dbo.AdjustmentCodes");
        }
    }
}
