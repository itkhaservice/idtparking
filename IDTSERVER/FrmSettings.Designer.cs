namespace IDTSERVER
{
    partial class FrmSettings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabHeThong = new System.Windows.Forms.TabPage();
            this.pnlHeThongContent = new System.Windows.Forms.Panel();
            this.grpOptions = new Guna.UI2.WinForms.Guna2GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkFastScan = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkSyncData = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkAutoReconnect = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkAutoPrint = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkOnlineImage = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkShowCamerasOnMain = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkShowRevenue = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkVoiceMoney = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkVoiceWarning = new Guna.UI2.WinForms.Guna2CheckBox();
            this.grpPath = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtBackupPath = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtURLServer = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLocalPath = new Guna.UI2.WinForms.Guna2TextBox();
            this.grpDatabase = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblDBStatus = new System.Windows.Forms.Label();
            this.btnTestDB = new Guna.UI2.WinForms.Guna2Button();
            this.txtDBName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.grpServer = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.btnTestServer = new Guna.UI2.WinForms.Guna2Button();
            this.txtPort = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtServerLocal = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtServerName = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlBottomSystem = new System.Windows.Forms.Panel();
            this.btnGuideSystem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveSystem = new Guna.UI2.WinForms.Guna2Button();
            this.tabThietBi = new System.Windows.Forms.TabPage();
            this.pnlThietBiContent = new System.Windows.Forms.Panel();
            this.pnlIPConfig = new System.Windows.Forms.FlowLayoutPanel();
            this.grpIpL1P = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnPreviewIpL1P = new Guna.UI2.WinForms.Guna2Button();
            this.txtIpL1P_Rtsp = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIpL1P_Pass = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIpL1P_User = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIpL1P_Host = new Guna.UI2.WinForms.Guna2TextBox();
            this.grpIpL1F = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnPreviewIpL1F = new Guna.UI2.WinForms.Guna2Button();
            this.txtIpL1F_Rtsp = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIpL1F_Pass = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIpL1F_User = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIpL1F_Host = new Guna.UI2.WinForms.Guna2TextBox();
            this.grpIpL2P = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnPreviewIpL2P = new Guna.UI2.WinForms.Guna2Button();
            this.txtIpL2P_Rtsp = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIpL2P_Pass = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIpL2P_User = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIpL2P_Host = new Guna.UI2.WinForms.Guna2TextBox();
            this.grpIpL2F = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnPreviewIpL2F = new Guna.UI2.WinForms.Guna2Button();
            this.txtIpL2F_Rtsp = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIpL2F_Pass = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIpL2F_User = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIpL2F_Host = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlAnalogConfig = new System.Windows.Forms.Panel();
            this.grpAnalogChannels = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnPreviewAnL2F = new Guna.UI2.WinForms.Guna2Button();
            this.btnPreviewAnL2P = new Guna.UI2.WinForms.Guna2Button();
            this.btnPreviewAnL1F = new Guna.UI2.WinForms.Guna2Button();
            this.btnPreviewAnL1P = new Guna.UI2.WinForms.Guna2Button();
            this.numChL2F = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.numChL2P = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.numChL1F = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.numChL1P = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpDvrInfo = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtDvrPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDvrUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDvrPort = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDvrHost = new Guna.UI2.WinForms.Guna2TextBox();
            this.grpLaneConfig = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtLane2Com = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLane1Com = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboLane2Dir = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboLane1Dir = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblL2 = new System.Windows.Forms.Label();
            this.lblL1 = new System.Windows.Forms.Label();
            this.pnlThietBiTop = new System.Windows.Forms.Panel();
            this.grpCameraType = new Guna.UI2.WinForms.Guna2GroupBox();
            this.rdoAnalogCamera = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rdoIPCamera = new Guna.UI2.WinForms.Guna2RadioButton();
            this.grpDisplayOptions = new Guna.UI2.WinForms.Guna2GroupBox();
            this.chkShowCamerasOnMain = new Guna.UI2.WinForms.Guna2CheckBox();
            this.pnlThietBiBottom = new System.Windows.Forms.Panel();
            this.btnGuideDevice = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveDevice = new Guna.UI2.WinForms.Guna2Button();
            this.tabLoaiThe = new System.Windows.Forms.TabPage();
            this.dgvCardType = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlCardTypeTools = new System.Windows.Forms.Panel();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.pnlLoaiTheBottom = new System.Windows.Forms.Panel();
            this.btnGuideCardType = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveCardType = new Guna.UI2.WinForms.Guna2Button();
            this.tabGiaTien = new System.Windows.Forms.TabPage();
            this.lblGiaTienDev = new System.Windows.Forms.Label();
            this.tabNangCao = new System.Windows.Forms.TabPage();
            this.lblNangCaoDev = new System.Windows.Forms.Label();
            this.guna2TabControl1.SuspendLayout();
            this.tabHeThong.SuspendLayout();
            this.pnlHeThongContent.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.grpPath.SuspendLayout();
            this.grpDatabase.SuspendLayout();
            this.grpServer.SuspendLayout();
            this.pnlBottomSystem.SuspendLayout();
            this.tabThietBi.SuspendLayout();
            this.pnlThietBiContent.SuspendLayout();
            this.pnlIPConfig.SuspendLayout();
            this.grpIpL1P.SuspendLayout();
            this.grpIpL1F.SuspendLayout();
            this.grpIpL2P.SuspendLayout();
            this.grpIpL2F.SuspendLayout();
            this.pnlAnalogConfig.SuspendLayout();
            this.grpAnalogChannels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChL2F)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChL2P)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChL1F)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChL1P)).BeginInit();
            this.grpDvrInfo.SuspendLayout();
            this.grpLaneConfig.SuspendLayout();
            this.pnlThietBiTop.SuspendLayout();
            this.grpCameraType.SuspendLayout();
            this.pnlThietBiBottom.SuspendLayout();
            this.tabLoaiThe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardType)).BeginInit();
            this.pnlCardTypeTools.SuspendLayout();
            this.pnlLoaiTheBottom.SuspendLayout();
            this.tabGiaTien.SuspendLayout();
            this.tabNangCao.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.guna2TabControl1.Controls.Add(this.tabHeThong);
            this.guna2TabControl1.Controls.Add(this.tabThietBi);
            this.guna2TabControl1.Controls.Add(this.tabLoaiThe);
            this.guna2TabControl1.Controls.Add(this.tabGiaTien);
            this.guna2TabControl1.Controls.Add(this.tabNangCao);
            this.guna2TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(180, 50);
            this.guna2TabControl1.Location = new System.Drawing.Point(0, 0);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(950, 650);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(180, 50);
            this.guna2TabControl1.TabIndex = 0;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            // 
            // tabHeThong
            // 
            this.tabHeThong.Controls.Add(this.pnlHeThongContent);
            this.tabHeThong.Controls.Add(this.pnlBottomSystem);
            this.tabHeThong.Location = new System.Drawing.Point(184, 4);
            this.tabHeThong.Name = "tabHeThong";
            this.tabHeThong.Padding = new System.Windows.Forms.Padding(15);
            this.tabHeThong.Size = new System.Drawing.Size(762, 642);
            this.tabHeThong.TabIndex = 0;
            this.tabHeThong.Text = "HỆ THỐNG";
            this.tabHeThong.UseVisualStyleBackColor = true;
            // 
            // pnlHeThongContent
            // 
            this.pnlHeThongContent.AutoScroll = true;
            this.pnlHeThongContent.Controls.Add(this.grpOptions);
            this.pnlHeThongContent.Controls.Add(this.grpPath);
            this.pnlHeThongContent.Controls.Add(this.grpDatabase);
            this.pnlHeThongContent.Controls.Add(this.grpServer);
            this.pnlHeThongContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeThongContent.Location = new System.Drawing.Point(15, 15);
            this.pnlHeThongContent.Name = "pnlHeThongContent";
            this.pnlHeThongContent.Size = new System.Drawing.Size(732, 562);
            this.pnlHeThongContent.TabIndex = 0;
            // 
            // grpOptions
            // 
            this.grpOptions.BorderRadius = 5;
            this.grpOptions.Controls.Add(this.flowLayoutPanel1);
            this.grpOptions.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.grpOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpOptions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpOptions.ForeColor = System.Drawing.Color.White;
            this.grpOptions.Location = new System.Drawing.Point(0, 510);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(732, 130);
            this.grpOptions.TabIndex = 3;
            this.grpOptions.Text = "TÙY CHỌN HỆ THỐNG";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.chkFastScan);
            this.flowLayoutPanel1.Controls.Add(this.chkSyncData);
            this.flowLayoutPanel1.Controls.Add(this.chkAutoReconnect);
            this.flowLayoutPanel1.Controls.Add(this.chkAutoPrint);
            this.flowLayoutPanel1.Controls.Add(this.chkOnlineImage);
            this.flowLayoutPanel1.Controls.Add(this.chkShowCamerasOnMain);
            this.flowLayoutPanel1.Controls.Add(this.chkShowRevenue);
            this.flowLayoutPanel1.Controls.Add(this.chkVoiceMoney);
            this.flowLayoutPanel1.Controls.Add(this.chkVoiceWarning);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(732, 90);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // chkFastScan
            // 
            this.chkFastScan.AutoSize = true;
            this.chkFastScan.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkFastScan.CheckedState.BorderRadius = 2;
            this.chkFastScan.CheckedState.BorderThickness = 0;
            this.chkFastScan.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkFastScan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkFastScan.ForeColor = System.Drawing.Color.Black;
            this.chkFastScan.Location = new System.Drawing.Point(13, 13);
            this.chkFastScan.Name = "chkFastScan";
            this.chkFastScan.Padding = new System.Windows.Forms.Padding(0, 0, 20, 10);
            this.chkFastScan.Size = new System.Drawing.Size(109, 29);
            this.chkFastScan.TabIndex = 0;
            this.chkFastScan.Text = "Quẹt nhanh";
            this.chkFastScan.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkFastScan.UncheckedState.BorderRadius = 2;
            this.chkFastScan.UncheckedState.BorderThickness = 0;
            this.chkFastScan.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkSyncData
            // 
            this.chkSyncData.AutoSize = true;
            this.chkSyncData.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkSyncData.CheckedState.BorderRadius = 2;
            this.chkSyncData.CheckedState.BorderThickness = 0;
            this.chkSyncData.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkSyncData.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkSyncData.ForeColor = System.Drawing.Color.Black;
            this.chkSyncData.Location = new System.Drawing.Point(128, 13);
            this.chkSyncData.Name = "chkSyncData";
            this.chkSyncData.Padding = new System.Windows.Forms.Padding(0, 0, 20, 10);
            this.chkSyncData.Size = new System.Drawing.Size(131, 29);
            this.chkSyncData.TabIndex = 1;
            this.chkSyncData.Text = "Đồng bộ dữ liệu";
            this.chkSyncData.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkSyncData.UncheckedState.BorderRadius = 2;
            this.chkSyncData.UncheckedState.BorderThickness = 0;
            this.chkSyncData.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkAutoReconnect
            // 
            this.chkAutoReconnect.AutoSize = true;
            this.chkAutoReconnect.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkAutoReconnect.CheckedState.BorderRadius = 2;
            this.chkAutoReconnect.CheckedState.BorderThickness = 0;
            this.chkAutoReconnect.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkAutoReconnect.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkAutoReconnect.ForeColor = System.Drawing.Color.Black;
            this.chkAutoReconnect.Location = new System.Drawing.Point(265, 13);
            this.chkAutoReconnect.Name = "chkAutoReconnect";
            this.chkAutoReconnect.Padding = new System.Windows.Forms.Padding(0, 0, 20, 10);
            this.chkAutoReconnect.Size = new System.Drawing.Size(116, 29);
            this.chkAutoReconnect.TabIndex = 2;
            this.chkAutoReconnect.Text = "Tự kết nối lại";
            this.chkAutoReconnect.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkAutoReconnect.UncheckedState.BorderRadius = 2;
            this.chkAutoReconnect.UncheckedState.BorderThickness = 0;
            this.chkAutoReconnect.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkAutoPrint
            // 
            this.chkAutoPrint.AutoSize = true;
            this.chkAutoPrint.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkAutoPrint.CheckedState.BorderRadius = 2;
            this.chkAutoPrint.CheckedState.BorderThickness = 0;
            this.chkAutoPrint.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkAutoPrint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkAutoPrint.ForeColor = System.Drawing.Color.Black;
            this.chkAutoPrint.Location = new System.Drawing.Point(387, 13);
            this.chkAutoPrint.Name = "chkAutoPrint";
            this.chkAutoPrint.Padding = new System.Windows.Forms.Padding(0, 0, 20, 10);
            this.chkAutoPrint.Size = new System.Drawing.Size(104, 29);
            this.chkAutoPrint.TabIndex = 3;
            this.chkAutoPrint.Text = "Tự động in";
            this.chkAutoPrint.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkAutoPrint.UncheckedState.BorderRadius = 2;
            this.chkAutoPrint.UncheckedState.BorderThickness = 0;
            this.chkAutoPrint.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkOnlineImage
            // 
            this.chkOnlineImage.AutoSize = true;
            this.chkOnlineImage.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkOnlineImage.CheckedState.BorderRadius = 2;
            this.chkOnlineImage.CheckedState.BorderThickness = 0;
            this.chkOnlineImage.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkOnlineImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkOnlineImage.ForeColor = System.Drawing.Color.Black;
            this.chkOnlineImage.Location = new System.Drawing.Point(497, 13);
            this.chkOnlineImage.Name = "chkOnlineImage";
            this.chkOnlineImage.Padding = new System.Windows.Forms.Padding(0, 0, 20, 10);
            this.chkOnlineImage.Size = new System.Drawing.Size(123, 29);
            this.chkOnlineImage.TabIndex = 4;
            this.chkOnlineImage.Text = "Ảnh trực tuyến";
            this.chkOnlineImage.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkOnlineImage.UncheckedState.BorderRadius = 2;
            this.chkOnlineImage.UncheckedState.BorderThickness = 0;
            this.chkOnlineImage.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkShowRevenue
            // 
            this.chkShowRevenue.AutoSize = true;
            this.chkShowRevenue.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkShowRevenue.CheckedState.BorderRadius = 2;
            this.chkShowRevenue.CheckedState.BorderThickness = 0;
            this.chkShowRevenue.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkShowRevenue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkShowRevenue.ForeColor = System.Drawing.Color.Black;
            this.chkShowRevenue.Location = new System.Drawing.Point(13, 48);
            this.chkShowRevenue.Name = "chkShowRevenue";
            this.chkShowRevenue.Padding = new System.Windows.Forms.Padding(0, 0, 20, 10);
            this.chkShowRevenue.Size = new System.Drawing.Size(128, 29);
            this.chkShowRevenue.TabIndex = 5;
            this.chkShowRevenue.Text = "Hiện doanh thu";
            this.chkShowRevenue.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkShowRevenue.UncheckedState.BorderRadius = 2;
            this.chkShowRevenue.UncheckedState.BorderThickness = 0;
            this.chkShowRevenue.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkVoiceMoney
            // 
            this.chkVoiceMoney.AutoSize = true;
            this.chkVoiceMoney.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkVoiceMoney.CheckedState.BorderRadius = 2;
            this.chkVoiceMoney.CheckedState.BorderThickness = 0;
            this.chkVoiceMoney.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkVoiceMoney.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkVoiceMoney.ForeColor = System.Drawing.Color.Black;
            this.chkVoiceMoney.Location = new System.Drawing.Point(147, 48);
            this.chkVoiceMoney.Name = "chkVoiceMoney";
            this.chkVoiceMoney.Padding = new System.Windows.Forms.Padding(0, 0, 20, 10);
            this.chkVoiceMoney.Size = new System.Drawing.Size(107, 29);
            this.chkVoiceMoney.TabIndex = 6;
            this.chkVoiceMoney.Text = "Đọc số tiền";
            this.chkVoiceMoney.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkVoiceMoney.UncheckedState.BorderRadius = 2;
            this.chkVoiceMoney.UncheckedState.BorderThickness = 0;
            this.chkVoiceMoney.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkVoiceWarning
            // 
            this.chkVoiceWarning.AutoSize = true;
            this.chkVoiceWarning.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkVoiceWarning.CheckedState.BorderRadius = 2;
            this.chkVoiceWarning.CheckedState.BorderThickness = 0;
            this.chkVoiceWarning.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkVoiceWarning.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkVoiceWarning.ForeColor = System.Drawing.Color.Black;
            this.chkVoiceWarning.Location = new System.Drawing.Point(260, 48);
            this.chkVoiceWarning.Name = "chkVoiceWarning";
            this.chkVoiceWarning.Padding = new System.Windows.Forms.Padding(0, 0, 20, 10);
            this.chkVoiceWarning.Size = new System.Drawing.Size(121, 29);
            this.chkVoiceWarning.TabIndex = 7;
            this.chkVoiceWarning.Text = "Đọc cảnh báo";
            this.chkVoiceWarning.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkVoiceWarning.UncheckedState.BorderRadius = 2;
            this.chkVoiceWarning.UncheckedState.BorderThickness = 0;
            this.chkVoiceWarning.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // grpPath
            // 
            this.grpPath.BorderRadius = 5;
            this.grpPath.Controls.Add(this.txtBackupPath);
            this.grpPath.Controls.Add(this.txtURLServer);
            this.grpPath.Controls.Add(this.txtLocalPath);
            this.grpPath.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.grpPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPath.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpPath.ForeColor = System.Drawing.Color.White;
            this.grpPath.Location = new System.Drawing.Point(0, 340);
            this.grpPath.Name = "grpPath";
            this.grpPath.Size = new System.Drawing.Size(732, 170);
            this.grpPath.TabIndex = 2;
            this.grpPath.Text = "ĐƯỜNG DẪN HỆ THỐNG";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.BorderRadius = 5;
            this.txtBackupPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBackupPath.DefaultText = "";
            this.txtBackupPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBackupPath.Location = new System.Drawing.Point(15, 115);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.PlaceholderText = "Backup Path (D:\\Backup)";
            this.txtBackupPath.Size = new System.Drawing.Size(615, 36);
            this.txtBackupPath.TabIndex = 2;
            // 
            // txtURLServer
            // 
            this.txtURLServer.BorderRadius = 5;
            this.txtURLServer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtURLServer.DefaultText = "";
            this.txtURLServer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtURLServer.Location = new System.Drawing.Point(330, 55);
            this.txtURLServer.Name = "txtURLServer";
            this.txtURLServer.PlaceholderText = "URL Server (http://...)";
            this.txtURLServer.Size = new System.Drawing.Size(300, 36);
            this.txtURLServer.TabIndex = 1;
            // 
            // txtLocalPath
            // 
            this.txtLocalPath.BorderRadius = 5;
            this.txtLocalPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLocalPath.DefaultText = "";
            this.txtLocalPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLocalPath.Location = new System.Drawing.Point(15, 55);
            this.txtLocalPath.Name = "txtLocalPath";
            this.txtLocalPath.PlaceholderText = "Local Path (C:\\Data)";
            this.txtLocalPath.Size = new System.Drawing.Size(300, 36);
            this.txtLocalPath.TabIndex = 0;
            // 
            // grpDatabase
            // 
            this.grpDatabase.BorderRadius = 5;
            this.grpDatabase.Controls.Add(this.lblDBStatus);
            this.grpDatabase.Controls.Add(this.btnTestDB);
            this.grpDatabase.Controls.Add(this.txtDBName);
            this.grpDatabase.Controls.Add(this.txtPassword);
            this.grpDatabase.Controls.Add(this.txtUsername);
            this.grpDatabase.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.grpDatabase.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDatabase.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDatabase.ForeColor = System.Drawing.Color.White;
            this.grpDatabase.Location = new System.Drawing.Point(0, 170);
            this.grpDatabase.Name = "grpDatabase";
            this.grpDatabase.Size = new System.Drawing.Size(732, 170);
            this.grpDatabase.TabIndex = 1;
            this.grpDatabase.Text = "CƠ SỞ DỮ LIỆU";
            // 
            // lblDBStatus
            // 
            this.lblDBStatus.AutoSize = true;
            this.lblDBStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDBStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblDBStatus.Location = new System.Drawing.Point(460, 115);
            this.lblDBStatus.Name = "lblDBStatus";
            this.lblDBStatus.Size = new System.Drawing.Size(84, 15);
            this.lblDBStatus.TabIndex = 4;
            this.lblDBStatus.Text = "Chưa kiểm tra...";
            // 
            // btnTestDB
            // 
            this.btnTestDB.BorderRadius = 5;
            this.btnTestDB.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.btnTestDB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTestDB.ForeColor = System.Drawing.Color.White;
            this.btnTestDB.Location = new System.Drawing.Point(330, 105);
            this.btnTestDB.Name = "btnTestDB";
            this.btnTestDB.Size = new System.Drawing.Size(120, 36);
            this.btnTestDB.TabIndex = 3;
            this.btnTestDB.Text = "KIỂM TRA";
            this.btnTestDB.Click += new System.EventHandler(this.btnTestDB_Click);
            // 
            // txtDBName
            // 
            this.txtDBName.BorderRadius = 5;
            this.txtDBName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDBName.DefaultText = "";
            this.txtDBName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDBName.Location = new System.Drawing.Point(15, 105);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.PlaceholderText = "Database Name";
            this.txtDBName.Size = new System.Drawing.Size(300, 36);
            this.txtDBName.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderRadius = 5;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.IconRightOffset = new System.Drawing.Point(5, 0);
            this.txtPassword.IconRightSize = new System.Drawing.Size(20, 20);
            this.txtPassword.Location = new System.Drawing.Point(330, 55);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.Size = new System.Drawing.Size(300, 36);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.IconRightClick += new System.EventHandler(this.txtPassword_IconRightClick);
            // 
            // txtUsername
            // 
            this.txtUsername.BorderRadius = 5;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsername.Location = new System.Drawing.Point(15, 55);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderText = "Username (sa)";
            this.txtUsername.Size = new System.Drawing.Size(300, 36);
            this.txtUsername.TabIndex = 0;
            // 
            // grpServer
            // 
            this.grpServer.BorderRadius = 5;
            this.grpServer.Controls.Add(this.lblServerStatus);
            this.grpServer.Controls.Add(this.btnTestServer);
            this.grpServer.Controls.Add(this.txtPort);
            this.grpServer.Controls.Add(this.txtServerLocal);
            this.grpServer.Controls.Add(this.txtServerName);
            this.grpServer.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.grpServer.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpServer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpServer.ForeColor = System.Drawing.Color.White;
            this.grpServer.Location = new System.Drawing.Point(0, 0);
            this.grpServer.Name = "grpServer";
            this.grpServer.Size = new System.Drawing.Size(732, 170);
            this.grpServer.TabIndex = 0;
            this.grpServer.Text = "CÀI ĐẶT SERVER";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblServerStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblServerStatus.Location = new System.Drawing.Point(280, 115);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(84, 15);
            this.lblServerStatus.TabIndex = 4;
            this.lblServerStatus.Text = "Chưa kiểm tra...";
            // 
            // btnTestServer
            // 
            this.btnTestServer.BorderRadius = 5;
            this.btnTestServer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.btnTestServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTestServer.ForeColor = System.Drawing.Color.White;
            this.btnTestServer.Location = new System.Drawing.Point(150, 105);
            this.btnTestServer.Name = "btnTestServer";
            this.btnTestServer.Size = new System.Drawing.Size(120, 36);
            this.btnTestServer.TabIndex = 3;
            this.btnTestServer.Text = "KIỂM TRA";
            this.btnTestServer.Click += new System.EventHandler(this.btnTestServer_Click);
            // 
            // txtPort
            // 
            this.txtPort.BorderRadius = 5;
            this.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPort.DefaultText = "1433";
            this.txtPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPort.Location = new System.Drawing.Point(15, 105);
            this.txtPort.Name = "txtPort";
            this.txtPort.PlaceholderText = "Port";
            this.txtPort.Size = new System.Drawing.Size(120, 36);
            this.txtPort.TabIndex = 2;
            // 
            // txtServerLocal
            // 
            this.txtServerLocal.BorderRadius = 5;
            this.txtServerLocal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServerLocal.DefaultText = "";
            this.txtServerLocal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtServerLocal.Location = new System.Drawing.Point(330, 55);
            this.txtServerLocal.Name = "txtServerLocal";
            this.txtServerLocal.PlaceholderText = "Server Local";
            this.txtServerLocal.Size = new System.Drawing.Size(300, 36);
            this.txtServerLocal.TabIndex = 1;
            // 
            // txtServerName
            // 
            this.txtServerName.BorderRadius = 5;
            this.txtServerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServerName.DefaultText = "";
            this.txtServerName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtServerName.Location = new System.Drawing.Point(15, 55);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.PlaceholderText = "Server Name (Địa chỉ IP)";
            this.txtServerName.Size = new System.Drawing.Size(300, 36);
            this.txtServerName.TabIndex = 0;
            // 
            // pnlBottomSystem
            // 
            this.pnlBottomSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlBottomSystem.Controls.Add(this.btnGuideSystem);
            this.pnlBottomSystem.Controls.Add(this.btnSaveSystem);
            this.pnlBottomSystem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomSystem.Location = new System.Drawing.Point(15, 577);
            this.pnlBottomSystem.Name = "pnlBottomSystem";
            this.pnlBottomSystem.Size = new System.Drawing.Size(732, 50);
            this.pnlBottomSystem.TabIndex = 1;
            // 
            // btnGuideSystem
            // 
            this.btnGuideSystem.BorderRadius = 5;
            this.btnGuideSystem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.btnGuideSystem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuideSystem.ForeColor = System.Drawing.Color.White;
            this.btnGuideSystem.Location = new System.Drawing.Point(10, 7);
            this.btnGuideSystem.Name = "btnGuideSystem";
            this.btnGuideSystem.Size = new System.Drawing.Size(120, 36);
            this.btnGuideSystem.TabIndex = 1;
            this.btnGuideSystem.Text = "HƯỚNG DẪN";
            // 
            // btnSaveSystem
            // 
            this.btnSaveSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSystem.BorderRadius = 5;
            this.btnSaveSystem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.btnSaveSystem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveSystem.ForeColor = System.Drawing.Color.White;
            this.btnSaveSystem.Location = new System.Drawing.Point(600, 7);
            this.btnSaveSystem.Name = "btnSaveSystem";
            this.btnSaveSystem.Size = new System.Drawing.Size(120, 36);
            this.btnSaveSystem.TabIndex = 0;
            this.btnSaveSystem.Text = "LƯU CÀI ĐẶT";
            this.btnSaveSystem.Click += new System.EventHandler(this.btnSaveSystem_Click);
            // 
            // tabThietBi
            // 
            this.tabThietBi.Controls.Add(this.pnlThietBiContent);
            this.tabThietBi.Controls.Add(this.pnlThietBiTop);
            this.tabThietBi.Controls.Add(this.pnlThietBiBottom);
            this.tabThietBi.Location = new System.Drawing.Point(184, 4);
            this.tabThietBi.Name = "tabThietBi";
            this.tabThietBi.Padding = new System.Windows.Forms.Padding(15);
            this.tabThietBi.Size = new System.Drawing.Size(762, 642);
            this.tabThietBi.TabIndex = 1;
            this.tabThietBi.Text = "THIẾT BỊ";
            this.tabThietBi.UseVisualStyleBackColor = true;
            // 
            // pnlThietBiContent
            // 
            this.pnlThietBiContent.AutoScroll = true;
            this.pnlThietBiContent.Controls.Add(this.pnlIPConfig);
            this.pnlThietBiContent.Controls.Add(this.pnlAnalogConfig);
            this.pnlThietBiContent.Controls.Add(this.grpLaneConfig);
            this.pnlThietBiContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThietBiContent.Location = new System.Drawing.Point(15, 85);
            this.pnlThietBiContent.Name = "pnlThietBiContent";
            this.pnlThietBiContent.Size = new System.Drawing.Size(732, 492);
            this.pnlThietBiContent.TabIndex = 0;
            // 
            // pnlIPConfig
            // 
            this.pnlIPConfig.Controls.Add(this.grpIpL1P);
            this.pnlIPConfig.Controls.Add(this.grpIpL1F);
            this.pnlIPConfig.Controls.Add(this.grpIpL2P);
            this.pnlIPConfig.Controls.Add(this.grpIpL2F);
            this.pnlIPConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlIPConfig.Location = new System.Drawing.Point(0, 510);
            this.pnlIPConfig.Name = "pnlIPConfig";
            this.pnlIPConfig.Size = new System.Drawing.Size(732, 450);
            this.pnlIPConfig.TabIndex = 2;
            this.pnlIPConfig.Visible = false;
            // 
            // grpIpL1P
            // 
            this.grpIpL1P.BorderRadius = 5;
            this.grpIpL1P.Controls.Add(this.btnPreviewIpL1P);
            this.grpIpL1P.Controls.Add(this.txtIpL1P_Rtsp);
            this.grpIpL1P.Controls.Add(this.txtIpL1P_Pass);
            this.grpIpL1P.Controls.Add(this.txtIpL1P_User);
            this.grpIpL1P.Controls.Add(this.txtIpL1P_Host);
            this.grpIpL1P.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.grpIpL1P.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpIpL1P.ForeColor = System.Drawing.Color.White;
            this.grpIpL1P.Location = new System.Drawing.Point(3, 3);
            this.grpIpL1P.Name = "grpIpL1P";
            this.grpIpL1P.Size = new System.Drawing.Size(350, 215);
            this.grpIpL1P.TabIndex = 0;
            this.grpIpL1P.Text = "LÀN 1 - BIỂN SỐ (SAU)";
            // 
            // btnPreviewIpL1P
            // 
            this.btnPreviewIpL1P.BorderRadius = 5;
            this.btnPreviewIpL1P.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.btnPreviewIpL1P.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnPreviewIpL1P.ForeColor = System.Drawing.Color.White;
            this.btnPreviewIpL1P.Location = new System.Drawing.Point(260, 55);
            this.btnPreviewIpL1P.Name = "btnPreviewIpL1P";
            this.btnPreviewIpL1P.Size = new System.Drawing.Size(80, 36);
            this.btnPreviewIpL1P.TabIndex = 4;
            this.btnPreviewIpL1P.Text = "XEM THỬ";
            this.btnPreviewIpL1P.Click += new System.EventHandler(this.btnPreviewCamera_Click);
            // 
            // txtIpL1P_Rtsp
            // 
            this.txtIpL1P_Rtsp.BorderRadius = 5;
            this.txtIpL1P_Rtsp.Location = new System.Drawing.Point(10, 165);
            this.txtIpL1P_Rtsp.Name = "txtIpL1P_Rtsp";
            this.txtIpL1P_Rtsp.PlaceholderText = "RTSP Path (/Streaming/...)";
            this.txtIpL1P_Rtsp.Size = new System.Drawing.Size(330, 30);
            this.txtIpL1P_Rtsp.TabIndex = 3;
            // 
            // txtIpL1P_Pass
            // 
            this.txtIpL1P_Pass.BorderRadius = 5;
            this.txtIpL1P_Pass.Location = new System.Drawing.Point(180, 125);
            this.txtIpL1P_Pass.Name = "txtIpL1P_Pass";
            this.txtIpL1P_Pass.PasswordChar = '●';
            this.txtIpL1P_Pass.PlaceholderText = "Password";
            this.txtIpL1P_Pass.Size = new System.Drawing.Size(160, 30);
            this.txtIpL1P_Pass.TabIndex = 2;
            // 
            // txtIpL1P_User
            // 
            this.txtIpL1P_User.BorderRadius = 5;
            this.txtIpL1P_User.Location = new System.Drawing.Point(10, 125);
            this.txtIpL1P_User.Name = "txtIpL1P_User";
            this.txtIpL1P_User.PlaceholderText = "User";
            this.txtIpL1P_User.Size = new System.Drawing.Size(160, 30);
            this.txtIpL1P_User.TabIndex = 1;
            // 
            // txtIpL1P_Host
            // 
            this.txtIpL1P_Host.BorderRadius = 5;
            this.txtIpL1P_Host.Location = new System.Drawing.Point(10, 55);
            this.txtIpL1P_Host.Name = "txtIpL1P_Host";
            this.txtIpL1P_Host.PlaceholderText = "IP Camera";
            this.txtIpL1P_Host.Size = new System.Drawing.Size(245, 36);
            this.txtIpL1P_Host.TabIndex = 0;
            // 
            // grpIpL1F
            // 
            this.grpIpL1F.BorderRadius = 5;
            this.grpIpL1F.Controls.Add(this.btnPreviewIpL1F);
            this.grpIpL1F.Controls.Add(this.txtIpL1F_Rtsp);
            this.grpIpL1F.Controls.Add(this.txtIpL1F_Pass);
            this.grpIpL1F.Controls.Add(this.txtIpL1F_User);
            this.grpIpL1F.Controls.Add(this.txtIpL1F_Host);
            this.grpIpL1F.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.grpIpL1F.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpIpL1F.ForeColor = System.Drawing.Color.White;
            this.grpIpL1F.Location = new System.Drawing.Point(359, 3);
            this.grpIpL1F.Name = "grpIpL1F";
            this.grpIpL1F.Size = new System.Drawing.Size(350, 215);
            this.grpIpL1F.TabIndex = 1;
            this.grpIpL1F.Text = "LÀN 1 - TOÀN CẢNH (TRƯỚC)";
            // 
            // btnPreviewIpL1F
            // 
            this.btnPreviewIpL1F.BorderRadius = 5;
            this.btnPreviewIpL1F.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.btnPreviewIpL1F.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnPreviewIpL1F.ForeColor = System.Drawing.Color.White;
            this.btnPreviewIpL1F.Location = new System.Drawing.Point(260, 55);
            this.btnPreviewIpL1F.Name = "btnPreviewIpL1F";
            this.btnPreviewIpL1F.Size = new System.Drawing.Size(80, 36);
            this.btnPreviewIpL1F.TabIndex = 4;
            this.btnPreviewIpL1F.Text = "XEM THỬ";
            this.btnPreviewIpL1F.Click += new System.EventHandler(this.btnPreviewCamera_Click);
            // 
            // txtIpL1F_Rtsp
            // 
            this.txtIpL1F_Rtsp.BorderRadius = 5;
            this.txtIpL1F_Rtsp.Location = new System.Drawing.Point(10, 165);
            this.txtIpL1F_Rtsp.Name = "txtIpL1F_Rtsp";
            this.txtIpL1F_Rtsp.PlaceholderText = "RTSP Path (/Streaming/...)";
            this.txtIpL1F_Rtsp.Size = new System.Drawing.Size(330, 30);
            this.txtIpL1F_Rtsp.TabIndex = 3;
            // 
            // txtIpL1F_Pass
            // 
            this.txtIpL1F_Pass.BorderRadius = 5;
            this.txtIpL1F_Pass.Location = new System.Drawing.Point(180, 125);
            this.txtIpL1F_Pass.Name = "txtIpL1F_Pass";
            this.txtIpL1F_Pass.PasswordChar = '●';
            this.txtIpL1F_Pass.PlaceholderText = "Password";
            this.txtIpL1F_Pass.Size = new System.Drawing.Size(160, 30);
            this.txtIpL1F_Pass.TabIndex = 2;
            // 
            // txtIpL1F_User
            // 
            this.txtIpL1F_User.BorderRadius = 5;
            this.txtIpL1F_User.Location = new System.Drawing.Point(10, 125);
            this.txtIpL1F_User.Name = "txtIpL1F_User";
            this.txtIpL1F_User.PlaceholderText = "User";
            this.txtIpL1F_User.Size = new System.Drawing.Size(160, 30);
            this.txtIpL1F_User.TabIndex = 1;
            // 
            // txtIpL1F_Host
            // 
            this.txtIpL1F_Host.BorderRadius = 5;
            this.txtIpL1F_Host.Location = new System.Drawing.Point(10, 55);
            this.txtIpL1F_Host.Name = "txtIpL1F_Host";
            this.txtIpL1F_Host.PlaceholderText = "IP Camera";
            this.txtIpL1F_Host.Size = new System.Drawing.Size(245, 36);
            this.txtIpL1F_Host.TabIndex = 0;
            // 
            // grpIpL2P
            // 
            this.grpIpL2P.BorderRadius = 5;
            this.grpIpL2P.Controls.Add(this.btnPreviewIpL2P);
            this.grpIpL2P.Controls.Add(this.txtIpL2P_Rtsp);
            this.grpIpL2P.Controls.Add(this.txtIpL2P_Pass);
            this.grpIpL2P.Controls.Add(this.txtIpL2P_User);
            this.grpIpL2P.Controls.Add(this.txtIpL2P_Host);
            this.grpIpL2P.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.grpIpL2P.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpIpL2P.ForeColor = System.Drawing.Color.White;
            this.grpIpL2P.Location = new System.Drawing.Point(3, 224);
            this.grpIpL2P.Name = "grpIpL2P";
            this.grpIpL2P.Size = new System.Drawing.Size(350, 215);
            this.grpIpL2P.TabIndex = 2;
            this.grpIpL2P.Text = "LÀN 2 - BIỂN SỐ (SAU)";
            // 
            // btnPreviewIpL2P
            // 
            this.btnPreviewIpL2P.BorderRadius = 5;
            this.btnPreviewIpL2P.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.btnPreviewIpL2P.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnPreviewIpL2P.ForeColor = System.Drawing.Color.White;
            this.btnPreviewIpL2P.Location = new System.Drawing.Point(260, 55);
            this.btnPreviewIpL2P.Name = "btnPreviewIpL2P";
            this.btnPreviewIpL2P.Size = new System.Drawing.Size(80, 36);
            this.btnPreviewIpL2P.TabIndex = 4;
            this.btnPreviewIpL2P.Text = "XEM THỬ";
            this.btnPreviewIpL2P.Click += new System.EventHandler(this.btnPreviewCamera_Click);
            // 
            // txtIpL2P_Rtsp
            // 
            this.txtIpL2P_Rtsp.BorderRadius = 5;
            this.txtIpL2P_Rtsp.Location = new System.Drawing.Point(10, 165);
            this.txtIpL2P_Rtsp.Name = "txtIpL2P_Rtsp";
            this.txtIpL2P_Rtsp.PlaceholderText = "RTSP Path (/Streaming/...)";
            this.txtIpL2P_Rtsp.Size = new System.Drawing.Size(330, 30);
            this.txtIpL2P_Rtsp.TabIndex = 3;
            // 
            // txtIpL2P_Pass
            // 
            this.txtIpL2P_Pass.BorderRadius = 5;
            this.txtIpL2P_Pass.Location = new System.Drawing.Point(180, 125);
            this.txtIpL2P_Pass.Name = "txtIpL2P_Pass";
            this.txtIpL2P_Pass.PasswordChar = '●';
            this.txtIpL2P_Pass.PlaceholderText = "Password";
            this.txtIpL2P_Pass.Size = new System.Drawing.Size(160, 30);
            this.txtIpL2P_Pass.TabIndex = 2;
            // 
            // txtIpL2P_User
            // 
            this.txtIpL2P_User.BorderRadius = 5;
            this.txtIpL2P_User.Location = new System.Drawing.Point(10, 125);
            this.txtIpL2P_User.Name = "txtIpL2P_User";
            this.txtIpL2P_User.PlaceholderText = "User";
            this.txtIpL2P_User.Size = new System.Drawing.Size(160, 30);
            this.txtIpL2P_User.TabIndex = 1;
            // 
            // txtIpL2P_Host
            // 
            this.txtIpL2P_Host.BorderRadius = 5;
            this.txtIpL2P_Host.Location = new System.Drawing.Point(10, 55);
            this.txtIpL2P_Host.Name = "txtIpL2P_Host";
            this.txtIpL2P_Host.PlaceholderText = "IP Camera";
            this.txtIpL2P_Host.Size = new System.Drawing.Size(245, 36);
            this.txtIpL2P_Host.TabIndex = 0;
            // 
            // grpIpL2F
            // 
            this.grpIpL2F.BorderRadius = 5;
            this.grpIpL2F.Controls.Add(this.btnPreviewIpL2F);
            this.grpIpL2F.Controls.Add(this.txtIpL2F_Rtsp);
            this.grpIpL2F.Controls.Add(this.txtIpL2F_Pass);
            this.grpIpL2F.Controls.Add(this.txtIpL2F_User);
            this.grpIpL2F.Controls.Add(this.txtIpL2F_Host);
            this.grpIpL2F.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.grpIpL2F.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpIpL2F.ForeColor = System.Drawing.Color.White;
            this.grpIpL2F.Location = new System.Drawing.Point(359, 224);
            this.grpIpL2F.Name = "grpIpL2F";
            this.grpIpL2F.Size = new System.Drawing.Size(350, 215);
            this.grpIpL2F.TabIndex = 3;
            this.grpIpL2F.Text = "LÀN 2 - TOÀN CẢNH (TRƯỚC)";
            // 
            // btnPreviewIpL2F
            // 
            this.btnPreviewIpL2F.BorderRadius = 5;
            this.btnPreviewIpL2F.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.btnPreviewIpL2F.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnPreviewIpL2F.ForeColor = System.Drawing.Color.White;
            this.btnPreviewIpL2F.Location = new System.Drawing.Point(260, 55);
            this.btnPreviewIpL2F.Name = "btnPreviewIpL2F";
            this.btnPreviewIpL2F.Size = new System.Drawing.Size(80, 36);
            this.btnPreviewIpL2F.TabIndex = 4;
            this.btnPreviewIpL2F.Text = "XEM THỬ";
            this.btnPreviewIpL2F.Click += new System.EventHandler(this.btnPreviewCamera_Click);
            // 
            // txtIpL2F_Rtsp
            // 
            this.txtIpL2F_Rtsp.BorderRadius = 5;
            this.txtIpL2F_Rtsp.Location = new System.Drawing.Point(10, 165);
            this.txtIpL2F_Rtsp.Name = "txtIpL2F_Rtsp";
            this.txtIpL2F_Rtsp.PlaceholderText = "RTSP Path (/Streaming/...)";
            this.txtIpL2F_Rtsp.Size = new System.Drawing.Size(330, 30);
            this.txtIpL2F_Rtsp.TabIndex = 3;
            // 
            // txtIpL2F_Pass
            // 
            this.txtIpL2F_Pass.BorderRadius = 5;
            this.txtIpL2F_Pass.Location = new System.Drawing.Point(180, 125);
            this.txtIpL2F_Pass.Name = "txtIpL2F_Pass";
            this.txtIpL2F_Pass.PasswordChar = '●';
            this.txtIpL2F_Pass.PlaceholderText = "Password";
            this.txtIpL2F_Pass.Size = new System.Drawing.Size(160, 30);
            this.txtIpL2F_Pass.TabIndex = 2;
            // 
            // txtIpL2F_User
            // 
            this.txtIpL2F_User.BorderRadius = 5;
            this.txtIpL2F_User.Location = new System.Drawing.Point(10, 125);
            this.txtIpL2F_User.Name = "txtIpL2F_User";
            this.txtIpL2F_User.PlaceholderText = "User";
            this.txtIpL2F_User.Size = new System.Drawing.Size(160, 30);
            this.txtIpL2F_User.TabIndex = 1;
            // 
            // txtIpL2F_Host
            // 
            this.txtIpL2F_Host.BorderRadius = 5;
            this.txtIpL2F_Host.Location = new System.Drawing.Point(10, 55);
            this.txtIpL2F_Host.Name = "txtIpL2F_Host";
            this.txtIpL2F_Host.PlaceholderText = "IP Camera";
            this.txtIpL2F_Host.Size = new System.Drawing.Size(245, 36);
            this.txtIpL2F_Host.TabIndex = 0;
            // 
            // pnlAnalogConfig
            // 
            this.pnlAnalogConfig.Controls.Add(this.grpAnalogChannels);
            this.pnlAnalogConfig.Controls.Add(this.grpDvrInfo);
            this.pnlAnalogConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAnalogConfig.Location = new System.Drawing.Point(0, 150);
            this.pnlAnalogConfig.Name = "pnlAnalogConfig";
            this.pnlAnalogConfig.Size = new System.Drawing.Size(732, 360);
            this.pnlAnalogConfig.TabIndex = 1;
            // 
            // grpAnalogChannels
            // 
            this.grpAnalogChannels.BorderRadius = 5;
            this.grpAnalogChannels.Controls.Add(this.btnPreviewAnL2F);
            this.grpAnalogChannels.Controls.Add(this.btnPreviewAnL2P);
            this.grpAnalogChannels.Controls.Add(this.btnPreviewAnL1F);
            this.grpAnalogChannels.Controls.Add(this.btnPreviewAnL1P);
            this.grpAnalogChannels.Controls.Add(this.numChL2F);
            this.grpAnalogChannels.Controls.Add(this.numChL2P);
            this.grpAnalogChannels.Controls.Add(this.numChL1F);
            this.grpAnalogChannels.Controls.Add(this.numChL1P);
            this.grpAnalogChannels.Controls.Add(this.label4);
            this.grpAnalogChannels.Controls.Add(this.label3);
            this.grpAnalogChannels.Controls.Add(this.label2);
            this.grpAnalogChannels.Controls.Add(this.label1);
            this.grpAnalogChannels.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.grpAnalogChannels.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAnalogChannels.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpAnalogChannels.ForeColor = System.Drawing.Color.White;
            this.grpAnalogChannels.Location = new System.Drawing.Point(0, 160);
            this.grpAnalogChannels.Name = "grpAnalogChannels";
            this.grpAnalogChannels.Size = new System.Drawing.Size(732, 200);
            this.grpAnalogChannels.TabIndex = 1;
            this.grpAnalogChannels.Text = "PHÂN KÊNH CAMERA THEO LÀN";
            // 
            // btnPreviewAnL2F
            // 
            this.btnPreviewAnL2F.BorderRadius = 5;
            this.btnPreviewAnL2F.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.btnPreviewAnL2F.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnPreviewAnL2F.ForeColor = System.Drawing.Color.White;
            this.btnPreviewAnL2F.Location = new System.Drawing.Point(570, 115);
            this.btnPreviewAnL2F.Name = "btnPreviewAnL2F";
            this.btnPreviewAnL2F.Size = new System.Drawing.Size(80, 36);
            this.btnPreviewAnL2F.TabIndex = 11;
            this.btnPreviewAnL2F.Text = "XEM THỬ";
            this.btnPreviewAnL2F.Click += new System.EventHandler(this.btnPreviewCamera_Click);
            // 
            // btnPreviewAnL2P
            // 
            this.btnPreviewAnL2P.BorderRadius = 5;
            this.btnPreviewAnL2P.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.btnPreviewAnL2P.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnPreviewAnL2P.ForeColor = System.Drawing.Color.White;
            this.btnPreviewAnL2P.Location = new System.Drawing.Point(250, 115);
            this.btnPreviewAnL2P.Name = "btnPreviewAnL2P";
            this.btnPreviewAnL2P.Size = new System.Drawing.Size(80, 36);
            this.btnPreviewAnL2P.TabIndex = 10;
            this.btnPreviewAnL2P.Text = "XEM THỬ";
            this.btnPreviewAnL2P.Click += new System.EventHandler(this.btnPreviewCamera_Click);
            // 
            // btnPreviewAnL1F
            // 
            this.btnPreviewAnL1F.BorderRadius = 5;
            this.btnPreviewAnL1F.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.btnPreviewAnL1F.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnPreviewAnL1F.ForeColor = System.Drawing.Color.White;
            this.btnPreviewAnL1F.Location = new System.Drawing.Point(570, 55);
            this.btnPreviewAnL1F.Name = "btnPreviewAnL1F";
            this.btnPreviewAnL1F.Size = new System.Drawing.Size(80, 36);
            this.btnPreviewAnL1F.TabIndex = 9;
            this.btnPreviewAnL1F.Text = "XEM THỬ";
            this.btnPreviewAnL1F.Click += new System.EventHandler(this.btnPreviewCamera_Click);
            // 
            // btnPreviewAnL1P
            // 
            this.btnPreviewAnL1P.BorderRadius = 5;
            this.btnPreviewAnL1P.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.btnPreviewAnL1P.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnPreviewAnL1P.ForeColor = System.Drawing.Color.White;
            this.btnPreviewAnL1P.Location = new System.Drawing.Point(250, 55);
            this.btnPreviewAnL1P.Name = "btnPreviewAnL1P";
            this.btnPreviewAnL1P.Size = new System.Drawing.Size(80, 36);
            this.btnPreviewAnL1P.TabIndex = 8;
            this.btnPreviewAnL1P.Text = "XEM THỬ";
            this.btnPreviewAnL1P.Click += new System.EventHandler(this.btnPreviewCamera_Click);
            // 
            // numChL2F
            // 
            this.numChL2F.BackColor = System.Drawing.Color.Transparent;
            this.numChL2F.BorderRadius = 5;
            this.numChL2F.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numChL2F.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numChL2F.Location = new System.Drawing.Point(480, 115);
            this.numChL2F.Name = "numChL2F";
            this.numChL2F.Size = new System.Drawing.Size(80, 36);
            this.numChL2F.TabIndex = 7;
            // 
            // numChL2P
            // 
            this.numChL2P.BackColor = System.Drawing.Color.Transparent;
            this.numChL2P.BorderRadius = 5;
            this.numChL2P.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numChL2P.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numChL2P.Location = new System.Drawing.Point(160, 115);
            this.numChL2P.Name = "numChL2P";
            this.numChL2P.Size = new System.Drawing.Size(80, 36);
            this.numChL2P.TabIndex = 5;
            // 
            // numChL1F
            // 
            this.numChL1F.BackColor = System.Drawing.Color.Transparent;
            this.numChL1F.BorderRadius = 5;
            this.numChL1F.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numChL1F.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numChL1F.Location = new System.Drawing.Point(480, 55);
            this.numChL1F.Name = "numChL1F";
            this.numChL1F.Size = new System.Drawing.Size(80, 36);
            this.numChL1F.TabIndex = 3;
            // 
            // numChL1P
            // 
            this.numChL1P.BackColor = System.Drawing.Color.Transparent;
            this.numChL1P.BorderRadius = 5;
            this.numChL1P.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numChL1P.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numChL1P.Location = new System.Drawing.Point(160, 55);
            this.numChL1P.Name = "numChL1P";
            this.numChL1P.Size = new System.Drawing.Size(80, 36);
            this.numChL1P.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(330, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Làn 2 - Toàn cảnh:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Làn 2 - Biển số:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(330, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Làn 1 - Toàn cảnh:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Làn 1 - Biển số:";
            // 
            // grpDvrInfo
            // 
            this.grpDvrInfo.BorderRadius = 5;
            this.grpDvrInfo.Controls.Add(this.txtDvrPass);
            this.grpDvrInfo.Controls.Add(this.txtDvrUser);
            this.grpDvrInfo.Controls.Add(this.txtDvrPort);
            this.grpDvrInfo.Controls.Add(this.txtDvrHost);
            this.grpDvrInfo.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.grpDvrInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDvrInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDvrInfo.ForeColor = System.Drawing.Color.White;
            this.grpDvrInfo.Location = new System.Drawing.Point(0, 0);
            this.grpDvrInfo.Name = "grpDvrInfo";
            this.grpDvrInfo.Size = new System.Drawing.Size(732, 160);
            this.grpDvrInfo.TabIndex = 0;
            this.grpDvrInfo.Text = "CẤU HÌNH ĐẦU GHI (DVR/NVR)";
            // 
            // txtDvrPass
            // 
            this.txtDvrPass.BorderRadius = 5;
            this.txtDvrPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDvrPass.DefaultText = "";
            this.txtDvrPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDvrPass.Location = new System.Drawing.Point(330, 105);
            this.txtDvrPass.Name = "txtDvrPass";
            this.txtDvrPass.PasswordChar = '●';
            this.txtDvrPass.PlaceholderText = "Password";
            this.txtDvrPass.Size = new System.Drawing.Size(300, 36);
            this.txtDvrPass.TabIndex = 3;
            // 
            // txtDvrUser
            // 
            this.txtDvrUser.BorderRadius = 5;
            this.txtDvrUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDvrUser.DefaultText = "";
            this.txtDvrUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDvrUser.Location = new System.Drawing.Point(15, 105);
            this.txtDvrUser.Name = "txtDvrUser";
            this.txtDvrUser.PlaceholderText = "Username";
            this.txtDvrUser.Size = new System.Drawing.Size(300, 36);
            this.txtDvrUser.TabIndex = 2;
            // 
            // txtDvrPort
            // 
            this.txtDvrPort.BorderRadius = 5;
            this.txtDvrPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDvrPort.DefaultText = "8000";
            this.txtDvrPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDvrPort.Location = new System.Drawing.Point(330, 55);
            this.txtDvrPort.Name = "txtDvrPort";
            this.txtDvrPort.PlaceholderText = "Port (8000)";
            this.txtDvrPort.Size = new System.Drawing.Size(120, 36);
            this.txtDvrPort.TabIndex = 1;
            // 
            // txtDvrHost
            // 
            this.txtDvrHost.BorderRadius = 5;
            this.txtDvrHost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDvrHost.DefaultText = "";
            this.txtDvrHost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDvrHost.Location = new System.Drawing.Point(15, 55);
            this.txtDvrHost.Name = "txtDvrHost";
            this.txtDvrHost.PlaceholderText = "IP Đầu ghi (192.168...)";
            this.txtDvrHost.Size = new System.Drawing.Size(300, 36);
            this.txtDvrHost.TabIndex = 0;
            // 
            // grpLaneConfig
            // 
            this.grpLaneConfig.BorderRadius = 5;
            this.grpLaneConfig.Controls.Add(this.txtLane2Com);
            this.grpLaneConfig.Controls.Add(this.txtLane1Com);
            this.grpLaneConfig.Controls.Add(this.cboLane2Dir);
            this.grpLaneConfig.Controls.Add(this.cboLane1Dir);
            this.grpLaneConfig.Controls.Add(this.lblL2);
            this.grpLaneConfig.Controls.Add(this.lblL1);
            this.grpLaneConfig.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.grpLaneConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLaneConfig.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpLaneConfig.ForeColor = System.Drawing.Color.White;
            this.grpLaneConfig.Location = new System.Drawing.Point(0, 0);
            this.grpLaneConfig.Name = "grpLaneConfig";
            this.grpLaneConfig.Size = new System.Drawing.Size(732, 150);
            this.grpLaneConfig.TabIndex = 0;
            this.grpLaneConfig.Text = "CẤU HÌNH LÀN XE & ĐẦU ĐỌC";
            // 
            // txtLane2Com
            // 
            this.txtLane2Com.BorderRadius = 5;
            this.txtLane2Com.Location = new System.Drawing.Point(330, 100);
            this.txtLane2Com.Name = "txtLane2Com";
            this.txtLane2Com.PlaceholderText = "Cổng COM (COM2)";
            this.txtLane2Com.Size = new System.Drawing.Size(150, 36);
            this.txtLane2Com.TabIndex = 5;
            // 
            // txtLane1Com
            // 
            this.txtLane1Com.BorderRadius = 5;
            this.txtLane1Com.Location = new System.Drawing.Point(330, 50);
            this.txtLane1Com.Name = "txtLane1Com";
            this.txtLane1Com.PlaceholderText = "Cổng COM (COM1)";
            this.txtLane1Com.Size = new System.Drawing.Size(150, 36);
            this.txtLane1Com.TabIndex = 2;
            // 
            // cboLane2Dir
            // 
            this.cboLane2Dir.BackColor = System.Drawing.Color.Transparent;
            this.cboLane2Dir.BorderRadius = 5;
            this.cboLane2Dir.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLane2Dir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLane2Dir.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLane2Dir.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLane2Dir.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLane2Dir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboLane2Dir.ItemHeight = 30;
            this.cboLane2Dir.Items.AddRange(new object[] {
            "LÀN VÀO",
            "LÀN RA",
            "ĐẢO CHIỀU"});
            this.cboLane2Dir.Location = new System.Drawing.Point(130, 100);
            this.cboLane2Dir.Name = "cboLane2Dir";
            this.cboLane2Dir.Size = new System.Drawing.Size(180, 36);
            this.cboLane2Dir.TabIndex = 4;
            // 
            // cboLane1Dir
            // 
            this.cboLane1Dir.BackColor = System.Drawing.Color.Transparent;
            this.cboLane1Dir.BorderRadius = 5;
            this.cboLane1Dir.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLane1Dir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLane1Dir.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLane1Dir.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLane1Dir.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLane1Dir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboLane1Dir.ItemHeight = 30;
            this.cboLane1Dir.Items.AddRange(new object[] {
            "LÀN VÀO",
            "LÀN RA",
            "ĐẢO CHIỀU"});
            this.cboLane1Dir.Location = new System.Drawing.Point(130, 50);
            this.cboLane1Dir.Name = "cboLane1Dir";
            this.cboLane1Dir.Size = new System.Drawing.Size(180, 36);
            this.cboLane1Dir.TabIndex = 1;
            // 
            // lblL2
            // 
            this.lblL2.AutoSize = true;
            this.lblL2.ForeColor = System.Drawing.Color.Black;
            this.lblL2.Location = new System.Drawing.Point(15, 105);
            this.lblL2.Name = "lblL2";
            this.lblL2.Size = new System.Drawing.Size(95, 19);
            this.lblL2.TabIndex = 3;
            this.lblL2.Text = "Cấu hình Làn 2:";
            // 
            // lblL1
            // 
            this.lblL1.AutoSize = true;
            this.lblL1.ForeColor = System.Drawing.Color.Black;
            this.lblL1.Location = new System.Drawing.Point(15, 55);
            this.lblL1.Name = "lblL1";
            this.lblL1.Size = new System.Drawing.Size(95, 19);
            this.lblL1.TabIndex = 0;
            this.lblL1.Text = "Cấu hình Làn 1:";
            // 
            // grpDisplayOptions
            // 
            this.grpDisplayOptions.BorderRadius = 5;
            this.grpDisplayOptions.Controls.Add(this.chkShowCamerasOnMain);
            this.grpDisplayOptions.CustomBorderThickness = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.grpDisplayOptions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpDisplayOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grpDisplayOptions.Location = new System.Drawing.Point(310, 3);
            this.grpDisplayOptions.Name = "grpDisplayOptions";
            this.grpDisplayOptions.Size = new System.Drawing.Size(250, 60);
            this.grpDisplayOptions.TabIndex = 2;
            this.grpDisplayOptions.Text = "TÙY CHỌN HIỂN THỊ";
            // 
            // chkShowCamerasOnMain
            // 
            this.chkShowCamerasOnMain.AutoSize = true;
            this.chkShowCamerasOnMain.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkShowCamerasOnMain.CheckedState.BorderRadius = 2;
            this.chkShowCamerasOnMain.CheckedState.BorderThickness = 0;
            this.chkShowCamerasOnMain.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.chkShowCamerasOnMain.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.chkShowCamerasOnMain.ForeColor = System.Drawing.Color.Black;
            this.chkShowCamerasOnMain.Location = new System.Drawing.Point(10, 33);
            this.chkShowCamerasOnMain.Name = "chkShowCamerasOnMain";
            this.chkShowCamerasOnMain.Size = new System.Drawing.Size(185, 17);
            this.chkShowCamerasOnMain.TabIndex = 0;
            this.chkShowCamerasOnMain.Text = "Hiện Camera ra màn hình chính";
            this.chkShowCamerasOnMain.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkShowCamerasOnMain.UncheckedState.BorderRadius = 2;
            this.chkShowCamerasOnMain.UncheckedState.BorderThickness = 0;
            this.chkShowCamerasOnMain.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // pnlThietBiTop
            // 
            this.pnlThietBiTop.Controls.Add(this.grpDisplayOptions);
            this.pnlThietBiTop.Controls.Add(this.grpCameraType);
            this.pnlThietBiTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThietBiTop.Location = new System.Drawing.Point(15, 15);
            this.pnlThietBiTop.Name = "pnlThietBiTop";
            this.pnlThietBiTop.Size = new System.Drawing.Size(732, 70);
            this.pnlThietBiTop.TabIndex = 2;
            // 
            // grpCameraType
            // 
            this.grpCameraType.BorderRadius = 5;
            this.grpCameraType.Controls.Add(this.rdoAnalogCamera);
            this.grpCameraType.Controls.Add(this.rdoIPCamera);
            this.grpCameraType.CustomBorderThickness = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.grpCameraType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpCameraType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grpCameraType.Location = new System.Drawing.Point(3, 3);
            this.grpCameraType.Name = "grpCameraType";
            this.grpCameraType.Size = new System.Drawing.Size(300, 60);
            this.grpCameraType.TabIndex = 1;
            this.grpCameraType.Text = "LOẠI CAMERA SỬ DỤNG";
            // 
            // rdoAnalogCamera
            // 
            this.rdoAnalogCamera.AutoSize = true;
            this.rdoAnalogCamera.Checked = true;
            this.rdoAnalogCamera.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.rdoAnalogCamera.CheckedState.BorderThickness = 0;
            this.rdoAnalogCamera.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.rdoAnalogCamera.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdoAnalogCamera.Location = new System.Drawing.Point(15, 33);
            this.rdoAnalogCamera.Name = "rdoAnalogCamera";
            this.rdoAnalogCamera.Size = new System.Drawing.Size(108, 19);
            this.rdoAnalogCamera.TabIndex = 1;
            this.rdoAnalogCamera.TabStop = true;
            this.rdoAnalogCamera.Text = "Analog Camera";
            this.rdoAnalogCamera.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdoAnalogCamera.UncheckedState.BorderThickness = 2;
            this.rdoAnalogCamera.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdoAnalogCamera.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdoAnalogCamera.CheckedChanged += new System.EventHandler(this.rdoCameraType_CheckedChanged);
            // 
            // rdoIPCamera
            // 
            this.rdoIPCamera.AutoSize = true;
            this.rdoIPCamera.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.rdoIPCamera.CheckedState.BorderThickness = 0;
            this.rdoIPCamera.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.rdoIPCamera.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdoIPCamera.Location = new System.Drawing.Point(150, 33);
            this.rdoIPCamera.Name = "rdoIPCamera";
            this.rdoIPCamera.Size = new System.Drawing.Size(81, 19);
            this.rdoIPCamera.TabIndex = 0;
            this.rdoIPCamera.Text = "IP Camera";
            this.rdoIPCamera.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdoIPCamera.UncheckedState.BorderThickness = 2;
            this.rdoIPCamera.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdoIPCamera.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdoIPCamera.CheckedChanged += new System.EventHandler(this.rdoCameraType_CheckedChanged);
            // 
            // pnlThietBiBottom
            // 
            this.pnlThietBiBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlThietBiBottom.Controls.Add(this.btnGuideDevice);
            this.pnlThietBiBottom.Controls.Add(this.btnSaveDevice);
            this.pnlThietBiBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThietBiBottom.Location = new System.Drawing.Point(15, 577);
            this.pnlThietBiBottom.Name = "pnlThietBiBottom";
            this.pnlThietBiBottom.Size = new System.Drawing.Size(732, 50);
            this.pnlThietBiBottom.TabIndex = 1;
            // 
            // btnGuideDevice
            // 
            this.btnGuideDevice.BorderRadius = 5;
            this.btnGuideDevice.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.btnGuideDevice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuideDevice.ForeColor = System.Drawing.Color.White;
            this.btnGuideDevice.Location = new System.Drawing.Point(10, 7);
            this.btnGuideDevice.Name = "btnGuideDevice";
            this.btnGuideDevice.Size = new System.Drawing.Size(120, 36);
            this.btnGuideDevice.TabIndex = 1;
            this.btnGuideDevice.Text = "HƯỚNG DẪN";
            // 
            // btnSaveDevice
            // 
            this.btnSaveDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveDevice.BorderRadius = 5;
            this.btnSaveDevice.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.btnSaveDevice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveDevice.ForeColor = System.Drawing.Color.White;
            this.btnSaveDevice.Location = new System.Drawing.Point(600, 7);
            this.btnSaveDevice.Name = "btnSaveDevice";
            this.btnSaveDevice.Size = new System.Drawing.Size(120, 36);
            this.btnSaveDevice.TabIndex = 0;
            this.btnSaveDevice.Text = "LƯU THIẾT BỊ";
            this.btnSaveDevice.Click += new System.EventHandler(this.btnSaveDevice_Click);
            // 
            // tabLoaiThe
            // 
            this.tabLoaiThe.Controls.Add(this.dgvCardType);
            this.tabLoaiThe.Controls.Add(this.pnlCardTypeTools);
            this.tabLoaiThe.Controls.Add(this.pnlLoaiTheBottom);
            this.tabLoaiThe.Location = new System.Drawing.Point(184, 4);
            this.tabLoaiThe.Name = "tabLoaiThe";
            this.tabLoaiThe.Padding = new System.Windows.Forms.Padding(15);
            this.tabLoaiThe.Size = new System.Drawing.Size(762, 642);
            this.tabLoaiThe.TabIndex = 2;
            this.tabLoaiThe.Text = "LOẠI THẺ";
            this.tabLoaiThe.UseVisualStyleBackColor = true;
            // 
            // dgvCardType
            // 
            this.dgvCardType.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCardType.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCardType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCardType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCardType.ColumnHeadersHeight = 35;
            this.dgvCardType.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCardType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCardType.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCardType.Location = new System.Drawing.Point(15, 65);
            this.dgvCardType.Name = "dgvCardType";
            this.dgvCardType.RowHeadersVisible = false;
            this.dgvCardType.Size = new System.Drawing.Size(732, 512);
            this.dgvCardType.TabIndex = 0;
            this.dgvCardType.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCardType.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCardType.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCardType.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCardType.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCardType.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCardType.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCardType.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.dgvCardType.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCardType.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCardType.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCardType.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvCardType.ThemeStyle.ReadOnly = false;
            this.dgvCardType.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCardType.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCardType.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvCardType.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCardType.ThemeStyle.RowsStyle.Height = 22;
            this.dgvCardType.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCardType.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // pnlCardTypeTools
            // 
            this.pnlCardTypeTools.Controls.Add(this.btnDelete);
            this.pnlCardTypeTools.Controls.Add(this.btnEdit);
            this.pnlCardTypeTools.Controls.Add(this.btnAdd);
            this.pnlCardTypeTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCardTypeTools.Location = new System.Drawing.Point(15, 15);
            this.pnlCardTypeTools.Name = "pnlCardTypeTools";
            this.pnlCardTypeTools.Size = new System.Drawing.Size(732, 50);
            this.pnlCardTypeTools.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.BorderRadius = 5;
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(185, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 36);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "XÓA";
            // 
            // btnEdit
            // 
            this.btnEdit.BorderRadius = 5;
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(95, 7);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 36);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "SỬA";
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 5;
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(5, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 36);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "THÊM";
            // 
            // pnlLoaiTheBottom
            // 
            this.pnlLoaiTheBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlLoaiTheBottom.Controls.Add(this.btnGuideCardType);
            this.pnlLoaiTheBottom.Controls.Add(this.btnSaveCardType);
            this.pnlLoaiTheBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLoaiTheBottom.Location = new System.Drawing.Point(15, 577);
            this.pnlLoaiTheBottom.Name = "pnlLoaiTheBottom";
            this.pnlLoaiTheBottom.Size = new System.Drawing.Size(732, 50);
            this.pnlLoaiTheBottom.TabIndex = 1;
            // 
            // btnGuideCardType
            // 
            this.btnGuideCardType.BorderRadius = 5;
            this.btnGuideCardType.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.btnGuideCardType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuideCardType.ForeColor = System.Drawing.Color.White;
            this.btnGuideCardType.Location = new System.Drawing.Point(10, 7);
            this.btnGuideCardType.Name = "btnGuideCardType";
            this.btnGuideCardType.Size = new System.Drawing.Size(120, 36);
            this.btnGuideCardType.TabIndex = 1;
            this.btnGuideCardType.Text = "HƯỚNG DẪN";
            // 
            // btnSaveCardType
            // 
            this.btnSaveCardType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveCardType.BorderRadius = 5;
            this.btnSaveCardType.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(128)))), ((int)(((byte)(66)))));
            this.btnSaveCardType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveCardType.ForeColor = System.Drawing.Color.White;
            this.btnSaveCardType.Location = new System.Drawing.Point(600, 7);
            this.btnSaveCardType.Name = "btnSaveCardType";
            this.btnSaveCardType.Size = new System.Drawing.Size(120, 36);
            this.btnSaveCardType.TabIndex = 0;
            this.btnSaveCardType.Text = "LƯU LOẠI THẺ";
            this.btnSaveCardType.Click += new System.EventHandler(this.btnSaveCardType_Click);
            // 
            // tabGiaTien
            // 
            this.tabGiaTien.Controls.Add(this.lblGiaTienDev);
            this.tabGiaTien.Location = new System.Drawing.Point(184, 4);
            this.tabGiaTien.Name = "tabGiaTien";
            this.tabGiaTien.Padding = new System.Windows.Forms.Padding(15);
            this.tabGiaTien.Size = new System.Drawing.Size(762, 642);
            this.tabGiaTien.TabIndex = 3;
            this.tabGiaTien.Text = "GIÁ TIỀN";
            this.tabGiaTien.UseVisualStyleBackColor = true;
            // 
            // lblGiaTienDev
            // 
            this.lblGiaTienDev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGiaTienDev.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaTienDev.Location = new System.Drawing.Point(0, 0);
            this.lblGiaTienDev.Name = "lblGiaTienDev";
            this.lblGiaTienDev.Size = new System.Drawing.Size(762, 642);
            this.lblGiaTienDev.TabIndex = 0;
            this.lblGiaTienDev.Text = "Đang phát triển chức năng cấu hình giá tiền theo thời gian...";
            this.lblGiaTienDev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabNangCao
            // 
            this.tabNangCao.Controls.Add(this.lblNangCaoDev);
            this.tabNangCao.Location = new System.Drawing.Point(184, 4);
            this.tabNangCao.Name = "tabNangCao";
            this.tabHeThong.Padding = new System.Windows.Forms.Padding(15);
            this.tabNangCao.Size = new System.Drawing.Size(762, 642);
            this.tabNangCao.TabIndex = 4;
            this.tabNangCao.Text = "NÂNG CAO";
            this.tabNangCao.UseVisualStyleBackColor = true;
            // 
            // lblNangCaoDev
            // 
            this.lblNangCaoDev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNangCaoDev.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNangCaoDev.Location = new System.Drawing.Point(0, 0);
            this.lblNangCaoDev.Name = "lblNangCaoDev";
            this.lblNangCaoDev.Size = new System.Drawing.Size(762, 642);
            this.lblNangCaoDev.TabIndex = 0;
            this.lblNangCaoDev.Text = "Cấu hình AI nhận diện biển số và các tùy chọn nâng cao khác...";
            this.lblNangCaoDev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 650);
            this.Controls.Add(this.guna2TabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CẤU HÌNH HỆ THỐNG - IDT PARKING v2.0";
            this.guna2TabControl1.ResumeLayout(false);
            this.tabHeThong.ResumeLayout(false);
            this.pnlHeThongContent.ResumeLayout(false);
            this.grpOptions.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.grpPath.ResumeLayout(false);
            this.grpDatabase.ResumeLayout(false);
            this.grpDatabase.PerformLayout();
            this.grpServer.ResumeLayout(false);
            this.grpServer.PerformLayout();
            this.pnlBottomSystem.ResumeLayout(false);
            this.tabThietBi.ResumeLayout(false);
            this.pnlThietBiContent.ResumeLayout(false);
            this.pnlIPConfig.ResumeLayout(false);
            this.grpIpL1P.ResumeLayout(false);
            this.grpIpL1F.ResumeLayout(false);
            this.grpIpL2P.ResumeLayout(false);
            this.grpIpL2F.ResumeLayout(false);
            this.pnlAnalogConfig.ResumeLayout(false);
            this.grpAnalogChannels.ResumeLayout(false);
            this.grpAnalogChannels.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChL2F)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChL2P)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChL1F)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChL1P)).EndInit();
            this.grpDvrInfo.ResumeLayout(false);
            this.grpLaneConfig.ResumeLayout(false);
            this.grpLaneConfig.PerformLayout();
            this.pnlThietBiTop.ResumeLayout(false);
            this.grpCameraType.ResumeLayout(false);
            this.grpCameraType.PerformLayout();
            this.pnlThietBiBottom.ResumeLayout(false);
            this.tabLoaiThe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardType)).EndInit();
            this.pnlCardTypeTools.ResumeLayout(false);
            this.pnlLoaiTheBottom.ResumeLayout(false);
            this.tabGiaTien.ResumeLayout(false);
            this.tabNangCao.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage tabHeThong;
        private System.Windows.Forms.TabPage tabThietBi;
        private System.Windows.Forms.TabPage tabLoaiThe;
        private System.Windows.Forms.TabPage tabGiaTien;
        private System.Windows.Forms.TabPage tabNangCao;
        private System.Windows.Forms.Panel pnlHeThongContent;
        private Guna.UI2.WinForms.Guna2GroupBox grpServer;
        private Guna.UI2.WinForms.Guna2TextBox txtServerName;
        private Guna.UI2.WinForms.Guna2TextBox txtPort;
        private Guna.UI2.WinForms.Guna2TextBox txtServerLocal;
        private Guna.UI2.WinForms.Guna2Button btnTestServer;
        private System.Windows.Forms.Label lblServerStatus;
        private Guna.UI2.WinForms.Guna2GroupBox grpDatabase;
        private Guna.UI2.WinForms.Guna2TextBox txtDBName;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2Button btnTestDB;
        private System.Windows.Forms.Label lblDBStatus;
        private Guna.UI2.WinForms.Guna2GroupBox grpPath;
        private Guna.UI2.WinForms.Guna2TextBox txtLocalPath;
        private Guna.UI2.WinForms.Guna2TextBox txtURLServer;
        private Guna.UI2.WinForms.Guna2TextBox txtBackupPath;
        private System.Windows.Forms.Panel pnlBottomSystem;
        private Guna.UI2.WinForms.Guna2Button btnSaveSystem;
        private Guna.UI2.WinForms.Guna2Button btnGuideSystem;
        private Guna.UI2.WinForms.Guna2GroupBox grpOptions;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2CheckBox chkFastScan;
        private Guna.UI2.WinForms.Guna2CheckBox chkSyncData;
        private Guna.UI2.WinForms.Guna2CheckBox chkAutoReconnect;
        private Guna.UI2.WinForms.Guna2CheckBox chkAutoPrint;
        private Guna.UI2.WinForms.Guna2CheckBox chkOnlineImage;
        private Guna.UI2.WinForms.Guna2CheckBox chkShowCamerasOnMain;
        private Guna.UI2.WinForms.Guna2CheckBox chkShowRevenue;
        private Guna.UI2.WinForms.Guna2CheckBox chkVoiceMoney;
        private Guna.UI2.WinForms.Guna2CheckBox chkVoiceWarning;
        private System.Windows.Forms.Panel pnlThietBiBottom;
        private Guna.UI2.WinForms.Guna2Button btnGuideDevice;
        private Guna.UI2.WinForms.Guna2Button btnSaveDevice;
        private System.Windows.Forms.Panel pnlThietBiTop;
        private Guna.UI2.WinForms.Guna2GroupBox grpCameraType;
        private Guna.UI2.WinForms.Guna2RadioButton rdoAnalogCamera;
        private Guna.UI2.WinForms.Guna2RadioButton rdoIPCamera;
        private Guna.UI2.WinForms.Guna2GroupBox grpDisplayOptions;
        private System.Windows.Forms.Panel pnlThietBiContent;
        private Guna.UI2.WinForms.Guna2GroupBox grpLaneConfig;
        private System.Windows.Forms.Label lblL1;
        private System.Windows.Forms.Label lblL2;
        private Guna.UI2.WinForms.Guna2ComboBox cboLane1Dir;
        private Guna.UI2.WinForms.Guna2ComboBox cboLane2Dir;
        private Guna.UI2.WinForms.Guna2TextBox txtLane1Com;
        private Guna.UI2.WinForms.Guna2TextBox txtLane2Com;
        private System.Windows.Forms.Panel pnlAnalogConfig;
        private Guna.UI2.WinForms.Guna2GroupBox grpDvrInfo;
        private Guna.UI2.WinForms.Guna2TextBox txtDvrHost;
        private Guna.UI2.WinForms.Guna2TextBox txtDvrPort;
        private Guna.UI2.WinForms.Guna2TextBox txtDvrUser;
        private Guna.UI2.WinForms.Guna2TextBox txtDvrPass;
        private Guna.UI2.WinForms.Guna2GroupBox grpAnalogChannels;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2NumericUpDown numChL1P;
        private Guna.UI2.WinForms.Guna2NumericUpDown numChL1F;
        private Guna.UI2.WinForms.Guna2NumericUpDown numChL2P;
        private Guna.UI2.WinForms.Guna2NumericUpDown numChL2F;
        private Guna.UI2.WinForms.Guna2Button btnPreviewAnL1P;
        private Guna.UI2.WinForms.Guna2Button btnPreviewAnL1F;
        private Guna.UI2.WinForms.Guna2Button btnPreviewAnL2P;
        private Guna.UI2.WinForms.Guna2Button btnPreviewAnL2F;
        private System.Windows.Forms.FlowLayoutPanel pnlIPConfig;
        private Guna.UI2.WinForms.Guna2GroupBox grpIpL1P;
        private Guna.UI2.WinForms.Guna2TextBox txtIpL1P_Host;
        private Guna.UI2.WinForms.Guna2TextBox txtIpL1P_User;
        private Guna.UI2.WinForms.Guna2TextBox txtIpL1P_Pass;
        private Guna.UI2.WinForms.Guna2TextBox txtIpL1P_Rtsp;
        private Guna.UI2.WinForms.Guna2Button btnPreviewIpL1P;
        private Guna.UI2.WinForms.Guna2GroupBox grpIpL1F;
        private Guna.UI2.WinForms.Guna2TextBox txtIpL1F_Host;
        private Guna.UI2.WinForms.Guna2TextBox txtIpL1F_User;
        private Guna.UI2.WinForms.Guna2TextBox txtIpL1F_Pass;
        private Guna.UI2.WinForms.Guna2TextBox txtIpL1F_Rtsp;
        private Guna.UI2.WinForms.Guna2Button btnPreviewIpL1F;
        private Guna.UI2.WinForms.Guna2GroupBox grpIpL2P;
        private Guna.UI2.WinForms.Guna2TextBox txtIpL2P_Host;
        private Guna.UI2.WinForms.Guna2TextBox txtIpL2P_User;
        private Guna.UI2.WinForms.Guna2TextBox txtIpL2P_Pass;
        private Guna.UI2.WinForms.Guna2TextBox txtIpL2P_Rtsp;
        private Guna.UI2.WinForms.Guna2Button btnPreviewIpL2P;
        private Guna.UI2.WinForms.Guna2GroupBox grpIpL2F;
        private Guna.UI2.WinForms.Guna2TextBox txtIpL2F_Host;
        private Guna.UI2.WinForms.Guna2TextBox txtIpL2F_User;
        private Guna.UI2.WinForms.Guna2TextBox txtIpL2F_Pass;
        private Guna.UI2.WinForms.Guna2TextBox txtIpL2F_Rtsp;
        private Guna.UI2.WinForms.Guna2Button btnPreviewIpL2F;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCardType;
        private System.Windows.Forms.Panel pnlCardTypeTools;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private System.Windows.Forms.Panel pnlLoaiTheBottom;
        private Guna.UI2.WinForms.Guna2Button btnGuideCardType;
        private Guna.UI2.WinForms.Guna2Button btnSaveCardType;
        private System.Windows.Forms.Label lblGiaTienDev;
        private System.Windows.Forms.Label lblNangCaoDev;
    }
}
