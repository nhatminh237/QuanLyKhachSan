using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyKhachSan.DataAccess
{
    public class PhongDAO
    {
        public DataTable SelectAllPhong()
        {
            return SqlProvider.ExecuteQuery("select * from phong");
        }
        public DataTable SortByPhongChuaThue()
        {
            return SqlProvider.ExecuteQuery("select * from phong order by tinhtrang ASC");
        }
        public DataTable SortByPhongDaThue()
        {
            return SqlProvider.ExecuteQuery("select * from phong order by tinhtrang DESC");
        }
        public DataTable SearchTenVaLoaiPhong(string textsearch)
        {
            return SqlProvider.ExecuteQuery("select * from phong where tenphong like '%" + textsearch + "%' or loaiphong like'%" + textsearch + "%'");
        }
        public void updatePhong(string tenphong)
        {
            SqlProvider.ExecuteQuery("update phong set tinhtrang = 'da thue' where tenphong = '" + tenphong + "'");
        }
        public DataTable SearchTheoTenPhongdathue(string tenphong)
        {
            return SqlProvider.ExecuteQuery("select * from phong where tenphong like '%" + tenphong + "%' and tinhtrang = 'da thue'");
        }
        public DataTable SearchTheoTenPhongchuathue(string tenphong)
        {
            return SqlProvider.ExecuteQuery("select * from phong where tenphong like '%" + tenphong + "%' and tinhtrang = 'chua thue'");
        }
        public void UpdateTTPhong(string tenphong, string loai,double dongia,string ghichu)
        {
            SqlProvider.ExecuteQuery("update phong set loaiphong = '" + loai + "',dongia =" + dongia + ",ghichu =N'" + ghichu + "'where tenphong = '" + tenphong + "' "); 
        }

        public DataTable selectGiaPhongTheoLoaiPhong(string loaiphong)
        {
            return SqlProvider.ExecuteQuery("select dongia from phong where loaiphong ='" + loaiphong + "'");
        }

        public void updateDonGiaTatCaCacPhongTheoLoai(string loaiphong,double dongia)
        {
            SqlProvider.ExecuteQuery("update phong set dongia = " + dongia + "where loaiphong = '" + loaiphong + "'");
        }

        public void updateTTPhongAsChuaThue()
        {
            SqlProvider.ExecuteQuery("exec UpdateTTPhong");
        }
       
    }
}

//Proc cập nhật lại tình trạng của tất cả các phòng

//if OBJECT_ID('UpdateTTPhong') is not null
//drop proc UpdateTTPhong
//go
//create proc UpdateTTPhong
//as
//	if exists(select* from PHONG p join HOADONTHANHTOAN hd
//                on p.tenphong = hd.phong join PHIEUTHUEPHONG pt
//                on pt.maphieu = hd.phieuthue where p.tinhtrang = 'da thue' and DATEDIFF(day, hd.ngaythanhtoan, getdate()) >=0 and DATEDIFF(DAY, pt.ngaybd, GETDATE())<DATEDIFF(day, hd.ngaythanhtoan, getdate()) )
//				begin
//                    declare cur cursor for (select p.tenphong from PHONG p join HOADONTHANHTOAN hd
//                on p.tenphong = hd.phong join PHIEUTHUEPHONG pt

//                on pt.maphieu = hd.phieuthue where p.tinhtrang = 'da thue' and DATEDIFF(day, hd.ngaythanhtoan, getdate()) >=0and DATEDIFF(DAY, pt.ngaybd, GETDATE())<DATEDIFF(day, hd.ngaythanhtoan, getdate()))
//					declare @maphong varchar(10)

//                    open cur

//                    fetch next from cur into @maphong
//					while(@@FETCH_STATUS = 0)
//					begin
//                        update PHONG
//                        set tinhtrang = 'chua thue'
//						where tenphong = @maphong

//                        fetch next from cur into @maphong

//                    end
//                    close cur
//                    deallocate cur
//                end
//go


