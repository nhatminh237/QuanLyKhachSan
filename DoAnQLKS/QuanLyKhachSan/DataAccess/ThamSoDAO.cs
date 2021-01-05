using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyKhachSan.DataAccess
{
    public class ThamSoDAO
    {
        public DataTable SelectThamSo()
        {
            return SqlProvider.ExecuteQuery("select*from thamso");
        }
        public void updateSoLuongKhachToiDa(int soluongkhach)
        {
            SqlProvider.ExecuteQuery("update thamso set soluongkhachtoidamoiphong = " + soluongkhach);
        }
        public void updateHeSoPhuThuKhachThu3(double hesophuthu)
        {
            SqlProvider.ExecuteQuery("update thamso set phuthukhachthu3 = " + hesophuthu);
        }
        public void updateHeSoPhuThuKhachNuocNgoai(double hesophuthu)
        {
            SqlProvider.ExecuteQuery("update thamso set phuthukhachnuocngoai = " + hesophuthu);
        }
    }
}
