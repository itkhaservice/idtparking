using System;
using System.Drawing;
using System.Data;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace IDTSERVER
{
    public partial class FrmSettings : Form
    {
        private AppSettings _settings;

        public FrmSettings()
        {
            InitializeComponent();
            _settings = AppSettings.Load();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            LoadSettingsToUI();
        }

        private void LoadSettingsToUI()
        {
            // Tab 1 - Hệ thống
            txtServerName.Text = _settings.PrimaryServer;
            txtServerLocal.Text = _settings.BackupServer;
            txtPort.Text = _settings.Port;
            txtUsername.Text = _settings.Username;
            txtPassword.Text = _settings.Password;
            txtDBName.Text = _settings.DatabaseName;
            txtLocalPath.Text = _settings.LocalPath;
            txtURLServer.Text = _settings.URLServer;
            txtBackupPath.Text = _settings.BackupPath;

            cboLane1Dir.SelectedIndex = Math.Min(_settings.Lane1Direction, 2);
            cboLane2Dir.SelectedIndex = Math.Min(_settings.Lane2Direction, 2);
            txtLane1Com.Text = _settings.Lane1ComPort;
            txtLane2Com.Text = _settings.Lane2ComPort;

            // Tab 2 - Camera Type
            if (_settings.CameraType == 0)
                rdoAnalogCamera.Checked = true;
            else
                rdoIPCamera.Checked = true;

            // Tab 2 - Analog Config
            txtDvrHost.Text = _settings.DvrHost;
            txtDvrPort.Text = _settings.DvrPort.ToString();
            txtDvrUser.Text = _settings.DvrUser;
            txtDvrPass.Text = _settings.DvrPass;
            numChL1P.Value = _settings.ChLane1Plate;
            numChL1F.Value = _settings.ChLane1Front;
            numChL2P.Value = _settings.ChLane2Plate;
            numChL2F.Value = _settings.ChLane2Front;

            // Tab 2 - IP Camera Config (6 Camera)
            txtIpL1P_Host.Text = _settings.IpCamL1PlateHost;
            txtIpL1P_User.Text = _settings.IpCamL1PlateUser;
            txtIpL1P_Pass.Text = _settings.IpCamL1PlatePass;
            txtIpL1P_Rtsp.Text = _settings.IpCamL1PlateRTSP;
            txtIpL1F_Host.Text = _settings.IpCamL1FrontHost;
            txtIpL1F_User.Text = _settings.IpCamL1FrontUser;
            txtIpL1F_Pass.Text = _settings.IpCamL1FrontPass;
            txtIpL1F_Rtsp.Text = _settings.IpCamL1FrontRTSP;
            txtIpL2P_Host.Text = _settings.IpCamL2PlateHost;
            txtIpL2P_User.Text = _settings.IpCamL2PlateUser;
            txtIpL2P_Pass.Text = _settings.IpCamL2PlatePass;
            txtIpL2P_Rtsp.Text = _settings.IpCamL2PlateRTSP;
            txtIpL2F_Host.Text = _settings.IpCamL2FrontHost;
            txtIpL2F_User.Text = _settings.IpCamL2FrontUser;
            txtIpL2F_Pass.Text = _settings.IpCamL2FrontPass;
            txtIpL2F_Rtsp.Text = _settings.IpCamL2FrontRTSP;

            UpdateCameraUI();

            // Options & Công tắc Camera
            chkFastScan.Checked = _settings.FastScan;
            chkSyncData.Checked = _settings.SyncData;
            chkAutoReconnect.Checked = _settings.AutoReconnect;
            chkAutoPrint.Checked = _settings.AutoPrint;
            chkOnlineImage.Checked = _settings.OnlineImage;
            chkShowCamerasOnMain.Checked = _settings.ShowCamerasOnMain; // ĐÃ THÊM
            chkShowRevenue.Checked = _settings.ShowRevenue;
            chkVoiceMoney.Checked = _settings.VoiceMoney;
            chkVoiceWarning.Checked = _settings.VoiceWarning;
        }

        private void SaveUIToSettings()
        {
            // Tab 1 & 2
            _settings.PrimaryServer = txtServerName.Text;
            _settings.BackupServer = txtServerLocal.Text;
            _settings.Port = txtPort.Text;
            _settings.Username = txtUsername.Text;
            _settings.Password = txtPassword.Text;
            _settings.DatabaseName = txtDBName.Text;
            _settings.LocalPath = txtLocalPath.Text;
            _settings.URLServer = txtURLServer.Text;
            _settings.BackupPath = txtBackupPath.Text;

            _settings.Lane1Direction = cboLane1Dir.SelectedIndex;
            _settings.Lane2Direction = cboLane2Dir.SelectedIndex;
            _settings.Lane1ComPort = txtLane1Com.Text;
            _settings.Lane2ComPort = txtLane2Com.Text;


            _settings.CameraType = rdoAnalogCamera.Checked ? 0 : 1;
            _settings.DvrHost = txtDvrHost.Text;
            _settings.DvrPort = int.TryParse(txtDvrPort.Text, out int port) ? port : 8888;
            _settings.DvrUser = txtDvrUser.Text;
            _settings.DvrPass = txtDvrPass.Text;
            _settings.ChLane1Plate = (int)numChL1P.Value;
            _settings.ChLane1Front = (int)numChL1F.Value;
            _settings.ChLane2Plate = (int)numChL2P.Value;
            _settings.ChLane2Front = (int)numChL2F.Value;


            _settings.IpCamL1PlateHost = txtIpL1P_Host.Text;
            _settings.IpCamL1PlateUser = txtIpL1P_User.Text;
            _settings.IpCamL1PlatePass = txtIpL1P_Pass.Text;
            _settings.IpCamL1PlateRTSP = txtIpL1P_Rtsp.Text;
            _settings.IpCamL1FrontHost = txtIpL1F_Host.Text;
            _settings.IpCamL1FrontUser = txtIpL1F_User.Text;
            _settings.IpCamL1FrontPass = txtIpL1F_Pass.Text;
            _settings.IpCamL1FrontRTSP = txtIpL1F_Rtsp.Text;
            _settings.IpCamL2PlateHost = txtIpL2P_Host.Text;
            _settings.IpCamL2PlateUser = txtIpL2P_User.Text;
            _settings.IpCamL2PlatePass = txtIpL2P_Pass.Text;
            _settings.IpCamL2PlateRTSP = txtIpL2P_Rtsp.Text;
            _settings.IpCamL2FrontHost = txtIpL2F_Host.Text;
            _settings.IpCamL2FrontUser = txtIpL2F_User.Text;
            _settings.IpCamL2FrontPass = txtIpL2F_Pass.Text;
            _settings.IpCamL2FrontRTSP = txtIpL2F_Rtsp.Text;

            // Options & Công tắc Camera
            _settings.FastScan = chkFastScan.Checked;
            _settings.SyncData = chkSyncData.Checked;
            _settings.AutoReconnect = chkAutoReconnect.Checked;
            _settings.AutoPrint = chkAutoPrint.Checked;
            _settings.OnlineImage = chkOnlineImage.Checked;
            _settings.ShowCamerasOnMain = chkShowCamerasOnMain.Checked; // ĐÃ THÊM
            _settings.ShowRevenue = chkShowRevenue.Checked;
            _settings.VoiceMoney = chkVoiceMoney.Checked;
            _settings.VoiceWarning = chkVoiceWarning.Checked;
        }

        private void btnSaveSystem_Click(object sender, EventArgs e)
        {
            SaveUIToSettings();
            _settings.Save();
            this.DialogResult = DialogResult.OK; // Để FormMain tự động load lại giao diện
            MessageBox.Show("Cấu hình hệ thống đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExitSystem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnTestServer_Click(object sender, EventArgs e)
        {
            lblServerStatus.Text = "Đang kiểm tra chính...";
            lblServerStatus.ForeColor = Color.Orange;
            bool primaryOk = await CheckConnectionAsync(txtServerName.Text, txtPort.Text);
            if (primaryOk) { lblServerStatus.Text = "Server Chính OK!"; lblServerStatus.ForeColor = Color.Green; }
            else {
                lblServerStatus.Text = "Chính Lỗi. Kiểm tra dự phòng...";
                bool backupOk = await CheckConnectionAsync(txtServerLocal.Text, txtPort.Text);
                if (backupOk) { lblServerStatus.Text = "Chính Lỗi - Dự phòng OK!"; lblServerStatus.ForeColor = Color.Blue; }
                else { lblServerStatus.Text = "Cả hai đều không phản hồi!"; lblServerStatus.ForeColor = Color.Red; }
            }
        }

        private async Task<bool> CheckConnectionAsync(string ip, string port)
        {
            if (string.IsNullOrEmpty(ip)) return false;
            try {
                using (TcpClient client = new TcpClient()) {
                    var task = client.ConnectAsync(ip, int.Parse(port));
                    if (await Task.WhenAny(task, Task.Delay(3000)) == task) return client.Connected;
                    return false;
                }
            } catch { return false; }
        }

        private void btnTestDB_Click(object sender, EventArgs e)
        {
            lblDBStatus.Text = "Đang kết nối...";
            lblDBStatus.ForeColor = Color.Orange;
            Application.DoEvents();
            string connString = $"Server={txtServerName.Text},{txtPort.Text};Database={txtDBName.Text};User ID={txtUsername.Text};Password={txtPassword.Text};Connect Timeout=10;TrustServerCertificate=True;";
            try {
                using (SqlConnection conn = new SqlConnection(connString)) {
                    conn.Open();
                    lblDBStatus.Text = "DB Chính kết nối thành công!";
                    lblDBStatus.ForeColor = Color.Green;
                }
            } catch (Exception ex) { lblDBStatus.Text = "Lỗi DB: " + ex.Message; lblDBStatus.ForeColor = Color.Red; }
        }

        private void txtPassword_IconRightClick(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '●') txtPassword.PasswordChar = '\0';
            else txtPassword.PasswordChar = '●';
        }

        private void rdoCameraType_CheckedChanged(object sender, EventArgs e) { UpdateCameraUI(); }

        private void UpdateCameraUI()
        {
            pnlAnalogConfig.Visible = rdoAnalogCamera.Checked;
            pnlIPConfig.Visible = rdoIPCamera.Checked;
            if (rdoAnalogCamera.Checked) pnlAnalogConfig.BringToFront();
            else pnlIPConfig.BringToFront();
        }

        private void btnSaveDevice_Click(object sender, EventArgs e)
        {
            SaveUIToSettings();
            _settings.Save();
            this.DialogResult = DialogResult.OK; // QUAN TRỌNG: Để FormMain biết mà reload
            MessageBox.Show("Cấu hình thiết bị đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPreviewCamera_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = (Guna.UI2.WinForms.Guna2Button)sender;
            string cameraName = "";
            string rtspUrl = "";

            if (btn == btnPreviewAnL1P) {
                cameraName = "TEST MẶC ĐỊNH (Kênh 3)";
                rtspUrl = "rtsp://admin:idt123321@192.168.100.99:554/cam/realmonitor?channel=3&subtype=1";
            }
            else if (rdoAnalogCamera.Checked) {
                string host = txtDvrHost.Text; string user = txtDvrUser.Text; string pass = txtDvrPass.Text;
                int channel = 1;
                if (btn == btnPreviewAnL1P) { cameraName = "Làn 1 - Biển số (Sau)"; channel = (int)numChL1P.Value; }
                else if (btn == btnPreviewAnL1F) { cameraName = "Làn 1 - Toàn cảnh (Trước)"; channel = (int)numChL1F.Value; }
                else if (btn == btnPreviewAnL2P) { cameraName = "Làn 2 - Biển số (Sau)"; channel = (int)numChL2P.Value; }
                else if (btn == btnPreviewAnL2F) { cameraName = "Làn 2 - Toàn cảnh (Trước)"; channel = (int)numChL2F.Value; }

                
                if (channel < 1) channel = 1;
                rtspUrl = $"rtsp://{user}:{pass}@{host}:554/cam/realmonitor?channel={channel}&subtype=1";
            }
            else {
                string host = "", user = "", pass = "", path = "";
                if (btn == btnPreviewIpL1P) { cameraName = "IP Làn 1 - Biển số"; host = txtIpL1P_Host.Text; user = txtIpL1P_User.Text; pass = txtIpL1P_Pass.Text; path = txtIpL1P_Rtsp.Text; }
                else if (btn == btnPreviewIpL1F) { cameraName = "IP Làn 1 - Toàn cảnh"; host = txtIpL1F_Host.Text; user = txtIpL1F_User.Text; pass = txtIpL1F_Pass.Text; path = txtIpL1F_Rtsp.Text; }
                else if (btn == btnPreviewIpL2P) { cameraName = "IP Làn 2 - Biển số"; host = txtIpL2P_Host.Text; user = txtIpL2P_User.Text; pass = txtIpL2P_Pass.Text; path = txtIpL2P_Rtsp.Text; }
                else if (btn == btnPreviewIpL2F) { cameraName = "IP Làn 2 - Toàn cảnh"; host = txtIpL2F_Host.Text; user = txtIpL2F_User.Text; pass = txtIpL2F_Pass.Text; path = txtIpL2F_Rtsp.Text; }
                if (path.StartsWith("rtsp://")) rtspUrl = path;
                else {
                    string separator = path.Contains("?") ? "&" : "?";
                    if (!path.Contains("subtype=")) rtspUrl = $"rtsp://{user}:{pass}@{host}:554{path}{separator}subtype=1";
                    else rtspUrl = $"rtsp://{user}:{pass}@{host}:554{path}";
                }
            }
            using (FormCameraPreview preview = new FormCameraPreview(cameraName, rtspUrl)) { preview.ShowDialog(); }
        }

        private void btnSaveCardType_Click(object sender, EventArgs e) { LoadLoaiThe(); MessageBox.Show("Đã làm mới danh sách loại thẻ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        private void LoadLoaiThe()
        {
            string connString = _settings.GetConnectionString();
            try {
                using (SqlConnection conn = new SqlConnection(connString)) {
                    string query = "SELECT MaLoaiThe AS N'Mã loại thẻ', LoaiThe AS N'Tên loại thẻ' FROM LoaiThe";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvCardType.DataSource = dt;
                    if (dgvCardType.Columns.Count > 0) { dgvCardType.Columns[0].Width = 150; dgvCardType.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; }
                }
            } catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách thẻ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnAdd_Click(object sender, EventArgs e) { MessageBox.Show("Vui lòng nhập thông tin vào dòng trống cuối cùng của danh sách và nhấn SỬA để cập nhật.", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCardType.DataSource == null) return;
            string connString = _settings.GetConnectionString();
            try {
                using (SqlConnection conn = new SqlConnection(connString)) {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT MaLoaiThe, LoaiThe FROM LoaiThe", conn);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    DataTable dt = (DataTable)dgvCardType.DataSource;
                    dt.Columns[0].ColumnName = "MaLoaiThe"; dt.Columns[1].ColumnName = "LoaiThe";
                    adapter.Update(dt);
                    dt.Columns[0].ColumnName = "Mã loại thẻ"; dt.Columns[1].ColumnName = "Tên loại thẻ";
                    MessageBox.Show("Đã cập nhật thay đổi vào cơ sở dữ liệu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex) { MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCardType.SelectedRows.Count > 0) {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa loại thẻ đang chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    dgvCardType.Rows.RemoveAt(dgvCardType.SelectedRows[0].Index); btnEdit_Click(null, null); 
                }
            } else { MessageBox.Show("Vui lòng chọn cả dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnExitSystem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExitDevice_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
