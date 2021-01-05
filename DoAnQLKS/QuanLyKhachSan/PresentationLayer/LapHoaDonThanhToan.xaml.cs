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
using QuanLyKhachSan.DTO;


namespace QuanLyKhachSan.PresentationLayer
{
    /// <summary>
    /// Interaction logic for LapHoaDonThanhToan.xaml
    /// </summary>
    public partial class LapHoaDonThanhToan : Window
    {
        public PhongDTO phong { get; set; }
        public LapHoaDonThanhToan(PhongDTO data)
        {
            InitializeComponent();
            phong = data;
        }

        private void Tb_tenphong_MouseLeave(object sender, MouseEventArgs e)
        {
            PhongBUS bus = new PhongBUS();
            if (tb_tenphong.Text != "")
            {

                var data = bus.SearchTheoTenPhongdathue(tb_tenphong.Text);
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

        private void Tb_tenphong_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhongBUS bus = new PhongBUS();
            if (tb_tenphong.Text != "")
            {

                var data = bus.SearchTheoTenPhongdathue(tb_tenphong.Text);
                if (data.Rows.Count != 0)
                {
                    PhieuThuePhongBUS phieuthue = new PhieuThuePhongBUS();
                    var dt = phieuthue.selectPhieuThuePhongGanNhat(data.Rows[0].Field<string>(0));

                    if (dt.Rows.Count != 0)
                    {
                        dp_ngaybd.SelectedDate = dt.Rows[0].Field<DateTime>(1);
                        KhachHangBUS khachhang = new KhachHangBUS();
                        if (khachhang.selectKhachHang(dt.Rows[0].Field<string>(0)).Rows.Count != 0)
                        {
                            gv_khachhang.ItemsSource = khachhang.selectKhachHang(dt.Rows[0].Field<string>(0)).AsDataView();
                        }
                    }
                    tb_loaiphong.Text = data.Rows[0].Field<string>(1);
                    tb_gia.Text = data.Rows[0].Field<double>(2).ToString();
                    tb_ghichu.Text = data.Rows[0].Field<string>(3).ToString();
                    dp_ngaythanhtoan.SelectedDate = DateTime.Now.Date;
                }
                else
                {
                    dp_ngaybd.SelectedDate = DateTime.Now.Date;
                    gv_khachhang.ItemsSource = null;
                    tb_loaiphong.Text = "";
                    tb_gia.Text = "";
                    tb_ghichu.Text = "";
                }
            }
            else
            {
                dp_ngaybd.SelectedDate = DateTime.Now.Date;
                gv_khachhang.ItemsSource = null;
                tb_loaiphong.Text = "";
                tb_gia.Text = "";
                tb_ghichu.Text = "";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (phong.TenPhong != null)
            {
                tb_tenphong.Text = phong.TenPhong;
                tb_loaiphong.Text = phong.LoaiPhong;
                tb_gia.Text = phong.DonGia.ToString();
                tb_ghichu.Text = phong.GhiChu;
                dp_ngaythanhtoan.SelectedDate = DateTime.Now.Date;
            }
        }

        private void Dp_ngaythanhtoan_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TimeSpan time = new TimeSpan();
            time = Convert.ToDateTime(dp_ngaythanhtoan.Text) - Convert.ToDateTime(dp_ngaybd.Text);
            int day = time.Days;

            if (day <= 0 || tb_tenphong.Text == "" || tb_loaiphong.Text == "")
            {
                MessageBox.Show("Chọn ngày thanh toán không hợp lệ hoặc dữ liệu trống, vui lòng chọn lại ngày khác và kiểm tra dữ liệu", "Chọn ngày không hợp lệ", MessageBoxButton.OK);
                dp_ngaythanhtoan.SelectedDate = DateTime.Now.Date.AddDays(1);
            }
            else
            {
                tb_songaythue.Text = day.ToString();
                KhachHangBUS kh = new KhachHangBUS();
                PhieuThuePhongBUS pt = new PhieuThuePhongBUS();
                var khachhang = kh.selectKhachHang(pt.selectPhieuThuePhongGanNhat(tb_tenphong.Text).Rows[0].Field<string>(0));
                int SoKhachNuocNgoai = 0;
                int Soluongkhach = 0;
                foreach (DataRow row in khachhang.Rows)
                {
                    if (row.Field<string>(2) == "khach nuoc ngoai")
                    {
                        SoKhachNuocNgoai++;
                    }
                    Soluongkhach++;
                }
                ThamSoBUS ts = new ThamSoBUS();
                var thamso = ts.SelectThamSo();
                tb_tienphong.Text = (double.Parse(tb_gia.Text) * day).ToString();
                if (SoKhachNuocNgoai > 0 && Soluongkhach >= thamso.Rows[0].Field<int>(0))
                {
                    tb_phuthu.Text = ((double.Parse(tb_tienphong.Text) * thamso.Rows[0].Field<double>(2) - double.Parse(tb_tienphong.Text)) + double.Parse(tb_tienphong.Text) * thamso.Rows[0].Field<double>(1)).ToString();
                }
                if (SoKhachNuocNgoai == 0 && Soluongkhach >= thamso.Rows[0].Field<int>(0))
                {
                    tb_phuthu.Text = (double.Parse(tb_tienphong.Text) * thamso.Rows[0].Field<double>(1)).ToString();
                }
                if (SoKhachNuocNgoai > 0 && Soluongkhach < thamso.Rows[0].Field<int>(0))
                {
                    tb_phuthu.Text = ((double.Parse(tb_tienphong.Text) * thamso.Rows[0].Field<double>(2) - double.Parse(tb_tienphong.Text))).ToString();
                }
                if (SoKhachNuocNgoai == 0 && Soluongkhach < thamso.Rows[0].Field<int>(0))
                {
                    tb_phuthu.Text = "0";
                }
                tb_tongtien.Text = (double.Parse(tb_phuthu.Text) + double.Parse(tb_tienphong.Text)).ToString();
                tb_tienchu.Text = DocTienBangChu(long.Parse(tb_tongtien.Text), " VNĐ");
            }
        }
        private string[] ChuSo = new string[10] { " không", " một", " hai", " ba", " bốn", " năm", " sáu", " bẩy", " tám", " chín" };
        private string[] Tien = new string[6] { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };
        // Hàm đọc số thành chữ ------- nguồn bài viết: Dngaz.com ----------
        public string DocTienBangChu(long SoTien, string strTail)
        {
            int lan, i;
            long so;
            string KetQua = "", tmp = "";
            int[] ViTri = new int[6];
            if (SoTien < 0) return "Số tiền âm !";
            if (SoTien == 0) return "Không đồng !";
            if (SoTien > 0)
            {
                so = SoTien;
            }
            else
            {
                so = -SoTien;
            }
            //Kiểm tra số quá lớn
            if (SoTien > 8999999999999999)
            {
                SoTien = 0;
                return "";
            }
            ViTri[5] = (int)(so / 1000000000000000);
            so = so - long.Parse(ViTri[5].ToString()) * 1000000000000000;
            ViTri[4] = (int)(so / 1000000000000);
            so = so - long.Parse(ViTri[4].ToString()) * +1000000000000;
            ViTri[3] = (int)(so / 1000000000);
            so = so - long.Parse(ViTri[3].ToString()) * 1000000000;
            ViTri[2] = (int)(so / 1000000);
            ViTri[1] = (int)((so % 1000000) / 1000);
            ViTri[0] = (int)(so % 1000);
            if (ViTri[5] > 0)
            {
                lan = 5;
            }
            else if (ViTri[4] > 0)
            {
                lan = 4;
            }
            else if (ViTri[3] > 0)
            {
                lan = 3;
            }
            else if (ViTri[2] > 0)
            {
                lan = 2;
            }
            else if (ViTri[1] > 0)
            {
                lan = 1;
            }
            else
            {
                lan = 0;
            }
            for (i = lan; i >= 0; i--)
            {
                tmp = DocSo3ChuSo(ViTri[i]);
                KetQua += tmp;
                if (ViTri[i] != 0) KetQua += Tien[i];
                if ((i > 0) && (!string.IsNullOrEmpty(tmp))) KetQua += ",";//&& (!string.IsNullOrEmpty(tmp))
            }
            if (KetQua.Substring(KetQua.Length - 1, 1) == ",") KetQua = KetQua.Substring(0, KetQua.Length - 1);
            KetQua = KetQua.Trim() + strTail;
            return KetQua.Substring(0, 1).ToUpper() + KetQua.Substring(1);
        }
        private string DocSo3ChuSo(int baso)
        {
            int tram, chuc, donvi;
            string KetQua = "";
            tram = (int)(baso / 100);
            chuc = (int)((baso % 100) / 10);
            donvi = baso % 10;
            if ((tram == 0) && (chuc == 0) && (donvi == 0)) return "";
            if (tram != 0)
            {
                KetQua += ChuSo[tram] + " trăm";
                if ((chuc == 0) && (donvi != 0)) KetQua += " linh";
            }
            if ((chuc != 0) && (chuc != 1))
            {
                KetQua += ChuSo[chuc] + " mươi";
                if ((chuc == 0) && (donvi != 0)) KetQua = KetQua + " linh";
            }
            if (chuc == 1) KetQua += " mười";
            switch (donvi)
            {
                case 1:
                    if ((chuc != 0) && (chuc != 1))
                    {
                        KetQua += " mốt";
                    }
                    else
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
                case 5:
                    if (chuc == 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    else
                    {
                        KetQua += " lăm";
                    }
                    break;
                default:
                    if (donvi != 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
            }
            return KetQua;
        }

        //---------------------------

        private void Bt_quaylai_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Bt_dongy_Click(object sender, RoutedEventArgs e)
        {
            bool checkThanhToan = false;
            HoaDonThanhToanBUS bus = new HoaDonThanhToanBUS();
            foreach (DataRow row in bus.KiemTraThanhToan().Rows)
            {
                if (row.Field<string>(0) == tb_tenphong.Text)
                {
                    checkThanhToan = true;
                }
            }
            if (checkThanhToan == false)
            {
                if (tb_tongtien.Text != "")
                {
                    var data_ = bus.selectAllHoaDon();
                    string MaHd = "";
                    var HD = "HD001";
                    if (data_.Rows.Count != 0)
                    {
                        foreach (DataRow row in data_.Rows)
                        {
                            MaHd = row.Field<string>(0);
                        }
                        var so = int.Parse(MaHd.Substring(2));

                        if (so < 10)
                        {
                            HD = "HD00" + (so + 1).ToString();
                        }
                        else if (so < 100)
                        {
                            HD = "HD0" + (so + 1).ToString();
                        }
                        else
                        {
                            HD = "HD" + (so + 1).ToString();
                        }
                    }
                    DateTime? date = dp_ngaythanhtoan.SelectedDate;
                    string month = date.Value.Month.ToString();
                    string day = date.Value.Day.ToString();
                    string year = date.Value.Year.ToString();
                    PhieuThuePhongBUS pt = new PhieuThuePhongBUS();
                    var mapt = pt.selectPhieuThuePhongGanNhat(tb_tenphong.Text);
                    bus.insertHoaDon(HD, tb_tenphong.Text, month + "/" + day + "/" + year, int.Parse(tb_songaythue.Text), double.Parse(tb_tienphong.Text), double.Parse(tb_phuthu.Text), double.Parse(tb_tongtien.Text), mapt.Rows[0].Field<string>(0));
                    //Cập nhật lại tình trạng phòng
                    PhongBUS phong = new PhongBUS();
                    phong.updateTTPhongAsChuaThue();
                    MessageBox.Show("Đã thanh toán phòng thành công", "Thanh toán thành công", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Thanh toán không thành công vui lòng kiểm tra lại dữ liệu", "Thanh toán không thành công", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Phòng này đã được khách thanh toán trước dó ! ", "Phòng đã được thanh toán trươc đó", MessageBoxButton.OK);
            }
            this.Close();
        }
        
    }

}
