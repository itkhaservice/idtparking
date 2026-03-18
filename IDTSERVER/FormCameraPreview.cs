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
            this.lblTitle.Text = "XEM THỬ: " + cameraName;
            this.txtInfo.UseMnemonic = false;
            this.txtInfo.Text = rtspUrl;

            // Hiển thị bitness để kiểm tra
            this.lblTitle.Text += (Environment.Is64BitProcess ? " [64-bit]" : " [32-bit]");

            this.Load += (s, e) => InitCamera(rtspUrl);
        }

        private void InitCamera(string rtspUrl)
        {
            try
            {
                // 1. TÌM THƯ MỤC VLC CHUẨN
                string programFiles = Environment.Is64BitProcess
                    ? Environment.GetEnvironmentVariable("ProgramFiles")
                    : Environment.GetEnvironmentVariable("ProgramFiles(x86)");

                string vlcPath = Path.Combine(programFiles, "VideoLAN", "VLC");

                if (!Directory.Exists(vlcPath))
                {
                    lblLoading.Text = "KHÔNG TÌM THẤY VLC TẠI:\n" + vlcPath;
                    return;
                }

                // 2. KHỞI TẠO VLC VỚI THAM SỐ CHỐNG TREO (FOR KBVISION/DAHUA)
                _vlc = new VlcControl();
                _vlc.BeginInit();
                _vlc.VlcLibDirectory = new DirectoryInfo(vlcPath);

                // Bộ tham số tối ưu nhất để hình ảnh chạy mượt (không đứng yên)
                _vlc.VlcMediaplayerOptions = new string[]
                {
                    ":rtsp-tcp",                // Ép dùng TCP
                    ":network-caching=500",     // Tăng cache để ổn định
                    ":live-caching=500",
                    ":clock-jitter=0",          // Chống đứng hình do lệch clock (Dahua fix)
                    ":clock-synchro=0",         // Đồng bộ clock liên tục
                    ":no-video-title-show",
                    ":no-stats",
                    ":no-hw-dec"                // Tắt gia tốc phần cứng để tránh lỗi render WinForms
                };

                _vlc.EndInit();

                // 3. THIẾT LẬP HIỂN THỊ SẠCH
                pnlMain.Controls.Clear(); // Xóa sạch rác
                _vlc.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(_vlc);
                _vlc.BringToFront();

                // 4. XỬ LÝ SỰ KIỆN
                _vlc.Playing += (s, e) =>
                {
                    this.Invoke(new Action(() => {
                        lblLoading.Visible = false;
                        picVideo.Visible = false;
                    }));
                };

                _vlc.EncounteredError += (s, e) =>
                {
                    this.Invoke(new Action(() => {
                        lblLoading.Text = "LỖI STREAM: Vui lòng kiểm tra lại kết nối!";
                        lblLoading.Visible = true;
                    }));
                };

                // 5. PHÁT VIDEO VỚI OPTIONS TRUYỀN THẲNG (ĐẢM BẢO CHẠY)
                _vlc.Play(new Uri(rtspUrl));
                lblLoading.Text = "Đang kết nối luồng Live Video...";
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
            try
            {
                if (_vlc != null)
                {
                    _vlc.Stop();
                    _vlc.Dispose();
                    _vlc = null;
                }
            }
            catch { }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopVlc();
            base.OnFormClosing(e);
        }
    }
}
