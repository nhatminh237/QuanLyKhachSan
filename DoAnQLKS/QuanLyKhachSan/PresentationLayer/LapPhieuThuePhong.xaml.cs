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
    /// Interaction logic for LapPhieuThuePhong.xaml
    /// </summary>
    public partial class LapPhieuThuePhong : Window
    {
        public PhongDTO phong { get; set; }
        List<TextBox> listTB = new List<TextBox>();
        List<ComboBox> listCBB = new List<ComboBox>();
        public LapPhieuThuePhong(PhongDTO data)
        {
            InitializeComponent();
            phong = data;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (phong.TenPhong != null)
            {
                tb_tenphong.Text = phong.TenPhong;
                tb_loaiphong.Text = phong.LoaiPhong;
                tb_gia.Text = phong.DonGia.ToString();
                tb_ghichu.Text = phong.GhiChu;
            }

            ThamSoBUS bus = new ThamSoBUS();
            var data = bus.SelectThamSo();
            var a = data.Rows[0].Field<int>(0);
            int sott = 1;
            while (a != 0)
            {
                TextBlock stt = new TextBlock();
                stt.Name = "stt" + a.ToString();
                stt.Height = 30;
                stt.Width = 60;
                stt.Text = sott.ToString();
                stt.Background = Brushes.LightGray;
                sott++;
                TextBox ten = new TextBox();
                ten.Name = "ten" + a.ToString();
                ten.Height = 30;
                ten.Width = 200;
                TextBox cmt = new TextBox();
                cmt.Name = "cmt" + a.ToString();
                cmt.Height = 30;
                cmt.Width = 200;
                ComboBox loai = new ComboBox();
                loai.Name = "loai" + a.ToString();
                loai.Height = 30;
                loai.Width = 100;
                loai.Items.Add("Khach nội địa");
                loai.Items.Add("Khach nươc ngoai");
                loai.SelectedIndex = 0;
                TextBox diachi = new TextBox();
                diachi.Name = "diachi" + a.ToString();
                diachi.Height = 30;
                diachi.Width = 300;
                DockPanel dock = new DockPanel();
                dock.Name = "dpn_kh" + a.ToString();
                dock.HorizontalAlignment = HorizontalAlignment.Left;
                dock.Children.Add(stt);
                dock.Children.Add(ten);
                dock.Children.Add(cmt);
                dock.Children.Add(loai);
                dock.Children.Add(diachi);
                pn_khachhang.Children.Add(dock);
                a--;
                listTB.Add(ten);
                listTB.Add(cmt);
                listTB.Add(diachi);
                listCBB.Add(loai);
            }
            dp_ngaybd.SelectedDate = DateTime.Now.Date;
        }

        private void Bt_quaylai_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Bt_dongy_Click(object sender, RoutedEventArgs e)
        {

            PhieuThuePhongBUS bus = new PhieuThuePhongBUS();
            var data_ = bus.selectAllPhieuThuePhong();
            string MaPT = "";
            var PT = "PT001";
            if (data_.Rows.Count != 0)
            {
                foreach (DataRow row in data_.Rows)
                {
                    MaPT = row.Field<string>(0);
                }
                var so = int.Parse(MaPT.Substring(2));

                if (so < 10)
                {
                    PT = "PT00" + (so + 1).ToString();
                }
                else if (so < 100)
                {
                    PT = "PT0" + (so + 1).ToString();
                }
                else
                {
                    PT = "PT" + (so + 1).ToString();
                }
            }
            string day = dp_ngaybd.Text.Substring(0, 2);
            string month = dp_ngaybd.Text.Substring(3, 2);
            string year = dp_ngaybd.Text.Substring(6, 4);
            var sluongkhach = 0;
            foreach (TextBox tb in listTB)
            {
                if (tb.Text != "")
                {
                    sluongkhach++;
                }
                if (tb.Text == "")
                {
                    break;
                }

            }

            if (sluongkhach % 3 == 0 && sluongkhach > 0 && tb_tenphong.Text != "" && tb_loaiphong.Text != "")
            {
                var kh = new KhachHangBUS();

                List<KhachHangDTO> listkh = new List<KhachHangDTO>();
                int checkBreak = 1;
                int stt = listTB.Count / 3;
                int dem = 0;
                while (true) // chuyển dữ liệu từ textbox ten, cmt, dia chi vào list khách hàng
                {
                    KhachHangDTO khachhang = new KhachHangDTO();
                    foreach (TextBox tb in listTB)
                    {
                        dem++;
                        if (dem == checkBreak)
                        {

                            if (tb.Name == "ten" + stt.ToString())
                            {
                                khachhang.ten = tb.Text;
                            }

                            if (tb.Name == "cmt" + stt.ToString())
                            {
                                if(tb.Text.Length > 9)
                                {
                                    MessageBox.Show("Số cmt không được nhiều hơn 9 số vui lòng nhập lại", "Số cmt sai", MessageBoxButton.OK);
                                    return;
                                }
                                khachhang.cmt = int.Parse(tb.Text);
                            }
                            if (tb.Name == "diachi" + stt.ToString())
                            {
                                khachhang.diachi = tb.Text;
                            }
                            if (checkBreak % 3 == 0)
                            {
                                break;
                            }
                            checkBreak++;
                        }
                    }
                    listkh.Add(khachhang);
                    if (dem == checkBreak - 1 || dem == sluongkhach)
                    {
                        break;
                    }
                    stt--;
                    checkBreak++;
                    dem = 0;
                }
                var tempDem = 1;
                var tempChay = 0;
                foreach (KhachHangDTO khach in listkh)
                {
                    foreach (ComboBox cb in listCBB)
                    {
                        tempChay++;

                        if (tempDem == tempChay)
                        {
                            tempDem++;
                            if (cb.SelectedIndex == 0)
                            {
                                khach.loai = "khach noi dia";
                                break;
                            }
                            if (cb.SelectedIndex == 1)
                            {
                                khach.loai = "khach nuoc ngoai";
                                break;
                            }
                        }
                    }
                    tempChay = 0;
                }

                foreach (KhachHangDTO k in listkh)
                {
                    kh.insertKhachHang(k.cmt, k.ten, k.loai, k.diachi, PT); // insert vào bảng khách hàng
                }

                PhongBUS p = new PhongBUS();
                p.updatePhong(tb_tenphong.Text); // update lại tình trạng phòng 
                bus.insertPhieuThuePhong(PT, month + "/" + day + "/" + year, sluongkhach / 3, tb_tenphong.Text); // insert phiếu thuê phòng

                MessageBox.Show("Thuê phòng thành công", "Thuê thành công", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Thuê phòng không thành công, kiểm tra lại dữ liệu đã nhập", "Thuê không thành công", MessageBoxButton.OK);
            }

        }

        private void Tb_tenphong_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhongBUS bus = new PhongBUS();
            if (tb_tenphong.Text != "")
            {

                var data = bus.SearchTheoTenPhongchuathue(tb_tenphong.Text);
                if (data.Rows.Count != 0)
                {

                    tb_loaiphong.Text = data.Rows[0].Field<string>(1);
                    tb_gia.Text = data.Rows[0].Field<double>(2).ToString();
                    tb_ghichu.Text = data.Rows[0].Field<string>(3).ToString();
                }
                else
                {
                    tb_loaiphong.Text = "";
                    tb_gia.Text = "";
                    tb_ghichu.Text = "";
                }
            }
            else
            {
                tb_loaiphong.Text = "";
                tb_gia.Text = "";
                tb_ghichu.Text = "";
            }
        }

        private void Tb_tenphong_MouseLeave(object sender, MouseEventArgs e)
        {
            PhongBUS bus = new PhongBUS();
            if (tb_tenphong.Text != "")
            {

                var data = bus.SearchTheoTenPhongchuathue(tb_tenphong.Text);
                if (data.Rows.Count != 0)
                {
                    tb_tenphong.Text = data.Rows[0].Field<string>(0);
                    tb_loaiphong.Text = data.Rows[0].Field<string>(1);
                    tb_gia.Text = data.Rows[0].Field<double>(2).ToString();
                    tb_ghichu.Text = data.Rows[0].Field<string>(3).ToString();
                }
                else
                {
                    tb_tenphong.Text = "";
                    tb_loaiphong.Text = "";
                    tb_gia.Text = "";
                    tb_ghichu.Text = "";
                }
            }
            else
            {
                tb_tenphong.Text = "";
                tb_loaiphong.Text = "";
                tb_gia.Text = "";
                tb_ghichu.Text = "";
            }
        }
    }
}
