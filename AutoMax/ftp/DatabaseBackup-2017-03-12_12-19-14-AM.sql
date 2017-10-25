CREATE DATABASE [automaxdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'automaxdb', FILENAME = N'c:\databases\automaxdb\automaxdb.mdf' , SIZE = 41792KB , MAXSIZE = 20971520KB , FILEGROWTH = 10%)
 LOG ON 
( NAME = N'automaxdb_log', FILENAME = N'c:\databases\automaxdb\automaxdb_log.ldf' , SIZE = 29504KB , MAXSIZE = 1048576KB , FILEGROWTH = 10%)
 COLLATE SQL_Latin1_General_CP1_CI_AS
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [automaxdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
ALTER DATABASE [automaxdb] SET ANSI_NULL_DEFAULT OFF 
ALTER DATABASE [automaxdb] SET ANSI_NULLS OFF 
ALTER DATABASE [automaxdb] SET ANSI_PADDING OFF 
ALTER DATABASE [automaxdb] SET ANSI_WARNINGS OFF 
ALTER DATABASE [automaxdb] SET ARITHABORT OFF 
ALTER DATABASE [automaxdb] SET AUTO_CLOSE OFF 
ALTER DATABASE [automaxdb] SET AUTO_CREATE_STATISTICS ON 
ALTER DATABASE [automaxdb] SET AUTO_SHRINK ON 
ALTER DATABASE [automaxdb] SET AUTO_UPDATE_STATISTICS ON 
ALTER DATABASE [automaxdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
ALTER DATABASE [automaxdb] SET CURSOR_DEFAULT  GLOBAL 
ALTER DATABASE [automaxdb] SET CONCAT_NULL_YIELDS_NULL OFF 
ALTER DATABASE [automaxdb] SET NUMERIC_ROUNDABORT OFF 
ALTER DATABASE [automaxdb] SET QUOTED_IDENTIFIER OFF 
ALTER DATABASE [automaxdb] SET RECURSIVE_TRIGGERS OFF 
ALTER DATABASE [automaxdb] SET  DISABLE_BROKER 
ALTER DATABASE [automaxdb] SET AUTO_UPDATE_STATISTICS_ASYNC ON 
ALTER DATABASE [automaxdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
ALTER DATABASE [automaxdb] SET TRUSTWORTHY OFF 
ALTER DATABASE [automaxdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
ALTER DATABASE [automaxdb] SET PARAMETERIZATION SIMPLE 
ALTER DATABASE [automaxdb] SET READ_COMMITTED_SNAPSHOT OFF 
ALTER DATABASE [automaxdb] SET HONOR_BROKER_PRIORITY OFF 
ALTER DATABASE [automaxdb] SET RECOVERY SIMPLE 
ALTER DATABASE [automaxdb] SET  MULTI_USER 
ALTER DATABASE [automaxdb] SET PAGE_VERIFY CHECKSUM  
ALTER DATABASE [automaxdb] SET DB_CHAINING OFF 
ALTER DATABASE [automaxdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
ALTER DATABASE [automaxdb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
ALTER DATABASE [automaxdb] SET  READ_WRITE 
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__MigrationHistory]') AND type in (N'U'))
DROP TABLE [dbo].[__MigrationHistory]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ContextKey] [nvarchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[__MigrationHistory]') AND name = N'PK____Migrat__EE2FFF92DFCF4133')
ALTER TABLE [dbo].[__MigrationHistory] DROP CONSTRAINT [PK____Migrat__EE2FFF92DFCF4133]
SET ANSI_PADDING ON

ALTER TABLE [dbo].[__MigrationHistory] ADD PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutoAirBags]') AND type in (N'U'))
DROP TABLE [dbo].[AutoAirBags]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[AutoAirBags](
	[AutoAirBagID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL
) ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoAirBags]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[AutoAirBags]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[AutoAirBags]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoAirBags]') AND name = N'PK__AutoAirB__5F354222440ED138')
ALTER TABLE [dbo].[AutoAirBags] DROP CONSTRAINT [PK__AutoAirB__5F354222440ED138]
ALTER TABLE [dbo].[AutoAirBags] ADD PRIMARY KEY CLUSTERED 
(
	[AutoAirBagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutoBodyStyles]') AND type in (N'U'))
DROP TABLE [dbo].[AutoBodyStyles]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[AutoBodyStyles](
	[AutoBodyStyleID] [int] IDENTITY(1,1) NOT NULL,
	[BodyStyle] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicBodyStyle] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ArabicDescription] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoBodyStyles]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[AutoBodyStyles]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[AutoBodyStyles]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoBodyStyles]') AND name = N'PK__AutoBody__4CC7B2C6504DE76B')
ALTER TABLE [dbo].[AutoBodyStyles] DROP CONSTRAINT [PK__AutoBody__4CC7B2C6504DE76B]
ALTER TABLE [dbo].[AutoBodyStyles] ADD PRIMARY KEY CLUSTERED 
(
	[AutoBodyStyleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutoConditions]') AND type in (N'U'))
DROP TABLE [dbo].[AutoConditions]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[AutoConditions](
	[AutoConditionID] [int] IDENTITY(1,1) NOT NULL,
	[Condition] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicCondition] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoConditions]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[AutoConditions]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[AutoConditions]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoConditions]') AND name = N'PK__AutoCond__7A481124D127C2C2')
ALTER TABLE [dbo].[AutoConditions] DROP CONSTRAINT [PK__AutoCond__7A481124D127C2C2]
ALTER TABLE [dbo].[AutoConditions] ADD PRIMARY KEY CLUSTERED 
(
	[AutoConditionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutoDoors]') AND type in (N'U'))
DROP TABLE [dbo].[AutoDoors]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[AutoDoors](
	[AutoDoorsID] [bigint] IDENTITY(1,1) NOT NULL,
	[Doors] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Value] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicDoors] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoDoors]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[AutoDoors]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[AutoDoors]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoDoors]') AND name = N'PK__AutoDoor__FB55F1FA73D39573')
ALTER TABLE [dbo].[AutoDoors] DROP CONSTRAINT [PK__AutoDoor__FB55F1FA73D39573]
ALTER TABLE [dbo].[AutoDoors] ADD PRIMARY KEY CLUSTERED 
(
	[AutoDoorsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutoEngines]') AND type in (N'U'))
DROP TABLE [dbo].[AutoEngines]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[AutoEngines](
	[AutoEngineID] [bigint] IDENTITY(1,1) NOT NULL,
	[EngineName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Value] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicEngineName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoEngines]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[AutoEngines]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[AutoEngines]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoEngines]') AND name = N'PK__AutoEngi__053FA3B66171CA44')
ALTER TABLE [dbo].[AutoEngines] DROP CONSTRAINT [PK__AutoEngi__053FA3B66171CA44]
ALTER TABLE [dbo].[AutoEngines] ADD PRIMARY KEY CLUSTERED 
(
	[AutoEngineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutoExteriorColors]') AND type in (N'U'))
DROP TABLE [dbo].[AutoExteriorColors]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[AutoExteriorColors](
	[AutoExteriorColorID] [bigint] IDENTITY(1,1) NOT NULL,
	[ExteriorColor] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Value] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicExteriorColor] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoExteriorColors]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[AutoExteriorColors]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[AutoExteriorColors]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoExteriorColors]') AND name = N'PK__AutoExte__7F2BE8DE47B23C34')
