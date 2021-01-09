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
using System.Text.RegularExpressions;

namespace QuanLyKhachSan.PresentationLayer
{
    /// <summary>
    /// Interaction logic for ThayDoiQuyDinh.xaml
    /// </summary>
    public partial class ThayDoiQuyDinh : Window
    {
        public ThayDoiQuyDinh()
        {
            InitializeComponent();
        }

        private void Item_A_Selected(object sender, RoutedEventArgs e)
        {
            PhongBUS bus = new PhongBUS();
            tb_dongia.Text = bus.selectDonGiaTheoLoaiPhong("A").Rows[0].Field<double>(0).ToString();
        }

        private void Item_B_Selected(object sender, RoutedEventArgs e)
        {
            PhongBUS bus = new PhongBUS();
            tb_dongia.Text = bus.selectDonGiaTheoLoaiPhong("B").Rows[0].Field<double>(0).ToString();
        }

        private void Item_C_Selected(object sender, RoutedEventArgs e)
        {
            PhongBUS bus = new PhongBUS();
            tb_dongia.Text = bus.selectDonGiaTheoLoaiPhong("C").Rows[0].Field<double>(0).ToString();
        }

        private void Bt_ThayDoiGiaLoaiPhong_Click(object sender, RoutedEventArgs e)
        {
            PhongBUS phong = new PhongBUS();

            if (tb_dongia.Text != "")
            {
                MessageBoxResult kq = MessageBox.Show("Bạn có đồng ý sẽ thay đổi đơn giá của thất cả các phòng cùng loại", "Xác nhận", MessageBoxButton.YesNo);

                if (kq == MessageBoxResult.Yes)
                {
                    if (cb_loaiphong.SelectedIndex == 0)
                    {

                        phong.updateDonGiaTatCaCacPhongTheoLoaiPhong("A", double.Parse(tb_dongia.Text));
                        MessageBox.Show("Đã thay đổi giá phong thành công", "Thay đổi thành công", MessageBoxButton.OK);

                    }
                    if (cb_loaiphong.SelectedIndex == 1)
                    {

                        phong.updateDonGiaTatCaCacPhongTheoLoaiPhong("B", double.Parse(tb_dongia.Text));
                        MessageBox.Show("Đã thay đổi giá phong thành công", "Thay đổi thành công", MessageBoxButton.OK);

                    }
                    if (cb_loaiphong.SelectedIndex == 2)
                    {

                        phong.updateDonGiaTatCaCacPhongTheoLoaiPhong("C", double.Parse(tb_dongia.Text));
                        MessageBox.Show("Đã thay đổi giá phong thành công", "Thay đổi thành công", MessageBoxButton.OK);

                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập dữ liệu ", "Dữ liệu để trống", MessageBoxButton.OK, MessageBoxImage.Hand);
            }

        }

        private void Bt_ThayDoiSoLuongKhach_Click(object sender, RoutedEventArgs e)
        {
            if (tb_soluongkhach.Text != "")
            {
                MessageBoxResult kq = MessageBox.Show("Bạn có đồng ý sẽ thay đổi số lượng khách tối đa của tất cả các phòng không", "Xác nhận", MessageBoxButton.YesNo);

                if (kq == MessageBoxResult.Yes)
                {
                    ThamSoBUS ts = new ThamSoBUS();
                    ts.updateSoLuongKhachToiDa(int.Parse(tb_soluongkhach.Text));
                    MessageBox.Show("Đã thay đổi số lượng khách tối đa thành công", "Thay đổi thành công", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập dữ liệu ", "Dữ liệu để trống", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        private void Bt_ThayDoiHeSoKT3_Click(object sender, RoutedEventArgs e)
        {
            ThamSoBUS ts = new ThamSoBUS();
            if (tb_HeSoPTKT3.Text == ts.SelectThamSo().Rows[0].Field<double>(1).ToString())
            {
                MessageBox.Show("Giá trị vẫn chưa thay đổi, bạn cần nhập giá trị mới", "Chưa thay đổi giá trị", MessageBoxButton.OK);
            }
            else if (tb_HeSoPTKT3.Text != "")
            {
                if (",".Contains(tb_HeSoPTKT3.Text) == false)
                {
                    MessageBoxResult kq = MessageBox.Show("Bạn có đồng ý sẽ thay đổi hệ số phụ thu với khách thứ 3 không", "Xác nhận", MessageBoxButton.YesNo);

                    if (kq == MessageBoxResult.Yes)
                    {

                        ts.updateHeSoPhuThuKhachThu3(double.Parse(tb_HeSoPTKT3.Text));
                        MessageBox.Show("Đã thay đổi hệ sô phụ thu khách thứ 3 thành công", "Thay đổi thành công", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng không để ký tự ',' trong ô nhập liệu bạn có thể thay bằng '.' ", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập dữ liệu ", "Dữ liệu để trống", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        private void Bt_ThayDoiPTKNN_Click(object sender, RoutedEventArgs e)
        {
            ThamSoBUS ts = new ThamSoBUS();
            if (tb_HePTKNN.Text == ts.SelectThamSo().Rows[0].Field<double>(2).ToString())
            {
                MessageBox.Show("Giá trị vẫn chưa thay đổi, bạn cần nhập giá trị mới", "Chưa thay đổi giá trị", MessageBoxButton.OK);
            }
            else if (tb_HePTKNN.Text != "")
            {
                if (",".Contains(tb_HePTKNN.Text) == false)
                {
                    MessageBoxResult kq = MessageBox.Show("Bạn có đồng ý sẽ thay đổi hệ số phụ thu với phòng có khách nước ngoài không", "Xác nhận", MessageBoxButton.YesNo);

                    if (kq == MessageBoxResult.Yes)
                    {

                        ts.updateHeSoPhuThuKhachNuocNgoai(double.Parse(tb_HePTKNN.Text));
                        MessageBox.Show("Đã thay đổi hệ số phụ thu với khách nước ngoài thành công", "Thay đổi thành công", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng không để ký tự ',' trong ô nhập liệu bạn có thể thay bằng '.' ", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập dữ liệu ", "Dữ liệu để trống", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        private void Bt_quaylai_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ThamSoBUS ts = new ThamSoBUS();
            var thamso = ts.SelectThamSo();
            tb_soluongkhach.Text = thamso.Rows[0].Field<int>(0).ToString();
            tb_HeSoPTKT3.Text = thamso.Rows[0].Field<double>(1).ToString();
            tb_HePTKNN.Text = thamso.Rows[0].Field<double>(2).ToString();
        }

        private void Tb_dongia_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Tb_soluongkhach_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Bt_ThayDoiSoLuongKhach_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Tb_HePTKNN_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
