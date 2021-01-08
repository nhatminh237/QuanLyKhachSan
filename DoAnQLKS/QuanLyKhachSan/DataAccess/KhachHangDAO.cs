using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace QuanLyKhachSan.DataAccess
{
    public class KhachHangDAO
    {
        public void insertKH(int cmt , string ten,string loaikhach,string diachi,string maphieuthue)
        {
            SqlProvider.ExecuteQuery("insert into khachhang values(" + cmt + ",N'" + ten + "','" + loaikhach + "',N'" + diachi + "','" + maphieuthue + "')");
        }
        public DataTable selectKhachHang(string maphieuthue)
        {
            return SqlProvider.ExecuteQuery("select * from khachhang where maphieuthue = '" + maphieuthue + "'");
        }
    }
}
