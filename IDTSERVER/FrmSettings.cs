using System;
using System.Drawing;
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

            // Tab 2 - Cấu hình Làn & COM
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

            // Tab 2 - IP Camera Config (4 Camera)
            // Làn 1 - Biển số
            txtIpL1P_Host.Text = _settings.IpCamL1PlateHost;
            txtIpL1P_User.Text = _settings.IpCamL1PlateUser;
            txtIpL1P_Pass.Text = _settings.IpCamL1PlatePass;
            txtIpL1P_Rtsp.Text = _settings.IpCamL1PlateRTSP;
            // Làn 1 - Toàn cảnh
            txtIpL1F_Host.Text = _settings.IpCamL1FrontHost;
            txtIpL1F_User.Text = _settings.IpCamL1FrontUser;
            txtIpL1F_Pass.Text = _settings.IpCamL1FrontPass;
            txtIpL1F_Rtsp.Text = _settings.IpCamL1FrontRTSP;
            // Làn 2 - Biển số
            txtIpL2P_Host.Text = _settings.IpCamL2PlateHost;
            txtIpL2P_User.Text = _settings.IpCamL2PlateUser;
            txtIpL2P_Pass.Text = _settings.IpCamL2PlatePass;
            txtIpL2P_Rtsp.Text = _settings.IpCamL2PlateRTSP;
            // Làn 2 - Toàn cảnh
            txtIpL2F_Host.Text = _settings.IpCamL2FrontHost;
            txtIpL2F_User.Text = _settings.IpCamL2FrontUser;
            txtIpL2F_Pass.Text = _settings.IpCamL2FrontPass;
            txtIpL2F_Rtsp.Text = _settings.IpCamL2FrontRTSP;

            UpdateCameraUI();

            // Tab 1 - Options
            chkFastScan.Checked = _settings.FastScan;
            chkSyncData.Checked = _settings.SyncData;
            chkAutoReconnect.Checked = _settings.AutoReconnect;
            chkAutoPrint.Checked = _settings.AutoPrint;
            chkOnlineImage.Checked = _settings.OnlineImage;
            chkShowRevenue.Checked = _settings.ShowRevenue;
            chkVoiceMoney.Checked = _settings.VoiceMoney;
            chkVoiceWarning.Checked = _settings.VoiceWarning;
        }

        private void SaveUIToSettings()
        {
            // Tab 1
            _settings.PrimaryServer = txtServerName.Text;
            _settings.BackupServer = txtServerLocal.Text;
            _settings.Port = txtPort.Text;
            _settings.Username = txtUsername.Text;
            _settings.Password = txtPassword.Text;
            _settings.DatabaseName = txtDBName.Text;
            _settings.LocalPath = txtLocalPath.Text;
            _settings.URLServer = txtURLServer.Text;
            _settings.BackupPath = txtBackupPath.Text;

            // Tab 2 - Làn & COM
            _settings.Lane1Direction = cboLane1Dir.SelectedIndex;
            _settings.Lane2Direction = cboLane2Dir.SelectedIndex;
            _settings.Lane1ComPort = txtLane1Com.Text;
            _settings.Lane2ComPort = txtLane2Com.Text;

            // Tab 2 - Camera Type
            _settings.CameraType = rdoAnalogCamera.Checked ? 0 : 1;
            
            // Analog
            _settings.DvrHost = txtDvrHost.Text;
            _settings.DvrPort = int.TryParse(txtDvrPort.Text, out int port) ? port : 8000;
            _settings.DvrUser = txtDvrUser.Text;
            _settings.DvrPass = txtDvrPass.Text;
            _settings.ChLane1Plate = (int)numChL1P.Value;
            _settings.ChLane1Front = (int)numChL1F.Value;
            _settings.ChLane2Plate = (int)numChL2P.Value;
            _settings.ChLane2Front = (int)numChL2F.Value;

            // IP Camera (4 Camera)
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

            // Tab 1 - Options
            _settings.FastScan = chkFastScan.Checked;
            _settings.SyncData = chkSyncData.Checked;
            _settings.AutoReconnect = chkAutoReconnect.Checked;
            _settings.AutoPrint = chkAutoPrint.Checked;
            _settings.OnlineImage = chkOnlineImage.Checked;
            _settings.ShowRevenue = chkShowRevenue.Checked;
            _settings.VoiceMoney = chkVoiceMoney.Checked;
            _settings.VoiceWarning = chkVoiceWarning.Checked;
        }

        private void btnSaveSystem_Click(object sender, EventArgs e)
        {
            SaveUIToSettings();
            _settings.Save();
            MessageBox.Show("Cấu hình hệ thống đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnTestServer_Click(object sender, EventArgs e)
        {
            lblServerStatus.Text = "Đang kiểm tra chính...";
            lblServerStatus.ForeColor = Color.Orange;
            
            bool primaryOk = await CheckConnectionAsync(txtServerName.Text, txtPort.Text);
            
            if (primaryOk)
            {
                lblServerStatus.Text = "Server Chính OK!";
                lblServerStatus.ForeColor = Color.Green;
            }
            else
            {
                lblServerStatus.Text = "Chính Lỗi. Kiểm tra dự phòng...";
                bool backupOk = await CheckConnectionAsync(txtServerLocal.Text, txtPort.Text);
                if (backupOk)
                {
                    lblServerStatus.Text = "Chính Lỗi - Dự phòng OK!";
                    lblServerStatus.ForeColor = Color.Blue;
                }
                else
                {
                    lblServerStatus.Text = "Cả hai đều không phản hồi!";
                    lblServerStatus.ForeColor = Color.Red;
                }
            }
        }

        private async Task<bool> CheckConnectionAsync(string ip, string port)
        {
            if (string.IsNullOrEmpty(ip)) return false;
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    var task = client.ConnectAsync(ip, int.Parse(port));
                    if (await Task.WhenAny(task, Task.Delay(3000)) == task)
                    {
                        return client.Connected;
                    }
                    return false;
                }
            }
            catch { return false; }
        }

        private void btnTestDB_Click(object sender, EventArgs e)
        {
            lblDBStatus.Text = "Đang kết nối...";
            lblDBStatus.ForeColor = Color.Orange;
            Application.DoEvents();

            string connString = $"Server={txtServerName.Text},{txtPort.Text};Database={txtDBName.Text};User ID={txtUsername.Text};Password={txtPassword.Text};Connect Timeout=10;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    lblDBStatus.Text = "DB Chính kết nối thành công!";
                    lblDBStatus.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblDBStatus.Text = "Lỗi DB: " + ex.Message;
                lblDBStatus.ForeColor = Color.Red;
            }
        }

        private void txtPassword_IconRightClick(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '●')
                txtPassword.PasswordChar = '\0';
            else
                txtPassword.PasswordChar = '●';
        }

        private void rdoCameraType_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCameraUI();
        }

        private void UpdateCameraUI()
        {
            pnlAnalogConfig.Visible = rdoAnalogCamera.Checked;
            pnlIPConfig.Visible = rdoIPCamera.Checked;
            
            if (rdoAnalogCamera.Checked)
                pnlAnalogConfig.BringToFront();
            else
                pnlIPConfig.BringToFront();
        }

        private void btnSaveDevice_Click(object sender, EventArgs e)
        {
            SaveUIToSettings();
            _settings.Save();
            MessageBox.Show("Cấu hình thiết bị đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaveCardType_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng lưu loại thẻ đang được cập nhật...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
