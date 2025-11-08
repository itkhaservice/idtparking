using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDT_PARKING
{
    public partial class FormTruyVan : Form
    {
        public FormTruyVan()
        {
            InitializeComponent();
            splitContainer1.Dock = DockStyle.Fill;
        }

        private void ExecuteQuery(string sqlQuery)
        {
            string serverAddress = Properties.Settings.Default.ServerAddress;
            string databaseName = Properties.Settings.Default.DatabaseName;
            string uid = Properties.Settings.Default.Username;
            string password = Properties.Settings.Default.Password;

            string backupFileName = $"{databaseName}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.bak";

            string connectionString;
            if (string.IsNullOrWhiteSpace(uid))
            {
                connectionString = $"Server={serverAddress};Database={databaseName};Integrated Security=True;TrustServerCertificate=True;";
            }
            else
            {
                connectionString = $"Server={serverAddress};Database={databaseName};User ID={uid};Password={password};TrustServerCertificate=True;";
            }
            string sql = txtCommand.SelectedText;
            int selectionStart = txtCommand.SelectionStart;
            int selectionLength = txtCommand.SelectionLength;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Gán dữ liệu vào DataGridView
                    dgvResult.DataSource = dataTable;
                    MessageBox.Show("Truy vấn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // --- Khôi phục vùng văn bản đã chọn ---
                    // Đảm bảo focus vào TextBox trước khi gán lại Selection
                    txtCommand.Focus();
                    txtCommand.SelectionStart = selectionStart;
                    txtCommand.SelectionLength = selectionLength;
                    // ------------------------------------------
                }
            }
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCommand.SelectionLength > 0)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;

                    string sqlQueryAll = txtCommand.Text;


                    string sqlQuery = txtCommand.SelectedText;
                    ExecuteQuery(sqlQuery);

                    int selectionStart = txtCommand.SelectionStart;
                    int selectionLength = txtCommand.SelectionLength;
                    txtCommand.Focus();
                    txtCommand.SelectionStart = selectionStart;
                    txtCommand.SelectionLength = selectionLength;
                    txtCommand.Text = sqlQueryAll;
                }
                else
                {
                    e.Handled = false;
                    e.SuppressKeyPress = false;
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpForm formTruyVan = new HelpForm();
            formTruyVan.Show(); // Hoặc formTruyVan.ShowDialog();
        }
    }
}
