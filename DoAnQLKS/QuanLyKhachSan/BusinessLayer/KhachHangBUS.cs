using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyKhachSan.DataAccess;


namespace QuanLyKhachSan.BusinessLayer
{
    public class KhachHangBUS
    {
        public void insertKhachHang(double cmt, string ten, string loaikh, string diachi, string maphieuthue)
        {
            KhachHangDAO dao = new KhachHangDAO();
            dao.insertKH(cmt, ten, loaikh, diachi, maphieuthue);
        }
        public DataTable selectKhachHang(string maphieuthue)
        {
            KhachHangDAO dao = new KhachHangDAO();
            return dao.selectKhachHang(maphieuthue);
        }
    }
}
