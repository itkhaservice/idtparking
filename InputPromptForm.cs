using System;
using System.Windows.Forms;

namespace IDT_PARKING
{
    public partial class InputPromptForm : Form
    {
        public string InputText { get; private set; }

        public InputPromptForm(string promptMessage, string title = "Nhập thông tin")
        {
            InitializeComponent();
            this.Text = title;
            this.lblPrompt.Text = promptMessage; // Assuming label1 is renamed to lblPrompt
            this.txtInput.KeyPress += new KeyPressEventHandler(txtInput_KeyPress); // Assuming txtLicense is renamed to txtInput
            this.AcceptButton = btnOK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            InputText = txtInput.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnOK_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
