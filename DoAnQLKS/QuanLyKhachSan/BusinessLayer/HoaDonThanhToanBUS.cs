using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyKhachSan.DataAccess;

namespace QuanLyKhachSan.BusinessLayer
{
    public class HoaDonThanhToanBUS
    {
        public void insertHoaDon(string mahd, string tenphong, string ngaythanhtoan, int songaythue, double dongia, double phuthu, double thanhtien, string phieuthue)
        {
            HoaDonThanhToanDAO dao = new HoaDonThanhToanDAO();
            dao.insertHoaDon(mahd, tenphong, ngaythanhtoan, songaythue, dongia, phuthu, thanhtien, phieuthue);
        }
        public DataTable selectAllHoaDon()
        {
            HoaDonThanhToanDAO dao = new HoaDonThanhToanDAO();
            return dao.selectAllHoaDon();
        }
        public DataTable KiemTraThanhToan()
        {
            HoaDonThanhToanDAO dao = new HoaDonThanhToanDAO();
            return dao.Kiemtrathanhtoan();
        }

        public DataTable SelectNam()
        {
            HoaDonThanhToanDAO dao = new HoaDonThanhToanDAO();
            return dao.SelectNam();
        }
        public DataTable selectDoanhThuTheoLoaiPhong(int thang, int nam)
        {
            HoaDonThanhToanDAO dao = new HoaDonThanhToanDAO();
            return dao.selectDoanhThuTheoLoaiPhong(thang, nam);
        }
        public DataTable selectMatDoSuDungPhong(int thang, int nam)
        {
            HoaDonThanhToanDAO dao = new HoaDonThanhToanDAO();
            return dao.selectMatDoSuDungPhong(thang, nam);
        }
    }
}
