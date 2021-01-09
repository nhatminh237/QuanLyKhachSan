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
using LiveCharts.Wpf;
using LiveCharts;

namespace QuanLyKhachSan.PresentationLayer
{
    /// <summary>
    /// Interaction logic for LapBaoCaoThang.xaml
    /// </summary>
    public partial class LapBaoCaoThang : Window
    {
        public LapBaoCaoThang()
        {
            InitializeComponent();
        }


        private void Bt_doanhthu_Click(object sender, RoutedEventArgs e)
        {
            cv_matdosudung.Visibility = Visibility.Hidden;
            cv_baocaodoanhthu.Visibility = Visibility.Visible;
            bt_doanhthu.IsEnabled = false;
            bt_matdosd.IsEnabled = true;
        }

        private void Bt_matdosd_Click(object sender, RoutedEventArgs e)
        {
            cv_matdosudung.Visibility = Visibility.Visible;
            cv_baocaodoanhthu.Visibility = Visibility.Hidden;
            bt_matdosd.IsEnabled = false;
            bt_doanhthu.IsEnabled = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HoaDonThanhToanBUS bus = new HoaDonThanhToanBUS();
            foreach(DataRow row in bus.SelectNam().Rows)
            {
                Cb_Nam_bcdoanhthu.Items.Add(row.Field<int>(0).ToString());
                Cb_Nam_matdosd.Items.Add(row.Field<int>(0).ToString());
            }
            cv_matdosudung.Visibility = Visibility.Hidden;
            pie_baocaodoanhthu.Foreground = Brushes.Black;
            pie_matdosudung.Foreground = Brushes.Black;
        }

        void loadPie_DoanhThu()
        {
            var nam = Cb_Nam_bcdoanhthu.SelectedValue.ToString();
            var thang = Cb_Thang_bcdoanhthu.SelectedIndex + 1;

            HoaDonThanhToanBUS bus = new HoaDonThanhToanBUS();
            var data = bus.selectDoanhThuTheoLoaiPhong(thang, int.Parse(nam));
            List<PieSeries> listPie = new List<PieSeries>();
            foreach (DataRow row in data.Rows)
            {
                PieSeries pie = new PieSeries();
                pie.Title = "Loại phòng: "+ row.Field<string>(0);
                pie.Values = new ChartValues<double> { row.Field<double>(1) };
                pie.DataLabels = true;
                listPie.Add(pie);
            }
            foreach (PieSeries p in listPie)
            {
                pie_baocaodoanhthu.Series.Add(p);
            }
            dg_doanhthu.ItemsSource = data.AsDataView();
        }
        private void Cb_Thang_bcdoanhthu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cb_Nam_bcdoanhthu.SelectedIndex != -1)
            {
                loadPie_DoanhThu();
            }
            
        }

        private void Cb_Nam_bcdoanhthu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cb_Thang_bcdoanhthu.SelectedIndex != -1)
            {
                loadPie_DoanhThu();   
            }
        }
        void loadpie_MatDoSD()
        {
            var nam = Cb_Nam_matdosd.SelectedValue.ToString();
            var thang = Cb_Thang_matdosd.SelectedIndex + 1;

            HoaDonThanhToanBUS bus = new HoaDonThanhToanBUS();
            var data = bus.selectMatDoSuDungPhong(thang, int.Parse(nam));
            List<PieSeries> listPie = new List<PieSeries>();
            foreach (DataRow row in data.Rows)
            {
                PieSeries pie = new PieSeries();
                pie.Title = "Phòng: "+ row.Field<string>(0);
                pie.Values = new ChartValues<int> { row.Field<int>(1) };
                pie.DataLabels = true;
                listPie.Add(pie);
            }
            foreach (PieSeries p in listPie)
            {
                pie_matdosudung.Series.Add(p);
            }
            dg_matdosd.ItemsSource = data.AsDataView();
        }
        private void Cb_Thang_matdosd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cb_Nam_matdosd.SelectedIndex != -1)
            {
                loadpie_MatDoSD();   
            }
        }

        private void Cb_Nam_matdosd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cb_Thang_matdosd.SelectedIndex != -1)
            {
                loadpie_MatDoSD();
            }
        }



        private void Bt_quaylai_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
