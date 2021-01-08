using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyKhachSan.DataAccess;

namespace QuanLyKhachSan.BusinessLayer
{
    public class ThamSoBUS
    {
        public DataTable SelectThamSo()
        {
            ThamSoDAO dao = new ThamSoDAO();
            return dao.SelectThamSo();
        }
        public void updateSoLuongKhachToiDa(int soluongkhach)
        {
            ThamSoDAO dao = new ThamSoDAO();
            dao.updateSoLuongKhachToiDa(soluongkhach);
        }
        public void updateHeSoPhuThuKhachThu3(double hesophuthu)
        {
            ThamSoDAO dao = new ThamSoDAO();
            dao.updateHeSoPhuThuKhachThu3(hesophuthu);
        }
        public void updateHeSoPhuThuKhachNuocNgoai(double hesophuthu)
        {
            ThamSoDAO dao = new ThamSoDAO();
            dao.updateHeSoPhuThuKhachNuocNgoai(hesophuthu);
        }
    }
}
