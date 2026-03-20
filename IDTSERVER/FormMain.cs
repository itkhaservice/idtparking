using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using Vlc.DotNet.Forms;

namespace IDTSERVER
{
    public partial class FormMain : Form
    {
        private AppSettings _settings;
        private Timer _clockTimer;
        
        // Luồng Video Live
        private VlcControl _vlcL1Pano, _vlcL1Plate, _vlcL2Pano, _vlcL2Plate;

        public FormMain()
        {
            InitializeComponent();
            _settings = AppSettings.Load();
            SetupUIProportions();
            
            _clockTimer = new Timer { Interval = 1000 };
            _clockTimer.Tick += (s, e) => {
                if (lblCurrentTime != null) lblCurrentTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            };
            _clockTimer.Start();

            this.Load += FormMain_Load;
            this.KeyDown += FormMain_KeyDown;
        }

        private void SetupUIProportions()
        {
            // YÊU CẦU 1: Thuộc tính SizeMode đặt là Zoom
            PictureBox[] allFrames = { 
                pbCamL1Panorama, pbCamL1Plate, pbCamL2Panorama, pbCamL2Plate,
                pbSnapL1_1, pbSnapL1_2, pbSnapL2_1, pbSnapL2_2,
                pbAIL1In, pbAIL1Out, pbAIL2In, pbAIL2Out 
            };

            foreach (var pb in allFrames) {
                if (pb != null) {
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    // YÊU CẦU 2: Docking đặt Dock = Fill
                    pb.Dock = DockStyle.Fill;
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (lblSoftwareName != null) lblSoftwareName.Text = "IDT PARKING SYSTEM";
            
            using (LoginForm login = new LoginForm())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    string info = $"Nhân viên: {login.FullName} ({login.CurrentUser}) - Ca: {login.CurrentShift} - Vào ca: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                    if (lblGuardL1 != null) lblGuardL1.Text = info;
                    if (lblGuardL2 != null) lblGuardL2.Text = info;
                    
                    ApplySettingsToUI();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void ApplySettingsToUI()
        {
            _settings = AppSettings.Load();
            if (_settings.ShowCamerasOnMain) LoadCameras();
            else StopCameras();
        }

        /// <summary>
        /// YÊU CẦU 3: Xử lý thẻ tháng quẹt vào làn Phải (Làn 2)
        /// </summary>
        public void ProcessMonthlyCardEntry(string cardId)
        {
            // Giả sử Làn 2 là làn vào mặc định cho thẻ tháng
            // Truy vấn cơ sở dữ liệu để lấy thông tin thẻ tháng
            string connString = _settings.GetConnectionString();
            try {
                using (SqlConnection conn = new SqlConnection(connString)) {
                    conn.Open();
                    string query = @"SELECT kh.hoten, tt.soxe, lt.LoaiThe, kh.DonVi 
                                    FROM TheThang tt
                                    JOIN KhachHang kh ON tt.MaKH = kh.MaKH
                                    JOIN LoaiThe lt ON tt.MaLoaiThe = lt.MaLoaiThe
                                    WHERE tt.CardID = @CardID AND tt.TTrang = 1";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@CardID", cardId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read()) {
                            // Tự động đổ dữ liệu vào các nhãn thông tin của Làn 2
                            lblOwner2.Text = "CHỦ XE: " + reader["hoten"].ToString();
                            lblPlate2.Text = "BIỂN SỐ: " + reader["soxe"].ToString();
                            lblRegistration2.Text = "ĐĂNG KÝ: " + reader["DonVi"].ToString();
                            lblCardType2.Text = "LOẠI THẺ: " + reader["LoaiThe"].ToString();
                            lblCardID2.Text = "SỐ THẺ: " + cardId;
                            lblTimeIn2.Text = "VÀO: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            lblTimeOut2.Text = "---";
                            lblAmount2.Text = "THẺ THÁNG OK";
                            lblAmount2.ForeColor = Color.Green;
                        }
                        reader.Close();
                    }
                }
            } catch (Exception ex) {
                // Log lỗi hoặc hiển thị thông báo nếu cần
            }
        }

        // --- HÀM CẬP NHẬT AI CHO LÀN 1 ---
        public void UpdateAILane1(Image imgIn, Image imgOut, string plateIn, string plateOut)
        {
            if (pbAIL1In != null) pbAIL1In.Image = imgIn;
            if (pbAIL1Out != null) pbAIL1Out.Image = imgOut;
            if (lblAIPlateInL1 != null) lblAIPlateInL1.Text = plateIn;
            if (lblAIPlateOutL1 != null) lblAIPlateOutL1.Text = plateOut;

            bool isMatch = (plateIn == plateOut && !string.IsNullOrEmpty(plateIn));
            lblAIResultL1.Text = isMatch ? "KHỚP" : "KIỂM TRA";
            lblAIResultL1.ForeColor = isMatch ? Color.LimeGreen : Color.Red;
        }

        // --- HÀM CẬP NHẬT AI CHO LÀN 2 ---
        public void UpdateAILane2(Image imgIn, Image imgOut, string plateIn, string plateOut)
        {
            if (pbAIL2In != null) pbAIL2In.Image = imgIn;
            if (pbAIL2Out != null) pbAIL2Out.Image = imgOut;
            if (lblAIPlateInL2 != null) lblAIPlateInL2.Text = plateIn;
            if (lblAIPlateOutL2 != null) lblAIPlateOutL2.Text = plateOut;

            bool isMatch = (plateIn == plateOut && !string.IsNullOrEmpty(plateIn));
            lblAIResultL2.Text = isMatch ? "KHỚP" : "KIỂM TRA";
            lblAIResultL2.ForeColor = isMatch ? Color.LimeGreen : Color.Red;
        }

        private void LoadCameras()
        {
            StopCameras();
            string vlcPath = GetVlcPath();
            if (string.IsNullOrEmpty(vlcPath)) {
                MessageBox.Show("Không tìm thấy thư mục cài đặt VLC!", "Lỗi Camera", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DirectoryInfo vlcDir = new DirectoryInfo(vlcPath);
            string[] options = { ":rtsp-tcp", ":network-caching=300", ":live-caching=300", ":no-stats", ":no-video-title-show" };

            // Khởi tạo và chạy 4 Camera
            _vlcL1Pano = CreateVlcControl(vlcDir, options, pbCamL1Panorama, GetRtspUrl(1, false));
            _vlcL1Plate = CreateVlcControl(vlcDir, options, pbCamL1Plate, GetRtspUrl(1, true));
            _vlcL2Pano = CreateVlcControl(vlcDir, options, pbCamL2Panorama, GetRtspUrl(2, false));
            _vlcL2Plate = CreateVlcControl(vlcDir, options, pbCamL2Plate, GetRtspUrl(2, true));
        }

        private VlcControl CreateVlcControl(DirectoryInfo vlcDir, string[] options, PictureBox container, string rtspUrl)
        {
            if (container == null || string.IsNullOrEmpty(rtspUrl)) return null;

            var vlc = new VlcControl();
            vlc.BeginInit();
            vlc.VlcLibDirectory = vlcDir;
            vlc.VlcMediaplayerOptions = options;
            vlc.EndInit();

            vlc.Dock = DockStyle.Fill;
            container.Controls.Clear();
            container.Controls.Add(vlc);
            
            vlc.Play(new Uri(rtspUrl));
            return vlc;
        }

        private string GetRtspUrl(int lane, bool isPlate)
        {
            if (_settings.CameraType == 0) // Analog
            {
                int channel = 1;
                if (lane == 1) channel = isPlate ? _settings.ChLane1Plate : _settings.ChLane1Front;
                else channel = isPlate ? _settings.ChLane2Plate : _settings.ChLane2Front;
                
                return $"rtsp://{_settings.DvrUser}:{_settings.DvrPass}@{_settings.DvrHost}:554/cam/realmonitor?channel={channel}&subtype=1";
            }
            else // IP
            {
                string host = "", user = "", pass = "", path = "";
                if (lane == 1) {
                    host = isPlate ? _settings.IpCamL1PlateHost : _settings.IpCamL1FrontHost;
                    user = isPlate ? _settings.IpCamL1PlateUser : _settings.IpCamL1FrontUser;
                    pass = isPlate ? _settings.IpCamL1PlatePass : _settings.IpCamL1FrontPass;
                    path = isPlate ? _settings.IpCamL1PlateRTSP : _settings.IpCamL1FrontRTSP;
                } else {
                    host = isPlate ? _settings.IpCamL2PlateHost : _settings.IpCamL2FrontHost;
                    user = isPlate ? _settings.IpCamL2PlateUser : _settings.IpCamL2FrontUser;
                    pass = isPlate ? _settings.IpCamL2PlatePass : _settings.IpCamL2FrontPass;
                    path = isPlate ? _settings.IpCamL2PlateRTSP : _settings.IpCamL2FrontRTSP;
                }

                if (path.StartsWith("rtsp://")) return path;
                string separator = path.Contains("?") ? "&" : "?";
                string finalPath = path.Contains("subtype=") ? path : $"{path}{separator}subtype=1";
                return $"rtsp://{user}:{pass}@{host}:554{finalPath}";
            }
        }

        private void StopCameras()
        {
            VlcControl[] controls = { _vlcL1Pano, _vlcL1Plate, _vlcL2Pano, _vlcL2Plate };
            foreach (var vlc in controls) {
                if (vlc != null) {
                    try { vlc.Stop(); vlc.Dispose(); } catch { }
                }
            }
            _vlcL1Pano = _vlcL1Plate = _vlcL2Pano = _vlcL2Plate = null;
        }

        private string GetVlcPath()
        {
            string programFiles = Environment.Is64BitProcess ? "ProgramFiles" : "ProgramFiles(x86)";
            string path = Path.Combine(Environment.GetEnvironmentVariable(programFiles), "VideoLAN", "VLC");
            return Directory.Exists(path) ? path : "";
        }

        private void tableLayoutPanel20_Paint(object sender, PaintEventArgs e) { }

        public void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3) {
                using (FrmSettings s = new FrmSettings()) { if (s.ShowDialog() == DialogResult.OK) ApplySettingsToUI(); }
            }
            if (e.KeyCode == Keys.Escape) Application.Exit();
        }
    }
}
