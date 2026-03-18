using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Vlc.DotNet.Forms;

namespace IDTSERVER
{
    public partial class FormMain : Form
    {
        private bool _isSystemActive = false;
        private string _currentUser = "Chưa đăng nhập";
        private string _currentShift = "Chưa xác định";
        private AppSettings _settings;

        private VlcControl _vlc1, _vlc2, _vlc3, _vlc4;

        public FormMain()
        {
            InitializeComponent();
            _settings = AppSettings.Load();
            this.Load += FormMain_Load;
            this.KeyPreview = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            UpdateStatusInfo();
            if (_settings.ShowCamerasOnMain)
            {
                LoadCamerasFromSettings();
            }
        }

        private void UpdateStatusInfo()
        {
            lblStatusLeft.Text = "LÀN 1: " + GetDirName(_settings.Lane1Direction);
            lblStatusRight.Text = "LÀN 2: " + GetDirName(_settings.Lane2Direction);
            
            gateLeft.SetGateStatus("SẴN SÀNG");
            gateRight.SetGateStatus("SẴN SÀNG");
            
            // DỮ LIỆU MẪU LÀN 1
            gateLeft.SetCardInfo(
                "0012345678", 
                "Ô TÔ 4 CHỖ", 
                "NGUYỄN VĂN A", 
                "51A-123.45", 
                "02 Giờ 15 Phút", 
                "18/03/2026 08:30:00", 
                "18/03/2026 10:45:00", 
                "25.000 VNĐ"
            );
            gateLeft.SetAIPlates("51A12345", "51A12345");

            // DỮ LIỆU MẪU LÀN 2
            gateRight.SetCardInfo(
                "0098765432", 
                "XE MÁY", 
                "TRẦN THỊ B", 
                "60B-111.22", 
                "05 Giờ 30 Phút", 
                "18/03/2026 07:00:00", 
                "18/03/2026 12:30:00", 
                "5.000 VNĐ"
            );
            gateRight.SetAIPlates("60B11122", "60B11122");
        }

        private string GetDirName(int dir)
        {
            switch (dir) {
                case 0: return "VÀO";
                case 1: return "RA";
                case 2: return "ĐẢO CHIỀU";
                default: return "KHÔNG XÁC ĐỊNH";
            }
        }

        private void LoadCamerasFromSettings()
        {
            StopAllCameras();
            try
            {
                string vlcPath = GetVlcPath();
                if (string.IsNullOrEmpty(vlcPath)) return;

                string url1, url2, url3, url4;
                if (_settings.CameraType == 0) // Analog
                {
                    string h = _settings.DvrHost; string u = _settings.DvrUser; string p = _settings.DvrPass;
                    url1 = $"rtsp://{u}:{p}@{h}:554/cam/realmonitor?channel={_settings.ChLane1Plate}&subtype=1";
                    url2 = $"rtsp://{u}:{p}@{h}:554/cam/realmonitor?channel={_settings.ChLane1Front}&subtype=1";
                    url3 = $"rtsp://{u}:{p}@{h}:554/cam/realmonitor?channel={_settings.ChLane2Plate}&subtype=1";
                    url4 = $"rtsp://{u}:{p}@{h}:554/cam/realmonitor?channel={_settings.ChLane2Front}&subtype=1";
                }
                else // IP
                {
                    url1 = GetIpCamUrl(_settings.IpCamL1PlateHost, _settings.IpCamL1PlateUser, _settings.IpCamL1PlatePass, _settings.IpCamL1PlateRTSP);
                    url2 = GetIpCamUrl(_settings.IpCamL1FrontHost, _settings.IpCamL1FrontUser, _settings.IpCamL1FrontPass, _settings.IpCamL1FrontRTSP);
                    url3 = GetIpCamUrl(_settings.IpCamL2PlateHost, _settings.IpCamL2PlateUser, _settings.IpCamL2PlatePass, _settings.IpCamL2PlateRTSP);
                    url4 = GetIpCamUrl(_settings.IpCamL2FrontHost, _settings.IpCamL2FrontUser, _settings.IpCamL2FrontPass, _settings.IpCamL2FrontRTSP);
                }

                _vlc1 = CreateVlc(vlcPath, url1, pbCam1);
                _vlc2 = CreateVlc(vlcPath, url2, pbCam2);
                _vlc3 = CreateVlc(vlcPath, url3, pbCam3);
                _vlc4 = CreateVlc(vlcPath, url4, pbCam4);
            }
            catch { }
        }

