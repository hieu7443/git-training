USE [master]
GO
/****** Object:  Database [Demo]    Script Date: 8/15/2018 5:50:14 PM ******/
CREATE DATABASE [Demo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Demo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Demo.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Demo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Demo_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Demo] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Demo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Demo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Demo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Demo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Demo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Demo] SET ARITHABORT OFF 
GO
ALTER DATABASE [Demo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Demo] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Demo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Demo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Demo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Demo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Demo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Demo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Demo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Demo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Demo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Demo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Demo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Demo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Demo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Demo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Demo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Demo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Demo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Demo] SET  MULTI_USER 
GO
ALTER DATABASE [Demo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Demo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Demo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Demo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Demo]
GO
/****** Object:  Table [dbo].[Fields]    Script Date: 8/15/2018 5:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fields](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[TemplateID] [uniqueidentifier] NOT NULL,
	[Type] [nvarchar](255) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_Fields] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ItemRenderings]    Script Date: 8/15/2018 5:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemRenderings](
	[ID] [uniqueidentifier] NOT NULL,
	[RenderingID] [uniqueidentifier] NOT NULL,
	[PresentationID] [uniqueidentifier] NOT NULL,
	[SourceID] [uniqueidentifier] NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Placeholder] [nvarchar](255) NOT NULL,
	[Index] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_ItemRenderings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Items]    Script Date: 8/15/2018 5:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[TemplateID] [uniqueidentifier] NOT NULL,
	[ParentID] [uniqueidentifier] NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Layouts]    Script Date: 8/15/2018 5:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Layouts](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Source] [nvarchar](255) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_Layouts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Links]    Script Date: 8/15/2018 5:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Links](
	[ID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[Url] [nvarchar](255) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_Links] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Presentations]    Script Date: 8/15/2018 5:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presentations](
	[ID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[LayoutID] [uniqueidentifier] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_Presentations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Properties]    Script Date: 8/15/2018 5:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Properties](
	[ID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[FieldID] [uniqueidentifier] NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[Language] [nvarchar](10) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_Properties] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Renderings]    Script Date: 8/15/2018 5:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Renderings](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Assembly] [nvarchar](255) NOT NULL,
	[Controller] [nvarchar](255) NOT NULL,
	[Action] [nvarchar](255) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_Renderings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Templates]    Script Date: 8/15/2018 5:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Templates](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_Templates] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ItemRenderings] ([ID], [RenderingID], [PresentationID], [SourceID], [Name], [Placeholder], [Index], [Created], [Updated]) VALUES (N'bcb24773-1145-4c44-9188-004209b439a3', N'c644f8d5-990e-4541-95d2-5843649a7791', N'e501195a-4b61-4eaf-9cd5-b29484f671b7', NULL, N'Custom Feature', N'main', 0, CAST(0x0000A93C00000000 AS DateTime), CAST(0x0000A93C00000000 AS DateTime))
INSERT [dbo].[ItemRenderings] ([ID], [RenderingID], [PresentationID], [SourceID], [Name], [Placeholder], [Index], [Created], [Updated]) VALUES (N'b8f25352-1198-42e3-ac1e-7d505eb4f382', N'c644f8d5-990e-4541-95d2-5843649a7791', N'e501195a-4b61-4eaf-9cd5-b29484f671b7', NULL, N'Custom Feature', N'main-2', 0, CAST(0x0000A93C00000000 AS DateTime), CAST(0x0000A93C00000000 AS DateTime))
INSERT [dbo].[Items] ([ID], [Name], [TemplateID], [ParentID], [Created], [Updated]) VALUES (N'29e3738b-4a47-49dc-9fb6-cfda1252d553', N'Home', N'7f207232-df9e-4a5b-ae27-d9d96e061819', NULL, CAST(0x0000A93C00000000 AS DateTime), CAST(0x0000A93C00000000 AS DateTime))
INSERT [dbo].[Layouts] ([ID], [Name], [Source], [Created], [Updated]) VALUES (N'24f0e167-4fc5-45e4-b837-eecbb7872498', N'Main layout', N'/Views/Shared/_Layout.cshtml', CAST(0x0000A93C00000000 AS DateTime), CAST(0x0000A93C00000000 AS DateTime))
INSERT [dbo].[Links] ([ID], [ItemID], [Url], [Created], [Updated]) VALUES (N'c0ec8ea6-0e0d-4418-89c5-f81a78162db4', N'29e3738b-4a47-49dc-9fb6-cfda1252d553', N'/', CAST(0x0000A93C00000000 AS DateTime), CAST(0x0000A93C00000000 AS DateTime))
INSERT [dbo].[Presentations] ([ID], [ItemID], [LayoutID], [Created], [Updated]) VALUES (N'e501195a-4b61-4eaf-9cd5-b29484f671b7', N'29e3738b-4a47-49dc-9fb6-cfda1252d553', N'24f0e167-4fc5-45e4-b837-eecbb7872498', CAST(0x0000A93C00000000 AS DateTime), CAST(0x0000A93C00000000 AS DateTime))
INSERT [dbo].[Renderings] ([ID], [Name], [Assembly], [Controller], [Action], [Created], [Updated]) VALUES (N'c644f8d5-990e-4541-95d2-5843649a7791', N'Custom Feature', N'CustomFeature', N'CustomFeature.Controllers.CustomFeatureController', N'Index', CAST(0x0000A93C00000000 AS DateTime), CAST(0x0000A93C00000000 AS DateTime))
INSERT [dbo].[Templates] ([ID], [Name], [Created], [Updated]) VALUES (N'7f207232-df9e-4a5b-ae27-d9d96e061819', N'Content page', CAST(0x0000A93C00000000 AS DateTime), CAST(0x0000A93C00000000 AS DateTime))
/****** Object:  Index [IX_Fields]    Script Date: 8/15/2018 5:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Fields] ON [dbo].[Fields]
(
	[TemplateID] ASC,
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ItemRenderings]    Script Date: 8/15/2018 5:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ItemRenderings] ON [dbo].[ItemRenderings]
(
	[PresentationID] ASC,
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Items]    Script Date: 8/15/2018 5:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Items] ON [dbo].[Items]
(
	[TemplateID] ASC,
	[ID] ASC,
	[Name] ASC,
	[ParentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Layouts]    Script Date: 8/15/2018 5:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Layouts] ON [dbo].[Layouts]
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Presentations]    Script Date: 8/15/2018 5:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Presentations] ON [dbo].[Presentations]
(
	[ItemID] ASC,
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Properties]    Script Date: 8/15/2018 5:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Properties] ON [dbo].[Properties]
(
	[ItemID] ASC,
	[FieldID] ASC,
	[ID] ASC,
	[Language] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Renderings]    Script Date: 8/15/2018 5:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Renderings] ON [dbo].[Renderings]
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Templates]    Script Date: 8/15/2018 5:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Templates] ON [dbo].[Templates]
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Fields]  WITH CHECK ADD  CONSTRAINT [FK_Fields_Templates] FOREIGN KEY([TemplateID])
REFERENCES [dbo].[Templates] ([ID])
GO
ALTER TABLE [dbo].[Fields] CHECK CONSTRAINT [FK_Fields_Templates]
GO
ALTER TABLE [dbo].[ItemRenderings]  WITH CHECK ADD  CONSTRAINT [FK_ItemRenderings_Items] FOREIGN KEY([SourceID])
REFERENCES [dbo].[Items] ([ID])
GO
ALTER TABLE [dbo].[ItemRenderings] CHECK CONSTRAINT [FK_ItemRenderings_Items]
GO
ALTER TABLE [dbo].[ItemRenderings]  WITH CHECK ADD  CONSTRAINT [FK_ItemRenderings_Presentations] FOREIGN KEY([PresentationID])
REFERENCES [dbo].[Presentations] ([ID])
GO
ALTER TABLE [dbo].[ItemRenderings] CHECK CONSTRAINT [FK_ItemRenderings_Presentations]
GO
ALTER TABLE [dbo].[ItemRenderings]  WITH CHECK ADD  CONSTRAINT [FK_ItemRenderings_Renderings] FOREIGN KEY([RenderingID])
REFERENCES [dbo].[Renderings] ([ID])
GO
ALTER TABLE [dbo].[ItemRenderings] CHECK CONSTRAINT [FK_ItemRenderings_Renderings]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Items] FOREIGN KEY([ParentID])
REFERENCES [dbo].[Items] ([ID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Items]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Templates] FOREIGN KEY([TemplateID])
REFERENCES [dbo].[Templates] ([ID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Templates]
GO
ALTER TABLE [dbo].[Links]  WITH CHECK ADD  CONSTRAINT [FK_Links_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ID])
GO
ALTER TABLE [dbo].[Links] CHECK CONSTRAINT [FK_Links_Items]
GO
ALTER TABLE [dbo].[Presentations]  WITH CHECK ADD  CONSTRAINT [FK_Presentations_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ID])
GO
ALTER TABLE [dbo].[Presentations] CHECK CONSTRAINT [FK_Presentations_Items]
GO
ALTER TABLE [dbo].[Presentations]  WITH CHECK ADD  CONSTRAINT [FK_Presentations_Layouts] FOREIGN KEY([LayoutID])
REFERENCES [dbo].[Layouts] ([ID])
GO
ALTER TABLE [dbo].[Presentations] CHECK CONSTRAINT [FK_Presentations_Layouts]
GO
ALTER TABLE [dbo].[Properties]  WITH CHECK ADD  CONSTRAINT [FK_Properties_Fields] FOREIGN KEY([FieldID])
REFERENCES [dbo].[Fields] ([ID])
GO
ALTER TABLE [dbo].[Properties] CHECK CONSTRAINT [FK_Properties_Fields]
GO
ALTER TABLE [dbo].[Properties]  WITH CHECK ADD  CONSTRAINT [FK_Properties_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ID])
GO
ALTER TABLE [dbo].[Properties] CHECK CONSTRAINT [FK_Properties_Items]
GO
USE [master]
GO
ALTER DATABASE [Demo] SET  READ_WRITE 
GO