ALTER TABLE [dbo].[AutoExteriorColors] DROP CONSTRAINT [PK__AutoExte__7F2BE8DE47B23C34]
ALTER TABLE [dbo].[AutoExteriorColors] ADD PRIMARY KEY CLUSTERED 
(
	[AutoExteriorColorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutoGlobalizations]') AND type in (N'U'))
DROP TABLE [dbo].[AutoGlobalizations]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[AutoGlobalizations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[En] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Ar] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LanguageID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoGlobalizations]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[AutoGlobalizations]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[AutoGlobalizations]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoGlobalizations]') AND name = N'PK__AutoGlob__3214EC07714153BC')
ALTER TABLE [dbo].[AutoGlobalizations] DROP CONSTRAINT [PK__AutoGlob__3214EC07714153BC]
ALTER TABLE [dbo].[AutoGlobalizations] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutoInteriorColors]') AND type in (N'U'))
DROP TABLE [dbo].[AutoInteriorColors]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[AutoInteriorColors](
	[AutoInteriorColorID] [bigint] IDENTITY(1,1) NOT NULL,
	[InteriorColor] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Value] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicInteriorColor] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoInteriorColors]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[AutoInteriorColors]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[AutoInteriorColors]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoInteriorColors]') AND name = N'PK__AutoInte__D03EECEC486E72C5')
ALTER TABLE [dbo].[AutoInteriorColors] DROP CONSTRAINT [PK__AutoInte__D03EECEC486E72C5]
ALTER TABLE [dbo].[AutoInteriorColors] ADD PRIMARY KEY CLUSTERED 
(
	[AutoInteriorColorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutoInventoryStatusHistories]') AND type in (N'U'))
DROP TABLE [dbo].[AutoInventoryStatusHistories]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[AutoInventoryStatusHistories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [bigint] NOT NULL,
	[FromInventoryStatusID] [int] NOT NULL,
	[ToInventoryStatusID] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL
) ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoInventoryStatusHistories]') AND name = N'PK__AutoInve__3214EC279CD6E7E5')
ALTER TABLE [dbo].[AutoInventoryStatusHistories] DROP CONSTRAINT [PK__AutoInve__3214EC279CD6E7E5]
ALTER TABLE [dbo].[AutoInventoryStatusHistories] ADD PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutoModelMappings]') AND type in (N'U'))
DROP TABLE [dbo].[AutoModelMappings]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[AutoModelMappings](
	[AutoModelMappingID] [int] IDENTITY(1,1) NOT NULL,
	[AutoModelID] [int] NOT NULL,
	[OpensooqName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HarajName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoModelMappings]') AND name = N'IX_AutoModelID')
DROP INDEX [IX_AutoModelID] ON [dbo].[AutoModelMappings]
CREATE NONCLUSTERED INDEX [IX_AutoModelID] ON [dbo].[AutoModelMappings]
(
	[AutoModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoModelMappings]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[AutoModelMappings]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[AutoModelMappings]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoModelMappings]') AND name = N'PK__AutoMode__CF9DA22825EB0867')
ALTER TABLE [dbo].[AutoModelMappings] DROP CONSTRAINT [PK__AutoMode__CF9DA22825EB0867]
ALTER TABLE [dbo].[AutoModelMappings] ADD PRIMARY KEY CLUSTERED 
(
	[AutoModelMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutoModels]') AND type in (N'U'))
DROP TABLE [dbo].[AutoModels]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[AutoModels](
	[AutoModelID] [int] IDENTITY(1,1) NOT NULL,
	[ModelName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[MakerID] [int] NULL,
	[ArabicModelName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoModels]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[AutoModels]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[AutoModels]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoModels]') AND name = N'IX_MakerID')
DROP INDEX [IX_MakerID] ON [dbo].[AutoModels]
CREATE NONCLUSTERED INDEX [IX_MakerID] ON [dbo].[AutoModels]
(
	[MakerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoModels]') AND name = N'PK__AutoMode__C4AC13433B0D762A')
ALTER TABLE [dbo].[AutoModels] DROP CONSTRAINT [PK__AutoMode__C4AC13433B0D762A]
ALTER TABLE [dbo].[AutoModels] ADD PRIMARY KEY CLUSTERED 
(
	[AutoModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutoSteerings]') AND type in (N'U'))
DROP TABLE [dbo].[AutoSteerings]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[AutoSteerings](
	[AutoSteeringID] [bigint] IDENTITY(1,1) NOT NULL,
	[Steering] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Value] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicSteering] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoSteerings]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[AutoSteerings]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[AutoSteerings]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoSteerings]') AND name = N'PK__AutoStee__9DC23E0FC6C709E8')
ALTER TABLE [dbo].[AutoSteerings] DROP CONSTRAINT [PK__AutoStee__9DC23E0FC6C709E8]
ALTER TABLE [dbo].[AutoSteerings] ADD PRIMARY KEY CLUSTERED 
(
	[AutoSteeringID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutoTransmissionMappings]') AND type in (N'U'))
DROP TABLE [dbo].[AutoTransmissionMappings]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[AutoTransmissionMappings](
	[AutoTransmissionMappingID] [int] IDENTITY(1,1) NOT NULL,
	[AutoTransmissionID] [int] NOT NULL,
	[OpensooqName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HarajName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[AutoTransmission_AutoTransmissionID] [bigint] NULL,
	[LanguageID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoTransmissionMappings]') AND name = N'IX_AutoTransmission_AutoTransmissionID')
DROP INDEX [IX_AutoTransmission_AutoTransmissionID] ON [dbo].[AutoTransmissionMappings]
CREATE NONCLUSTERED INDEX [IX_AutoTransmission_AutoTransmissionID] ON [dbo].[AutoTransmissionMappings]
(
	[AutoTransmission_AutoTransmissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoTransmissionMappings]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[AutoTransmissionMappings]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[AutoTransmissionMappings]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoTransmissionMappings]') AND name = N'PK__AutoTran__C18021E3FF965357')
ALTER TABLE [dbo].[AutoTransmissionMappings] DROP CONSTRAINT [PK__AutoTran__C18021E3FF965357]
ALTER TABLE [dbo].[AutoTransmissionMappings] ADD PRIMARY KEY CLUSTERED 
(
	[AutoTransmissionMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutoTransmissions]') AND type in (N'U'))
DROP TABLE [dbo].[AutoTransmissions]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[AutoTransmissions](
	[AutoTransmissionID] [bigint] IDENTITY(1,1) NOT NULL,
	[Transmission] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Value] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicTransmission] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoTransmissions]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[AutoTransmissions]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[AutoTransmissions]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoTransmissions]') AND name = N'PK__AutoTran__E4D4BA07D43BCB62')
ALTER TABLE [dbo].[AutoTransmissions] DROP CONSTRAINT [PK__AutoTran__E4D4BA07D43BCB62]
ALTER TABLE [dbo].[AutoTransmissions] ADD PRIMARY KEY CLUSTERED 
(
	[AutoTransmissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutoUsedStatus]') AND type in (N'U'))
DROP TABLE [dbo].[AutoUsedStatus]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[AutoUsedStatus](
	[AutoUsedStatusID] [bigint] IDENTITY(1,1) NOT NULL,
	[UsedStatus] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Value] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicUsedStatus] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoUsedStatus]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[AutoUsedStatus]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[AutoUsedStatus]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AutoUsedStatus]') AND name = N'PK__AutoUsed__9E7808AC830A29C1')
ALTER TABLE [dbo].[AutoUsedStatus] DROP CONSTRAINT [PK__AutoUsed__9E7808AC830A29C1]
ALTER TABLE [dbo].[AutoUsedStatus] ADD PRIMARY KEY CLUSTERED 
(
	[AutoUsedStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DriveTypes]') AND type in (N'U'))
DROP TABLE [dbo].[DriveTypes]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[DriveTypes](
	[DriveTypeID] [bigint] IDENTITY(1,1) NOT NULL,
	[DriveTypeV] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Value] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicDriveTypeV] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DriveTypes]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[DriveTypes]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[DriveTypes]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DriveTypes]') AND name = N'PK__DriveTyp__05D279D7454DCEC4')
