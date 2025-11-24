using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDT_PARKING
{
    public partial class FormThongKe : UserControl
    {
        private SqlConnection connection;
        public FormThongKe(SqlConnection conn)
        {
            InitializeComponent();
            connection = conn;
        }

        private async void FormThongKe_Load(object sender, EventArgs e)
        {
            await LoadStatistics();
        }

        private async Task LoadStatistics()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                // Customer Statistics
                lblKhachHangDangKy.Text = (await GetScalarValue("SELECT COUNT(DISTINCT MaKH) FROM TheThang")).ToString();
                lblKhachHangNgungSuDung.Text = (await GetScalarValue("SELECT COUNT(*) FROM KhachHang WHERE MaKH NOT IN (SELECT DISTINCT MaKH FROM TheThang)")).ToString();

                // Monthly Card Statistics
                lblTheThangDangSuDung.Text = (await GetScalarValue("SELECT COUNT(*) FROM TheThang WHERE TTrang = 1")).ToString();
                lblTheThangNgungSuDung.Text = (await GetScalarValue("SELECT COUNT(*) FROM TheThang WHERE TTrang = 5")).ToString();

                // Card Type Statistics
                string queryLoaiThe = @"SELECT LT.LoaiThe, COUNT(TT.MaLoaiThe) AS SoLuong
                                        FROM LoaiThe LT
                                        LEFT JOIN TheThang TT ON LT.MaLoaiThe = TT.MaLoaiThe
                                        GROUP BY LT.LoaiThe";
                using (SqlCommand cmd = new SqlCommand(queryLoaiThe, connection))
                {
                    DataTable dt = new DataTable();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(reader);
                    }
                    dgvLoaiThe.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<int> GetScalarValue(string query)
        {
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                object result = await cmd.ExecuteScalarAsync();
                return (result == DBNull.Value || result == null) ? 0 : Convert.ToInt32(result);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadStatistics();
        }
    }
}
