using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IDT_PARKING
{
    public partial class FormMainMenu : Form
    {
        private Form activeForm = null;
        private SqlConnection connection;
        public FormMainMenu()
        {
            InitializeComponent();
            DisableAllButtonsExceptCaiDat();
        }

        private void DisableAllButtonsExceptCaiDat()
        {
            btnDoanhThu.Enabled = false;
            btnXeVao.Enabled = false;
            btnXeRa.Enabled = false;
            btnXeThang.Enabled = false;
        }

        private void EnableAllButtons()
        {
            btnDoanhThu.Enabled = true;
            btnXeVao.Enabled = true;
            btnXeRa.Enabled = true;
            btnXeThang.Enabled = true;
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(childForm);
            mainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            FormCaiDat formCaiDat = new FormCaiDat();
            formCaiDat.ConnectionSuccessful += (s, args) =>
            {
                EnableAllButtons();
                string serverAddress = Properties.Settings.Default.ServerAddress;
                string databaseName = Properties.Settings.Default.DatabaseName;
                string uid = Properties.Settings.Default.Username;
                string password = Properties.Settings.Default.Password;

                string connectionString;
                if (string.IsNullOrWhiteSpace(uid))
                {
                    connectionString = $"Server={serverAddress};Database={databaseName};Integrated Security=True;TrustServerCertificate=True;";
                }
                else
                {
                    connectionString = $"Server={serverAddress};Database={databaseName};User ID={uid};Password={password};TrustServerCertificate=True;";
                }
                connection = new SqlConnection(connectionString);
                connection.Open();
                EnsureItKhaTableExists();
                // Optionally, open a default form after connection
                // openChildForm(new FormTTT());
            };
            formCaiDat.ShowDialog();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            FormTTT formTTT = new FormTTT();
            formTTT.Connection = connection;
            openChildForm(formTTT);
        }

        private void btnXeVao_Click(object sender, EventArgs e)
        {
            // Replace with the actual form for "Xe vao"
            // openChildForm(new FormXeVao());
        }

        private void btnXeRa_Click(object sender, EventArgs e)
        {
            // Replace with the actual form for "Xe ra"
            // openChildForm(new FormXeRa());
        }

        private void btnXeThang_Click(object sender, EventArgs e)
        {
            // Replace with the actual form for "Xe thang"
            // openChildForm(new FormXeThang());
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            // Attempt to connect on load, or just show CaiDat
            btnCaiDat.PerformClick();
        }
        
        private void EnsureItKhaTableExists()
        {
            if (connection == null || connection.State != System.Data.ConnectionState.Open)
                return;

            string checkAndCreateTable = @"
    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ITKHA' AND xtype='U')
    BEGIN
        CREATE TABLE [dbo].[ITKHA] (
            STTThe     VARCHAR(10)   NOT NULL,
            CardID     VARCHAR(20)   NOT NULL,
            NgayRa     DATETIME      NOT NULL,
            ThoiGianRa NCHAR(10)     NOT NULL,
            MaLoaiThe  VARCHAR(10)   NOT NULL,
            GiaTien    MONEY         NOT NULL,
            username   VARCHAR(20)   NOT NULL,
            IDXe       VARCHAR(50)   NOT NULL,
            IDMat      VARCHAR(50)   NOT NULL,
            GioRa      NCHAR(10)     NOT NULL,
            cong       VARCHAR(50)   NULL,
            soxe       VARCHAR(50)   NULL,
            soxera     VARCHAR(50)   NOT NULL,
            Thao_Tac   NVARCHAR(20)  NOT NULL,
            Ngay_Thuc_Hien DATETIME NOT NULL
        )
    END";

            using (SqlCommand cmd = new SqlCommand(checkAndCreateTable, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}