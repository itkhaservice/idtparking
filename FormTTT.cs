using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;  
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace IDT_PARKING
{
    public partial class FormTTT : System.Windows.Forms.Form
    {
        

        private SqlConnection connection;
        private SqlConnection _connection;
        private DataTable _currentQueryResult;

        public string txtServer = Properties.Settings.Default.ServerAddress;
        public string txtDatabase = Properties.Settings.Default.DatabaseName;
        public string txtFolder = Properties.Settings.Default.SharedFolder;
        public string txtUsername = Properties.Settings.Default.Username;
        public string txtPassword = Properties.Settings.Default.Password;

        public FormTTT(DataTable currentQueryResult)
        {
            _currentQueryResult = currentQueryResult;
        }



        public FormTTT()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            // Ẩn ProgressBar và Label trạng thái ban đầu

        }


        private void btnQuery_Click(object sender, EventArgs e)
        {
 
        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvResults.Rows.Count == 0 || e.RowIndex < 0 || e.RowIndex >= dgvResults.Rows.Count - (dgvResults.AllowUserToAddRows ? 1 : 0))
            //{
            //    return;
            //}
            //if (e.ColumnIndex == dgvResults.Columns["DeleteColumn"].Index && e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = dgvResults.Rows[e.RowIndex];

            //    string cardIdToUpdate = row.Cells["ID CARD"].Value.ToString();
            //    string idXeToUpdate = row.Cells["ID VEHICLE"].Value.ToString();
            //    string idMatToUpdate = row.Cells["ID NO"].Value.ToString();

            //    DialogResult result = MessageBox.Show($"Are you sure you want to set GiaTien of the row:\'ID CARD': {cardIdToUpdate}\n'ID VEHICLE': {idXeToUpdate}\n'ID NO': {idMatToUpdate} to 0.0000?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //    if (result == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            string updateQuery = "UPDATE [dbo].[Ra] SET GiaTien = 0.00 WHERE CardID = @cardId AND IDXe = @idXe AND IDMat = @idMat;";

            //            SqlCommand command = new SqlCommand(updateQuery, connection);

            //            command.Parameters.AddWithValue("@cardId", cardIdToUpdate);
            //            command.Parameters.AddWithValue("@idXe", idXeToUpdate);
            //            command.Parameters.AddWithValue("@idMat", idMatToUpdate);

            //            command.ExecuteNonQuery();

            //            row.Cells["PRICE"].Value = 0.0000;

            //            MessageBox.Show("Price has been updated to 0.00!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show($"Error updating price: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
 
        }


//        private void btnBackup_Click(object sender, EventArgs e)
//        {
//            string serverAddress = txtServer; // tên server hoặc IP
//            string databaseName = txtDatabase;
//            string uid = txtUsername;
//            string password = txtPassword;
//            string clientUNCPath = txtFolder; // thư mục UNC hoặc đường dẫn đích

//            // Tên file backup
//            string backupFileName = $"{databaseName}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
//            string destBackupFile = Path.Combine(clientUNCPath, backupFileName);

//            // Chuỗi kết nối SQL Server
//            string connectionString;
//            if (string.IsNullOrWhiteSpace(uid))
//            {
//                connectionString = $"Server={serverAddress};Database=master;Integrated Security=True;TrustServerCertificate=True;";
//            }
//            else
//            {
//                connectionString = $"Server={serverAddress};Database=master;User ID={uid};Password={password};TrustServerCertificate=True;";
//            }

//            try
//            {
//                using (SqlConnection conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();

//                    // Tạo thư mục đích nếu chưa có (nếu là UNC hoặc local path mà SQL có quyền)
//                    string createFolderCmd = $"EXEC xp_cmdshell 'if not exist \"{clientUNCPath}\" mkdir \"{clientUNCPath}\"'";
//                    using (SqlCommand cmd = new SqlCommand(createFolderCmd, conn))
//                    {
//                        cmd.ExecuteNonQuery();
//                    }

//                    // Backup trực tiếp đến thư mục đích
//                    string backupCmd = $@"
//BACKUP DATABASE [{databaseName}]
//TO DISK = N'{destBackupFile}'
//WITH INIT, STATS = 10";
//                    using (SqlCommand cmd = new SqlCommand(backupCmd, conn))
//                    {
//                        cmd.CommandTimeout = 3600; // cho phép thời gian backup dài
//                        cmd.ExecuteNonQuery();
//                    }
//                }

//                MessageBox.Show(
//                    $"Đã backup DB '{databaseName}' **thành công** đến:\n{destBackupFile}",
//                    "Backup thành công",
//                    MessageBoxButtons.OK,
//                    MessageBoxIcon.Information);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Lỗi backup: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }

