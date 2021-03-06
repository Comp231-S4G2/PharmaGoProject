USE [master]
GO
/****** Object:  Database [GPADb]    Script Date: 12/6/2020 12:36:32 AM ******/
CREATE DATABASE [GPADb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GPADb', FILENAME = N'C:\Users\Andrey\GPADb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GPADb_log', FILENAME = N'C:\Users\Andrey\GPADb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GPADb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GPADb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GPADb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GPADb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GPADb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GPADb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GPADb] SET ARITHABORT OFF 
GO
ALTER DATABASE [GPADb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GPADb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GPADb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GPADb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GPADb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GPADb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GPADb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GPADb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GPADb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GPADb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GPADb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GPADb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GPADb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GPADb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GPADb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GPADb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [GPADb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GPADb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GPADb] SET  MULTI_USER 
GO
ALTER DATABASE [GPADb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GPADb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GPADb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GPADb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GPADb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GPADb] SET QUERY_STORE = OFF
GO
USE [GPADb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [GPADb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/6/2020 12:36:33 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 12/6/2020 12:36:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ApptTime] [datetime2](7) NOT NULL,
	[CustomerId] [nvarchar](450) NULL,
	[StoreId] [bigint] NOT NULL,
	[TimeSlotId] [bigint] NOT NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppReviews]    Script Date: 12/6/2020 12:36:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppReviews](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FluShotServices] [int] NOT NULL,
	[ApplicationPerformance] [int] NOT NULL,
	[TechnicalAssistanceResponse] [int] NOT NULL,
	[OverallReview] [int] NOT NULL,
	[UserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppReviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 12/6/2020 12:36:33 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/6/2020 12:36:33 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/6/2020 12:36:33 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/6/2020 12:36:33 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/6/2020 12:36:33 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/6/2020 12:36:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[AccessFailedCount] [int] NOT NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[PharmaId] [bigint] NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 12/6/2020 12:36:33 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerMedReserves]    Script Date: 12/6/2020 12:36:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerMedReserves](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [nvarchar](450) NULL,
	[StockMedicineId] [bigint] NOT NULL,
 CONSTRAINT [PK_CustomerMedReserves] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerPrescriptions]    Script Date: 12/6/2020 12:36:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerPrescriptions](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[PrescriptionPath] [nvarchar](max) NULL,
 CONSTRAINT [PK_CustomerPrescriptions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedDemands]    Script Date: 12/6/2020 12:36:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedDemands](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StockMedicineId] [bigint] NOT NULL,
	[CustomerPrescriptionId] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[InStock] [int] NOT NULL,
 CONSTRAINT [PK_MedDemands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicines]    Script Date: 12/6/2020 12:36:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicines](
	[MedicineId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_Medicines] PRIMARY KEY CLUSTERED 
(
	[MedicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pharmacies]    Script Date: 12/6/2020 12:36:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pharmacies](
	[PharmacyId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[EmailId] [nvarchar](max) NULL,
	[Contact] [nvarchar](max) NULL,
	[PharmacistId] [nvarchar](450) NULL,
	[AsstPharmacistId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Pharmacies] PRIMARY KEY CLUSTERED 
(
	[PharmacyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockMedicines]    Script Date: 12/6/2020 12:36:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockMedicines](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[MedicineId] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[PharmacyId] [bigint] NOT NULL,
 CONSTRAINT [PK_StockMedicines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeSlots]    Script Date: 12/6/2020 12:36:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSlots](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[ScheduleStartTime] [datetime2](7) NOT NULL,
	[ScheduleEndTime] [datetime2](7) NOT NULL,
	[PharmacyId] [bigint] NOT NULL,
 CONSTRAINT [PK_TimeSlots] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Appointments_CustomerId]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_Appointments_CustomerId] ON [dbo].[Appointments]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Appointments_TimeSlotId]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_Appointments_TimeSlotId] ON [dbo].[Appointments]
(
	[TimeSlotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CustomerMedReserves_CustomerId]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_CustomerMedReserves_CustomerId] ON [dbo].[CustomerMedReserves]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CustomerMedReserves_StockMedicineId]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_CustomerMedReserves_StockMedicineId] ON [dbo].[CustomerMedReserves]
(
	[StockMedicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CustomerPrescriptions_UserId]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_CustomerPrescriptions_UserId] ON [dbo].[CustomerPrescriptions]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MedDemands_CustomerPrescriptionId]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_MedDemands_CustomerPrescriptionId] ON [dbo].[MedDemands]
(
	[CustomerPrescriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MedDemands_StockMedicineId]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_MedDemands_StockMedicineId] ON [dbo].[MedDemands]
