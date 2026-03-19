using System;
using System.Windows.Forms;

namespace IDTSERVER
{
    public partial class LoginForm : Form
    {
        public string CurrentUser { get; private set; } = "";
        public string CurrentShift { get; private set; } = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Mô phỏng kiểm tra đăng nhập
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                lblError.Text = "Vui lòng nhập đầy đủ thông tin";
                lblError.Visible = true;
                return;
            }

            // Giả định mọi tài khoản đều đúng để test UI
            CurrentUser = txtUsername.Text;
            CurrentShift = cboShift.SelectedItem.ToString();
            
            this.DialogResult = DialogResult.OK;
            this.Close();
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
