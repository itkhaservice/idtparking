using System;
using System.Windows.Forms;

namespace IDTSERVER
{
    public partial class ShiftHandoverForm : Form
    {
        public ShiftHandoverForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
