USE [master]
GO
/****** Object:  Database [QLKS]    Script Date: 12/29/2020 21:17:18 ******/
CREATE DATABASE [QLKS] ON  PRIMARY 
( NAME = N'QLKS', FILENAME = N'E:\SQL\MSSQL11.SQLEXPRESS\MSSQL\DATA\QLKS.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLKS_log', FILENAME = N'E:\SQL\MSSQL11.SQLEXPRESS\MSSQL\DATA\QLKS_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLKS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLKS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLKS] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [QLKS] SET ANSI_NULLS OFF
GO
ALTER DATABASE [QLKS] SET ANSI_PADDING OFF
GO
ALTER DATABASE [QLKS] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [QLKS] SET ARITHABORT OFF
GO
ALTER DATABASE [QLKS] SET AUTO_CLOSE ON
GO
ALTER DATABASE [QLKS] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [QLKS] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [QLKS] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [QLKS] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [QLKS] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [QLKS] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [QLKS] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [QLKS] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [QLKS] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [QLKS] SET  ENABLE_BROKER
GO
ALTER DATABASE [QLKS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [QLKS] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [QLKS] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [QLKS] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [QLKS] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [QLKS] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [QLKS] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [QLKS] SET  READ_WRITE
GO
ALTER DATABASE [QLKS] SET RECOVERY SIMPLE
GO
ALTER DATABASE [QLKS] SET  MULTI_USER
GO
ALTER DATABASE [QLKS] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [QLKS] SET DB_CHAINING OFF
GO
USE [QLKS]
GO
/****** Object:  Table [dbo].[THAMSO]    Script Date: 12/29/2020 21:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THAMSO](
	[Soluongkhachtoidamoiphong] [int] NULL,
	[phuthukhachthu3] [float] NULL,
	[phuthukhachnuocngoai] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONG]    Script Date: 12/29/2020 21:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHONG](
	[tenphong] [varchar](10) NOT NULL,
	[loaiphong] [varchar](3) NULL,
	[dongia] [float] NULL,
	[ghichu] [nvarchar](200) NULL,
	[tinhtrang] [nvarchar](15) NULL,
 CONSTRAINT [PK__PHONG__434D6ADA7F60ED59] PRIMARY KEY CLUSTERED 
(
	[tenphong] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHIEUTHUEPHONG]    Script Date: 12/29/2020 21:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHIEUTHUEPHONG](
	[maphieu] [varchar](10) NOT NULL,
	[ngaybd] [datetime] NULL,
	[soluongkhach] [int] NULL,
	[phong] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[maphieu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MATDOSUDUNGPHONG]    Script Date: 12/29/2020 21:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MATDOSUDUNGPHONG](
	[phong] [varchar](10) NOT NULL,
	[songaysd] [int] NULL,
	[tile] [float] NULL,
	[thangnam] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[phong] ASC,
	[thangnam] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 12/29/2020 21:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[Cmt] [int] NOT NULL,
	[hoten] [nvarchar](40) NULL,
	[loaikhach] [nvarchar](50) NULL,
	[diachi] [nvarchar](150) NULL,
	[maphieuthue] [varchar](10) NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[Cmt] ASC,
	[maphieuthue] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HOADONTHANHTOAN]    Script Date: 12/29/2020 21:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOADONTHANHTOAN](
	[mahoadon] [varchar](10) NOT NULL,
	[phong] [varchar](10) NULL,
	[ngaythanhtoan] [datetime] NULL,
	[songaythue] [int] NULL,
	[dongia] [float] NULL,
	[phuthu] [float] NULL,
	[thanhtien] [float] NULL,
	[phieuthue] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[mahoadon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DOANHTHUTHEOLOAIPHONG]    Script Date: 12/29/2020 21:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DOANHTHUTHEOLOAIPHONG](
	[loaiphong] [varchar](3) NOT NULL,
	[doanhthu] [float] NULL,
	[tile] [float] NULL,
	[thangnam] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[loaiphong] ASC,
	[thangnam] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[UpdateTTPhong]    Script Date: 12/29/2020 21:17:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateTTPhong]
as
	if exists(select * from PHONG p join HOADONTHANHTOAN hd 
				on p.tenphong = hd.phong join PHIEUTHUEPHONG pt 
				on pt.maphieu = hd.phieuthue where p.tinhtrang = 'da thue' and DATEDIFF(day, hd.ngaythanhtoan,getdate()) >=0 and DATEDIFF(DAY, pt.ngaybd,GETDATE())<DATEDIFF(day, hd.ngaythanhtoan,getdate()) )
				begin
					declare cur cursor for (select p.tenphong from PHONG p join HOADONTHANHTOAN hd 
				on p.tenphong = hd.phong join PHIEUTHUEPHONG pt 
				on pt.maphieu = hd.phieuthue where p.tinhtrang = 'da thue' and DATEDIFF(day, hd.ngaythanhtoan,getdate()) >=0and DATEDIFF(DAY, pt.ngaybd,GETDATE())<DATEDIFF(day, hd.ngaythanhtoan,getdate()))
					declare @maphong varchar(10)
					open cur 
					fetch next from cur into @maphong
					while(@@FETCH_STATUS = 0)
					begin
						update PHONG
						set tinhtrang = 'chua thue'
						where tenphong = @maphong
						fetch next from cur into @maphong
					end
					close cur
					deallocate cur
				end
GO
