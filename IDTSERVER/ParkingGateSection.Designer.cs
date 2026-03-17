namespace IDTSERVER
{
    partial class ParkingGateSection
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.tlpLeftContent = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSnapshots = new System.Windows.Forms.TableLayoutPanel();
            this.pnlEntrySnap = new Guna.UI2.WinForms.Guna2Panel();
            this.pbEntryPlate = new System.Windows.Forms.PictureBox();
            this.lblEntryTitle = new System.Windows.Forms.Label();
            this.pnlExitSnap = new Guna.UI2.WinForms.Guna2Panel();
            this.pbExitPlate = new System.Windows.Forms.PictureBox();
            this.lblExitTitle = new System.Windows.Forms.Label();
            this.tlpAIResults = new System.Windows.Forms.TableLayoutPanel();
            this.lblAIEntry = new System.Windows.Forms.Label();
            this.lblAIExit = new System.Windows.Forms.Label();
            this.pnlStatus = new Guna.UI2.WinForms.Guna2Panel();
            this.chipStatus = new Guna.UI2.WinForms.Guna2Chip();
            this.pnlRight = new Guna.UI2.WinForms.Guna2Panel();
            this.tlpRightContent = new System.Windows.Forms.TableLayoutPanel();
            this.tlpInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblCardID = new System.Windows.Forms.Label();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.lblOwner = new System.Windows.Forms.Label();
            this.lblPlate = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblTimeEntry = new System.Windows.Forms.Label();
            this.lblTimeExit = new System.Windows.Forms.Label();
            this.pnlPayment = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblPayTitle = new System.Windows.Forms.Label();

            this.tlpMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.tlpLeftContent.SuspendLayout();
            this.tlpSnapshots.SuspendLayout();
            this.pnlEntrySnap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEntryPlate)).BeginInit();
            this.pnlExitSnap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExitPlate)).BeginInit();
            this.tlpAIResults.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.tlpRightContent.SuspendLayout();
            this.tlpInfo.SuspendLayout();
            this.pnlPayment.SuspendLayout();
            this.SuspendLayout();

            // tlpMain
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpMain.Controls.Add(this.pnlLeft, 0, 0);
            this.tlpMain.Controls.Add(this.pnlRight, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.Size = new System.Drawing.Size(900, 300);

            // pnlLeft
            this.pnlLeft.Controls.Add(this.tlpLeftContent);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(2);

            // tlpLeftContent
            this.tlpLeftContent.ColumnCount = 1;
            this.tlpLeftContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeftContent.Controls.Add(this.tlpSnapshots, 0, 0);
            this.tlpLeftContent.Controls.Add(this.tlpAIResults, 0, 1);
            this.tlpLeftContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeftContent.RowCount = 2;
            this.tlpLeftContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpLeftContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));

            // Snapshots AI (Midnight Style)
            this.tlpSnapshots.ColumnCount = 2;
            this.tlpSnapshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSnapshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSnapshots.Controls.Add(this.pnlEntrySnap, 0, 0);
            this.tlpSnapshots.Controls.Add(this.pnlExitSnap, 1, 0);
            this.tlpSnapshots.Dock = System.Windows.Forms.DockStyle.Fill;

            this.pnlEntrySnap.Controls.Add(this.pbEntryPlate);
            this.pnlEntrySnap.Controls.Add(this.lblEntryTitle);
            this.pnlEntrySnap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbEntryPlate.BackColor = System.Drawing.Color.FromArgb(25, 35, 45);
            this.pbEntryPlate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbEntryPlate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbEntryPlate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.lblEntryTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEntryTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblEntryTitle.Text = "ẢNH VÀO (AI)";
            this.lblEntryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEntryTitle.Height = 15;

            this.pnlExitSnap.Controls.Add(this.pbExitPlate);
            this.pnlExitSnap.Controls.Add(this.lblExitTitle);
            this.pnlExitSnap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbExitPlate.BackColor = System.Drawing.Color.FromArgb(25, 35, 45);
            this.pbExitPlate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbExitPlate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbExitPlate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.lblExitTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblExitTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblExitTitle.Text = "ẢNH RA (AI)";
            this.lblExitTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExitTitle.Height = 15;

            // AI Text Results
            this.tlpAIResults.ColumnCount = 2;
            this.tlpAIResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAIResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAIResults.Controls.Add(this.lblAIEntry, 0, 0);
            this.tlpAIResults.Controls.Add(this.lblAIExit, 1, 0);
            this.tlpAIResults.Controls.Add(this.pnlStatus, 0, 1);
            this.tlpAIResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAIResults.RowCount = 2;
            this.tlpAIResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpAIResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpAIResults.SetColumnSpan(this.pnlStatus, 2);

            this.lblAIEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAIEntry.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAIEntry.ForeColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.lblAIEntry.Text = "---";
            this.lblAIEntry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblAIExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAIExit.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAIExit.ForeColor = System.Drawing.Color.FromArgb(211, 47, 47);
            this.lblAIExit.Text = "---";
            this.lblAIExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.pnlStatus.Controls.Add(this.chipStatus);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatus.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.chipStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chipStatus.FillColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.chipStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.chipStatus.Text = "CHỜ XE...";

            // ================= RIGHT SIDE =================
            this.pnlRight.Controls.Add(this.tlpRightContent);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.pnlRight.BorderThickness = 1;
            this.pnlRight.Padding = new System.Windows.Forms.Padding(5);

            this.tlpRightContent.ColumnCount = 1;
            this.tlpRightContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRightContent.Controls.Add(this.tlpInfo, 0, 0);
            this.tlpRightContent.Controls.Add(this.pnlPayment, 0, 1);
            this.tlpRightContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRightContent.RowCount = 2;
            this.tlpRightContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpRightContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));

            this.tlpInfo.ColumnCount = 1;
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInfo.Controls.Add(this.lblCardID, 0, 0);
            this.tlpInfo.Controls.Add(this.lblVehicleType, 0, 1);
            this.tlpInfo.Controls.Add(this.lblOwner, 0, 2);
            this.tlpInfo.Controls.Add(this.lblPlate, 0, 3);
            this.tlpInfo.Controls.Add(this.lblAddress, 0, 4);
            this.tlpInfo.Controls.Add(this.lblDuration, 0, 5);
            this.tlpInfo.Controls.Add(this.lblTimeEntry, 0, 6);
            this.tlpInfo.Controls.Add(this.lblTimeExit, 0, 7);
            this.tlpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInfo.RowCount = 8;
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));

            this.lblCardID.Text = "SỐ THẺ: ---";
            this.lblVehicleType.Text = "LOẠI XE: ---";
            this.lblOwner.Text = "CHỦ XE: ---";
            this.lblPlate.Text = "BIỂN SỐ: ---";
            this.lblAddress.Text = "ĐỊA CHỈ: ---";
            this.lblDuration.Text = "THỜI GIAN: ---";
            this.lblTimeEntry.Text = "VÀO: ---";
            this.lblTimeExit.Text = "RA: ---";

            this.lblCardID.Dock = this.lblVehicleType.Dock = this.lblOwner.Dock = this.lblPlate.Dock = this.lblAddress.Dock = this.lblDuration.Dock = this.lblTimeEntry.Dock = this.lblTimeExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCardID.TextAlign = this.lblVehicleType.TextAlign = this.lblOwner.TextAlign = this.lblPlate.TextAlign = this.lblAddress.TextAlign = this.lblDuration.TextAlign = this.lblTimeEntry.TextAlign = this.lblTimeExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            this.lblCardID.Font = this.lblVehicleType.Font = this.lblDuration.Font = this.lblTimeEntry.Font = this.lblTimeExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOwner.Font = this.lblPlate.Font = this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            
            this.lblOwner.ForeColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.lblPlate.ForeColor = System.Drawing.Color.FromArgb(0, 121, 107);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(123, 31, 162);

            // Payment
            this.pnlPayment.Controls.Add(this.lblAmount);
            this.pnlPayment.Controls.Add(this.lblPayTitle);
            this.pnlPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPayment.BorderColor = System.Drawing.Color.FromArgb(245, 124, 0);
            this.pnlPayment.BorderRadius = 8;
            this.pnlPayment.BorderThickness = 2;
            this.pnlPayment.FillColor = System.Drawing.Color.FromArgb(255, 243, 224);
            this.lblAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(245, 124, 0);
            this.lblAmount.Text = "0 VNĐ";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPayTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPayTitle.Height = 25;
            this.lblPayTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPayTitle.Text = "THANH TOÁN";
            this.lblPayTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // Finalize
            this.Controls.Add(this.tlpMain);
            this.Name = "ParkingGateSection";
            this.Size = new System.Drawing.Size(900, 300);
            this.tlpMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.tlpLeftContent.ResumeLayout(false);
            this.tlpSnapshots.ResumeLayout(false);
            this.pnlEntrySnap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEntryPlate)).EndInit();
            this.pnlExitSnap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbExitPlate)).EndInit();
            this.tlpAIResults.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.tlpRightContent.ResumeLayout(false);
            this.tlpInfo.ResumeLayout(false);
            this.pnlPayment.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private Guna.UI2.WinForms.Guna2Panel pnlLeft;
        private System.Windows.Forms.TableLayoutPanel tlpLeftContent;
        private System.Windows.Forms.TableLayoutPanel tlpSnapshots;
        private Guna.UI2.WinForms.Guna2Panel pnlEntrySnap;
        private System.Windows.Forms.PictureBox pbEntryPlate;
        private System.Windows.Forms.Label lblEntryTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlExitSnap;
        private System.Windows.Forms.PictureBox pbExitPlate;
        private System.Windows.Forms.Label lblExitTitle;
        private System.Windows.Forms.TableLayoutPanel tlpAIResults;
        private System.Windows.Forms.Label lblAIEntry;
        private System.Windows.Forms.Label lblAIExit;
        private Guna.UI2.WinForms.Guna2Panel pnlStatus;
        private Guna.UI2.WinForms.Guna2Chip chipStatus;
        private Guna.UI2.WinForms.Guna2Panel pnlRight;
        private System.Windows.Forms.TableLayoutPanel tlpRightContent;
        private System.Windows.Forms.TableLayoutPanel tlpInfo;
        private System.Windows.Forms.Label lblCardID;
        private System.Windows.Forms.Label lblVehicleType;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Label lblPlate;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblTimeEntry;
        private System.Windows.Forms.Label lblTimeExit;
        private Guna.UI2.WinForms.Guna2Panel pnlPayment;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblPayTitle;
    }
}
