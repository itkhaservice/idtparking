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
    public partial class MonthYearSelectorDialog : Form
    {
        private ComboBox monthComboBox;
        private NumericUpDown yearNumericUpDown;

        public int SelectedMonth { get; private set; }
        public int SelectedYear { get; private set; }



        public MonthYearSelectorDialog()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Select Month/Year";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ClientSize = new System.Drawing.Size(200, 150);

            Label monthLabel = new Label() { Text = "Month:", Left = 20, Top = 20, Width = 50 };
            this.Controls.Add(monthLabel);

            monthComboBox = new ComboBox()
            {
                Left = 75,
                Top = 17,
                Width = 100,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            for (int i = 1; i <= 12; i++)
            {
                monthComboBox.Items.Add(i);
            }
            monthComboBox.SelectedIndex = DateTime.Now.Month - 1;
            this.Controls.Add(monthComboBox);

            Label yearLabel = new Label() { Text = "Year:", Left = 20, Top = 50, Width = 50 };
            this.Controls.Add(yearLabel);

            yearNumericUpDown = new NumericUpDown()
            {
                Left = 75,
                Top = 47,
                Width = 100,
                Minimum = 2000,
                Maximum = 2100,
                Value = DateTime.Now.Year
            };
            this.Controls.Add(yearNumericUpDown);

            Button okButton = new Button() { Text = "OK", Left = 20, Top = 90, Width = 75, DialogResult = DialogResult.OK };
            this.Controls.Add(okButton);

            Button cancelButton = new Button() { Text = "Cancel", Left = 100, Top = 90, Width = 75, DialogResult = DialogResult.Cancel };
            this.Controls.Add(cancelButton);

            this.AcceptButton = okButton;
            this.CancelButton = cancelButton;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                SelectedMonth = (int)monthComboBox.SelectedItem;
                SelectedYear = (int)yearNumericUpDown.Value;
            }
            base.OnFormClosing(e);
        }
    }
}
