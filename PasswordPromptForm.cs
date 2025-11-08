using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDT_PARKING
{
    public partial class PasswordPromptForm : Form
    {
        private string _password;

        public string EnteredPassword
        {
            get { return _password; }
        }
        public PasswordPromptForm()
        {
            InitializeComponent();
            this.txtLicense.KeyPress += new KeyPressEventHandler(txtPassword_KeyPress);
            this.AcceptButton = btnOK;
        }

        // Sự kiện Click cho nút OK
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Lấy mật khẩu từ TextBox
            _password = txtLicense.Text;
            this.DialogResult = DialogResult.OK; // Đặt kết quả hộp thoại là OK
            this.Close(); // Đóng hộp thoại
        }

        // Xử lý sự kiện KeyPress trên TextBox để nhấn Enter cũng như nhấn nút OK
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnOK_Click(sender, e); // Kích hoạt sự kiện click của nút OK
                e.Handled = true; // Ngăn không cho ký tự Enter hiển thị trong TextBox
            }
        }

        private void txtLicense_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