//        }

        //private void Connection_InfoMessage_Backup(object sender, SqlInfoMessageEventArgs e)
        //{
        //    // Các thông báo STATS sẽ có dạng "XX percent processed."
        //    // Chúng ta cần phân tích chuỗi này để lấy phần trăm.
        //    string message = e.Message;
        //    // Kiểm tra xem thông báo có chứa thông tin tiến độ hay không
        //    if (message.Contains("percent processed."))
        //    {
        //        // Sử dụng Regex để trích xuất số phần trăm
        //        System.Text.RegularExpressions.Match match =
        //            System.Text.RegularExpressions.Regex.Match(message, @"^(\d+) percent processed.$");

        //        if (match.Success)
        //        {
        //            if (int.TryParse(match.Groups[1].Value, out int percentComplete))
        //            {
        //                // Cập nhật ProgressBar trên UI Thread
        //                // Cần dùng Invoke vì sự kiện này được gọi từ một thread khác (do Task.Run)
        //                if (this.progressBarExport.InvokeRequired)
        //                {
        //                    this.Invoke((MethodInvoker)delegate
        //                    {
        //                        // Đảm bảo giá trị trong khoảng hợp lệ [0, 100]
        //                        progressBarExport.Value = Math.Min(100, Math.Max(0, percentComplete));
        //                    });
        //                }
        //                else
        //                {
        //                    progressBarExport.Value = Math.Min(100, Math.Max(0, percentComplete));
        //                }
        //            }
        //        }
        //    }
        //}

        //private void btnEqual_Click(object sender, EventArgs e)
        //{
        //    // Lấy giá trị ngày từ DateTimePicker đầu tiên
        //    DateTime startDateValue = dateTimeStart.Value;

        //    // Gán giá trị này cho DateTimePicker thứ hai
        //    dateTimeEnd.Value = startDateValue;

        //    // Hiển thị một thông báo (tùy chọn)
        //    MessageBox.Show("End Date has been set to the same as Start Date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        private void btnMonth_Click(object sender, EventArgs e)
        {
            InitializeDatabaseConnection();
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Chưa kết nối với cơ sở dữ liệu. Vui lòng kết nối trước..", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MonthYearSelectorDialog selector = new MonthYearSelectorDialog();
            if (selector.ShowDialog() == DialogResult.OK)
            {
                int selectedMonth = selector.SelectedMonth;
                int selectedYear = selector.SelectedYear;

                string query = BuildMonthSummaryQuery(selectedMonth, selectedYear);

                try
                {
                    using (SqlCommand command = new SqlCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@selectedMonth", selectedMonth);
                        command.Parameters.AddWithValue("@selectedYear", selectedYear);

                        _currentQueryResult.Clear();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(_currentQueryResult);
                        }

                        //DisplayMonthSummaryResults(_currentQueryResult);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi truy vấn dữ liệu tháng: {ex.Message}\n\nVui lòng kiểm tra lại kết nối và dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string BuildMonthSummaryQuery(int month, int year)
        {
            string query = @"
        SELECT
            CAST(NgayRa AS DATE) AS 'DATE',
            SUM(GiaTien) AS 'SUM'
        FROM [dbo].[Ra]
        WHERE GiaTien > 0
          AND MONTH(NgayRa) = @selectedMonth
          AND YEAR(NgayRa) = @selectedYear
        GROUP BY CAST(NgayRa AS DATE)
        ORDER BY CAST(NgayRa AS DATE);
    ";
            return query;
        }

        //private void DisplayMonthSummaryResults(DataTable dataTable)
        //{
        //    dgvResults.DataSource = dataTable;
        //    dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        //    if (dataTable.Rows.Count > 0)
        //    {
        //        btnUpdate.Enabled = false;
        //        btnDelete.Enabled = false;  
        //    }
        //    else
        //    {
        //        btnUpdate.Enabled = false;
        //        btnDelete.Enabled = false;  
        //    }
        //    decimal totalGiaTien = 0;

        //    if (dataTable.Columns.Contains("SUM"))
        //    {
        //        foreach (DataRow row in dataTable.Rows)
        //        {
        //            if (row["SUM"] != DBNull.Value && decimal.TryParse(row["SUM"].ToString(), out decimal giaTien))
        //            {
        //                totalGiaTien += giaTien;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Column 'SUM' not found in query results. Cannot calculate sum.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }

        //    txtSum.Text = totalGiaTien.ToString("N0") + " VNĐ";
        //}

        private void InitializeDatabaseConnection()
        {
            try
            {
                string serverAddress = txtServer;
                string databaseName = txtDatabase;
                string uid = txtUsername;
                string password = txtPassword;
                string connectionString;
                if (string.IsNullOrWhiteSpace(uid))
                {
                    connectionString = $"Server={serverAddress};Database={databaseName};Integrated Security=True;TrustServerCertificate=True;";
                }
                else
                {
                    connectionString = $"Server={serverAddress};Database={databaseName};User ID={uid};Password={password};TrustServerCertificate=True;";
                }

                connection = new SqlConnection(connectionString);
                connection.Open();
                MessageBox.Show("Kết nối cơ sở dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}\n\nVui lòng kiểm tra lại chuỗi kết nối.", "Lỗi Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisableDatabaseFunctions();
            }
        }

        private void DisableDatabaseFunctions()
        {
            //btnQuery.Enabled = false;
            //btnUpdate.Enabled = false;
            //btnDelete.Enabled = false;
            //btnMonth.Enabled = false;
        }



        


        //private void btnConsignment_Click(object sender, EventArgs e)
        //{
        //    //InitializeDatabaseConnection();
        //    if (connection == null || connection.State != ConnectionState.Open)
        //    {
        //        MessageBox.Show("Chưa kết nối với cơ sở dữ liệu. Vui lòng kết nối trước..", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    string query = "select a.SoTT, a.CardID, a.MaLoaiThe, a.NgayBD, a.NgayKT, a.soxe, b.hoten, b.dienthoai, b.chungloai, b.DonVi, b.DiaChi from TheThang a, KhachHang b where a.MaKH = b.MaKH\r\n";
        //    try
        //    {
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {


        //            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        //            {
        //                btnUpdate.Enabled = false;
        //                btnDelete.Enabled = false;
        //                DataTable dataTable = new DataTable();
        //                adapter.Fill(dataTable);
        //                int rowCount = dataTable.Rows.Count;
        //                txtCount.Text = rowCount.ToString("N0");
        //                btnExport.Enabled = true;
        //                dgvResults.DataSource = dataTable;
        //                dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //                txtSum.Text = "";
        //                txtCount.Text = dataTable.Rows.Count.ToString("N0");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Query error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btnExport_Click(object sender, EventArgs e)
        //{
        //    // Vô hiệu hóa nút Export và hiển thị ProgressBar
        //    btnExportRevenue.Enabled = false;
        //    this.Cursor = Cursors.WaitCursor;
        //    progressBarExport.Visible = true;
        //    progressBarExport.Value = 0;

        //    DataTable dataTable = new DataTable();
        //    SqlConnection localConnection = null; // Tạo kết nối cục bộ để đảm bảo đóng
        //    try
        //    {
        //        InitializeDatabaseConnection();
        //        if (_connection == null || _connection.State != ConnectionState.Open)
        //        {
        //            MessageBox.Show("Chưa kết nối với cơ sở dữ liệu. Vui lòng kết nối trước.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        // Tạo và mở kết nối cục bộ
        //        string serverAddress = txtServer;
        //        string databaseName = txtDatabase;
        //        string uid = txtUsername;
        //        string password = txtPassword;

        //        string connectionString;
        //        if (string.IsNullOrWhiteSpace(uid))
        //        {
        //            connectionString = $"Server={serverAddress};Database={databaseName};Integrated Security=True;TrustServerCertificate=True;";
        //        }
        //        else
        //        {
        //            connectionString = $"Server={serverAddress};Database={databaseName};User ID={uid};Password={password};TrustServerCertificate=True;";
        //        }
        //        localConnection = new SqlConnection(connectionString);
        //        localConnection.Open();

        //        string query = "SELECT a.SoTT, a.CardID, a.MaLoaiThe, a.NgayBD, a.NgayKT, a.soxe, b.hoten, b.dienthoai, b.chungloai, b.DonVi, b.DiaChi " +
        //                       "FROM TheThang a JOIN KhachHang b ON a.MaKH = b.MaKH";

        //        using (SqlCommand command = new SqlCommand(query, localConnection))
        //        {
        //            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        //            {
        //                adapter.Fill(dataTable);
        //            }
        //        }

        //        if (dataTable.Rows.Count == 0)
        //        {
        //            MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }

        //        // Gọi hàm xuất Excel với DataTable đã có
        //        ExportDataTableToExcel(dataTable, "DANH-SACH-THE-THANG");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi truy vấn dữ liệu hoặc xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        // Đảm bảo kết nối cục bộ được đóng
        //        if (localConnection != null && localConnection.State == ConnectionState.Open)
        //        {
        //            localConnection.Close();
        //            localConnection.Dispose();
        //        }

        //        // Khôi phục trạng thái UI
        //        btnExportRevenue.Enabled = true;
        //        this.Cursor = Cursors.Default;
        //        progressBarExport.Visible = false;
        //        progressBarExport.Value = 0;
        //    }
        //}
        



//        private void btnExportRevenue_Click(object sender, EventArgs e)
//        {
//            // Vô hiệu hóa nút và hiển thị ProgressBar (giữ nguyên)
//            btnExportRevenue.Enabled = false; // Vô hiệu hóa nút Export Revenue
//            this.Cursor = Cursors.WaitCursor;
//            progressBarExport.Visible = true;
//            progressBarExport.Value = 0;

//            DataTable dataTable = new DataTable();
//            SqlConnection localConnection = null; // Tạo kết nối cục bộ để đảm bảo đóng

//            try
//            {
//                // Giữ nguyên logic kiểm tra và lấy chuỗi kết nối
//                InitializeDatabaseConnection(); // Giữ nguyên, mặc dù bạn đang tạo localConnection bên dưới
//                if (_connection == null || _connection.State != ConnectionState.Open)
//                {
//                    MessageBox.Show("Chưa kết nối với cơ sở dữ liệu. Vui lòng kết nối trước.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                // Tạo và mở kết nối cục bộ (giữ nguyên)
//                string serverAddress = txtServer;
//                string databaseName = txtDatabase;
//                string uid = txtUsername;
//                string password = txtPassword;

//                string connectionString;
//                if (string.IsNullOrWhiteSpace(uid))
//                {
//                    connectionString = $"Server={serverAddress};Database={databaseName};Integrated Security=True;TrustServerCertificate=True;";
//                }
//                else
//                {
//                    connectionString = $"Server={serverAddress};Database={databaseName};User ID={uid};Password={password};TrustServerCertificate=True;";
//                }

//                localConnection = new SqlConnection(connectionString);
//                localConnection.Open();

//                // Giữ nguyên việc lấy giá trị từ Date/Time Pickers
//                DateTime startDateFromPicker = dateTimeStart.Value;
//                DateTime endDateFromPicker = dateTimeEnd.Value;
//                DateTime startTimeFromPicker = timeTimeStart.Value;
//                DateTime endTimeFromPicker = timeTimeEnd.Value;

//                DateTime fullStartDateTime = new DateTime(
//                    startDateFromPicker.Year,
//                    startDateFromPicker.Month,
//                    startDateFromPicker.Day,
//                    startTimeFromPicker.Hour,
//                    startTimeFromPicker.Minute,
//                    startTimeFromPicker.Second);

//                DateTime fullEndDateTime = new DateTime(
//                    endDateFromPicker.Year,
//                    endDateFromPicker.Month,
//                    endDateFromPicker.Day,
//                    endTimeFromPicker.Hour,
//                    endTimeFromPicker.Minute,
//                    endTimeFromPicker.Second);

//                string selectedMaterialType = cmbType.SelectedItem?.ToString();

//                // *** PHẦN SỬA ĐỔI QUAN TRỌNG: Câu truy vấn SQL để tương thích mọi phiên bản ***
//                string query = @"
//SELECT
//    STTThe AS 'NO',
//    NgayRa AS 'DATE OUT',
//    -- Sử dụng các hàm chuỗi cơ bản để tạo định dạng thời gian HH:MM:SS.FF
//    RIGHT('0' + CAST(GioRa / 1000000 AS VARCHAR(2)), 2) + ':' +
//    RIGHT('0' + CAST((GioRa / 10000) % 100 AS VARCHAR(2)), 2) + ':' +
//    RIGHT('0' + CAST((GioRa / 100) % 100 AS VARCHAR(2)), 2) + '.' +
//    RIGHT('0' + CAST(GioRa % 100 AS VARCHAR(2)), 2) AS 'TIME OUT',
//    MaLoaiThe AS 'TYPE',
//    GiaTien AS 'PRICE',
//    CardID AS 'ID CARD',
//    IDXe AS 'ID VEHICLE',
//    IDMat AS 'ID NO',
//    soxe AS 'LPN IN',
//    soxera AS 'LPN OUT'
//FROM [dbo].[Ra]
//WHERE GiaTien > 0 AND "; // Giữ nguyên điều kiện GiaTien > 0

//                // Phần điều kiện WHERE cũng được sửa đổi để tương thích
//                query += @" (
//            CAST(NgayRa AS DATETIME) +
//            CAST( -- Cast chuỗi thời gian được tạo từ GioRa thành DATETIME
//                RIGHT('0' + CAST(GioRa / 1000000 AS VARCHAR(2)), 2) + ':' +
//                RIGHT('0' + CAST((GioRa / 10000) % 100 AS VARCHAR(2)), 2) + ':' +
//                RIGHT('0' + CAST((GioRa / 100) % 100 AS VARCHAR(2)), 2) + '.' +
//                RIGHT('0' + CAST(GioRa % 100 AS VARCHAR(2)), 2)
//            AS DATETIME)
//        ) BETWEEN @fullStartDateTime AND @fullEndDateTime";

//                // Giữ nguyên logic thêm điều kiện lọc theo loại vật liệu
//                if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
//                {
//                    query += " AND Ra.MaLoaiThe = @MaterialType";
//                }

//                // Dòng ORDER BY đã bị comment trong code gốc của bạn, tôi sẽ giữ nguyên trạng thái đó.
//                // Nếu bạn muốn sắp xếp, hãy bỏ comment dòng sau:
//                // query += " ORDER BY NgayRa ASC, GioRa ASC;";

//                using (SqlCommand command = new SqlCommand(query, localConnection))
//                {
//                    command.Parameters.AddWithValue("@fullStartDateTime", fullStartDateTime);
//                    command.Parameters.AddWithValue("@fullEndDateTime", fullEndDateTime);

//                    if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
//                    {
//                        command.Parameters.AddWithValue("@MaterialType", selectedMaterialType);
//                    }

//                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
//                    {
//                        adapter.Fill(dataTable); // Đổ dữ liệu vào DataTable
//                    }
//                }

//                // Kiểm tra xem có dữ liệu để xuất hay không (giữ nguyên)
//                if (dataTable.Rows.Count == 0)
//                {
//                    MessageBox.Show("Không có dữ liệu doanh thu để xuất trong khoảng thời gian đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    return;
//                }

//                // Tính tổng doanh thu (giữ nguyên logic tính toán)
//                decimal totalGiaTien = 0;
//                if (dataTable.Columns.Contains("PRICE"))
//                {
//                    foreach (DataRow row in dataTable.Rows)
//                    {
//                        if (row["PRICE"] != DBNull.Value && decimal.TryParse(row["PRICE"].ToString(), out decimal giaTien))
//                        {
//                            totalGiaTien += giaTien;
//                        }
//                    }
//                }
//                else
//                {
//                    MessageBox.Show("Cột 'PRICE' không tìm thấy trong kết quả truy vấn. Không thể tính tổng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                }
//                txtSum.Text = totalGiaTien.ToString("N0") + " VNĐ";

//                // *** PHẦN QUAN TRỌNG: Gọi hàm xuất Excel thay vì đổ vào DGV *** (giữ nguyên)
//                ExportDataTableToExcel(dataTable, "DOANH-THU-VANG-LAI"); // Gọi hàm xuất Excel với DataTable
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Lỗi khi truy vấn dữ liệu hoặc xuất báo cáo doanh thu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            finally
//            {
//                // Đảm bảo kết nối cục bộ được đóng (giữ nguyên)
//                if (localConnection != null && localConnection.State == ConnectionState.Open)
//                {
//                    localConnection.Close();
//                    localConnection.Dispose();
//                }

//                // Khôi phục trạng thái UI (giữ nguyên)
//                btnExportRevenue.Enabled = true; // Kích hoạt lại nút Export Revenue
//                this.Cursor = Cursors.Default;
//                progressBarExport.Visible = false;
//                progressBarExport.Value = 0;
//            }
//        }

        private void FormTTT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            string folderPath = txtFolder; // Lấy đường dẫn từ textbox

            if (string.IsNullOrWhiteSpace(folderPath))
            {
                MessageBox.Show("Vui lòng nhập đường dẫn thư mục cần mở.",
                                "Thiếu thông tin",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show($"Thư mục '{folderPath}' không tồn tại hoặc không thể truy cập được. Vui lòng kiểm tra lại đường dẫn.",
                                "Thư mục không tìm thấy",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Sử dụng ProcessStartInfo để mở thư mục
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = folderPath,
                    UseShellExecute = true // Quan trọng: mở như click đúp trong Windows Explorer
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể mở thư mục '{folderPath}'. Lỗi: {ex.Message}\n\nVui lòng kiểm tra lại quyền truy cập hoặc đường dẫn.",
                                "Lỗi mở thư mục",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnOpenRevenue_Click(object sender, EventArgs e)
        {
            string folderPath = Properties.Settings.Default.FolderRevenue; // Đảm bảo đúng tên biến trong Settings

            if (string.IsNullOrWhiteSpace(folderPath))
            {
                MessageBox.Show("Đường dẫn thư mục doanh thu hiện đang trống. Vui lòng xuất dữ liệu xuống file Excel trước để thiết lập đường dẫn.",
                                "Thư mục chưa được thiết lập",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show($"Thư mục '{folderPath}' không tồn tại hoặc không thể truy cập được. Vui lòng kiểm tra lại đường dẫn hoặc xuất dữ liệu xuống file Excel mới để tạo thư mục.",
                                "Thư mục không tìm thấy",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Sử dụng ProcessStartInfo để kiểm soát việc mở process tốt hơn
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = folderPath,
                    UseShellExecute = true // Quan trọng: Sử dụng shell để mở, tương tự như click đúp vào folder
                };

                Process.Start(psi); // Khởi chạy process

                // Ứng dụng của bạn sẽ vẫn chạy sau dòng này
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể mở thư mục '{folderPath}'. Lỗi: {ex.Message}\n\nVui lòng kiểm tra lại quyền truy cập hoặc đường dẫn.",
                                "Lỗi mở thư mục",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnOpenCus_Click(object sender, EventArgs e)
        {
            string folderPath = Properties.Settings.Default.FolderCus; // Đảm bảo đúng tên biến trong Settings

            if (string.IsNullOrWhiteSpace(folderPath))
            {
                MessageBox.Show("Đường dẫn thư mục danh sách thẻ tháng hiện đang trống. Vui lòng xuất dữ liệu xuống file Excel trước để thiết lập đường dẫn.",
                                "Thư mục chưa được thiết lập",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show($"Thư mục '{folderPath}' không tồn tại hoặc không thể truy cập được. Vui lòng kiểm tra lại đường dẫn hoặc xuất dữ liệu xuống file Excel mới để tạo thư mục.",
                                "Thư mục không tìm thấy",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Sử dụng ProcessStartInfo để kiểm soát việc mở process tốt hơn
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = folderPath,
                    UseShellExecute = true // Quan trọng: Sử dụng shell để mở, tương tự như click đúp vào folder
                };

                Process.Start(psi); // Khởi chạy process
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể mở thư mục '{folderPath}'. Lỗi: {ex.Message}\n\nVui lòng kiểm tra lại quyền truy cập hoặc đường dẫn.",
                                "Lỗi mở thư mục",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

//        private void btnRevenueCa_Click(object sender, EventArgs e)
//        {
//            InitializeDatabaseConnection();

//            if (_connection == null || _connection.State != ConnectionState.Open)
//            {
//                MessageBox.Show("Chưa kết nối với cơ sở dữ liệu. Vui lòng kết nối trước.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            DateTime startDateFromPicker = dateTimeStart.Value.Date;
//            DateTime endDateFromPicker = dateTimeEnd.Value.Date;
//            DateTime startTimeFromPicker = timeTimeStart.Value;
//            DateTime endTimeFromPicker = timeTimeEnd.Value;

//            TimeSpan caNgayStart = startTimeFromPicker.TimeOfDay;
//            TimeSpan caNgayEnd = endTimeFromPicker.TimeOfDay;

//            DateTime queryStartTime = startDateFromPicker;
//            DateTime queryEndTime = endDateFromPicker.AddDays(1).AddTicks(-1);

//            string selectedMaterialType = cmbType.SelectedItem?.ToString();

//            try
//            {
//                // Step 1: Get distinct Material Types
//                List<string> materialTypes = new List<string>();
//                string getTypesQuery = "SELECT DISTINCT MaLoaiThe FROM [dbo].[Ra] WHERE MaLoaiThe IS NOT NULL AND MaLoaiThe != ''";
//                using (SqlCommand typeCommand = new SqlCommand(getTypesQuery, _connection))
//                {
//                    using (SqlDataReader reader = typeCommand.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            materialTypes.Add(reader["MaLoaiThe"].ToString());
//                        }
//                    }
//                }

//                // Step 2: Build dynamic PIVOT columns
//                StringBuilder pivotColumns = new StringBuilder();
//                StringBuilder selectColumns = new StringBuilder();

//                selectColumns.AppendLine("CAST(NgayBaoCao AS DATE) AS 'Ngày',");
//                selectColumns.AppendLine("SUM(CASE WHEN LoaiCa = 'Ca Ngày' THEN GiaTien ELSE 0 END) AS 'Tổng tiền Ca ngày',");
//                selectColumns.AppendLine("SUM(CASE WHEN LoaiCa = 'Ca Đêm' THEN GiaTien ELSE 0 END) AS 'Tổng tiền Ca đêm'");

//                foreach (string type in materialTypes)
//                {
//                    // Escape type names that might contain spaces or special characters
//                    string safeTypeName = $"[{type.Replace("]", "]]")}]";

//                    pivotColumns.AppendLine($", ISNULL(SUM(CASE WHEN LoaiCa = 'Ca Ngày' AND MaLoaiThe = '{type}' THEN GiaTien ELSE 0 END), 0) AS 'Ca Ngày - {type}'");
//                    pivotColumns.AppendLine($", ISNULL(SUM(CASE WHEN LoaiCa = 'Ca Đêm' AND MaLoaiThe = '{type}' THEN GiaTien ELSE 0 END), 0) AS 'Ca Đêm - {type}'");
//                }

//                string query = $@"
//WITH TimeParsedData AS (
//    SELECT
//        NgayRa,
//        GiaTien,
//        MaLoaiThe,
//        CAST(
//            RIGHT('0' + CAST(GioRa / 1000000 AS VARCHAR(2)), 2) + ':' +
//            RIGHT('0' + CAST((GioRa / 10000) % 100 AS VARCHAR(2)), 2) + ':' +
//            RIGHT('0' + CAST((GioRa / 100) % 100 AS VARCHAR(2)), 2) + '.' +
//            RIGHT('0' + CAST(GioRa % 100 AS VARCHAR(2)), 2)
//        AS TIME) AS ThoiGianRa
//    FROM [dbo].[Ra]
//    WHERE GiaTien > 0
//    AND (CAST(NgayRa AS DATETIME) +
//         CAST(
//             RIGHT('0' + CAST(GioRa / 1000000 AS VARCHAR(2)), 2) + ':' +
//             RIGHT('0' + CAST((GioRa / 10000) % 100 AS VARCHAR(2)), 2) + ':' +
//             RIGHT('0' + CAST((GioRa / 100) % 100 AS VARCHAR(2)), 2) + '.' +
//             RIGHT('0' + CAST(GioRa % 100 AS VARCHAR(2)), 2)
//         AS DATETIME)) BETWEEN @QueryStartTime AND @QueryEndTime
//),
//CategorizedData AS (
//    SELECT
//        NgayRa,
//        GiaTien,
//        MaLoaiThe,
//        CASE
//            WHEN ThoiGianRa >= @CaNgayStart AND ThoiGianRa < @CaNgayEnd THEN 'Ca Ngày'
//            ELSE 'Ca Đêm'
//        END AS LoaiCa,
//        NgayRa AS NgayBaoCao
//    FROM TimeParsedData
//    WHERE (@MaterialTypeFilter IS NULL OR @MaterialTypeFilter = 'ALL' OR MaLoaiThe = @MaterialTypeFilter)
//)
//SELECT
//    CAST(NgayBaoCao AS DATE) AS 'Ngày',
//    SUM(CASE WHEN LoaiCa = 'Ca Ngày' THEN GiaTien ELSE 0 END) AS 'Tổng tiền Ca ngày',
//    SUM(CASE WHEN LoaiCa = 'Ca Đêm' THEN GiaTien ELSE 0 END) AS 'Tổng tiền Ca đêm'
//    {pivotColumns}
//FROM CategorizedData
//GROUP BY CAST(NgayBaoCao AS DATE)
//ORDER BY CAST(NgayBaoCao AS DATE) ASC;
//";
//                // Important: Replace {pivotColumns} in the query string
//                query = query.Replace("{pivotColumns}", pivotColumns.ToString());


//                using (SqlCommand command = new SqlCommand(query, _connection))
//                {
//                    command.Parameters.AddWithValue("@QueryStartTime", queryStartTime);
//                    command.Parameters.AddWithValue("@QueryEndTime", queryEndTime);
//                    command.Parameters.AddWithValue("@CaNgayStart", caNgayStart);
//                    command.Parameters.AddWithValue("@CaNgayEnd", caNgayEnd);

//                    // Use a different parameter name to avoid conflict with dynamically generated column names
//                    // This parameter is for the overall filter from cmbType
//                    if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
//                    {
//                        command.Parameters.AddWithValue("@MaterialTypeFilter", selectedMaterialType);
//                    }
//                    else
//                    {
//                        command.Parameters.AddWithValue("@MaterialTypeFilter", DBNull.Value); // Pass DBNull if 'ALL' or empty
//                    }


//                    DataTable dataTable = new DataTable();
//                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
//                    {
//                        adapter.Fill(dataTable);
//                    }

//                    dgvResults.DataSource = dataTable;
//                    dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

//                    int rowCount = dataTable.Rows.Count;
//                    txtCount.Text = rowCount.ToString("N0");

//                    btnUpdate.Enabled = dataTable.Rows.Count > 0;
//                    btnDelete.Enabled = dataTable.Rows.Count > 0;

//                    decimal totalGiaTien = 0;
//                    // Calculate total GiaTien from 'Tổng tiền Ca ngày' and 'Tổng tiền Ca đêm'
//                    if (dataTable.Columns.Contains("Tổng tiền Ca ngày") && dataTable.Columns.Contains("Tổng tiền Ca đêm"))
//                    {
//                        foreach (DataRow row in dataTable.Rows)
//                        {
//                            if (row["Tổng tiền Ca ngày"] != DBNull.Value && decimal.TryParse(row["Tổng tiền Ca ngày"].ToString(), out decimal ngayAmount))
//                            {
//                                totalGiaTien += ngayAmount;
//                            }
//                            if (row["Tổng tiền Ca đêm"] != DBNull.Value && decimal.TryParse(row["Tổng tiền Ca đêm"].ToString(), out decimal demAmount))
//                            {
//                                totalGiaTien += demAmount;
//                            }
//                        }
//                    }
//                    else
//                    {
//                        MessageBox.Show("Các cột 'Tổng tiền Ca ngày' hoặc 'Tổng tiền Ca đêm' không tìm thấy trong kết quả truy vấn. Không thể tính tổng chung.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    }

//                    txtSum.Text = totalGiaTien.ToString("N0") + " VNĐ";
//                    txtCount.Text = dataTable.Rows.Count.ToString("N0");
//                    btnExportRevenue.Enabled = true;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Lỗi truy vấn doanh thu: {ex.Message}\n\nVui lòng kiểm tra lại kết nối và dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

        //private void btnSaveTable_Click(object sender, EventArgs e)
        //{
        //    // Kiểm tra xem DataGridView có dữ liệu không
        //    if (dgvResults.DataSource == null || !(dgvResults.DataSource is DataTable) || ((DataTable)dgvResults.DataSource).Rows.Count == 0)
        //    {
        //        MessageBox.Show("Không có dữ liệu để xuất ra Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    DataTable dataToExport = (DataTable)dgvResults.DataSource;

        //    // Reset ProgressBar trước khi bắt đầu
        //    progressBarExport.Value = 0;
        //    progressBarExport.Minimum = 0;
        //    progressBarExport.Maximum = 100;

        //    string suggestedFileName = "BANG-DU-LIEU-";
        //    ExportDataTableToExcelTable(dataToExport, suggestedFileName);
        //}

        //private void ExportDataTableToExcelTable(DataTable dataTable, String suggestedFileName)
        //{
        //    Excel.Application excelApp = null;
        //    Excel.Workbook workbook = null;
        //    Excel.Worksheet worksheet = null;
        //    Excel.Range headerRange = null;
        //    Excel.Range dataRange = null;

        //    try
        //    {
        //        using (SaveFileDialog sfd = new SaveFileDialog())
        //        {
        //            sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";
        //            sfd.Title = "Lưu file Excel";
        //            sfd.FileName = suggestedFileName + ".xlsx"; // Gán tên file gợi ý và đuôi .xlsx

        //            if (sfd.ShowDialog() != DialogResult.OK)
        //            {
        //                // Người dùng hủy bỏ, không làm gì cả
        //                progressBarExport.Value = 0; // Đặt lại ProgressBar
        //                return;
        //            }

        //            string saveFilePath = sfd.FileName;

        //            excelApp = new Excel.Application();

        //            workbook = excelApp.Workbooks.Add();
        //            worksheet = (Excel.Worksheet)workbook.Sheets[1];

        //            int columnCount = dataTable.Columns.Count;
        //            int rowCount = dataTable.Rows.Count;

        //            // 1. Ghi tiêu đề cột (tối ưu bằng cách ghi cả mảng)
        //            object[] header = new object[columnCount];
        //            for (int col = 0; col < columnCount; col++)
        //            {
        //                header[col] = dataTable.Columns[col].ColumnName;
        //            }
        //            headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, columnCount]];
        //            headerRange.Value = header;
        //            headerRange.Font.Bold = true;
        //            headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
        //            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        //            Marshal.ReleaseComObject(headerRange);

        //            object[,] data = new object[rowCount, columnCount];
        //            progressBarExport.Visible = true;
        //            for (int row = 0; row < rowCount; row++)
        //            {
        //                for (int col = 0; col < columnCount; col++)
        //                {
        //                    data[row, col] = dataTable.Rows[row][col]?.ToString() ?? "";
        //                }
        //                if (progressBarExport != null) // Kiểm tra null để tránh lỗi nếu control không tồn tại
        //                {
        //                    if (row % 1000 == 0 || row == rowCount - 1)
        //                    {
        //                        int progress = (int)((double)(row + 1) / rowCount * 90);
        //                        if (progress > progressBarExport.Maximum) progress = progressBarExport.Maximum;
        //                        progressBarExport.Value = progress;
        //                        Application.DoEvents();
        //                    }
        //                }
        //            }
        //            dataRange = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[rowCount + 1, columnCount]];
        //            dataRange.Value = data;
        //            Marshal.ReleaseComObject(dataRange);
        //            worksheet.Columns.AutoFit();

        //            if (progressBarExport != null)
        //            {
        //                int progressFinal = 95;
        //                if (progressFinal > progressBarExport.Maximum) progressFinal = progressBarExport.Maximum;
        //                progressBarExport.Value = progressFinal;
        //                Application.DoEvents();
        //            }

        //            // Lưu workbook
        //            workbook.SaveAs(saveFilePath);
        //            MessageBox.Show("Xuất dữ liệu ra Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //            if (progressBarExport != null)
        //            {
        //                progressBarExport.Value = 100;
        //                Application.DoEvents();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi xuất dữ liệu ra Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        if (workbook != null) workbook.Saved = true;
        //    }
        //    finally
        //    {
        //        if (excelApp != null)
        //        {
        //            excelApp.ScreenUpdating = true;
        //            excelApp.DisplayAlerts = true;
        //            excelApp.Calculation = Excel.XlCalculation.xlCalculationAutomatic;
        //        }

        //        if (headerRange != null) Marshal.ReleaseComObject(headerRange);
        //        if (dataRange != null) Marshal.ReleaseComObject(dataRange);
        //        if (worksheet != null)
        //        {
        //            Marshal.ReleaseComObject(worksheet);
        //            worksheet = null;
        //        }
        //        if (workbook != null)
        //        {
        //            workbook.Close(false);
        //            Marshal.ReleaseComObject(workbook);
        //            workbook = null;
        //        }
        //        if (excelApp != null)
        //        {
        //            excelApp.Quit();
        //            Marshal.ReleaseComObject(excelApp);
        //            excelApp = null;
        //        }

        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //        GC.Collect();
        //    }
        //}

        //private void ExportDataTableToExcel(DataTable dataTable, String filename)
        //{
        //    Excel.Application excelApp = null;
        //    Excel.Workbook workbook = null;
        //    Excel.Worksheet worksheet = null;
        //    Excel.Range headerRange = null; // Khai báo để giải phóng
        //    Excel.Range dataRange = null;   // Khai báo để giải phóng

        //    try
        //    {
        //        // Tối ưu hóa Excel Application
        //        excelApp = new Excel.Application();
        //        //excelApp.Visible = false; // Ẩn Excel
        //        //excelApp.DisplayAlerts = false; // Tắt cảnh báo
        //        //excelApp.ScreenUpdating = false; // Tắt cập nhật màn hình
        //        //excelApp.Calculation = Excel.XlCalculation.xlCalculationManual; // Tắt tính toán tự động

        //        workbook = excelApp.Workbooks.Add();
        //        worksheet = (Excel.Worksheet)workbook.Sheets[1];

        //        int columnCount = dataTable.Columns.Count;
        //        int rowCount = dataTable.Rows.Count;

        //        // 1. Ghi tiêu đề cột (tối ưu bằng cách ghi cả mảng)
        //        object[] header = new object[columnCount];
        //        for (int col = 0; col < columnCount; col++)
        //        {
        //            header[col] = dataTable.Columns[col].ColumnName;
        //        }
        //        headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, columnCount]];
        //        headerRange.Value = header;
        //        headerRange.Font.Bold = true;
        //        headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
        //        headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        //        Marshal.ReleaseComObject(headerRange); // Giải phóng Range sau khi dùng

        //        // 2. Ghi dữ liệu vào Excel theo khối (batch write)
        //        object[,] data = new object[rowCount, columnCount];
        //        for (int row = 0; row < rowCount; row++)
        //        {
        //            for (int col = 0; col < columnCount; col++)
        //            {
        //                data[row, col] = dataTable.Rows[row][col]?.ToString() ?? "";
        //            }
        //            // Cập nhật ProgressBar cho UI Thread (mặc dù không dùng BackgroundWorker,
        //            // vẫn nên cập nhật định kỳ để UI không bị treo hoàn toàn nếu dữ liệu rất lớn)
        //            // Tuy nhiên, việc này vẫn có thể làm treo UI nếu số lượng hàng quá lớn.
        //            // Nếu UI vẫn bị treo, bạn CẦN sử dụng BackgroundWorker.
        //            if (row % 1000 == 0 || row == rowCount - 1) // Cập nhật mỗi 1000 hàng hoặc ở cuối
        //            {
        //                progressBarExport.Value = (int)((double)(row + 1) / rowCount * 90); // 90% cho việc ghi dữ liệu
        //                Application.DoEvents(); // Cho phép UI xử lý sự kiện để cập nhật ProgressBar
        //            }
        //        }
        //        dataRange = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[rowCount + 1, columnCount]];
        //        dataRange.Value = data;
        //        Marshal.ReleaseComObject(dataRange); // Giải phóng Range sau khi dùng

        //        // 3. Tự động điều chỉnh độ rộng cột và các tối ưu khác
        //        worksheet.Columns.AutoFit();

        //        progressBarExport.Value = 95; // 95% cho các thao tác tối ưu

        //        string serverAddress = txtServer;
        //        string sharedFolder = txtFolder;
        //        int index = serverAddress.IndexOf("\\SQLEXPRESS", StringComparison.OrdinalIgnoreCase);
        //        if (index != -1)
        //        {
        //            serverAddress = serverAddress.Remove(index, "\\SQLEXPRESS".Length).Trim();
        //        }
        //        string networkPath = $"\\\\{serverAddress}\\{sharedFolder}";

        //        using (SaveFileDialog sfd = new SaveFileDialog())
        //        {
        //            sfd.InitialDirectory = networkPath;

        //            sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";
        //            sfd.Title = "Lưu file Excel";
        //            if (filename == "DANH-SACH-THE-THANG")
        //            {
        //                sfd.FileName = "XUAT-DU-LIEU-" + filename + "-DEN-NGAY" + DateTime.Now.ToString("-dd-MM-yyyy") + ".xlsx";
        //            }
        //            else if (filename == "DOANH-THU-VANG-LAI")
        //            {
        //                sfd.FileName = "XUAT-DU-LIEU-" + filename + "-THANG" + DateTime.Now.ToString("-MM-yyyy") + ".xlsx";
        //            }
        //            if (sfd.ShowDialog() == DialogResult.OK)
        //            {
        //                workbook.SaveAs(sfd.FileName);
        //                MessageBox.Show("Xuất dữ liệu ra Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //                // Lấy đường dẫn thư mục chứa file
        //                string folderPath = Path.GetDirectoryName(sfd.FileName);
        //                if (filename == "DANH-SACH-THE-THANG")
        //                {
        //                    btnOpenCus.Enabled = true;
        //                    Properties.Settings.Default.FolderCus = folderPath;
        //                }
        //                else if (filename == "DOANH-THU-VANG-LAI")
        //                {
        //                    btnOpenRevenue.Enabled = true;
        //                    Properties.Settings.Default.FolderRevenue = folderPath;
        //                }
        //            }
        //        }
        //        progressBarExport.Value = 100; // Hoàn thành

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi xuất dữ liệu ra Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        // Nếu có lỗi, đảm bảo workbook không hỏi lưu khi đóng
        //        if (workbook != null) workbook.Saved = true;
        //    }
        //    finally
        //    {
        //        // Khôi phục trạng thái của Excel Application
        //        if (excelApp != null)
        //        {
        //            excelApp.ScreenUpdating = true;
        //            excelApp.DisplayAlerts = true;
        //            excelApp.Calculation = Excel.XlCalculation.xlCalculationAutomatic;
        //        }

        //        // Giải phóng tài nguyên COM Objects một cách an toàn
        //        // Đảm bảo giải phóng các đối tượng đã khai báo
        //        if (headerRange != null) Marshal.ReleaseComObject(headerRange);
        //        if (dataRange != null) Marshal.ReleaseComObject(dataRange);
        //        if (worksheet != null)
        //        {
        //            Marshal.ReleaseComObject(worksheet);
        //            worksheet = null;
        //        }
        //        if (workbook != null)
        //        {
        //            workbook.Close(false); // False để không hỏi lưu lại lần nữa
        //            Marshal.ReleaseComObject(workbook);
        //            workbook = null;
        //        }
        //        if (excelApp != null)
        //        {
        //            excelApp.Quit();
        //            Marshal.ReleaseComObject(excelApp);
        //            excelApp = null;
        //        }

        //        // Buộc Garbage Collection để giải phóng các đối tượng COM bị treo
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //        GC.Collect(); // Chạy lại lần nữa để chắc chắn
        //    }
        //}

        //private void btnCheck_Click(object sender, EventArgs e)
        //{
        //    FormKiemTra frmKiemTra = new FormKiemTra();
        //    frmKiemTra.Show();
        //}

        //private void btnDelete_Click(object sender, EventArgs e)
        //{


        //}

        //private void btnSQL_Click(object sender, EventArgs e)
        //{
        //    FormTruyVan formTruyVan = new FormTruyVan();
        //    formTruyVan.Show(); // Hoặc formTruyVan.ShowDialog();
        //}

        //private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //private void btnCaiDat_Click(object sender, EventArgs e)
        //{
        //    FormCaiDat formCaiDat = new FormCaiDat();
        //    formCaiDat.Show(); // Hoặc FormCaiDat.ShowDialog();
        //}

        //private void FormTTT_Load(object sender, EventArgs e)
        //{

        //}
    }
}