(
	[StockMedicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Pharmacies_AsstPharmacistId]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_Pharmacies_AsstPharmacistId] ON [dbo].[Pharmacies]
(
	[AsstPharmacistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Pharmacies_PharmacistId]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_Pharmacies_PharmacistId] ON [dbo].[Pharmacies]
(
	[PharmacistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StockMedicines_MedicineId]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_StockMedicines_MedicineId] ON [dbo].[StockMedicines]
(
	[MedicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StockMedicines_PharmacyId]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_StockMedicines_PharmacyId] ON [dbo].[StockMedicines]
(
	[PharmacyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TimeSlots_PharmacyId]    Script Date: 12/6/2020 12:36:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_TimeSlots_PharmacyId] ON [dbo].[TimeSlots]
(
	[PharmacyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_AspNetUsers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_AspNetUsers_CustomerId]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_TimeSlots_TimeSlotId] FOREIGN KEY([TimeSlotId])
REFERENCES [dbo].[TimeSlots] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_TimeSlots_TimeSlotId]
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
ALTER TABLE [dbo].[CustomerMedReserves]  WITH CHECK ADD  CONSTRAINT [FK_CustomerMedReserves_AspNetUsers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[CustomerMedReserves] CHECK CONSTRAINT [FK_CustomerMedReserves_AspNetUsers_CustomerId]
GO
ALTER TABLE [dbo].[CustomerMedReserves]  WITH CHECK ADD  CONSTRAINT [FK_CustomerMedReserves_StockMedicines_StockMedicineId] FOREIGN KEY([StockMedicineId])
REFERENCES [dbo].[StockMedicines] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomerMedReserves] CHECK CONSTRAINT [FK_CustomerMedReserves_StockMedicines_StockMedicineId]
GO
ALTER TABLE [dbo].[CustomerPrescriptions]  WITH CHECK ADD  CONSTRAINT [FK_CustomerPrescriptions_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[CustomerPrescriptions] CHECK CONSTRAINT [FK_CustomerPrescriptions_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[MedDemands]  WITH CHECK ADD  CONSTRAINT [FK_MedDemands_CustomerPrescriptions_CustomerPrescriptionId] FOREIGN KEY([CustomerPrescriptionId])
REFERENCES [dbo].[CustomerPrescriptions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedDemands] CHECK CONSTRAINT [FK_MedDemands_CustomerPrescriptions_CustomerPrescriptionId]
GO
ALTER TABLE [dbo].[MedDemands]  WITH CHECK ADD  CONSTRAINT [FK_MedDemands_StockMedicines_StockMedicineId] FOREIGN KEY([StockMedicineId])
REFERENCES [dbo].[StockMedicines] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedDemands] CHECK CONSTRAINT [FK_MedDemands_StockMedicines_StockMedicineId]
GO
ALTER TABLE [dbo].[Pharmacies]  WITH CHECK ADD  CONSTRAINT [FK_Pharmacies_AspNetUsers_AsstPharmacistId] FOREIGN KEY([AsstPharmacistId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Pharmacies] CHECK CONSTRAINT [FK_Pharmacies_AspNetUsers_AsstPharmacistId]
GO
ALTER TABLE [dbo].[Pharmacies]  WITH CHECK ADD  CONSTRAINT [FK_Pharmacies_AspNetUsers_PharmacistId] FOREIGN KEY([PharmacistId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Pharmacies] CHECK CONSTRAINT [FK_Pharmacies_AspNetUsers_PharmacistId]
GO
ALTER TABLE [dbo].[StockMedicines]  WITH CHECK ADD  CONSTRAINT [FK_StockMedicines_Medicines_MedicineId] FOREIGN KEY([MedicineId])
REFERENCES [dbo].[Medicines] ([MedicineId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StockMedicines] CHECK CONSTRAINT [FK_StockMedicines_Medicines_MedicineId]
GO
ALTER TABLE [dbo].[StockMedicines]  WITH CHECK ADD  CONSTRAINT [FK_StockMedicines_Pharmacies_PharmacyId] FOREIGN KEY([PharmacyId])
REFERENCES [dbo].[Pharmacies] ([PharmacyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StockMedicines] CHECK CONSTRAINT [FK_StockMedicines_Pharmacies_PharmacyId]
GO
ALTER TABLE [dbo].[TimeSlots]  WITH CHECK ADD  CONSTRAINT [FK_TimeSlots_Pharmacies_PharmacyId] FOREIGN KEY([PharmacyId])
REFERENCES [dbo].[Pharmacies] ([PharmacyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TimeSlots] CHECK CONSTRAINT [FK_TimeSlots_Pharmacies_PharmacyId]
GO
USE [master]
GO
ALTER DATABASE [GPADb] SET  READ_WRITE 
GO
