using System;
using System.Drawing;
using System.Windows.Forms;

namespace IDT_PARKING
{
    public partial class CustomMessageBoxForm : Form
    {
        public CustomMessageBoxForm(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            InitializeComponent();
            lblMessage.Text = message;
            lblTitle.Text = title;
            SetupButtons(buttons);
            SetupIcon(icon);
        }

        private void SetupButtons(MessageBoxButtons buttons)
        {
            // Reset visibility
            btn1.Visible = false;
            btn2.Visible = false;
            btn3.Visible = false;

            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    SetupButton(btn1, "OK", DialogResult.OK);
                    btn1.Location = new Point(410, 185);
                    break;
                case MessageBoxButtons.OKCancel:
                    SetupButton(btn1, "OK", DialogResult.OK);
                    SetupButton(btn2, "Hủy", DialogResult.Cancel);
                    break;
                case MessageBoxButtons.YesNo:
                    SetupButton(btn1, "Có", DialogResult.Yes);
                    SetupButton(btn2, "Không", DialogResult.No);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    SetupButton(btn1, "Có", DialogResult.Yes);
                    SetupButton(btn2, "Không", DialogResult.No);
                    SetupButton(btn3, "Hủy", DialogResult.Cancel);
                    break;
            }
        }

        private void SetupButton(Guna.UI2.WinForms.Guna2Button btn, string text, DialogResult result)
        {
            btn.Text = text;
            btn.Visible = true;
            btn.DialogResult = DialogResult.None; // Ensure button doesn't handle dialog result automatically
            btn.Click += (s, e) =>
            {
                this.DialogResult = result;
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SetupIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Information:
                    picIcon.Image = SystemIcons.Information.ToBitmap();
                    break;
                case MessageBoxIcon.Warning:
                    picIcon.Image = SystemIcons.Warning.ToBitmap();
                    break;
                case MessageBoxIcon.Error:
                    picIcon.Image = SystemIcons.Error.ToBitmap();
                    break;
                case MessageBoxIcon.Question:
                    picIcon.Image = SystemIcons.Question.ToBitmap();
                    break;
                default:
                    picIcon.Visible = false;
                    lblTitle.Location = new Point(30, 23);
                    break;
            }
        }
    }

    public static class CustomMessageBox
    {
        public static DialogResult Show(string message)
        {
            return Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        public static DialogResult Show(string message, string title)
        {
            return Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        public static DialogResult Show(string message, string title, MessageBoxButtons buttons)
        {
            return Show(message, title, buttons, MessageBoxIcon.None);
        }

        public static DialogResult Show(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            using (var form = new CustomMessageBoxForm(message, title, buttons, icon))
            {
                return form.ShowDialog();
            }
        }

        public static DialogResult Show(IWin32Window owner, string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            using (var form = new CustomMessageBoxForm(message, title, buttons, icon))
            {
                return form.ShowDialog(owner);
            }
        }
    }
}
