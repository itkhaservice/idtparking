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

        private VlcControl _vlc1, _vlc2, _vlc3, _vlc4, _vlc5, _vlc6;

        public FormMain()
        {
            InitializeComponent();
            _settings = AppSettings.Load();
            this.Load += FormMain_Load;
            this.KeyDown += FormMain_KeyDown;
            this.KeyPreview = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ApplySettingsToUI();
        }

        private void ApplySettingsToUI()
        {
            UpdateStatusInfo();

            pnlTopCamera.Visible = true;
            bool is3Lanes = (_settings.LaneCount == 3);

            // --- ĐIỀU KHIỂN GATE VÀ LABEL TRẠNG THÁI ---
            // Làn 1 (Trái): Luôn hiện
            gateLeft.Visible = true;
            lblStatusLeft.Visible = true;

            // Làn Giữa (Middle): Chỉ hiện khi là 3 làn
            gateMiddle.Visible = is3Lanes;
            if (lblStatusMiddle != null) lblStatusMiddle.Visible = is3Lanes;

            // Làn Phải (Right): Luôn hiện (Sẽ là Làn 2 nếu máy chạy 2 làn, hoặc Làn 3 nếu chạy 3 làn)
            gateRight.Visible = true;
            lblStatusRight.Visible = true;

            // --- ĐIỀU KHIỂN CAMERA LIVE (THEO CẶP) ---
            // Cặp 1 (Làn Trái): Cam 1 & 2 luôn hiện
            pbCam1.Visible = true;
            pbCam2.Visible = true;

            // Cặp 2 (Vùng giữa): Cam 3 & 4 chỉ hiện khi là 3 làn
            pbCam3.Visible = is3Lanes;
            pbCam4.Visible = is3Lanes;

            // Cặp 3 (Vùng phải cùng): Cam 5 & 6 luôn hiện
            pbCam5.Visible = true;
            pbCam6.Visible = true;

            // --- ĐIỀU KHIỂN SNAPSHOTS (ẢNH CHỤP ĐỐI SOÁT) ---
            pbSnap1.Visible = true;
            pbSnap2.Visible = true;

            // Ẩn cặp snap giữa nếu chỉ có 2 làn xe để dồn ảnh làn 2 về phía trái cho dễ nhìn
            pbSnap3.Visible = is3Lanes;
            pbSnap4.Visible = is3Lanes;

            pbSnap5.Visible = true;
            pbSnap6.Visible = true;

            // --- KHỞI TẠO CAMERA ---
            if (_settings.ShowCamerasOnMain)
            {
                LoadCamerasFromSettings();
            }
            else
            {
                StopAllCameras();
            }
        }

        private void UpdateStatusInfo()
        {
            bool is3Lanes = (_settings.LaneCount == 3);

            // Cập nhật text tiêu đề cho các làn
            lblStatusLeft.Text = "LÀN 1: " + GetDirName(_settings.Lane1Direction);

            if (is3Lanes)
            {
                if (lblStatusMiddle != null) lblStatusMiddle.Text = "LÀN 2: " + GetDirName(_settings.Lane2Direction);
                lblStatusRight.Text = "LÀN 3: " + GetDirName(_settings.Lane3Direction);

                gateMiddle.SetGateStatus("SẴN SÀNG");
                gateRight.SetGateStatus("SẴN SÀNG");
            }
            else
            {
                lblStatusRight.Text = "LÀN 2: " + GetDirName(_settings.Lane2Direction);
                gateRight.SetGateStatus("SẴN SÀNG");
            }

            gateLeft.SetGateStatus("SẴN SÀNG");
        }

        private string GetDirName(int dir)
        {
            switch (dir)
            {
                case 0: return "VÀO";
                case 1: return "RA";
                case 2: return "ĐẢO CHIỀU";
                default: return "K.XÁC ĐỊNH";
            }
        }

        private void LoadCamerasFromSettings()
        {
            StopAllCameras();
            try
            {
                string vlcPath = GetVlcPath();
                if (string.IsNullOrEmpty(vlcPath)) return;

                bool is3Lanes = (_settings.LaneCount == 3);
                string url1, url2, url3 = "", url4 = "", url5, url6;

                // LOGIC GÁN URL: 
                // Nếu 2 làn: Cam 5,6 sẽ lấy cấu hình của Làn 2.
                // Nếu 3 làn: Cam 3,4 là Làn 2 | Cam 5,6 là Làn 3.

                if (_settings.CameraType == 0) // Analog
                {
                    string h = _settings.DvrHost; string u = _settings.DvrUser; string p = _settings.DvrPass;
                    url1 = $"rtsp://{u}:{p}@{h}:554/cam/realmonitor?channel={_settings.ChLane1Plate}&subtype=1";
                    url2 = $"rtsp://{u}:{p}@{h}:554/cam/realmonitor?channel={_settings.ChLane1Front}&subtype=1";

                    if (is3Lanes)
                    {
                        url3 = $"rtsp://{u}:{p}@{h}:554/cam/realmonitor?channel={_settings.ChLane2Plate}&subtype=1";
                        url4 = $"rtsp://{u}:{p}@{h}:554/cam/realmonitor?channel={_settings.ChLane2Front}&subtype=1";
                        url5 = $"rtsp://{u}:{p}@{h}:554/cam/realmonitor?channel={_settings.ChLane3Plate}&subtype=1";
                        url6 = $"rtsp://{u}:{p}@{h}:554/cam/realmonitor?channel={_settings.ChLane3Front}&subtype=1";
                    }
                    else
                    {
                        url5 = $"rtsp://{u}:{p}@{h}:554/cam/realmonitor?channel={_settings.ChLane2Plate}&subtype=1";
                        url6 = $"rtsp://{u}:{p}@{h}:554/cam/realmonitor?channel={_settings.ChLane2Front}&subtype=1";
                    }
                }
                else // IP Camera
                {
                    url1 = GetIpCamUrl(_settings.IpCamL1PlateHost, _settings.IpCamL1PlateUser, _settings.IpCamL1PlatePass, _settings.IpCamL1PlateRTSP);
                    url2 = GetIpCamUrl(_settings.IpCamL1FrontHost, _settings.IpCamL1FrontUser, _settings.IpCamL1FrontPass, _settings.IpCamL1FrontRTSP);

                    if (is3Lanes)
                    {
                        url3 = GetIpCamUrl(_settings.IpCamL2PlateHost, _settings.IpCamL2PlateUser, _settings.IpCamL2PlatePass, _settings.IpCamL2PlateRTSP);
                        url4 = GetIpCamUrl(_settings.IpCamL2FrontHost, _settings.IpCamL2FrontUser, _settings.IpCamL2FrontPass, _settings.IpCamL2FrontRTSP);
                        url5 = GetIpCamUrl(_settings.IpCamL3PlateHost, _settings.IpCamL3PlateUser, _settings.IpCamL3PlatePass, _settings.IpCamL3PlateRTSP);
                        url6 = GetIpCamUrl(_settings.IpCamL3FrontHost, _settings.IpCamL3FrontUser, _settings.IpCamL3FrontPass, _settings.IpCamL3FrontRTSP);
                    }
                    else
                    {
                        url5 = GetIpCamUrl(_settings.IpCamL2PlateHost, _settings.IpCamL2PlateUser, _settings.IpCamL2PlatePass, _settings.IpCamL2PlateRTSP);
                        url6 = GetIpCamUrl(_settings.IpCamL2FrontHost, _settings.IpCamL2FrontUser, _settings.IpCamL2FrontPass, _settings.IpCamL2FrontRTSP);
                    }
                }

                // Khởi tạo hiển thị
                _vlc1 = CreateVlc(vlcPath, url1, pbCam1);
                _vlc2 = CreateVlc(vlcPath, url2, pbCam2);
                if (is3Lanes)
                {
                    _vlc3 = CreateVlc(vlcPath, url3, pbCam3);
                    _vlc4 = CreateVlc(vlcPath, url4, pbCam4);
                }
                _vlc5 = CreateVlc(vlcPath, url5, pbCam5);
                _vlc6 = CreateVlc(vlcPath, url6, pbCam6);
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
            try
            {
                if (_vlc1 != null) { _vlc1.Stop(); _vlc1.Dispose(); _vlc1 = null; pbCam1.Controls.Clear(); }
                if (_vlc2 != null) { _vlc2.Stop(); _vlc2.Dispose(); _vlc2 = null; pbCam2.Controls.Clear(); }
                if (_vlc3 != null) { _vlc3.Stop(); _vlc3.Dispose(); _vlc3 = null; pbCam3.Controls.Clear(); }
                if (_vlc4 != null) { _vlc4.Stop(); _vlc4.Dispose(); _vlc4 = null; pbCam4.Controls.Clear(); }
                if (_vlc5 != null) { _vlc5.Stop(); _vlc5.Dispose(); _vlc5 = null; pbCam5.Controls.Clear(); }
                if (_vlc6 != null) { _vlc6.Stop(); _vlc6.Dispose(); _vlc6 = null; pbCam6.Controls.Clear(); }
            }
            catch { }
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
                case Keys.F3:
                    using (FrmSettings settings = new FrmSettings())
                    {
                        if (settings.ShowDialog() == DialogResult.OK)
                        {
                            _settings = AppSettings.Load();
                            ApplySettingsToUI();
                        }
                    }
                    break;
                case Keys.F11:
                    _settings = AppSettings.Load();
                    ApplySettingsToUI();
                    this.Refresh(); // Buộc vẽ lại toàn bộ Form
                    MessageBox.Show("Đã tải lại cấu hình hệ thống (F11)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Keys.Escape:
                    if (MessageBox.Show("Thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Application.Exit();
                    break;
            }
        }
    }
}