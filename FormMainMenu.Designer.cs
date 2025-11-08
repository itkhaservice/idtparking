namespace IDT_PARKING
{
    partial class FormMainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnDoanhThu = new Guna.UI2.WinForms.Guna2Button();
            this.btnXeThang = new Guna.UI2.WinForms.Guna2Button();
            this.btnXeRa = new Guna.UI2.WinForms.Guna2Button();
            this.btnXeVao = new Guna.UI2.WinForms.Guna2Button();
            this.btnCaiDat = new Guna.UI2.WinForms.Guna2Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.btnDoanhThu);
            this.guna2GradientPanel1.Controls.Add(this.btnXeThang);
            this.guna2GradientPanel1.Controls.Add(this.btnXeRa);
            this.guna2GradientPanel1.Controls.Add(this.btnXeVao);
            this.guna2GradientPanel1.Controls.Add(this.btnCaiDat);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1350, 37);
            this.guna2GradientPanel1.TabIndex = 25;
            // 
            // btnDoanhThu
            // 
            this.btnDoanhThu.BorderRadius = 8;
            this.btnDoanhThu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDoanhThu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDoanhThu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDoanhThu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDoanhThu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(69)))), ((int)(((byte)(115)))));
            this.btnDoanhThu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDoanhThu.ForeColor = System.Drawing.Color.White;
            this.btnDoanhThu.Location = new System.Drawing.Point(128, 3);
            this.btnDoanhThu.Name = "btnDoanhThu";
            this.btnDoanhThu.Size = new System.Drawing.Size(120, 31);
            this.btnDoanhThu.TabIndex = 1;
            this.btnDoanhThu.Text = "Doanh thu";
            this.btnDoanhThu.Click += new System.EventHandler(this.btnDoanhThu_Click);
            // 
            // btnXeThang
            // 
            this.btnXeThang.BorderRadius = 8;
            this.btnXeThang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXeThang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXeThang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXeThang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXeThang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(69)))), ((int)(((byte)(115)))));
            this.btnXeThang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXeThang.ForeColor = System.Drawing.Color.White;
            this.btnXeThang.Location = new System.Drawing.Point(506, 3);
            this.btnXeThang.Name = "btnXeThang";
            this.btnXeThang.Size = new System.Drawing.Size(120, 31);
            this.btnXeThang.TabIndex = 4;
            this.btnXeThang.Text = "Xe tháng";
            this.btnXeThang.Click += new System.EventHandler(this.btnXeThang_Click);
            // 
            // btnXeRa
            // 
            this.btnXeRa.BorderRadius = 8;
            this.btnXeRa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXeRa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXeRa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXeRa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXeRa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(69)))), ((int)(((byte)(115)))));
            this.btnXeRa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXeRa.ForeColor = System.Drawing.Color.White;
            this.btnXeRa.Location = new System.Drawing.Point(380, 3);
            this.btnXeRa.Name = "btnXeRa";
            this.btnXeRa.Size = new System.Drawing.Size(120, 31);
            this.btnXeRa.TabIndex = 3;
            this.btnXeRa.Text = "Xe ra";
            this.btnXeRa.Click += new System.EventHandler(this.btnXeRa_Click);
            // 
            // btnXeVao
            // 
            this.btnXeVao.BorderRadius = 8;
            this.btnXeVao.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXeVao.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXeVao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXeVao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXeVao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(69)))), ((int)(((byte)(115)))));
            this.btnXeVao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXeVao.ForeColor = System.Drawing.Color.White;
            this.btnXeVao.Location = new System.Drawing.Point(254, 3);
            this.btnXeVao.Name = "btnXeVao";
            this.btnXeVao.Size = new System.Drawing.Size(120, 31);
            this.btnXeVao.TabIndex = 2;
            this.btnXeVao.Text = "Xe vào";
            this.btnXeVao.Click += new System.EventHandler(this.btnXeVao_Click);
            // 
            // btnCaiDat
            // 
            this.btnCaiDat.BorderRadius = 8;
            this.btnCaiDat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCaiDat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCaiDat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCaiDat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCaiDat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(69)))), ((int)(((byte)(115)))));
            this.btnCaiDat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCaiDat.ForeColor = System.Drawing.Color.White;
            this.btnCaiDat.Location = new System.Drawing.Point(3, 3);
            this.btnCaiDat.Name = "btnCaiDat";
            this.btnCaiDat.Size = new System.Drawing.Size(120, 31);
            this.btnCaiDat.TabIndex = 0;
            this.btnCaiDat.Text = "Cài đặt";
            this.btnCaiDat.Click += new System.EventHandler(this.btnCaiDat_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 37);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1350, 692);
            this.mainPanel.TabIndex = 26;
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.guna2GradientPanel1);

            this.Name = "FormMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IDT PARKING";
            this.Load += new System.EventHandler(this.FormMainMenu_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Button btnCaiDat;
        private Guna.UI2.WinForms.Guna2Button btnXeThang;
        private Guna.UI2.WinForms.Guna2Button btnXeRa;
        private Guna.UI2.WinForms.Guna2Button btnXeVao;
        private Guna.UI2.WinForms.Guna2Button btnDoanhThu;
        private System.Windows.Forms.Panel mainPanel;
    }
}
