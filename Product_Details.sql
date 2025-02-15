USE [Product_Details]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 05-04-2024 19:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[CartId] [int] IDENTITY(1,1) NOT NULL,
	[TotalPrice] [decimal](10, 0) NOT NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_Cart_1] PRIMARY KEY CLUSTERED 
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartItem]    Script Date: 05-04-2024 19:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItem](
	[CartItemId] [int] IDENTITY(1,1) NOT NULL,
	[CartId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Qty] [int] NULL,
	[UnitPrice] [decimal](10, 0) NULL,
	[Amount] [decimal](10, 0) NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[CartItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 05-04-2024 19:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Qty] [int] NULL,
	[UnitPrice] [decimal](10, 0) NULL,
	[Amount] [decimal](10, 0) NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 05-04-2024 19:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductImg] [nvarchar](500) NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ProductNumber] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[ProductPrice] [int] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteBy] [int] NULL,
	[DeleteAt] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductQuantity]    Script Date: 05-04-2024 19:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductQuantity](
	[ProductQuantityId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdateAt] [datetime] NULL,
 CONSTRAINT [PK_ProductQuantity] PRIMARY KEY CLUSTERED 
(
	[ProductQuantityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 05-04-2024 19:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserPhoto] [nvarchar](500) NULL,
	[FirstName] [nvarchar](25) NOT NULL,
	[LastName] [nvarchar](25) NOT NULL,
	[UserRole] [nvarchar](25) NOT NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[Gender] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteBy] [int] NULL,
	[DeleteAt] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([CartId], [TotalPrice], [CreatedBy]) VALUES (5, CAST(2000 AS Decimal(10, 0)), 19)
INSERT [dbo].[Cart] ([CartId], [TotalPrice], [CreatedBy]) VALUES (6, CAST(30 AS Decimal(10, 0)), 22)
SET IDENTITY_INSERT [dbo].[Cart] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderProduct] ON 

