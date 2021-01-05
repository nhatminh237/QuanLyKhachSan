using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using QuanLyKhachSan.DTO;
using QuanLyKhachSan.BusinessLayer;


namespace QuanLyKhachSan.PresentationLayer
{
    /// <summary>
    /// Interaction logic for LapDanhMucPhong.xaml
    /// </summary>
    public partial class LapDanhMucPhong : Window
    {
        BindingList<PhongDTO> ListPhong = new BindingList<PhongDTO>();
        BindingList<PhongDTO> listtemp = new BindingList<PhongDTO>();
        public LapDanhMucPhong()
        {
            InitializeComponent();
        }
        void LoadData(DataTable data)
        {
            LbDanhMucPhong.Items.Clear();
            listtemp.Clear();
            ListPhong.Clear();
            dp_day.SelectedDate = DateTime.Now.Date;
            foreach (DataRow row in data.Rows)
            {
                ListBoxItem item = new ListBoxItem();
                item.Height = 100;
                item.Width = 150;
                item.Content = row.Field<string>(0);
                item.ToolTip = "Loại phòng: " + row.Field<string>(1) + "\n" + "Giá phòng:" + row.Field<double>(2).ToString() + " vnđ/ngay" +
                        "\n" + "Ghi chú: " + row.Field<string>(3) + "\n" + "Tình trạng phòng :" + row.Field<string>(4);

                PhongDTO phong = new PhongDTO();
                phong.TenPhong = row.Field<string>(0);
                phong.LoaiPhong = row.Field<string>(1);
                phong.DonGia = row.Field<double>(2);
                phong.GhiChu = row.Field<string>(3);
                phong.TinhTrang = row.Field<string>(4);
                listtemp.Add(phong);
                if (row.Field<string>(4) == "da thue")
                {
                    item.Background = Brushes.Red;
                }
                else
                {
                    item.Background = Brushes.Green;
                }

                LbDanhMucPhong.Items.Add(item);
            }
            Swap();
        }
        void Swap()
        {
            for (var i = 0; i < listtemp.Count; i++)
            {

                ListPhong.Add(listtemp[i]);
            }
        }
        private void Tb_timkiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhongBUS bus = new PhongBUS();
            if (tb_timkiem.Text == "")
            {
                var data = bus.SelectAllPhong();
                LoadData(data);
            }
            else
            {

                var data = bus.search(tb_timkiem.Text);
                LoadData(data);
            }
        }

       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Cập nhật lại tình trạng phòng
            PhongBUS phong = new PhongBUS();
            phong.updateTTPhongAsChuaThue();
            //--
            pn_menu.Visibility = Visibility.Hidden;
            PhongBUS bus = new PhongBUS();
            var data = bus.SelectAllPhong();
            cb_sort.SelectedIndex = 0;
        }


        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

            PhongBUS bus = new PhongBUS();
            var data = bus.SelectAllPhong();
            LoadData(data);
        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            PhongBUS bus = new PhongBUS();
            var data = bus.SortByPhongChuaThue();
            LoadData(data);
        }

        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            PhongBUS bus = new PhongBUS();
            var data = bus.SortByPhongDaThue();
            LoadData(data);
        }

        private void Bt_ThuePhong_Click(object sender, RoutedEventArgs e)
        {
            var index = 0;
            if (LbDanhMucPhong.SelectedItems.Count > 0)
            {
                for (var lcount = 0; lcount <= LbDanhMucPhong.Items.Count - 1; lcount++)
                {
                    if (LbDanhMucPhong.Items[lcount] == LbDanhMucPhong.SelectedItem)
                    {
                        index = lcount;
                        break;
                    }
                }
            }
            if (ListPhong[index].TinhTrang != "da thue")
            {
                var screen = new LapPhieuThuePhong(ListPhong[index]);
                screen.ShowDialog();
                PhongBUS bus = new PhongBUS();
                LoadData(bus.SelectAllPhong());
            }
            else
            {
                MessageBox.Show("Phòng này đã được khách thuê vui lòng chọn phòng khác", "Phòng đã đươc thuê", MessageBoxButton.OK);
            }
        }

        private void Bt_thanhtoan_Click(object sender, RoutedEventArgs e)
        {
            var index = 0;
            if (LbDanhMucPhong.SelectedItems.Count > 0)
            {
                for (var lcount = 0; lcount <= LbDanhMucPhong.Items.Count - 1; lcount++)
                {
                    if (LbDanhMucPhong.Items[lcount] == LbDanhMucPhong.SelectedItem)
                    {
                        index = lcount;
                        break;
                    }
                }
            }
            //
            bool checkThanhToan = false;
            HoaDonThanhToanBUS hd = new HoaDonThanhToanBUS();
            foreach (DataRow row in hd.KiemTraThanhToan().Rows)
            {
                if (row.Field<string>(0) == ListPhong[index].TenPhong)
                {
                    checkThanhToan = true;
                }
            }
            //Kiểm tra phòng đã thanh toán chưa

            if (ListPhong[index].TinhTrang != "chua thue" && checkThanhToan == false)
            {
                var screen = new LapHoaDonThanhToan(ListPhong[index]);
                screen.ShowDialog();
                PhongBUS bus = new PhongBUS();
                LoadData(bus.SelectAllPhong());
            }
            else if (checkThanhToan == true)
            {
                MessageBox.Show("Phòng này đã được khách thanh toán rồi !", "Phòng đã đươc thanh toán", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Phòng này chưa được khách thuê vui lòng chọn phòng khác", "Phòng chưa đươc thuê", MessageBoxButton.OK);
            }
        }

        private void Bt_dong_Click(object sender, RoutedEventArgs e)
        {
            pn_menu.Visibility = Visibility.Hidden;
        }

        private void LbDanhMucPhong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Cập nhật lại tình trạng phòng
            PhongBUS phong = new PhongBUS();
            phong.updateTTPhongAsChuaThue();
            //--
            pn_menu.Visibility = Visibility.Visible;
        }
    }
}
