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
using System.Collections;

namespace QuanLyKhachSan.PresentationLayer
{
    /// <summary>
    /// Interaction logic for TraCuuThayDoiThongTinPhong.xaml
    /// </summary>
    public partial class TraCuuThayDoiThongTinPhong : Window
    {
        public TraCuuThayDoiThongTinPhong()
        {
            InitializeComponent();
        }
        PhongBUS bus = new PhongBUS();
        DataTable data = new DataTable();
        private void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_search.Text == "")
            {
                data = bus.SelectAllPhong();
                gv_phong.ItemsSource = data.AsDataView();
            }
            else
            {

                data = bus.search(tb_search.Text);
                gv_phong.ItemsSource = data.AsDataView();
            }
        }

        private void bt_dongy_Click(object sender, RoutedEventArgs e)
        {
            if (tb_GhiChu.Text != "" && tb_dongia.Text != "")
            {
                double gia = double.Parse(tb_dongia.Text);
                string loai = "";
                if (cb_loai.SelectedIndex == 0)
                {
                    loai = "A";
                }
                if (cb_loai.SelectedIndex == 1)
                {
                    loai = "B";
                }
                if (cb_loai.SelectedIndex == 2)
                {
                    loai = "C";
                }
                bus.updateTTPhong(tb_tenphong.Text, loai, gia, tb_GhiChu.Text);
                MessageBox.Show("Cập nhật thông tin phòng thành công", "Cập nhật thành công", MessageBoxButton.OK);
            }
            data = bus.SelectAllPhong();
            gv_phong.ItemsSource = data.AsDataView();
        }

        private void Bt_quaylai_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            data = bus.SelectAllPhong();
            gv_phong.ItemsSource = data.AsDataView();

        }

        private void Tb_dongia_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        //Code tham khảo  -- Nguồn :https://stackoverflow.com/questions/3913580/get-selected-row-item-in-datagrid-wpf
        private IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }
        private void Gv_phong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var row_list = GetDataGridRows(gv_phong);
                foreach (DataGridRow single_row in row_list)
                {
                    if (single_row.IsSelected == true)
                    {

                        tb_tenphong.Text = data.Rows[single_row.GetIndex()].Field<string>(0);
                        if (data.Rows[single_row.GetIndex()].Field<string>(1) == "A")
                        {
                            cb_loai.SelectedIndex = 0;
                        }
                        if (data.Rows[single_row.GetIndex()].Field<string>(1) == "B")
                        {
                            cb_loai.SelectedIndex = 1;
                        }
                        if (data.Rows[single_row.GetIndex()].Field<string>(1) == "C")
                        {
                            cb_loai.SelectedIndex = 2;
                        }
                        tb_dongia.Text = data.Rows[single_row.GetIndex()].Field<double>(2).ToString();
                        tb_GhiChu.Text = data.Rows[single_row.GetIndex()].Field<string>(3);
                        if (data.Rows[single_row.GetIndex()].Field<string>(4) == "da thue")
                        {
                            tb_tinhtrang.Text = "Đang được thuê";
                        }
                        if (data.Rows[single_row.GetIndex()].Field<string>(4) == "chua thue")
                        {
                            tb_tinhtrang.Text = "Chưa được thuê";
                        }
                    }
                }

            }
            catch { }
        }
        //-----------
    }
}
