using System;
using System.IO;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace IDTSERVER
{
    public partial class FormCameraPreview : Form
    {
        private VlcControl _vlc;

        public FormCameraPreview(string cameraName, string rtspUrl)
        {
            InitializeComponent();
            this.lblTitle.Text = "XEM THỬ: " + cameraName + (Environment.Is64BitProcess ? " [64-bit]" : " [32-bit]");
            this.txtInfo.UseMnemonic = false;
            this.txtInfo.Text = rtspUrl;

            this.Load += (s, e) => InitCamera(rtspUrl);
        }

        private void InitCamera(string rtspUrl)
        {
            try
            {
                string programFiles = Environment.Is64BitProcess
                    ? Environment.GetEnvironmentVariable("ProgramFiles")
                    : Environment.GetEnvironmentVariable("ProgramFiles(x86)");

                string vlcPath = Path.Combine(programFiles, "VideoLAN", "VLC");

                if (!Directory.Exists(vlcPath))
                {
                    lblLoading.Text = "KHÔNG TÌM THẤY VLC TẠI:\n" + vlcPath;
                    return;
                }

                _vlc = new VlcControl();
                _vlc.BeginInit();
                _vlc.VlcLibDirectory = new DirectoryInfo(vlcPath);
                _vlc.VlcMediaplayerOptions = new string[] {
                    ":rtsp-tcp",
                    ":network-caching=300",
                    ":live-caching=300",
                    ":no-stats",
                    ":no-video-title-show"
                };
                _vlc.EndInit();

                pnlMain.Controls.Clear();
                _vlc.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(_vlc);
                _vlc.BringToFront();

                _vlc.Playing += (s, e) => {
                    this.BeginInvoke(new Action(() => {
                        lblLoading.Visible = false;
                        picVideo.Visible = false;
                    }));
                };

                _vlc.Play(new Uri(rtspUrl));
                lblLoading.Text = "Đang thắp sáng luồng Camera...";
            }
            catch (Exception ex)
            {
                lblLoading.Text = "LỖI: " + ex.Message;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            StopVlc();
            this.Close();
        }

        private void StopVlc()
        {
            try {
                if (_vlc != null) {
                    _vlc.Stop();
                    _vlc.Dispose();
                    _vlc = null;
                }
            } catch { }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopVlc();
            base.OnFormClosing(e);
        }
    }
}