ALTER TABLE [dbo].[DriveTypes] DROP CONSTRAINT [PK__DriveTyp__05D279D7454DCEC4]
ALTER TABLE [dbo].[DriveTypes] ADD PRIMARY KEY CLUSTERED 
(
	[DriveTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EngineCapacities]') AND type in (N'U'))
DROP TABLE [dbo].[EngineCapacities]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[EngineCapacities](
	[EngineCapacityID] [int] IDENTITY(1,1) NOT NULL,
	[Capacity] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicCapacity] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[EngineCapacities]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[EngineCapacities]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[EngineCapacities]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[EngineCapacities]') AND name = N'PK__EngineCa__508BFE096C2EAF43')
ALTER TABLE [dbo].[EngineCapacities] DROP CONSTRAINT [PK__EngineCa__508BFE096C2EAF43]
ALTER TABLE [dbo].[EngineCapacities] ADD PRIMARY KEY CLUSTERED 
(
	[EngineCapacityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FuelTypes]') AND type in (N'U'))
DROP TABLE [dbo].[FuelTypes]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[FuelTypes](
	[FuelTypeID] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Value] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicType] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FuelTypes]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[FuelTypes]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[FuelTypes]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FuelTypes]') AND name = N'PK__FuelType__048BEE57D2C9E40A')
ALTER TABLE [dbo].[FuelTypes] DROP CONSTRAINT [PK__FuelType__048BEE57D2C9E40A]
ALTER TABLE [dbo].[FuelTypes] ADD PRIMARY KEY CLUSTERED 
(
	[FuelTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InventoryStatus]') AND type in (N'U'))
DROP TABLE [dbo].[InventoryStatus]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[InventoryStatus](
	[InventoryStatusID] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Value] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicStatus] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ArabicDescription] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[InventoryStatus]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[InventoryStatus]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[InventoryStatus]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[InventoryStatus]') AND name = N'PK__Inventor__D2FC6F8227ADEDB9')
ALTER TABLE [dbo].[InventoryStatus] DROP CONSTRAINT [PK__Inventor__D2FC6F8227ADEDB9]
ALTER TABLE [dbo].[InventoryStatus] ADD PRIMARY KEY CLUSTERED 
(
	[InventoryStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Languages]') AND type in (N'U'))
DROP TABLE [dbo].[Languages]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Languages](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Languages]') AND name = N'PK__Language__B938558B316A5952')
ALTER TABLE [dbo].[Languages] DROP CONSTRAINT [PK__Language__B938558B316A5952]
ALTER TABLE [dbo].[Languages] ADD PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MakerMappings]') AND type in (N'U'))
DROP TABLE [dbo].[MakerMappings]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[MakerMappings](
	[MakerMappingID] [int] IDENTITY(1,1) NOT NULL,
	[MakerId] [int] NOT NULL,
	[OpensooqName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HarajName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MakerMappings]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[MakerMappings]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[MakerMappings]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MakerMappings]') AND name = N'IX_MakerId')
