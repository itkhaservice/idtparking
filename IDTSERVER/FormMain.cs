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
            ApplySettingsToUI();
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
                            lblAmount2Text.Text = "THẺ THÁNG OK";
                            lblAmount2Text.ForeColor = Color.Green;
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
            if (string.IsNullOrEmpty(vlcPath)) return;

            // Xây dựng URL RTSP từ settings và khởi tạo VLC controls
            // (Phần này sẽ triển khai chi tiết dựa trên logic RTSP trong FrmSettings)
        }

        private void StopCameras()
        {
            if (_vlcL1Pano != null) _vlcL1Pano.Dispose();
            if (_vlcL1Plate != null) _vlcL1Plate.Dispose();
            if (_vlcL2Pano != null) _vlcL2Pano.Dispose();
            if (_vlcL2Plate != null) _vlcL2Plate.Dispose();
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