        private VlcControl CreateVlc(string vlcPath, string url, PictureBox host)
        {
            if (string.IsNullOrEmpty(url)) return null;
            var vlc = new VlcControl();
            vlc.BeginInit();
            vlc.VlcLibDirectory = new DirectoryInfo(vlcPath);
            vlc.VlcMediaplayerOptions = new string[] { ":rtsp-tcp", ":network-caching=300", ":no-stats", ":no-video-title-show" };
            vlc.EndInit();
            vlc.Dock = DockStyle.Fill;
            host.Controls.Clear();
            host.Controls.Add(vlc);
            vlc.Play(new Uri(url));
            return vlc;
        }

        private void StopAllCameras()
        {
            try {
                if (_vlc1 != null) { _vlc1.Stop(); _vlc1.Dispose(); _vlc1 = null; pbCam1.Controls.Clear(); }
                if (_vlc2 != null) { _vlc2.Stop(); _vlc2.Dispose(); _vlc2 = null; pbCam2.Controls.Clear(); }
                if (_vlc3 != null) { _vlc3.Stop(); _vlc3.Dispose(); _vlc3 = null; pbCam3.Controls.Clear(); }
                if (_vlc4 != null) { _vlc4.Stop(); _vlc4.Dispose(); _vlc4 = null; pbCam4.Controls.Clear(); }
            } catch { }
        }

        private string GetVlcPath()
        {
            string programFiles = Environment.Is64BitProcess ? "ProgramFiles" : "ProgramFiles(x86)";
            string path = Path.Combine(Environment.GetEnvironmentVariable(programFiles), "VideoLAN", "VLC");
            return Directory.Exists(path) ? path : "";
        }

        private string GetIpCamUrl(string host, string user, string pass, string path)
        {
            if (string.IsNullOrEmpty(host)) return "";
            if (path.StartsWith("rtsp://")) return path;
            string sep = path.Contains("?") ? "&" : "?";
            return $"rtsp://{user}:{pass}@{host}:554{path}{sep}subtype=1";
        }

        public void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    using (LoginForm login = new LoginForm()) {
                        if (login.ShowDialog() == DialogResult.OK) {
                            _isSystemActive = true; _currentUser = login.CurrentUser; _currentShift = login.CurrentShift;
                            this.Text = $"IDT PARKING - ĐANG HOẠT ĐỘNG | NV: {_currentUser} | {_currentShift}";
                        }
                    }
                    break;
                case Keys.F3:
                    using (FrmSettings settings = new FrmSettings()) {
                        if (settings.ShowDialog() == DialogResult.OK) {
                            _settings = AppSettings.Load();
                            UpdateStatusInfo();
                            if (_settings.ShowCamerasOnMain) LoadCamerasFromSettings();
                            else StopAllCameras();
                        }
                    }
                    break;
                case Keys.F11:
                    _settings = AppSettings.Load();
                    if (_settings.ShowCamerasOnMain) {
                        LoadCamerasFromSettings();
                        MessageBox.Show("Đã tải lại luồng Camera!", "Thông báo");
                    } else {
                        UpdateStatusInfo();
                        MessageBox.Show("Đã làm mới dữ liệu mẫu!", "Thông báo");
                    }
                    break;
                case Keys.Escape:
                    if (MessageBox.Show("Thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Application.Exit();
                    break;
            }
        }
    }
}
