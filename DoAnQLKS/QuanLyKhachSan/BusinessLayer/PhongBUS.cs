using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyKhachSan.DataAccess;

namespace QuanLyKhachSan.BusinessLayer
{
    public class PhongBUS
    {
        public DataTable SelectAllPhong()
        {
            PhongDAO dao = new PhongDAO();
            return dao.SelectAllPhong();
        }
        public DataTable SortByPhongChuaThue()
        {
            PhongDAO dao = new PhongDAO();
            return dao.SortByPhongChuaThue();
        }
        public DataTable SortByPhongDaThue()
        {
            PhongDAO dao = new PhongDAO();
            return dao.SortByPhongDaThue();
        }
        public DataTable search(string textsearch)
        {
            PhongDAO dao = new PhongDAO();
            return dao.SearchTenVaLoaiPhong(textsearch);
        }
        public void updatePhong(string tenphong)
        {
            PhongDAO dao = new PhongDAO();
            dao.updatePhong(tenphong);
        }
        public DataTable SearchTheoTenPhongdathue(string tenphong)
        {
            PhongDAO dao = new PhongDAO();
            return dao.SearchTheoTenPhongdathue(tenphong);
        }
        public DataTable SearchTheoTenPhongchuathue(string tenphong)
        {
            PhongDAO dao = new PhongDAO();
            return dao.SearchTheoTenPhongchuathue(tenphong);
        }
        public void updateTTPhong(string tenphong, string loai, double dongia, string ghichu)
        {
            PhongDAO dao = new PhongDAO();
            dao.UpdateTTPhong(tenphong, loai, dongia, ghichu);
        }
        public DataTable selectDonGiaTheoLoaiPhong(string loaiphong)
        {
            PhongDAO dao = new PhongDAO();
            return dao.selectGiaPhongTheoLoaiPhong(loaiphong);
        }
        public void updateDonGiaTatCaCacPhongTheoLoaiPhong(string loaiphong, double dongia)
        {
            PhongDAO dao = new PhongDAO();
            dao.updateDonGiaTatCaCacPhongTheoLoai(loaiphong, dongia);
        }
        public void updateTTPhongAsChuaThue()
        {
            PhongDAO dao = new PhongDAO();
            dao.updateTTPhongAsChuaThue();
        }
    }
}
