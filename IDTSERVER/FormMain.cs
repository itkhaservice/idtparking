using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace IDTSERVER
{
    public partial class FormMain : Form
    {
        private bool _isSystemActive = false;
        private string _currentUser = "CHƯA ĐĂNG NHẬP";
        private string _currentShift = "N/A";

        public FormMain()
        {
            InitializeComponent();
            SetupKeyboardShortcuts();
            
            // 1. Luôn hiển thị hình ảnh mặc định
            LoadPlaceholderImages();
            
            // 2. Luôn hiển thị dữ liệu ảo để mô phỏng giao diện
            LoadDummyData();
            
            this.Text = "IDT PARKING - HỆ THỐNG CHỜ ĐĂNG NHẬP (F1)";
        }

        private void LoadPlaceholderImages()
        {
            Bitmap camIcon = CreateCameraPlaceholder(320, 240, "CAMERA - STANDBY", Color.FromArgb(0, 120, 215));
            Bitmap snapIcon = CreateCameraPlaceholder(320, 240, "HISTORY - READY", Color.Gray);

            pbCam1.Image = pbCam2.Image = pbCam3.Image = pbCam4.Image = camIcon;
            pbSnap1.Image = pbSnap2.Image = pbSnap3.Image = pbSnap4.Image = snapIcon;
        }

        private void LoadDummyData()
        {
            // Làn Trái
            gateLeft.UpdateInfo("UID-40291", "Xe Máy - Tháng", "NGUYỄN TRƯỜNG HOÀNG MINH", "51-G1-77777", "Chung cư IDT, Tân Bình", "0");
            gateLeft.SetTimes("02:15:00", "10:15:20 - 17/03", "12:30:20 - 17/03");
            gateLeft.SetMatchResult(true);
            gateLeft.SetAIPlates("51-G1\n77777", "51-G1\n77777");

            // Làn Phải
            gateRight.UpdateInfo("UID-99999", "Xe Máy - Vãng lai", "KHÁCH VÃNG LAI", "59-K1-88888", "N/A", "5.000");
            gateRight.SetTimes("00:45:00", "11:00:00 - 17/03", "11:45:00 - 17/03");
            gateRight.SetMatchResult(false);
            gateRight.SetAIPlates("59-K1\n88888", "59-K1\n00000");
        }

        private void SetupKeyboardShortcuts()
        {
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        if (MessageBox.Show("Thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Application.Exit();
                        break;

                    case Keys.F1:
                        using (LoginForm login = new LoginForm())
                        {
                            if (login.ShowDialog() == DialogResult.OK)
                            {
                                _isSystemActive = true;
                                _currentUser = login.CurrentUser;
                                _currentShift = login.CurrentShift;
                                this.Text = $"IDT PARKING - ĐANG HOẠT ĐỘNG | NV: {_currentUser} | {_currentShift}";
                                MessageBox.Show($"Chào mừng {_currentUser} vào ca trực!");
                            }
                        }
                        break;

                    case Keys.F2:
                        if (!_isSystemActive) { MessageBox.Show("Vui lòng nhấn F1 để đăng nhập trước!"); break; }
                        using (ShiftHandoverForm handover = new ShiftHandoverForm())
                        {
                            if (handover.ShowDialog() == DialogResult.OK)
                            {
                                _isSystemActive = false;
                                this.Text = "IDT PARKING - HỆ THỐNG CHỜ ĐĂNG NHẬP (F1)";
                                MessageBox.Show("Bàn giao ca thành công.");
                            }
                        }
                        break;

                    case Keys.F11: Application.Restart(); break;
                }
            };
        }

        private Bitmap CreateCameraPlaceholder(int width, int height, string text, Color accentColor)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.FromArgb(20, 20, 20));
                Pen pen = new Pen(accentColor, 2);
                int s = 20;
                g.DrawLine(pen, 10, 10, 10 + s, 10); g.DrawLine(pen, 10, 10, 10, 10 + s);
                g.DrawLine(pen, width - 10, 10, width - 10 - s, 10); g.DrawLine(pen, width - 10, 10, width - 10, 10 + s);
                g.DrawLine(pen, 10, height - 10, 10 + s, height - 10); g.DrawLine(pen, 10, height - 10, 10, height - 10 - s);
                g.DrawLine(pen, width - 10, height - 10, width - 10 - s, height - 10); g.DrawLine(pen, width - 10, height - 10, width - 10, height - 10 - s);
                g.FillRectangle(new SolidBrush(accentColor), width / 2 - 20, height / 2 - 15, 40, 25);
                g.FillEllipse(new SolidBrush(Color.FromArgb(20, 20, 20)), width / 2 - 8, height / 2 - 8, 16, 16);
                Font font = new Font("Segoe UI", 9, FontStyle.Bold);
                SizeF textSize = g.MeasureString(text, font);
                g.DrawString(text, font, new SolidBrush(accentColor), (width - textSize.Width) / 2, height / 2 + 20);
            }
            return bmp;
        }
    }
}