DROP INDEX [IX_MakerId] ON [dbo].[MakerMappings]
CREATE NONCLUSTERED INDEX [IX_MakerId] ON [dbo].[MakerMappings]
(
	[MakerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MakerMappings]') AND name = N'PK__MakerMap__1D8A1CB2989BEB6B')
ALTER TABLE [dbo].[MakerMappings] DROP CONSTRAINT [PK__MakerMap__1D8A1CB2989BEB6B]
ALTER TABLE [dbo].[MakerMappings] ADD PRIMARY KEY CLUSTERED 
(
	[MakerMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Makers]') AND type in (N'U'))
DROP TABLE [dbo].[Makers]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Makers](
	[MakerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[VehicleTypeID] [bigint] NULL,
	[ArabicName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Makers]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[Makers]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[Makers]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Makers]') AND name = N'IX_VehicleTypeID')
DROP INDEX [IX_VehicleTypeID] ON [dbo].[Makers]
CREATE NONCLUSTERED INDEX [IX_VehicleTypeID] ON [dbo].[Makers]
(
	[VehicleTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Makers]') AND name = N'PK__Makers__DD7BBCD384C75639')
ALTER TABLE [dbo].[Makers] DROP CONSTRAINT [PK__Makers__DD7BBCD384C75639]
ALTER TABLE [dbo].[Makers] ADD PRIMARY KEY CLUSTERED 
(
	[MakerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MediaPlayers]') AND type in (N'U'))
DROP TABLE [dbo].[MediaPlayers]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[MediaPlayers](
	[MediaPlayerID] [bigint] IDENTITY(1,1) NOT NULL,
	[PlayerName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicPlayerName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MediaPlayers]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[MediaPlayers]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[MediaPlayers]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MediaPlayers]') AND name = N'PK__MediaPla__38D0C00D96D3DA83')
ALTER TABLE [dbo].[MediaPlayers] DROP CONSTRAINT [PK__MediaPla__38D0C00D96D3DA83]
ALTER TABLE [dbo].[MediaPlayers] ADD PRIMARY KEY CLUSTERED 
(
	[MediaPlayerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Milages]') AND type in (N'U'))
DROP TABLE [dbo].[Milages]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Milages](
	[MilageID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Milages]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[Milages]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[Milages]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Milages]') AND name = N'PK__Milages__74C72BB935993AB0')
ALTER TABLE [dbo].[Milages] DROP CONSTRAINT [PK__Milages__74C72BB935993AB0]
ALTER TABLE [dbo].[Milages] ADD PRIMARY KEY CLUSTERED 
(
	[MilageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MotorizedTypes]') AND type in (N'U'))
DROP TABLE [dbo].[MotorizedTypes]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[MotorizedTypes](
	[MotorizedTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Value] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MotorizedTypes]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[MotorizedTypes]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[MotorizedTypes]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MotorizedTypes]') AND name = N'PK__Motorize__61D74078CE42CCEA')
ALTER TABLE [dbo].[MotorizedTypes] DROP CONSTRAINT [PK__Motorize__61D74078CE42CCEA]
ALTER TABLE [dbo].[MotorizedTypes] ADD PRIMARY KEY CLUSTERED 
(
	[MotorizedTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PostingConfigurations]') AND type in (N'U'))
DROP TABLE [dbo].[PostingConfigurations]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[PostingConfigurations](
	[PostingConfigurationID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Value] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PostingConfigurations]') AND name = N'PK__PostingC__48C96466949F7AC8')
ALTER TABLE [dbo].[PostingConfigurations] DROP CONSTRAINT [PK__PostingC__48C96466949F7AC8]
ALTER TABLE [dbo].[PostingConfigurations] ADD PRIMARY KEY CLUSTERED 
(
	[PostingConfigurationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PostingDetails]') AND type in (N'U'))
DROP TABLE [dbo].[PostingDetails]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[PostingDetails](
	[PostingDetailID] [int] IDENTITY(1,1) NOT NULL,
	[PostingTitle] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PostingDescription] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[VehicleWizardId] [bigint] NOT NULL,
	[VehicleWizard_VehicleID] [bigint] NULL,
	[LanguageID] [int] NULL,
	[PublishPrice] [bit] NOT NULL DEFAULT ((0)),
	[Negotiable] [bit] NOT NULL DEFAULT ((0)),
	[PostingStatusID] [int] NOT NULL DEFAULT ((0)),
	[PostingSiteID] [int] NOT NULL DEFAULT ((0)),
	[PostingSiteUser_PostingSiteUserID] [int] NULL,
	[Retries] [int] NOT NULL DEFAULT ((0)),
	[RetryCount] [int] NOT NULL DEFAULT ((0)),
	[PostingError] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PostingDetails]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[PostingDetails]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[PostingDetails]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PostingDetails]') AND name = N'IX_PostingSiteID')
DROP INDEX [IX_PostingSiteID] ON [dbo].[PostingDetails]
CREATE NONCLUSTERED INDEX [IX_PostingSiteID] ON [dbo].[PostingDetails]
(
	[PostingSiteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PostingDetails]') AND name = N'IX_PostingSiteUser_PostingSiteUserID')
DROP INDEX [IX_PostingSiteUser_PostingSiteUserID] ON [dbo].[PostingDetails]
CREATE NONCLUSTERED INDEX [IX_PostingSiteUser_PostingSiteUserID] ON [dbo].[PostingDetails]
(
	[PostingSiteUser_PostingSiteUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PostingDetails]') AND name = N'IX_PostingStatusID')
DROP INDEX [IX_PostingStatusID] ON [dbo].[PostingDetails]
CREATE NONCLUSTERED INDEX [IX_PostingStatusID] ON [dbo].[PostingDetails]
(
	[PostingStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PostingDetails]') AND name = N'IX_VehicleWizard_VehicleID')
DROP INDEX [IX_VehicleWizard_VehicleID] ON [dbo].[PostingDetails]
CREATE NONCLUSTERED INDEX [IX_VehicleWizard_VehicleID] ON [dbo].[PostingDetails]
(
	[VehicleWizard_VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PostingDetails]') AND name = N'PK__PostingD__E6311E3D3F43D97A')
ALTER TABLE [dbo].[PostingDetails] DROP CONSTRAINT [PK__PostingD__E6311E3D3F43D97A]
ALTER TABLE [dbo].[PostingDetails] ADD PRIMARY KEY CLUSTERED 
(
	[PostingDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PostingFields]') AND type in (N'U'))
DROP TABLE [dbo].[PostingFields]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[PostingFields](
	[PostingFieldID] [int] IDENTITY(1,1) NOT NULL,
	[PostingSiteID] [int] NOT NULL,
	[FieldName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LinkedFieldName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DisplayName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IncludeInPosting] [bit] NOT NULL,
	[IncludeOrder] [int] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[ArabicFieldName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ArabicLinkedFieldName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ArabicDisplayName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PostingFields]') AND name = N'IX_PostingSiteID')
DROP INDEX [IX_PostingSiteID] ON [dbo].[PostingFields]
CREATE NONCLUSTERED INDEX [IX_PostingSiteID] ON [dbo].[PostingFields]
(
	[PostingSiteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PostingFields]') AND name = N'PK__PostingF__C38CF5DF4EAF2AE2')
ALTER TABLE [dbo].[PostingFields] DROP CONSTRAINT [PK__PostingF__C38CF5DF4EAF2AE2]
ALTER TABLE [dbo].[PostingFields] ADD PRIMARY KEY CLUSTERED 
(
	[PostingFieldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PostingSites]') AND type in (N'U'))
DROP TABLE [dbo].[PostingSites]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[PostingSites](
	[PostingSiteID] [int] IDENTITY(1,1) NOT NULL,
	[PostingSiteName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PostingSites]') AND name = N'PK__PostingS__AD8EFB90E1387D65')
ALTER TABLE [dbo].[PostingSites] DROP CONSTRAINT [PK__PostingS__AD8EFB90E1387D65]
ALTER TABLE [dbo].[PostingSites] ADD PRIMARY KEY CLUSTERED 
(
	[PostingSiteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PostingSiteUsers]') AND type in (N'U'))
DROP TABLE [dbo].[PostingSiteUsers]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[PostingSiteUsers](
	[PostingSiteUserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UserPassword] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Phonenumber] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PostingSiteID] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PostingSiteUsers]') AND name = N'IX_PostingSiteID')
DROP INDEX [IX_PostingSiteID] ON [dbo].[PostingSiteUsers]
CREATE NONCLUSTERED INDEX [IX_PostingSiteID] ON [dbo].[PostingSiteUsers]
(
	[PostingSiteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PostingSiteUsers]') AND name = N'PK__PostingS__EDB49224B6CD2A10')
ALTER TABLE [dbo].[PostingSiteUsers] DROP CONSTRAINT [PK__PostingS__EDB49224B6CD2A10]
ALTER TABLE [dbo].[PostingSiteUsers] ADD PRIMARY KEY CLUSTERED 
(
	[PostingSiteUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PostingStatus]') AND type in (N'U'))
DROP TABLE [dbo].[PostingStatus]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[PostingStatus](
	[PostingStatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PostingStatus]') AND name = N'PK__PostingS__51FF37A819F4ACDD')
ALTER TABLE [dbo].[PostingStatus] DROP CONSTRAINT [PK__PostingS__51FF37A819F4ACDD]
ALTER TABLE [dbo].[PostingStatus] ADD PRIMARY KEY CLUSTERED 
(
	[PostingStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoofTypes]') AND type in (N'U'))
DROP TABLE [dbo].[RoofTypes]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[RoofTypes](
	[RoofTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicType] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[RoofTypes]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[RoofTypes]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[RoofTypes]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[RoofTypes]') AND name = N'PK__RoofType__81723EE704585F66')
ALTER TABLE [dbo].[RoofTypes] DROP CONSTRAINT [PK__RoofType__81723EE704585F66]
ALTER TABLE [dbo].[RoofTypes] ADD PRIMARY KEY CLUSTERED 
(
	[RoofTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubModelMappings]') AND type in (N'U'))
DROP TABLE [dbo].[SubModelMappings]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[SubModelMappings](
	[SubModelMappingID] [int] IDENTITY(1,1) NOT NULL,
	[SubModelID] [int] NOT NULL,
	[OpensooqName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HarajName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SubModelMappings]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[SubModelMappings]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[SubModelMappings]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SubModelMappings]') AND name = N'IX_SubModelID')
DROP INDEX [IX_SubModelID] ON [dbo].[SubModelMappings]
CREATE NONCLUSTERED INDEX [IX_SubModelID] ON [dbo].[SubModelMappings]
(
	[SubModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SubModelMappings]') AND name = N'PK__SubModel__FB2E9B89B88AD112')
ALTER TABLE [dbo].[SubModelMappings] DROP CONSTRAINT [PK__SubModel__FB2E9B89B88AD112]
ALTER TABLE [dbo].[SubModelMappings] ADD PRIMARY KEY CLUSTERED 
(
	[SubModelMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubModels]') AND type in (N'U'))
DROP TABLE [dbo].[SubModels]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[SubModels](
	[SubModelID] [int] IDENTITY(1,1) NOT NULL,
	[ModelName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[AutoModelID] [int] NULL,
	[LanguageID] [int] NULL,
	[ArabicModelName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SubModels]') AND name = N'IX_AutoModelID')
DROP INDEX [IX_AutoModelID] ON [dbo].[SubModels]
CREATE NONCLUSTERED INDEX [IX_AutoModelID] ON [dbo].[SubModels]
(
	[AutoModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SubModels]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[SubModels]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[SubModels]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SubModels]') AND name = N'PK__SubModel__DCFCD0E023052D24')
ALTER TABLE [dbo].[SubModels] DROP CONSTRAINT [PK__SubModel__DCFCD0E023052D24]
ALTER TABLE [dbo].[SubModels] ADD PRIMARY KEY CLUSTERED 
(
	[SubModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sysdiagrams]') AND type in (N'U'))
DROP TABLE [dbo].[sysdiagrams]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[sysdiagrams]') AND name = N'PK__sysdiagr__C2B05B61752E9B83')
ALTER TABLE [dbo].[sysdiagrams] DROP CONSTRAINT [PK__sysdiagr__C2B05B61752E9B83]
ALTER TABLE [dbo].[sysdiagrams] ADD PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[sysdiagrams]') AND name = N'UQ__sysdiagr__532EC1545F7D6111')
ALTER TABLE [dbo].[sysdiagrams] DROP CONSTRAINT [UQ__sysdiagr__532EC1545F7D6111]
SET ANSI_PADDING ON

ALTER TABLE [dbo].[sysdiagrams] ADD UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Upholsteries]') AND type in (N'U'))
DROP TABLE [dbo].[Upholsteries]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Upholsteries](
	[UpholsteryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Upholsteries]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[Upholsteries]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[Upholsteries]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Upholsteries]') AND name = N'PK__Upholste__8AA5407D95800385')
ALTER TABLE [dbo].[Upholsteries] DROP CONSTRAINT [PK__Upholste__8AA5407D95800385]
ALTER TABLE [dbo].[Upholsteries] ADD PRIMARY KEY CLUSTERED 
(
	[UpholsteryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoles]') AND type in (N'U'))
DROP TABLE [dbo].[UserRoles]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[UserRoles](
	[UserRoleID] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicRole] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[UserRoles]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[UserRoles]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[UserRoles]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[UserRoles]') AND name = N'PK__UserRole__3D978A55F3074297')
ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [PK__UserRole__3D978A55F3074297]
ALTER TABLE [dbo].[UserRoles] ADD PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Users](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FirstName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Password] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[PasswordToken] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LinkExpiryDate] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[UserRoleID] [int] NULL,
	[LanguageID] [int] NULL,
	[ArabicFirstName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ArabicLastName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[Users]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[Users]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND name = N'IX_UserRoleID')
DROP INDEX [IX_UserRoleID] ON [dbo].[Users]
CREATE NONCLUSTERED INDEX [IX_UserRoleID] ON [dbo].[Users]
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND name = N'PK__Users__1788CCAC03C6BBD2')
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [PK__Users__1788CCAC03C6BBD2]
ALTER TABLE [dbo].[Users] ADD PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehclieTitles]') AND type in (N'U'))
DROP TABLE [dbo].[VehclieTitles]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VehclieTitles](
	[VehicleTitleID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicTitle] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ArabicDescription] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehclieTitles]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[VehclieTitles]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[VehclieTitles]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehclieTitles]') AND name = N'PK__VehclieT__A3B169674495B04A')
ALTER TABLE [dbo].[VehclieTitles] DROP CONSTRAINT [PK__VehclieT__A3B169674495B04A]
ALTER TABLE [dbo].[VehclieTitles] ADD PRIMARY KEY CLUSTERED 
(
	[VehicleTitleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleAddresses]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleAddresses]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VehicleAddresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PhysicalAddress] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GoogleAddress] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ArabicName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ArabicPhysicalAddress] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleAddresses]') AND name = N'PK__VehicleA__3214EC07FC2E11A7')
ALTER TABLE [dbo].[VehicleAddresses] DROP CONSTRAINT [PK__VehicleA__3214EC07FC2E11A7]
ALTER TABLE [dbo].[VehicleAddresses] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleAudios]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleAudios]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VehicleAudios](
	[AudioID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[ArabicType] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleAudios]') AND name = N'PK__VehicleA__A28A94B0174C49E9')
ALTER TABLE [dbo].[VehicleAudios] DROP CONSTRAINT [PK__VehicleA__A28A94B0174C49E9]
ALTER TABLE [dbo].[VehicleAudios] ADD PRIMARY KEY CLUSTERED 
(
	[AudioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleImages]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleImages]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VehicleImages](
	[VehicleImageID] [bigint] IDENTITY(1,1) NOT NULL,
	[ImagePath] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[VehicleID] [bigint] NOT NULL,
	[DisplayOrder] [int] NULL,
	[LanguageID] [int] NULL,
	[IsFeatured] [int] NULL,
	[ExternalURL] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleImages]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[VehicleImages]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[VehicleImages]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleImages]') AND name = N'IX_VehicleID')
DROP INDEX [IX_VehicleID] ON [dbo].[VehicleImages]
CREATE NONCLUSTERED INDEX [IX_VehicleID] ON [dbo].[VehicleImages]
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleImages]') AND name = N'PK__VehicleI__BDB4640AE6ADBDC0')
ALTER TABLE [dbo].[VehicleImages] DROP CONSTRAINT [PK__VehicleI__BDB4640AE6ADBDC0]
ALTER TABLE [dbo].[VehicleImages] ADD PRIMARY KEY CLUSTERED 
(
	[VehicleImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleInteriorTypes]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleInteriorTypes]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VehicleInteriorTypes](
	[InteriorTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[ArabicType] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleInteriorTypes]') AND name = N'PK__VehicleI__F6F90E62D072A468')
ALTER TABLE [dbo].[VehicleInteriorTypes] DROP CONSTRAINT [PK__VehicleI__F6F90E62D072A468]
ALTER TABLE [dbo].[VehicleInteriorTypes] ADD PRIMARY KEY CLUSTERED 
(
	[InteriorTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehiclePartImages]') AND type in (N'U'))
DROP TABLE [dbo].[VehiclePartImages]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VehiclePartImages](
	[VehiclePartImageID] [bigint] IDENTITY(1,1) NOT NULL,
	[ImagePath] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[VehicleID] [bigint] NOT NULL,
	[VIRID] [int] NOT NULL,
	[LanguageID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehiclePartImages]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[VehiclePartImages]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[VehiclePartImages]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehiclePartImages]') AND name = N'IX_VehicleID')
DROP INDEX [IX_VehicleID] ON [dbo].[VehiclePartImages]
CREATE NONCLUSTERED INDEX [IX_VehicleID] ON [dbo].[VehiclePartImages]
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehiclePartImages]') AND name = N'IX_VIRID')
DROP INDEX [IX_VIRID] ON [dbo].[VehiclePartImages]
CREATE NONCLUSTERED INDEX [IX_VIRID] ON [dbo].[VehiclePartImages]
(
	[VIRID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehiclePartImages]') AND name = N'PK__VehicleP__E013970F3A0C24C4')
ALTER TABLE [dbo].[VehiclePartImages] DROP CONSTRAINT [PK__VehicleP__E013970F3A0C24C4]
ALTER TABLE [dbo].[VehiclePartImages] ADD PRIMARY KEY CLUSTERED 
(
	[VehiclePartImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehiclePrices]') AND type in (N'U'))
DROP TABLE [dbo].[VehiclePrices]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VehiclePrices](
	[VehiclePriceID] [int] IDENTITY(1,1) NOT NULL,
	[CurrentPrice] [decimal](18, 2) NOT NULL,
	[MonthlyPayment] [decimal](18, 2) NOT NULL,
	[ByNowWholeSalePrice] [decimal](18, 2) NOT NULL,
	[ConsignedPrice] [decimal](18, 2) NOT NULL,
	[SaleCost] [decimal](18, 2) NOT NULL,
	[MSRP] [decimal](18, 2) NOT NULL,
	[BookValue] [decimal](18, 2) NOT NULL,
	[InternetPrice] [decimal](18, 2) NOT NULL,
	[AlternativePrice1] [decimal](18, 2) NOT NULL,
	[AlternativePrice2] [decimal](18, 2) NOT NULL,
	[AlternativePrice3] [decimal](18, 2) NOT NULL,
	[PriceVehicleID] [bigint] NOT NULL,
	[VehicleID] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[VehicleWizard_VehicleID] [bigint] NULL,
	[LanguageID] [int] NULL
) ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehiclePrices]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[VehiclePrices]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[VehiclePrices]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehiclePrices]') AND name = N'IX_VehicleWizard_VehicleID')
DROP INDEX [IX_VehicleWizard_VehicleID] ON [dbo].[VehiclePrices]
CREATE NONCLUSTERED INDEX [IX_VehicleWizard_VehicleID] ON [dbo].[VehiclePrices]
(
	[VehicleWizard_VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehiclePrices]') AND name = N'PK__VehicleP__CBE8700671E61A02')
ALTER TABLE [dbo].[VehiclePrices] DROP CONSTRAINT [PK__VehicleP__CBE8700671E61A02]
ALTER TABLE [dbo].[VehiclePrices] ADD PRIMARY KEY CLUSTERED 
(
	[VehiclePriceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleTemplates]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleTemplates]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VehicleTemplates](
	[VehicleTemplateID] [int] IDENTITY(1,1) NOT NULL,
	[TemplateName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicTemplateName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleTemplates]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[VehicleTemplates]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[VehicleTemplates]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleTemplates]') AND name = N'PK__VehicleT__D103CD4C0E457069')
ALTER TABLE [dbo].[VehicleTemplates] DROP CONSTRAINT [PK__VehicleT__D103CD4C0E457069]
ALTER TABLE [dbo].[VehicleTemplates] ADD PRIMARY KEY CLUSTERED 
(
	[VehicleTemplateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleTitleMappings]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleTitleMappings]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VehicleTitleMappings](
	[VehicleTitleMappingID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleTitleID] [int] NOT NULL,
	[OpensooqName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HarajName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleTitleMappings]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[VehicleTitleMappings]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[VehicleTitleMappings]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleTitleMappings]') AND name = N'IX_VehicleTitleID')
DROP INDEX [IX_VehicleTitleID] ON [dbo].[VehicleTitleMappings]
CREATE NONCLUSTERED INDEX [IX_VehicleTitleID] ON [dbo].[VehicleTitleMappings]
(
	[VehicleTitleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleTitleMappings]') AND name = N'PK__VehicleT__FC422A80456B6ECE')
ALTER TABLE [dbo].[VehicleTitleMappings] DROP CONSTRAINT [PK__VehicleT__FC422A80456B6ECE]
ALTER TABLE [dbo].[VehicleTitleMappings] ADD PRIMARY KEY CLUSTERED 
(
	[VehicleTitleMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleTopStyles]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleTopStyles]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VehicleTopStyles](
	[TopStyleID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[ArabicType] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleTopStyles]') AND name = N'PK__VehicleT__8F2DCC6350F46FCA')
ALTER TABLE [dbo].[VehicleTopStyles] DROP CONSTRAINT [PK__VehicleT__8F2DCC6350F46FCA]
ALTER TABLE [dbo].[VehicleTopStyles] ADD PRIMARY KEY CLUSTERED 
(
	[TopStyleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleTrims]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleTrims]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VehicleTrims](
	[VehicleTrimID] [int] IDENTITY(1,1) NOT NULL,
	[Trim] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleTrims]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[VehicleTrims]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[VehicleTrims]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleTrims]') AND name = N'PK__VehicleT__33B3B35DE5377D7A')
ALTER TABLE [dbo].[VehicleTrims] DROP CONSTRAINT [PK__VehicleT__33B3B35DE5377D7A]
ALTER TABLE [dbo].[VehicleTrims] ADD PRIMARY KEY CLUSTERED 
(
	[VehicleTrimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleTypes]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleTypes]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VehicleTypes](
	[VehicleTypeID] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VehicleTypeValue] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicType] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleTypes]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[VehicleTypes]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[VehicleTypes]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleTypes]') AND name = N'PK__VehicleT__9F4496236C75FEAE')
