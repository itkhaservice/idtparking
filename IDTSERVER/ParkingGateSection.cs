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
        }

        // Cập nhật thông tin thẻ xe kèm Tiêu đề và Giá trị mẫu
        public void SetCardInfo(string cardId, string vehicleType, string owner, string plate, string duration, string timeIn, string timeOut, string amount)
        {
            lblCardID.Text = $"SỐ THẺ: {cardId}";
            lblVehicleType.Text = $"LOẠI XE: {vehicleType}";
            lblOwner.Text = $"CHỦ XE: {owner}";
            lblPlate.Text = $"BIỂN SỐ: {plate}";
            lblDuration.Text = $"THỜI GIAN: {duration}";
            lblTimeEntry.Text = $"THỜI ĐIỂM VÀO: {timeIn}";
            lblTimeExit.Text = $"THỜI ĐIỂM RA: {timeOut}";
            
            // Phần thanh toán thường có nhãn riêng hoặc định dạng đặc biệt
            lblPayTitle.Text = "THANH TOÁN (PHÍ LƯỢT):";
            lblAmount.Text = amount;
        }

        public void SetAIPlates(string entryPlate, string exitPlate)
        {
            lblAIEntry.Text = entryPlate;
            lblAIExit.Text = exitPlate;
        }

        public void SetGateStatus(string status)
        {
            chipStatus.Text = status;
            if (status == "SẴN SÀNG") chipStatus.FillColor = Color.Green;
            else if (status.Contains("LỖI")) chipStatus.FillColor = Color.Red;
            else chipStatus.FillColor = Color.Orange;
        }

        public void ClearInfo()
        {
            lblCardID.Text = "SỐ THẺ: ---";
            lblVehicleType.Text = "LOẠI XE: ---";
            lblOwner.Text = "CHỦ XE: ---";
            lblPlate.Text = "BIỂN SỐ: ---";
            lblDuration.Text = "THỜI GIAN: ---";
            lblTimeEntry.Text = "THỜI ĐIỂM VÀO: ---";
            lblTimeExit.Text = "THỜI ĐIỂM RA: ---";
            lblAmount.Text = "0 VNĐ";
        }
    }
}
