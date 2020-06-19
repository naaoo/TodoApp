USE [master]
GO
/****** Object:  Database [todo]    Script Date: 19.06.2020 12:15:53 ******/
CREATE DATABASE [todo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Todo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Todo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Todo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Todo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [todo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [todo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [todo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [todo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [todo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [todo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [todo] SET ARITHABORT OFF 
GO
ALTER DATABASE [todo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [todo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [todo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [todo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [todo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [todo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [todo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [todo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [todo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [todo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [todo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [todo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [todo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [todo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [todo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [todo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [todo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [todo] SET RECOVERY FULL 
GO
ALTER DATABASE [todo] SET  MULTI_USER 
GO
ALTER DATABASE [todo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [todo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [todo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [todo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [todo] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'todo', N'ON'
GO
ALTER DATABASE [todo] SET QUERY_STORE = OFF
GO
USE [todo]
GO
/****** Object:  Table [dbo].[Todo]    Script Date: 19.06.2020 12:15:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Todo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[text] [varchar](400) NOT NULL,
	[done] [bit] NOT NULL,
	[date_due] [datetime] NULL,
	[date_done] [datetime] NULL,
 CONSTRAINT [PK_todo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Todo] ON 

INSERT [dbo].[Todo] ([id], [text], [done], [date_due], [date_done]) VALUES (1, N'Wäsche', 1, CAST(N'2020-06-18T16:00:00.000' AS DateTime), CAST(N'2020-06-19T07:54:00.953' AS DateTime))
INSERT [dbo].[Todo] ([id], [text], [done], [date_due], [date_done]) VALUES (2, N'Einkaufen', 0, CAST(N'2020-06-18T17:30:00.000' AS DateTime), CAST(N'2020-06-18T15:36:52.610' AS DateTime))
INSERT [dbo].[Todo] ([id], [text], [done], [date_due], [date_done]) VALUES (3, N'Coden', 1, CAST(N'2020-06-20T16:00:00.000' AS DateTime), CAST(N'2020-06-19T11:34:01.080' AS DateTime))
INSERT [dbo].[Todo] ([id], [text], [done], [date_due], [date_done]) VALUES (4, N'Geschirr', 1, CAST(N'2020-06-20T16:00:00.000' AS DateTime), CAST(N'2020-06-19T11:36:00.360' AS DateTime))
INSERT [dbo].[Todo] ([id], [text], [done], [date_due], [date_done]) VALUES (5, N'Staubsaugen', 1, NULL, CAST(N'2020-06-18T14:00:00.000' AS DateTime))
INSERT [dbo].[Todo] ([id], [text], [done], [date_due], [date_done]) VALUES (7, N'Fenster putzen', 1, NULL, CAST(N'2020-06-19T09:30:04.377' AS DateTime))
INSERT [dbo].[Todo] ([id], [text], [done], [date_due], [date_done]) VALUES (8, N'Test', 0, CAST(N'2020-06-20T10:30:58.000' AS DateTime), NULL)
INSERT [dbo].[Todo] ([id], [text], [done], [date_due], [date_done]) VALUES (9, N'TestTodo', 0, NULL, NULL)
INSERT [dbo].[Todo] ([id], [text], [done], [date_due], [date_done]) VALUES (10, N'Laufen', 1, CAST(N'2020-06-24T09:36:52.000' AS DateTime), CAST(N'2020-06-19T10:09:49.823' AS DateTime))
INSERT [dbo].[Todo] ([id], [text], [done], [date_due], [date_done]) VALUES (11, N'Radfahren', 1, CAST(N'2020-06-26T09:54:35.000' AS DateTime), CAST(N'2020-06-19T10:08:54.717' AS DateTime))
INSERT [dbo].[Todo] ([id], [text], [done], [date_due], [date_done]) VALUES (12, N'Zugfahren', 0, CAST(N'2020-06-22T10:09:13.000' AS DateTime), NULL)
INSERT [dbo].[Todo] ([id], [text], [done], [date_due], [date_done]) VALUES (13, N'Klettern', 0, CAST(N'2020-06-25T23:00:13.000' AS DateTime), NULL)
INSERT [dbo].[Todo] ([id], [text], [done], [date_due], [date_done]) VALUES (14, N'Kochen', 0, CAST(N'2020-06-20T22:50:46.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Todo] OFF
GO
USE [master]
GO
ALTER DATABASE [todo] SET  READ_WRITE 
GO
