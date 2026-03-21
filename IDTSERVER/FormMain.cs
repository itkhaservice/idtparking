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
        private bool _isLoggedIn = false;
        
        // Luồng Video Live
        private VlcControl _vlcL1Pano, _vlcL1Plate, _vlcL2Pano, _vlcL2Plate;

        public FormMain()
        {
            InitializeComponent();
            _settings = AppSettings.Load();
            SetupUIProportions();
            
            // Cấu hình chống vỡ UI
            this.MinimumSize = new Size(1200, 700);
            this.Resize += (s, e) => AdjustLabelFonts();

            _clockTimer = new Timer { Interval = 1000 };
            _clockTimer.Tick += (s, e) => {
                if (lblCurrentTime != null) lblCurrentTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            };
            _clockTimer.Start();

            this.Load += FormMain_Load;
        }

        private void SetupUIProportions()
        {
            // YÊU CẦU 1: PictureBoxes Zoom & Fill (Không đụng tới pbSnapL2_1, pbSnapL2_2)
            PictureBox[] allFrames = { 
                pbCamL1Panorama, pbCamL1Plate, pbCamL2Panorama, pbCamL2Plate,
                pbSnapL1_1, pbSnapL1_2,
                pbAIL1In, pbAIL1Out, pbAIL2In, pbAIL2Out 
            };

            foreach (var pb in allFrames) {
                if (pb != null) {
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Dock = DockStyle.Fill;
                    pb.Margin = new Padding(0); // Triệt tiêu khoảng cách lề
                    
                    // Nếu parent là TableLayoutPanel, triệt tiêu Padding của ô đó
                    if (pb.Parent is TableLayoutPanel tlp) {
                        tlp.Padding = new Padding(0);
                    }
                }
            }

            // Chống vỡ chữ & Chia đều dòng cho các TableLayoutPanel thông tin
            // Làn 1: tableLayoutPanel8, Làn 2: tableLayoutPanel20
            FixTableLayoutRowStyles(tableLayoutPanel8, 5);
            FixTableLayoutRowStyles(tableLayoutPanel20, 5);

            // Cấu hình tỉ lệ cột cho cả 2 Làn
            // Nhóm Số thẻ - Loại thẻ - TG lưu bãi (30-30-40)
            FixTableLayoutColumnStyles(tableLayoutPanel25, new float[] { 30f, 30f, 40f });
            FixTableLayoutColumnStyles(tableLayoutPanel22, new float[] { 30f, 30f, 40f });

            // Nhóm Biển số - Chủ xe (60-40)
            FixTableLayoutColumnStyles(tableLayoutPanel23, new float[] { 60f, 40f });
            FixTableLayoutColumnStyles(tableLayoutPanel26, new float[] { 60f, 40f });

            // Nhóm Thời gian Vào - Ra (50-50)
            FixTableLayoutColumnStyles(tableLayoutPanel31, new float[] { 50f, 50f });
            FixTableLayoutColumnStyles(tableLayoutPanel24, new float[] { 50f, 50f });
            
            Label[] infoLabels = {
                lblCardID1, lblCardType1, lblStayDuration1, lblOwner1, lblPlate1, lblRegistration1, lblTimeIn1, lblTimeOut1, lblAmount1,
                lblCardID2, lblCardType2, lblStayDuration2, lblOwner2, lblPlate2, lblRegistration2, lblTimeIn2, lblTimeOut2, lblAmount2,
                lblAmount1Text, lblAmount2Text
            };

            foreach (var lb in infoLabels) {
                if (lb != null) {
                    lb.AutoSize = false;
                    lb.Dock = DockStyle.Fill;
                    lb.TextAlign = ContentAlignment.MiddleLeft;
                }
            }
        }

        private void FixTableLayoutRowStyles(TableLayoutPanel tlp, int rowCount)
        {
            if (tlp == null) return;
            tlp.RowCount = rowCount;
            tlp.RowStyles.Clear();
            float percent = 100f / rowCount;
            for (int i = 0; i < rowCount; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Percent, percent));
            }
        }

        private void FixTableLayoutColumnStyles(TableLayoutPanel tlp, float[] percentages)
        {
            if (tlp == null || percentages == null) return;
            tlp.ColumnCount = percentages.Length;
            tlp.ColumnStyles.Clear();
            foreach (var p in percentages)
            {
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, p));
            }
        }

        private void AdjustLabelFonts()
        {
            float ratio = this.Width / 1920f;
            
            // Định nghĩa các cỡ chữ cơ sở (cho màn 1080p)
            float sizeStandard = 13f;   // Thông tin thẻ, nhân viên
            float sizeNotify = 18f;     // Thông báo, Kết quả AI
            float sizeAmount = 24f;     // Tiền thanh toán
            float sizeHeader = 22f;     // Tên phần mềm
            float sizeClock = 16f;      // Đồng hồ

            // Tính toán cỡ chữ mới dựa trên tỉ lệ resize
            float fStd = Math.Max(8f, sizeStandard * ratio);
            float fNoti = Math.Max(10f, sizeNotify * ratio);
            float fAmnt = Math.Max(14f, sizeAmount * ratio);
            float fHead = Math.Max(12f, sizeHeader * ratio);
            float fClock = Math.Max(10f, sizeClock * ratio);

            // Tạo các đối tượng Font
            Font fontStd = new Font("Times New Roman", fStd, FontStyle.Bold);
            Font fontNoti = new Font("Times New Roman", fNoti, FontStyle.Bold);
            Font fontAmnt = new Font("Times New Roman", fAmnt, FontStyle.Bold);
            Font fontHead = new Font("Times New Roman", fHead, FontStyle.Bold);
            Font fontClock = new Font("Times New Roman", fClock, FontStyle.Bold);

            // 1. Nhóm Thông tin thẻ (Làn 1 & 2)
            Label[] cardLabels = { 
                lblCardID1, lblCardType1, lblStayDuration1, lblOwner1, lblPlate1, lblRegistration1, lblTimeIn1, lblTimeOut1, lblAmount1Text,
                lblCardID2, lblCardType2, lblStayDuration2, lblOwner2, lblPlate2, lblRegistration2, lblTimeIn2, lblTimeOut2, lblAmount2Text
            };
            foreach (var lb in cardLabels) if (lb != null) lb.Font = fontStd;

            // 2. Nhóm Thanh toán (Tiền)
            if (lblAmount1 != null) lblAmount1.Font = fontAmnt;
            if (lblAmount2 != null) lblAmount2.Font = fontAmnt;

            // 3. Nhóm Thông báo & Nhân viên
            if (lblNotifyL1 != null) lblNotifyL1.Font = fontNoti;
            if (lblNotifyL2 != null) lblNotifyL2.Font = fontNoti;
            if (lblGuardL1 != null) lblGuardL1.Font = fontStd;
            if (lblGuardL2 != null) lblGuardL2.Font = fontStd;

            // 4. Nhóm AI (Kết quả so khớp & Biển số nhận diện)
            if (lblAIResultL1 != null) lblAIResultL1.Font = fontNoti;
            if (lblAIResultL2 != null) lblAIResultL2.Font = fontNoti;
            Label[] aiPlates = { lblAIPlateInL1, lblAIPlateOutL1, lblAIPlateInL2, lblAIPlateOutL2 };
            foreach (var lb in aiPlates) if (lb != null) lb.Font = fontStd;

            // 5. Nhóm Header & Clock
            if (lblSoftwareName != null) lblSoftwareName.Font = fontHead;
            if (lblCurrentTime != null) lblCurrentTime.Font = fontClock;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (lblSoftwareName != null) lblSoftwareName.Text = "IDT PARKING SYSTEM";
            
            // Mặc định ban đầu: Chưa đăng nhập
            UpdateLoginStatus(null, null, null);
            ApplySettingsToUI();
            LoadDefaultImages();

            // Hiển thị bảng đăng nhập khi khởi động nhưng không bắt buộc (bấm thoát vẫn vào được FormMain)
            using (LoginForm login = new LoginForm())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    UpdateLoginStatus(login.FullName, login.CurrentUser, login.CurrentShift);
                }
            }
        }

        private void LoadDefaultImages()
        {
            try
            {
                // Đường dẫn tương đối từ thư mục thực thi (giả định bin/Debug)
                string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", ".."));
                string assetsPath = Path.Combine(projectRoot, "Assets", "Images");

                if (!Directory.Exists(assetsPath))
                {
                    // Thử trường hợp chạy thực tế nếu folder Assets được copy vào folder thực thi
                    assetsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images");
                }

                string imgVao = Path.Combine(assetsPath, "lan-vao.png");
                string imgRa = Path.Combine(assetsPath, "lan-ra.png");

                // Làn 1 (Trái) - Mặc định là RA
                if (File.Exists(imgRa))
                {
                    Image raImg = Image.FromFile(imgRa);
                    if (pbSnapL1_1 != null) pbSnapL1_1.Image = raImg;
                    if (pbSnapL1_2 != null) pbSnapL1_2.Image = raImg;
                }

                // Làn 2 (Phải) - Mặc định là VÀO
                if (File.Exists(imgVao))
                {
                    Image vaoImg = Image.FromFile(imgVao);
                    if (pbSnapL2_1 != null) pbSnapL2_1.Image = vaoImg;
                    if (pbSnapL2_2 != null) pbSnapL2_2.Image = vaoImg;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi LoadDefaultImages: " + ex.Message);
            }
        }

        private void UpdateLoginStatus(string fullName, string user, string shift)
        {
            if (string.IsNullOrEmpty(user))
            {
                _isLoggedIn = false;
                string info = "TRẠNG THÁI: CHƯA ĐĂNG NHẬP (Nhấn F1 để đăng nhập)";
                if (lblGuardL1 != null) lblGuardL1.Text = info;
                if (lblGuardL2 != null) lblGuardL2.Text = info;
            }
            else
            {
                _isLoggedIn = true;
                string info = $"Nhân viên: {fullName} ({user}) - Ca: {shift} - Vào ca: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                if (lblGuardL1 != null) lblGuardL1.Text = info;
                if (lblGuardL2 != null) lblGuardL2.Text = info;
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
                Console.WriteLine("Lỗi ProcessMonthlyCardEntry: " + ex.Message);
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
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận thoát", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    break;

                case Keys.F1:
                    PerformLogin();
                    break;

                case Keys.F2:
                    PerformLogout();
                    break;

                case Keys.F3:
                    using (FrmSettings s = new FrmSettings())
                    {
                        if (s.ShowDialog() == DialogResult.OK) ApplySettingsToUI();
                    }
                    break;

                case Keys.F4:
                    // Đăng nhập vào Quản lý dữ liệu hệ thống xe
                    using (LoginForm login = new LoginForm())
                    {
                        if (login.ShowDialog() == DialogResult.OK)
                        {
                            // Sau khi đăng nhập thành công thì mở FormTruyVan (Kế toán/Quản lý)
                            // Lưu ý: FormTruyVan ở project root, cần kiểm tra namespace
                            // Mở FormMain ở IDTPARKING để tránh lỗi liên quan đến việc mở Form từ một project khác
                            MessageBox.Show("Mở chức năng Quản lý dữ liệu (Kế toán)");
                        }
                    }
                    break;

                case Keys.F5:
                    // Xem lại hình ảnh của thẻ vừa quẹt ở làn bên trái
                    MessageBox.Show("Xem lại hình ảnh Làn Trái (Làn 1)");
                    break;

                case Keys.F6:
                    // Xem lại hình ảnh của thẻ vừa quẹt ở làn bên phải (Giả định F6 vì yêu cầu ghi 2 lần F5)
                    MessageBox.Show("Xem lại hình ảnh Làn Phải (Làn 2)");
                    break;

                case Keys.F7:
                    // Đổi làn ra/vào bên màn hình bên trái (Chỉ hoán đổi Vào <-> Ra)
                    _settings.Lane1Direction = (_settings.Lane1Direction == 0) ? 1 : 0;
                    _settings.Save();
                    // Cập nhật lại hình ảnh mặc định theo chiều làn mới
                    if (_settings.Lane1Direction == 0) { // VÀO
                        if (pbSnapL1_1 != null) pbSnapL1_1.Image = Properties.Resources.lan_vao;
                        if (pbSnapL1_2 != null) pbSnapL1_2.Image = Properties.Resources.lan_vao;
                    } else { // RA
                        if (pbSnapL1_1 != null) pbSnapL1_1.Image = Properties.Resources.lan_ra;
                        if (pbSnapL1_2 != null) pbSnapL1_2.Image = Properties.Resources.lan_ra;
                    }
                    break;

                case Keys.F8:
                    // Đổi làn ra/vào bên màn hình bên phải (Chỉ hoán đổi Vào <-> Ra)
                    _settings.Lane2Direction = (_settings.Lane2Direction == 0) ? 1 : 0;
                    _settings.Save();
                    // Cập nhật lại hình ảnh mặc định theo chiều làn mới
                    if (_settings.Lane2Direction == 0) { // VÀO
                        if (pbSnapL2_1 != null) pbSnapL2_1.Image = Properties.Resources.lan_vao;
                        if (pbSnapL2_2 != null) pbSnapL2_2.Image = Properties.Resources.lan_vao;
                    } else { // RA
                        if (pbSnapL2_1 != null) pbSnapL2_1.Image = Properties.Resources.lan_ra;
                        if (pbSnapL2_2 != null) pbSnapL2_2.Image = Properties.Resources.lan_ra;
                    }
                    break;

                case Keys.F11:
                    if (MessageBox.Show("Bạn có muốn khởi động lại chương trình?", "Reset", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    break;

                case Keys.F12:
                    // Thoát ra màn hình chính (Thu nhỏ hoặc về trạng thái mặc định)
                    this.WindowState = FormWindowState.Minimized;
                    break;
            }
        }

        private void PerformLogin()
        {
            using (LoginForm login = new LoginForm())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    string info = $"Nhân viên: {login.FullName} ({login.CurrentUser}) - Ca: {login.CurrentShift} - Vào ca: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                    if (lblGuardL1 != null) lblGuardL1.Text = info;
                    if (lblGuardL2 != null) lblGuardL2.Text = info;
                    ApplySettingsToUI();
                }
            }
        }

        private void PerformLogout()
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất và thực hiện bàn giao ca?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Hiển thị thông tin giao ca
                // using (ShiftHandoverForm shf = new ShiftHandoverForm()) { shf.ShowDialog(); }
                
                if (lblGuardL1 != null) lblGuardL1.Text = "Nhân viên: ---";
                if (lblGuardL2 != null) lblGuardL2.Text = "Nhân viên: ---";
                StopCameras();
                
                // Sau khi đăng xuất, yêu cầu đăng nhập lại
                PerformLogin();
            }
        }

        private string GetDirectionName(int dir)
        {
            switch (dir)
            {
                case 0: return "VÀO";
                case 1: return "RA";
                case 2: return "ĐẢO CHIỀU";
                default: return "KHÔNG XÁC ĐỊNH";
            }
        }
    }
}
