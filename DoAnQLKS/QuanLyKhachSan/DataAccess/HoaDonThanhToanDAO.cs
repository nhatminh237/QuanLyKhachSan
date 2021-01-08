using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyKhachSan.DataAccess
{
    public class HoaDonThanhToanDAO
    {
        public void insertHoaDon(string mahd,string tenphong,string ngaythanhtoan, int songaythue,double dongia,double phuthu,double thanhtien,string phieuthue)
        {
            SqlProvider.ExecuteQuery("insert into hoadonthanhtoan values('" + mahd + "','" + tenphong + "','" + ngaythanhtoan + "'," + songaythue + "," + dongia + "," + phuthu + "," + thanhtien + ",'" + phieuthue + "')");
        }
        public DataTable selectAllHoaDon()
        {
            return SqlProvider.ExecuteQuery("select * from hoadonthanhtoan");
        }
        public DataTable Kiemtrathanhtoan()
        {
            return SqlProvider.ExecuteQuery("select pt.phong from HOADONTHANHTOAN hd join PHIEUTHUEPHONG pt on pt.maphieu = hd.phieuthue join PHONG p on p.tenphong = pt.phong where p.tinhtrang = 'da thue'");
        }
        public DataTable SelectNam()
        {
            return SqlProvider.ExecuteQuery("select year(ngaythanhtoan) from hoadonthanhtoan");
        }
        public DataTable selectDoanhThuTheoLoaiPhong(int thang, int nam)
        {
            return SqlProvider.ExecuteQuery("select p.loaiphong, SUM(hd.thanhtien) TongTien from HOADONTHANHTOAN hd join PHONG p on hd.phong = p.tenphong where year(hd.ngaythanhtoan) = " + nam + " and MONTH(hd.ngaythanhtoan) = " + thang + " group by p.loaiphong, hd.thanhtien");
        }
        public DataTable selectMatDoSuDungPhong(int thang, int nam)
        {
            return SqlProvider.ExecuteQuery("select p.tenphong,sum(hd.songaythue) TongSoNgayThue from HOADONTHANHTOAN hd join PHONG p on hd.phong = p.tenphong where year(hd.ngaythanhtoan) = " + nam + " and MONTH(hd.ngaythanhtoan) = " + thang + " group by p.tenphong, hd.songaythue");
        }
    }
}
