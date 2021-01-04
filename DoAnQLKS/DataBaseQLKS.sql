
if OBJECT_ID('QLKS')is not null
drop database QLKS
go

CREATE DATABASE QLKS 
go

use QLKS
go

CREATE TABLE [dbo].[THAMSO](
	[Soluongkhachtoidamoiphong] [int] NULL,
	[phuthukhachthu3] [float] NULL,
	[phuthukhachnuocngoai] [float] NULL
) ON [PRIMARY]
GO

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

CREATE TABLE [dbo].[PHIEUTHUEPHONG](
	[maphieu] [varchar](10) NOT NULL,
	[ngaybd] [datetime] NULL,
	[soluongkhach] [int] NULL,
	[phong] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[maphieu] ASC
))
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
))
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
))

go
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


insert into phong 
values('P101','A',300000,N'Phòng loại A đơn giá 300000/ngay','chua thue'),
('P102','B',200000,N'Phòng loại B đơn giá 200000/ngay','chua thue'),
('P103','C',400000,N'Phòng loại C đơn giá 400000/ngay','chua thue')

insert into THAMSO

values (3,0.25,1.5)