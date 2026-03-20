using System;
using System.Windows.Forms;
using System.Drawing;

namespace IDTSERVER
{
    public partial class ParkingGateSection : UserControl
    {
        public ParkingGateSection()
        {
            InitializeComponent();
            SetupUIProportions();
        }

        private void SetupUIProportions()
        {
            // Đảm bảo tất cả PictureBox dùng chế độ Zoom theo yêu cầu
            pbEntryPlate.SizeMode = PictureBoxSizeMode.Zoom;
            pbExitPlate.SizeMode = PictureBoxSizeMode.Zoom;
        }

        /// <summary>
        /// Cập nhật thông tin thẻ và xe lên giao diện
        /// </summary>
        public void SetCardInfo(string cardId, string cardType, string duration, string owner, string plate, string registration, string timeIn, string timeOut, string amount)
        {
            if (lblCardID != null) lblCardID.Text = "SỐ THẺ: " + cardId;
            if (lblVehicleType != null) lblVehicleType.Text = "LOẠI THẺ: " + cardType;
            if (lblDuration != null) lblDuration.Text = "THỜI GIAN: " + duration;
            if (lblOwner != null) lblOwner.Text = "CHỦ XE: " + owner;
            if (lblPlate != null) lblPlate.Text = "BIỂN SỐ: " + plate;
            if (lblAddress != null) lblAddress.Text = "ĐĂNG KÝ: " + registration;
            if (lblTimeEntry != null) lblTimeEntry.Text = "VÀO: " + timeIn;
            if (lblTimeExit != null) lblTimeExit.Text = "RA: " + timeOut;
            if (lblAmount != null) lblAmount.Text = amount;

            // Nếu là xe vào (không có thời gian ra), ẩn label thời gian ra và số tiền nếu cần
            bool isEntry = string.IsNullOrEmpty(timeOut) || timeOut == "---";
            lblTimeExit.Visible = !isEntry;
            lblDuration.Visible = !isEntry;
        }

        public void SetAIImages(Image imgIn, Image imgOut, string plateIn, string plateOut)
        {
            if (pbEntryPlate != null) pbEntryPlate.Image = imgIn;
            if (pbExitPlate != null) pbExitPlate.Image = imgOut;
            if (lblAIEntry != null) lblAIEntry.Text = plateIn;
            if (lblAIExit != null) lblAIExit.Text = plateOut;

            if (!string.IsNullOrEmpty(plateIn) && !string.IsNullOrEmpty(plateOut))
            {
                bool isMatch = (plateIn == plateOut);
                chipStatus.Text = isMatch ? "KHỚP BIỂN SỐ" : "KHÔNG KHỚP";
                chipStatus.FillColor = isMatch ? Color.LimeGreen : Color.Red;
                chipStatus.ForeColor = Color.White;
            }
        }

        public void SetStatus(string status, Color color)
        {
            if (chipStatus != null)
            {
                chipStatus.Text = status;
                chipStatus.FillColor = color;
                chipStatus.ForeColor = Color.White;
            }
        }

        public void ClearInfo()
        {
            if (lblCardID != null) lblCardID.Text = "SỐ THẺ: ---";
            if (lblVehicleType != null) lblVehicleType.Text = "LOẠI THẺ: ---";
            if (lblDuration != null) lblDuration.Text = "THỜI GIAN: ---";
            if (lblOwner != null) lblOwner.Text = "CHỦ XE: ---";
            if (lblPlate != null) lblPlate.Text = "BIỂN SỐ: ---";
            if (lblAddress != null) lblAddress.Text = "ĐĂNG KÝ: ---";
            if (lblTimeEntry != null) lblTimeEntry.Text = "VÀO: ---";
            if (lblTimeExit != null) lblTimeExit.Text = "RA: ---";
            if (lblAmount != null) lblAmount.Text = "0 VNĐ";
            
            if (pbEntryPlate != null) pbEntryPlate.Image = null;
            if (pbExitPlate != null) pbExitPlate.Image = null;
            if (lblAIEntry != null) lblAIEntry.Text = "---";
            if (lblAIExit != null) lblAIExit.Text = "---";
            
            SetStatus("CHỜ XE...", Color.FromArgb(180, 180, 180));
        }
    }
}
