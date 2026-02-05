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
            
            // Adjust form height based on label content
            int padding = 20;
            int buttonHeight = 50;
            int requiredHeight = lblMessage.Bottom + padding + buttonHeight;
            
            if (requiredHeight > this.Height)
            {
                this.Height = requiredHeight;
            }

            SetupButtons(buttons);
            SetupIcon(icon);
        }

        private void SetupButtons(MessageBoxButtons buttons)
        {
            // Reset visibility
            btn1.Visible = false;
            btn2.Visible = false;
            btn3.Visible = false;

            int btnY = this.Height - 45; // Position buttons at the bottom of the resized form

            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    SetupButton(btn1, "OK", DialogResult.OK);
                    btn1.Location = new Point(this.Width - btn1.Width - 15, btnY);
                    break;
                case MessageBoxButtons.OKCancel:
                    SetupButton(btn1, "OK", DialogResult.OK);
                    SetupButton(btn2, "Hủy", DialogResult.Cancel);
                    btn1.Location = new Point(this.Width - btn1.Width - 15, btnY);
                    btn2.Location = new Point(btn1.Left - btn2.Width - 10, btnY);
                    break;
                case MessageBoxButtons.YesNo:
                    SetupButton(btn1, "Có", DialogResult.Yes);
                    SetupButton(btn2, "Không", DialogResult.No);
                    btn1.Location = new Point(this.Width - btn1.Width - 15, btnY);
                    btn2.Location = new Point(btn1.Left - btn2.Width - 10, btnY);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    SetupButton(btn1, "Có", DialogResult.Yes);
                    SetupButton(btn2, "Không", DialogResult.No);
                    SetupButton(btn3, "Hủy", DialogResult.Cancel);
                    btn1.Location = new Point(this.Width - btn1.Width - 15, btnY);
                    btn2.Location = new Point(btn1.Left - btn2.Width - 10, btnY);
                    btn3.Location = new Point(btn2.Left - btn3.Width - 10, btnY);
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
