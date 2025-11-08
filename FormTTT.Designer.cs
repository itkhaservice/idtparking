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
            this.backgroundWorkerExportToExcel = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnQuery = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.timeTimeStart = new System.Windows.Forms.DateTimePicker();
            this.timeTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnMonth = new System.Windows.Forms.Button();
            this.btnRevenue = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnConsignment = new System.Windows.Forms.Button();
            this.btnExportRevenue = new System.Windows.Forms.Button();
            this.btnOpenRevenue = new System.Windows.Forms.Button();
            this.btnOpenCus = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRevenueCa = new System.Windows.Forms.Button();
            this.btnSaveTable = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.progressBarExport = new System.Windows.Forms.ProgressBar();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.btnSQL = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCaiDat = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuery.Location = new System.Drawing.Point(782, 576);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(96, 29);
            this.btnQuery.TabIndex = 9;
            this.btnQuery.Text = "LỌC";
            this.toolTip1.SetToolTip(this.btnQuery, "Lọc tất cả dữ liệu");
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(272, 604);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "ĐẾN";
            // 
            // txtSum
            // 
            this.txtSum.Enabled = false;
            this.txtSum.Location = new System.Drawing.Point(157, 576);
            this.txtSum.Margin = new System.Windows.Forms.Padding(2);
            this.txtSum.Name = "txtSum";
            this.txtSum.Size = new System.Drawing.Size(96, 20);
            this.txtSum.TabIndex = 17;
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeEnd.Location = new System.Drawing.Point(314, 600);
            this.dateTimeEnd.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(92, 20);
            this.dateTimeEnd.TabIndex = 14;
            this.dateTimeEnd.Value = new System.DateTime(2025, 1, 1, 12, 28, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(40, 580);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "TỔNG TIỀN";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Location = new System.Drawing.Point(666, 576);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 29);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "CẬP NHẬT";
            this.toolTip1.SetToolTip(this.btnUpdate, "Cập nhật lại giá tiền vãng lai đã ra");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeStart.Location = new System.Drawing.Point(314, 573);
            this.dateTimeStart.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(92, 20);
            this.dateTimeStart.TabIndex = 12;
            this.dateTimeStart.Value = new System.DateTime(2025, 1, 1, 12, 28, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(272, 577);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "TỪ";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(577, 574);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(75, 21);
            this.cmbType.TabIndex = 20;
            // 
            // timeTimeStart
            // 
            this.timeTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeTimeStart.Location = new System.Drawing.Point(409, 573);
            this.timeTimeStart.Margin = new System.Windows.Forms.Padding(2);
            this.timeTimeStart.Name = "timeTimeStart";
            this.timeTimeStart.Size = new System.Drawing.Size(75, 20);
            this.timeTimeStart.TabIndex = 14;
            this.timeTimeStart.Value = new System.DateTime(2025, 8, 8, 0, 0, 0, 0);
            // 
            // timeTimeEnd
            // 
            this.timeTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeTimeEnd.Location = new System.Drawing.Point(409, 600);
            this.timeTimeEnd.Margin = new System.Windows.Forms.Padding(2);
            this.timeTimeEnd.Name = "timeTimeEnd";
            this.timeTimeEnd.Size = new System.Drawing.Size(75, 20);
            this.timeTimeEnd.TabIndex = 15;
            this.timeTimeEnd.Value = new System.DateTime(2025, 5, 27, 6, 30, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(496, 574);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 21;
            this.label8.Text = "LOẠI THẺ";
            // 
            // btnMonth
            // 
            this.btnMonth.Location = new System.Drawing.Point(782, 608);
            this.btnMonth.Margin = new System.Windows.Forms.Padding(2);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(95, 29);
            this.btnMonth.TabIndex = 22;
            this.btnMonth.Text = "THÁNG";
            this.toolTip1.SetToolTip(this.btnMonth, "Doanh thu các ngày trong tháng");
            this.btnMonth.UseVisualStyleBackColor = true;
            this.btnMonth.Click += new System.EventHandler(this.btnMonth_Click);
            // 
            // btnRevenue
            // 
            this.btnRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRevenue.Location = new System.Drawing.Point(1109, 577);
            this.btnRevenue.Margin = new System.Windows.Forms.Padding(2);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.Size = new System.Drawing.Size(98, 29);
            this.btnRevenue.TabIndex = 23;
            this.btnRevenue.Text = "DOANH THU";
            this.toolTip1.SetToolTip(this.btnRevenue, "Doanh thu xe vãng lai");
            this.btnRevenue.UseVisualStyleBackColor = true;
            this.btnRevenue.Click += new System.EventHandler(this.btnRevenue_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExport.Location = new System.Drawing.Point(1225, 609);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(43, 29);
            this.btnExport.TabIndex = 25;
            this.btnExport.Text = "LƯU";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnConsignment
            // 
            this.btnConsignment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConsignment.Location = new System.Drawing.Point(1225, 577);
            this.btnConsignment.Margin = new System.Windows.Forms.Padding(2);
            this.btnConsignment.Name = "btnConsignment";
            this.btnConsignment.Size = new System.Drawing.Size(95, 29);
            this.btnConsignment.TabIndex = 24;
            this.btnConsignment.Text = "KHÁCH HÀNG";
            this.toolTip1.SetToolTip(this.btnConsignment, "Danh sách thẻ tháng đến hiện tại");
            this.btnConsignment.UseVisualStyleBackColor = true;
            this.btnConsignment.Click += new System.EventHandler(this.btnConsignment_Click);
            // 
            // btnExportRevenue
            // 
            this.btnExportRevenue.Enabled = false;
            this.btnExportRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportRevenue.Location = new System.Drawing.Point(1109, 609);
            this.btnExportRevenue.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportRevenue.Name = "btnExportRevenue";
            this.btnExportRevenue.Size = new System.Drawing.Size(45, 29);
            this.btnExportRevenue.TabIndex = 26;
            this.btnExportRevenue.Text = "LƯU";
            this.btnExportRevenue.UseVisualStyleBackColor = true;
            this.btnExportRevenue.Click += new System.EventHandler(this.btnExportRevenue_Click);
            // 
            // btnOpenRevenue
            // 
            this.btnOpenRevenue.Enabled = false;
            this.btnOpenRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenRevenue.Location = new System.Drawing.Point(1159, 609);
            this.btnOpenRevenue.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenRevenue.Name = "btnOpenRevenue";
            this.btnOpenRevenue.Size = new System.Drawing.Size(48, 29);
            this.btnOpenRevenue.TabIndex = 27;
            this.btnOpenRevenue.Text = "MỞ";
            this.toolTip1.SetToolTip(this.btnOpenRevenue, "Mở thư mục lưu tệp tin DOANH THU");
            this.btnOpenRevenue.UseVisualStyleBackColor = true;
            this.btnOpenRevenue.Click += new System.EventHandler(this.btnOpenRevenue_Click);
            // 
            // btnOpenCus
            // 
            this.btnOpenCus.Enabled = false;
            this.btnOpenCus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenCus.Location = new System.Drawing.Point(1273, 609);
            this.btnOpenCus.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenCus.Name = "btnOpenCus";
            this.btnOpenCus.Size = new System.Drawing.Size(48, 29);
            this.btnOpenCus.TabIndex = 28;
            this.btnOpenCus.Text = "MỞ";
            this.toolTip1.SetToolTip(this.btnOpenCus, "Mở thư mục lưu tệp tin KHÁCH HÀNG");
            this.btnOpenCus.UseVisualStyleBackColor = true;
            this.btnOpenCus.Click += new System.EventHandler(this.btnOpenCus_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBackup.Location = new System.Drawing.Point(1222, 644);
            this.btnBackup.Margin = new System.Windows.Forms.Padding(2);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(96, 29);
            this.btnBackup.TabIndex = 19;
            this.btnBackup.Text = "SAO LƯU";
            this.toolTip1.SetToolTip(this.btnBackup, "Sao lưu toàn bộ dữ liệu máy chủ hệ thống xe");
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRevenueCa
            // 
            this.btnRevenueCa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRevenueCa.Location = new System.Drawing.Point(882, 577);
            this.btnRevenueCa.Margin = new System.Windows.Forms.Padding(2);
            this.btnRevenueCa.Name = "btnRevenueCa";
            this.btnRevenueCa.Size = new System.Drawing.Size(164, 29);
            this.btnRevenueCa.TabIndex = 29;
            this.btnRevenueCa.Text = "DOANH THU THEO CA";
            this.toolTip1.SetToolTip(this.btnRevenueCa, "Doanh thu xe vãng lai");
            this.btnRevenueCa.UseVisualStyleBackColor = true;
            this.btnRevenueCa.Click += new System.EventHandler(this.btnRevenueCa_Click);
            // 
            // btnSaveTable
            // 
            this.btnSaveTable.Enabled = false;
            this.btnSaveTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveTable.Location = new System.Drawing.Point(1051, 577);
            this.btnSaveTable.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveTable.Name = "btnSaveTable";
            this.btnSaveTable.Size = new System.Drawing.Size(43, 29);
            this.btnSaveTable.TabIndex = 30;
            this.btnSaveTable.Text = "LƯU";
            this.btnSaveTable.UseVisualStyleBackColor = true;
            this.btnSaveTable.Click += new System.EventHandler(this.btnSaveTable_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(666, 608);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 29);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "XÓA";
            this.toolTip1.SetToolTip(this.btnDelete, "Xóa dòng dữ liệu vĩnh viễn");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(41, 604);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 15);
            this.label10.TabIndex = 32;
            this.label10.Text = "SỐ DÒNG DỮ LIỆU";
            // 
            // progressBarExport
            // 
            this.progressBarExport.Location = new System.Drawing.Point(44, 682);
            this.progressBarExport.Margin = new System.Windows.Forms.Padding(2);
            this.progressBarExport.Name = "progressBarExport";
            this.progressBarExport.Size = new System.Drawing.Size(1050, 30);
            this.progressBarExport.TabIndex = 26;
            this.progressBarExport.Visible = false;
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(1109, 647);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(98, 30);
            this.btnCheck.TabIndex = 29;
            this.btnCheck.Text = "KIỂM TRA";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtCount
            // 
            this.txtCount.Enabled = false;
            this.txtCount.Location = new System.Drawing.Point(158, 602);
            this.txtCount.Margin = new System.Windows.Forms.Padding(2);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(96, 20);
            this.txtCount.TabIndex = 33;
            // 
            // btnSQL
            // 
            this.btnSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSQL.Location = new System.Drawing.Point(1109, 682);
            this.btnSQL.Margin = new System.Windows.Forms.Padding(2);
            this.btnSQL.Name = "btnSQL";
            this.btnSQL.Size = new System.Drawing.Size(212, 30);
            this.btnSQL.TabIndex = 30;
            this.btnSQL.Text = "TRUY VẤN";
            this.btnSQL.UseVisualStyleBackColor = true;
            this.btnSQL.Click += new System.EventHandler(this.btnSQL_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(11, 48);
            this.dgvResults.Margin = new System.Windows.Forms.Padding(2);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowHeadersWidth = 51;
            this.dgvResults.Size = new System.Drawing.Size(1327, 521);
            this.dgvResults.TabIndex = 10;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnCaiDat);
            this.guna2Panel1.Location = new System.Drawing.Point(11, 4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1327, 39);
            this.guna2Panel1.TabIndex = 25;
            // 
            // btnCaiDat
            // 
            this.btnCaiDat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCaiDat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCaiDat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCaiDat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCaiDat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(69)))), ((int)(((byte)(115)))));
            this.btnCaiDat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCaiDat.ForeColor = System.Drawing.Color.White;
            this.btnCaiDat.Location = new System.Drawing.Point(3, 3);
            this.btnCaiDat.Name = "btnCaiDat";
            this.btnCaiDat.Size = new System.Drawing.Size(129, 33);
            this.btnCaiDat.TabIndex = 0;
            this.btnCaiDat.Text = "Cài đặt";
            this.btnCaiDat.Click += new System.EventHandler(this.btnCaiDat_Click);
            // 
            // FormTTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.btnSQL);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.timeTimeEnd);
            this.Controls.Add(this.timeTimeStart);
            this.Controls.Add(this.btnSaveTable);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRevenueCa);
            this.Controls.Add(this.dateTimeStart);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimeEnd);
            this.Controls.Add(this.btnMonth);
            this.Controls.Add(this.txtSum);
            this.Controls.Add(this.progressBarExport);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnRevenue);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnConsignment);
            this.Controls.Add(this.btnExportRevenue);
            this.Controls.Add(this.btnOpenRevenue);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnOpenCus);
            this.Controls.Add(this.btnQuery);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormTTT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAO LƯU DỮ LIỆU HỆ THỐNG XE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTTT_FormClosing);
            this.Load += new System.EventHandler(this.FormTTT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorkerExportToExcel;
        private ToolTip toolTip1;
        private Button btnSQL;
        private TextBox txtCount;
        private Button btnCheck;
        private ProgressBar progressBarExport;
        private Label label10;
        private Button btnDelete;
        private Button btnSaveTable;
        private Button btnRevenueCa;
        private Button btnBackup;
        private Button btnOpenCus;
        private Button btnOpenRevenue;
        private Button btnExportRevenue;
        private Button btnConsignment;
        private Button btnExport;
        private Button btnRevenue;
        private Button btnMonth;
        private Label label8;
        private DateTimePicker timeTimeEnd;
        private DateTimePicker timeTimeStart;
        private ComboBox cmbType;
        private Label label5;
        private DateTimePicker dateTimeStart;
        private Button btnUpdate;
        private Label label7;
        private DateTimePicker dateTimeEnd;
        private TextBox txtSum;
        private Label label6;
        private Button btnQuery;
        private DataGridView dgvResults;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnCaiDat;
    }
}
