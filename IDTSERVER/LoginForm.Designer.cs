namespace IDTSERVER
{
    partial class LoginForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.tlpFields = new System.Windows.Forms.TableLayoutPanel();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblShift = new System.Windows.Forms.Label();
            this.cboShift = new Guna.UI2.WinForms.Guna2ComboBox();
            this.chkShowPass = new System.Windows.Forms.CheckBox();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.lblError = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.tlpMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.tlpFields.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpMain.Controls.Add(this.pnlForm, 0, 1);
            this.tlpMain.Controls.Add(this.pnlActions, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(20, 20);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.Size = new System.Drawing.Size(410, 380);
            this.tlpMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(404, 74);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblSubtitle.Location = new System.Drawing.Point(0, 35);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(404, 25);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Vui lòng đăng nhập để bắt đầu ca trực";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(404, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ BÃI XE";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.tlpFields);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(3, 83);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlForm.Size = new System.Drawing.Size(404, 234);
            this.pnlForm.TabIndex = 1;
            // 
            // tlpFields
            // 
            this.tlpFields.ColumnCount = 2;
            this.tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFields.Controls.Add(this.lblUser, 0, 0);
            this.tlpFields.Controls.Add(this.txtUsername, 1, 0);
            this.tlpFields.Controls.Add(this.lblPass, 0, 1);
            this.tlpFields.Controls.Add(this.txtPassword, 1, 1);
            this.tlpFields.Controls.Add(this.lblShift, 0, 2);
            this.tlpFields.Controls.Add(this.cboShift, 1, 2);
            this.tlpFields.Controls.Add(this.chkShowPass, 1, 3);
            this.tlpFields.Controls.Add(this.chkRemember, 1, 4);
            this.tlpFields.Controls.Add(this.lblError, 1, 5);
            this.tlpFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFields.Location = new System.Drawing.Point(10, 0);
            this.tlpFields.Name = "tlpFields";
            this.tlpFields.RowCount = 6;
            this.tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFields.Size = new System.Drawing.Size(384, 234);
            this.tlpFields.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblUser.Location = new System.Drawing.Point(3, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(124, 45);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Tên đăng nhập:";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUsername
            // 
            this.txtUsername.BorderRadius = 5;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(133, 5);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderText = "Nhập tài khoản...";
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(248, 35);
            this.txtUsername.TabIndex = 1;
            // 
            // lblPass
            // 
            this.lblPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblPass.Location = new System.Drawing.Point(3, 45);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(124, 45);
            this.lblPass.TabIndex = 2;
            this.lblPass.Text = "Mật khẩu:";
            this.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderRadius = 5;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(133, 50);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "Nhập mật khẩu...";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(248, 35);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblShift
            // 
            this.lblShift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShift.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblShift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblShift.Location = new System.Drawing.Point(3, 90);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(124, 45);
            this.lblShift.TabIndex = 4;
            this.lblShift.Text = "Ca làm việc:";
            this.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboShift
            // 
            this.cboShift.BackColor = System.Drawing.Color.Transparent;
            this.cboShift.BorderRadius = 5;
            this.cboShift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboShift.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShift.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboShift.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboShift.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboShift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboShift.ItemHeight = 30;
            this.cboShift.Items.AddRange(new object[] {
            "Ca ngày (06:00 - 18:00)",
            "Ca đêm (18:00 - 06:00)"});
            this.cboShift.Location = new System.Drawing.Point(133, 95);
            this.cboShift.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboShift.Name = "cboShift";
            this.cboShift.Size = new System.Drawing.Size(248, 36);
            this.cboShift.StartIndex = 0;
            this.cboShift.TabIndex = 5;
            // 
            // chkShowPass
            // 
            this.chkShowPass.AutoSize = true;
            this.chkShowPass.Location = new System.Drawing.Point(133, 138);
            this.chkShowPass.Name = "chkShowPass";
            this.chkShowPass.Size = new System.Drawing.Size(148, 19);
            this.chkShowPass.TabIndex = 6;
            this.chkShowPass.Text = "Hiển thị mật khẩu";
            this.chkShowPass.UseVisualStyleBackColor = true;
            this.chkShowPass.CheckedChanged += new System.EventHandler(this.chkShowPass_CheckedChanged);
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Location = new System.Drawing.Point(133, 163);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(157, 19);
            this.chkRemember.TabIndex = 7;
            this.chkRemember.Text = "Ghi nhớ đăng nhập";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // lblError
            // 
            this.lblError.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.lblError.Location = new System.Drawing.Point(133, 185);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(248, 23);
            this.lblError.TabIndex = 8;
            this.lblError.Text = "Sai tài khoản hoặc mật khẩu";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Visible = false;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnExit);
            this.pnlActions.Controls.Add(this.btnLogin);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActions.Location = new System.Drawing.Point(3, 323);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(404, 54);
            this.pnlActions.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.BorderRadius = 5;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.Location = new System.Drawing.Point(219, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(175, 40);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Thoát (Esc)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BorderRadius = 5;
            this.btnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(10, 7);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(203, 40);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Đăng nhập (Enter)";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(450, 420);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐĂNG NHẬP CA TRỰC";
            this.tlpMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.tlpFields.ResumeLayout(false);
            this.tlpFields.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.TableLayoutPanel tlpFields;
        private System.Windows.Forms.Label lblUser;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private System.Windows.Forms.Label lblPass;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private System.Windows.Forms.Label lblShift;
        private Guna.UI2.WinForms.Guna2ComboBox cboShift;
        private System.Windows.Forms.CheckBox chkShowPass;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Panel pnlActions;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2Button btnExit;
    }
}
