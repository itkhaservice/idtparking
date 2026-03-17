using System;
using System.Drawing;
using System.Windows.Forms;

namespace IDTSERVER
{
    public partial class ParkingGateSection : UserControl
    {
        public ParkingGateSection()
        {
            InitializeComponent();
        }

        public void SetMatchResult(bool isMatch)
        {
            if (isMatch)
            {
                chipStatus.Text = "✓ HỢP LỆ";
                chipStatus.FillColor = Color.FromArgb(46, 125, 50); // Green
            }
            else
            {
                chipStatus.Text = "SAI BIỂN SỐ";
                chipStatus.FillColor = Color.FromArgb(211, 47, 47); // Red
            }
        }

        public void UpdateInfo(string card, string type, string owner, string plate, string address, string amount)
        {
            lblCardID.Text = $"SỐ THẺ: {card}";
            lblVehicleType.Text = $"LOẠI XE: {type}";
            lblOwner.Text = $"CHỦ XE: {owner}";
            lblPlate.Text = $"BIỂN SỐ: {plate}";
            lblAddress.Text = $"ĐỊA CHỈ: {address}";
            lblAmount.Text = $"{amount} VNĐ";
        }

        public void SetTimes(string duration, string entry, string exit)
        {
            lblDuration.Text = $"THỜI GIAN: {duration}";
            lblTimeEntry.Text = $"VÀO: {entry}";
            lblTimeExit.Text = $"RA: {exit}";
        }

        public void SetAIPlates(string entryPlate, string exitPlate)
        {
            lblAIEntry.Text = entryPlate;
            lblAIExit.Text = exitPlate;
        }
    }
}
