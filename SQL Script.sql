USE [DASAR V.01]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [varchar](200) NULL,
	[Password] [nvarchar](3000) NULL,
	[FirstName] [nvarchar](500) NULL,
	[LastName] [nvarchar](500) NULL,
	[IdentifyID] [nvarchar](500) NULL,
	[Email] [nvarchar](200) NULL,
	[Phone] [nvarchar](200) NULL,
	[Mobile] [nvarchar](200) NULL,
	[InformationID] [int] NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cooling_Request]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cooling_Request](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Request_Date] [datetime] NULL,
	[ItemID] [int] NULL,
	[CustomerID] [int] NULL,
	[Requester] [nvarchar](200) NULL,
	[Delivery_Date] [datetime] NULL,
	[InformationID] [int] NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_Cooling_Request] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] NOT NULL,
	[CustomerCode] [nvarchar](200) NULL,
	[CustomerName] [nvarchar](500) NULL,
	[Email] [nvarchar](200) NULL,
	[Phone] [nvarchar](200) NULL,
	[Mobile] [nvarchar](200) NULL,
	[InformationID] [int] NULL,
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer_Complaint]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_Complaint](
	[ID] [int] NOT NULL,
	[CustomerID] [int] NULL,
	[Grower_Claim] [nvarchar](max) NULL,
	[ItemID] [int] NULL,
	[SupplierID] [int] NULL,
	[Lot] [nvarchar](200) NULL,
	[Certificate] [int] NULL,
	[Import_Quantity] [int] NULL,
	[Delivery_Quantity] [int] NULL,
	[Selling_Date] [datetime] NULL,
	[ContID] [nvarchar](200) NULL,
	[Dmg_QTY_Before] [int] NULL,
	[Dmg_QTY_After] [int] NULL,
	[Checked_Date] [datetime] NULL,
	[Grower_Before] [nvarchar](200) NULL,
	[Grower_After] [nvarchar](200) NULL,
	[Conclusion_Before] [nvarchar](200) NULL,
	[Conclusion_After] [nvarchar](200) NULL,
	[Technical] [nvarchar](200) NULL,
	[Solution] [nvarchar](200) NULL,
	[Status] [nvarchar](200) NULL,
	[Claiming_Supplier] [nvarchar](200) NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customer_Complaint] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer_Contract]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_Contract](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Contract] [nvarchar](200) NULL,
	[Effective_Date] [datetime] NULL,
	[In_Charge] [nvarchar](200) NULL,
	[CustomerID] [int] NULL,
	[ItemID] [int] NULL,
	[Required_Supplier] [nvarchar](200) NULL,
	[Order_QTY_Bulbs] [int] NULL,
	[Price_VND] [real] NULL,
	[Seeding_Date_Lunar] [datetime] NULL,
	[Seeding_Date_Gregorian] [datetime] NULL,
	[Estimated_Arrival_Date] [datetime] NULL,
	[Note] [nvarchar](max) NULL,
	[ContID] [nvarchar](200) NULL,
	[Date_Arrived] [datetime] NULL,
	[Deposit] [real] NULL,
	[Date_1] [datetime] NULL,
	[Delivery_1] [int] NULL,
	[Date_2] [datetime] NULL,
	[Delivery_2] [int] NULL,
	[Date_3] [datetime] NULL,
	[Delivery_3] [int] NULL,
	[Date_4] [datetime] NULL,
	[Delivery_4] [int] NULL,
	[Date_5] [datetime] NULL,
	[Delivery_5] [int] NULL,
	[InformationID] [int] NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_Customer_Contract] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Information]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Information](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameInfor] [nvarchar](500) NULL,
	[DateCreated] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[DateModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Information] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItemID] [nvarchar](200) NULL,
	[ItemName] [nvarchar](500) NULL,
	[Type] [nvarchar](50) NULL,
	[Size] [nvarchar](50) NULL,
	[ItemsPerPack] [int] NULL,
	[Crop] [nvarchar](200) NULL,
	[Note] [nvarchar](max) NULL,
	[Information] [int] NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Monitoring_Seed_Quantity]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monitoring_Seed_Quantity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date_Added] [datetime] NULL,
	[ContID] [nvarchar](200) NULL,
	[ItemID] [int] NULL,
	[SupplierID] [int] NULL,
	[Lot] [nvarchar](200) NULL,
	[Certificate] [int] NULL,
	[Status] [nvarchar](500) NULL,
	[CustomerID] [int] NULL,
	[Export_Quantity] [int] NULL,
	[Export_Date] [datetime] NULL,
	[Damaged_Quantity] [int] NULL,
	[Customer_Feedback] [nvarchar](max) NULL,
	[Damaged_Status] [nvarchar](500) NULL,
	[Checked_Date] [datetime] NULL,
	[Note] [nvarchar](max) NULL,
	[Process_Status_Customer] [nvarchar](200) NULL,
	[Process_Status_Supplier] [nvarchar](200) NULL,
	[InformationID] [int] NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_Monitoring_Seed_Quantity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pallet]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pallet](
	[ID] [int] NULL,
	[Pallet] [nvarchar](200) NULL,
	[Tray_Number] [int] NULL,
	[ReposityID] [int] NULL,
	[ContID] [nvarchar](200) NULL,
	[Empty_Pallet] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report_Customer_Complaints]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report_Customer_Complaints](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Technical_staff] [nvarchar](200) NULL,
	[Customer_A_Quantity] [nvarchar](50) NULL,
	[Customer_A_Times] [nvarchar](50) NULL,
	[Customer_B_Quantity] [nvarchar](50) NULL,
	[Customer_B_Times] [nvarchar](50) NULL,
	[Customer_C_Quantity] [nvarchar](50) NULL,
	[Customer_C_Times] [nvarchar](50) NULL,
	[Customer_D_Quantity] [nvarchar](50) NULL,
	[Customer_D_Times] [nvarchar](50) NULL,
	[Result] [nvarchar](50) NULL,
	[InformationID] [int] NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_Report_Customer_Complaints] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report_On_Board]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report_On_Board](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItemID] [int] NULL,
	[SupplierID] [int] NULL,
	[Price_EUR] [real] NULL,
	[CustomerID] [int] NULL,
	[Order_Quantity] [int] NULL,
	[Unit_Price] [real] NULL,
	[Delivery_Time] [nvarchar](200) NULL,
	[Pay] [nvarchar](200) NULL,
	[InformationID] [int] NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_Report_On_Board] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Repository]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Repository](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Repo_Name] [nvarchar](200) NULL,
	[Location] [nvarchar](200) NULL,
	[PalletID] [int] NULL,
	[ItemID] [int] NULL,
	[ContID] [nvarchar](200) NULL,
	[CustomerID] [int] NULL,
	[InformationID] [int] NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_Repository] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](500) NULL,
	[Functions] [nvarchar](500) NULL,
	[InformationID] [int] NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleAccount]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleAccount](
	[RoleID] [int] NOT NULL,
	[AccountID] [int] NOT NULL,
	[Active] [int] NULL,
 CONSTRAINT [PK_RoleAccount_1] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales_Report]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales_Report](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NULL,
	[Month] [datetime] NULL,
	[Export_Date] [datetime] NULL,
	[Date_Arrived] [datetime] NULL,
	[Check_Date] [nvarchar](200) NULL,
	[Export_Number] [nvarchar](200) NULL,
	[Bill_Number] [nvarchar](200) NULL,
	[CustomerID] [int] NULL,
	[ItemID] [int] NULL,
	[SupplierID] [int] NULL,
	[Certificate] [nvarchar](200) NULL,
	[Tuber_Number] [int] NULL,
	[Tray_Number] [int] NULL,
	[Price_VND] [real] NULL,
	[Status] [nvarchar](200) NULL,
	[Note] [nvarchar](max) NULL,
	[InformationID] [int] NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_Sales_Report] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipment]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NULL,
	[Month] [datetime] NULL,
	[ContID] [nvarchar](200) NULL,
	[ItemID] [int] NULL,
	[Purchase_Quantity_Bulbs] [int] NULL,
	[Price_EUR] [real] NULL,
	[Lot] [nvarchar](200) NULL,
	[Certificate] [int] NULL,
	[Quality_Control_Assessment] [nvarchar](200) NULL,
	[Note] [nvarchar](max) NULL,
	[InformationID] [int] NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_Shipment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipment_Request]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipment_Request](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[ItemID] [int] NULL,
	[Reason] [nvarchar](max) NULL,
	[InformationID] [int] NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_Shipment_Request] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierCode] [nvarchar](200) NULL,
	[SupplierName] [nvarchar](500) NULL,
	[Nation] [nvarchar](200) NULL,
	[InformationID] [int] NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier_Contract]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier_Contract](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ExtID] [nvarchar](3000) NULL,
	[Supplier_Contract_Name] [nvarchar](200) NULL,
	[Ordered_Date] [datetime] NULL,
	[SupplierID] [int] NULL,
	[ItemID] [int] NULL,
	[Purchase_Quantity_Bulbs] [int] NULL,
	[Price_EUR] [real] NULL,
	[Shipped_Quantity_Bulbs] [int] NULL,
	[Note] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
	[Schedule] [nvarchar](200) NULL,
	[ETD] [datetime] NULL,
	[ETA] [datetime] NULL,
	[Loading_Date] [datetime] NULL,
	[ETD_CMA_SCHEDULE] [datetime] NULL,
	[ETA_CMA_SCHEDULE] [datetime] NULL,
	[ETD_ONE_SCHEDULE] [datetime] NULL,
	[ETA_ONE_SCHEDULE] [datetime] NULL,
	[InformationID] [int] NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_Supplier_Contract] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Information] FOREIGN KEY([InformationID])
