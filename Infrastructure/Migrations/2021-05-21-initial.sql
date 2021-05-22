USE [master]
GO
/****** Object:  Database [IMS]    Script Date: 5/22/2021 6:20:13 PM ******/
CREATE DATABASE [IMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\IMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\IMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [IMS] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [IMS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [IMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IMS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [IMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IMS] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [IMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [IMS] SET  MULTI_USER 
GO
ALTER DATABASE [IMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [IMS] SET QUERY_STORE = OFF
GO
USE [IMS]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdjustmentCodes]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdjustmentCodes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[AffectsDemand] [bit] NOT NULL,
	[Use] [bit] NOT NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.AdjustmentCodes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppSettings]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppSettings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
	[Group] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_dbo.AppSettings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillNo] [int] NOT NULL,
	[BIllDate] [datetime] NOT NULL,
	[BillTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Bills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Branches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ParentCategoryId] [int] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Counters]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Counters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[BranchId] [int] NOT NULL,
	[OutOfOrder] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Counters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryUnits]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryUnits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[WarehouseId] [int] NULL,
	[LotNumber] [int] NOT NULL,
	[ReceiveReceipt] [nvarchar](max) NULL,
	[ReceiveAdjustment] [nvarchar](max) NULL,
	[ReceiveDate] [datetime] NULL,
	[IssueReceipt] [nvarchar](max) NULL,
	[IssueAdjustment] [nvarchar](max) NULL,
	[IssueDate] [datetime] NULL,
	[UnitQuantity] [decimal](18, 2) NOT NULL,
	[PackageQuantity] [decimal](18, 2) NOT NULL,
	[Rate] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[NetWeight] [decimal](18, 2) NOT NULL,
	[GrossWeight] [decimal](18, 2) NOT NULL,
	[PackageId] [int] NULL,
	[SupplierId] [int] NULL,
	[ProductionDate] [datetime] NULL,
	[ExpirationDate] [datetime] NULL,
	[IsHold] [bit] NOT NULL,
	[Remark] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
	[OrderItemId] [int] NULL,
 CONSTRAINT [PK_dbo.InventoryUnits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movements]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Reference] [nvarchar](max) NULL,
	[AdjustmentCode] [nvarchar](max) NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
	[ProductId] [int] NULL,
 CONSTRAINT [PK_dbo.Movements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[WarehouseId] [int] NULL,
	[UnitQuantity] [decimal](18, 2) NOT NULL,
	[PackageQuantity] [decimal](18, 2) NOT NULL,
	[Rate] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[NetWeight] [decimal](18, 2) NOT NULL,
	[GrossWeight] [decimal](18, 2) NOT NULL,
	[IsReceived] [bit] NOT NULL,
	[IsHold] [bit] NOT NULL,
	[LotNumber] [int] NOT NULL,
	[Reference] [nvarchar](max) NULL,
	[Adjustment] [nvarchar](max) NULL,
	[PackageId] [int] NULL,
	[SupplierId] [int] NULL,
	[ProductionDate] [datetime] NULL,
	[ExpirationDate] [datetime] NULL,
	[CostPriceRate] [decimal](18, 2) NULL,
	[CostPriceTotal] [decimal](18, 2) NULL,
 CONSTRAINT [PK_dbo.OrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderType] [nvarchar](max) NULL,
	[UserId] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[ReferenceNumber] [nvarchar](max) NULL,
	[ParentOrderId] [int] NULL,
	[LotNumber] [int] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[Note] [nvarchar](max) NULL,
	[DeliveryDate] [datetime] NOT NULL,
	[DueDays] [int] NULL,
	[IsVoid] [bit] NOT NULL,
	[IsVerified] [bit] NOT NULL,
	[VerifiedDate] [datetime] NULL,
	[IsCancelled] [bit] NOT NULL,
	[CancelledDate] [datetime] NULL,
	[IsCompleted] [bit] NOT NULL,
	[CompletedDate] [datetime] NULL,
	[IsReceiptGenerated] [bit] NOT NULL,
	[ReceiptGeneratedDate] [datetime] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[DiscountPercent] [decimal](18, 2) NOT NULL,
	[DiscountAmount] [decimal](18, 2) NOT NULL,
	[PaymentType] [nvarchar](max) NULL,
	[PaidAmount] [decimal](18, 2) NOT NULL,
	[PaymentDueDate] [datetime] NULL,
	[PaymentCompleteDate] [datetime] NULL,
	[WarehouseId] [int] NULL,
	[SupplierInvoice] [nvarchar](max) NULL,
	[VatNumber] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[ToWarehouseId] [int] NULL,
	[CostPriceTotal] [decimal](18, 2) NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Packages]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Use] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Packages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[UserType] [nvarchar](max) NOT NULL,
	[ReferenceNumber] [nvarchar](max) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[DueAmount] [decimal](18, 2) NOT NULL,
	[DueDate] [datetime] NULL,
	[PaymentType] [nvarchar](max) NULL,
	[PaymentMethod] [nvarchar](max) NULL,
	[Date] [datetime] NOT NULL,
	[PaidBy] [nvarchar](max) NULL,
	[ChequeNo] [nvarchar](max) NULL,
	[Bank] [nvarchar](max) NULL,
	[IsVoid] [bit] NOT NULL,
	[Order_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PriceHistories]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceHistories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[PriceType] [nvarchar](max) NULL,
	[PackageId] [int] NULL,
	[Rate] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.PriceHistories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAttributes]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttributes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Attribute] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ProductAttributes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductPackages]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPackages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[PackageId] [int] NOT NULL,
	[IsBasePackage] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ProductPackages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[SKU] [nvarchar](max) NULL,
	[Barcode] [nvarchar](max) NULL,
	[Use] [bit] NOT NULL,
	[HasVariants] [bit] NOT NULL,
	[IsVariant] [bit] NOT NULL,
	[ParentProductId] [int] NULL,
	[CategoryId] [int] NULL,
	[IsDiscontinued] [bit] NOT NULL,
	[UnitsInPackage] [decimal](18, 2) NOT NULL,
	[UnitNetWeight] [decimal](18, 2) NOT NULL,
	[UnitGrossWeight] [decimal](18, 2) NOT NULL,
	[IsBuy] [bit] NOT NULL,
	[IsSell] [bit] NOT NULL,
	[IsBuild] [bit] NOT NULL,
	[IsNotMovable] [bit] NOT NULL,
	[WarehouseId] [int] NULL,
	[ReorderPoint] [decimal](18, 2) NOT NULL,
	[ReorderQuantity] [decimal](18, 2) NOT NULL,
	[ReorderAlert] [bit] NOT NULL,
	[LeadDays] [int] NOT NULL,
	[EOQ] [decimal](18, 2) NOT NULL,
	[MonthlyDemand] [decimal](18, 2) NOT NULL,
	[InStockQuantity] [decimal](18, 2) NOT NULL,
	[OnHoldQuantity] [decimal](18, 2) NOT NULL,
	[CommittedQuantity] [decimal](18, 2) NOT NULL,
	[OnOrderQuantity] [decimal](18, 2) NOT NULL,
	[SupplyPrice] [decimal](18, 2) NOT NULL,
	[MarkupPercent] [decimal](18, 2) NOT NULL,
	[RetailPrice] [decimal](18, 2) NOT NULL,
	[Manufacturer] [nvarchar](max) NULL,
	[Brand] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[AttributesJSON] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionItems]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionId] [int] NOT NULL,
	[PurchaseOrderItemId] [int] NULL,
	[UnitQuantity] [decimal](18, 2) NOT NULL,
	[SaleOrderItemId] [int] NULL,
	[CostPriceRate] [decimal](18, 2) NOT NULL,
	[CostPriceTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.TransactionItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[UserId] [int] NULL,
	[OrderId] [int] NULL,
	[Particulars] [nvarchar](max) NULL,
	[Debit] [decimal](18, 2) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
	[DrCr] [int] NOT NULL,
	[Type] [nvarchar](max) NULL,
	[IsVoid] [bit] NOT NULL,
	[CostPriceTotal] [decimal](18, 2) NULL,
 CONSTRAINT [PK_dbo.Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transfers]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transfers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransferNumber] [nvarchar](max) NULL,
	[FromWarehouseId] [int] NOT NULL,
	[ToWarehouseId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Transfers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uoms]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uoms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [decimal](18, 9) NOT NULL,
	[Use] [bit] NOT NULL,
	[PackageId] [int] NOT NULL,
	[RelatedPackageId] [int] NOT NULL,
	[ProductId] [int] NULL,
 CONSTRAINT [PK_dbo.Uoms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[IsCompany] [bit] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Use] [bit] NOT NULL,
	[SalesPerson] [nvarchar](max) NULL,
	[DeliveryAddress] [nvarchar](max) NULL,
	[UserType] [nvarchar](max) NULL,
	[CanLogin] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[DeletedAt] [datetime] NULL,
	[Fax] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Website] [nvarchar](max) NULL,
	[Company] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[IsMarried] [nvarchar](max) NULL,
	[DOB] [datetime] NULL,
	[Notes] [nvarchar](max) NULL,
	[PaymentDueDate] [datetime] NULL,
	[AllDuesClearDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WarehouseProducts]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WarehouseProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[InStockQuantity] [decimal](18, 2) NOT NULL,
	[OnHoldQuantity] [decimal](18, 2) NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.WarehouseProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warehouses]    Script Date: 5/22/2021 6:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Hold] [bit] NOT NULL,
	[MixedProduct] [bit] NOT NULL,
	[Staging] [bit] NOT NULL,
	[Use] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Warehouses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_ParentCategoryId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParentCategoryId] ON [dbo].[Categories]