INSERT [dbo].[OrderProduct] ([OrderId], [ProductId], [Qty], [UnitPrice], [Amount], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [DeletedBy], [DeletedAt]) VALUES (5, 35, 1, CAST(1000 AS Decimal(10, 0)), CAST(1000 AS Decimal(10, 0)), 19, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[OrderProduct] ([OrderId], [ProductId], [Qty], [UnitPrice], [Amount], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [DeletedBy], [DeletedAt]) VALUES (6, 37, 2, CAST(100 AS Decimal(10, 0)), CAST(200 AS Decimal(10, 0)), 19, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[OrderProduct] ([OrderId], [ProductId], [Qty], [UnitPrice], [Amount], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [DeletedBy], [DeletedAt]) VALUES (7, 38, 2, CAST(150 AS Decimal(10, 0)), CAST(300 AS Decimal(10, 0)), 19, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[OrderProduct] ([OrderId], [ProductId], [Qty], [UnitPrice], [Amount], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [DeletedBy], [DeletedAt]) VALUES (8, 39, 2, CAST(500 AS Decimal(10, 0)), CAST(1000 AS Decimal(10, 0)), 22, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[OrderProduct] ([OrderId], [ProductId], [Qty], [UnitPrice], [Amount], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [DeletedBy], [DeletedAt]) VALUES (9, 37, 1, CAST(100 AS Decimal(10, 0)), CAST(100 AS Decimal(10, 0)), 19, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[OrderProduct] ([OrderId], [ProductId], [Qty], [UnitPrice], [Amount], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [DeletedBy], [DeletedAt]) VALUES (10, 40, 2, CAST(15 AS Decimal(10, 0)), CAST(30 AS Decimal(10, 0)), 22, NULL, 22, NULL, NULL, NULL)
INSERT [dbo].[OrderProduct] ([OrderId], [ProductId], [Qty], [UnitPrice], [Amount], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [DeletedBy], [DeletedAt]) VALUES (11, 35, 2, CAST(1000 AS Decimal(10, 0)), CAST(2000 AS Decimal(10, 0)), 19, NULL, 19, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[OrderProduct] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [ProductImg], [ProductName], [ProductNumber], [Description], [ProductPrice], [CreatedBy], [CreatedAt], [UpdateBy], [UpdateAt], [DeleteBy], [DeleteAt]) VALUES (37, N'~/Upload/images (2).jpeg', N'Smart Watch', N'PD002', N'nice and good', 100, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductId], [ProductImg], [ProductName], [ProductNumber], [Description], [ProductPrice], [CreatedBy], [CreatedAt], [UpdateBy], [UpdateAt], [DeleteBy], [DeleteAt]) VALUES (38, N'~/Upload/home-appliances-png-24.jpg', N'Mixer', N'PD003', N'wowww', 150, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductId], [ProductImg], [ProductName], [ProductNumber], [Description], [ProductPrice], [CreatedBy], [CreatedAt], [UpdateBy], [UpdateAt], [DeleteBy], [DeleteAt]) VALUES (40, N'~/Upload/th.jpeg', N'Ghadi', N'PD005', N'wow', 15, 18, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductId], [ProductImg], [ProductName], [ProductNumber], [Description], [ProductPrice], [CreatedBy], [CreatedAt], [UpdateBy], [UpdateAt], [DeleteBy], [DeleteAt]) VALUES (41, N'~/Upload/th (1).jpeg', N'Amezon TV', N'PD005', N'nice', 500, 18, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductQuantity] ON 

INSERT [dbo].[ProductQuantity] ([ProductQuantityId], [ProductId], [Quantity], [UpdateBy], [UpdateAt]) VALUES (3, 37, 6, NULL, NULL)
INSERT [dbo].[ProductQuantity] ([ProductQuantityId], [ProductId], [Quantity], [UpdateBy], [UpdateAt]) VALUES (4, 38, 15, NULL, NULL)
INSERT [dbo].[ProductQuantity] ([ProductQuantityId], [ProductId], [Quantity], [UpdateBy], [UpdateAt]) VALUES (6, 40, 0, NULL, NULL)
INSERT [dbo].[ProductQuantity] ([ProductQuantityId], [ProductId], [Quantity], [UpdateBy], [UpdateAt]) VALUES (7, 41, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ProductQuantity] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [UserPhoto], [FirstName], [LastName], [UserRole], [PhoneNumber], [Email], [Password], [DateOfBirth], [Gender], [Address], [CreateBy], [CreateAt], [UpdateBy], [UpdateAt], [DeleteBy], [DeleteAt]) VALUES (18, N'~/Upload/WhatsApp Image 2024-02-01 at 00.54.18_f350bd77.jpg', N'Jeel', N'Savaliya', N'Admin', N'64654654654', N'admin@gmail.com', N'abc123', CAST(N'2002-02-10T00:00:00.000' AS DateTime), N'Male', N'Rajkot', 18, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [UserPhoto], [FirstName], [LastName], [UserRole], [PhoneNumber], [Email], [Password], [DateOfBirth], [Gender], [Address], [CreateBy], [CreateAt], [UpdateBy], [UpdateAt], [DeleteBy], [DeleteAt]) VALUES (19, N'~/Upload/h2.jpg', N'Hanuman', N'kesrinandan', N'User', N'1235678950', N'aaa@gmail.com', N'a123', CAST(N'2023-10-28T00:00:00.000' AS DateTime), N'Male', N'aaaaaaaaaaa', 19, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [UserPhoto], [FirstName], [LastName], [UserRole], [PhoneNumber], [Email], [Password], [DateOfBirth], [Gender], [Address], [CreateBy], [CreateAt], [UpdateBy], [UpdateAt], [DeleteBy], [DeleteAt]) VALUES (22, N'~/Upload/Screenshot (15).png', N'Chotu', N'Bhai', N'User', N'123456789', N'bbb@gmail.com', N'123', CAST(N'2023-10-29T00:00:00.000' AS DateTime), N'Male', N'sdjksabdhjabd', 22, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD  CONSTRAINT [FK_CartItem_Cart] FOREIGN KEY([CartId])
REFERENCES [dbo].[Cart] ([CartId])
GO
ALTER TABLE [dbo].[CartItem] CHECK CONSTRAINT [FK_CartItem_Cart]
GO
ALTER TABLE [dbo].[ProductQuantity]  WITH CHECK ADD  CONSTRAINT [FK_ProductQuantity_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductQuantity] CHECK CONSTRAINT [FK_ProductQuantity_Product]
GO
