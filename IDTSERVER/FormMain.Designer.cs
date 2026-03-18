namespace IDTSERVER
{
    partial class FormMain
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
            this.tlpLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTopCamera = new Guna.UI2.WinForms.Guna2Panel();
            this.tlpCameras = new System.Windows.Forms.TableLayoutPanel();
            this.pbCam1 = new System.Windows.Forms.PictureBox();
            this.pbCam2 = new System.Windows.Forms.PictureBox();
            this.pbCam3 = new System.Windows.Forms.PictureBox();
            this.pbCam4 = new System.Windows.Forms.PictureBox();
            this.pnlMiddleInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.tlpGates = new System.Windows.Forms.TableLayoutPanel();
            this.gateLeft = new IDTSERVER.ParkingGateSection();
            this.gateRight = new IDTSERVER.ParkingGateSection();
            this.pnlStatusStrip = new Guna.UI2.WinForms.Guna2Panel();
            this.tlpStatus = new System.Windows.Forms.TableLayoutPanel();
            this.lblStatusLeft = new System.Windows.Forms.Label();
            this.lblStatusRight = new System.Windows.Forms.Label();
            this.pnlBottomSnapshots = new Guna.UI2.WinForms.Guna2Panel();
            this.tlpSnapshots = new System.Windows.Forms.TableLayoutPanel();
            this.pbSnap1 = new System.Windows.Forms.PictureBox();
            this.pbSnap2 = new System.Windows.Forms.PictureBox();
            this.pbSnap3 = new System.Windows.Forms.PictureBox();
            this.pbSnap4 = new System.Windows.Forms.PictureBox();
            this.tlpLayout.SuspendLayout();
            this.pnlTopCamera.SuspendLayout();
            this.tlpCameras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam4)).BeginInit();
            this.pnlMiddleInfo.SuspendLayout();
            this.tlpGates.SuspendLayout();
            this.pnlStatusStrip.SuspendLayout();
            this.tlpStatus.SuspendLayout();
            this.pnlBottomSnapshots.SuspendLayout();
            this.tlpSnapshots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap4)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpLayout
            // 
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLayout.Controls.Add(this.pnlTopCamera, 0, 0);
            this.tlpLayout.Controls.Add(this.pnlMiddleInfo, 0, 1);
            this.tlpLayout.Controls.Add(this.pnlStatusStrip, 0, 2);
            this.tlpLayout.Controls.Add(this.pnlBottomSnapshots, 0, 3);
            this.tlpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpLayout.Name = "tlpLayout";
            this.tlpLayout.RowCount = 4;
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlpLayout.Size = new System.Drawing.Size(1280, 720);
            this.tlpLayout.TabIndex = 0;
            // 
            // pnlTopCamera
            // 
            this.pnlTopCamera.Controls.Add(this.tlpCameras);
            this.pnlTopCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopCamera.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlTopCamera.Location = new System.Drawing.Point(3, 3);
            this.pnlTopCamera.Name = "pnlTopCamera";
            this.pnlTopCamera.Padding = new System.Windows.Forms.Padding(5);
            this.pnlTopCamera.Size = new System.Drawing.Size(1274, 196);
            this.pnlTopCamera.TabIndex = 0;
            // 
            // tlpCameras
            // 
            this.tlpCameras.ColumnCount = 4;
            this.tlpCameras.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCameras.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCameras.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCameras.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCameras.Controls.Add(this.pbCam1, 0, 0);
            this.tlpCameras.Controls.Add(this.pbCam2, 1, 0);
            this.tlpCameras.Controls.Add(this.pbCam3, 2, 0);
            this.tlpCameras.Controls.Add(this.pbCam4, 3, 0);
            this.tlpCameras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCameras.Location = new System.Drawing.Point(5, 5);
            this.tlpCameras.Name = "tlpCameras";
            this.tlpCameras.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCameras.Size = new System.Drawing.Size(1264, 186);
            this.tlpCameras.TabIndex = 0;
            // 
            // pbCam1
            // 
            this.pbCam1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pbCam1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCam1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCam1.Location = new System.Drawing.Point(2, 2);
            this.pbCam1.Margin = new System.Windows.Forms.Padding(2);
            this.pbCam1.Name = "pbCam1";
            this.pbCam1.Size = new System.Drawing.Size(312, 182);
            this.pbCam1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCam1.TabIndex = 0;
            this.pbCam1.TabStop = false;
            // 
            // pbCam2
            // 
            this.pbCam2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pbCam2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCam2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCam2.Location = new System.Drawing.Point(318, 2);
            this.pbCam2.Margin = new System.Windows.Forms.Padding(2);
            this.pbCam2.Name = "pbCam2";
            this.pbCam2.Size = new System.Drawing.Size(312, 182);
            this.pbCam2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCam2.TabIndex = 1;
            this.pbCam2.TabStop = false;
            // 
            // pbCam3
            // 
            this.pbCam3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pbCam3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCam3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCam3.Location = new System.Drawing.Point(634, 2);
            this.pbCam3.Margin = new System.Windows.Forms.Padding(2);
            this.pbCam3.Name = "pbCam3";
            this.pbCam3.Size = new System.Drawing.Size(312, 182);
            this.pbCam3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCam3.TabIndex = 2;
            this.pbCam3.TabStop = false;
            // 
            // pbCam4
            // 
            this.pbCam4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pbCam4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCam4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCam4.Location = new System.Drawing.Point(950, 2);
            this.pbCam4.Margin = new System.Windows.Forms.Padding(2);
            this.pbCam4.Name = "pbCam4";
            this.pbCam4.Size = new System.Drawing.Size(312, 182);
            this.pbCam4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCam4.TabIndex = 3;
            this.pbCam4.TabStop = false;
            // 
            // pnlMiddleInfo
            // 
            this.pnlMiddleInfo.Controls.Add(this.tlpGates);
            this.pnlMiddleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddleInfo.FillColor = System.Drawing.Color.White;
            this.pnlMiddleInfo.Location = new System.Drawing.Point(3, 205);
            this.pnlMiddleInfo.Name = "pnlMiddleInfo";
            this.pnlMiddleInfo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pnlMiddleInfo.Size = new System.Drawing.Size(1274, 237);
            this.pnlMiddleInfo.TabIndex = 1;
            // 
            // tlpGates
            // 
            this.tlpGates.ColumnCount = 2;
            this.tlpGates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGates.Controls.Add(this.gateLeft, 0, 0);
            this.tlpGates.Controls.Add(this.gateRight, 1, 0);
            this.tlpGates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGates.Location = new System.Drawing.Point(5, 0);
            this.tlpGates.Name = "tlpGates";
            this.tlpGates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpGates.Size = new System.Drawing.Size(1264, 237);
            this.tlpGates.TabIndex = 0;
            // 
            // gateLeft
            // 
            this.gateLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gateLeft.Location = new System.Drawing.Point(3, 3);
            this.gateLeft.Name = "gateLeft";
            this.gateLeft.Size = new System.Drawing.Size(626, 231);
            this.gateLeft.TabIndex = 0;
            // 
            // gateRight
            // 
            this.gateRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gateRight.Location = new System.Drawing.Point(635, 3);
            this.gateRight.Name = "gateRight";
            this.gateRight.Size = new System.Drawing.Size(626, 231);
            this.gateRight.TabIndex = 1;
            // 
            // pnlStatusStrip
            // 
            this.pnlStatusStrip.Controls.Add(this.tlpStatus);
            this.pnlStatusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatusStrip.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlStatusStrip.Location = new System.Drawing.Point(0, 445);
            this.pnlStatusStrip.Margin = new System.Windows.Forms.Padding(0);
            this.pnlStatusStrip.Name = "pnlStatusStrip";
            this.pnlStatusStrip.Size = new System.Drawing.Size(1280, 45);
            this.pnlStatusStrip.TabIndex = 2;
            // 
            // tlpStatus
            // 
            this.tlpStatus.ColumnCount = 2;
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStatus.Controls.Add(this.lblStatusLeft, 0, 0);
            this.tlpStatus.Controls.Add(this.lblStatusRight, 1, 0);
            this.tlpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatus.Location = new System.Drawing.Point(0, 0);
            this.tlpStatus.Margin = new System.Windows.Forms.Padding(0);
            this.tlpStatus.Name = "tlpStatus";
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStatus.Size = new System.Drawing.Size(1280, 45);
            this.tlpStatus.TabIndex = 0;
            // 
            // lblStatusLeft
            // 
            this.lblStatusLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblStatusLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatusLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusLeft.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStatusLeft.ForeColor = System.Drawing.Color.White;
            this.lblStatusLeft.Location = new System.Drawing.Point(3, 0);
            this.lblStatusLeft.Name = "lblStatusLeft";
            this.lblStatusLeft.Size = new System.Drawing.Size(634, 45);
            this.lblStatusLeft.TabIndex = 0;
            this.lblStatusLeft.Text = "HỆ THỐNG SẴN SÀNG";
            this.lblStatusLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusRight
            // 
            this.lblStatusRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblStatusRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatusRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusRight.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStatusRight.ForeColor = System.Drawing.Color.White;
            this.lblStatusRight.Location = new System.Drawing.Point(643, 0);
            this.lblStatusRight.Name = "lblStatusRight";
            this.lblStatusRight.Size = new System.Drawing.Size(634, 45);
            this.lblStatusRight.TabIndex = 1;
            this.lblStatusRight.Text = "HỆ THỐNG SẴN SÀNG";
            this.lblStatusRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottomSnapshots
            // 
            this.pnlBottomSnapshots.Controls.Add(this.tlpSnapshots);
            this.pnlBottomSnapshots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottomSnapshots.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlBottomSnapshots.Location = new System.Drawing.Point(3, 493);
            this.pnlBottomSnapshots.Name = "pnlBottomSnapshots";
            this.pnlBottomSnapshots.Padding = new System.Windows.Forms.Padding(5);
            this.pnlBottomSnapshots.Size = new System.Drawing.Size(1274, 224);
            this.pnlBottomSnapshots.TabIndex = 3;
            // 
            // tlpSnapshots
            // 
            this.tlpSnapshots.ColumnCount = 4;
            this.tlpSnapshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSnapshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSnapshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSnapshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSnapshots.Controls.Add(this.pbSnap1, 0, 0);
            this.tlpSnapshots.Controls.Add(this.pbSnap2, 1, 0);
            this.tlpSnapshots.Controls.Add(this.pbSnap3, 2, 0);
            this.tlpSnapshots.Controls.Add(this.pbSnap4, 3, 0);
            this.tlpSnapshots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSnapshots.Location = new System.Drawing.Point(5, 5);
            this.tlpSnapshots.Name = "tlpSnapshots";
            this.tlpSnapshots.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSnapshots.Size = new System.Drawing.Size(1264, 214);
            this.tlpSnapshots.TabIndex = 0;
            // 
            // pbSnap1
            // 
            this.pbSnap1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pbSnap1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSnap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSnap1.Location = new System.Drawing.Point(2, 2);
            this.pbSnap1.Margin = new System.Windows.Forms.Padding(2);
            this.pbSnap1.Name = "pbSnap1";
            this.pbSnap1.Size = new System.Drawing.Size(312, 210);
            this.pbSnap1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSnap1.TabIndex = 0;
            this.pbSnap1.TabStop = false;
            // 
            // pbSnap2
            // 
            this.pbSnap2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pbSnap2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSnap2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSnap2.Location = new System.Drawing.Point(318, 2);
            this.pbSnap2.Margin = new System.Windows.Forms.Padding(2);
            this.pbSnap2.Name = "pbSnap2";
            this.pbSnap2.Size = new System.Drawing.Size(312, 210);
            this.pbSnap2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSnap2.TabIndex = 1;
            this.pbSnap2.TabStop = false;
            // 
            // pbSnap3
            // 
            this.pbSnap3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pbSnap3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSnap3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSnap3.Location = new System.Drawing.Point(634, 2);
            this.pbSnap3.Margin = new System.Windows.Forms.Padding(2);
            this.pbSnap3.Name = "pbSnap3";
            this.pbSnap3.Size = new System.Drawing.Size(312, 210);
            this.pbSnap3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSnap3.TabIndex = 2;
            this.pbSnap3.TabStop = false;
            // 
            // pbSnap4
            // 
            this.pbSnap4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pbSnap4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSnap4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSnap4.Location = new System.Drawing.Point(950, 2);
            this.pbSnap4.Margin = new System.Windows.Forms.Padding(2);
            this.pbSnap4.Name = "pbSnap4";
            this.pbSnap4.Size = new System.Drawing.Size(312, 210);
            this.pbSnap4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSnap4.TabIndex = 3;
            this.pbSnap4.TabStop = false;
            // 
            // FormMain
            // 
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.tlpLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.tlpLayout.ResumeLayout(false);
            this.pnlTopCamera.ResumeLayout(false);
            this.tlpCameras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCam1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam4)).EndInit();
            this.pnlMiddleInfo.ResumeLayout(false);
            this.tlpGates.ResumeLayout(false);
            this.pnlStatusStrip.ResumeLayout(false);
            this.tlpStatus.ResumeLayout(false);
            this.pnlBottomSnapshots.ResumeLayout(false);
            this.tlpSnapshots.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLayout;
        private Guna.UI2.WinForms.Guna2Panel pnlTopCamera;
        private System.Windows.Forms.TableLayoutPanel tlpCameras;
        private System.Windows.Forms.PictureBox pbCam1;
        private System.Windows.Forms.PictureBox pbCam2;
        private System.Windows.Forms.PictureBox pbCam3;
        private System.Windows.Forms.PictureBox pbCam4;
        private Guna.UI2.WinForms.Guna2Panel pnlMiddleInfo;
        private System.Windows.Forms.TableLayoutPanel tlpGates;
        private IDTSERVER.ParkingGateSection gateLeft;
        private IDTSERVER.ParkingGateSection gateRight;
        private Guna.UI2.WinForms.Guna2Panel pnlBottomSnapshots;
        private System.Windows.Forms.TableLayoutPanel tlpSnapshots;
        private System.Windows.Forms.PictureBox pbSnap1;
        private System.Windows.Forms.PictureBox pbSnap2;
        private System.Windows.Forms.PictureBox pbSnap3;
        private System.Windows.Forms.PictureBox pbSnap4;
        private Guna.UI2.WinForms.Guna2Panel pnlStatusStrip;
        private System.Windows.Forms.TableLayoutPanel tlpStatus;
        private System.Windows.Forms.Label lblStatusLeft;
        private System.Windows.Forms.Label lblStatusRight;
    }
}