ALTER TABLE [dbo].[VehicleTypes] DROP CONSTRAINT [PK__VehicleT__9F4496236C75FEAE]
ALTER TABLE [dbo].[VehicleTypes] ADD PRIMARY KEY CLUSTERED 
(
	[VehicleTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleVideos]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleVideos]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VehicleVideos](
	[VehicleVideoID] [bigint] IDENTITY(1,1) NOT NULL,
	[VideoPath] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DisplayOrder] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[VehicleID] [bigint] NOT NULL,
	[LanguageID] [int] NULL,
	[IsFeatured] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleVideos]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[VehicleVideos]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[VehicleVideos]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleVideos]') AND name = N'IX_VehicleID')
DROP INDEX [IX_VehicleID] ON [dbo].[VehicleVideos]
CREATE NONCLUSTERED INDEX [IX_VehicleID] ON [dbo].[VehicleVideos]
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleVideos]') AND name = N'PK__VehicleV__7F5F2B1087E3D73C')
ALTER TABLE [dbo].[VehicleVideos] DROP CONSTRAINT [PK__VehicleV__7F5F2B1087E3D73C]
ALTER TABLE [dbo].[VehicleVideos] ADD PRIMARY KEY CLUSTERED 
(
	[VehicleVideoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWheels]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleWheels]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VehicleWheels](
	[WheelID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[ArabicType] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWheels]') AND name = N'PK__VehicleW__F2D0AD212BA4B2B2')
ALTER TABLE [dbo].[VehicleWheels] DROP CONSTRAINT [PK__VehicleW__F2D0AD212BA4B2B2]
ALTER TABLE [dbo].[VehicleWheels] ADD PRIMARY KEY CLUSTERED 
(
	[WheelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleWizards]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VehicleWizards](
	[VehicleID] [bigint] IDENTITY(1,1) NOT NULL,
	[InventoryStatusID] [int] NULL,
	[StockNumber] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MMCode] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PlateNumber] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AutoConditionID] [int] NULL,
	[VIN] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[YearID] [int] NULL,
	[MakerID] [int] NULL,
	[AutoModelID] [int] NULL,
	[SubModelID] [int] NULL,
	[FreeText] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AutoBodyStyleID] [int] NULL,
	[Odometer] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AutoExteriorColorID] [bigint] NULL,
	[AutoInteriorColorID] [bigint] NULL,
	[AutoSteeringID] [bigint] NULL,
	[AutoDoorsID] [bigint] NULL,
	[AutoEngineID] [bigint] NULL,
	[AutoTransmissionID] [bigint] NULL,
	[FuelTypeID] [bigint] NULL,
	[DriveTypeID] [bigint] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[VehiclePrice] [decimal](18, 2) NULL,
	[WarantyText] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UserID] [bigint] NOT NULL,
	[AutoAirBagID] [int] NULL,
	[EngineCapacityID] [int] NULL,
	[UpholsteryID] [int] NULL,
	[RoofTypeID] [int] NULL,
	[VehicleTitleID] [int] NULL,
	[VehicleTypeID] [bigint] NULL,
	[VehicleAudioID] [int] NULL,
	[VehicleInteriorTypeID] [int] NULL,
	[VehicleTopStyleID] [int] NULL,
	[VehicleWheelID] [int] NULL,
	[MediaPlayerID] [bigint] NULL,
	[VehicleOptions] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VehicleMoreOptions] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VehicleFlags] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VehiclemoreFlags] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VehicleAddressId] [int] NULL,
	[ExteriorRatting] [float] NULL,
	[InteriorRatting] [float] NULL,
	[MechanicsRatting] [float] NULL,
	[FrameRatting] [float] NULL,
	[TotalRatting] [float] NULL,
	[VIRCompletenessPercentage] [float] NULL,
	[IsDeleted] [bit] NULL DEFAULT ((0)),
	[LanguageID] [int] NULL,
	[MotorizedType_MotorizedTypeID] [int] NULL,
	[IsFeatured] [bit] NULL,
	[VehicleTrim_VehicleTrimID] [int] NULL,
	[PurchasingCost] [decimal](18, 2) NULL,
	[Has360] [bit] NULL,
	[Branch] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Location] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Milage_MilageID] [int] NULL,
	[AutoUsedStatusID] [bigint] NULL,
	[MilageValue] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ArabicWarantyText] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ArabicDescription] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ArabicFreeText] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ArabicVehicleMoreOptions] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ArabicVehicleMoreFlags] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EvaluatorExteriorRatting] [float] NULL,
	[EvaluatorInteriorRatting] [float] NULL,
	[EvaluatorMechanicsRatting] [float] NULL,
	[EvaluatorFrameRatting] [float] NULL,
	[EvaluatorTotalRatting] [float] NULL,
	[HasDealerImages] [bit] NOT NULL,
	[IsFacebook] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_AutoAirBagID')
