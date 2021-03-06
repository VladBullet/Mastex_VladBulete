USE [master]
GO
/****** Object:  Database [Mastex_App]    Script Date: 01-Jun-20 6:46:36 AM ******/
CREATE DATABASE [Mastex_App]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mastex_App', FILENAME = N'C:\Users\vlado\Mastex_App.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Mastex_App_log', FILENAME = N'C:\Users\vlado\Mastex_App_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Mastex_App] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mastex_App].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mastex_App] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Mastex_App] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Mastex_App] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Mastex_App] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Mastex_App] SET ARITHABORT OFF 
GO
ALTER DATABASE [Mastex_App] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Mastex_App] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Mastex_App] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Mastex_App] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Mastex_App] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Mastex_App] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Mastex_App] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Mastex_App] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Mastex_App] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Mastex_App] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Mastex_App] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Mastex_App] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Mastex_App] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Mastex_App] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Mastex_App] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Mastex_App] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Mastex_App] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Mastex_App] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Mastex_App] SET  MULTI_USER 
GO
ALTER DATABASE [Mastex_App] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Mastex_App] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Mastex_App] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Mastex_App] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Mastex_App] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Mastex_App] SET QUERY_STORE = OFF
GO
USE [Mastex_App]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Mastex_App]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 01-Jun-20 6:46:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectUsers]    Script Date: 01-Jun-20 6:46:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectUsers](
	[UserId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 01-Jun-20 6:46:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ProjectId] [int] NOT NULL,
	[AssignedUserId] [int] NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01-Jun-20 6:46:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Projects] ON 

INSERT [dbo].[Projects] ([Id], [Title], [Description], [Deleted]) VALUES (1, N'Create Application', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Erat imperdiet sed euismod nisi porta lorem. Viverra nam libero justo laoreet sit amet cursus sit. Neque ornare aenean euismod elementum nisi quis eleifend quam adipiscing. Tincidunt dui ut ornare lectus. ', 0)
INSERT [dbo].[Projects] ([Id], [Title], [Description], [Deleted]) VALUES (3, N'Project 2', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Erat imperdiet sed euismod nisi porta lorem. Viverra nam libero justo laoreet sit amet cursus sit. Neque ornare aenean euismod elementum nisi quis eleifend quam adipiscing. Tincidunt dui ut ornare lectus. ', 0)
INSERT [dbo].[Projects] ([Id], [Title], [Description], [Deleted]) VALUES (4, N'Project 3', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Erat imperdiet sed euismod nisi porta lorem. Viverra nam libero justo laoreet sit amet cursus sit. Neque ornare aenean euismod elementum nisi quis eleifend quam adipiscing. Tincidunt dui ut ornare lectus. ', 0)
SET IDENTITY_INSERT [dbo].[Projects] OFF
INSERT [dbo].[ProjectUsers] ([UserId], [ProjectId]) VALUES (1, 1)
INSERT [dbo].[ProjectUsers] ([UserId], [ProjectId]) VALUES (1, 3)
INSERT [dbo].[ProjectUsers] ([UserId], [ProjectId]) VALUES (1, 4)
INSERT [dbo].[ProjectUsers] ([UserId], [ProjectId]) VALUES (2, 3)
INSERT [dbo].[ProjectUsers] ([UserId], [ProjectId]) VALUES (3, 4)
INSERT [dbo].[ProjectUsers] ([UserId], [ProjectId]) VALUES (2, 1)
INSERT [dbo].[ProjectUsers] ([UserId], [ProjectId]) VALUES (3, 1)
SET IDENTITY_INSERT [dbo].[Tasks] ON 

INSERT [dbo].[Tasks] ([Id], [Title], [Description], [ProjectId], [AssignedUserId], [Status], [Deleted]) VALUES (1, N'Task 1', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 1, NULL, N'Created', 0)
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [ProjectId], [AssignedUserId], [Status], [Deleted]) VALUES (2, N'Task 2', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 1, NULL, N'Reasearching', 0)
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [ProjectId], [AssignedUserId], [Status], [Deleted]) VALUES (3, N'Task 3', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 1, NULL, N'InProgress', 0)
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [ProjectId], [AssignedUserId], [Status], [Deleted]) VALUES (4, N'Task 4', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 1, NULL, N'Done', 0)
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [ProjectId], [AssignedUserId], [Status], [Deleted]) VALUES (7, N'Task 1', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 3, NULL, N'InProgress', 0)
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [ProjectId], [AssignedUserId], [Status], [Deleted]) VALUES (8, N'Task 2', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 3, NULL, N'Done', 0)
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [ProjectId], [AssignedUserId], [Status], [Deleted]) VALUES (9, N'Task 1', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 4, NULL, N'Done', 0)
SET IDENTITY_INSERT [dbo].[Tasks] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Role], [Deleted]) VALUES (1, N'Vlad Bulete', N'Admin', 0)
INSERT [dbo].[Users] ([Id], [Name], [Role], [Deleted]) VALUES (2, N'Maria Popescu', N'Default', 0)
INSERT [dbo].[Users] ([Id], [Name], [Role], [Deleted]) VALUES (3, N'Ian Miller', N'Default', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[ProjectUsers]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUsers_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[ProjectUsers] CHECK CONSTRAINT [FK_ProjectUsers_Projects]
GO
ALTER TABLE [dbo].[ProjectUsers]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUsers_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[ProjectUsers] CHECK CONSTRAINT [FK_ProjectUsers_Users]
GO
USE [master]
GO
ALTER DATABASE [Mastex_App] SET  READ_WRITE 
GO
