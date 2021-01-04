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
        }

        private void Bt_matdosd_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
        }

        void loadPie_DoanhThu()
        {
           
        }
        private void Cb_Thang_bcdoanhthu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Cb_Nam_bcdoanhthu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
        void loadpie_MatDoSD()
        {
            
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
           
        }



        private void Bt_quaylai_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