DROP INDEX [IX_AutoAirBagID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_AutoAirBagID] ON [dbo].[VehicleWizards]
(
	[AutoAirBagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_AutoBodyStyleID')
DROP INDEX [IX_AutoBodyStyleID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_AutoBodyStyleID] ON [dbo].[VehicleWizards]
(
	[AutoBodyStyleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_AutoConditionID')
DROP INDEX [IX_AutoConditionID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_AutoConditionID] ON [dbo].[VehicleWizards]
(
	[AutoConditionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_AutoDoorsID')
DROP INDEX [IX_AutoDoorsID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_AutoDoorsID] ON [dbo].[VehicleWizards]
(
	[AutoDoorsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_AutoEngineID')
DROP INDEX [IX_AutoEngineID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_AutoEngineID] ON [dbo].[VehicleWizards]
(
	[AutoEngineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_AutoExteriorColorID')
DROP INDEX [IX_AutoExteriorColorID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_AutoExteriorColorID] ON [dbo].[VehicleWizards]
(
	[AutoExteriorColorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_AutoInteriorColorID')
DROP INDEX [IX_AutoInteriorColorID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_AutoInteriorColorID] ON [dbo].[VehicleWizards]
(
	[AutoInteriorColorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_AutoModelID')
DROP INDEX [IX_AutoModelID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_AutoModelID] ON [dbo].[VehicleWizards]
(
	[AutoModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_AutoSteeringID')
DROP INDEX [IX_AutoSteeringID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_AutoSteeringID] ON [dbo].[VehicleWizards]
(
	[AutoSteeringID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_AutoTransmissionID')
DROP INDEX [IX_AutoTransmissionID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_AutoTransmissionID] ON [dbo].[VehicleWizards]
(
	[AutoTransmissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_AutoUsedStatusID')
DROP INDEX [IX_AutoUsedStatusID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_AutoUsedStatusID] ON [dbo].[VehicleWizards]
(
	[AutoUsedStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_DriveTypeID')
DROP INDEX [IX_DriveTypeID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_DriveTypeID] ON [dbo].[VehicleWizards]
(
	[DriveTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_EngineCapacityID')
DROP INDEX [IX_EngineCapacityID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_EngineCapacityID] ON [dbo].[VehicleWizards]
(
	[EngineCapacityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_FuelTypeID')
DROP INDEX [IX_FuelTypeID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_FuelTypeID] ON [dbo].[VehicleWizards]
(
	[FuelTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_InventoryStatusID')
DROP INDEX [IX_InventoryStatusID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_InventoryStatusID] ON [dbo].[VehicleWizards]
(
	[InventoryStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[VehicleWizards]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_MakerID')
DROP INDEX [IX_MakerID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_MakerID] ON [dbo].[VehicleWizards]
(
	[MakerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_MediaPlayerID')
DROP INDEX [IX_MediaPlayerID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_MediaPlayerID] ON [dbo].[VehicleWizards]
(
	[MediaPlayerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_Milage_MilageID')
DROP INDEX [IX_Milage_MilageID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_Milage_MilageID] ON [dbo].[VehicleWizards]
(
	[Milage_MilageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_MotorizedType_MotorizedTypeID')
DROP INDEX [IX_MotorizedType_MotorizedTypeID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_MotorizedType_MotorizedTypeID] ON [dbo].[VehicleWizards]
(
	[MotorizedType_MotorizedTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_RoofTypeID')
DROP INDEX [IX_RoofTypeID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_RoofTypeID] ON [dbo].[VehicleWizards]
(
	[RoofTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_SubModelID')
DROP INDEX [IX_SubModelID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_SubModelID] ON [dbo].[VehicleWizards]
(
	[SubModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_UpholsteryID')
DROP INDEX [IX_UpholsteryID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_UpholsteryID] ON [dbo].[VehicleWizards]
(
	[UpholsteryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_UserID')
DROP INDEX [IX_UserID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_UserID] ON [dbo].[VehicleWizards]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_VehicleAddressId')
DROP INDEX [IX_VehicleAddressId] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_VehicleAddressId] ON [dbo].[VehicleWizards]
(
	[VehicleAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_VehicleAudioID')
DROP INDEX [IX_VehicleAudioID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_VehicleAudioID] ON [dbo].[VehicleWizards]
(
	[VehicleAudioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_VehicleInteriorTypeID')
DROP INDEX [IX_VehicleInteriorTypeID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_VehicleInteriorTypeID] ON [dbo].[VehicleWizards]
(
	[VehicleInteriorTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_VehicleTitleID')
DROP INDEX [IX_VehicleTitleID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_VehicleTitleID] ON [dbo].[VehicleWizards]
(
	[VehicleTitleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_VehicleTopStyleID')
DROP INDEX [IX_VehicleTopStyleID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_VehicleTopStyleID] ON [dbo].[VehicleWizards]
(
	[VehicleTopStyleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_VehicleTrim_VehicleTrimID')
DROP INDEX [IX_VehicleTrim_VehicleTrimID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_VehicleTrim_VehicleTrimID] ON [dbo].[VehicleWizards]
(
	[VehicleTrim_VehicleTrimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_VehicleTypeID')
DROP INDEX [IX_VehicleTypeID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_VehicleTypeID] ON [dbo].[VehicleWizards]
(
	[VehicleTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_VehicleWheelID')
DROP INDEX [IX_VehicleWheelID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_VehicleWheelID] ON [dbo].[VehicleWizards]
(
	[VehicleWheelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'IX_YearID')
DROP INDEX [IX_YearID] ON [dbo].[VehicleWizards]
CREATE NONCLUSTERED INDEX [IX_YearID] ON [dbo].[VehicleWizards]
(
	[YearID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VehicleWizards]') AND name = N'PK__VehicleW__476B54B214E4F0CE')
ALTER TABLE [dbo].[VehicleWizards] DROP CONSTRAINT [PK__VehicleW__476B54B214E4F0CE]
ALTER TABLE [dbo].[VehicleWizards] ADD PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VIRFlagProperties]') AND type in (N'U'))
DROP TABLE [dbo].[VIRFlagProperties]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VIRFlagProperties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VIRFlagProperties]') AND name = N'PK__VIRFlagP__3214EC07899777EA')
ALTER TABLE [dbo].[VIRFlagProperties] DROP CONSTRAINT [PK__VIRFlagP__3214EC07899777EA]
ALTER TABLE [dbo].[VIRFlagProperties] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VIROptionProperties]') AND type in (N'U'))
DROP TABLE [dbo].[VIROptionProperties]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VIROptionProperties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Name] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VIROptionProperties]') AND name = N'PK__VIROptio__3214EC072AE2F367')
ALTER TABLE [dbo].[VIROptionProperties] DROP CONSTRAINT [PK__VIROptio__3214EC072AE2F367]
ALTER TABLE [dbo].[VIROptionProperties] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VIRPartConditionSeverityLevels]') AND type in (N'U'))
DROP TABLE [dbo].[VIRPartConditionSeverityLevels]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VIRPartConditionSeverityLevels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SeverityLevels] [float] NOT NULL,
	[VIRPartID] [int] NOT NULL,
	[ArabicName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VIRPartConditionSeverityLevels]') AND name = N'IX_VIRPartID')
DROP INDEX [IX_VIRPartID] ON [dbo].[VIRPartConditionSeverityLevels]
CREATE NONCLUSTERED INDEX [IX_VIRPartID] ON [dbo].[VIRPartConditionSeverityLevels]
(
	[VIRPartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VIRPartConditionSeverityLevels]') AND name = N'PK__VIRPartC__3214EC07A4D28930')
ALTER TABLE [dbo].[VIRPartConditionSeverityLevels] DROP CONSTRAINT [PK__VIRPartC__3214EC07A4D28930]
ALTER TABLE [dbo].[VIRPartConditionSeverityLevels] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VIRParts]') AND type in (N'U'))
DROP TABLE [dbo].[VIRParts]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VIRParts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VIRPartsType] [int] NOT NULL,
	[ArabicName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VIRParts]') AND name = N'PK__VIRParts__3214EC078C50D7B5')
ALTER TABLE [dbo].[VIRParts] DROP CONSTRAINT [PK__VIRParts__3214EC078C50D7B5]
ALTER TABLE [dbo].[VIRParts] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VIRs]') AND type in (N'U'))
DROP TABLE [dbo].[VIRs]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[VIRs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[fkVehickeId] [int] NOT NULL,
	[fkUserId] [int] NOT NULL,
	[fkPartId] [int] NOT NULL,
	[Condition] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Part] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Severity] [float] NOT NULL,
	[Description] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CostOfRepair] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CostOfReplacement] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EstimatedRepairCost] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Ratting] [float] NOT NULL,
	[ArabicCondition] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ArabicPart] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ArabicDescription] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[VIRs]') AND name = N'PK__VIRs__3214EC070CA8D56D')
ALTER TABLE [dbo].[VIRs] DROP CONSTRAINT [PK__VIRs__3214EC070CA8D56D]
ALTER TABLE [dbo].[VIRs] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Years]') AND type in (N'U'))
DROP TABLE [dbo].[Years]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Years](
	[YearID] [int] IDENTITY(1,1) NOT NULL,
	[YearName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Value] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[LanguageID] [int] NULL,
	[ArabicYearName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Years]') AND name = N'IX_LanguageID')
DROP INDEX [IX_LanguageID] ON [dbo].[Years]
CREATE NONCLUSTERED INDEX [IX_LanguageID] ON [dbo].[Years]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Years]') AND name = N'PK__Years__C33A18AD5194A41E')
ALTER TABLE [dbo].[Years] DROP CONSTRAINT [PK__Years__C33A18AD5194A41E]
ALTER TABLE [dbo].[Years] ADD PRIMARY KEY CLUSTERED 
(
	[YearID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
