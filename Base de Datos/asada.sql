USE [master]
GO
/****** Object:  Database [asada]    Script Date: 19/10/2021 10:07:01 ******/
CREATE DATABASE [asada]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'asada', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\asada.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'asada_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\asada_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [asada] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [asada].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [asada] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [asada] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [asada] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [asada] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [asada] SET ARITHABORT OFF 
GO
ALTER DATABASE [asada] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [asada] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [asada] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [asada] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [asada] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [asada] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [asada] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [asada] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [asada] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [asada] SET  DISABLE_BROKER 
GO
ALTER DATABASE [asada] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [asada] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [asada] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [asada] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [asada] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [asada] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [asada] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [asada] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [asada] SET  MULTI_USER 
GO
ALTER DATABASE [asada] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [asada] SET DB_CHAINING OFF 
GO
ALTER DATABASE [asada] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [asada] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [asada] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [asada] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [asada] SET QUERY_STORE = OFF
GO
USE [asada]
GO
/****** Object:  Table [dbo].[Averia]    Script Date: 19/10/2021 10:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Averia](
	[id_averia] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](200) NOT NULL,
	[direccion] [varchar](200) NOT NULL,
	[fecha_inicio] [date] NOT NULL,
	[fecha_fin] [date] NOT NULL,
	[id_estado] [int] NOT NULL,
 CONSTRAINT [PK_Averia] PRIMARY KEY CLUSTERED 
(
	[id_averia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comprobante]    Script Date: 19/10/2021 10:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comprobante](
	[id_comprobante] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [varchar](20) NOT NULL,
	[id_recibo] [int] NOT NULL,
	[numero_tarjeta] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Comprobante] PRIMARY KEY CLUSTERED 
(
	[id_comprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 19/10/2021 10:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[id_estado] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[id_estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 19/10/2021 10:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[id_marca] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[id_marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medidor]    Script Date: 19/10/2021 10:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medidor](
	[id_medidor] [int] IDENTITY(1,1) NOT NULL,
	[direccion] [varchar](500) NOT NULL,
	[cedula] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Medidor] PRIMARY KEY CLUSTERED 
(
	[id_medidor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recibo]    Script Date: 19/10/2021 10:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recibo](
	[id_recibo] [int] IDENTITY(1,1) NOT NULL,
	[fecha_cobro] [date] NOT NULL,
	[monto] [int] NOT NULL,
	[consumo] [int] NOT NULL,
	[id_medidor] [int] NOT NULL,
	[cedula] [varchar](20) NOT NULL,
	[fecha_vencimiento] [date] NOT NULL,
	[id_estado] [int] NOT NULL,
 CONSTRAINT [PK_Recibo] PRIMARY KEY CLUSTERED 
(
	[id_recibo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 19/10/2021 10:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjeta](
	[numero_tarjeta] [varchar](20) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[cvv] [int] NOT NULL,
	[fecha_vencimiento] [date] NOT NULL,
	[id_marca] [int] NOT NULL,
	[cedula] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Tarjeta] PRIMARY KEY CLUSTERED 
(
	[numero_tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Usuario]    Script Date: 19/10/2021 10:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Tipo_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 19/10/2021 10:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[cedula] [varchar](20) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[primer_apellido] [varchar](20) NOT NULL,
	[segundo_apellido] [varchar](20) NOT NULL,
	[correo] [varchar](200) NOT NULL,
	[password] [varchar](20) NOT NULL,
	[telefono] [varchar](15) NOT NULL,
	[id_usuario] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Averia]  WITH CHECK ADD  CONSTRAINT [FK_Averia_Estado] FOREIGN KEY([id_estado])
REFERENCES [dbo].[Estado] ([id_estado])
GO
ALTER TABLE [dbo].[Averia] CHECK CONSTRAINT [FK_Averia_Estado]
GO
ALTER TABLE [dbo].[Comprobante]  WITH CHECK ADD  CONSTRAINT [FK_Comprobante_Recibo] FOREIGN KEY([id_recibo])
REFERENCES [dbo].[Recibo] ([id_recibo])
GO
ALTER TABLE [dbo].[Comprobante] CHECK CONSTRAINT [FK_Comprobante_Recibo]
GO
ALTER TABLE [dbo].[Comprobante]  WITH CHECK ADD  CONSTRAINT [FK_Comprobante_Tarjeta] FOREIGN KEY([numero_tarjeta])
REFERENCES [dbo].[Tarjeta] ([numero_tarjeta])
GO
ALTER TABLE [dbo].[Comprobante] CHECK CONSTRAINT [FK_Comprobante_Tarjeta]
GO
ALTER TABLE [dbo].[Comprobante]  WITH CHECK ADD  CONSTRAINT [FK_Comprobante_Usuario] FOREIGN KEY([cedula])
REFERENCES [dbo].[Usuario] ([cedula])
GO
ALTER TABLE [dbo].[Comprobante] CHECK CONSTRAINT [FK_Comprobante_Usuario]
GO
ALTER TABLE [dbo].[Medidor]  WITH CHECK ADD  CONSTRAINT [FK_Medidor_Medidor] FOREIGN KEY([cedula])
REFERENCES [dbo].[Usuario] ([cedula])
GO
ALTER TABLE [dbo].[Medidor] CHECK CONSTRAINT [FK_Medidor_Medidor]
GO
ALTER TABLE [dbo].[Recibo]  WITH CHECK ADD  CONSTRAINT [FK_Recibo_Estado] FOREIGN KEY([id_estado])
REFERENCES [dbo].[Estado] ([id_estado])
GO
ALTER TABLE [dbo].[Recibo] CHECK CONSTRAINT [FK_Recibo_Estado]
GO
ALTER TABLE [dbo].[Recibo]  WITH CHECK ADD  CONSTRAINT [FK_Recibo_Medidor] FOREIGN KEY([id_medidor])
REFERENCES [dbo].[Medidor] ([id_medidor])
GO
ALTER TABLE [dbo].[Recibo] CHECK CONSTRAINT [FK_Recibo_Medidor]
GO
ALTER TABLE [dbo].[Recibo]  WITH CHECK ADD  CONSTRAINT [FK_Recibo_Usuario] FOREIGN KEY([cedula])
REFERENCES [dbo].[Usuario] ([cedula])
GO
ALTER TABLE [dbo].[Recibo] CHECK CONSTRAINT [FK_Recibo_Usuario]
GO
ALTER TABLE [dbo].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_Marca] FOREIGN KEY([id_marca])
REFERENCES [dbo].[Marca] ([id_marca])
GO
ALTER TABLE [dbo].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_Marca]
GO
ALTER TABLE [dbo].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_Usuario] FOREIGN KEY([cedula])
REFERENCES [dbo].[Usuario] ([cedula])
GO
ALTER TABLE [dbo].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_Usuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Tipo_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Tipo_Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Tipo_Usuario]
GO
USE [master]
GO
ALTER DATABASE [asada] SET  READ_WRITE 
GO
