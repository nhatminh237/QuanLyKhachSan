using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyKhachSan.DataAccess;

namespace QuanLyKhachSan.BusinessLayer
{ 
    public class PhieuThuePhongBUS
    {
        public void insertPhieuThuePhong(string maphieu, string ngaybd, int soluongkhach, string tenphong) {
            PhieuThuePhongDAO dao = new PhieuThuePhongDAO();
            dao.insertPhieuThue(maphieu, ngaybd, soluongkhach, tenphong);
        }
        public DataTable selectAllPhieuThuePhong()
        {
            PhieuThuePhongDAO dao = new PhieuThuePhongDAO();
            return dao.selectAllPhieuThuePhong();
        }
        public DataTable selectPhieuThuePhongGanNhat(string tenphong)
        {
            PhieuThuePhongDAO dao = new PhieuThuePhongDAO();
            return dao.selectPhieuThueGanNhat(tenphong);
        }
    }
}
