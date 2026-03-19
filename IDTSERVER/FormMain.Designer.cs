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
            this.pnlMiddleInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.tlpGates = new System.Windows.Forms.TableLayoutPanel();
            this.gateLeft = new IDTSERVER.ParkingGateSection();
            this.gateMiddle = new IDTSERVER.ParkingGateSection();
            this.gateRight = new IDTSERVER.ParkingGateSection();
            this.pnlStatusStrip = new Guna.UI2.WinForms.Guna2Panel();
            this.tlpStatus = new System.Windows.Forms.TableLayoutPanel();
            this.lblStatusLeft = new System.Windows.Forms.Label();
            this.lblStatusMiddle = new System.Windows.Forms.Label();
            this.lblStatusRight = new System.Windows.Forms.Label();
            this.pnlBottomSnapshots = new Guna.UI2.WinForms.Guna2Panel();
            this.tlpSnapshots = new System.Windows.Forms.TableLayoutPanel();
            this.pbCam1 = new System.Windows.Forms.PictureBox();
            this.pbCam2 = new System.Windows.Forms.PictureBox();
            this.pbCam3 = new System.Windows.Forms.PictureBox();
            this.pbCam4 = new System.Windows.Forms.PictureBox();
            this.pbCam5 = new System.Windows.Forms.PictureBox();
            this.pbCam6 = new System.Windows.Forms.PictureBox();
            this.pbSnap1 = new System.Windows.Forms.PictureBox();
            this.pbSnap2 = new System.Windows.Forms.PictureBox();
            this.pbSnap3 = new System.Windows.Forms.PictureBox();
            this.pbSnap4 = new System.Windows.Forms.PictureBox();
            this.pbSnap5 = new System.Windows.Forms.PictureBox();
            this.pbSnap6 = new System.Windows.Forms.PictureBox();
            this.tlpLayout.SuspendLayout();
            this.pnlTopCamera.SuspendLayout();
            this.tlpCameras.SuspendLayout();
            this.pnlMiddleInfo.SuspendLayout();
            this.tlpGates.SuspendLayout();
            this.pnlStatusStrip.SuspendLayout();
            this.tlpStatus.SuspendLayout();
            this.pnlBottomSnapshots.SuspendLayout();
            this.tlpSnapshots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap6)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpLayout
            // 
            this.tlpLayout.ColumnCount = 1;
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
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
            this.tlpLayout.Size = new System.Drawing.Size(1556, 884);
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
            this.pnlTopCamera.Size = new System.Drawing.Size(1550, 245);
            this.pnlTopCamera.TabIndex = 0;
            // 
            // tlpCameras
            // 
            this.tlpCameras.ColumnCount = 6;
            this.tlpCameras.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tlpCameras.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tlpCameras.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tlpCameras.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tlpCameras.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tlpCameras.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tlpCameras.Controls.Add(this.pbCam1, 0, 0);
            this.tlpCameras.Controls.Add(this.pbCam2, 1, 0);
            this.tlpCameras.Controls.Add(this.pbCam3, 2, 0);
            this.tlpCameras.Controls.Add(this.pbCam4, 3, 0);
            this.tlpCameras.Controls.Add(this.pbCam5, 4, 0);
            this.tlpCameras.Controls.Add(this.pbCam6, 5, 0);
            this.tlpCameras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCameras.Location = new System.Drawing.Point(5, 5);
            this.tlpCameras.Name = "tlpCameras";
            this.tlpCameras.RowCount = 1;
            this.tlpCameras.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCameras.Size = new System.Drawing.Size(1540, 235);
            this.tlpCameras.TabIndex = 0;
            // 
            // pnlMiddleInfo
            // 
            this.pnlMiddleInfo.Controls.Add(this.tlpGates);
            this.pnlMiddleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddleInfo.FillColor = System.Drawing.Color.White;
            this.pnlMiddleInfo.Location = new System.Drawing.Point(3, 254);
            this.pnlMiddleInfo.Name = "pnlMiddleInfo";
            this.pnlMiddleInfo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pnlMiddleInfo.Size = new System.Drawing.Size(1550, 296);
            this.pnlMiddleInfo.TabIndex = 1;
            // 
            // tlpGates
            // 
            this.tlpGates.ColumnCount = 3;
            this.tlpGates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpGates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpGates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpGates.Controls.Add(this.gateLeft, 0, 0);
            this.tlpGates.Controls.Add(this.gateMiddle, 1, 0);
            this.tlpGates.Controls.Add(this.gateRight, 2, 0);
            this.tlpGates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGates.Location = new System.Drawing.Point(5, 0);
            this.tlpGates.Name = "tlpGates";
            this.tlpGates.RowCount = 1;
            this.tlpGates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGates.Size = new System.Drawing.Size(1540, 296);
            this.tlpGates.TabIndex = 0;
            // 
            // gateLeft
            // 
            this.gateLeft.Location = new System.Drawing.Point(3, 3);
            this.gateLeft.Name = "gateLeft";
            this.gateLeft.Size = new System.Drawing.Size(507, 290);
            this.gateLeft.TabIndex = 0;
            // 
            // gateMiddle
            // 
            this.gateMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gateMiddle.Location = new System.Drawing.Point(516, 3);
            this.gateMiddle.Name = "gateMiddle";
            this.gateMiddle.Size = new System.Drawing.Size(507, 290);
            this.gateMiddle.TabIndex = 2;
            // 
            // gateRight
            // 
            this.gateRight.Location = new System.Drawing.Point(1029, 3);
            this.gateRight.Name = "gateRight";
            this.gateRight.Size = new System.Drawing.Size(508, 290);
            this.gateRight.TabIndex = 3;
            // 
            // pnlStatusStrip
            // 
            this.pnlStatusStrip.Controls.Add(this.tlpStatus);
            this.pnlStatusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatusStrip.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlStatusStrip.Location = new System.Drawing.Point(0, 553);
            this.pnlStatusStrip.Margin = new System.Windows.Forms.Padding(0);
            this.pnlStatusStrip.Name = "pnlStatusStrip";
            this.pnlStatusStrip.Size = new System.Drawing.Size(1556, 45);
            this.pnlStatusStrip.TabIndex = 2;
            // 
            // tlpStatus
            // 
            this.tlpStatus.ColumnCount = 3;
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpStatus.Controls.Add(this.lblStatusLeft, 0, 0);
            this.tlpStatus.Controls.Add(this.lblStatusMiddle, 1, 0);
            this.tlpStatus.Controls.Add(this.lblStatusRight, 2, 0);
            this.tlpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatus.Location = new System.Drawing.Point(0, 0);
            this.tlpStatus.Name = "tlpStatus";
            this.tlpStatus.RowCount = 1;
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpStatus.Size = new System.Drawing.Size(1556, 45);
            this.tlpStatus.TabIndex = 0;
            // 
            // lblStatusLeft
            // 
            this.lblStatusLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblStatusLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatusLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusLeft.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStatusLeft.ForeColor = System.Drawing.Color.White;
            this.lblStatusLeft.Location = new System.Drawing.Point(3, 0);
            this.lblStatusLeft.Name = "lblStatusLeft";
            this.lblStatusLeft.Size = new System.Drawing.Size(512, 45);
            this.lblStatusLeft.TabIndex = 2;
            this.lblStatusLeft.Text = "XIN MỜI VÀO";
            this.lblStatusLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusMiddle
            // 
            this.lblStatusMiddle.BackColor = System.Drawing.Color.Red;
            this.lblStatusMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatusMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusMiddle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStatusMiddle.ForeColor = System.Drawing.Color.White;
            this.lblStatusMiddle.Location = new System.Drawing.Point(521, 0);
            this.lblStatusMiddle.Name = "lblStatusMiddle";
            this.lblStatusMiddle.Size = new System.Drawing.Size(512, 45);
            this.lblStatusMiddle.TabIndex = 2;
            this.lblStatusMiddle.Text = "THẺ BỊ KHÓA";
            this.lblStatusMiddle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusRight
            // 
            this.lblStatusRight.BackColor = System.Drawing.Color.Blue;
            this.lblStatusRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatusRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusRight.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStatusRight.ForeColor = System.Drawing.Color.White;
            this.lblStatusRight.Location = new System.Drawing.Point(1039, 0);
            this.lblStatusRight.Name = "lblStatusRight";
            this.lblStatusRight.Size = new System.Drawing.Size(514, 45);
            this.lblStatusRight.TabIndex = 3;
            this.lblStatusRight.Text = "THẺ CHƯA RA";
            this.lblStatusRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottomSnapshots
            // 
            this.pnlBottomSnapshots.Controls.Add(this.tlpSnapshots);
            this.pnlBottomSnapshots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottomSnapshots.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlBottomSnapshots.Location = new System.Drawing.Point(3, 601);
            this.pnlBottomSnapshots.Name = "pnlBottomSnapshots";
            this.pnlBottomSnapshots.Padding = new System.Windows.Forms.Padding(5);
            this.pnlBottomSnapshots.Size = new System.Drawing.Size(1550, 280);
            this.pnlBottomSnapshots.TabIndex = 3;
            // 
            // tlpSnapshots
            // 
            this.tlpSnapshots.ColumnCount = 6;
            this.tlpSnapshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tlpSnapshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tlpSnapshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tlpSnapshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tlpSnapshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tlpSnapshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tlpSnapshots.Controls.Add(this.pbSnap1, 0, 0);
            this.tlpSnapshots.Controls.Add(this.pbSnap2, 1, 0);
            this.tlpSnapshots.Controls.Add(this.pbSnap3, 2, 0);
            this.tlpSnapshots.Controls.Add(this.pbSnap4, 3, 0);
            this.tlpSnapshots.Controls.Add(this.pbSnap5, 4, 0);
            this.tlpSnapshots.Controls.Add(this.pbSnap6, 5, 0);
            this.tlpSnapshots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSnapshots.Location = new System.Drawing.Point(5, 5);
            this.tlpSnapshots.Name = "tlpSnapshots";
            this.tlpSnapshots.RowCount = 1;
            this.tlpSnapshots.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSnapshots.Size = new System.Drawing.Size(1540, 270);
            this.tlpSnapshots.TabIndex = 0;
            // 
            // pbCam1
            // 
            this.pbCam1.BackColor = System.Drawing.Color.White;
            this.pbCam1.BackgroundImage = global::IDTSERVER.Properties.Resources.camera;
            this.pbCam1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbCam1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCam1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCam1.Location = new System.Drawing.Point(2, 2);
            this.pbCam1.Margin = new System.Windows.Forms.Padding(2);
            this.pbCam1.Name = "pbCam1";
            this.pbCam1.Size = new System.Drawing.Size(252, 231);
            this.pbCam1.TabIndex = 0;
            this.pbCam1.TabStop = false;
            // 
            // pbCam2
            // 
            this.pbCam2.BackColor = System.Drawing.Color.White;
            this.pbCam2.BackgroundImage = global::IDTSERVER.Properties.Resources.camera;
            this.pbCam2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbCam2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCam2.Location = new System.Drawing.Point(259, 3);
            this.pbCam2.Name = "pbCam2";
            this.pbCam2.Size = new System.Drawing.Size(250, 229);
            this.pbCam2.TabIndex = 1;
            this.pbCam2.TabStop = false;
            // 
            // pbCam3
            // 
            this.pbCam3.BackColor = System.Drawing.Color.White;
            this.pbCam3.BackgroundImage = global::IDTSERVER.Properties.Resources.camera;
            this.pbCam3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbCam3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCam3.Location = new System.Drawing.Point(515, 3);
            this.pbCam3.Name = "pbCam3";
            this.pbCam3.Size = new System.Drawing.Size(250, 229);
            this.pbCam3.TabIndex = 2;
            this.pbCam3.TabStop = false;
            // 
            // pbCam4
            // 
            this.pbCam4.BackColor = System.Drawing.Color.White;
            this.pbCam4.BackgroundImage = global::IDTSERVER.Properties.Resources.camera;
            this.pbCam4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbCam4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCam4.Location = new System.Drawing.Point(771, 3);
            this.pbCam4.Name = "pbCam4";
            this.pbCam4.Size = new System.Drawing.Size(250, 229);
            this.pbCam4.TabIndex = 3;
            this.pbCam4.TabStop = false;
            // 
            // pbCam5
            // 
            this.pbCam5.BackColor = System.Drawing.Color.White;
            this.pbCam5.BackgroundImage = global::IDTSERVER.Properties.Resources.camera;
            this.pbCam5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbCam5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCam5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCam5.Location = new System.Drawing.Point(1026, 2);
            this.pbCam5.Margin = new System.Windows.Forms.Padding(2);
            this.pbCam5.Name = "pbCam5";
            this.pbCam5.Size = new System.Drawing.Size(252, 231);
            this.pbCam5.TabIndex = 4;
            this.pbCam5.TabStop = false;
            // 
            // pbCam6
            // 
            this.pbCam6.BackColor = System.Drawing.Color.White;
            this.pbCam6.BackgroundImage = global::IDTSERVER.Properties.Resources.camera;
            this.pbCam6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbCam6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCam6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCam6.Location = new System.Drawing.Point(1282, 2);
            this.pbCam6.Margin = new System.Windows.Forms.Padding(2);
            this.pbCam6.Name = "pbCam6";
            this.pbCam6.Size = new System.Drawing.Size(256, 231);
            this.pbCam6.TabIndex = 5;
            this.pbCam6.TabStop = false;
            // 
            // pbSnap1
            // 
            this.pbSnap1.BackColor = System.Drawing.Color.White;
            this.pbSnap1.BackgroundImage = global::IDTSERVER.Properties.Resources.image;
            this.pbSnap1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSnap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSnap1.Location = new System.Drawing.Point(3, 3);
            this.pbSnap1.Name = "pbSnap1";
            this.pbSnap1.Size = new System.Drawing.Size(250, 264);
            this.pbSnap1.TabIndex = 0;
            this.pbSnap1.TabStop = false;
            // 
            // pbSnap2
            // 
            this.pbSnap2.BackColor = System.Drawing.Color.White;
            this.pbSnap2.BackgroundImage = global::IDTSERVER.Properties.Resources.image;
            this.pbSnap2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSnap2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSnap2.Location = new System.Drawing.Point(259, 3);
            this.pbSnap2.Name = "pbSnap2";
            this.pbSnap2.Size = new System.Drawing.Size(250, 264);
            this.pbSnap2.TabIndex = 1;
            this.pbSnap2.TabStop = false;
            // 
            // pbSnap3
            // 
            this.pbSnap3.BackColor = System.Drawing.Color.White;
            this.pbSnap3.BackgroundImage = global::IDTSERVER.Properties.Resources.image;
            this.pbSnap3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSnap3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSnap3.Location = new System.Drawing.Point(515, 3);
            this.pbSnap3.Name = "pbSnap3";
            this.pbSnap3.Size = new System.Drawing.Size(250, 264);
            this.pbSnap3.TabIndex = 2;
            this.pbSnap3.TabStop = false;
            // 
            // pbSnap4
            // 
            this.pbSnap4.BackColor = System.Drawing.Color.White;
            this.pbSnap4.BackgroundImage = global::IDTSERVER.Properties.Resources.image;
            this.pbSnap4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSnap4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSnap4.Location = new System.Drawing.Point(771, 3);
            this.pbSnap4.Name = "pbSnap4";
            this.pbSnap4.Size = new System.Drawing.Size(250, 264);
            this.pbSnap4.TabIndex = 3;
            this.pbSnap4.TabStop = false;
            // 
            // pbSnap5
            // 
            this.pbSnap5.BackColor = System.Drawing.Color.White;
            this.pbSnap5.BackgroundImage = global::IDTSERVER.Properties.Resources.image;
            this.pbSnap5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSnap5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSnap5.Location = new System.Drawing.Point(1027, 3);
            this.pbSnap5.Name = "pbSnap5";
            this.pbSnap5.Size = new System.Drawing.Size(250, 264);
            this.pbSnap5.TabIndex = 4;
            this.pbSnap5.TabStop = false;
            // 
            // pbSnap6
            // 
            this.pbSnap6.BackColor = System.Drawing.Color.White;
            this.pbSnap6.BackgroundImage = global::IDTSERVER.Properties.Resources.image;
            this.pbSnap6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSnap6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSnap6.Location = new System.Drawing.Point(1283, 3);
            this.pbSnap6.Name = "pbSnap6";
            this.pbSnap6.Size = new System.Drawing.Size(254, 264);
            this.pbSnap6.TabIndex = 5;
            this.pbSnap6.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 884);
            this.Controls.Add(this.tlpLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.tlpLayout.ResumeLayout(false);
            this.pnlTopCamera.ResumeLayout(false);
            this.tlpCameras.ResumeLayout(false);
            this.pnlMiddleInfo.ResumeLayout(false);
            this.tlpGates.ResumeLayout(false);
            this.pnlStatusStrip.ResumeLayout(false);
            this.tlpStatus.ResumeLayout(false);
            this.pnlBottomSnapshots.ResumeLayout(false);
            this.tlpSnapshots.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCam1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap6)).EndInit();
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
        private System.Windows.Forms.PictureBox pbCam5; // Mới
        private System.Windows.Forms.PictureBox pbCam6; // Mới
        private Guna.UI2.WinForms.Guna2Panel pnlMiddleInfo;
        private System.Windows.Forms.TableLayoutPanel tlpGates;
        private IDTSERVER.ParkingGateSection gateLeft;
        private IDTSERVER.ParkingGateSection gateMiddle; // Mới
        private IDTSERVER.ParkingGateSection gateRight;
        private Guna.UI2.WinForms.Guna2Panel pnlStatusStrip;
        private System.Windows.Forms.TableLayoutPanel tlpStatus;
        private System.Windows.Forms.Label lblStatusLeft;
        private System.Windows.Forms.Label lblStatusMiddle; // Mới
        private System.Windows.Forms.Label lblStatusRight;
        private Guna.UI2.WinForms.Guna2Panel pnlBottomSnapshots;
        private System.Windows.Forms.TableLayoutPanel tlpSnapshots;
        private System.Windows.Forms.PictureBox pbSnap1;
        private System.Windows.Forms.PictureBox pbSnap2;
        private System.Windows.Forms.PictureBox pbSnap3;
        private System.Windows.Forms.PictureBox pbSnap4;
        private System.Windows.Forms.PictureBox pbSnap5; // Mới
        private System.Windows.Forms.PictureBox pbSnap6; // Mới
    }
}