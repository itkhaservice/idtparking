namespace IDTSERVER
{
    partial class ShiftHandoverForm
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
            this.pnlShiftInfo = new System.Windows.Forms.Panel();
            this.tlpShiftGrid = new System.Windows.Forms.TableLayoutPanel();
            this.lblShiftLabel = new System.Windows.Forms.Label();
            this.lblShiftVal = new System.Windows.Forms.Label();
            this.lblTimeLabel = new System.Windows.Forms.Label();
            this.lblTimeVal = new System.Windows.Forms.Label();
            this.lblHandoverLabel = new System.Windows.Forms.Label();
            this.lblHandoverVal = new System.Windows.Forms.Label();
            this.lblReceiveLabel = new System.Windows.Forms.Label();
            this.lblReceiveVal = new System.Windows.Forms.Label();
            this.pnlVehicleStats = new System.Windows.Forms.Panel();
            this.lblVehiclesContent = new System.Windows.Forms.Label();
            this.lblVehiclesTitle = new System.Windows.Forms.Label();
            this.pnlRevenue = new System.Windows.Forms.Panel();
            this.lblRevTotal = new System.Windows.Forms.Label();
            this.lblRevDetail = new System.Windows.Forms.Label();
            this.lblRevTitle = new System.Windows.Forms.Label();
            this.pnlWarnings = new System.Windows.Forms.Panel();
            this.lblWarnContent = new System.Windows.Forms.Label();
            this.lblWarnTitle = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.tlpMain.SuspendLayout();
            this.pnlShiftInfo.SuspendLayout();
            this.tlpShiftGrid.SuspendLayout();
            this.pnlVehicleStats.SuspendLayout();
            this.pnlRevenue.SuspendLayout();
            this.pnlWarnings.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlShiftInfo, 0, 0);
            this.tlpMain.Controls.Add(this.pnlVehicleStats, 0, 1);
            this.tlpMain.Controls.Add(this.pnlRevenue, 0, 2);
            this.tlpMain.Controls.Add(this.pnlWarnings, 0, 3);
            this.tlpMain.Controls.Add(this.pnlActions, 0, 4);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(15, 15);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpMain.Size = new System.Drawing.Size(550, 620);
            this.tlpMain.TabIndex = 0;
            // 
            // pnlShiftInfo
            // 
            this.pnlShiftInfo.Controls.Add(this.tlpShiftGrid);
            this.pnlShiftInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlShiftInfo.Location = new System.Drawing.Point(3, 3);
            this.pnlShiftInfo.Name = "pnlShiftInfo";
            this.pnlShiftInfo.Size = new System.Drawing.Size(544, 124);
            this.pnlShiftInfo.TabIndex = 0;
            // 
            // tlpShiftGrid
            // 
            this.tlpShiftGrid.ColumnCount = 2;
            this.tlpShiftGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpShiftGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShiftGrid.Controls.Add(this.lblShiftLabel, 0, 0);
            this.tlpShiftGrid.Controls.Add(this.lblShiftVal, 1, 0);
            this.tlpShiftGrid.Controls.Add(this.lblTimeLabel, 0, 1);
            this.tlpShiftGrid.Controls.Add(this.lblTimeVal, 1, 1);
            this.tlpShiftGrid.Controls.Add(this.lblHandoverLabel, 0, 2);
            this.tlpShiftGrid.Controls.Add(this.lblHandoverVal, 1, 2);
            this.tlpShiftGrid.Controls.Add(this.lblReceiveLabel, 0, 3);
            this.tlpShiftGrid.Controls.Add(this.lblReceiveVal, 1, 3);
            this.tlpShiftGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpShiftGrid.Location = new System.Drawing.Point(0, 0);
            this.tlpShiftGrid.Name = "tlpShiftGrid";
            this.tlpShiftGrid.RowCount = 4;
            this.tlpShiftGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpShiftGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpShiftGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpShiftGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpShiftGrid.Size = new System.Drawing.Size(544, 124);
            this.tlpShiftGrid.TabIndex = 0;
            // 
            // lblShiftLabel
            // 
            this.lblShiftLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShiftLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblShiftLabel.Location = new System.Drawing.Point(3, 0);
            this.lblShiftLabel.Name = "lblShiftLabel";
            this.lblShiftLabel.Size = new System.Drawing.Size(114, 31);
            this.lblShiftLabel.TabIndex = 0;
            this.lblShiftLabel.Text = "Ca trực:";
            this.lblShiftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShiftVal
            // 
            this.lblShiftVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShiftVal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblShiftVal.Location = new System.Drawing.Point(123, 0);
            this.lblShiftVal.Name = "lblShiftVal";
            this.lblShiftVal.Size = new System.Drawing.Size(418, 31);
            this.lblShiftVal.TabIndex = 1;
            this.lblShiftVal.Text = "Ca ngày → Ca đêm";
            this.lblShiftVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTimeLabel
            // 
            this.lblTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimeLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTimeLabel.Location = new System.Drawing.Point(3, 31);
            this.lblTimeLabel.Name = "lblTimeLabel";
            this.lblTimeLabel.Size = new System.Drawing.Size(114, 31);
            this.lblTimeLabel.TabIndex = 2;
            this.lblTimeLabel.Text = "Thời gian:";
            this.lblTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTimeVal
            // 
            this.lblTimeVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimeVal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTimeVal.Location = new System.Drawing.Point(123, 31);
            this.lblTimeVal.Name = "lblTimeVal";
            this.lblTimeVal.Size = new System.Drawing.Size(418, 31);
            this.lblTimeVal.TabIndex = 3;
            this.lblTimeVal.Text = "06:00 - 18:00";
            this.lblTimeVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHandoverLabel
            // 
            this.lblHandoverLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHandoverLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblHandoverLabel.Location = new System.Drawing.Point(3, 62);
            this.lblHandoverLabel.Name = "lblHandoverLabel";
            this.lblHandoverLabel.Size = new System.Drawing.Size(114, 31);
            this.lblHandoverLabel.TabIndex = 4;
            this.lblHandoverLabel.Text = "Bàn giao:";
            this.lblHandoverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHandoverVal
            // 
            this.lblHandoverVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHandoverVal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHandoverVal.Location = new System.Drawing.Point(123, 62);
            this.lblHandoverVal.Name = "lblHandoverVal";
            this.lblHandoverVal.Size = new System.Drawing.Size(418, 31);
            this.lblHandoverVal.TabIndex = 5;
            this.lblHandoverVal.Text = "Nguyễn Văn A";
            this.lblHandoverVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReceiveLabel
            // 
            this.lblReceiveLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReceiveLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblReceiveLabel.Location = new System.Drawing.Point(3, 93);
            this.lblReceiveLabel.Name = "lblReceiveLabel";
            this.lblReceiveLabel.Size = new System.Drawing.Size(114, 31);
            this.lblReceiveLabel.TabIndex = 6;
            this.lblReceiveLabel.Text = "Nhận ca:";
            this.lblReceiveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReceiveVal
            // 
            this.lblReceiveVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReceiveVal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblReceiveVal.Location = new System.Drawing.Point(123, 93);
            this.lblReceiveVal.Name = "lblReceiveVal";
            this.lblReceiveVal.Size = new System.Drawing.Size(418, 31);
            this.lblReceiveVal.TabIndex = 7;
            this.lblReceiveVal.Text = "Trần Văn B";
            this.lblReceiveVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlVehicleStats
            // 
            this.pnlVehicleStats.Controls.Add(this.lblVehiclesContent);
            this.pnlVehicleStats.Controls.Add(this.lblVehiclesTitle);
            this.pnlVehicleStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVehicleStats.Location = new System.Drawing.Point(3, 133);
            this.pnlVehicleStats.Name = "pnlVehicleStats";
            this.pnlVehicleStats.Size = new System.Drawing.Size(544, 144);
            this.pnlVehicleStats.TabIndex = 1;
            // 
            // lblVehiclesContent
            // 
            this.lblVehiclesContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVehiclesContent.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblVehiclesContent.Location = new System.Drawing.Point(0, 25);
            this.lblVehiclesContent.Name = "lblVehiclesContent";
            this.lblVehiclesContent.Size = new System.Drawing.Size(544, 119);
            this.lblVehiclesContent.TabIndex = 1;
            this.lblVehiclesContent.Text = "Xe vào: 120  |  Xe ra: 110  |  Trong bãi: 10\r\n\r\nXe vãng lai: 110\r\n  • Ô tô: 10\r\n " +
    " • Xe máy: 100\r\nXe tháng: 150";
            // 
            // lblVehiclesTitle
            // 
            this.lblVehiclesTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVehiclesTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVehiclesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVehiclesTitle.Location = new System.Drawing.Point(0, 0);
            this.lblVehiclesTitle.Name = "lblVehiclesTitle";
            this.lblVehiclesTitle.Size = new System.Drawing.Size(544, 25);
            this.lblVehiclesTitle.TabIndex = 0;
            this.lblVehiclesTitle.Text = "THỐNG KÊ XE";
            // 
            // pnlRevenue
            // 
            this.pnlRevenue.Controls.Add(this.lblRevDetail);
            this.pnlRevenue.Controls.Add(this.lblRevTotal);
            this.pnlRevenue.Controls.Add(this.lblRevTitle);
            this.pnlRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRevenue.Location = new System.Drawing.Point(3, 283);
            this.pnlRevenue.Name = "pnlRevenue";
            this.pnlRevenue.Size = new System.Drawing.Size(544, 114);
            this.pnlRevenue.TabIndex = 2;
            // 
            // lblRevTotal
            // 
            this.lblRevTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRevTotal.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblRevTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.lblRevTotal.Location = new System.Drawing.Point(0, 25);
            this.lblRevTotal.Name = "lblRevTotal";
            this.lblRevTotal.Size = new System.Drawing.Size(544, 45);
            this.lblRevTotal.TabIndex = 1;
            this.lblRevTotal.Text = "2,500,000 VND";
            this.lblRevTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRevDetail
            // 
            this.lblRevDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRevDetail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblRevDetail.Location = new System.Drawing.Point(0, 70);
            this.lblRevDetail.Name = "lblRevDetail";
            this.lblRevDetail.Size = new System.Drawing.Size(544, 44);
            this.lblRevDetail.TabIndex = 2;
            this.lblRevDetail.Text = "• Vãng lai ô tô: 150,000 VND  |  • Xe máy: 200,000 VND";
            // 
            // lblRevTitle
            // 
            this.lblRevTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRevTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRevTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRevTitle.Location = new System.Drawing.Point(0, 0);
            this.lblRevTitle.Name = "lblRevTitle";
            this.lblRevTitle.Size = new System.Drawing.Size(544, 25);
            this.lblRevTitle.TabIndex = 0;
            this.lblRevTitle.Text = "DOANH THU";
            // 
            // pnlWarnings
            // 
            this.pnlWarnings.Controls.Add(this.lblWarnContent);
            this.pnlWarnings.Controls.Add(this.lblWarnTitle);
            this.pnlWarnings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWarnings.Location = new System.Drawing.Point(3, 403);
            this.pnlWarnings.Name = "pnlWarnings";
            this.pnlWarnings.Size = new System.Drawing.Size(544, 144);
            this.pnlWarnings.TabIndex = 3;
            // 
            // lblWarnContent
            // 
            this.lblWarnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWarnContent.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblWarnContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.lblWarnContent.Location = new System.Drawing.Point(0, 25);
            this.lblWarnContent.Name = "lblWarnContent";
            this.lblWarnContent.Size = new System.Drawing.Size(544, 119);
            this.lblWarnContent.TabIndex = 1;
            this.lblWarnContent.Text = "• 2 Thẻ sai biển số (AI nhận diện)\r\n• 5 Thẻ bị khóa (đã quẹt vào máy)\r\n• 7 Thẻ bị" +
    " hết hạn (đã quẹt vào máy)";
            // 
            // lblWarnTitle
            // 
            this.lblWarnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWarnTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWarnTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.lblWarnTitle.Location = new System.Drawing.Point(0, 0);
            this.lblWarnTitle.Name = "lblWarnTitle";
            this.lblWarnTitle.Size = new System.Drawing.Size(544, 25);
            this.lblWarnTitle.TabIndex = 0;
            this.lblWarnTitle.Text = "⚠ CẢNH BÁO";
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnCancel);
            this.pnlActions.Controls.Add(this.btnConfirm);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActions.Location = new System.Drawing.Point(3, 553);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(544, 64);
            this.pnlActions.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(421, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy (Esc)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BorderRadius = 5;
            this.btnConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(265, 10);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(150, 45);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Đồng ý (Enter)";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // ShiftHandoverForm
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(580, 650);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShiftHandoverForm";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XÁC NHẬN BÀN GIAO CA";
            this.tlpMain.ResumeLayout(false);
            this.pnlShiftInfo.ResumeLayout(false);
            this.tlpShiftGrid.ResumeLayout(false);
            this.pnlVehicleStats.ResumeLayout(false);
            this.pnlRevenue.ResumeLayout(false);
            this.pnlWarnings.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlShiftInfo;
        private System.Windows.Forms.TableLayoutPanel tlpShiftGrid;
        private System.Windows.Forms.Label lblShiftLabel;
        private System.Windows.Forms.Label lblShiftVal;
        private System.Windows.Forms.Label lblTimeLabel;
        private System.Windows.Forms.Label lblTimeVal;
        private System.Windows.Forms.Label lblHandoverLabel;
        private System.Windows.Forms.Label lblHandoverVal;
        private System.Windows.Forms.Label lblReceiveLabel;
        private System.Windows.Forms.Label lblReceiveVal;
        private System.Windows.Forms.Panel pnlVehicleStats;
        private System.Windows.Forms.Label lblVehiclesTitle;
        private System.Windows.Forms.Label lblVehiclesContent;
        private System.Windows.Forms.Panel pnlRevenue;
        private System.Windows.Forms.Label lblRevTitle;
        private System.Windows.Forms.Label lblRevTotal;
        private System.Windows.Forms.Label lblRevDetail;
        private System.Windows.Forms.Panel pnlWarnings;
        private System.Windows.Forms.Label lblWarnTitle;
        private System.Windows.Forms.Label lblWarnContent;
        private System.Windows.Forms.Panel pnlActions;
        private Guna.UI2.WinForms.Guna2Button btnConfirm;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}
