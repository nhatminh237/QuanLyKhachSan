using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using QuanLyKhachSan.BusinessLayer;
using QuanLyKhachSan.DataAccess;
using QuanLyKhachSan.DTO;

namespace QuanLyKhachSan.PresentationLayer
{
    /// <summary>
    /// Interaction logic for WindowMain.xaml
    /// </summary>
    public partial class WindowMain : Window
    {
        public WindowMain()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Cập nhật lại tình trạng phòng
            PhongBUS phong = new PhongBUS();
            phong.updateTTPhongAsChuaThue();
            //--
            dptb.SelectedDate = DateTime.Now.Date;
           
        }

        private void Bt_phong_Click(object sender, RoutedEventArgs e)
        {
            //Cập nhật lại tình trạng phòng
            PhongBUS phong = new PhongBUS();
            phong.updateTTPhongAsChuaThue();
            //--
            var screen = new LapDanhMucPhong();
            screen.ShowDialog();
        }

        private void Bt_thanhtoan_Click(object sender, RoutedEventArgs e)
        {
            //Cập nhật lại tình trạng phòng
            PhongBUS phong_ = new PhongBUS();
            phong_.updateTTPhongAsChuaThue();
            //--
            PhongDTO phong = new PhongDTO();
            var screen = new LapHoaDonThanhToan(phong);
            screen.ShowDialog();
        }

        private void Bt_thuephong_Click(object sender, RoutedEventArgs e)
        {
            //Cập nhật lại tình trạng phòng
            PhongBUS phong_ = new PhongBUS();
            phong_.updateTTPhongAsChuaThue();
            //--
            PhongDTO phong = new PhongDTO();
            var screen = new LapPhieuThuePhong(phong);
            screen.ShowDialog();
        }

        private void Bt_baocaothang_Click(object sender, RoutedEventArgs e)
        {
            
            var screen = new LapBaoCaoThang();
            screen.ShowDialog();
        }

        private void Bt_quydinh_Click(object sender, RoutedEventArgs e)
        {
            var screen = new ThayDoiQuyDinh();
            screen.ShowDialog();
        }
        private void Bt_chinhsua_Click(object sender, RoutedEventArgs e)
        {
               
            var screen = new TraCuuThayDoiThongTinPhong();
            screen.ShowDialog();

        }
    }
}
