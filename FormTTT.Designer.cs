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
            this.btnConsignment = new System.Windows.Forms.Button();
            this.btnOpenCus = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnSQL = new System.Windows.Forms.Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCaiDat = new Guna.UI2.WinForms.Guna2Button();
            this.btnXeRa = new Guna.UI2.WinForms.Guna2Button();
            this.btnXeVao = new Guna.UI2.WinForms.Guna2Button();
            this.btnDoanhThu = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConsignment
            // 
            this.btnConsignment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConsignment.Location = new System.Drawing.Point(1227, 620);
            this.btnConsignment.Margin = new System.Windows.Forms.Padding(2);
            this.btnConsignment.Name = "btnConsignment";
            this.btnConsignment.Size = new System.Drawing.Size(95, 29);
            this.btnConsignment.TabIndex = 24;
            this.btnConsignment.Text = "KHÁCH HÀNG";
            this.toolTip1.SetToolTip(this.btnConsignment, "Danh sách thẻ tháng đến hiện tại");
            this.btnConsignment.UseVisualStyleBackColor = true;
            //this.btnConsignment.Click += new System.EventHandler(this.btnConsignment_Click);
            // 
            // btnOpenCus
            // 
            this.btnOpenCus.Enabled = false;
            this.btnOpenCus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenCus.Location = new System.Drawing.Point(1275, 652);
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
            this.btnBackup.Location = new System.Drawing.Point(1224, 687);
            this.btnBackup.Margin = new System.Windows.Forms.Padding(2);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(96, 29);
            this.btnBackup.TabIndex = 19;
            this.btnBackup.Text = "SAO LƯU";
            this.toolTip1.SetToolTip(this.btnBackup, "Sao lưu toàn bộ dữ liệu máy chủ hệ thống xe");
            this.btnBackup.UseVisualStyleBackColor = true;
            //this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExport.Location = new System.Drawing.Point(1227, 652);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(43, 29);
            this.btnExport.TabIndex = 25;
            this.btnExport.Text = "LƯU";
            this.btnExport.UseVisualStyleBackColor = true;
            //this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(1111, 690);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(98, 30);
            this.btnCheck.TabIndex = 29;
            this.btnCheck.Text = "KIỂM TRA";
            this.btnCheck.UseVisualStyleBackColor = true;
            //this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnSQL
            // 
            this.btnSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSQL.Location = new System.Drawing.Point(1111, 725);
            this.btnSQL.Margin = new System.Windows.Forms.Padding(2);
            this.btnSQL.Name = "btnSQL";
            this.btnSQL.Size = new System.Drawing.Size(212, 30);
            this.btnSQL.TabIndex = 30;
            this.btnSQL.Text = "TRUY VẤN";
            this.btnSQL.UseVisualStyleBackColor = true;
            //this.btnSQL.Click += new System.EventHandler(this.btnSQL_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnDoanhThu);
            this.guna2Panel1.Controls.Add(this.btnXeVao);
            this.guna2Panel1.Controls.Add(this.btnXeRa);
            this.guna2Panel1.Controls.Add(this.btnCaiDat);
            this.guna2Panel1.Location = new System.Drawing.Point(11, 4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1343, 39);
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
            //this.btnCaiDat.Click += new System.EventHandler(this.btnCaiDat_Click);
            // 
            // btnXeRa
            // 
            this.btnXeRa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXeRa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXeRa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXeRa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXeRa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(69)))), ((int)(((byte)(115)))));
            this.btnXeRa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXeRa.ForeColor = System.Drawing.Color.White;
            this.btnXeRa.Location = new System.Drawing.Point(273, 3);
            this.btnXeRa.Name = "btnXeRa";
            this.btnXeRa.Size = new System.Drawing.Size(129, 33);
            this.btnXeRa.TabIndex = 1;
            this.btnXeRa.Text = "Xe ra";
            // 
            // btnXeVao
            // 
            this.btnXeVao.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXeVao.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXeVao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXeVao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXeVao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(69)))), ((int)(((byte)(115)))));
            this.btnXeVao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXeVao.ForeColor = System.Drawing.Color.White;
            this.btnXeVao.Location = new System.Drawing.Point(138, 3);
            this.btnXeVao.Name = "btnXeVao";
            this.btnXeVao.Size = new System.Drawing.Size(129, 33);
            this.btnXeVao.TabIndex = 2;
            this.btnXeVao.Text = "Xe vào";
            // 
            // btnDoanhThu
            // 
            this.btnDoanhThu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDoanhThu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDoanhThu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDoanhThu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDoanhThu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(69)))), ((int)(((byte)(115)))));
            this.btnDoanhThu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDoanhThu.ForeColor = System.Drawing.Color.White;
            this.btnDoanhThu.Location = new System.Drawing.Point(408, 3);
            this.btnDoanhThu.Name = "btnDoanhThu";
            this.btnDoanhThu.Size = new System.Drawing.Size(129, 33);
            this.btnDoanhThu.TabIndex = 3;
            this.btnDoanhThu.Text = "Doanh thu";
            // 
            // FormTTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.btnSQL);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnConsignment);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnOpenCus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormTTT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAO LƯU DỮ LIỆU HỆ THỐNG XE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTTT_FormClosing);
            //this.Load += new System.EventHandler(this.FormTTT_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorkerExportToExcel;
        private ToolTip toolTip1;
        private Button btnSQL;
        private Button btnCheck;
        private Button btnBackup;
        private Button btnOpenCus;
        private Button btnConsignment;
        private Button btnExport;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnCaiDat;
        private Guna.UI2.WinForms.Guna2Button btnXeVao;
        private Guna.UI2.WinForms.Guna2Button btnXeRa;
        private Guna.UI2.WinForms.Guna2Button btnDoanhThu;
    }
}
