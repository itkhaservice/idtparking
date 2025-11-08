using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace IDT_PARKING
{
    partial class FormTTT
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTTT));
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBackup = new System.Windows.Forms.Button();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSaveTable = new System.Windows.Forms.Button();
            this.btnRevenueCa = new System.Windows.Forms.Button();
            this.btnOpenCus = new System.Windows.Forms.Button();
            this.btnOpenRevenue = new System.Windows.Forms.Button();
            this.btnExportRevenue = new System.Windows.Forms.Button();
            this.btnConsignment = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRevenue = new System.Windows.Forms.Button();
            this.btnMonth = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.timeTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.timeTimeStart = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSQL = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.progressBarExport = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerExportToExcel = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(104, 20);
            this.txtServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(194, 27);
            this.txtServer.TabIndex = 1;
            this.txtServer.Text = "192.168.1.168";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(104, 51);
            this.txtDatabase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(194, 27);
            this.txtDatabase.TabIndex = 2;
            this.txtDatabase.Text = "GIUXE";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(104, 113);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(194, 27);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.Text = "sa";
            this.txtUsername.UseSystemPasswordChar = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(104, 144);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(194, 27);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Text = "123ABC";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "MÁY CHỦ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "DỮ LIỆU";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "TÀI KHOẢN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(12, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "MẬT KHẨU";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConnect.Location = new System.Drawing.Point(171, 175);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(127, 36);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "KẾT NỐI";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuery.Location = new System.Drawing.Point(171, 178);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(128, 36);
            this.btnQuery.TabIndex = 9;
            this.btnQuery.Text = "LỌC";
            this.toolTip1.SetToolTip(this.btnQuery, "Lọc tất cả dữ liệu");
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(0, 0);
            this.dgvResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowHeadersWidth = 51;
            this.dgvResults.Size = new System.Drawing.Size(1021, 773);
            this.dgvResults.TabIndex = 10;
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeStart.Location = new System.Drawing.Point(72, 81);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(121, 27);
            this.dateTimeStart.TabIndex = 12;
            this.dateTimeStart.Value = new System.DateTime(2025, 1, 1, 12, 28, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(16, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "TỪ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(16, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "ĐẾN";
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeEnd.Location = new System.Drawing.Point(72, 114);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(121, 27);
            this.dateTimeEnd.TabIndex = 14;
            this.dateTimeEnd.Value = new System.DateTime(2025, 1, 1, 12, 28, 0, 0);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Location = new System.Drawing.Point(16, 178);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(134, 36);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "CẬP NHẬT";
            this.toolTip1.SetToolTip(this.btnUpdate, "Cập nhật lại giá tiền vãng lai đã ra");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtSum
            // 
            this.txtSum.Enabled = false;
            this.txtSum.Location = new System.Drawing.Point(171, 18);
            this.txtSum.Name = "txtSum";
            this.txtSum.Size = new System.Drawing.Size(127, 27);
            this.txtSum.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(15, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "TỔNG TIỀN";
            // 
            // btnBackup
            // 
            this.btnBackup.Enabled = false;
            this.btnBackup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBackup.Location = new System.Drawing.Point(170, 389);
            this.btnBackup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(128, 36);
            this.btnBackup.TabIndex = 19;
            this.btnBackup.Text = "SAO LƯU";
            this.toolTip1.SetToolTip(this.btnBackup, "Sao lưu toàn bộ dữ liệu máy chủ hệ thống xe");
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(199, 146);
            this.cmbType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(99, 28);
            this.cmbType.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenFolder);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.txtDatabase);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(305, 218);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "KẾT NỐI";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenFolder.Location = new System.Drawing.Point(16, 175);
            this.btnOpenFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(127, 36);
            this.btnOpenFolder.TabIndex = 11;
            this.btnOpenFolder.Text = "MỞ THƯ MỤC";
            this.toolTip1.SetToolTip(this.btnOpenFolder, "Mở thư mục lưu tệp tin Backup trên Server");
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(12, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "THƯ MỤC";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(104, 82);
            this.txtFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(194, 27);
            this.txtFolder.TabIndex = 9;
            this.txtFolder.Text = "hinh";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCount);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnSaveTable);
            this.groupBox2.Controls.Add(this.btnRevenueCa);
            this.groupBox2.Controls.Add(this.btnBackup);
            this.groupBox2.Controls.Add(this.btnOpenCus);
            this.groupBox2.Controls.Add(this.btnOpenRevenue);
            this.groupBox2.Controls.Add(this.btnExportRevenue);
            this.groupBox2.Controls.Add(this.btnConsignment);
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.btnRevenue);
            this.groupBox2.Controls.Add(this.btnMonth);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.timeTimeEnd);
            this.groupBox2.Controls.Add(this.timeTimeStart);
            this.groupBox2.Controls.Add(this.cmbType);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dateTimeStart);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dateTimeEnd);
            this.groupBox2.Controls.Add(this.txtSum);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnQuery);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(3, 224);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(305, 493);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BÁO CÁO";
            // 
            // txtCount
            // 
            this.txtCount.Enabled = false;
            this.txtCount.Location = new System.Drawing.Point(172, 50);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(127, 27);
            this.txtCount.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(16, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 20);
            this.label10.TabIndex = 32;
            this.label10.Text = "SỐ DÒNG DỮ LIỆU";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(16, 218);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(134, 36);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "XÓA";
            this.toolTip1.SetToolTip(this.btnDelete, "Xóa dòng dữ liệu vĩnh viễn");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSaveTable
            // 
            this.btnSaveTable.Enabled = false;
            this.btnSaveTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveTable.Location = new System.Drawing.Point(241, 258);
            this.btnSaveTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveTable.Name = "btnSaveTable";
            this.btnSaveTable.Size = new System.Drawing.Size(57, 36);
            this.btnSaveTable.TabIndex = 30;
            this.btnSaveTable.Text = "LƯU";
            this.btnSaveTable.UseVisualStyleBackColor = true;
            this.btnSaveTable.Click += new System.EventHandler(this.btnSaveTable_Click);
            // 
            // btnRevenueCa
            // 
            this.btnRevenueCa.Enabled = false;
            this.btnRevenueCa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRevenueCa.Location = new System.Drawing.Point(16, 258);
            this.btnRevenueCa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRevenueCa.Name = "btnRevenueCa";
            this.btnRevenueCa.Size = new System.Drawing.Size(219, 36);
            this.btnRevenueCa.TabIndex = 29;
            this.btnRevenueCa.Text = "DOANH THU THEO CA";
            this.toolTip1.SetToolTip(this.btnRevenueCa, "Doanh thu xe vãng lai");
            this.btnRevenueCa.UseVisualStyleBackColor = true;
            this.btnRevenueCa.Click += new System.EventHandler(this.btnRevenueCa_Click);
            // 
            // btnOpenCus
            // 
            this.btnOpenCus.Enabled = false;
            this.btnOpenCus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenCus.Location = new System.Drawing.Point(234, 345);
            this.btnOpenCus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenCus.Name = "btnOpenCus";
            this.btnOpenCus.Size = new System.Drawing.Size(64, 36);
            this.btnOpenCus.TabIndex = 28;
            this.btnOpenCus.Text = "MỞ";
            this.toolTip1.SetToolTip(this.btnOpenCus, "Mở thư mục lưu tệp tin KHÁCH HÀNG");
            this.btnOpenCus.UseVisualStyleBackColor = true;
            this.btnOpenCus.Click += new System.EventHandler(this.btnOpenCus_Click);
            // 
            // btnOpenRevenue
            // 
            this.btnOpenRevenue.Enabled = false;
            this.btnOpenRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenRevenue.Location = new System.Drawing.Point(82, 345);
            this.btnOpenRevenue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenRevenue.Name = "btnOpenRevenue";
            this.btnOpenRevenue.Size = new System.Drawing.Size(64, 36);
            this.btnOpenRevenue.TabIndex = 27;
            this.btnOpenRevenue.Text = "MỞ";
            this.toolTip1.SetToolTip(this.btnOpenRevenue, "Mở thư mục lưu tệp tin DOANH THU");
            this.btnOpenRevenue.UseVisualStyleBackColor = true;
            this.btnOpenRevenue.Click += new System.EventHandler(this.btnOpenRevenue_Click);
            // 
            // btnExportRevenue
            // 
            this.btnExportRevenue.Enabled = false;
            this.btnExportRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportRevenue.Location = new System.Drawing.Point(16, 345);
            this.btnExportRevenue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportRevenue.Name = "btnExportRevenue";
            this.btnExportRevenue.Size = new System.Drawing.Size(60, 36);
            this.btnExportRevenue.TabIndex = 26;
            this.btnExportRevenue.Text = "LƯU";
            this.btnExportRevenue.UseVisualStyleBackColor = true;
            this.btnExportRevenue.Click += new System.EventHandler(this.btnExportRevenue_Click);
            // 
            // btnConsignment
            // 
            this.btnConsignment.Enabled = false;
            this.btnConsignment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConsignment.Location = new System.Drawing.Point(171, 305);
            this.btnConsignment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConsignment.Name = "btnConsignment";
            this.btnConsignment.Size = new System.Drawing.Size(127, 36);
            this.btnConsignment.TabIndex = 24;
            this.btnConsignment.Text = "KHÁCH HÀNG";
            this.toolTip1.SetToolTip(this.btnConsignment, "Danh sách thẻ tháng đến hiện tại");
            this.btnConsignment.UseVisualStyleBackColor = true;
            this.btnConsignment.Click += new System.EventHandler(this.btnConsignment_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExport.Location = new System.Drawing.Point(171, 345);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(57, 36);
            this.btnExport.TabIndex = 25;
            this.btnExport.Text = "LƯU";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRevenue
            // 
            this.btnRevenue.Enabled = false;
            this.btnRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRevenue.Location = new System.Drawing.Point(16, 305);
            this.btnRevenue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.Size = new System.Drawing.Size(130, 36);
            this.btnRevenue.TabIndex = 23;
            this.btnRevenue.Text = "DOANH THU";
            this.toolTip1.SetToolTip(this.btnRevenue, "Doanh thu xe vãng lai");
            this.btnRevenue.UseVisualStyleBackColor = true;
            this.btnRevenue.Click += new System.EventHandler(this.btnRevenue_Click);
            // 
            // btnMonth
            // 
            this.btnMonth.Location = new System.Drawing.Point(171, 218);
            this.btnMonth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(127, 36);
            this.btnMonth.TabIndex = 22;
            this.btnMonth.Text = "THÁNG";
            this.toolTip1.SetToolTip(this.btnMonth, "Doanh thu các ngày trong tháng");
            this.btnMonth.UseVisualStyleBackColor = true;
            this.btnMonth.Click += new System.EventHandler(this.btnMonth_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(16, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "LOẠI THẺ";
            // 
            // timeTimeEnd
            // 
            this.timeTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeTimeEnd.Location = new System.Drawing.Point(199, 114);
            this.timeTimeEnd.Name = "timeTimeEnd";
            this.timeTimeEnd.Size = new System.Drawing.Size(99, 27);
            this.timeTimeEnd.TabIndex = 15;
            this.timeTimeEnd.Value = new System.DateTime(2025, 5, 27, 6, 30, 0, 0);
            // 
            // timeTimeStart
            // 
            this.timeTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeTimeStart.Location = new System.Drawing.Point(199, 81);
            this.timeTimeStart.Name = "timeTimeStart";
            this.timeTimeStart.Size = new System.Drawing.Size(99, 27);
            this.timeTimeStart.TabIndex = 14;
            this.timeTimeStart.Value = new System.DateTime(2025, 8, 8, 0, 0, 0, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnSQL);
            this.splitContainer1.Panel1.Controls.Add(this.btnCheck);
            this.splitContainer1.Panel1.Controls.Add(this.progressBarExport);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvResults);
            this.splitContainer1.Size = new System.Drawing.Size(1343, 773);
            this.splitContainer1.SplitterDistance = 318;
            this.splitContainer1.TabIndex = 24;
            // 
            // btnSQL
            // 
            this.btnSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSQL.Location = new System.Drawing.Point(19, 657);
            this.btnSQL.Name = "btnSQL";
            this.btnSQL.Size = new System.Drawing.Size(282, 37);
            this.btnSQL.TabIndex = 30;
            this.btnSQL.Text = "TRUY VẤN";
            this.btnSQL.UseVisualStyleBackColor = true;
            this.btnSQL.Click += new System.EventHandler(this.btnSQL_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Enabled = false;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(19, 614);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(130, 37);
            this.btnCheck.TabIndex = 29;
            this.btnCheck.Text = "KIỂM TRA";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // progressBarExport
            // 
            this.progressBarExport.Location = new System.Drawing.Point(19, 722);
            this.progressBarExport.Name = "progressBarExport";
            this.progressBarExport.Size = new System.Drawing.Size(275, 14);
            this.progressBarExport.TabIndex = 26;
            this.progressBarExport.Visible = false;
            // 
            // FormTTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 773);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormTTT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAO LƯU DỮ LIỆU HỆ THỐNG XE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTTT_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox txtServer;
        private TextBox txtDatabase;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnConnect;
        private Button btnQuery;
        private DataGridView dgvResults;
        private DateTimePicker dateTimeStart;
        private Label label5;
        private Label label6;
        private DateTimePicker dateTimeEnd;
        private Button btnUpdate;
        private TextBox txtSum;
        private Label label7;
        private Button btnBackup;
        private ComboBox cmbType;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DateTimePicker timeTimeEnd;
        private DateTimePicker timeTimeStart;
        private Label label8;
        private Button btnMonth;
        private Label label9;
        private TextBox txtFolder;
        private Button btnConsignment;
        private Button btnRevenue;
        private SplitContainer splitContainer1;
        private ProgressBar progressBarExport;
        private System.ComponentModel.BackgroundWorker backgroundWorkerExportToExcel;
        private Button btnExport;
        private Button btnExportRevenue;
        private Button btnOpenFolder;
        private ToolTip toolTip1;
        private Button btnOpenRevenue;
        private Button btnRevenueCa;
        private Button btnSaveTable;
        private Button btnOpenCus;
        private Button btnCheck;
        private Button btnDelete;
        private Button btnSQL;
        private TextBox txtCount;
        private Label label10;
    }
}
