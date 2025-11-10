using Microsoft.Office.Interop.Access.Dao;
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
    public partial class FormCaiDat : Form
    {

        private SqlConnection connection;
        private SqlConnection _connection;

      
        public FormCaiDat()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // LẤY THÔNG TIN KẾT NỐI TỪ GIAO DIỆN NGƯỜI DÙNG
            string serverAddress = txtServer.Text;
            string databaseName = txtDatabase.Text;
            string folder = txtFolder.Text;
            string uid = txtUsername.Text;
            string password = txtPassword.Text;

            // TẠO CHUỖI KẾT NỐI DỰA TRÊN THÔNG TIN NHẬP VÀO
            string connectionString;
            if (string.IsNullOrWhiteSpace(uid))
            {
                connectionString = $"Server={serverAddress};Database={databaseName};Integrated Security=True;TrustServerCertificate=True;";
            }
            else
            {
                connectionString = $"Server={serverAddress};Database={databaseName};User ID={uid};Password={password};TrustServerCertificate=True;";
            }

            // THỬ KẾT NỐI ĐẾN CƠ SỞ DỮ LIỆU
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                MessageBox.Show("Kết nối dữ liệu thành công!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // LƯU LẠI CÁC THÔNG TIN KẾT NỐI ĐẾN CƠ SỞ DỮ LIỆU
                Properties.Settings.Default.ServerAddress = txtServer.Text;
                Properties.Settings.Default.DatabaseName = txtDatabase.Text;
                Properties.Settings.Default.Username = txtUsername.Text;
                Properties.Settings.Default.SharedFolder = txtFolder.Text;
                Properties.Settings.Default.Password = password;
                Properties.Settings.Default.Save();
                EnsureItKhaTableExists();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // TẠO BẢNG ITKHA NẾU CHƯA TỒN TẠI TRONG CƠ SỞ DỮ LIỆU SAU KHI KẾT NỐI THÀNH CÔNG
        private void EnsureItKhaTableExists()
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Không có kết nối cơ sở dữ liệu. Vui lòng kết nối trước.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string checkAndCreateTable = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ITKHA' AND xtype='U')
            BEGIN
                CREATE TABLE [dbo].[ITKHA] (
                    STTThe     VARCHAR(10)   NOT NULL,
                    CardID     VARCHAR(20)   NOT NULL,
                    NgayRa     DATETIME      NOT NULL,
                    ThoiGianRa NCHAR(10)     NOT NULL,
                    MaLoaiThe  VARCHAR(10)   NOT NULL,
                    GiaTien    MONEY         NOT NULL,
                    username   VARCHAR(20)   NOT NULL,
                    IDXe       VARCHAR(50)   NOT NULL,
                    IDMat      VARCHAR(50)   NOT NULL,
                    GioRa      NCHAR(10)     NOT NULL,
                    cong       VARCHAR(50)   NULL,
                    soxe       VARCHAR(50)   NULL,
                    soxera     VARCHAR(50)   NOT NULL,
                    Thao_Tac   NVARCHAR(20)  NOT NULL,
                    Ngay_Thuc_Hien DATETIME NOT NULL
                )
            END";

            using (SqlCommand cmd = new SqlCommand(checkAndCreateTable, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private void InitializeDatabaseConnection()
        {
            try
            {
                string serverAddress = txtServer.Text;
                string databaseName = txtDatabase.Text;
                string uid = txtUsername.Text;
                string password = txtPassword.Text;
                string connectionString;
                if (string.IsNullOrWhiteSpace(uid))
                {
                    connectionString = $"Server={serverAddress};Database={databaseName};Integrated Security=True;TrustServerCertificate=True;";
                }
                else
                {
                    connectionString = $"Server={serverAddress};Database={databaseName};User ID={uid};Password={password};TrustServerCertificate=True;";
                }

                _connection = new SqlConnection(connectionString);
                _connection.Open();
                MessageBox.Show("Kết nối cơ sở dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}\n\nVui lòng kiểm tra lại chuỗi kết nối.", "Lỗi Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormCaiDat_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            this.Hide();
            formMain.Show();
        }
    }
}
