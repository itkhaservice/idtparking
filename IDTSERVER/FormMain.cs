using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
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
            
            //_clockTimer = new Timer { Interval = 1000 };
            //_clockTimer.Tick += (s, e) => {
            //    if (lblCurrentTime != null) lblCurrentTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            //};
            //_clockTimer.Start();

            //this.Load += FormMain_Load;
            //this.KeyDown += FormMain_KeyDown;
        }

        private void SetupUIProportions()
        {
            //PictureBox[] allFrames = { 
            //    pbCamL1Panorama, pbCamL1Plate, pbCamL2Panorama, pbCamL2Plate,
            //    pbSnapL1_1, pbSnapL1_2, pbSnapL2_1, pbSnapL2_2,
            //    pbAIL1In, pbAIL1Out, pbAIL2In 
            //};

            //foreach (var pb in allFrames) {
            //    if (pb != null) pb.SizeMode = PictureBoxSizeMode.Zoom;
            //}
        }

        //private void FormMain_Load(object sender, EventArgs e)
        //{
        //    if (lblSoftwareName != null) lblSoftwareName.Text = "KHA - PARKING";
        //    ApplySettingsToUI();
        //}

        //private void ApplySettingsToUI()
        //{
        //    _settings = AppSettings.Load();
        //    if (_settings.ShowCamerasOnMain) LoadCameras();
        //    else StopCameras();
        //}

        //// --- HÀM CẬP NHẬT 5 PHẦN AI CHO LÀN RA (Làn 1) ---
        //public void UpdateAILaneExit(Image imgIn, Image imgOut, string plateIn, string plateOut)
        //{
        //    if (pbAIL1In != null) pbAIL1In.Image = imgIn;
        //    if (pbAIL1Out != null) pbAIL1Out.Image = imgOut;
        //    if (lblAIPlateInL1 != null) lblAIPlateInL1.Text = "VÀO: " + plateIn;
        //    if (lblAIPlateOutL1 != null) lblAIPlateOutL1.Text = "RA: " + plateOut;

        //    if (lblAICompareL1 != null) 
        //    {
        //        bool isMatch = (plateIn == plateOut);
        //        lblAICompareL1.Text = isMatch ? "KHỚP BIỂN SỐ" : "KHÔNG KHỚP";
        //        lblAICompareL1.ForeColor = isMatch ? Color.LimeGreen : Color.Red;
        //    }
        //}

        //// --- HÀM CẬP NHẬT AI CHO LÀN VÀO (Làn 2) ---
        //public void UpdateAILaneEntry(Image imgIn, string plateIn)
        //{
        //    if (pbAIL2In != null) pbAIL2In.Image = imgIn;
        //    if (lblAIPlateInL2 != null) lblAIPlateInL2.Text = "BIỂN SỐ: " + plateIn;
        //}

        //private void LoadCameras()
        //{
        //    StopCameras();
        //    string vlcPath = GetVlcPath();
        //    if (string.IsNullOrEmpty(vlcPath)) return;

        //    _vlcL1Pano = CreateVlc(vlcPath, "url_pano_1", pbCamL1Panorama);
        //    _vlcL1Plate = CreateVlc(vlcPath, "url_plate_1", pbCamL1Plate);
        //    _vlcL2Pano = CreateVlc(vlcPath, "url_pano_2", pbCamL2Panorama);
        //    _vlcL2Plate = CreateVlc(vlcPath, "url_plate_2", pbCamL2Plate);
        //}

        //private VlcControl CreateVlc(string path, string url, PictureBox host)
        //{
        //    if (host == null) return null;
        //    var vlc = new VlcControl();
        //    vlc.BeginInit();
        //    vlc.VlcLibDirectory = new DirectoryInfo(path);
        //    vlc.EndInit();
        //    vlc.Dock = DockStyle.Fill;
        //    host.Controls.Clear();
        //    host.Controls.Add(vlc);
        //    return vlc;
        //}

        //private void StopCameras()
        //{
        //    if (_vlcL1Pano != null) _vlcL1Pano.Dispose();
        //    if (_vlcL1Plate != null) _vlcL1Plate.Dispose();
        //    if (_vlcL2Pano != null) _vlcL2Pano.Dispose();
        //    if (_vlcL2Plate != null) _vlcL2Plate.Dispose();
        //}

        //private string GetVlcPath()
        //{
        //    string programFiles = Environment.Is64BitProcess ? "ProgramFiles" : "ProgramFiles(x86)";
        //    string path = Path.Combine(Environment.GetEnvironmentVariable(programFiles), "VideoLAN", "VLC");
        //    return Directory.Exists(path) ? path : "";
        //}

        private void tableLayoutPanel20_Paint(object sender, PaintEventArgs e) { }

        public void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F3) {
            //    using (FrmSettings s = new FrmSettings()) { if (s.ShowDialog() == DialogResult.OK) ApplySettingsToUI(); }
            //}
            if (e.KeyCode == Keys.Escape) Application.Exit();
        }
    }
}