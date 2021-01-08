using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyKhachSan.DataAccess
{
    public class PhieuThuePhongDAO
    {
        public void insertPhieuThue(string maphieu , string ngaybd,int soluongkhach, string tenphong)
        {
            SqlProvider.ExecuteQuery("insert into phieuthuephong values ('" + maphieu + "','" + ngaybd + "'," + soluongkhach + ",'" + tenphong + "')");
        }
        public DataTable selectAllPhieuThuePhong()
        {
            return SqlProvider.ExecuteQuery("select * from phieuthuephong");
        }
        public DataTable selectPhieuThueGanNhat(string tenphong)
        {
            return SqlProvider.ExecuteQuery("select pt.* from phong p join PHIEUTHUEPHONG pt on p.tenphong = pt.phong where p.tenphong = '"+tenphong+"' and DATEDIFF(DAY, pt.ngaybd, getdate()) <= all(select DATEDIFF(DAY, pt.ngaybd, getdate()) from phong p join PHIEUTHUEPHONG pt on p.tenphong = pt.phong where p.tenphong = '"+tenphong+"')");
        }
    }
}