(
	[ParentCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BranchId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_BranchId] ON [dbo].[Counters]
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderItemId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderItemId] ON [dbo].[InventoryUnits]
(
	[OrderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PackageId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_PackageId] ON [dbo].[InventoryUnits]
(
	[PackageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[InventoryUnits]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierId] ON [dbo].[InventoryUnits]
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_WarehouseId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_WarehouseId] ON [dbo].[InventoryUnits]
(
	[WarehouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[Movements]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderId] ON [dbo].[OrderItems]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PackageId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_PackageId] ON [dbo].[OrderItems]
(
	[PackageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[OrderItems]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierId] ON [dbo].[OrderItems]
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_WarehouseId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_WarehouseId] ON [dbo].[OrderItems]
(
	[WarehouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ParentOrderId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParentOrderId] ON [dbo].[Orders]
(
	[ParentOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ToWarehouseId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ToWarehouseId] ON [dbo].[Orders]
(
	[ToWarehouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Orders]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_WarehouseId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_WarehouseId] ON [dbo].[Orders]
(
	[WarehouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Order_Id]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Order_Id] ON [dbo].[Payments]
(
	[Order_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Payments]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PackageId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_PackageId] ON [dbo].[PriceHistories]
(
	[PackageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[PriceHistories]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[ProductAttributes]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PackageId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_PackageId] ON [dbo].[ProductPackages]
(
	[PackageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[ProductPackages]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ParentProductId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParentProductId] ON [dbo].[Products]
(
	[ParentProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_WarehouseId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_WarehouseId] ON [dbo].[Products]
(
	[WarehouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PurchaseOrderItemId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseOrderItemId] ON [dbo].[TransactionItems]
(
	[PurchaseOrderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SaleOrderItemId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_SaleOrderItemId] ON [dbo].[TransactionItems]
(
	[SaleOrderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TransactionId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_TransactionId] ON [dbo].[TransactionItems]
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderId] ON [dbo].[Transactions]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Transactions]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FromWarehouseId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_FromWarehouseId] ON [dbo].[Transfers]
(
	[FromWarehouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ToWarehouseId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ToWarehouseId] ON [dbo].[Transfers]
(
	[ToWarehouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PackageId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_PackageId] ON [dbo].[Uoms]
(
	[PackageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[Uoms]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RelatedPackageId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_RelatedPackageId] ON [dbo].[Uoms]
(
	[RelatedPackageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[WarehouseProducts]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_WarehouseId]    Script Date: 5/22/2021 6:20:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_WarehouseId] ON [dbo].[WarehouseProducts]
(
	[WarehouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PriceHistories] ADD  DEFAULT ((0)) FOR [Rate]
GO
ALTER TABLE [dbo].[TransactionItems] ADD  DEFAULT ((0)) FOR [CostPriceRate]
GO
ALTER TABLE [dbo].[TransactionItems] ADD  DEFAULT ((0)) FOR [CostPriceTotal]
GO
ALTER TABLE [dbo].[Uoms] ADD  DEFAULT ((0)) FOR [PackageId]
GO
ALTER TABLE [dbo].[Uoms] ADD  DEFAULT ((0)) FOR [RelatedPackageId]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Categories_dbo.Categories_ParentCategoryId] FOREIGN KEY([ParentCategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_dbo.Categories_dbo.Categories_ParentCategoryId]
GO
ALTER TABLE [dbo].[Counters]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Counters_dbo.Branches_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branches] ([Id])
GO
ALTER TABLE [dbo].[Counters] CHECK CONSTRAINT [FK_dbo.Counters_dbo.Branches_BranchId]
GO
ALTER TABLE [dbo].[InventoryUnits]  WITH CHECK ADD  CONSTRAINT [FK_dbo.InventoryUnits_dbo.OrderItems_OrderItemId] FOREIGN KEY([OrderItemId])
REFERENCES [dbo].[OrderItems] ([Id])
GO
ALTER TABLE [dbo].[InventoryUnits] CHECK CONSTRAINT [FK_dbo.InventoryUnits_dbo.OrderItems_OrderItemId]
GO
ALTER TABLE [dbo].[InventoryUnits]  WITH CHECK ADD  CONSTRAINT [FK_dbo.InventoryUnits_dbo.Packages_PackageId] FOREIGN KEY([PackageId])
REFERENCES [dbo].[Packages] ([Id])
GO
ALTER TABLE [dbo].[InventoryUnits] CHECK CONSTRAINT [FK_dbo.InventoryUnits_dbo.Packages_PackageId]
GO
ALTER TABLE [dbo].[InventoryUnits]  WITH CHECK ADD  CONSTRAINT [FK_dbo.InventoryUnits_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[InventoryUnits] CHECK CONSTRAINT [FK_dbo.InventoryUnits_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[InventoryUnits]  WITH CHECK ADD  CONSTRAINT [FK_dbo.InventoryUnits_dbo.Users_SupplierId] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[InventoryUnits] CHECK CONSTRAINT [FK_dbo.InventoryUnits_dbo.Users_SupplierId]
GO
ALTER TABLE [dbo].[InventoryUnits]  WITH CHECK ADD  CONSTRAINT [FK_dbo.InventoryUnits_dbo.Warehouses_WarehouseId] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouses] ([Id])
GO
ALTER TABLE [dbo].[InventoryUnits] CHECK CONSTRAINT [FK_dbo.InventoryUnits_dbo.Warehouses_WarehouseId]
GO
ALTER TABLE [dbo].[Movements]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Movements_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Movements] CHECK CONSTRAINT [FK_dbo.Movements_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderItems_dbo.Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_dbo.OrderItems_dbo.Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderItems_dbo.Packages_PackageId] FOREIGN KEY([PackageId])
REFERENCES [dbo].[Packages] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_dbo.OrderItems_dbo.Packages_PackageId]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderItems_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_dbo.OrderItems_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderItems_dbo.Users_SupplierId] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_dbo.OrderItems_dbo.Users_SupplierId]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderItems_dbo.Warehouses_WarehouseId] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouses] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_dbo.OrderItems_dbo.Warehouses_WarehouseId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Orders_ParentOrderId] FOREIGN KEY([ParentOrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Orders_ParentOrderId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Warehouses_ToWarehouseId] FOREIGN KEY([ToWarehouseId])
REFERENCES [dbo].[Warehouses] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Warehouses_ToWarehouseId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Warehouses_WarehouseId] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouses] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Warehouses_WarehouseId]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Payments_dbo.Orders_Order_Id] FOREIGN KEY([Order_Id])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_dbo.Payments_dbo.Orders_Order_Id]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Payments_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_dbo.Payments_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[PriceHistories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PriceHistories_dbo.Packages_PackageId] FOREIGN KEY([PackageId])
REFERENCES [dbo].[Packages] ([Id])
GO
ALTER TABLE [dbo].[PriceHistories] CHECK CONSTRAINT [FK_dbo.PriceHistories_dbo.Packages_PackageId]
GO
ALTER TABLE [dbo].[PriceHistories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PriceHistories_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[PriceHistories] CHECK CONSTRAINT [FK_dbo.PriceHistories_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[ProductAttributes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProductAttributes_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductAttributes] CHECK CONSTRAINT [FK_dbo.ProductAttributes_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[ProductPackages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProductPackages_dbo.Packages_PackageId] FOREIGN KEY([PackageId])
REFERENCES [dbo].[Packages] ([Id])
GO
ALTER TABLE [dbo].[ProductPackages] CHECK CONSTRAINT [FK_dbo.ProductPackages_dbo.Packages_PackageId]
GO
ALTER TABLE [dbo].[ProductPackages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProductPackages_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductPackages] CHECK CONSTRAINT [FK_dbo.ProductPackages_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.Categories_CategoryId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.Products_ParentProductId] FOREIGN KEY([ParentProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.Products_ParentProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.Warehouses_WarehouseId] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouses] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.Warehouses_WarehouseId]
GO
ALTER TABLE [dbo].[TransactionItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TransactionItems_dbo.OrderItems_InventoryOrderItemId] FOREIGN KEY([PurchaseOrderItemId])
REFERENCES [dbo].[OrderItems] ([Id])
GO
ALTER TABLE [dbo].[TransactionItems] CHECK CONSTRAINT [FK_dbo.TransactionItems_dbo.OrderItems_InventoryOrderItemId]
GO
ALTER TABLE [dbo].[TransactionItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TransactionItems_dbo.OrderItems_SaleOrderItemId] FOREIGN KEY([SaleOrderItemId])
REFERENCES [dbo].[OrderItems] ([Id])
GO
ALTER TABLE [dbo].[TransactionItems] CHECK CONSTRAINT [FK_dbo.TransactionItems_dbo.OrderItems_SaleOrderItemId]
GO
ALTER TABLE [dbo].[TransactionItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TransactionItems_dbo.Transactions_TransactionId] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[Transactions] ([Id])
GO
ALTER TABLE [dbo].[TransactionItems] CHECK CONSTRAINT [FK_dbo.TransactionItems_dbo.Transactions_TransactionId]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Transactions_dbo.Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_dbo.Transactions_dbo.Orders_OrderId]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Transactions_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_dbo.Transactions_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Transfers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Transfers_dbo.Warehouses_FromWarehouseId] FOREIGN KEY([FromWarehouseId])
REFERENCES [dbo].[Warehouses] ([Id])
GO
ALTER TABLE [dbo].[Transfers] CHECK CONSTRAINT [FK_dbo.Transfers_dbo.Warehouses_FromWarehouseId]
GO
ALTER TABLE [dbo].[Transfers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Transfers_dbo.Warehouses_ToWarehouseId] FOREIGN KEY([ToWarehouseId])
REFERENCES [dbo].[Warehouses] ([Id])
GO
ALTER TABLE [dbo].[Transfers] CHECK CONSTRAINT [FK_dbo.Transfers_dbo.Warehouses_ToWarehouseId]
GO
ALTER TABLE [dbo].[Uoms]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Uoms_dbo.Packages_PackageId] FOREIGN KEY([PackageId])
REFERENCES [dbo].[Packages] ([Id])
GO
ALTER TABLE [dbo].[Uoms] CHECK CONSTRAINT [FK_dbo.Uoms_dbo.Packages_PackageId]
GO
ALTER TABLE [dbo].[Uoms]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Uoms_dbo.Packages_RelatedPackageId] FOREIGN KEY([RelatedPackageId])
REFERENCES [dbo].[Packages] ([Id])
GO
ALTER TABLE [dbo].[Uoms] CHECK CONSTRAINT [FK_dbo.Uoms_dbo.Packages_RelatedPackageId]
GO
ALTER TABLE [dbo].[Uoms]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Uoms_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Uoms] CHECK CONSTRAINT [FK_dbo.Uoms_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[WarehouseProducts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WarehouseProducts_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[WarehouseProducts] CHECK CONSTRAINT [FK_dbo.WarehouseProducts_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[WarehouseProducts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WarehouseProducts_dbo.Warehouses_WarehouseId] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouses] ([Id])
GO
ALTER TABLE [dbo].[WarehouseProducts] CHECK CONSTRAINT [FK_dbo.WarehouseProducts_dbo.Warehouses_WarehouseId]
GO
USE [master]
GO
ALTER DATABASE [IMS] SET  READ_WRITE 
GO
