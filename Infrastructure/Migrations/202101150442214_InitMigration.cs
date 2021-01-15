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
                        IsSystem = c.Boolean(nullable: false),
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .Index(t => t.BranchId);
            
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
                "dbo.InventoryUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        WarehouseId = c.Int(),
                        LotNumber = c.Int(nullable: false),
                        ReceiveReceipt = c.String(),
                        ReceiveAdjustment = c.String(),
                        ReceiveDate = c.DateTime(),
                        IssueReceipt = c.String(),
                        IssueAdjustment = c.String(),
                        IssueDate = c.DateTime(),
                        UnitQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackageQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UomId = c.Int(),
                        PackageId = c.Int(),
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
                .ForeignKey("dbo.Users", t => t.SupplierId)
                .ForeignKey("dbo.Uoms", t => t.UomId)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId)
                .Index(t => t.ProductId)
                .Index(t => t.WarehouseId)
                .Index(t => t.UomId)
                .Index(t => t.PackageId)
                .Index(t => t.SupplierId);
            
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
                        CategoryId = c.Int(),
                        IsDiscontinued = c.Boolean(nullable: false),
                        PackageId = c.Int(),
                        BaseUomId = c.Int(),
                        UnitsInPackage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitNetWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitGrossWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsBuy = c.Boolean(nullable: false),
                        IsSell = c.Boolean(nullable: false),
                        IsBuild = c.Boolean(nullable: false),
                        IsNotMovable = c.Boolean(nullable: false),
                        WarehouseId = c.Int(),
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
                        Manufacturer = c.String(),
                        Brand = c.String(),
                        Description = c.String(),
                        AttributesJSON = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
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
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        IsCompany = c.Boolean(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Use = c.Boolean(nullable: false),
                        SalesPerson = c.String(),
                        DeliveryAddress = c.String(),
                        UserType = c.String(),
                        CanLogin = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        Fax = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        Gender = c.String(),
                        IsMarried = c.String(),
                        DOB = c.DateTime(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderType = c.String(),
                        UserId = c.Int(),
                        Name = c.String(),
                        ReferenceNumber = c.String(),
                        ParentOrderId = c.Int(),
                        LotNumber = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                        DeliveryDate = c.DateTime(nullable: false),
                        DueDays = c.Int(),
                        IsVerified = c.Boolean(nullable: false),
                        VerifiedDate = c.DateTime(),
                        IsCancelled = c.Boolean(nullable: false),
                        CancelledDate = c.DateTime(),
                        IsCompleted = c.Boolean(nullable: false),
                        CompletedDate = c.DateTime(),
                        IsReceiptGenerated = c.Boolean(nullable: false),
                        ReceiptGeneratedDate = c.DateTime(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DiscountPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentType = c.String(),
                        PaidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDueDate = c.DateTime(),
                        PaymentCompleteDate = c.DateTime(),
                        WarehouseId = c.Int(),
                        SupplierInvoice = c.String(),
                        VatNumber = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        ToWarehouseId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.ParentOrderId)
                .ForeignKey("dbo.Warehouses", t => t.ToWarehouseId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId)
                .Index(t => t.UserId)
                .Index(t => t.ParentOrderId)
                .Index(t => t.WarehouseId)
                .Index(t => t.ToWarehouseId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        WarehouseId = c.Int(),
                        UnitQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackageQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsReceived = c.Boolean(nullable: false),
                        IsHold = c.Boolean(nullable: false),
                        LotNumber = c.Int(nullable: false),
                        Reference = c.String(),
                        Adjustment = c.String(),
                        UomId = c.Int(),
                        PackageId = c.Int(),
                        SupplierId = c.Int(),
                        ProductionDate = c.DateTime(),
                        ExpirationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Packages", t => t.PackageId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Users", t => t.SupplierId)
                .ForeignKey("dbo.Uoms", t => t.UomId)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId)
                .Index(t => t.WarehouseId)
                .Index(t => t.UomId)
                .Index(t => t.PackageId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(),
                        UserId = c.Int(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentMethod = c.String(),
                        Date = c.DateTime(nullable: false),
                        PaidBy = c.String(),
                        ChequeNo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.OrderId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(),
                        OrderId = c.Int(),
                        Particulars = c.String(),
                        Debit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DrCr = c.Int(nullable: false),
                        Type = c.String(),
                        IsVoid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Movements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Reference = c.String(),
                        AdjustmentCode = c.String(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transfers", "ToWarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Transfers", "FromWarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.InventoryUnits", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.InventoryUnits", "UomId", "dbo.Uoms");
            DropForeignKey("dbo.InventoryUnits", "SupplierId", "dbo.Users");
            DropForeignKey("dbo.Orders", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ToWarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Payments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Payments", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ParentOrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.OrderItems", "UomId", "dbo.Uoms");
            DropForeignKey("dbo.OrderItems", "SupplierId", "dbo.Users");
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.InventoryUnits", "ProductId", "dbo.Products");
            DropForeignKey("dbo.WarehouseProducts", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.WarehouseProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.ProductAttributes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ParentProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "BaseUomId", "dbo.Uoms");
            DropForeignKey("dbo.Uoms", "BaseUomId", "dbo.Uoms");
            DropForeignKey("dbo.InventoryUnits", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories");
            DropForeignKey("dbo.Counters", "BranchId", "dbo.Branches");
            DropIndex("dbo.Transfers", new[] { "ToWarehouseId" });
            DropIndex("dbo.Transfers", new[] { "FromWarehouseId" });
            DropIndex("dbo.Transactions", new[] { "OrderId" });
            DropIndex("dbo.Transactions", new[] { "UserId" });
            DropIndex("dbo.Payments", new[] { "UserId" });
            DropIndex("dbo.Payments", new[] { "OrderId" });
            DropIndex("dbo.OrderItems", new[] { "SupplierId" });
            DropIndex("dbo.OrderItems", new[] { "PackageId" });
            DropIndex("dbo.OrderItems", new[] { "UomId" });
            DropIndex("dbo.OrderItems", new[] { "WarehouseId" });
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "ToWarehouseId" });
            DropIndex("dbo.Orders", new[] { "WarehouseId" });
            DropIndex("dbo.Orders", new[] { "ParentOrderId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.WarehouseProducts", new[] { "ProductId" });
            DropIndex("dbo.WarehouseProducts", new[] { "WarehouseId" });
            DropIndex("dbo.ProductAttributes", new[] { "ProductId" });
            DropIndex("dbo.Uoms", new[] { "BaseUomId" });
            DropIndex("dbo.Products", new[] { "WarehouseId" });
            DropIndex("dbo.Products", new[] { "BaseUomId" });
            DropIndex("dbo.Products", new[] { "PackageId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "ParentProductId" });
            DropIndex("dbo.InventoryUnits", new[] { "SupplierId" });
            DropIndex("dbo.InventoryUnits", new[] { "PackageId" });
            DropIndex("dbo.InventoryUnits", new[] { "UomId" });
            DropIndex("dbo.InventoryUnits", new[] { "WarehouseId" });
            DropIndex("dbo.InventoryUnits", new[] { "ProductId" });
            DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
            DropIndex("dbo.Counters", new[] { "BranchId" });
            DropTable("dbo.Transfers");
            DropTable("dbo.Movements");
            DropTable("dbo.Transactions");
            DropTable("dbo.Payments");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.WarehouseProducts");
            DropTable("dbo.Warehouses");
            DropTable("dbo.ProductAttributes");
            DropTable("dbo.Uoms");
            DropTable("dbo.Products");
            DropTable("dbo.Packages");
            DropTable("dbo.InventoryUnits");
            DropTable("dbo.Categories");
            DropTable("dbo.Counters");
            DropTable("dbo.Branches");
            DropTable("dbo.Bills");
            DropTable("dbo.AppSettings");
            DropTable("dbo.AdjustmentCodes");
        }
    }
}
