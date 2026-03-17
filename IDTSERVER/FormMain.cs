using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace IDTSERVER
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            SetupKeyboardShortcuts();
            LoadPlaceholderImages();
            LoadDummyData();
        }

        private void LoadPlaceholderImages()
        {
            // Tạo một ảnh Bitmap làm icon Camera mặc định
            Bitmap camIcon = CreateCameraPlaceholder(320, 240, "LIVE CAMERA", Color.FromArgb(0, 120, 215));
            Bitmap snapIcon = CreateCameraPlaceholder(320, 240, "SNAPSHOT", Color.Gray);

            pbCam1.Image = pbCam2.Image = pbCam3.Image = pbCam4.Image = camIcon;
            pbSnap1.Image = pbSnap2.Image = pbSnap3.Image = pbSnap4.Image = snapIcon;
        }

        private void LoadDummyData()
        {
            // Mô phỏng Làn Trái: HỢP LỆ
            gateLeft.UpdateInfo("UID-40291", "Xe Máy - Tháng", "NGUYỄN TRƯỜNG HOÀNG MINH", "51-G1-77777", "Chung cư IDT, Tân Bình", "0");
            gateLeft.SetTimes("02:15:00", "10:15:20 - 17/03", "12:30:20 - 17/03");
            gateLeft.SetMatchResult(true); // Hợp lệ
            gateLeft.SetAIPlates("51-G1\n77777", "51-G1\n77777");

            // Mô phỏng Làn Phải: SAI BIỂN SỐ
            gateRight.UpdateInfo("UID-99999", "Xe Máy - Vãng lai", "KHÁCH VÃNG LAI", "59-K1-88888", "N/A", "5.000");
            gateRight.SetTimes("00:45:00", "11:00:00 - 17/03", "11:45:00 - 17/03");
            gateRight.SetMatchResult(false); // Sai biển số
            gateRight.SetAIPlates("59-K1\n88888", "59-K1\n00000"); // AI đọc sai số cuối
        }

        private Bitmap CreateCameraPlaceholder(int width, int height, string text, Color accentColor)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.FromArgb(30, 30, 30));

                // Vẽ khung ống ngắm (Corners)
                Pen pen = new Pen(accentColor, 2);
                int s = 20; // size of corner
                g.DrawLine(pen, 10, 10, 10 + s, 10); g.DrawLine(pen, 10, 10, 10, 10 + s); // Top-Left
                g.DrawLine(pen, width - 10, 10, width - 10 - s, 10); g.DrawLine(pen, width - 10, 10, width - 10, 10 + s); // Top-Right
                g.DrawLine(pen, 10, height - 10, 10 + s, height - 10); g.DrawLine(pen, 10, height - 10, 10, height - 10 - s); // Bottom-Left
                g.DrawLine(pen, width - 10, height - 10, width - 10 - s, height - 10); g.DrawLine(pen, width - 10, height - 10, width - 10, height - 10 - s); // Bottom-Right

                // Vẽ icon Camera đơn giản
                g.FillRectangle(new SolidBrush(accentColor), width / 2 - 20, height / 2 - 15, 40, 25);
                g.FillEllipse(new SolidBrush(Color.FromArgb(30, 30, 30)), width / 2 - 8, height / 2 - 8, 16, 16);
                
                // Vẽ chữ
                Font font = new Font("Segoe UI", 9, FontStyle.Bold);
                SizeF textSize = g.MeasureString(text, font);
                g.DrawString(text, font, new SolidBrush(accentColor), (width - textSize.Width) / 2, height / 2 + 20);
            }
            return bmp;
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
                    case Keys.F11: Application.Restart(); break;
                }
            };
        }
    }
}
