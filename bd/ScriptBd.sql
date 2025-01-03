USE [master]
GO
/****** Object:  Database [PropuestaRestoBD]    Script Date: 09/11/2024 18:39:53 ******/
CREATE DATABASE [PropuestaRestoBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PropuestaRestoBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PropuestaRestoBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PropuestaRestoBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PropuestaRestoBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PropuestaRestoBD] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PropuestaRestoBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PropuestaRestoBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PropuestaRestoBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PropuestaRestoBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PropuestaRestoBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PropuestaRestoBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET RECOVERY FULL 
GO
ALTER DATABASE [PropuestaRestoBD] SET  MULTI_USER 
GO
ALTER DATABASE [PropuestaRestoBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PropuestaRestoBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PropuestaRestoBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PropuestaRestoBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PropuestaRestoBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PropuestaRestoBD] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PropuestaRestoBD', N'ON'
GO
ALTER DATABASE [PropuestaRestoBD] SET QUERY_STORE = ON
GO
ALTER DATABASE [PropuestaRestoBD] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PropuestaRestoBD]
GO
/****** Object:  Table [dbo].[Insumo]    Script Date: 09/11/2024 18:39:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Insumo](
	[IdInsumo] [int] NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[IdTipoInsumo] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [money] NOT NULL,
 CONSTRAINT [PK_Insumo] PRIMARY KEY CLUSTERED 
(
	[IdInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mesa]    Script Date: 09/11/2024 18:39:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesa](
	[IdMesa] [int] NOT NULL,
	[Diponible] [bit] NOT NULL,
	[Asignada] [bit] NOT NULL,
 CONSTRAINT [PK_Mesa] PRIMARY KEY CLUSTERED 
(
	[IdMesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mesa_Usuario]    Script Date: 09/11/2024 18:39:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesa_Usuario](
	[IdMesa] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 09/11/2024 18:39:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[IdPedido] [int] NOT NULL,
	[IdMesa] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Precio] [money] NULL,
	[IdInsumo] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoInsmo]    Script Date: 09/11/2024 18:39:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoInsmo](
	[IdInsumo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nchar](10) NULL,
 CONSTRAINT [PK_TipoInsmo] PRIMARY KEY CLUSTERED 
(
	[IdInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 09/11/2024 18:39:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[FechaIngreso] [datetime] NOT NULL,
	[EsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
ALTER TABLE [dbo].[Insumo]  WITH CHECK ADD  CONSTRAINT [FK_Insumo_TipoInsmo] FOREIGN KEY([IdTipoInsumo])
REFERENCES [dbo].[TipoInsmo] ([IdInsumo])
GO
ALTER TABLE [dbo].[Insumo] CHECK CONSTRAINT [FK_Insumo_TipoInsmo]
GO
ALTER TABLE [dbo].[Mesa_Usuario]  WITH CHECK ADD  CONSTRAINT [FKIDMESA] FOREIGN KEY([IdMesa])
REFERENCES [dbo].[Mesa] ([IdMesa])
GO
ALTER TABLE [dbo].[Mesa_Usuario] CHECK CONSTRAINT [FKIDMESA]
GO
ALTER TABLE [dbo].[Mesa_Usuario]  WITH CHECK ADD  CONSTRAINT [FKIDUSUARIO] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Mesa_Usuario] CHECK CONSTRAINT [FKIDUSUARIO]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Insumo] FOREIGN KEY([IdInsumo])
REFERENCES [dbo].[Insumo] ([IdInsumo])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Insumo]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FKIDMESAA] FOREIGN KEY([IdMesa])
REFERENCES [dbo].[Mesa] ([IdMesa])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FKIDMESAA]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [fkidsario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [fkidsario]
GO
USE [master]
GO
ALTER DATABASE [PropuestaRestoBD] SET  READ_WRITE 
GO