REFERENCES [dbo].[Information] ([ID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Information]
GO
ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [FK_Role_Information] FOREIGN KEY([InformationID])
REFERENCES [dbo].[Information] ([ID])
GO
ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [FK_Role_Information]
GO
ALTER TABLE [dbo].[RoleAccount]  WITH CHECK ADD  CONSTRAINT [FK_RoleAccount_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[RoleAccount] CHECK CONSTRAINT [FK_RoleAccount_Account]
GO
ALTER TABLE [dbo].[RoleAccount]  WITH CHECK ADD  CONSTRAINT [FK_RoleAccount_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[RoleAccount] CHECK CONSTRAINT [FK_RoleAccount_Role]
GO
/****** Object:  StoredProcedure [dbo].[Find]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[Find]
    @TableName nvarchar(128),
    @ColumnName nvarchar(128),
    @Key nvarchar(128)
AS
SET NOCOUNT ON
DECLARE @STMT nvarchar(4000)
SET @STMT = 'SELECT TOP 1 * FROM [' + @TableName + '] WHERE [' + @ColumnName + ']=' + @Key
EXEC (@STMT)
GO
/****** Object:  StoredProcedure [dbo].[GetAll]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[GetAll]
    @TableName nvarchar(128),
    @OrderBy nvarchar(512)
AS
SET NOCOUNT ON
DECLARE @STMT nvarchar(1000)
SET @STMT = 'SELECT * FROM [' + @TableName + '] ' + @OrderBy
EXEC (@STMT)
GO
/****** Object:  StoredProcedure [dbo].[GetByPage]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[GetByPage]
    @TableName nvarchar(128),
    @FieldList nvarchar(512),
    @Filter nvarchar(1000),
    @OrderBy nvarchar(512),
    @PageNum int,
    @PageSize int,
    @PageCount int
AS
SET NOCOUNT ON

IF @PageCount <= 0
   RETURN

IF @PageNum < 1 OR @PageNum > @PageCount
   RETURN

IF @FieldList = '' SET @FieldList = '*'

DECLARE @STMT nvarchar(4000)

IF @PageCount > 1
BEGIN
   DECLARE @Max int,
           @Min int

   SET @Min = (@PageNum - 1) * @PageSize
   SET @Max = @Min + @PageSize

   SET @STMT =
     'SELECT ' + @FieldList
   + ' FROM'
   + ' ( SELECT TOP ' + CONVERT(varchar(10), @Max) + ' ROW_NUMBER() OVER(' + @OrderBy + ')'
   + ' AS row, * FROM [' + @TableName + '] ' + @Filter
   + ' ) AS tbl'
   + ' WHERE row >= ' + CONVERT(varchar(10), @Min + 1) 
   + ' AND row <= '   + CONVERT(varchar(10), @Max)
END
ELSE
   SET @STMT = 'SELECT ' + @FieldList + ' FROM [' + @TableName + '] ' + @Filter +  ' ' + @OrderBy

EXEC (@STMT)
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateDelete_Account]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[InsertUpdateDelete_Account]
    @ID int output,
    @AccountName varchar(200),
    @Password nvarchar(3000),
    @FirstName nvarchar(500),
    @LastName nvarchar(500),
    @IdentifyID nvarchar(500),
    @Email nvarchar(200),
    @Phone nvarchar(200),
    @Mobile nvarchar(200),
    @InformationID int,
    @OrderID int,
    @Action int
AS
IF @Action = 0
BEGIN
INSERT INTO [Account]
(
    [AccountName],
    [Password],
    [FirstName],
    [LastName],
    [IdentifyID],
    [Email],
    [Phone],
    [Mobile],
    [InformationID],
    [OrderID]
)
VALUES
(
    @AccountName,
    @Password,
    @FirstName,
    @LastName,
    @IdentifyID,
    @Email,
    @Phone,
    @Mobile,
    @InformationID,
    @OrderID
)
SET @ID = @@identity
END

ELSE IF @Action = 1
BEGIN
UPDATE [Account] SET
    [AccountName] = @AccountName,
    [Password] = @Password,
    [FirstName] = @FirstName,
    [LastName] = @LastName,
    [IdentifyID] = @IdentifyID,
    [Email] = @Email,
    [Phone] = @Phone,
    [Mobile] = @Mobile,
    [InformationID] = @InformationID,
    [OrderID] = @OrderID
WHERE [ID] = @ID
END

ELSE IF @Action = 2
BEGIN
DELETE [Account]
WHERE [ID] = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateDelete_Cooling_Request]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[InsertUpdateDelete_Cooling_Request]
    @ID int output,
    @Request_Date datetime,
    @ItemID int,
    @CustomerID int,
    @Requester nvarchar(200),
    @Delivery_Date datetime,
    @InformationID int,
    @OrderID int,
    @Action int
AS
IF @Action = 0
BEGIN
INSERT INTO [Cooling_Request]
(
    [Request_Date],
    [ItemID],
    [CustomerID],
    [Requester],
    [Delivery_Date],
    [InformationID],
    [OrderID]
)
VALUES
(
    @Request_Date,
    @ItemID,
    @CustomerID,
    @Requester,
    @Delivery_Date,
    @InformationID,
    @OrderID
)
SET @ID = @@identity
END

ELSE IF @Action = 1
BEGIN
UPDATE [Cooling_Request] SET
    [Request_Date] = @Request_Date,
    [ItemID] = @ItemID,
    [CustomerID] = @CustomerID,
    [Requester] = @Requester,
    [Delivery_Date] = @Delivery_Date,
    [InformationID] = @InformationID,
    [OrderID] = @OrderID
WHERE [ID] = @ID
END

ELSE IF @Action = 2
BEGIN
DELETE [Cooling_Request]
WHERE [ID] = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateDelete_Information]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[InsertUpdateDelete_Information]
    @ID int output,
    @NameInfor nvarchar(500),
    @DateCreated datetime,
    @CreatedBy nvarchar(50),
    @DateModified datetime,
    @ModifiedBy nvarchar(50),
    @Action int
AS
IF @Action = 0
BEGIN
INSERT INTO [Information]
(
    [NameInfor],
    [DateCreated],
    [CreatedBy],
    [DateModified],
    [ModifiedBy]
)
VALUES
(
    @NameInfor,
    @DateCreated,
    @CreatedBy,
    @DateModified,
    @ModifiedBy
)
SET @ID = @@identity
END

ELSE IF @Action = 1
BEGIN
UPDATE [Information] SET
    [NameInfor] = @NameInfor,
    [DateCreated] = @DateCreated,
    [CreatedBy] = @CreatedBy,
    [DateModified] = @DateModified,
    [ModifiedBy] = @ModifiedBy
WHERE [ID] = @ID
END

ELSE IF @Action = 2
BEGIN
DELETE [Information]
WHERE [ID] = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateDelete_Report_Customer_Complaints]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[InsertUpdateDelete_Report_Customer_Complaints]
    @ID int output,
    @Technical_staff nvarchar(200),
    @Customer_A_Quantity nvarchar(50),
    @Customer_A_Times nvarchar(50),
    @Customer_B_Quantity nvarchar(50),
    @Customer_B_Times nvarchar(50),
    @Customer_C_Quantity nvarchar(50),
    @Customer_C_Times nvarchar(50),
    @Customer_D_Quantity nvarchar(50),
    @Customer_D_Times nvarchar(50),
    @Result nvarchar(50),
    @InformationID int,
    @OrderID int,
    @Action int
AS
IF @Action = 0
BEGIN
INSERT INTO [Report_Customer_Complaints]
(
    [Technical_staff],
    [Customer_A_Quantity],
    [Customer_A_Times],
    [Customer_B_Quantity],
    [Customer_B_Times],
    [Customer_C_Quantity],
    [Customer_C_Times],
    [Customer_D_Quantity],
    [Customer_D_Times],
    [Result],
    [InformationID],
    [OrderID]
)
VALUES
(
    @Technical_staff,
    @Customer_A_Quantity,
    @Customer_A_Times,
    @Customer_B_Quantity,
    @Customer_B_Times,
    @Customer_C_Quantity,
    @Customer_C_Times,
    @Customer_D_Quantity,
    @Customer_D_Times,
    @Result,
    @InformationID,
    @OrderID
)
SET @ID = @@identity
END

ELSE IF @Action = 1
BEGIN
UPDATE [Report_Customer_Complaints] SET
    [Technical_staff] = @Technical_staff,
    [Customer_A_Quantity] = @Customer_A_Quantity,
    [Customer_A_Times] = @Customer_A_Times,
    [Customer_B_Quantity] = @Customer_B_Quantity,
    [Customer_B_Times] = @Customer_B_Times,
    [Customer_C_Quantity] = @Customer_C_Quantity,
    [Customer_C_Times] = @Customer_C_Times,
    [Customer_D_Quantity] = @Customer_D_Quantity,
    [Customer_D_Times] = @Customer_D_Times,
    [Result] = @Result,
    [InformationID] = @InformationID,
    [OrderID] = @OrderID
WHERE [ID] = @ID
END

ELSE IF @Action = 2
BEGIN
DELETE [Report_Customer_Complaints]
WHERE [ID] = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateDelete_Report_On_Board]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[InsertUpdateDelete_Report_On_Board]
    @ID int output,
    @ItemID int,
    @SupplierID int,
    @Price_EUR real,
    @CustomerID int,
    @Order_Quantity int,
    @Unit_Price real,
    @Delivery_Time nvarchar(200),
    @Pay nvarchar(200),
    @InformationID int,
    @OrderID int,
    @Action int
AS
IF @Action = 0
BEGIN
INSERT INTO [Report_On_Board]
(
    [ItemID],
    [SupplierID],
    [Price_EUR],
    [CustomerID],
    [Order_Quantity],
    [Unit_Price],
    [Delivery_Time],
    [Pay],
    [InformationID],
    [OrderID]
)
VALUES
(
    @ItemID,
    @SupplierID,
    @Price_EUR,
    @CustomerID,
    @Order_Quantity,
    @Unit_Price,
    @Delivery_Time,
    @Pay,
    @InformationID,
    @OrderID
)
SET @ID = @@identity
END

ELSE IF @Action = 1
BEGIN
UPDATE [Report_On_Board] SET
    [ItemID] = @ItemID,
    [SupplierID] = @SupplierID,
    [Price_EUR] = @Price_EUR,
    [CustomerID] = @CustomerID,
    [Order_Quantity] = @Order_Quantity,
    [Unit_Price] = @Unit_Price,
    [Delivery_Time] = @Delivery_Time,
    [Pay] = @Pay,
    [InformationID] = @InformationID,
    [OrderID] = @OrderID
WHERE [ID] = @ID
END

ELSE IF @Action = 2
BEGIN
DELETE [Report_On_Board]
WHERE [ID] = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateDelete_Repository]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[InsertUpdateDelete_Repository]
    @ID int output,
    @Repo_Name nvarchar(200),
    @Location nvarchar(200),
    @PalletID int,
    @ItemID int,
    @ContID nvarchar(200),
    @CustomerID int,
    @InformationID int,
    @OrderID int,
    @Action int
AS
IF @Action = 0
BEGIN
INSERT INTO [Repository]
(
    [Repo_Name],
    [Location],
    [PalletID],
    [ItemID],
    [ContID],
    [CustomerID],
    [InformationID],
    [OrderID]
)
VALUES
(
    @Repo_Name,
    @Location,
    @PalletID,
    @ItemID,
    @ContID,
    @CustomerID,
    @InformationID,
    @OrderID
)
SET @ID = @@identity
END

ELSE IF @Action = 1
BEGIN
UPDATE [Repository] SET
    [Repo_Name] = @Repo_Name,
    [Location] = @Location,
    [PalletID] = @PalletID,
    [ItemID] = @ItemID,
    [ContID] = @ContID,
    [CustomerID] = @CustomerID,
    [InformationID] = @InformationID,
    [OrderID] = @OrderID
WHERE [ID] = @ID
END

ELSE IF @Action = 2
BEGIN
DELETE [Repository]
WHERE [ID] = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateDelete_Role]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[InsertUpdateDelete_Role]
    @ID int output,
    @RoleName nvarchar(500),
    @Functions nvarchar(500),
    @InformationID int,
    @OrderID int,
    @Action int
AS
IF @Action = 0
BEGIN
INSERT INTO [Role]
(
    [RoleName],
    [Functions],
    [InformationID],
    [OrderID]
)
VALUES
(
    @RoleName,
    @Functions,
    @InformationID,
    @OrderID
)
SET @ID = @@identity
END

ELSE IF @Action = 1
BEGIN
UPDATE [Role] SET
    [RoleName] = @RoleName,
    [Functions] = @Functions,
    [InformationID] = @InformationID,
    [OrderID] = @OrderID
WHERE [ID] = @ID
END

ELSE IF @Action = 2
BEGIN
DELETE [Role]
WHERE [ID] = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateDelete_RoleAccount]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[InsertUpdateDelete_RoleAccount]
    @RoleID int,
    @AccountID int,
    @Active int,
    @Action int
AS
IF @Action = 0
BEGIN
INSERT INTO [RoleAccount]
(
    [RoleID],
    [AccountID],
    [Active]
)
VALUES
(
    @RoleID,
    @AccountID,
    @Active
)
END

ELSE IF @Action = 2
BEGIN
DELETE [RoleAccount]
WHERE [RoleID] = @RoleID AND [AccountID] = @AccountID
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateDelete_Supplier]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[InsertUpdateDelete_Supplier]
    @ID int output,
    @SupplierCode nvarchar(200),
    @SupplierName nvarchar(500),
    @Nation nvarchar(200),
    @InformationID int,
    @OrderID int,
    @Action int
AS
IF @Action = 0
BEGIN
INSERT INTO [Supplier]
(
    [SupplierCode],
    [SupplierName],
    [Nation],
    [InformationID],
    [OrderID]
)
VALUES
(
    @SupplierCode,
    @SupplierName,
    @Nation,
    @InformationID,
    @OrderID
)
SET @ID = @@identity
END

ELSE IF @Action = 1
BEGIN
UPDATE [Supplier] SET
    [SupplierCode] = @SupplierCode,
    [SupplierName] = @SupplierName,
    [Nation] = @Nation,
    [InformationID] = @InformationID,
    [OrderID] = @OrderID
WHERE [ID] = @ID
END

ELSE IF @Action = 2
BEGIN
DELETE [Supplier]
WHERE [ID] = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[TotalRowCount]    Script Date: 9/28/2019 4:58:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[TotalRowCount]
    @TableName nvarchar(128),
    @Filter nvarchar(1000)
AS
SET NOCOUNT ON
DECLARE @STMT nvarchar(4000)
SET @STMT = 'SELECT COUNT(1) FROM [' + @TableName + '] ' + @Filter
EXEC (@STMT)
GO
