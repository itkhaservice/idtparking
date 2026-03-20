using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace IDTSERVER
{
    public partial class LoginForm : Form
    {
        public string CurrentUser { get; private set; } = "";
        public string CurrentShift { get; private set; } = "";
        public string FullName { get; private set; } = "";

        private AppSettings _settings;

        public LoginForm()
        {
            InitializeComponent();
            _settings = AppSettings.Load();
            if (cboShift.Items.Count > 0) cboShift.SelectedIndex = 0;
            
            // Cho phép Form nhận sự kiện phím
            this.KeyPreview = true;
            this.KeyDown += LoginForm_KeyDown;
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Hotkeys resize ứng dụng ngay từ màn hình Login
            if (e.KeyCode == Keys.F5) { this.Owner.WindowState = FormWindowState.Normal; this.Owner.Size = new Size(1366, 768); }
            if (e.KeyCode == Keys.F6) { this.Owner.WindowState = FormWindowState.Normal; this.Owner.Size = new Size(1600, 900); }
            if (e.KeyCode == Keys.F7) { this.Owner.WindowState = FormWindowState.Normal; this.Owner.Size = new Size(1920, 1080); }
            
            // F12 để BYPASS (Vào thẳng không cần DB) để Test UI Main
            if (e.KeyCode == Keys.F12)
            {
                CurrentUser = "admin_test";
                FullName = "Người Kiểm Thử";
                CurrentShift = "Ca Test";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                lblError.Text = "Vui lòng nhập đầy đủ thông tin";
                lblError.Visible = true;
                return;
            }

            string connString = _settings.GetConnectionString();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"SELECT l.username, nv.Hoten 
                                    FROM [login] l
                                    JOIN NhanVien nv ON l.MaNV = nv.MaNV
                                    WHERE l.username = @user AND l.pass = @pass";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim());

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            CurrentUser = reader["username"].ToString();
                            FullName = reader["Hoten"].ToString();
                            CurrentShift = cboShift.SelectedItem?.ToString() ?? "Ca 1";
                            
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            lblError.Text = "Sai tên đăng nhập hoặc mật khẩu!";
                            lblError.Visible = true;
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Lỗi kết nối: " + ex.Message;
                lblError.Visible = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPass.Checked;
            txtPassword.PasswordChar = chkShowPass.Checked ? '\0' : '●';
        }
    }
}
