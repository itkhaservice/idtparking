using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace IDT_PARKING
{
    public partial class FormMain : Form
    {
        // KHAI BÁO CÁC BIẾN LƯU TỪ FORM CÀI ĐẶT
        public string txtServer = Properties.Settings.Default.ServerAddress;
        public string txtDatabase = Properties.Settings.Default.DatabaseName;
        public string txtUsername = Properties.Settings.Default.Username;
        public string txtPassword = Properties.Settings.Default.Password;

        // KHAI BÁO HẰNG SỐ CỦA TAB DOANH THU
        private const string CORRECT_PASSWORD = "9999";
        public const string ALL_MATERIAL_TYPE = "ALL";
        public const string PRICE_COLUMN_NAME = "PRICE";
        private SqlConnection connection;
        private string _selectedMaKH = string.Empty;
        private string _selectedCardID = string.Empty;
        private int _selectedSTT = 0;// To store the MaKH of the selected customer
        private ImageViewerForm imageViewerInstance = null;
        private Guna.UI2.WinForms.Guna2PictureBox lastClickedPictureBox = null;
        //private SqlConnection _connection;
        //private DataTable _currentQueryResult;

        public FormMain()
        {
            InitializeComponent();
            txtQuerry_CaiDat.Text = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE';";
            this.tabControl.Selecting += new TabControlCancelEventHandler(this.tabControl_Selecting);
            SetupAndConnect();
            btnConnect_Main.Click += new System.EventHandler(this.btnConnect_Main_Click);
            this.tabControl.SelectedTab = tabCaiDat;
            
            DoanhThu_Load();
            dgvXeRa.KeyDown += dgvXeRa_KeyDown;


            ptHinhMatRa.Click += pictureBox_Click;
            ptHinhXeRa.Click += pictureBox_Click;
            ptHinhMatVao.Click += pictureBox_Click;
            ptHinhXeVao.Click += pictureBox_Click;

            ptHinhMatVaoVao.Click += pictureBox_Click;
            ptHinhXeVaoVao.Click += pictureBox_Click;

            txtSoTheXeRa.KeyDown += txtSoTheXeRa_KeyDown;
            txtBienSoXeRa.KeyDown += txtBienSoXeRa_KeyDown;

            dgvXeVao.CellClick += dgvXeVao_CellClick;
            dgvXeVao.KeyDown += dgvXeVao_KeyDown;
            txtSoTheXeVao.KeyDown += txtSoTheXeVao_KeyDown;
            txtSoTheXeVao.KeyDown += txtSoTheXeVao_KeyDown;
            txtBienSoXeVao.KeyDown += txtBienSoXeVao_KeyDown;

            toolTip1.Active = true;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);

            // Sự kiện cho Tab Khách hàng
            dgvKhachHang_KH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_KH_CellClick);
            txtTimTen_KH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchKhachHang_KeyDown);
            txtTimDVDC_KH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchKhachHang_KeyDown);
            txtTimBS_KH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchKhachHang_KeyDown);

            btnThem_KH.Click += new System.EventHandler(this.btnThem_KH_Click);
            btnUpdate_KH.Click += new System.EventHandler(this.btnUpdate_KH_Click);
            btnExportExcel_KH.Click += new System.EventHandler(this.btnExportExcel_KH_Click);
            btnUpdateBienSo_KH.Click += new System.EventHandler(this.btnUpdateBienSo_KH_Click);
            btnUpdateLoaiThe_KH.Click += new System.EventHandler(this.btnUpdateLoaiThe_KH_Click);
            btnUpdateDate_KH.Click += new System.EventHandler(this.btnUpdateDate_KH_Click);

            rbSoThe_TT.Checked = true;
            txtThe_TT.KeyDown += new KeyEventHandler(this.txtThe_TT_KeyDown);
            rbSoThe_TT.CheckedChanged += new EventHandler(this.rbSoThe_TT_CheckedChanged);
            rbBienSo_TT.CheckedChanged += new EventHandler(this.rbBienSo_TT_CheckedChanged);
            cbExDate_TT.CheckedChanged += new EventHandler(this.cbExDate_TT_CheckedChanged);
            cbKhoa_TT.CheckedChanged += new EventHandler(this.cbKhoa_TT_CheckedChanged);

            //LoadKhachHangData(); // Initial load for KhachHang
            //LoadTheThangData(); // Initial load for TheThang
            //LoadTheTrongData(); // Initial load for TheTrong

            // Sự kiện cho tìm kiếm thẻ trống
            txtThe_TTr.KeyDown += new KeyEventHandler(this.txtThe_TTr_KeyDown);

            // Set custom format for Guna2DateTimePicker controls
            dtTu_TT.Format = DateTimePickerFormat.Custom;
            dtTu_TT.CustomFormat = "dd-MM-yyyy";
            dtTu_TT.ShowUpDown = false; // Enable direct typing
            dtDen_TT.Format = DateTimePickerFormat.Custom;
            dtDen_TT.CustomFormat = "dd-MM-yyyy";
            dtDen_TT.ShowUpDown = false; // Enable direct typing
            dtTu_TTr.Format = DateTimePickerFormat.Custom;
            dtTu_TTr.CustomFormat = "dd-MM-yyyy";
            dtDen_TTr.Format = DateTimePickerFormat.Custom;
            dtDen_TTr.CustomFormat = "dd-MM-yyyy";

            txtQuerry_CaiDat.KeyDown += new KeyEventHandler(txtQuerry_CaiDat_KeyDown);
        }

        private void SetTabStates(bool enabled)
        {
            foreach (TabPage tab in tabControl.TabPages)
            {
                if (tab == tabCaiDat) continue; // Always keep settings tab enabled

                tab.Enabled = enabled; // This enables/disables controls within the tab
                // For Guna2TabControl, disabling the TabPage itself might not visually disable the header.
                // We'll rely on the Selecting event to prevent navigation.
            }
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // If the connection is not open and the selected tab is not the settings tab, cancel the selection
            if ((connection == null || connection.State != ConnectionState.Open) && e.TabPage != tabCaiDat)
            {
                e.Cancel = true;
                MessageBox.Show("Vui lòng kết nối cơ sở dữ liệu trước khi truy cập các chức năng khác.", "Yêu cầu kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetupAndConnect()
        {
            SetTabStates(false); // Initially disable all tabs except settings

            // Check if settings are already saved
            //if (string.IsNullOrEmpty(Properties.Settings.Default.ServerAddress))
            //{
            //    // Populate textboxes from settings
            //    txtServer_Main.Text = Properties.Settings.Default.ServerAddress;
            //    txtDatabase_Main.Text = Properties.Settings.Default.DatabaseName;
            //    txtUsername_Main.Text = Properties.Settings.Default.Username;
            //    txtPassword_Main.Text = Properties.Settings.Default.Password;
            //    txtFolder_Main.Text = Properties.Settings.Default.SharedFolder;

            //    // Try to connect automatically
            //    try
            //    {
            //        InitializeDatabaseConnection();
            //        if (connection.State != ConnectionState.Open)
            //        {
            //            connection.Open();
            //        }
            //        // If connection is successful, switch to the main tab and enable other tabs
            //        SetTabStates(true);
            //        tabControl.SelectedTab = tabXeVao;
            //    }
            //    catch (Exception ex)
            //    {
            //        // If auto-connect fails, show error and stay on settings tab, keep other tabs disabled
            //        MessageBox.Show($"Tự động kết nối thất bại: {ex.Message}\nVui lòng kiểm tra lại cài đặt.", "Lỗi Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        tabControl.SelectedTab = tabCaiDat;
            //        SetTabStates(false);
            //    }
            //}
            //else
            //{
            //    // First time launch: clear textboxes and stay on settings tab, keep other tabs disabled
            //    txtServer_Main.Text = "";
            //    txtDatabase_Main.Text = "";
            //    txtUsername_Main.Text = "";
            //    txtPassword_Main.Text = "";
            //    txtFolder_Main.Text = "";
            //    tabControl.SelectedTab = tabCaiDat;
            //    SetTabStates(false);
            //}
        }

        private void btnConnect_Main_Click(object sender, EventArgs e)
        {
            // LẤY THÔNG TIN KẾT NỐI TỪ GIAO DIỆN NGƯỜI DÙNG
            string serverAddress = txtServer_Main.Text;
            string databaseName = txtDatabase_Main.Text;
            string folder = txtFolder_Main.Text;
            string uid = txtUsername_Main.Text;
            string password = txtPassword_Main.Text;

            // KIỂM TRA XEM CÁC TRƯỜNG BẮT BUỘC CÓ BỊ TRỐNG KHÔNG
            if (string.IsNullOrWhiteSpace(serverAddress) || string.IsNullOrWhiteSpace(databaseName))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Server và Database.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng thực hiện nếu thiếu thông tin
            }

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
                //MessageBox.Show("Kết nối dữ liệu thành công!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // LƯU LẠI CÁC THÔNG TIN KẾT NỐI ĐẾN CƠ SỞ DỮ LIỆU
                Properties.Settings.Default.ServerAddress = txtServer_Main.Text;
                Properties.Settings.Default.DatabaseName = txtDatabase_Main.Text;
                Properties.Settings.Default.Username = txtUsername_Main.Text;
                Properties.Settings.Default.SharedFolder = txtFolder_Main.Text;
                Properties.Settings.Default.Password = txtPassword_Main.Text;
                Properties.Settings.Default.Save();
                EnsureItKhaTableExists();

                // Chuyển sang tab chính và kích hoạt các tab khác
                SetTabStates(true);
                tabControl.SelectedTab = tabXeVao;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetTabStates(false); // Keep other tabs disabled on connection failure
            }
        }

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


        private void txtSoTheXeVao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLocXeVao.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBienSoXeVao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLocXeVao.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void dgvXeVao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    if (dgvXeVao.CurrentRow != null)
                    {
                        LoadImagesFromXeVaoRow(dgvXeVao.CurrentRow);
                    }
                }));
            }
        }

        private void txtSoTheXeRa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLocXeRa.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBienSoXeRa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLocXeRa.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        #region KHÁCH HÀNG

        private void LoadKhachHangData()
        {
            // InitializeDatabaseConnection(); // Đảm bảo kết nối được mở

            var whereClauses = new List<string>();
            var parameters = new List<SqlParameter>();

            string baseQuery = "SELECT MaKH AS 'Mã KH', hoten AS 'Họ tên', DonVi AS 'Đơn vị', DiaChi AS 'Địa chỉ', dienthoai AS 'Điện thoại', hopdong AS 'Biển số', chungloai AS 'Hiệu xe', hinhanh AS 'Hình ảnh' FROM KhachHang";

            if (!string.IsNullOrWhiteSpace(txtTimTen_KH.Text))
            {
                whereClauses.Add("hoten LIKE @hoten");
                parameters.Add(new SqlParameter("@hoten", "%" + txtTimTen_KH.Text + "%"));
            }

            if (!string.IsNullOrWhiteSpace(txtTimDVDC_KH.Text))
            {
                whereClauses.Add("(DonVi LIKE @dvdc OR DiaChi LIKE @dvdc)");
                parameters.Add(new SqlParameter("@dvdc", "%" + txtTimDVDC_KH.Text + "%"));
            }

            if (!string.IsNullOrWhiteSpace(txtTimBS_KH.Text))
            {
                whereClauses.Add("hopdong LIKE @hopdong");
                parameters.Add(new SqlParameter("@hopdong", "%" + txtTimBS_KH.Text + "%"));
            }

            string finalQuery = baseQuery;
            if (whereClauses.Any())
            {
                finalQuery += " WHERE " + string.Join(" AND ", whereClauses);
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(finalQuery, connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvKhachHang_KH.DataSource = dataTable;

                        if (dgvKhachHang_KH.Columns.Contains("Hình ảnh"))
                        {
                            dgvKhachHang_KH.Columns["Hình ảnh"].Visible = false;
                        }
                        dgvKhachHang_KH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTheThangData(string searchTerm = "", bool searchByCardID = true, bool showExpired = false, bool showLocked = false, string maKHFilter = "")
        {
            // InitializeDatabaseConnection(); // Ensure connection is open

            var whereClauses = new List<string>();
            var parameters = new List<SqlParameter>();

            string query = @"
                SELECT
                    tt.SoTT AS 'Số thẻ',
                    tt.soxe AS 'Biển số',
                    kh.DonVi AS 'Đơn vị',
                    kh.DiaChi AS 'Địa chỉ',
                    kh.hoten AS 'Họ tên',
                    tt.CardID AS 'Mã thẻ',
                    tt.MaLoaiThe AS 'Loại thẻ',
                    tt.NgayBD AS 'Ngày bắt đầu',
                    tt.NgayKT AS 'Ngày kết thúc',
                    tt.nguoicap AS 'Người cấp',
                    tt.giatien AS 'Giá tiền',
                    tt.datcoc AS 'Đặt cọc',
                    kh.dienthoai AS 'Điện thoại',
                    kh.chungloai AS 'Chủng loại'
                FROM
                    TheThang tt
                INNER JOIN
                    KhachHang kh ON tt.MaKH = kh.MaKH";

            // Add MaKH filter if provided
            if (!string.IsNullOrEmpty(maKHFilter))
            {
                whereClauses.Add("tt.MaKH = @maKHFilter");
                parameters.Add(new SqlParameter("@maKHFilter", maKHFilter));
            }

            // Conditional TTrang filter based on showLocked
            if (showLocked)
            {
                whereClauses.Add("tt.TTrang = 5");
            }
            else
            {
                whereClauses.Add("tt.TTrang = 1");
            }

            // Conditional NgayKT filter based on showExpired
            if (showExpired)
            {
                whereClauses.Add("tt.NgayKT < GETDATE()");
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                if (searchByCardID)
                {
                    whereClauses.Add("tt.SoTT LIKE @searchTerm");
                }
                else // Search by license plate
                {
                    whereClauses.Add("tt.soxe LIKE @searchTerm");
                }
                parameters.Add(new SqlParameter("@searchTerm", "%" + searchTerm + "%"));
            }

            if (whereClauses.Any())
            {
                query += " WHERE " + string.Join(" AND ", whereClauses);
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvTheThang_KH.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu thẻ tháng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhachHang_KH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang_KH.Rows[e.RowIndex];

                _selectedMaKH = row.Cells["Mã KH"].Value?.ToString(); // Store MaKH in the private variable
                txtHoTen_KH.Text = row.Cells["Họ tên"].Value?.ToString();
                txtDiaChi_KH.Text = row.Cells["Địa chỉ"].Value?.ToString();
                txtDonVi_KH.Text = row.Cells["Đơn vị"].Value?.ToString();
                txtBienSo_KH.Text = row.Cells["Biển số"].Value?.ToString();
                txtHieuXe_KH.Text = row.Cells["Hiệu xe"].Value?.ToString();
                txtDienThoai_KH.Text = row.Cells["Điện thoại"].Value?.ToString();

                // Load monthly card data for the selected customer
                LoadTheThangData(maKHFilter: _selectedMaKH);

                // If there's data in dgvTheThang_KH, select the first row and populate details
                if (dgvTheThang_KH.Rows.Count > 0)
                {
                    dgvTheThang_KH.CurrentCell = dgvTheThang_KH.Rows[0].Cells[0];
                    dgvTheThang_KH.Rows[0].Selected = true;
                    PopulateTheThangDetails(dgvTheThang_KH.Rows[0]);
                }
                else
                {
                    // Clear the monthly card detail fields if no cards found
                    dtTu_TT.Value = DateTime.Now;
                    dtDen_TT.Value = DateTime.Now;
                    txtBienSo_TT.Clear();
                    cbbLoai_TTr.SelectedIndex = -1; // Clear selection
                }
            }
        }

        private void PopulateTheThangDetails(DataGridViewRow row)
        {
            // Populate dtTu_TT with "Ngày bắt đầu"
            if (row.Cells["Ngày bắt đầu"].Value != null && DateTime.TryParse(row.Cells["Ngày bắt đầu"].Value.ToString(), out DateTime ngayBD))
            {
                dtTu_TT.Value = ngayBD;
            }
            else
            {
                dtTu_TT.Value = DateTime.Now; // Default to current date if parsing fails
            }

            // Populate dtDen_TT with "Ngày kết thúc"
            if (row.Cells["Ngày kết thúc"].Value != null && DateTime.TryParse(row.Cells["Ngày kết thúc"].Value.ToString(), out DateTime ngayKT))
            {
                dtDen_TT.Value = ngayKT;
            }
            else
            {
                dtDen_TT.Value = DateTime.Now; // Default to current date if parsing fails
            }

            // Populate txtBienSo_TT with "Biển số"
            txtBienSo_TT.Text = row.Cells["Biển số"].Value?.ToString();

            // Populate cbbLoai_TTr and cbbLoaiThe_TT with "Loại thẻ"
            string maLoaiThe = row.Cells["Loại thẻ"].Value?.ToString();
            if (!string.IsNullOrEmpty(maLoaiThe))
            {
                cbbLoai_TTr.SelectedValue = maLoaiThe;
                cbbLoaiThe_TT.SelectedValue = maLoaiThe;
            }
            else
            {
                cbbLoai_TTr.SelectedIndex = -1; // Clear selection
                cbbLoaiThe_TT.SelectedIndex = -1; // Clear selection
            }
        }

        private void dgvTheTrong_KH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTheTrong_KH.Rows[e.RowIndex];

                _selectedCardID = row.Cells["Mã thẻ"].Value?.ToString();
                _selectedSTT = Convert.ToInt32(row.Cells["Số thẻ"].Value);
            }
        }

        private void dgvTheThang_KH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTheThang_KH.Rows[e.RowIndex];
                PopulateTheThangDetails(row);
            }
        }

        private DataGridViewRow GetSelectedTheThangRow()
        {
            if (dgvTheThang_KH.CurrentRow == null || dgvTheThang_KH.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn một thẻ tháng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return dgvTheThang_KH.CurrentRow;
        }

        private void btnUpdateBienSo_KH_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = GetSelectedTheThangRow();
            if (selectedRow == null) return;

            string cardID = selectedRow.Cells["Mã thẻ"].Value?.ToString();
            string soTT = selectedRow.Cells["Số thẻ"].Value?.ToString();
            string newBienSo = txtBienSo_TT.Text.Trim();

            if (string.IsNullOrEmpty(cardID) || string.IsNullOrEmpty(soTT))
            {
                MessageBox.Show("Không thể xác định thẻ tháng để cập nhật. Vui lòng chọn một thẻ hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "UPDATE TheThang SET soxe = @newBienSo WHERE CardID = @cardID AND SoTT = @soTT";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newBienSo", newBienSo);
                    command.Parameters.AddWithValue("@cardID", cardID);
                    command.Parameters.AddWithValue("@soTT", soTT);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật biển số thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTheThangData(maKHFilter: _selectedMaKH); // Refresh data
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thẻ tháng để cập nhật hoặc không có thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật biển số: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateLoaiThe_KH_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = GetSelectedTheThangRow();
            if (selectedRow == null) return;

            string cardID = selectedRow.Cells["Mã thẻ"].Value?.ToString();
            string soTT = selectedRow.Cells["Số thẻ"].Value?.ToString();
            string newMaLoaiThe = cbbLoaiThe_TT.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(cardID) || string.IsNullOrEmpty(soTT) || string.IsNullOrEmpty(newMaLoaiThe))
            {
                MessageBox.Show("Không thể xác định thẻ tháng hoặc loại thẻ mới để cập nhật. Vui lòng chọn một thẻ hợp lệ và loại thẻ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "UPDATE TheThang SET MaLoaiThe = @newMaLoaiThe WHERE CardID = @cardID AND SoTT = @soTT";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newMaLoaiThe", newMaLoaiThe);
                    command.Parameters.AddWithValue("@cardID", cardID);
                    command.Parameters.AddWithValue("@soTT", soTT);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật loại thẻ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTheThangData(maKHFilter: _selectedMaKH); // Refresh data
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thẻ tháng để cập nhật hoặc không có thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật loại thẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateDate_KH_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = GetSelectedTheThangRow();
            if (selectedRow == null) return;

            string cardID = selectedRow.Cells["Mã thẻ"].Value?.ToString();
            string soTT = selectedRow.Cells["Số thẻ"].Value?.ToString();
            DateTime newNgayBD = dtTu_TT.Value;
            DateTime newNgayKT = dtDen_TT.Value;

            if (string.IsNullOrEmpty(cardID) || string.IsNullOrEmpty(soTT))
            {
                MessageBox.Show("Không thể xác định thẻ tháng để cập nhật. Vui lòng chọn một thẻ hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newNgayBD > newNgayKT)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.", "Lỗi ngày", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "UPDATE TheThang SET NgayBD = @newNgayBD, NgayKT = @newNgayKT WHERE CardID = @cardID AND SoTT = @soTT";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newNgayBD", newNgayBD);
                    command.Parameters.AddWithValue("@newNgayKT", newNgayKT);
                    command.Parameters.AddWithValue("@cardID", cardID);
                    command.Parameters.AddWithValue("@soTT", soTT);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật ngày hiệu lực thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTheThangData(maKHFilter: _selectedMaKH); // Refresh data
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thẻ tháng để cập nhật hoặc không có thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật ngày hiệu lực: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKhoaThe_TT_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = GetSelectedTheThangRow();
            if (selectedRow == null) return;

            string cardID = selectedRow.Cells["Mã thẻ"].Value?.ToString();
            string soTT = selectedRow.Cells["Số thẻ"].Value?.ToString();

            if (string.IsNullOrEmpty(cardID) || string.IsNullOrEmpty(soTT))
            {
                MessageBox.Show("Không thể xác định thẻ tháng để khóa. Vui lòng chọn một thẻ hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn khóa thẻ có Mã thẻ: {cardID} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            SqlTransaction transaction = null;
            bool connectionOpenedHere = false;

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    connectionOpenedHere = true;
                }
                transaction = connection.BeginTransaction();

                // Update TheThang.TTrang to 5 (Locked)
                string updateTheThangQuery = "UPDATE TheThang SET TTrang = 5 WHERE CardID = @cardID AND SoTT = @soTT";
                using (SqlCommand cmdTheThang = new SqlCommand(updateTheThangQuery, connection, transaction))
                {
                    cmdTheThang.Parameters.AddWithValue("@cardID", cardID);
                    cmdTheThang.Parameters.AddWithValue("@soTT", soTT);
                    cmdTheThang.ExecuteNonQuery();
                }

                // Update Active.trangthai to 5 (Locked)
                string updateActiveQuery = "UPDATE Active SET trangthai = 5 WHERE sttthe = @soTT";
                using (SqlCommand cmdActive = new SqlCommand(updateActiveQuery, connection, transaction))
                {
                    cmdActive.Parameters.AddWithValue("@soTT", soTT);
                    cmdActive.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Khóa thẻ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTheThangData(maKHFilter: _selectedMaKH); // Refresh data
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Lỗi khi khóa thẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connectionOpenedHere && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void btnThuHoiThe_TT_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = GetSelectedTheThangRow();
            if (selectedRow == null) return;

            string cardID = selectedRow.Cells["Mã thẻ"].Value?.ToString();
            string soTT = selectedRow.Cells["Số thẻ"].Value?.ToString();

            if (string.IsNullOrEmpty(cardID) || string.IsNullOrEmpty(soTT))
            {
                MessageBox.Show("Không thể xác định thẻ tháng để thu hồi. Vui lòng chọn một thẻ hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn thu hồi thẻ có Mã thẻ: {cardID} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            SqlTransaction transaction = null;
            bool connectionOpenedHere = false;

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    connectionOpenedHere = true;
                }
                transaction = connection.BeginTransaction();

                // Update Active.trangthai to 1 (Active/Reclaimed)
                string updateActiveQuery = "UPDATE Active SET trangthai = 1 WHERE sttthe = @soTT";
                using (SqlCommand cmdActive = new SqlCommand(updateActiveQuery, connection, transaction))
                {
                    cmdActive.Parameters.AddWithValue("@soTT", soTT);
                    cmdActive.ExecuteNonQuery();
                }

                // Delete from TheThang table
                string deleteTheThangQuery = "DELETE FROM TheThang WHERE CardID = @cardID AND SoTT = @soTT";
                using (SqlCommand cmdTheThang = new SqlCommand(deleteTheThangQuery, connection, transaction))
                {
                    cmdTheThang.Parameters.AddWithValue("@cardID", cardID);
                    cmdTheThang.Parameters.AddWithValue("@soTT", soTT);
                    cmdTheThang.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Thu hồi thẻ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTheThangData(maKHFilter: _selectedMaKH); // Refresh data
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Lỗi khi thu hồi thẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connectionOpenedHere && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void btnBaoMatThe_TT_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = GetSelectedTheThangRow();
            if (selectedRow == null) return;

            string cardID = selectedRow.Cells["Mã thẻ"].Value?.ToString();
            string soTT = selectedRow.Cells["Số thẻ"].Value?.ToString();

            if (string.IsNullOrEmpty(cardID) || string.IsNullOrEmpty(soTT))
            {
                MessageBox.Show("Không thể xác định thẻ tháng để báo mất. Vui lòng chọn một thẻ hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn báo mất thẻ có Mã thẻ: {cardID} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            SqlTransaction transaction = null;
            bool connectionOpenedHere = false;

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    connectionOpenedHere = true;
                }
                transaction = connection.BeginTransaction();

                // Update TheThang.TTrang to 9 (Lost/Stolen)
                string updateTheThangQuery = "UPDATE TheThang SET TTrang = 9 WHERE CardID = @cardID AND SoTT = @soTT";
                using (SqlCommand cmdTheThang = new SqlCommand(updateTheThangQuery, connection, transaction))
                {
                    cmdTheThang.Parameters.AddWithValue("@cardID", cardID);
                    cmdTheThang.Parameters.AddWithValue("@soTT", soTT);
                    cmdTheThang.ExecuteNonQuery();
                }

                // Update Active.trangthai to 0 (Lost/Inactive)
                string updateActiveQuery = "UPDATE Active SET trangthai = 0 WHERE sttthe = @soTT";
                using (SqlCommand cmdActive = new SqlCommand(updateActiveQuery, connection, transaction))
                {
                    cmdActive.Parameters.AddWithValue("@soTT", soTT);
                    cmdActive.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Báo mất thẻ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTheThangData(maKHFilter: _selectedMaKH); // Refresh data
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Lỗi khi báo mất thẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connectionOpenedHere && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void SearchKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadKhachHangData();
                e.SuppressKeyPress = true; 
            }
        }

        private void txtThe_TT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformTheThangSearch();
                e.SuppressKeyPress = true;
            }
        }

        private void rbSoThe_TT_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSoThe_TT.Checked)
            {
                rbBienSo_TT.Checked = false;
                PerformTheThangSearch();
            }
        }

        private void rbBienSo_TT_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBienSo_TT.Checked)
            {
                rbSoThe_TT.Checked = false;
                PerformTheThangSearch();
            }
        }

        private void PerformTheThangSearch()
        {
            string searchTerm = txtThe_TT.Text.Trim();
            bool searchByCardID = rbSoThe_TT.Checked;
            bool showExpired = cbExDate_TT.Checked; // Get state of cbExDate_TT
            bool showLocked = cbKhoa_TT.Checked;   // Get state of cbKhoa_TT
            LoadTheThangData(searchTerm, searchByCardID, showExpired, showLocked);
        }

        private void cbExDate_TT_CheckedChanged(object sender, EventArgs e)
        {
            PerformTheThangSearch();
        }

        private void cbKhoa_TT_CheckedChanged(object sender, EventArgs e)
        {
            PerformTheThangSearch();
        }


        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabKhachHang)
            {
                LoadKhachHangData();
                // Pass default values for showExpired and showLocked (false, false)
                LoadTheThangData("", true, false, false); // Assuming default search by CardID, not expired, not locked
                LoadTheTrongData(); // Load TheTrong data when tabKhachHang is selected

                // Set dtTu_TTr and dtDen_TTr to current date
                dtTu_TTr.Value = DateTime.Now;
                dtDen_TTr.Value = DateTime.Now;

                // Load LoaiThe data for cbbLoai_TTr
                LoadLoaiTheData();
            }
        }

        private void btnThem_KH_Click(object sender, EventArgs e)
        {
            string newMaKH = GenerateNextMaKH();
            if (newMaKH == null) return; // Error occurred during generation

            InitializeDatabaseConnection();

            string query = @"
                INSERT INTO KhachHang (MaKH, hoten, DonVi, DiaChi, dienthoai, hopdong, chungloai, hinhanh)
                VALUES (@makh, '', '', '', '', '', '', NULL)"; // Insert with empty strings and NULL for image

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@makh", newMaKH);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Đã thêm khách hàng mới với Mã KH: {newMaKH}. Vui lòng chọn dòng này và nhấn Cập nhật để điền thông tin chi tiết.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKhachHangData(); // Refresh the DataGridView
                        // Optionally, select the newly added row
                        foreach (DataGridViewRow row in dgvKhachHang_KH.Rows)
                        {
                            if (row.Cells["Mã KH"].Value?.ToString() == newMaKH)
                            {
                                dgvKhachHang_KH.CurrentCell = row.Cells[0];
                                row.Selected = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm khách hàng mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm khách hàng mới: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_KH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedMaKH))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            InitializeDatabaseConnection();

            string query = @"
                UPDATE KhachHang
                SET hoten = @hoten, DonVi = @donvi, DiaChi = @diachi, dienthoai = @dienthoai, hopdong = @hopdong, chungloai = @chungloai
                WHERE MaKH = @makh";

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@makh", _selectedMaKH);
                    command.Parameters.AddWithValue("@hoten", txtHoTen_KH.Text);
                    command.Parameters.AddWithValue("@donvi", txtDonVi_KH.Text);
                    command.Parameters.AddWithValue("@diachi", txtDiaChi_KH.Text);
                    command.Parameters.AddWithValue("@dienthoai", txtDienThoai_KH.Text);
                    command.Parameters.AddWithValue("@hopdong", txtBienSo_KH.Text);
                    command.Parameters.AddWithValue("@chungloai", txtHieuXe_KH.Text);
                    // hinhanh is not updated via UI, so it's omitted

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKhachHangData(); // Refresh the DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng để cập nhật hoặc không có thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_KH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedMaKH))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng có Mã KH: {_selectedMaKH} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                InitializeDatabaseConnection();

                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    // Check if the customer has any associated monthly cards
                    string checkCardsQuery = "SELECT COUNT(*) FROM TheThang WHERE MaKH = @makh";
                    using (SqlCommand checkCmd = new SqlCommand(checkCardsQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@makh", _selectedMaKH);
                        int cardCount = (int)checkCmd.ExecuteScalar();

                        if (cardCount > 0)
                        {
                            MessageBox.Show("Không thể xóa khách hàng này vì họ có thẻ tháng liên quan. Vui lòng xóa tất cả thẻ tháng của khách hàng trước.", "Lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Prevent deletion
                        }
                    }

                    // If no cards, proceed with deletion
                    string deleteQuery = "DELETE FROM KhachHang WHERE MaKH = @makh";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@makh", _selectedMaKH);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Clear textboxes after deletion
                            _selectedMaKH = string.Empty; // Clear selected MaKH
                            txtHoTen_KH.Clear();
                            txtDiaChi_KH.Clear();
                            txtDonVi_KH.Clear();
                            txtBienSo_KH.Clear();
                            txtHieuXe_KH.Clear();
                            txtDienThoai_KH.Clear();
                            LoadKhachHangData(); // Refresh the DataGridView
                            LoadTheThangData("", true, false, false); // Also refresh monthly cards, clearing the list
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportKhachHangToExcel(DataTable dataTable, String filename)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            Excel.Range headerRange = null;
            Excel.Range dataRange = null;

            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.Sheets[1];

                int columnCount = dataTable.Columns.Count;
                int rowCount = dataTable.Rows.Count;

                object[] header = new object[columnCount];
                for (int col = 0; col < columnCount; col++)
                {
                    header[col] = dataTable.Columns[col].ColumnName;
                }
                headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, columnCount]];
                headerRange.Value = header;
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                Marshal.ReleaseComObject(headerRange);

                object[,] data = new object[rowCount, columnCount];
                for (int row = 0; row < rowCount; row++)
                {
                    for (int col = 0; col < columnCount; col++)
                    {
                        data[row, col] = dataTable.Rows[row][col]?.ToString() ?? "";
                    }
                }
                dataRange = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[rowCount + 1, columnCount]];
                dataRange.Value = data;
                Marshal.ReleaseComObject(dataRange);

                worksheet.Columns.AutoFit();

                string serverAddress = txtServer;
                string sharedFolderValue = Properties.Settings.Default.SharedFolder;

                int index = serverAddress.IndexOf("\\SQLEXPRESS", StringComparison.OrdinalIgnoreCase);
                if (index != -1)
                {
                    serverAddress = serverAddress.Remove(index, "\\SQLEXPRESS".Length).Trim();
                }
                string networkPath = Path.Combine("\\\\" + serverAddress, sharedFolderValue);

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.InitialDirectory = networkPath;
                    sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";
                    sfd.Title = "Lưu file Excel danh sách khách hàng";
                    sfd.FileName = $"DANH-SACH-KHACH-HANG-{DateTime.Now:dd-MM-yyyy}.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Xuất dữ liệu khách hàng ra Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Properties.Settings.Default.FolderCus = Path.GetDirectoryName(sfd.FileName);
                        Properties.Settings.Default.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất dữ liệu khách hàng ra Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (workbook != null) workbook.Saved = true;
            }
            finally
            {
                if (excelApp != null)
                {
                    excelApp.ScreenUpdating = true;
                    excelApp.DisplayAlerts = true;
                    excelApp.Calculation = Excel.XlCalculation.xlCalculationAutomatic;
                }

                if (headerRange != null) Marshal.ReleaseComObject(headerRange);
                if (dataRange != null) Marshal.ReleaseComObject(dataRange);
                if (worksheet != null)
                {
                    Marshal.ReleaseComObject(worksheet);
                    worksheet = null;
                }
                if (workbook != null)
                {
                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                    workbook = null;
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                    excelApp = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }

        private void btnExportExcel_KH_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang_KH.DataSource == null || !(dgvKhachHang_KH.DataSource is DataTable) || ((DataTable)dgvKhachHang_KH.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu khách hàng để xuất ra Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dataTable = (DataTable)dgvKhachHang_KH.DataSource;
            ExportKhachHangToExcel(dataTable, "DANH-SACH-KHACH-HANG");
        }

        private string GenerateNextMaKH()
        {
            string maxMaKH = "000000"; // Default if no existing customers

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "SELECT MAX(MaKH) FROM KhachHang";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        maxMaKH = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy Mã KH lớn nhất: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Indicate failure
            }
            finally
            {
                // It's generally better to keep the connection open if multiple operations are expected,
                // but for a single query, closing it here is fine.
                // However, InitializeDatabaseConnection() ensures it's open, so we might not need to close it here.
            }

            // Parse, increment, and format
            if (int.TryParse(maxMaKH, out int numericMaKH))
            {
                numericMaKH++;
                return numericMaKH.ToString("D6"); // Format to 6 digits with leading zeros
            }
            else
            {
                // Handle cases where MaKH is not purely numeric or has unexpected format
                // For now, return a default or throw an error
                MessageBox.Show("Mã KH hiện tại không đúng định dạng số. Không thể tự động tăng.", "Lỗi định dạng Mã KH", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }









        private void LoadTheTrongData(string searchTerm = "")
        {
            // InitializeDatabaseConnection(); // Ensure connection is open

            string query = @"
                SELECT
                    sttthe AS 'Số thẻ',
                    CardID AS 'Mã thẻ'
                FROM
                    Active
                WHERE trangthai = 1"; // Assuming 'Active' is the table name

            var whereClauses = new List<string>();
            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                whereClauses.Add("sttthe LIKE @searchTerm");
                parameters.Add(new SqlParameter("@searchTerm", "%" + searchTerm + "%"));
            }

            if (whereClauses.Any())
            {
                query += " AND " + string.Join(" AND ", whereClauses);
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvTheTrong_KH.DataSource = dataTable;
                        dgvTheTrong_KH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Auto-fill columns
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu thẻ trống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

                    private void PerformTheTrongSearch()
        {
            string searchTerm = txtThe_TTr.Text.Trim();
            LoadTheTrongData(searchTerm);
        }

        private void txtThe_TTr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformTheTrongSearch();
                e.SuppressKeyPress = true;
            }
        }

        private void LoadLoaiTheData()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "SELECT MaLoaiThe, LoaiThe FROM LoaiThe";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        cbbLoai_TTr.DataSource = dataTable;
                        cbbLoai_TTr.DisplayMember = "MaLoaiThe"; // Display the 'MaLoaiThe' column
                        cbbLoai_TTr.ValueMember = "MaLoaiThe"; // Use 'MaLoaiThe' as the actual value

                        // Create a new DataTable for cbbLoaiThe_TT to avoid issues with shared DataSource
                        DataTable dataTableForCbbLoaiThe_TT = dataTable.Copy();
                        cbbLoaiThe_TT.DataSource = dataTableForCbbLoaiThe_TT;
                        cbbLoaiThe_TT.DisplayMember = "MaLoaiThe"; // Display the 'MaLoaiThe' column
                        cbbLoaiThe_TT.ValueMember = "MaLoaiThe"; // Use 'MaLoaiThe' as the actual value
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu loại thẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnCapThe_TTr_Click(object sender, EventArgs e)
        {
            // 2. Lấy dữ liệu vào biến tạm (tránh bị Clear UI làm mất dữ liệu)
            string maKH = _selectedMaKH;
            string cardID = _selectedCardID;
            string soTT = _selectedSTT.ToString();
            string maLoaiThe = cbbLoai_TTr.Text.Trim();
            DateTime ngayBD = dtTu_TTr.Value;
            DateTime ngayKT = dtDen_TTr.Value;
            string soxe = txtBienSo_TTr.Text.Trim();
            int tTrang = 1; // Active
            string giatien = "0";
            string datcoc = "0";
            string nguoicap = "admin";

            // 3. Kiểm tra dữ liệu bắt buộc
            if (string.IsNullOrEmpty(maKH) || string.IsNullOrEmpty(soTT) ||
                string.IsNullOrEmpty(cardID) || string.IsNullOrEmpty(maLoaiThe))
            {
                MessageBox.Show(
                    $"Không thể lấy đủ thông tin cần thiết để cấp thẻ.\n\n" +
                    $"Vui lòng kiểm tra lại dữ liệu:\n" +
                    $"- Mã KH: {maKH}\n" +
                    $"- Mã thẻ: {cardID}\n" +
                    $"- Số thẻ: {soTT}\n" +
                    $"- Mã loại thẻ: {maLoaiThe}",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return; // Không chạy tiếp
            }

            //4.Thao tác Database với Transaction
            SqlTransaction transaction = null;
            bool connectionOpenedHere = false;

            try
            {
                InitializeDatabaseConnection(); // Đảm bảo connection được khởi tạo

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    connectionOpenedHere = true;
                }

                transaction = connection.BeginTransaction();

                // 4a. Insert vào TheThang
                string insertTheThangQuery = @"
            INSERT INTO TheThang (CardID, SoTT, MaKH, TTrang, MaLoaiThe, NgayBD, NgayKT, soxe, nguoicap, giatien, datcoc)
            VALUES (@CardID, @SoTT, @MaKH, @TTrang, @MaLoaiThe, @NgayBD, @NgayKT, @soxe, @nguoicap, @giatien, @datcoc)";

                using (SqlCommand cmdInsert = new SqlCommand(insertTheThangQuery, connection, transaction))
                {
                    cmdInsert.Parameters.AddWithValue("@CardID", cardID);
                    cmdInsert.Parameters.AddWithValue("@SoTT", soTT);
                    cmdInsert.Parameters.AddWithValue("@MaKH", maKH);
                    cmdInsert.Parameters.AddWithValue("@TTrang", tTrang);
                    cmdInsert.Parameters.AddWithValue("@MaLoaiThe", maLoaiThe);
                    cmdInsert.Parameters.AddWithValue("@NgayBD", ngayBD);
                    cmdInsert.Parameters.AddWithValue("@NgayKT", ngayKT);
                    cmdInsert.Parameters.AddWithValue("@soxe", soxe);
                    cmdInsert.Parameters.AddWithValue("@nguoicap", nguoicap);
                    cmdInsert.Parameters.AddWithValue("@giatien", giatien);
                    cmdInsert.Parameters.AddWithValue("@datcoc", datcoc);

                    cmdInsert.ExecuteNonQuery();
                }

                // 4b. Update Active table
                string updateActiveQuery = "UPDATE Active SET trangthai = 2 WHERE CardID = @CardID";
                using (SqlCommand cmdUpdateActive = new SqlCommand(updateActiveQuery, connection, transaction))
                {
                    cmdUpdateActive.Parameters.AddWithValue("@CardID", cardID);
                    cmdUpdateActive.ExecuteNonQuery();
                }

                transaction.Commit();

                MessageBox.Show("Cấp thẻ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 5. Load lại dữ liệu
                LoadTheThangData("", true, false, false);
                LoadTheTrongData();

                // 6. Clear UI
                txtThe_TTr.Clear();
                txtBienSo_TTr.Clear();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Lỗi khi cấp thẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connectionOpenedHere && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        #endregion // End of KHÁCH HÀNG



        #region KHỐI DOANH THU

        private void DoanhThu_Load()        
        {

            progressBarExport.Visible = false;
            progressBarExport.Value = 0;

            //_currentQueryResult = new DataTable();
            SetInitialControlStates();

            // Set dateTimeStart to the first day of the current month
            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimeStart.Value = firstDayOfMonth;
            dateTimeEnd.Value = firstDayOfMonth; // Or DateTime.Now, depending on desired default end date

            // Set timeTimeStart and timeTimeEnd to 00:00:00
            timeTimeStart.Value = new DateTime(firstDayOfMonth.Year, firstDayOfMonth.Month, firstDayOfMonth.Day, 06, 0, 0);
            timeTimeEnd.Value = new DateTime(firstDayOfMonth.Year, firstDayOfMonth.Month, firstDayOfMonth.Day, 06, 0, 0);

            // Set custom format for time pickers
            timeTimeStart.Format = DateTimePickerFormat.Custom;
            timeTimeEnd.Format = DateTimePickerFormat.Custom;
            timeTimeStart.CustomFormat = "HH:mm:ss";
            timeTimeEnd.CustomFormat = "HH:mm:ss";
            timeTimeStart.ShowUpDown = true;
            timeTimeEnd.ShowUpDown = true;

            // Set custom format for date pickers to dd-MM-yyyy
            dateTimeStart.Format = DateTimePickerFormat.Custom;
            dateTimeStart.CustomFormat = "dd-MM-yyyy";
            dateTimeEnd.Format = DateTimePickerFormat.Custom;
            dateTimeEnd.CustomFormat = "dd-MM-yyyy";

            cmbTypeDoanhThu.Items.Add("VL");
            cmbTypeDoanhThu.Items.Add("VL-XD");
            cmbTypeDoanhThu.Items.Add("VL-XM");
            cmbTypeDoanhThu.Items.Add("VL-XH");
            cmbTypeDoanhThu.Items.Add("VT-XH");
            cmbTypeDoanhThu.Items.Add("VT-XM");
            cmbTypeDoanhThu.Items.Add("VT");
            cmbTypeDoanhThu.Items.Add("VT-XD");
            cmbTypeDoanhThu.Items.Add("All");

            if (cmbTypeDoanhThu.Items.Count > 0)
            {
                cmbTypeDoanhThu.SelectedIndex = 0;
            }

            // Initialize Xe Ra tab controls
            dtXeRaTuDate.Value = firstDayOfMonth;
            dtXeRaDenDate.Value = firstDayOfMonth;
            dtXeRaTuTime.Value = new DateTime(firstDayOfMonth.Year, firstDayOfMonth.Month, firstDayOfMonth.Day, 0, 0, 0);
            dtXeRaDenTime.Value = new DateTime(firstDayOfMonth.Year, firstDayOfMonth.Month, firstDayOfMonth.Day, 0, 0, 0);

            dtXeRaTuTime.Format = DateTimePickerFormat.Custom;
            dtXeRaDenTime.Format = DateTimePickerFormat.Custom;
            dtXeRaTuTime.CustomFormat = "HH:mm:ss";
            dtXeRaDenTime.CustomFormat = "HH:mm:ss";
            dtXeRaTuTime.ShowUpDown = true;
            dtXeRaDenTime.ShowUpDown = true;

            dtXeRaTuDate.Format = DateTimePickerFormat.Custom;
            dtXeRaTuDate.CustomFormat = "dd-MM-yyyy";
            dtXeRaDenDate.Format = DateTimePickerFormat.Custom;
            dtXeRaDenDate.CustomFormat = "dd-MM-yyyy";

            cbbXeRa.Items.Add("VL");
            cbbXeRa.Items.Add("VL-XD");
            cbbXeRa.Items.Add("VL-XM");
            cbbXeRa.Items.Add("VL-XH");
            cbbXeRa.Items.Add("VT-XH");
            cbbXeRa.Items.Add("VT-XM");
            cbbXeRa.Items.Add("VT");
            cbbXeRa.Items.Add("VT-XD");
            cbbXeRa.Items.Add("All");

            if (cbbXeRa.Items.Count > 0)
            {
                cbbXeRa.SelectedIndex = 0;
            }

            // Initialize Xe Vao tab controls
            dtXeVaoTuDate.Value = firstDayOfMonth;
            dtXeVaoDenDate.Value = firstDayOfMonth;
            dtXeVaoTuTime.Value = new DateTime(firstDayOfMonth.Year, firstDayOfMonth.Month, firstDayOfMonth.Day, 0, 0, 0);
            dtXeVaoDenTime.Value = new DateTime(firstDayOfMonth.Year, firstDayOfMonth.Month, firstDayOfMonth.Day, 0, 0, 0);

            dtXeVaoTuTime.Format = DateTimePickerFormat.Custom;
            dtXeVaoDenTime.Format = DateTimePickerFormat.Custom;
            dtXeVaoTuTime.CustomFormat = "HH:mm:ss";
            dtXeVaoDenTime.CustomFormat = "HH:mm:ss";
            dtXeVaoTuTime.ShowUpDown = true;
            dtXeVaoDenTime.ShowUpDown = true;

            dtXeVaoTuDate.Format = DateTimePickerFormat.Custom;
            dtXeVaoTuDate.CustomFormat = "dd-MM-yyyy";
            dtXeVaoDenDate.Format = DateTimePickerFormat.Custom;
            dtXeVaoDenDate.CustomFormat = "dd-MM-yyyy";

            cbbXeVao.Items.Add("VL");
            cbbXeVao.Items.Add("VL-XD");
            cbbXeVao.Items.Add("VL-XM");
            cbbXeVao.Items.Add("VL-XH");
            cbbXeVao.Items.Add("VT-XH");
            cbbXeVao.Items.Add("VT-XM");
            cbbXeVao.Items.Add("VT");
            cbbXeVao.Items.Add("VT-XD");
            cbbXeVao.Items.Add("All");

            if (cbbXeVao.Items.Count > 0)
            {
                cbbXeVao.SelectedIndex = 0;
            }
        }

        private void SetInitialControlStates()
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            if (!cmbTypeDoanhThu.Items.Contains(ALL_MATERIAL_TYPE))
            {
                cmbTypeDoanhThu.Items.Insert(0, ALL_MATERIAL_TYPE);
            }
            cmbTypeDoanhThu.SelectedIndex = 0;

            if (!cbbXeRa.Items.Contains(ALL_MATERIAL_TYPE))
            {
                cbbXeRa.Items.Insert(0, ALL_MATERIAL_TYPE);
            }
            cbbXeRa.SelectedIndex = 0;
        }

        private void InitializeDatabaseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                return; // Connection is already open
            }

            try
            {
                string serverAddress = txtServer;
                string databaseName = txtDatabase;
                string uid = txtUsername;
                string password = Properties.Settings.Default.Password; // Ensure password is retrieved from settings
                string connectionString;
                if (string.IsNullOrWhiteSpace(uid))
                {
                    connectionString = $"Server={serverAddress};Database={databaseName};Integrated Security=True;TrustServerCertificate=True;";
                }
                else
                {
                    connectionString = $"Server={serverAddress};Database={databaseName};User ID={uid};Password={password};TrustServerCertificate=True;";
                }

                this.connection = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối đến cơ sở dữ liệu: {ex.Message}\nVui lòng kiểm tra lại cài đặt kết nối.", "Lỗi kết nối cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally, disable UI elements that require a database connection
            }
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {

            DateTime startDateFromPicker = dateTimeStart.Value;
            DateTime endDateFromPicker = dateTimeEnd.Value;
            DateTime startTimeFromPicker = timeTimeStart.Value;
            DateTime endTimeFromPicker = timeTimeEnd.Value;

            DateTime fullStartDateTime = new DateTime(
                startDateFromPicker.Year,
                startDateFromPicker.Month,
                startDateFromPicker.Day,
                startTimeFromPicker.Hour,
                startTimeFromPicker.Minute,
                startTimeFromPicker.Second);

            DateTime fullEndDateTime = new DateTime(
                endDateFromPicker.Year,
                endDateFromPicker.Month,
                endDateFromPicker.Day,
                endTimeFromPicker.Hour,
                endTimeFromPicker.Minute,
                endTimeFromPicker.Second);

            string selectedMaterialType = cmbTypeDoanhThu.SelectedItem?.ToString();

            string query = @"
                        SELECT
                            STTThe AS 'Số thẻ',
                            NgayRa AS 'Ngày ra',
                            -- Sử dụng các hàm chuỗi cơ bản để tạo định dạng thời gian HH:MM:SS.FF
                            FORMAT(DATEADD(second, CAST(GioRa AS INT) % 100, DATEADD(minute, (CAST(GioRa AS INT) / 100) % 100, DATEADD(hour, CAST(GioRa AS INT) / 10000, '00:00:00'))), 'HH:mm:ss.ff') AS 'Giờ ra',
                            MaLoaiThe AS 'Loại thẻ',
                            GiaTien AS 'Tiền thu',
                            CardID AS 'Mã thẻ',
                            IDXe AS 'Mã xe',
                            IDMat AS 'Mã mặt',
                            soxe AS 'Xe vào',
                            soxera AS 'Xe ra'
                        FROM [dbo].[Ra]
                        WHERE GiaTien > 0 AND ";

            query += @" (
                    CAST(NgayRa AS DATETIME) +
                    CAST( -- Cast chuỗi thời gian được tạo từ GioRa thành DATETIME
                        RIGHT('0' + CAST(GioRa / 1000000 AS VARCHAR(2)), 2) + ':' +
                        RIGHT('0' + CAST((GioRa / 10000) % 100 AS VARCHAR(2)), 2) + ':' +
                        RIGHT('0' + CAST((GioRa / 100) % 100 AS VARCHAR(2)), 2) + '.' +
                        RIGHT('0' + CAST(GioRa % 100 AS VARCHAR(2)), 2)
                    AS DATETIME)
                ) BETWEEN @fullStartDateTime AND @fullEndDateTime";

            if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
            {
                query += " AND Ra.MaLoaiThe = @MaterialType";
            }

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fullStartDateTime", fullStartDateTime);
                    command.Parameters.AddWithValue("@fullEndDateTime", fullEndDateTime);

                    if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
                    {
                        command.Parameters.AddWithValue("@MaterialType", selectedMaterialType);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvResults.DataSource = dataTable;
                        dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        int rowCount = dataTable.Rows.Count;
                        txtCount.Text = rowCount.ToString("N0");

                        if (dataTable.Rows.Count > 0)
                        {
                            btnUpdate.Enabled = true;
                            btnDelete.Enabled = true;
                        }
                        else
                        {
                            btnUpdate.Enabled = false;
                            btnDelete.Enabled = false;
                        }

                        decimal totalGiaTien = 0;

                        if (dataTable.Columns.Contains("Tiền thu"))
                        {
                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (row["Tiền thu"] != DBNull.Value && decimal.TryParse(row["Tiền thu"].ToString(), out decimal giaTien))
                                {
                                    totalGiaTien += giaTien;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Column 'Tiền thu' not found in query results. Cannot calculate sum.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        txtSum.Text = totalGiaTien.ToString("N0") + " VNĐ";
                        txtCount.Text = dataTable.Rows.Count.ToString("N0");
                        btnExportRevenue.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Query error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (PasswordPromptForm passwordForm = new PasswordPromptForm())
            {
                DialogResult result = passwordForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string enteredPassword = passwordForm.EnteredPassword;

                    if (enteredPassword == CORRECT_PASSWORD)
                    {
                        EvenDelete();
                    }
                    else
                    {
                        MessageBox.Show("Sai mật khẩu. Vui lòng thử lại", "Xác thực không thành công!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Cancel.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void EvenDelete()
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Chưa kết nối với cơ sở dữ liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvResults.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dòng để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa các dòng đã chọn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            int successCount = 0, failCount = 0;

            foreach (DataGridViewRow row in dgvResults.SelectedRows)
            {
                if (row.IsNewRow) continue;

                string cardId = row.Cells["Mã thẻ"].Value?.ToString();
                string idXe = row.Cells["Mã xe"].Value?.ToString();
                string idMat = row.Cells["Mã mặt"].Value?.ToString();

                if (string.IsNullOrEmpty(cardId) || string.IsNullOrEmpty(idXe) || string.IsNullOrEmpty(idMat))
                {
                    failCount++;
                    continue;
                }

                try
                {
                    // 🔹 Ghi log trước khi xóa
                    string insertLogQuery = @"
                    INSERT INTO [dbo].[ITKHA]
                    (STTThe, CardID, NgayRa, THoiGianRa, MaLoaiThe, GiaTien, username, IDXe, IDMat, GioRa, cong, soxe, soxera, Thao_Tac, Ngay_Thuc_Hien)
                    SELECT STTThe, CardID, NgayRa, THoiGianRa, MaLoaiThe, GiaTien, username, IDXe, IDMat, GioRa, cong, soxe, soxera, N'Xóa', GETDATE()
                    FROM [dbo].[Ra]
                    WHERE CardID = @cardId AND IDXe = @idXe AND IDMat = @idMat;";

                    using (SqlCommand logCmd = new SqlCommand(insertLogQuery, connection))
                    {
                        logCmd.Parameters.AddWithValue("@cardId", cardId);
                        logCmd.Parameters.AddWithValue("@idXe", idXe);
                        logCmd.Parameters.AddWithValue("@idMat", idMat);
                        logCmd.ExecuteNonQuery();
                    }

                    // 🔹 Thực hiện xóa
                    string deleteQuery = "DELETE FROM [dbo].[Ra] WHERE CardID = @cardId AND IDXe = @idXe AND IDMat = @idMat";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCmd.Parameters.AddWithValue("@cardId", cardId);
                        deleteCmd.Parameters.AddWithValue("@idXe", idXe);
                        deleteCmd.Parameters.AddWithValue("@idMat", idMat);

                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            dgvResults.Rows.Remove(row);
                            successCount++;
                        }
                        else failCount++;
                    }
                }
                catch
                                {
                    failCount++;
                }
            }

            MessageBox.Show($"Xóa hoàn tất.\nThành công: {successCount}\nThất bại: {failCount}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

            // Giữ nguyên việc lấy giá trị từ Date/Time Pickers
            DateTime startDateFromPicker = dateTimeStart.Value;
            DateTime endDateFromPicker = dateTimeEnd.Value;
            DateTime startTimeFromPicker = timeTimeStart.Value;
            DateTime endTimeFromPicker = timeTimeEnd.Value;

            DateTime fullStartDateTime = new DateTime(
                startDateFromPicker.Year,
                startDateFromPicker.Month,
                startDateFromPicker.Day,
                startTimeFromPicker.Hour,
                startTimeFromPicker.Minute,
                startTimeFromPicker.Second);

            DateTime fullEndDateTime = new DateTime(
                endDateFromPicker.Year,
                endDateFromPicker.Month,
                endDateFromPicker.Day,
                endTimeFromPicker.Hour,
                endTimeFromPicker.Minute,
                endTimeFromPicker.Second);

            string selectedMaterialType = cmbTypeDoanhThu.SelectedItem?.ToString();

            // *** PHẦN SỬA ĐỔI QUAN TRỌNG: Câu truy vấn SQL để tương thích mọi phiên bản ***
            string query = @"
                            SELECT
                                STTThe AS 'Số thẻ',
                                NgayRa AS 'Ngày ra',
                                -- Sử dụng các hàm chuỗi cơ bản để tạo định dạng thời gian HH:MM:SS.FF
                                RIGHT('0' + CAST(GioRa / 1000000 AS VARCHAR(2)), 2) + ':' +
                                RIGHT('0' + CAST((GioRa / 10000) % 100 AS VARCHAR(2)), 2) + ':' +
                                RIGHT('0' + CAST((GioRa / 100) % 100 AS VARCHAR(2)), 2) + '.' +
                                RIGHT('0' + CAST(GioRa % 100 AS VARCHAR(2)), 2) AS 'Giờ ra',
                                MaLoaiThe AS 'Loại thẻ',
                                GiaTien AS 'Tiền thu',
                                CardID AS 'Mã thẻ',
                                IDXe AS 'Mã xe',
                                IDMat AS 'Mã mặt',
                                soxe AS 'Xe vào',
                                soxera AS 'Xe ra'
                            FROM [dbo].[Ra]
                            WHERE";

            // Phần điều kiện WHERE cũng được sửa đổi để tương thích
            query += @" (
                            CAST(NgayRa AS DATETIME) +
                            CAST( -- Cast chuỗi thời gian được tạo từ GioRa thành DATETIME
                                FORMAT(DATEADD(second, CAST(GioRa AS INT) % 100, DATEADD(minute, (CAST(GioRa AS INT) / 100) % 100, DATEADD(hour, CAST(GioRa AS INT) / 10000, '00:00:00'))), 'HH:mm:ss.ff')
                            AS DATETIME)
                        ) BETWEEN @fullStartDateTime AND @fullEndDateTime";

            // Giữ nguyên logic thêm điều kiện lọc theo loại vật liệu
            if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
            {
                query += " AND Ra.MaLoaiThe = @MaterialType";
            }

            // Giữ nguyên ORDER BY
            query += " ORDER BY NgayRa ASC, GioRa ASC;";

            // Giữ nguyên khối try-catch-finally và logic đổ dữ liệu vào dgvResults
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fullStartDateTime", fullStartDateTime);
                    command.Parameters.AddWithValue("@fullEndDateTime", fullEndDateTime);

                    if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
                    {
                        command.Parameters.AddWithValue("@MaterialType", selectedMaterialType);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvResults.DataSource = dataTable;
                        dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        if (dataTable.Rows.Count > 0)
                        {
                            btnUpdate.Enabled = true;
                            btnDelete.Enabled = true;
                        }
                        else
                        {
                            btnUpdate.Enabled = false;
                            btnDelete.Enabled = false;
                        }

                        decimal totalGiaTien = 0;

                        if (dataTable.Columns.Contains("Tiền thu"))
                        {
                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (row["Tiền thu"] != DBNull.Value && decimal.TryParse(row["Tiền thu"].ToString(), out decimal giaTien))
                                {
                                    totalGiaTien += giaTien;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Column 'Tiền thu' not found in query results. Cannot calculate sum.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        txtSum.Text = totalGiaTien.ToString("N0") + " VNĐ";
                        txtCount.Text = dataTable.Rows.Count.ToString("N0");
                        btnExportRevenue.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Query error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Không có khối finally ở đây trong code gốc của bạn, nên tôi không thêm vào.
            // Nếu bạn muốn thêm xử lý trạng thái UI như btnExport_Click, thì cần thêm vào đây.
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (connection == null)
            {
                MessageBox.Show("Chưa khởi tạo kết nối. Vui lòng kết nối trước.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Vui lòng chọn đúng một dòng để cập nhật.", "Lỗi chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvResults.SelectedRows[0];
            if (row.IsNewRow) return;

            string cardId = row.Cells["Mã thẻ"].Value?.ToString();
            string idXe = row.Cells["Mã xe"].Value?.ToString();
            string idMat = row.Cells["Mã mặt"].Value?.ToString();

            if (string.IsNullOrEmpty(cardId) || string.IsNullOrEmpty(idXe) || string.IsNullOrEmpty(idMat))
            {
                MessageBox.Show("Không thể xác định dòng cần cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool openedHere = false;
            try
            {
                // Mở connection nếu cần (nhớ đóng lại nếu do hàm này mở)
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    openedHere = true;
                }

                using (SqlTransaction trans = connection.BeginTransaction())
                {
                    // 1) Ghi log vào it_kha (dùng cùng connection + transaction)
                    string insertLogQuery = @"
                        INSERT INTO [dbo].[ITKHA]
                        (STTThe, CardID, NgayRa, THoiGianRa, MaLoaiThe, GiaTien, username, IDXe, IDMat, GioRa, cong, soxe, soxera, Thao_Tac, Ngay_Thuc_Hien)
                        SELECT STTThe, CardID, NgayRa, THoiGianRa, MaLoaiThe, GiaTien, username, IDXe, IDMat, GioRa, cong, soxe, soxera, N'Cập nhật', GETDATE()
                        FROM [dbo].[Ra]
                        WHERE CardID = @cardId AND IDXe = @idXe AND IDMat = @idMat;";

                    using (SqlCommand logCmd = new SqlCommand(insertLogQuery, connection, trans))
                    {
                        logCmd.Parameters.AddWithValue("@cardId", cardId);
                        logCmd.Parameters.AddWithValue("@idXe", idXe);
                        logCmd.Parameters.AddWithValue("@idMat", idMat);
                        logCmd.ExecuteNonQuery();
                    }

                    // 2) Chuẩn bị update (lấy các cột cần update từ dgv)
                    Dictionary<string, string> columnMapping = new Dictionary<string, string>
                        {
                            { "Số thẻ", "STTThe" },
                            { "Loại thẻ", "MaLoaiThe" },
                            { "Tiền thu", "GiaTien" },
                            { "Xe vào", "soxe" },
                            { "Xe ra", "soxera" }
                        };

                    List<string> updateFields = new List<string>();
                    using (SqlCommand updateCmd = new SqlCommand())
                    {
                        updateCmd.Connection = connection;
                        updateCmd.Transaction = trans;

                        foreach (DataGridViewColumn column in dgvResults.Columns)
                        {
                            string columnName = column.Name;

                            // Skip primary key columns and read-only columns
                            if (columnName == "Mã thẻ" || columnName == "Mã xe" || columnName == "Mã mặt" || columnName == "Ngày ra" || columnName == "Giờ ra")
                                continue;

                            if (!columnMapping.TryGetValue(columnName, out string dbColumnName))
                                continue;

                            object value = row.Cells[columnName].Value ?? DBNull.Value;
                            string paramName = $"@param_{dbColumnName}";
                            updateFields.Add($"[{dbColumnName}] = {paramName}");

                            // Nếu bạn muốn chắc chắn kiểu tham số chính xác, bạn có thể dùng Add và chỉ định SqlDbType ở đây
                            updateCmd.Parameters.AddWithValue(paramName, value);
                        }

                        if (updateFields.Count == 0)
                        {
                            MessageBox.Show("Không có dữ liệu nào để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            trans.Rollback();
                            return;
                        }

                        string updateQuery = $@"
                            UPDATE [dbo].[Ra]
                            SET {string.Join(", ", updateFields)}
                            WHERE CardID = @cardId AND IDXe = @idXe AND IDMat = @idMat;";

                        updateCmd.CommandText = updateQuery;
                        updateCmd.Parameters.AddWithValue("@cardId", cardId);
                        updateCmd.Parameters.AddWithValue("@idXe", idXe);
                        updateCmd.Parameters.AddWithValue("@idMat", idMat);

                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            trans.Commit();
                            MessageBox.Show("Cập nhật thành công.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            trans.Rollback();
                            MessageBox.Show("Không có dòng nào được cập nhật.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
                        
            catch (Exception ex)
            {
                try { connection?.Close(); } catch { }
                MessageBox.Show($"Lỗi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (openedHere && connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        private void ExportDataTableToExcel(DataTable dataTable, String filename, DateTime fullStartDateTime, DateTime fullEndDateTime)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            Excel.Range headerRange = null; // Khai báo để giải phóng
            Excel.Range dataRange = null;   // Khai báo để giải phóng

            try
            {
                // Tối ưu hóa Excel Application
                excelApp = new Excel.Application();

                workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.Sheets[1];

                int columnCount = dataTable.Columns.Count;
                int rowCount = dataTable.Rows.Count;

                object[] header = new object[columnCount];
                for (int col = 0; col < columnCount; col++)
                {
                    header[col] = dataTable.Columns[col].ColumnName;
                }
                headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, columnCount]];
                headerRange.Value = header;
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                Marshal.ReleaseComObject(headerRange); // Giải phóng Range sau khi dùng

                object[,] data = new object[rowCount, columnCount];
                for (int row = 0; row < rowCount; row++)
                {
                    for (int col = 0; col < columnCount; col++)
                    {
                        data[row, col] = dataTable.Rows[row][col]?.ToString() ?? "";
                    }
                    if (row % 1000 == 0 || row == rowCount - 1) // Cập nhật mỗi 1000 hàng hoặc ở cuối
                    {
                        progressBarExport.Value = (int)((double)(row + 1) / rowCount * 90); // 90% cho việc ghi dữ liệu
                        Application.DoEvents(); // Cho phép UI xử lý sự kiện để cập nhật ProgressBar
                    }
                }
                dataRange = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[rowCount + 1, columnCount]];
                dataRange.Value = data;
                Marshal.ReleaseComObject(dataRange); // Giải phóng Range sau khi dùng

                // 3. Tự động điều chỉnh độ rộng cột và các tối ưu khác
                worksheet.Columns.AutoFit();

                progressBarExport.Value = 95; // 95% cho các thao tác tối ưu

                string serverAddress = txtServer;
                string sharedFolderValue = Properties.Settings.Default.SharedFolder; 

                int index = serverAddress.IndexOf("\\SQLEXPRESS", StringComparison.OrdinalIgnoreCase);
                if (index != -1)
                {
                    serverAddress = serverAddress.Remove(index, "\\SQLEXPRESS".Length).Trim();
                }
                string networkPath = Path.Combine("\\\\" + serverAddress, sharedFolderValue);

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.InitialDirectory = networkPath;

                    sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";
                    sfd.Title = "Lưu file Excel";
                    if (filename == "DANH-SACH-THE-THANG")
                    {
                        sfd.FileName = "XUAT-DU-LIEU-" + filename + "-DEN-NGAY" + DateTime.Now.ToString("-dd-MM-yyyy") + ".xlsx";
                    }
                    else if (filename == "DOANH-THU-VANG-LAI")
                    {
                        string startDate = fullStartDateTime.ToString("ddMMyyyy");
                        string startTime = fullStartDateTime.ToString("HHmmss");
                        string endDate = fullEndDateTime.ToString("ddMMyyyy");
                        string endTime = fullEndDateTime.ToString("HHmmss");
                        sfd.FileName = $"DOANH-THU-TU-{startDate}-{startTime}-DEN-{endDate}-{endTime}.xlsx";
                    }
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Xuất dữ liệu ra Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Lấy đường dẫn thư mục chứa file
                        string folderPath = Path.GetDirectoryName(sfd.FileName);
                        if (filename == "DANH-SACH-THE-THANG")
                        {
                            //btnOpenCus.Enabled = true; // btnOpenCus does not exist in FormMain
                            Properties.Settings.Default.FolderCus = folderPath;
                        }
                        else if (filename == "DOANH-THU-VANG-LAI")
                        {
                            //btnOpenRevenue.Enabled = true; // btnOpenRevenue does not exist in FormMain
                            Properties.Settings.Default.FolderRevenue = folderPath;
                        }
                        Properties.Settings.Default.Save(); // Save settings after updating folder paths
                    }
                }
                progressBarExport.Value = 100; // Hoàn thành

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất dữ liệu ra Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Nếu có lỗi, đảm bảo workbook không hỏi lưu khi đóng
                if (workbook != null) workbook.Saved = true;
            }
            finally
            {
                // Khôi phục trạng thái của Excel Application
                if (excelApp != null)
                {
                    excelApp.ScreenUpdating = true;
                    excelApp.DisplayAlerts = true;
                    excelApp.Calculation = Excel.XlCalculation.xlCalculationAutomatic;
                }

                // Giải phóng tài nguyên COM Objects một cách an toàn
                // Đảm bảo giải phóng các đối tượng đã khai báo
                if (headerRange != null) Marshal.ReleaseComObject(headerRange);
                if (dataRange != null) Marshal.ReleaseComObject(dataRange);
                if (worksheet != null)
                {
                    Marshal.ReleaseComObject(worksheet);
                    worksheet = null;
                }
                if (workbook != null)
                {
                    workbook.Close(false); // False để không hỏi lưu lại lần nữa
                    Marshal.ReleaseComObject(workbook);
                    workbook = null;
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                    excelApp = null;
                }

                // Buộc Garbage Collection để giải phóng các đối tượng COM bị treo
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect(); // Chạy lại lần nữa để chắc chắn
            }
        }

        private void btnExportRevenue_Click(object sender, EventArgs e)
        {
            // Vô hiệu hóa nút Export và hiển thị ProgressBar
            btnExportRevenue.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            progressBarExport.Visible = true;
            progressBarExport.Value = 0;

            // Recalculate fullStartDateTime and fullEndDateTime
            DateTime startDateFromPicker = dateTimeStart.Value;
            DateTime endDateFromPicker = dateTimeEnd.Value;
            DateTime startTimeFromPicker = timeTimeStart.Value;
            DateTime endTimeFromPicker = timeTimeEnd.Value;

            DateTime fullStartDateTime = new DateTime(
                startDateFromPicker.Year,
                startDateFromPicker.Month,
                startDateFromPicker.Day,
                startTimeFromPicker.Hour,
                startTimeFromPicker.Minute,
                startTimeFromPicker.Second);

            DateTime fullEndDateTime = new DateTime(
                endDateFromPicker.Year,
                endDateFromPicker.Month,
                endDateFromPicker.Day,
                endTimeFromPicker.Hour,
                endTimeFromPicker.Minute,
                endTimeFromPicker.Second);

            DataTable dataTable = new DataTable();
            try
            {
                // Check if dgvResults has data
                if (dgvResults.DataSource == null || !(dgvResults.DataSource is DataTable) || ((DataTable)dgvResults.DataSource).Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất ra Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Get data from dgvResults
                dataTable = (DataTable)dgvResults.DataSource;

                // Call the export function with new parameters
                ExportDataTableToExcel(dataTable, "DOANH-THU-VANG-LAI", fullStartDateTime, fullEndDateTime);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất dữ liệu hoặc truy vấn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Khôi phục trạng thái UI
                btnExportRevenue.Enabled = true;
                this.Cursor = Cursors.Default;
                progressBarExport.Visible = false;
                progressBarExport.Value = 0;
            }
        }

        #endregion

        #region KHỐI XE VÀO
        private Bitmap GetBlackImage(int width, int height)
        {
            Bitmap blackImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(blackImage))
            {
                g.FillRectangle(Brushes.Black, 0, 0, blackImage.Width, blackImage.Height);
            }
            return blackImage;
        }

        private void btnXoaXeVao_Click(object sender, EventArgs e)
        {
            // Implement deletion logic for Xe Ra if needed
        }

        private void btnLocXeVao_Click(object sender, EventArgs e)
        {
            LoadXeVaoData();
        }
        private void LoadXeVaoData()
        {
            // InitializeDatabaseConnection(); // Ensure connection is open

            DateTime startDateFromPicker = dtXeVaoTuDate.Value;
            DateTime endDateFromPicker = dtXeVaoDenDate.Value;
            DateTime startTimeFromPicker = dtXeVaoTuTime.Value;
            DateTime endTimeFromPicker = dtXeVaoDenTime.Value;

            DateTime fullStartDateTime = new DateTime(
                startDateFromPicker.Year,
                startDateFromPicker.Month,
                startDateFromPicker.Day,
                startTimeFromPicker.Hour,
                startTimeFromPicker.Minute,
                startTimeFromPicker.Second);

            DateTime fullEndDateTime = new DateTime(
                endDateFromPicker.Year,
                endDateFromPicker.Month,
                endDateFromPicker.Day,
                endTimeFromPicker.Hour,
                endTimeFromPicker.Minute,
                endTimeFromPicker.Second);

            string selectedMaterialType = cbbXeVao.SelectedItem?.ToString();
            string soTheXeVao = txtSoTheXeVao.Text.Trim();
            string bienSoXeVao = txtBienSoXeVao.Text.Trim();

            string query = @"
        SELECT
            Vao.STTThe AS 'Số thẻ',
            Vao.CardID AS 'Mã thẻ',
            Vao.NgayVao AS 'Ngày vào',
            CONVERT(varchar, DATEADD(second, Vao.ThoiGian, 0), 108) AS 'Thời gian vào',
            Vao.MaLoaiThe AS 'Loại thẻ',
            Vao.IDXe,
            Vao.IDMat,
            Vao.soxe AS 'Biển số vào'
        FROM [dbo].[Vao] AS Vao
        LEFT JOIN [dbo].[Ra] AS Ra ON Vao.IDXe = Ra.IDXe
        WHERE Ra.IDXe IS NULL";

            // Add date/time filter
            query += @" AND (
                CAST(Vao.NgayVao AS DATETIME) +
                CAST(CONVERT(varchar, DATEADD(second, Vao.ThoiGian, 0), 108) AS DATETIME)
            ) BETWEEN @fullStartDateTime AND @fullEndDateTime";

            // Add card number filter
            if (!string.IsNullOrEmpty(soTheXeVao))
            {
                query += " AND Vao.STTThe LIKE @soTheXeVao";
            }

            // Add license plate filter
            if (!string.IsNullOrEmpty(bienSoXeVao))
            {
                query += " AND Vao.soxe LIKE @bienSoXeVao";
            }

            // Add material type filter
            if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
            {
                query += " AND Vao.MaLoaiThe = @MaterialType";
            }

            query += " ORDER BY Vao.NgayVao DESC, Vao.ThoiGian DESC;";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fullStartDateTime", fullStartDateTime);
                    command.Parameters.AddWithValue("@fullEndDateTime", fullEndDateTime);

                    if (!string.IsNullOrEmpty(soTheXeVao))
                    {
                        command.Parameters.AddWithValue("@soTheXeVao", "%" + soTheXeVao + "%");
                    }
                    if (!string.IsNullOrEmpty(bienSoXeVao))
                    {
                        command.Parameters.AddWithValue("@bienSoXeVao", "%" + bienSoXeVao + "%");
                    }
                    if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
                    {
                        command.Parameters.AddWithValue("@MaterialType", selectedMaterialType);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvXeVao.DataSource = dataTable;
                        dgvXeVao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi truy vấn dữ liệu xe vào: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvXeVao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadImagesFromXeVaoRow(dgvXeVao.Rows[e.RowIndex]);
            }
        }

        private void LoadImagesFromXeVaoRow(DataGridViewRow row)
        {
            // Clear exit images and info
            ptHinhMatRa.Image = GetBlackImage(ptHinhMatRa.Width, ptHinhMatRa.Height);
            ptHinhXeRa.Image = GetBlackImage(ptHinhXeRa.Width, ptHinhXeRa.Height);
            txtInfoRa.Text = "Thông tin ra: ";

            string idXe = "";
            DateTime ngayVao;
            // Update Info TextBoxes
            try
            {
                // --- Info Vào ---
                idXe = row.Cells["IDXe"].Value?.ToString();
                if (!string.IsNullOrEmpty(idXe) && idXe.Length >= 8 &&
                    DateTime.TryParseExact(idXe.Substring(0, 8), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out ngayVao) &&
                    TimeSpan.TryParse(row.Cells["Thời gian vào"].Value?.ToString(), out TimeSpan timeVao))
                {
                    txtInfoVaoVao.Text = $"Thông tin vào: Ngày {ngayVao.Day} tháng {ngayVao.Month} năm {ngayVao.Year} Thời gian: {timeVao.Hours} giờ {timeVao.Minutes} phút {timeVao.Seconds} giây";
                }
                else
                {
                    txtInfoVaoVao.Text = "Thông tin vào: Không có dữ liệu";
                }
            }
            catch (Exception)
            {
                txtInfoVaoVao.Text = "Thông tin vào: Lỗi định dạng dữ liệu";
            }

            if (row == null || row.Cells["IDMat"] == null || row.Cells["IDXe"] == null ||
                row.Cells["Mã thẻ"] == null || row.Cells["Ngày vào"] == null || row.Cells["Thời gian vào"] == null)
            {
                // Clear picture boxes if data is incomplete or row is null
                ptHinhMatVaoVao.Image = GetBlackImage(ptHinhMatVaoVao.Width, ptHinhMatVaoVao.Height);
                ptHinhXeVaoVao.Image = GetBlackImage(ptHinhXeVaoVao.Width, ptHinhXeVaoVao.Height);
                toolTip1.SetToolTip(ptHinhMatVaoVao, "Dữ liệu hàng không đầy đủ.");
                toolTip1.SetToolTip(ptHinhXeVaoVao, "Dữ liệu hàng không đầy đủ.");
                return;
            }

            string idMat = row.Cells["IDMat"].Value?.ToString();
            idXe = row.Cells["IDXe"].Value?.ToString();
            string cardId = row.Cells["Mã thẻ"].Value?.ToString(); // Lấy CardID

            // Attempt to parse NgayVao
            if (!DateTime.TryParse(row.Cells["Ngày vào"].Value?.ToString(), out ngayVao))
            {
                ptHinhMatVaoVao.Image = GetBlackImage(ptHinhMatVaoVao.Width, ptHinhMatVaoVao.Height);
                ptHinhXeVaoVao.Image = GetBlackImage(ptHinhXeVaoVao.Width, ptHinhXeVaoVao.Height);
                toolTip1.SetToolTip(ptHinhMatVaoVao, "Không thể phân tích ngày vào.");
                toolTip1.SetToolTip(ptHinhXeVaoVao, "Không thể phân tích ngày vào.");
                return;
            }

            string gioVaoString = row.Cells["Thời gian vào"].Value?.ToString();

            if (string.IsNullOrEmpty(gioVaoString))
            {
                ptHinhMatVaoVao.Image = GetBlackImage(ptHinhMatVaoVao.Width, ptHinhMatVaoVao.Height);
                ptHinhXeVaoVao.Image = GetBlackImage(ptHinhXeVaoVao.Width, ptHinhXeVaoVao.Height);
                toolTip1.SetToolTip(ptHinhMatVaoVao, "Không thể phân tích giờ vào.");
                toolTip1.SetToolTip(ptHinhXeVaoVao, "Không thể phân tích giờ vào.");
                return;
            }

            string folderPath = Properties.Settings.Default.SharedFolder;
            if (!string.IsNullOrEmpty(folderPath) && folderPath.StartsWith(@"\") && !folderPath.StartsWith(@"\\"))
            {
                folderPath = @"\\" + folderPath;
            }

            string yearMonthDay = ngayVao.ToString("yyyyMMdd");
            string fileNameMat = idMat + cardId;
            string fileNameXe = idXe + cardId;

            string imageMatVaoPath = Path.Combine(folderPath, "in", "mat", yearMonthDay, fileNameMat + ".jpg");
            string imageXeVaoPath = Path.Combine(folderPath, "in", "xe", yearMonthDay, fileNameXe + ".jpg");

            if (string.IsNullOrWhiteSpace(folderPath))
            {
                ptHinhMatVaoVao.Image = GetBlackImage(ptHinhMatVaoVao.Width, ptHinhMatVaoVao.Height);
                ptHinhXeVaoVao.Image = GetBlackImage(ptHinhXeVaoVao.Width, ptHinhXeVaoVao.Height);
                toolTip1.SetToolTip(ptHinhMatVaoVao, "Đường dẫn thư mục hình ảnh không được để trống.");
                toolTip1.SetToolTip(ptHinhXeVaoVao, "Đường dẫn thư mục hình ảnh không được để trống.");
                return;
            }

            LoadImageIntoPictureBox(ptHinhMatVaoVao, imageMatVaoPath);
            LoadImageIntoPictureBox(ptHinhXeVaoVao, imageXeVaoPath);
        }
        #endregion // End of KHỐI XE VÀO

        #region KHỐI XE RA
        private void LoadXeRaData()
        {
            InitializeDatabaseConnection(); // Ensure connection is open

            DateTime startDateFromPicker = dtXeRaTuDate.Value;
            DateTime endDateFromPicker = dtXeRaDenDate.Value;
            DateTime startTimeFromPicker = dtXeRaTuTime.Value;
            DateTime endTimeFromPicker = dtXeRaDenTime.Value;

            DateTime fullStartDateTime = new DateTime(
                startDateFromPicker.Year,
                startDateFromPicker.Month,
                startDateFromPicker.Day,
                startTimeFromPicker.Hour,
                startTimeFromPicker.Minute,
                startTimeFromPicker.Second);

            DateTime fullEndDateTime = new DateTime(
                endDateFromPicker.Year,
                endDateFromPicker.Month,
                endDateFromPicker.Day,
                endTimeFromPicker.Hour,
                endTimeFromPicker.Minute,
                endTimeFromPicker.Second);

            string selectedMaterialType = cbbXeRa.SelectedItem?.ToString();
            string soTheXeRa = txtSoTheXeRa.Text.Trim();
            string bienSoXeRa = txtBienSoXeRa.Text.Trim();

            string query = @"
SELECT
    Ra.STTThe AS 'Số thẻ',
    Ra.CardID AS 'Mã thẻ',
    Vao.NgayVao AS 'Ngày vào',
    CONVERT(varchar, DATEADD(second, Vao.ThoiGian, 0), 108) AS 'Thời gian vào',
    Ra.NgayRa AS 'Ngày ra',
    CONVERT(varchar, DATEADD(second, Ra.THoiGianRa, 0), 108) AS 'Thời gian ra',
    Ra.MaLoaiThe AS 'Loại thẻ',
    Ra.GiaTien AS 'Tiền thu',
    Ra.IDXe,
    Ra.IDMat,
    Ra.soxe AS 'Biển số vào',
    Ra.soxera AS 'Biển số ra'
FROM
[dbo].[Ra]
INNER JOIN [dbo].[Vao] ON Ra.IDXe = Vao.IDXe
                WHERE 1=1 "; // Start with a true condition to easily append AND clauses

            // Add date/time filter
            query += @" AND (
                CAST(NgayRa AS DATETIME) +
                CAST(
                    RIGHT('0' + CAST(GioRa / 1000000 AS VARCHAR(2)), 2) + ':' +
                    RIGHT('0' + CAST((GioRa / 10000) % 100 AS VARCHAR(2)), 2) + ':' +
                    RIGHT('0' + CAST((GioRa / 100) % 100 AS VARCHAR(2)), 2) + '.' +
                    RIGHT('0' + CAST(GioRa % 100 AS VARCHAR(2)), 2)
                AS DATETIME)
            ) BETWEEN @fullStartDateTime AND @fullEndDateTime";

            // Add card number filter
            if (!string.IsNullOrEmpty(soTheXeRa))
            {
                query += " AND Ra.STTThe LIKE @soTheXeRa";
            }

            // Add license plate filter
            if (!string.IsNullOrEmpty(bienSoXeRa))
            {
                query += " AND (Ra.soxe LIKE @bienSoXeRa OR Ra.soxera LIKE @bienSoXeRa)";
            }

            // Add material type filter
            if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
            {
                query += " AND Ra.MaLoaiThe = @MaterialType";
            }

            query += " ORDER BY Ra.NgayRa DESC, Ra.GioRa DESC;";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fullStartDateTime", fullStartDateTime);
                    command.Parameters.AddWithValue("@fullEndDateTime", fullEndDateTime);

                    if (!string.IsNullOrEmpty(soTheXeRa))
                    {
                        command.Parameters.AddWithValue("@soTheXeRa", "%" + soTheXeRa + "%");
                    }
                    if (!string.IsNullOrEmpty(bienSoXeRa))
                    {
                        command.Parameters.AddWithValue("@bienSoXeRa", "%" + bienSoXeRa + "%");
                    }
                    if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
                    {
                        command.Parameters.AddWithValue("@MaterialType", selectedMaterialType);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvXeRa.DataSource = dataTable;
                        dgvXeRa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi truy vấn dữ liệu xe ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLocXeRa_Click(object sender, EventArgs e)
        {
            LoadXeRaData();
        }

        private void dgvXeRa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadImagesFromSelectedRow(dgvXeRa.Rows[e.RowIndex]);
            }
        }

        private void LoadImagesFromSelectedRow(DataGridViewRow row)
        {
            string idXe = "";
            DateTime ngayVao;
            // Update Info TextBoxes
            try
            {
                // --- Info Vào ---
                idXe = row.Cells["IDXe"].Value?.ToString();
                if (!string.IsNullOrEmpty(idXe) && idXe.Length >= 8 &&
                    DateTime.TryParseExact(idXe.Substring(0, 8), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out ngayVao) &&
                    TimeSpan.TryParse(row.Cells["Thời gian vào"].Value?.ToString(), out TimeSpan timeVao))
                {
                    txtInfoVao.Text = $"Thông tin vào: Ngày {ngayVao.Day} tháng {ngayVao.Month} năm {ngayVao.Year} Thời gian: {timeVao.Hours} giờ {timeVao.Minutes} phút {timeVao.Seconds} giây";
                }
                else
                {
                    txtInfoVao.Text = "Thông tin vào: Không có dữ liệu";
                }

                // --- Info Ra ---
                if (DateTime.TryParse(row.Cells["Ngày ra"].Value?.ToString(), out DateTime ngayRa) &&
                    TimeSpan.TryParse(row.Cells["Thời gian ra"].Value?.ToString(), out TimeSpan timeRa))
                {
                    txtInfoRa.Text = $"Thông tin ra: Ngày {ngayRa.Day} tháng {ngayRa.Month} năm {ngayRa.Year} Thời gian: {timeRa.Hours} giờ {timeRa.Minutes} phút {timeRa.Seconds} giây";
                }
                else
                {
                    txtInfoRa.Text = "Thông tin ra: Không có dữ liệu";
                }
            }
            catch (Exception)
            {
                txtInfoVao.Text = "Thông tin vào: Lỗi định dạng dữ liệu";
                txtInfoRa.Text = "Thông tin ra: Lỗi định dạng dữ liệu";
            }

            if (row == null || row.Cells["IDMat"] == null || row.Cells["IDXe"] == null ||
                row.Cells["Mã thẻ"] == null || row.Cells["Ngày vào"] == null || row.Cells["Thời gian vào"] == null)
            {
                // Clear picture boxes if data is incomplete or row is null
                ptHinhMatRa.Image = GetBlackImage(ptHinhMatRa.Width, ptHinhMatRa.Height);
                ptHinhXeRa.Image = GetBlackImage(ptHinhXeRa.Width, ptHinhXeRa.Height);
                toolTip1.SetToolTip(ptHinhMatRa, "Dữ liệu hàng không đầy đủ.");
                toolTip1.SetToolTip(ptHinhXeRa, "Dữ liệu hàng không đầy đủ.");
                return;
            }

            string idMat = row.Cells["IDMat"].Value?.ToString();
            idXe = row.Cells["IDXe"].Value?.ToString();
            string cardId = row.Cells["Mã thẻ"].Value?.ToString(); // Lấy CardID



            // Attempt to parse NgayVao
            if (!DateTime.TryParse(row.Cells["Ngày vào"].Value?.ToString(), out ngayVao))
            {
                ptHinhMatRa.Image = GetBlackImage(ptHinhMatRa.Width, ptHinhMatRa.Height);
                ptHinhXeRa.Image = GetBlackImage(ptHinhXeRa.Width, ptHinhXeRa.Height);
                toolTip1.SetToolTip(ptHinhMatRa, "Không thể phân tích ngày vào.");
                toolTip1.SetToolTip(ptHinhXeRa, "Không thể phân tích ngày vào.");
                return;
            }

            string gioVaoString = row.Cells["Thời gian vào"].Value?.ToString();

            if (string.IsNullOrEmpty(gioVaoString))
            {
                ptHinhMatRa.Image = GetBlackImage(ptHinhMatRa.Width, ptHinhMatRa.Height);
                ptHinhXeRa.Image = GetBlackImage(ptHinhXeRa.Width, ptHinhXeRa.Height);
                toolTip1.SetToolTip(ptHinhMatRa, "Không thể phân tích giờ vào.");
                toolTip1.SetToolTip(ptHinhXeRa, "Không thể phân tích giờ vào.");
                ptHinhMatVao.Image = GetBlackImage(ptHinhMatVao.Width, ptHinhMatVao.Height);
                ptHinhXeVao.Image = GetBlackImage(ptHinhXeVao.Width, ptHinhXeVao.Height);
                toolTip1.SetToolTip(ptHinhMatRa, "Không thể phân tích giờ vào.");
                toolTip1.SetToolTip(ptHinhXeRa, "Không thể phân tích giờ vào.");
                return;
            }

            string folderPath = Properties.Settings.Default.SharedFolder;
            if (!string.IsNullOrEmpty(folderPath) && folderPath.StartsWith(@"\") && !folderPath.StartsWith(@"\\"))
            {
                folderPath = @"\\" + folderPath;
            }

            string yearMonthDay = ngayVao.ToString("yyyyMMdd");
            // Tạo tên tệp hình ảnh theo định dạng: ngayVao (yyyyMMdd) + gioVaoFormatted (HHmmss) + CardID
            string fileNameMat = idMat + cardId;
            string fileNameXe = idXe + cardId;

            //string imageMatPath = Path.Combine("\\\\192.168.1.99\\Hinh", "out", "mat", yearMonthDay, fileNameMat + ".jpg");
            //string imageXePath = Path.Combine("\\\\192.168.1.99\\Hinh", "out", "xe", yearMonthDay, fileNameXe + ".jpg");
            string imageMatPath = Path.Combine(folderPath, "out", "mat", yearMonthDay, fileNameMat + ".jpg");
            string imageXePath = Path.Combine(folderPath, "out", "xe", yearMonthDay, fileNameXe + ".jpg");
            string imageMatVaoPath = Path.Combine(folderPath, "in", "mat", yearMonthDay, fileNameMat + ".jpg");
            string imageXeVaoPath = Path.Combine(folderPath, "in", "xe", yearMonthDay, fileNameXe + ".jpg");

            if (string.IsNullOrWhiteSpace(folderPath))
            {
                // Thay vì MessageBox.Show, đặt hình ảnh là màu đen
                ptHinhMatRa.Image = GetBlackImage(ptHinhMatRa.Width, ptHinhMatRa.Height);
                ptHinhXeRa.Image = GetBlackImage(ptHinhXeRa.Width, ptHinhXeRa.Height);
                toolTip1.SetToolTip(ptHinhMatRa, "Đường dẫn thư mục hình ảnh không được để trống.");
                toolTip1.SetToolTip(ptHinhXeRa, "Đường dẫn thư mục hình ảnh không được để trống.");
                ptHinhMatVao.Image = GetBlackImage(ptHinhMatVao.Width, ptHinhMatVao.Height);
                ptHinhXeVao.Image = GetBlackImage(ptHinhXeVao.Width, ptHinhXeVao.Height);
                toolTip1.SetToolTip(ptHinhMatVao, "Đường dẫn thư mục hình ảnh không được để trống.");
                toolTip1.SetToolTip(ptHinhXeVao, "Đường dẫn thư mục hình ảnh không được để trống.");
                return;
            }
            else
            {

            }


            LoadImageIntoPictureBox(ptHinhMatVao, imageMatVaoPath);
            LoadImageIntoPictureBox(ptHinhXeVao, imageXeVaoPath);
            LoadImageIntoPictureBox(ptHinhMatRa, imageMatPath);
            LoadImageIntoPictureBox(ptHinhXeRa, imageXePath);

        }

        private void LoadImageIntoPictureBox(Guna.UI2.WinForms.Guna2PictureBox pictureBox, string imagePath)
        {
            try
            {
                if (File.Exists(imagePath))
                {
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        pictureBox.Image = Image.FromStream(fs);
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Or other suitable layout
                    }
                    toolTip1.SetToolTip(pictureBox, imagePath);
                }
                else
                {
                    pictureBox.Image = GetBlackImage(pictureBox.Width, pictureBox.Height); // Đặt hình ảnh màu đen
                    toolTip1.SetToolTip(pictureBox, "Image not found: " + imagePath);
                }
            }
            catch (Exception ex)
            {
                pictureBox.Image = GetBlackImage(pictureBox.Width, pictureBox.Height); // Đặt hình ảnh màu đen
                toolTip1.SetToolTip(pictureBox, "Error loading image: " + ex.Message);
                Console.WriteLine($"Error loading image {imagePath}: {ex.Message}");
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            lastClickedPictureBox = sender as Guna.UI2.WinForms.Guna2PictureBox;
            if (lastClickedPictureBox == null) return;

            string imagePath = GetSingleImagePathForCurrentRow(lastClickedPictureBox);

            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
            {
                MessageBox.Show("Không tìm thấy hình ảnh để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var imageList = new List<string> { imagePath };

            if (imageViewerInstance == null || imageViewerInstance.IsDisposed)
            {
                imageViewerInstance = new ImageViewerForm(imageList, 0);
                imageViewerInstance.FormClosed += (s, args) => imageViewerInstance = null;
                // Subscribe to the new events
                imageViewerInstance.RequestNextImage += Viewer_RequestNextImage;
                imageViewerInstance.RequestPreviousImage += Viewer_RequestPreviousImage;
                imageViewerInstance.Show();
            }
            else
            {
                imageViewerInstance.UpdateAndShowImage(imageList, 0);
            }
        }

        private void Viewer_RequestNextImage(object sender, EventArgs e)
        {
            NavigateGrid(1);
        }

        private void Viewer_RequestPreviousImage(object sender, EventArgs e)
        {
            NavigateGrid(-1);
        }

        private void NavigateGrid(int direction)
        {
            DataGridView dgv = null;
            if (tabControl.SelectedIndex == 0) // Xe Vao
            {
                dgv = dgvXeVao;
            }
            else if (tabControl.SelectedIndex == 1) // Xe Ra
            {
                dgv = dgvXeRa;
            }

            if (dgv == null || dgv.Rows.Count == 0 || dgv.CurrentRow == null) return;

            int newIndex = dgv.CurrentRow.Index + direction;

            if (newIndex >= 0 && newIndex < dgv.Rows.Count)
            {
                dgv.CurrentCell = dgv.Rows[newIndex].Cells[0]; // Change selection

                // Update images based on the active tab
                if (tabControl.SelectedIndex == 0)
                {
                    LoadImagesFromXeVaoRow(dgv.Rows[newIndex]);
                }
                else
                {
                    LoadImagesFromSelectedRow(dgv.Rows[newIndex]);
                }


                // Update viewer if it's open
                if (imageViewerInstance != null && !imageViewerInstance.IsDisposed && lastClickedPictureBox != null)
                {
                    string newImagePath = GetSingleImagePathForCurrentRow(lastClickedPictureBox);
                    if (!string.IsNullOrEmpty(newImagePath) && File.Exists(newImagePath))
                    {
                        imageViewerInstance.UpdateAndShowImage(new List<string> { newImagePath }, 0);
                    }
                }
            }
        }
        #endregion // End of KHỐI XE RA

        private string GetSingleImagePathForCurrentRow(Guna.UI2.WinForms.Guna2PictureBox clickedPictureBox)
        {
            DataGridView dgv = null;
            if (tabControl.SelectedIndex == 0) // Xe Vao
            {
                dgv = dgvXeVao;
            }
            else if (tabControl.SelectedIndex == 1) // Xe Ra
            {
                dgv = dgvXeRa;
            }

            if (dgv == null || dgv.CurrentRow == null || clickedPictureBox == null) return null;

            DataGridViewRow row = dgv.CurrentRow;

            // Determine image type and direction from the clicked control
            string imageType = "";
            string direction = "";
            if (clickedPictureBox == ptHinhMatVao || clickedPictureBox == ptHinhMatVaoVao) { imageType = "mat"; direction = "in"; }
            else if (clickedPictureBox == ptHinhXeVao || clickedPictureBox == ptHinhXeVaoVao) { imageType = "xe"; direction = "in"; }
            else if (clickedPictureBox == ptHinhMatRa) { imageType = "mat"; direction = "out"; }
            else if (clickedPictureBox == ptHinhXeRa) { imageType = "xe"; direction = "out"; }
            else return null; // Should not happen if wired correctly

            // Common data extraction
            if (row.Cells["IDMat"]?.Value == null || row.Cells["IDXe"]?.Value == null ||
                row.Cells["Mã thẻ"]?.Value == null || row.Cells["Ngày vào"]?.Value == null)
            {
                return null;
            }

            string idMat = row.Cells["IDMat"].Value.ToString();
            string idXe = row.Cells["IDXe"].Value.ToString();
            string cardId = row.Cells["Mã thẻ"].Value.ToString();

            if (!DateTime.TryParse(row.Cells["Ngày vào"].Value.ToString(), out DateTime ngayVao)) return null;

            string folderPath = Properties.Settings.Default.SharedFolder;
            if (string.IsNullOrWhiteSpace(folderPath)) return null;
            if (folderPath.StartsWith(@"\") && !folderPath.StartsWith(@"\\"))
            {
                folderPath = @"\\" + folderPath;
            }

            string yearMonthDay = ngayVao.ToString("yyyyMMdd");
            string fileName = (imageType == "mat") ? (idMat + cardId) : (idXe + cardId);

            return Path.Combine(folderPath, direction, imageType, yearMonthDay, fileName + ".jpg");
        }

        private void pictureBoxMatRa_Click(object sender, EventArgs e)
        {
            OpenImageViewer(ptHinhMatRa);
        }

        private void pictureBoxXeRa_Click(object sender, EventArgs e)
        {
            OpenImageViewer(ptHinhXeRa);
        }

        private void OpenImageViewer(Guna.UI2.WinForms.Guna2PictureBox clickedPictureBox)
        {
            DataGridView dgv = null;
            if (tabControl.SelectedIndex == 0) // Xe Vao
            {
                dgv = dgvXeVao;
            }
            else if (tabControl.SelectedIndex == 1) // Xe Ra
            {
                dgv = dgvXeRa;
            }

            if (dgv == null || dgv.CurrentRow == null) return;

            DataGridViewRow row = dgv.CurrentRow;

            if (row.Cells["IDMat"] == null || row.Cells["IDXe"] == null ||
                row.Cells["Mã thẻ"] == null || row.Cells["Ngày vào"] == null || row.Cells["Thời gian vào"] == null)
            {
                return;
            }

            string idMat = row.Cells["IDMat"].Value?.ToString();
            string idXe = row.Cells["IDXe"].Value?.ToString();
            string cardId = row.Cells["Mã thẻ"].Value?.ToString(); // Lấy CardID

            DateTime ngayVao;

            // Attempt to parse NgayVao
            if (!DateTime.TryParse(row.Cells["Ngày vào"].Value?.ToString(), out ngayVao))
            {
                ptHinhMatRa.Image = GetBlackImage(ptHinhMatRa.Width, ptHinhMatRa.Height);
                ptHinhXeRa.Image = GetBlackImage(ptHinhXeRa.Width, ptHinhXeRa.Height);
                toolTip1.SetToolTip(ptHinhMatRa, "Không thể phân tích ngày vào.");
                toolTip1.SetToolTip(ptHinhXeRa, "Không thể phân tích ngày vào.");
                return;
            }

            string gioVaoString = row.Cells["Thời gian vào"].Value?.ToString();

            if (string.IsNullOrEmpty(gioVaoString))
            {
                ptHinhMatRa.Image = GetBlackImage(ptHinhMatRa.Width, ptHinhMatRa.Height);
                ptHinhXeRa.Image = GetBlackImage(ptHinhXeRa.Width, ptHinhXeRa.Height);
                toolTip1.SetToolTip(ptHinhMatRa, "Không thể phân tích giờ vào.");
                toolTip1.SetToolTip(ptHinhXeRa, "Không thể phân tích giờ vào.");
                ptHinhMatVao.Image = GetBlackImage(ptHinhMatVao.Width, ptHinhMatVao.Height);
                ptHinhXeVao.Image = GetBlackImage(ptHinhXeVao.Width, ptHinhXeVao.Height);
                toolTip1.SetToolTip(ptHinhMatRa, "Không thể phân tích giờ vào.");
                toolTip1.SetToolTip(ptHinhXeRa, "Không thể phân tích giờ vào.");
                return;
            }

            string folderPath = Properties.Settings.Default.SharedFolder;
            if (!string.IsNullOrEmpty(folderPath) && folderPath.StartsWith(@"\") && !folderPath.StartsWith(@"\\"))
            {
                folderPath = @"\\" + folderPath;
            }

            string yearMonthDay = ngayVao.ToString("yyyyMMdd");
            // Tạo tên tệp hình ảnh theo định dạng: ngayVao (yyyyMMdd) + gioVaoFormatted (HHmmss) + CardID
            string fileNameMat = idMat + cardId;
            string fileNameXe = idXe + cardId;

            string imageMatPath = Path.Combine(folderPath, "out", "mat", yearMonthDay, fileNameMat + ".jpg");
            string imageXePath = Path.Combine(folderPath, "out", "xe", yearMonthDay, fileNameXe + ".jpg");
            string imageMatVaoPath = Path.Combine(folderPath, "in", "mat", yearMonthDay, fileNameMat + ".jpg");
            string imageXeVaoPath = Path.Combine(folderPath, "in", "xe", yearMonthDay, fileNameXe + ".jpg");
            List<string> imagePaths = new List<string>();
            int startIndex = 0;

            if (File.Exists(imageMatVaoPath))
            {
                imagePaths.Add(imageMatVaoPath);
            }
            if (File.Exists(imageXeVaoPath))
            {
                if (clickedPictureBox == ptHinhXeVao || clickedPictureBox == ptHinhXeVaoVao)
                {
                    startIndex = imagePaths.Count;
                }
                imagePaths.Add(imageXeVaoPath);
            }

            if (tabControl.SelectedIndex == 1) // Only add "out" images for Xe Ra tab
            {
                if (File.Exists(imageMatPath))
                {
                    if (clickedPictureBox == ptHinhMatRa)
                    {
                        startIndex = imagePaths.Count;
                    }
                    imagePaths.Add(imageMatPath);
                }
                if (File.Exists(imageXePath))
                {
                    if (clickedPictureBox == ptHinhXeRa)
                    {
                        startIndex = imagePaths.Count;
                    }
                    imagePaths.Add(imageXePath);
                }
            }


            if (imagePaths.Any())
            {
                ImageViewerForm imageViewer = new ImageViewerForm(imagePaths, startIndex);
                imageViewer.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không tìm thấy hình ảnh nào để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvXeRa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Allow the DataGridView to handle the navigation first
                // Then load images for the newly selected row
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    if (dgvXeRa.CurrentRow != null)
                    {
                        LoadImagesFromSelectedRow(dgvXeRa.CurrentRow);
                    }
                }));
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLocXeRa.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void dgvXeRa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void ClearAllSettings()
        {
            txtServer_Main.Text = "";
            txtDatabase_Main.Text = "";
            txtUsername_Main.Text = "";
            txtPassword_Main.Text = "";
            txtFolder_Main.Text = "";
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            MessageBox.Show("Tất cả cài đặt đã được xóa về mặc định.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClearConnect_Click(object sender, EventArgs e)
        {
            ClearAllSettings();
        }

        private void txtQuerry_CaiDat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string query = txtQuerry_CaiDat.SelectedText.Trim();
                if (!string.IsNullOrEmpty(query))
                {
                    try
                    {
                        if (connection == null || connection.State != ConnectionState.Open)
                        {
                            MessageBox.Show("Vui lòng kết nối cơ sở dữ liệu trước khi thực hiện truy vấn.", "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);
                                dgvQuery_CaiDat.DataSource = dataTable;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi truy vấn SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    e.SuppressKeyPress = true; // Chỉ chặn Enter khi có truy vấn được thực thi
                }
                // Nếu không có text nào được bôi đen, không làm gì cả, để Enter tự xuống dòng
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được viết...", "Lỗi Kết Nối", MessageBoxButtons.OK);
        }

        private void btnExitProgram_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
