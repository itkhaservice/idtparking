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
    public partial class FormMain : Form
    {
        // KHAI BÁO CÁC BIẾN LƯU TỪ FORM CÀI ĐẶT
        public string txtServer = Properties.Settings.Default.ServerAddress;
        public string txtDatabase = Properties.Settings.Default.DatabaseName;
        public string txtFolder = Properties.Settings.Default.SharedFolder;
        public string txtUsername = Properties.Settings.Default.Username;
        public string txtPassword = Properties.Settings.Default.Password;

        // KHAI BÁO HẰNG SỐ CỦA TAB DOANH THU
        private const string CORRECT_PASSWORD = "9999";
        public const string ALL_MATERIAL_TYPE = "ALL";
        public const string PRICE_COLUMN_NAME = "PRICE";
        private SqlConnection connection;
        //private SqlConnection _connection;
        //private DataTable _currentQueryResult;

        public FormMain()
        {
            InitializeComponent();
            InitializeDatabaseConnection(); // Call here once
            DoanhThu_Load();
        }

        // TAB DOANH THU
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
            timeTimeStart.Value = new DateTime(firstDayOfMonth.Year, firstDayOfMonth.Month, firstDayOfMonth.Day, 0, 0, 0);
            timeTimeEnd.Value = new DateTime(firstDayOfMonth.Year, firstDayOfMonth.Month, firstDayOfMonth.Day, 0, 0, 0);

            // Set custom format for time pickers
            timeTimeStart.Format = DateTimePickerFormat.Custom;
            timeTimeEnd.Format = DateTimePickerFormat.Custom;
            timeTimeStart.CustomFormat = "HH:mm:ss";
            timeTimeEnd.CustomFormat = "HH:mm:ss";
            timeTimeStart.ShowUpDown = true;
            timeTimeEnd.ShowUpDown = true;

            // Set custom format for date pickers to dd/MM/yyyy
            dateTimeStart.Format = DateTimePickerFormat.Custom;
            dateTimeStart.CustomFormat = "dd/MM/yyyy";
            dateTimeEnd.Format = DateTimePickerFormat.Custom;
            dateTimeEnd.CustomFormat = "dd/MM/yyyy";

            cmbType.Items.Add("VL");
            cmbType.Items.Add("VL-XD");
            cmbType.Items.Add("VL-XM");
            cmbType.Items.Add("VL-XH");
            cmbType.Items.Add("VT-XH");
            cmbType.Items.Add("VT-XM");
            cmbType.Items.Add("VT");
            cmbType.Items.Add("VT-XD");
            cmbType.Items.Add("All");

            if (cmbType.Items.Count > 0)
            {
                cmbType.SelectedIndex = 0;
            }
        }

        private void SetInitialControlStates()
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            if (!cmbType.Items.Contains(ALL_MATERIAL_TYPE))
            {
                cmbType.Items.Insert(0, ALL_MATERIAL_TYPE);
            }
            cmbType.SelectedIndex = 0;
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

                connection = new SqlConnection(connectionString);
                connection.Open();
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

            string selectedMaterialType = cmbType.SelectedItem?.ToString();

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

                        if (dataTable.Columns.Contains("PRICE"))
                        {
                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (row["PRICE"] != DBNull.Value && decimal.TryParse(row["PRICE"].ToString(), out decimal giaTien))
                                {
                                    totalGiaTien += giaTien;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Column 'PRICE' not found in query results. Cannot calculate sum.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            string selectedMaterialType = cmbType.SelectedItem?.ToString();

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
                                RIGHT('0' + CAST(GioRa / 1000000 AS VARCHAR(2)), 2) + ':' +
                                RIGHT('0' + CAST((GioRa / 10000) % 100 AS VARCHAR(2)), 2) + ':' +
                                RIGHT('0' + CAST((GioRa / 100) % 100 AS VARCHAR(2)), 2) + '.' +
                                RIGHT('0' + CAST(GioRa % 100 AS VARCHAR(2)), 2)
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

                        if (dataTable.Columns.Contains("PRICE"))
                        {
                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (row["PRICE"] != DBNull.Value && decimal.TryParse(row["PRICE"].ToString(), out decimal giaTien))
                                {
                                    totalGiaTien += giaTien;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Column 'PRICE' not found in query results. Cannot calculate sum.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        logCmd.AddWithValue("@idMat", idMat);
                        logCmd.ExecuteNonQuery();
                    }

                    // 2) Chuẩn bị update (lấy các cột cần update từ dgv)
                    Dictionary<string, string> columnMapping = new Dictionary<string, string>
                        {
                            { "Số thẻ", "STTThe" },
                            { "Loại thẻ", "MaLoaiThe" },
                            { "Tiền thu", "GiaTien" },
                            { "USERNAME", "username" }, // Assuming 'username' is still 'USERNAME'
                            { "Xe vào", "soxe" },
                            { "Xe ra", "soxera" },
                            { "CONG", "cong" } // Assuming 'cong' is still 'CONG'
                        };

                    List<string> updateFields = new List<string>();
                    using (SqlCommand updateCmd = new SqlCommand())
                    {
                        updateCmd.Connection = connection;
                        updateCmd.Transaction = trans;

                        foreach (DataGridViewColumn column in dgvResults.Columns)
                        {
                            string columnName = column.Name;

                            if (columnName == "ID CARD" || columnName == "ID VEHICLE" || columnName == "ID NO")
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

        private void btnExportRevenue_Click(object sender, EventArgs e)
        {

        }
    }
}
