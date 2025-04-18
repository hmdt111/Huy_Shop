USE [Huy_Shop]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 24/3/2025 12:05:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 24/3/2025 12:05:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 24/3/2025 12:05:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 24/3/2025 12:05:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 24/3/2025 12:05:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 24/3/2025 12:05:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 24/3/2025 12:05:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Occupation] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[RoleId] [nvarchar](max) NULL,
	[Token] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 24/3/2025 12:05:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 24/3/2025 12:05:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 24/3/2025 12:05:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compares]    Script Date: 24/3/2025 12:05:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compares](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[UserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_Compares] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 24/3/2025 12:05:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[OrderCode] [nvarchar](max) NULL,
	[ProductId] [bigint] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 24/3/2025 12:05:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderCode] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 24/3/2025 12:05:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[BrandId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VnInfos]    Script Date: 24/3/2025 12:05:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VnInfos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDescription] [nvarchar](max) NULL,
	[TransactionId] [nvarchar](max) NULL,
	[OrderId] [nvarchar](max) NULL,
	[PaymentMethod] [nvarchar](max) NULL,
	[PaymentId] [nvarchar](max) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_VnInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wishlists]    Script Date: 24/3/2025 12:05:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wishlists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[UserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_Wishlists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250224160514_Initial', N'8.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250304064101_IdentityMigration', N'8.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250305173344_CreateCheckout', N'8.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250305180306_EditLongProductId', N'8.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250316174024_addwishlist_compare', N'8.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250317084153_AddTokenToUsers', N'8.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250322165201_AddVnpayModel', N'8.0.13')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'11a86dcd-6a5d-4f6e-beba-e147dbc83f4a', N'Admin', N'ADMIN', N'a3fe43ca-a76d-42c8-b610-4451219a8bd6')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4a0a9d06-7b35-49f4-b1e2-b0ad38a45f44', N'Customer', N'CUSTOMER', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'7901f61a-b8fe-44cd-98d5-8749f4bf8c98', N'Sales', N'SALES', N'ac7f7634-61ab-4b85-8d67-9ca867772f6d')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1e6c9a61-7534-4e67-a054-b9f5ba6bdc55', N'4a0a9d06-7b35-49f4-b1e2-b0ad38a45f44')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4cf049c2-db30-46a5-983d-0d9316a5ed24', N'11a86dcd-6a5d-4f6e-beba-e147dbc83f4a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'52a6e66f-9f71-4c51-acf5-25952c0dfd83', N'7901f61a-b8fe-44cd-98d5-8749f4bf8c98')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Occupation], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId], [Token]) VALUES (N'1e6c9a61-7534-4e67-a054-b9f5ba6bdc55', NULL, N'admin', N'ADMIN', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEGE4WnYDfFIZocRXBiCpaO5pcR5nqJ4AYN5t1ebD113oHh3rH5g38ygY55sVcwMtkQ==', N'K7XWTVYGLEQULNRK2ZK4OTWLFE4GLT5X', N'26b67d11-db98-4906-997c-7934237d7394', NULL, 0, 0, NULL, 1, 0, N'4a0a9d06-7b35-49f4-b1e2-b0ad38a45f44', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Occupation], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId], [Token]) VALUES (N'4cf049c2-db30-46a5-983d-0d9316a5ed24', NULL, N'huyadmin', N'HUYADMIN', N'huyad16072001@gmail.com', N'HUYAD16072001@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAECGBY8OCutJviU4xki1vpqDkg+X5leRQCS+Wu1IjLq31X8ThICCejQvXnvwKZZdyEA==', N'L3XE2X3UKK2JTO5572FRMMPPJ32ANPEO', N'2755459c-d8e1-46de-a78a-4b39d31e5d60', N'0969871669', 0, 0, NULL, 1, 0, N'11a86dcd-6a5d-4f6e-beba-e147dbc83f4a', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Occupation], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId], [Token]) VALUES (N'52a6e66f-9f71-4c51-acf5-25952c0dfd83', NULL, N'funym3o', N'FUNYM3O', N'funym3o@gmail.com', N'FUNYM3O@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEGKPLkE0VjL6j+k+2mXc4gVOxKMz69mDZL8xDSvm8Hp8GqfouCRHCv5OA95YdXyEig==', N'PFFJUUE2YZCIV7GOKW4KPPFTDUNBDTTP', N'45fe824f-8fc0-4f1b-9b9c-93d818a6fa61', N'0969871669', 0, 0, NULL, 1, 0, N'7901f61a-b8fe-44cd-98d5-8749f4bf8c98', NULL)
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (1, N'Apple', N'Apple is large Brand in the world', N'apple', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (2, N'SamSung', N'SamSung is large Brand in the world', N'samsung', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (3, N'Lenovo', N'máy tính xách tay', N'Lenovo', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (4, N'Asus', N'Asus
', N'Asus', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (5, N'Gigabyte', N'Gigabyte', N'Gigabyte', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (6, N'MSI', N'MSI', N'MSI', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (7, N'EVGA', N'EVGA', N'EVGA', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (8, N'Galax', N'Galax', N'Galax', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (9, N'Corsair', N'Corsair', N'Corsair', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (10, N'Montech', N'Montech', N'Montech', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (11, N'Logitech', N'Logitech', N'Logitech', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (12, N'JBL', N'JBL', N'JBL', 1)
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (1, N'Macbook', N'Macbook is large Product in the world', N'macbook', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (2, N'PC', N'Pc is large Product in the world', N'pc', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (3, N'Apple Watch', N'Đồng hồ đeo tay ', N'Apple-Watch', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (4, N'Ipad', N'Máy tính bản', N'Ipad', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (5, N'AirPod', N'tai nghe
', N'AirPod', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (6, N'Iphone', N'điện thoại di động', N'Iphone', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (7, N'Monitor', N'Màn hình
', N'Monitor', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (8, N'Speaker', N'Loa ', N'Speaker', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (9, N'Graphics card', N'Card đồ họa', N'Graphics-card', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (10, N'Mouse', N'Chuột máy tính', N'Mouse', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (11, N'Keyboard', N'Bàn phím máy tính', N'Keyboard', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (12, N'Case', N'Vỏ máy tính', N'Case', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (13, N'MainBoard', N'Bo mạch chính
', N'MainBoard', 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (4, N'admin1@gmail.com', N'3946ac44-32e8-4354-bb64-b8d9ab9689c5', 1, CAST(24000000.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (5, N'admin1@gmail.com', N'3946ac44-32e8-4354-bb64-b8d9ab9689c5', 2, CAST(24000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (6, N'admin@gmail.com', N'2469dc03-1f6b-4a86-a0bd-7f197a6d0b8a', 1, CAST(24000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (7, N'admin@gmail.com', N'2469dc03-1f6b-4a86-a0bd-7f197a6d0b8a', 2, CAST(24000000.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (8, N'funym3o@gmail.com', N'65c030b3-22a7-4990-9658-0bc0bd34ac51', 1, CAST(24000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (9, N'funym3o@gmail.com', N'65c030b3-22a7-4990-9658-0bc0bd34ac51', 6, CAST(32000000.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (10, N'funym3o@gmail.com', N'af8b7eb5-01fc-44e6-a06a-e99a2d67ec6d', 1, CAST(24000000.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (11, N'funym3o@gmail.com', N'af8b7eb5-01fc-44e6-a06a-e99a2d67ec6d', 11, CAST(6000000.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (12, N'funym3o@gmail.com', N'af8b7eb5-01fc-44e6-a06a-e99a2d67ec6d', 14, CAST(400000.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (13, N'funym3o@gmail.com', N'c0f363ed-e2ae-4876-a9bb-58b21dd64fb0', 1, CAST(24000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (14, N'funym3o@gmail.com', N'c0f363ed-e2ae-4876-a9bb-58b21dd64fb0', 8, CAST(32000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (15, N'funym3o@gmail.com', N'c0f363ed-e2ae-4876-a9bb-58b21dd64fb0', 14, CAST(400000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (16, N'funym3o@gmail.com', N'06daa389-54ed-4ca0-a362-edfd36f925e1', 1, CAST(24000000.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (17, N'funym3o@gmail.com', N'06daa389-54ed-4ca0-a362-edfd36f925e1', 8, CAST(32000000.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (18, N'funym3o@gmail.com', N'06daa389-54ed-4ca0-a362-edfd36f925e1', 13, CAST(400000.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (19, N'funym3o@gmail.com', N'72508a27-edfc-412b-b06a-dcd6d5e16f43', 11, CAST(6000000.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (20, N'funym3o@gmail.com', N'72508a27-edfc-412b-b06a-dcd6d5e16f43', 14, CAST(400000.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (21, N'huyad16072001@gmail.com', N'f4c5e807-3de7-4945-9b49-425430482304', 1, CAST(24000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (22, N'huyad16072001@gmail.com', N'f8e37bfe-1453-4d88-8d5e-1687eaedc341', 14, CAST(400000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (23, N'huyad16072001@gmail.com', N'7571df32-39e5-4aa9-a27b-8764a47d2132', 14, CAST(400000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (24, N'huyad16072001@gmail.com', N'7571df32-39e5-4aa9-a27b-8764a47d2132', 15, CAST(500000.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [CreatedDate], [Status]) VALUES (2, N'3946ac44-32e8-4354-bb64-b8d9ab9689c5', N'admin1@gmail.com', CAST(N'2025-03-06T22:44:46.7594848' AS DateTime2), 0)
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [CreatedDate], [Status]) VALUES (3, N'2469dc03-1f6b-4a86-a0bd-7f197a6d0b8a', N'admin@gmail.com', CAST(N'2025-03-10T13:00:30.6454370' AS DateTime2), 0)
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [CreatedDate], [Status]) VALUES (4, N'65c030b3-22a7-4990-9658-0bc0bd34ac51', N'funym3o@gmail.com', CAST(N'2025-03-10T13:03:38.1751744' AS DateTime2), 1)
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [CreatedDate], [Status]) VALUES (5, N'af8b7eb5-01fc-44e6-a06a-e99a2d67ec6d', N'funym3o@gmail.com', CAST(N'2025-03-10T14:48:28.7348025' AS DateTime2), 1)
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [CreatedDate], [Status]) VALUES (6, N'c0f363ed-e2ae-4876-a9bb-58b21dd64fb0', N'funym3o@gmail.com', CAST(N'2025-03-10T14:57:05.7041494' AS DateTime2), 1)
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [CreatedDate], [Status]) VALUES (7, N'06daa389-54ed-4ca0-a362-edfd36f925e1', N'funym3o@gmail.com', CAST(N'2025-03-10T15:00:20.0318824' AS DateTime2), 1)
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [CreatedDate], [Status]) VALUES (8, N'72508a27-edfc-412b-b06a-dcd6d5e16f43', N'funym3o@gmail.com', CAST(N'2025-03-10T15:04:04.7743830' AS DateTime2), 1)
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [CreatedDate], [Status]) VALUES (9, N'f4c5e807-3de7-4945-9b49-425430482304', N'huyad16072001@gmail.com', CAST(N'2025-03-20T02:36:46.3722834' AS DateTime2), 1)
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [CreatedDate], [Status]) VALUES (10, N'f8e37bfe-1453-4d88-8d5e-1687eaedc341', N'huyad16072001@gmail.com', CAST(N'2025-03-23T00:26:21.5815949' AS DateTime2), 1)
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [CreatedDate], [Status]) VALUES (11, N'7571df32-39e5-4aa9-a27b-8764a47d2132', N'huyad16072001@gmail.com', CAST(N'2025-03-23T22:46:14.4369906' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (1, N'Macbook Pro 2024', N'macbook', N'<p>Macbook is the Best</p>
', CAST(24000000.00 AS Decimal(18, 2)), 1, 1, N'97c06ff4-d87f-4220-bb51-cb22ecae8904_redesigned-MacBook-Pro-2.jpeg')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (2, N'PC AMD Ryzen 5', N'pc', N'Pc is the Best', CAST(24000000.00 AS Decimal(18, 2)), 2, 2, N'2.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (6, N'Macbook Air 2025', N'Macbook-Air-2024', N'<p>sdssd</p>
', CAST(32000000.00 AS Decimal(18, 2)), 1, 1, N'41685153-b931-4c4c-8852-2f33d8363e03_Macbook_Air_2024.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (7, N'Samsung Galaxy 4', N'Samsung-Galaxy-4', N'<p>ssssss</p>
', CAST(32000000.00 AS Decimal(18, 2)), 2, 2, N'62e01d3e-76a0-4fff-8864-b9fb793962e8_picture-1716255340.png')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (8, N'Samsung Galaxy Pro 15', N'Samsung-Galaxy-Pro-15', N'<p>sss</p>
', CAST(32000000.00 AS Decimal(18, 2)), 2, 2, N'36536448-289a-4128-b32d-39f25d405f5a_samsung-galaxy-book-pro-15-2021-2-1639379162-laptop365-_4c2354c3-990b-46d3-b65b-38ce3c522176.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (9, N'Macbook Air M2', N'Macbook-Air-M2', N'<p>ssssssss</p>
', CAST(36000000.00 AS Decimal(18, 2)), 1, 1, N'e65d4442-b53e-4f82-83df-292b131b7957_0034095_macbook-air-m2-13-inch-8-core-gpu-16gb-ram-256gb-ssd.png')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (10, N'Macbook Air 2023', N'Macbook-Air-2023', N'<p>sssss</p>
', CAST(32000000.00 AS Decimal(18, 2)), 1, 1, N'59ca7c9f-80cc-4144-9a9e-e250364385a6_macbook-pro-16-inch-2023.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (11, N'Apple Watch SE GPS', N'Apple-Watch-SE-GPS', N'<p>L&agrave; một trong những&nbsp;<strong>sản phẩm</strong>&nbsp;trung h&ograve;a carbon đầu ti&ecirc;n của&nbsp;<strong>Apple</strong></p>
', CAST(6000000.00 AS Decimal(18, 2)), 1, 3, N'6b32385e-0524-4028-ba49-aa113a44e825_MXM63ref_FV98_VW_34FR+watch-case-44-aluminum-starlight-nc-se_VW_34FR+watch-face-44-aluminum-starlight-se_VW_34FR.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (12, N'Apple Watch Series 10', N'Apple-Watch-Series-10', N'<p>L&agrave; Apple Watch mỏng nhất từ trước đến nay, đảm bảo mang đến sự thoải m&aacute;i tuyệt vời</p>
', CAST(6000000.00 AS Decimal(18, 2)), 1, 3, N'5c16860e-2a09-4b58-b1a8-a77c0a7a1f1f_apple-watch-s10-lte-day-silicone-bac-tb-600x600.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (13, N'G502 Hero', N'G502-Hero', N'<p>G502 HERO sở hữu cảm biến chơi game HERO 25K&nbsp;</p>
', CAST(400000.00 AS Decimal(18, 2)), 11, 10, N'4414d6d7-9601-4838-844d-70b19ae989ed_g502-hero-gallery-2-nb.png')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (14, N'G Pro X SuperLight Pink', N'G-Pro-X-SuperLight-Pink', N'<p>Chuột gaming kh&ocirc;ng d&acirc; ynhẹ nhất thế giới, chỉ 60 gram</p>
', CAST(400000.00 AS Decimal(18, 2)), 11, 10, N'c285e975-385a-4659-ab72-dd0ab93aa774_chuot-logitech-g-pro-x-superlight-wireless-pink--1.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (15, N'Air Pods 4', N'Air-Pods-4', N'<p>Tai nghe AirPods 4 sở hữu nhiều trang bị ấn tượng như chip H2 mạnh mẽ gi&uacute;p xử l&yacute; &acirc;m thanh đ&agrave;m thoại cực tốt, &acirc;m thanh đa chiều ch&acirc;n thực, thiết kế tinh tế v&agrave; &ecirc;m tai, pin bền bỉ c&ugrave;ng khả năng tương th&iacute;ch linh hoạt với hệ sinh th&aacute;i Apple. Đ&acirc;y sẽ l&agrave; sự lựa chọn l&yacute; tưởng gi&uacute;p mang đến cho bạn trải nghiệm nghe tuyệt vời.</p>
', CAST(500000.00 AS Decimal(18, 2)), 1, 5, N'c6db2495-bafd-47df-b85e-605d66380cd6_442897720.jpeg')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[VnInfos] ON 

INSERT [dbo].[VnInfos] ([Id], [OrderDescription], [TransactionId], [OrderId], [PaymentMethod], [PaymentId], [DateCreated]) VALUES (1, N'huyadmin Thanh toán qua Vnpay tại Huy_Shop 400000', N'14861647', N'638782863018294390', N'VnPay', N'14861647', CAST(N'2025-03-23T00:26:21.400' AS DateTime))
INSERT [dbo].[VnInfos] ([Id], [OrderDescription], [TransactionId], [OrderId], [PaymentMethod], [PaymentId], [DateCreated]) VALUES (2, N'huyadmin Thanh toán qua Vnpay tại Huy_Shop 900000', N'14863085', N'638783667404783958', N'VnPay', N'14863085', CAST(N'2025-03-23T22:46:14.230' AS DateTime))
SET IDENTITY_INSERT [dbo].[VnInfos] OFF
GO
SET IDENTITY_INSERT [dbo].[Wishlists] ON 

INSERT [dbo].[Wishlists] ([Id], [ProductId], [UserId]) VALUES (8, 1, N'37788271-8b68-4f5a-8869-992cd3c3b6c3')
INSERT [dbo].[Wishlists] ([Id], [ProductId], [UserId]) VALUES (9, 12, N'37788271-8b68-4f5a-8869-992cd3c3b6c3')
SET IDENTITY_INSERT [dbo].[Wishlists] OFF
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Compares]  WITH CHECK ADD  CONSTRAINT [FK_Compares_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Compares] CHECK CONSTRAINT [FK_Compares_Products_ProductId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brands_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Brands_BrandId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Wishlists]  WITH CHECK ADD  CONSTRAINT [FK_Wishlists_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Wishlists] CHECK CONSTRAINT [FK_Wishlists_Products_ProductId]
GO
