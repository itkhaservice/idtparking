using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using Excel = Microsoft.Office.Interop.Excel;

namespace IDT_PARKING
{
    public partial class FormMain : Form
    {
        private string _lastBackupFolderPath = string.Empty;
        #region Global Variables and Constants

        // KHAI BÁO CÁC BIẾN LƯU TỪ FORM CÀI ĐẶT
        public string txtServer = Properties.Settings.Default.ServerAddress;
        public string txtDatabase = Properties.Settings.Default.DatabaseName;
        public string txtUsername = Properties.Settings.Default.Username;
        public string txtPassword = Properties.Settings.Default.Password;

        // KHAI BÁO HẰNG SỐ CỦA TAB DOANH THU
                private string DynamicPassword => GenerateDynamicPassword();

        private string GenerateDynamicPassword()
        {
            DateTime now = DateTime.Now;
            // Ensure hours are in 24-hour format
            return now.ToString("HHmmddMM"); // hhmmddMM format
        }
        public const string ALL_MATERIAL_TYPE = "ALL";
        public const string PRICE_COLUMN_NAME = "PRICE";
        private SqlConnection connection;
        private string _selectedMaKH = string.Empty;
        private string _selectedCardID = string.Empty;
        private int _selectedSTT = 0;// To store the MaKH of the selected customer
        private ImageViewerForm imageViewerInstance = null;
        private Guna.UI2.WinForms.Guna2PictureBox lastClickedPictureBox = null;
        private string kh_export_path;
        private string tt_export_path;
        private string dt_export_path;
        private string lastXeVaoExportPath;
        private string lastXeRaExportPath;
        private string active_export_path;
        private bool isDragging = false;
        private Point lastCursorPos;
        //private SqlConnection _connection;
        //private DataTable _currentQueryResult;

        #endregion

        #region Constructor and Form Initialization

        public FormMain()
        {
            InitializeComponent();
       
            txtQuerry_CaiDat.Text = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE';";
            txtQuerry_CaiDat.ReadOnly = true;
            txtQuerry_CaiDat.Enabled = false;
            //this.tabControl.SelectedTab = tabCaiDat;
            

            dgvXeRa.KeyDown += dgvXeRa_KeyDown;

            this.Resize += MainForm_Resize;
            ptHinhMatRa.Click += pictureBox_Click;
            ptHinhXeRa.Click += pictureBox_Click;
            ptHinhMatVao.Click += pictureBox_Click;
            ptHinhXeVao.Click += pictureBox_Click;

            ptHinhMatVaoVao.Click += pictureBox_Click;
            ptHinhXeVaoVao.Click += pictureBox_Click;

            btnXoaXeVao.Click += btnXoaXeVao_Click;

            dgvXeVao.CellClick += dgvXeVao_CellClick;
            dgvXeVao.KeyDown += dgvXeVao_KeyDown;

            txtSoTheXeRa.KeyDown += txtSoTheXeRa_KeyDown;
            txtBienSoXeRa.KeyDown += txtBienSoXeRa_KeyDown;

            txtSoTheXeVao.KeyDown += txtSoTheXeVao_KeyDown;
            txtBienSoXeVao.KeyDown += txtBienSoXeVao_KeyDown;

            toolTip1.Active = true;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);

            // Sự kiện cho Tab Khách hàng
            dgvKhachHang_KH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_KH_CellClick);
            txtTimTen_KH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchKhachHang_KeyDown);
            txtTimDVDC_KH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchKhachHang_KeyDown);
            txtTimBS_KH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchKhachHang_KeyDown);
            cbChuaThe_KH.CheckedChanged += new System.EventHandler(this.cbChuaThe_KH_CheckedChanged);

            btnThem_KH.Click += new System.EventHandler(this.btnThem_KH_Click);
            btnUpdate_KH.Click += new System.EventHandler(this.btnUpdate_KH_Click);
            btnUpdateBienSo_KH.Click += new System.EventHandler(this.btnUpdateBienSo_KH_Click);
            btnUpdateLoaiThe_KH.Click += new System.EventHandler(this.btnUpdateLoaiThe_KH_Click);
            btnUpdateDate_KH.Click += new System.EventHandler(this.btnUpdateDate_KH_Click);

            // Wire up mouse events for dragging the form
            this.tabControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseDown);
            this.tabControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseMove);
            this.tabControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseUp);

            rbSoThe_TT.Checked = true;
            txtThe_TT.KeyDown += new KeyEventHandler(this.txtThe_TT_KeyDown);
            rbSoThe_TT.CheckedChanged += new EventHandler(this.rbSoThe_TT_CheckedChanged);
            rbBienSo_TT.CheckedChanged += new EventHandler(this.rbBienSo_TT_CheckedChanged);
            cbExDate_TT.CheckedChanged += new EventHandler(this.cbExDate_TT_CheckedChanged);
            cbKhoa_TT.CheckedChanged += new EventHandler(this.cbKhoa_TT_CheckedChanged);
            btnMoThe_TT.Click += new System.EventHandler(this.btnMoThe_TT_Click);

            guna2Button1.Click += new System.EventHandler(this.btnRevenueMonth_Click);
            guna2Button3.Click += new System.EventHandler(this.btnRevenueYear_Click);

            // Sự kiện cho tìm kiếm thẻ trống
            txtThe_TTr.KeyDown += new KeyEventHandler(this.txtThe_TTr_KeyDown);

            // Set custom format for Guna2DateTimePicker controls
            dtTu_TT.Format = DateTimePickerFormat.Custom;
            dtTu_TT.CustomFormat = "dd-MM-yyyy";
            dtTu_TT.ShowUpDown = false; // Enable direct typing
            dtDen_TT.Format = DateTimePickerFormat.Custom;
            dtDen_TT.CustomFormat = "dd-MM-yyyy";
            dtDen_TT.ShowUpDown = false; // Enable direct typing
            dtTu_TTr.Format = DateTimePickerFormat.Custom;
            dtTu_TTr.CustomFormat = "dd-MM-yyyy";
            dtDen_TTr.Format = DateTimePickerFormat.Custom;
            dtDen_TTr.CustomFormat = "dd-MM-yyyy";

            txtQuerry_CaiDat.KeyDown += new KeyEventHandler(txtQuerry_CaiDat_KeyDown);

            // Disable search by MaThe
            txtMaThe_TTT.Enabled = false;
            txtTinhTrang_TTT1.Enabled = true;
            txtTinhTrang_TTT2.Enabled = true;
            txtMaThe_TTT.PlaceholderText = "Chỉ tìm kiếm bằng Số thẻ";

            btnDelete_XR_KHAC.Click += new System.EventHandler(this.btnDelete_XR_KHAC_Click);
            btnQuerry_XR_KHAC.Click += new System.EventHandler(this.btnQuerry_XR_KHAC_Click);
            btnDelete_XR_KHAC.Enabled = false;
        }

        #endregion

        #region Common / General Methods

        private Task RunSTATask(Action action)
        {
            var tcs = new TaskCompletionSource<object>();
            var thread = new Thread(() =>
            {
                try
                {
                    action();
                    tcs.SetResult(null);
                }
                catch (Exception e)
                {
                    tcs.SetException(e);
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            return tcs.Task;
        }

        private Task<T> RunSTATask<T>(Func<T> func)
        {
            var tcs = new TaskCompletionSource<T>();
            var thread = new Thread(() =>
            {
                try
                {
                    tcs.SetResult(func());
                }
                catch (Exception e)
                {
                    tcs.SetException(e);
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            return tcs.Task;
        }

        private void ShowLoading()
        {
            this.Invoke((MethodInvoker)delegate
            {
                loadingControl.Location = new Point(
                    (this.ClientSize.Width - loadingControl.Width) / 2,
                    (this.ClientSize.Height - loadingControl.Height) / 2
                );

                loadingControl.BringToFront();
                loadingControl.Visible = true;
                loadingControl.Enabled = true;
            });
        }


        private void HideLoading()
        {
            this.Invoke((MethodInvoker)delegate
            {
                loadingControl.Visible = false;
                loadingControl.Enabled = false;
            });
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (loadingControl.Visible)
            {
                loadingControl.Location = new Point(
                    (this.ClientSize.Width - loadingControl.Width) / 2,
                    (this.ClientSize.Height - loadingControl.Height) / 2
                );
            }
        }


        private void SetTabStates(bool enabled)
        {
            foreach (TabPage tab in tabControl.TabPages)
            {
                if (tab == tabCaiDat) continue; // Always keep settings tab enabled

                tab.Enabled = enabled; // This enables/disables controls within the tab
                // For Guna2TabControl, disabling the TabPage itself might not visually disable the header.
                // We'll rely on the Selecting event to prevent navigation.
            }
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // If the connection is not open and the selected tab is not the settings tab, cancel the selection
            if ((connection == null || connection.State != ConnectionState.Open) && e.TabPage != tabCaiDat)
            {
                e.Cancel = true;
                return;
            }
        }

        private async void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabKhachHang)
            {
                await LoadKhachHangData();
                // When the tab is selected, LoadKhachHangData will internally call LoadTheThangData
                // with the MaKHs of the filtered customers. If no customers are filtered, an empty list will be passed.
                //await LoadTheThangData("", true, false, false, null); 
                await LoadTheTrongData(); // Load TheTrong data when tabKhachHang is selected

                // Set dtTu_TTr and dtDen_TTr to current date
                dtTu_TTr.Value = DateTime.Now;
                dtDen_TTr.Value = DateTime.Now;

                // Load LoaiThe data for cbbLoai_TTr
                // LoadLoaiTheData(); // Removed as it's now called in DoanhThu_Load()
            }
        }

        private void InitializeDatabaseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                return; // Connection is already open
            }

            try
            {
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

                this.connection = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối đến cơ sở dữ liệu: {ex.Message}\nVui lòng kiểm tra lại cài đặt kết nối.", "Lỗi kết nối cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally, disable UI elements that require a database connection
            }
        }

        private Bitmap GetBlackImage(int width, int height)
        {
            Bitmap blackImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(blackImage))
            {
                g.FillRectangle(Brushes.Black, 0, 0, blackImage.Width, blackImage.Height);
            }
            return blackImage;
        }

        private void LoadImageIntoPictureBox(Guna.UI2.WinForms.Guna2PictureBox pictureBox, string imagePath)
        {
            try
            {
                if (File.Exists(imagePath))
                {
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        pictureBox.Image = Image.FromStream(fs);
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Or other suitable layout
                    }
                    toolTip1.SetToolTip(pictureBox, imagePath);
                }
                else
                {
                    pictureBox.Image = GetBlackImage(pictureBox.Width, pictureBox.Height); // Đặt hình ảnh màu đen
                    toolTip1.SetToolTip(pictureBox, "Image not found: " + imagePath);
                }
            }
            catch (Exception ex)
            {
                pictureBox.Image = GetBlackImage(pictureBox.Width, pictureBox.Height); // Đặt hình ảnh màu đen
                toolTip1.SetToolTip(pictureBox, "Error loading image: " + ex.Message);
                Console.WriteLine($"Error loading image {imagePath}: {ex.Message}");
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            lastClickedPictureBox = sender as Guna.UI2.WinForms.Guna2PictureBox;
            if (lastClickedPictureBox == null) return;

            string imagePath = GetSingleImagePathForCurrentRow(lastClickedPictureBox);

            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
            {
                MessageBox.Show("Không tìm thấy hình ảnh để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var imageList = new List<string> { imagePath };

            if (imageViewerInstance == null || imageViewerInstance.IsDisposed)
            {
                imageViewerInstance = new ImageViewerForm(imageList, 0);
                imageViewerInstance.FormClosed += (s, args) => imageViewerInstance = null;
                // Subscribe to the new events
                imageViewerInstance.RequestNextImage += Viewer_RequestNextImage;
                imageViewerInstance.RequestPreviousImage += Viewer_RequestPreviousImage;
                imageViewerInstance.Show();
            }
            else
            {
                imageViewerInstance.UpdateAndShowImage(imageList, 0);
            }
        }

        private void Viewer_RequestNextImage(object sender, EventArgs e)
        {
            NavigateGrid(1);
        }

        private void Viewer_RequestPreviousImage(object sender, EventArgs e)
        {
            NavigateGrid(-1);
        }

        private void NavigateGrid(int direction)
        {
            DataGridView dgv = null;
            if (tabControl.SelectedIndex == 0) // Xe Vao
            {
                dgv = dgvXeVao;
            }
            else if (tabControl.SelectedIndex == 1) // Xe Ra
            {
                dgv = dgvXeRa;
            }

            if (dgv == null || dgv.Rows.Count == 0 || dgv.CurrentRow == null) return;

            int newIndex = dgv.CurrentRow.Index + direction;

            if (newIndex >= 0 && newIndex < dgv.Rows.Count)
            {
                dgv.CurrentCell = dgv.Rows[newIndex].Cells[0]; // Change selection

                // Update images based on the active tab
                if (tabControl.SelectedIndex == 0)
                {
                    LoadImagesFromXeVaoRow(dgv.Rows[newIndex]);
                }
                else
                {
                    LoadImagesFromSelectedRow(dgv.Rows[newIndex]);
                }


                // Update viewer if it's open
                if (imageViewerInstance != null && !imageViewerInstance.IsDisposed && lastClickedPictureBox != null)
                {
                    string newImagePath = GetSingleImagePathForCurrentRow(lastClickedPictureBox);
                    if (!string.IsNullOrEmpty(newImagePath) && File.Exists(newImagePath))
                    {
                        imageViewerInstance.UpdateAndShowImage(new List<string> { newImagePath }, 0);
                    }
                }
            }
        }

        private string GetSingleImagePathForCurrentRow(Guna.UI2.WinForms.Guna2PictureBox clickedPictureBox)
        {
            DataGridView dgv = null;
            if (tabControl.SelectedIndex == 0) // Xe Vao
            {
                dgv = dgvXeVao;
            }
            else if (tabControl.SelectedIndex == 1) // Xe Ra
            {
                dgv = dgvXeRa;
            }

            if (dgv == null || dgv.CurrentRow == null || clickedPictureBox == null) return null;

            DataGridViewRow row = dgv.CurrentRow;

            // Determine image type and direction from the clicked control
            string imageType = "";
            string direction = "";
            if (clickedPictureBox == ptHinhMatVao || clickedPictureBox == ptHinhMatVaoVao) { imageType = "mat"; direction = "in"; }
            else if (clickedPictureBox == ptHinhXeVao || clickedPictureBox == ptHinhXeVaoVao) { imageType = "xe"; direction = "in"; }
            else if (clickedPictureBox == ptHinhMatRa) { imageType = "mat"; direction = "out"; }
            else if (clickedPictureBox == ptHinhXeRa) { imageType = "xe"; direction = "out"; }
            else return null; // Should not happen if wired correctly

            // Common data extraction
            if (row.Cells["IDMat"]?.Value == null || row.Cells["IDXe"]?.Value == null ||
                row.Cells["Mã thẻ"]?.Value == null || row.Cells["Ngày vào"]?.Value == null)
            {
                return null;
            }

            string idMat = row.Cells["IDMat"].Value.ToString();
            string idXe = row.Cells["IDXe"].Value.ToString();
            string cardId = row.Cells["Mã thẻ"].Value.ToString();

            if (!DateTime.TryParse(row.Cells["Ngày vào"].Value.ToString(), out DateTime ngayVao)) return null;

            string folderPath = Properties.Settings.Default.SharedFolder;
            if (string.IsNullOrWhiteSpace(folderPath)) return null;
            if (folderPath.StartsWith(@"\") && !folderPath.StartsWith(@"\\"))
            {
                folderPath = @"\\" + folderPath;
            }

            string yearMonthDay = ngayVao.ToString("yyyyMMdd");
            string fileName = (imageType == "mat") ? (idMat + cardId) : (idXe + cardId);

            return Path.Combine(folderPath, direction, imageType, yearMonthDay, fileName + ".jpg");
        }

        private void OpenImageViewer(Guna.UI2.WinForms.Guna2PictureBox clickedPictureBox)
        {
            DataGridView dgv = null;
            if (tabControl.SelectedIndex == 0) // Xe Vao
            {
                dgv = dgvXeVao;
            }
            else if (tabControl.SelectedIndex == 1) // Xe Ra
            {
                dgv = dgvXeRa;
            }

            if (dgv == null || dgv.CurrentRow == null) return;

            DataGridViewRow row = dgv.CurrentRow;

            if (row.Cells["IDMat"] == null || row.Cells["IDXe"] == null ||
                row.Cells["Mã thẻ"] == null || row.Cells["Ngày vào"] == null || row.Cells["Thời gian vào"] == null)
            {
                return;
            }

            string idMat = row.Cells["IDMat"].Value?.ToString();
            string idXe = row.Cells["IDXe"].Value?.ToString();
            string cardId = row.Cells["Mã thẻ"].Value?.ToString(); // Lấy CardID

            DateTime ngayVao;

            // Attempt to parse NgayVao
            if (!DateTime.TryParse(row.Cells["Ngày vào"].Value?.ToString(), out ngayVao))
            {
                ptHinhMatRa.Image = GetBlackImage(ptHinhMatRa.Width, ptHinhMatRa.Height);
                ptHinhXeRa.Image = GetBlackImage(ptHinhXeRa.Width, ptHinhXeRa.Height);
                toolTip1.SetToolTip(ptHinhMatRa, "Không thể phân tích ngày vào.");
                toolTip1.SetToolTip(ptHinhXeRa, "Không thể phân tích ngày vào.");
                return;
            }

            string gioVaoString = row.Cells["Thời gian vào"].Value?.ToString();

            if (string.IsNullOrEmpty(gioVaoString))
            {
                ptHinhMatRa.Image = GetBlackImage(ptHinhMatRa.Width, ptHinhMatRa.Height);
                ptHinhXeRa.Image = GetBlackImage(ptHinhXeRa.Width, ptHinhXeRa.Height);
                toolTip1.SetToolTip(ptHinhMatRa, "Không thể phân tích giờ vào.");
                toolTip1.SetToolTip(ptHinhXeRa, "Không thể phân tích giờ vào.");
                ptHinhMatVao.Image = GetBlackImage(ptHinhMatVao.Width, ptHinhMatVao.Height);
                ptHinhXeVao.Image = GetBlackImage(ptHinhXeVao.Width, ptHinhXeVao.Height);
                toolTip1.SetToolTip(ptHinhMatRa, "Không thể phân tích giờ vào.");
                toolTip1.SetToolTip(ptHinhXeRa, "Không thể phân tích giờ vào.");
                return;
            }

            string folderPath = Properties.Settings.Default.SharedFolder;
            if (!string.IsNullOrEmpty(folderPath) && folderPath.StartsWith(@"\") && !folderPath.StartsWith(@"\\"))
            {
                folderPath = @"\\" + folderPath;
            }

            string yearMonthDay = ngayVao.ToString("yyyyMMdd");
            // Tạo tên tệp hình ảnh theo định dạng: ngayVao (yyyyMMdd) + gioVaoFormatted (HHmmss) + CardID
            string fileNameMat = idMat + cardId;
            string fileNameXe = idXe + cardId;

            string imageMatPath = Path.Combine(folderPath, "out", "mat", yearMonthDay, fileNameMat + ".jpg");
            string imageXePath = Path.Combine(folderPath, "out", "xe", yearMonthDay, fileNameXe + ".jpg");
            string imageMatVaoPath = Path.Combine(folderPath, "in", "mat", yearMonthDay, fileNameMat + ".jpg");
            string imageXeVaoPath = Path.Combine(folderPath, "in", "xe", yearMonthDay, fileNameXe + ".jpg");
            List<string> imagePaths = new List<string>();
            int startIndex = 0;

            if (File.Exists(imageMatVaoPath))
            {
                imagePaths.Add(imageMatVaoPath);
            }
            if (File.Exists(imageXeVaoPath))
            {
                if (clickedPictureBox == ptHinhXeVao || clickedPictureBox == ptHinhXeVaoVao)
                {
                    startIndex = imagePaths.Count;
                }
                imagePaths.Add(imageXeVaoPath);
            }

            if (tabControl.SelectedIndex == 1) // Only add "out" images for Xe Ra tab
            {
                if (File.Exists(imageMatPath))
                {
                    if (clickedPictureBox == ptHinhMatRa)
                    {
                        startIndex = imagePaths.Count;
                    }
                    imagePaths.Add(imageMatPath);
                }
                if (File.Exists(imageXePath))
                {
                    if (clickedPictureBox == ptHinhXeRa)
                    {
                        startIndex = imagePaths.Count;
                    }
                    imagePaths.Add(imageXePath);
                }
            }


            if (imagePaths.Any())
            {
                ImageViewerForm imageViewer = new ImageViewerForm(imagePaths, startIndex);
                imageViewer.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không tìm thấy hình ảnh nào để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExitProgram_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPos = new Point(e.X, e.Y);
            }
        }

        private void tabControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Location = new Point(this.Location.X + (e.X - lastCursorPos.X),
                                          this.Location.Y + (e.Y - lastCursorPos.Y));
            }
        }

        private void tabControl_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SetupAndConnect();
        }

        #endregion

        #region Cài Đặt (Settings) Tab

        private async void SetupAndConnect()
        {
            SetTabStates(false); // Initially disable all tabs except settings
            string serverAddress = Properties.Settings.Default.ServerAddress;
            string databaseName = Properties.Settings.Default.DatabaseName;
            string folder = Properties.Settings.Default.SharedFolder;
            string uid = Properties.Settings.Default.Username;
            string password = Properties.Settings.Default.Password;

            if (string.IsNullOrWhiteSpace(serverAddress) || string.IsNullOrWhiteSpace(databaseName))
            {
                tabControl.SelectedTab = tabCaiDat;
                SetTabStates(false);
            }
            else
            {
                string connectionString;
                if (string.IsNullOrWhiteSpace(uid))
                {
                    connectionString = $"Server={serverAddress};Database={databaseName};Integrated Security=True;TrustServerCertificate=True;";
                }
                else
                {
                    connectionString = $"Server={serverAddress};Database={databaseName};User ID={uid};Password={password};TrustServerCertificate=True;";
                }

                try
                {

                    connection = new SqlConnection(connectionString);
                    connection.Open();

                    txtServer_Main.Text = Properties.Settings.Default.ServerAddress;
                    txtDatabase_Main.Text = Properties.Settings.Default.DatabaseName;
                    txtFolder_Main.Text = Properties.Settings.Default.SharedFolder;
                    txtUsername_Main.Text = Properties.Settings.Default.Username;
                    txtPassword_Main.Text = Properties.Settings.Default.Password;
                    SetTabStates(true);
                                    DoanhThu_Load();
                                    await LoadKhachHangData();
                                    await LoadTheThangData("", true, false, false, null);                    await LoadTheTrongData();
                    dtTu_TTr.Value = DateTime.Now;
                    dtDen_TTr.Value = DateTime.Now;
                    //tabControl_SelectedIndexChanged(tabControl, EventArgs.Empty);
                    tabControl.SelectedTab = tabKhachHang;
                }
                catch (Exception)
                {
                    tabControl.SelectedTab = tabCaiDat;
                    SetTabStates(false);
                }
                finally
                {
                }
            }
        }

        private void btnSaveConnect_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerAddress = txtServer_Main.Text;
            Properties.Settings.Default.DatabaseName = txtDatabase_Main.Text;
            Properties.Settings.Default.Username = txtUsername_Main.Text;
            Properties.Settings.Default.SharedFolder = txtFolder_Main.Text;
            Properties.Settings.Default.Password = txtPassword_Main.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Thông tin kết nối đã được lưu thành công!", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnConnect_Main_Click(object sender, EventArgs e)
        {
            // LẤY THÔNG TIN KẾT NỐI TỪ GIAO DIỆN NGƯỜI DÙNG
            string serverAddress = txtServer_Main.Text;
            string databaseName = txtDatabase_Main.Text;
            string folder = txtFolder_Main.Text;
            string uid = txtUsername_Main.Text;
            string password = txtPassword_Main.Text;

            // KIỂM TRA XEM CÁC TRƯỜNG BẮT BUỘC CÓ BỊ TRỐNG KHÔNG
            if (string.IsNullOrWhiteSpace(serverAddress) || string.IsNullOrWhiteSpace(databaseName))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Máy chủ và Cơ sở dữ liệu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng thực hiện nếu thiếu thông tin
            }

            // TẠO CHUỖI KẾT NỐI DỰA TRÊN THÔNG TIN NHẬP VÀO
            string connectionString;
            if (string.IsNullOrWhiteSpace(uid))
            {
                connectionString = $"Server={serverAddress};Database={databaseName};Integrated Security=True;TrustServerCertificate=True;";
            }
            else
            {
                connectionString = $"Server={serverAddress};Database={databaseName};User ID={uid};Password={password};TrustServerCertificate=True;";
            }

            // THỬ KẾT NỐI ĐẾN CƠ SỞ DỮ LIỆU
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                //MessageBox.Show("Kết nối dữ liệu thành công!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // LƯU LẠI CÁC THÔNG TIN KẾT NỐI ĐẾN CƠ SỞ DỮ LIỆU
                Properties.Settings.Default.ServerAddress = txtServer_Main.Text;
                Properties.Settings.Default.DatabaseName = txtDatabase_Main.Text;
                Properties.Settings.Default.Username = txtUsername_Main.Text;
                Properties.Settings.Default.SharedFolder = txtFolder_Main.Text;
                Properties.Settings.Default.Password = txtPassword_Main.Text;
                Properties.Settings.Default.Save();
                EnsureItKhaTableClear();
                DoanhThu_Load();
                SetTabStates(true);
                await LoadKhachHangData();
                await LoadTheThangData("", true, false, false, null);
                await LoadTheTrongData();
                dtTu_TTr.Value = DateTime.Now;
                dtDen_TTr.Value = DateTime.Now;
                tabControl.SelectedTab = tabKhachHang;
            }
            catch (Exception)
            {
                SetTabStates(false); // Keep other tabs disabled on connection failure
            }
            finally
            {
            }
        }



        private void ClearAllSettings()
        {
            txtServer_Main.Text = "";
            txtDatabase_Main.Text = "";
            txtUsername_Main.Text = "";
            txtPassword_Main.Text = "";
            txtFolder_Main.Text = "";
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            MessageBox.Show("Tất cả cài đặt đã được xóa về mặc định.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EnsureItKhaTableClear()
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                // Connection not open, cannot check/delete table.
                // This method should ideally be called when a connection is known to be active.
                return;
            }

            string dropTableQuery = @"
            IF OBJECT_ID('dbo.ITKHA', 'U') IS NOT NULL
            BEGIN
                DROP TABLE [dbo].[ITKHA]
            END";

            try
            {
                using (SqlCommand cmd = new SqlCommand(dropTableQuery, connection))
                {
                    cmd.ExecuteNonQuery();
                    // Optionally, log or show a message that the table was dropped.
                    // For now, we'll keep it silent unless an error occurs.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa bảng ITKHA: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearConnect_Click(object sender, EventArgs e)
        {
            ClearAllSettings();
        }

        private void txtQuerry_CaiDat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string query = txtQuerry_CaiDat.SelectedText.Trim();
                if (!string.IsNullOrEmpty(query))
                {
                    try
                    {
                        if (connection == null || connection.State != ConnectionState.Open)
                        {
                            MessageBox.Show("Vui lòng kết nối cơ sở dữ liệu trước khi thực hiện truy vấn.", "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);
                                dgvQuery_CaiDat.DataSource = dataTable;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi truy vấn SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    e.SuppressKeyPress = true; // Chỉ chặn Enter khi có truy vấn được thực thi
                }
                // Nếu không có text nào được bôi đen, không làm gì cả, để Enter tự xuống dòng
            }
        }

        private void btnMoQuery_Click(object sender, EventArgs e)
        {
            using (PasswordPromptForm passwordForm = new PasswordPromptForm())
            {
                DialogResult result = passwordForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string enteredPassword = passwordForm.EnteredPassword;

                    if (enteredPassword == DynamicPassword)
                    {
                        txtQuerry_CaiDat.ReadOnly = false;
                        txtQuerry_CaiDat.Enabled = true;
                        MessageBox.Show("Đã mở khóa ô nhập truy vấn. Bạn có thể chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sai mật khẩu. Vui lòng thử lại", "Xác thực không thành công!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Hủy thao tác mở khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được viết...", "Lỗi Kết Nối", MessageBoxButtons.OK);
        }

        #endregion

        #region Khác (Other) Tab

        private async void btnQuerry_XR_KHAC_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtdF_XR_KHAC.Value.Date;
            DateTime startTime = dttF_XR_KHAC.Value;
            DateTime endDate = dtdT_XR_KHAC.Value.Date;
            DateTime endTime = dttT_XR_KHAC.Value;

            int startTimeInSeconds = (int)startTime.TimeOfDay.TotalSeconds;
            int endTimeInSeconds = (int)endTime.TimeOfDay.TotalSeconds;
            string maLoaiThe = cbb_XR_KHAC.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(maLoaiThe))
            {
                MessageBox.Show("Vui lòng chọn một loại thẻ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var whereClauses = new List<string>();
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@endDate", endDate),
                new SqlParameter("@startTime", startTimeInSeconds),
                new SqlParameter("@endTime", endTimeInSeconds)
            };

            whereClauses.Add("((NgayRa > @startDate AND NgayRa < @endDate) OR (NgayRa = @startDate AND ThoiGianRa >= @startTime) OR (NgayRa = @endDate AND ThoiGianRa <= @endTime))");

            if (maLoaiThe != ALL_MATERIAL_TYPE)
            {
                whereClauses.Add("MaLoaiThe = @maLoaiThe");
                parameters.Add(new SqlParameter("@maLoaiThe", maLoaiThe));
            }

            string whereSql = string.Join(" AND ", whereClauses);
            string countQuery = $"SELECT COUNT(*) FROM [dbo].[Ra] WHERE {whereSql}";
            int recordCount = 0;

            try
            {
                ShowLoading();
                InitializeDatabaseConnection();
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                using (SqlCommand countCommand = new SqlCommand(countQuery, connection))
                {
                    countCommand.Parameters.AddRange(parameters.ToArray());
                    recordCount = (int)await countCommand.ExecuteScalarAsync();
                }

                txtSumGD_XR_KHAC.Text = recordCount.ToString();
                btnDelete_XR_KHAC.Enabled = recordCount > 0;

                if (recordCount == 0)
                {
                    MessageBox.Show("Không có dữ liệu nào phù hợp với điều kiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi truy vấn dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSumGD_XR_KHAC.Text = "0";
                btnDelete_XR_KHAC.Enabled = false;
            }
            finally
            {
                HideLoading();
            }
        }


        private async void btnDelete_XR_KHAC_Click(object sender, EventArgs e)
        {
            using (PasswordPromptForm passwordForm = new PasswordPromptForm())
            {
                if (passwordForm.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Hủy thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (passwordForm.EnteredPassword != DynamicPassword)
                {
                    MessageBox.Show("Sai mật khẩu. Vui lòng thử lại", "Xác thực không thành công!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DateTime startDate = dtdF_XR_KHAC.Value.Date;
            DateTime startTime = dttF_XR_KHAC.Value;
            DateTime endDate = dtdT_XR_KHAC.Value.Date;
            DateTime endTime = dttT_XR_KHAC.Value;

            int startTimeInSeconds = (int)startTime.TimeOfDay.TotalSeconds;
            int endTimeInSeconds = (int)endTime.TimeOfDay.TotalSeconds;
            string maLoaiThe = cbb_XR_KHAC.SelectedValue?.ToString();

            var whereClauses = new List<string>();
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@endDate", endDate),
                new SqlParameter("@startTime", startTimeInSeconds),
                new SqlParameter("@endTime", endTimeInSeconds)
            };

            whereClauses.Add("((NgayRa > @startDate AND NgayRa < @endDate) OR (NgayRa = @startDate AND ThoiGianRa >= @startTime) OR (NgayRa = @endDate AND ThoiGianRa <= @endTime))");

            if (maLoaiThe != ALL_MATERIAL_TYPE)
            {
                whereClauses.Add("MaLoaiThe = @maLoaiThe");
                parameters.Add(new SqlParameter("@maLoaiThe", maLoaiThe));
            }

            string whereSql = string.Join(" AND ", whereClauses);
            string deleteQuery = $"DELETE FROM [dbo].[Ra] WHERE {whereSql}";
            int rowsAffected = 0;

            try
            {
                ShowLoading();
                InitializeDatabaseConnection();
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa {txtSumGD_XR_KHAC.Text} dòng dữ liệu phù hợp không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                {
                    return;
                }

                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                {
                    deleteCommand.Parameters.AddRange(parameters.ToArray());
                    rowsAffected = await deleteCommand.ExecuteNonQueryAsync();
                }

                MessageBox.Show($"Đã xóa thành công {rowsAffected} dòng dữ liệu.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset UI
                txtSumGD_XR_KHAC.Text = "0";
                btnDelete_XR_KHAC.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HideLoading();
            }
        }

        private async void btnQuerry_XV_KHAC_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtdF_XV_KHAC.Value.Date;
            DateTime startTime = dttF_XV_KHAC.Value;
            DateTime endDate = dtdT_XV_KHAC.Value.Date;
            DateTime endTime = dttT_XV_KHAC.Value;

            int startTimeInSeconds = (int)startTime.TimeOfDay.TotalSeconds;
            int endTimeInSeconds = (int)endTime.TimeOfDay.TotalSeconds;
            string maLoaiThe = cbb_XV_KHAC.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(maLoaiThe))
            {
                MessageBox.Show("Vui lòng chọn một loại thẻ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var whereClauses = new List<string>();
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@endDate", endDate),
                new SqlParameter("@startTime", startTimeInSeconds),
                new SqlParameter("@endTime", endTimeInSeconds)
            };

            whereClauses.Add("((NgayVao > @startDate AND NgayVao < @endDate) OR (NgayVao = @startDate AND ThoiGian >= @startTime) OR (NgayVao = @endDate AND ThoiGian <= @endTime))");

            if (maLoaiThe != ALL_MATERIAL_TYPE)
            {
                whereClauses.Add("MaLoaiThe = @maLoaiThe");
                parameters.Add(new SqlParameter("@maLoaiThe", maLoaiThe));
            }

            string whereSql = string.Join(" AND ", whereClauses);
            string countQuery = $"SELECT COUNT(*) FROM [dbo].[Vao] WHERE {whereSql}";
            int recordCount = 0;

            try
            {
                ShowLoading();
                InitializeDatabaseConnection();
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                using (SqlCommand countCommand = new SqlCommand(countQuery, connection))
                {
                    countCommand.Parameters.AddRange(parameters.ToArray());
                    recordCount = (int)await countCommand.ExecuteScalarAsync();
                }

                txtSumGD_XV_KHAC.Text = recordCount.ToString();
                btnDelete_XV_KHAC.Enabled = recordCount > 0;

                if (recordCount == 0)
                {
                    MessageBox.Show("Không có dữ liệu nào phù hợp với điều kiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi truy vấn dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSumGD_XV_KHAC.Text = "0";
                btnDelete_XV_KHAC.Enabled = false;
            }
            finally
            {
                HideLoading();
            }
        }

        private async void btnDelete_XV_KHAC_Click(object sender, EventArgs e)
        {
            using (PasswordPromptForm passwordForm = new PasswordPromptForm())
            {
                if (passwordForm.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Hủy thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (passwordForm.EnteredPassword != DynamicPassword)
                {
                    MessageBox.Show("Sai mật khẩu. Vui lòng thử lại", "Xác thực không thành công!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DateTime startDate = dtdF_XV_KHAC.Value.Date;
            DateTime startTime = dttF_XV_KHAC.Value;
            DateTime endDate = dtdT_XV_KHAC.Value.Date;
            DateTime endTime = dttT_XV_KHAC.Value;

            int startTimeInSeconds = (int)startTime.TimeOfDay.TotalSeconds;
            int endTimeInSeconds = (int)endTime.TimeOfDay.TotalSeconds;
            string maLoaiThe = cbb_XV_KHAC.SelectedValue?.ToString();

            var whereClauses = new List<string>();
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@endDate", endDate),
                new SqlParameter("@startTime", startTimeInSeconds),
                new SqlParameter("@endTime", endTimeInSeconds)
            };

            whereClauses.Add("((NgayVao > @startDate AND NgayVao < @endDate) OR (NgayVao = @startDate AND ThoiGian >= @startTime) OR (NgayVao = @endDate AND ThoiGian <= @endTime))");

            if (maLoaiThe != ALL_MATERIAL_TYPE)
            {
                whereClauses.Add("MaLoaiThe = @maLoaiThe");
                parameters.Add(new SqlParameter("@maLoaiThe", maLoaiThe));
            }

            string whereSql = string.Join(" AND ", whereClauses);
            string deleteQuery = $"DELETE FROM [dbo].[Vao] WHERE {whereSql}";
            int rowsAffected = 0;

            try
            {
                ShowLoading();
                InitializeDatabaseConnection();
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa {txtSumGD_XV_KHAC.Text} dòng dữ liệu phù hợp không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                {
                    return;
                }

                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                {
                    deleteCommand.Parameters.AddRange(parameters.ToArray());
                    rowsAffected = await deleteCommand.ExecuteNonQueryAsync();
                }

                MessageBox.Show($"Đã xóa thành công {rowsAffected} dòng dữ liệu.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset UI
                txtSumGD_XV_KHAC.Text = "0";
                btnDelete_XV_KHAC.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HideLoading();
            }
        }
        #endregion

        #region Khách Hàng (Customers) Tab

        private async Task LoadKhachHangData()
        {
            var whereClauses = new List<string>();
            var parameters = new List<SqlParameter>();

            string baseQuery = "SELECT MaKH AS 'Mã KH', hoten AS 'Họ tên', DonVi AS 'Đơn vị', DiaChi AS 'Địa chỉ', dienthoai AS 'Điện thoại', hopdong AS 'Biển số', chungloai AS 'Hiệu xe', hinhanh AS 'Hình ảnh' FROM KhachHang";

            if (!string.IsNullOrWhiteSpace(txtTimTen_KH.Text))
            {
                whereClauses.Add("hoten LIKE @hoten");
                parameters.Add(new SqlParameter("@hoten", "%" + txtTimTen_KH.Text + "%"));
            }

            if (!string.IsNullOrWhiteSpace(txtTimDVDC_KH.Text))
            {
                whereClauses.Add("(DonVi LIKE @dvdc OR DiaChi LIKE @dvdc)");
                parameters.Add(new SqlParameter("@dvdc", "%" + txtTimDVDC_KH.Text + "%"));
            }

            if (!string.IsNullOrWhiteSpace(txtTimBS_KH.Text))
            {
                whereClauses.Add("hopdong LIKE @hopdong");
                parameters.Add(new SqlParameter("@hopdong", "%" + txtTimBS_KH.Text + "%"));
            }

            if (cbChuaThe_KH.Checked)
            {
                whereClauses.Add("NOT EXISTS (SELECT 1 FROM TheThang tt WHERE tt.MaKH = KhachHang.MaKH)");
            }

            string finalQuery = baseQuery;
            if (whereClauses.Any())
            {
                finalQuery += " WHERE " + string.Join(" AND ", whereClauses);
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                DataTable dataTable = new DataTable(); // Moved here

                using (SqlCommand command = new SqlCommand(finalQuery, connection))
                {
                    command.CommandTimeout = 120; // 2 minutes timeout
                    command.Parameters.AddRange(parameters.ToArray());
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        dataTable.Load(reader);
                    }

                    dgvKhachHang_KH.DataSource = dataTable;

                    if (dgvKhachHang_KH.Columns.Contains("Hình ảnh"))
                    {
                        dgvKhachHang_KH.Columns["Hình ảnh"].Visible = false;
                    }
                    dgvKhachHang_KH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                }

                // Extract MaKH from the filtered customer dataTable
                List<string> filteredMaKHs = new List<string>();
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["Mã KH"] != DBNull.Value)
                    {
                        filteredMaKHs.Add(row["Mã KH"].ToString());
                    }
                }

                // Load monthly cards for the filtered customers
                await LoadTheThangData(maKHFilters: filteredMaKHs);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private async void dgvKhachHang_KH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang_KH.Rows[e.RowIndex];

                _selectedMaKH = row.Cells["Mã KH"].Value?.ToString(); // Store MaKH in the private variable
                txtHoTen_KH.Text = row.Cells["Họ tên"].Value?.ToString();
                txtDiaChi_KH.Text = row.Cells["Địa chỉ"].Value?.ToString();
                txtDonVi_KH.Text = row.Cells["Đơn vị"].Value?.ToString();
                txtBienSo_KH.Text = row.Cells["Biển số"].Value?.ToString();
                txtBienSo_TTr.Text = txtBienSo_KH.Text;
                txtHieuXe_KH.Text = row.Cells["Hiệu xe"].Value?.ToString();
                txtDienThoai_KH.Text = row.Cells["Điện thoại"].Value?.ToString();

                // Load monthly card data for the selected customer
                await LoadTheThangData(maKHFilters: new List<string> { _selectedMaKH });

                // If there's data in dgvTheThang_KH, select the first row and populate details
                if (dgvTheThang_KH.Rows.Count > 0)
                {
                    dgvTheThang_KH.CurrentCell = dgvTheThang_KH.Rows[0].Cells[0];
                    dgvTheThang_KH.Rows[0].Selected = true;
                    PopulateTheThangDetails(dgvTheThang_KH.Rows[0]);
                }
                else
                {
                    // Clear the monthly card detail fields if no cards found
                    dtTu_TT.Value = DateTime.Now;
                    dtDen_TT.Value = DateTime.Now;
                    txtBienSo_TT.Clear();
                    cbbLoai_TTr.SelectedIndex = -1; // Clear selection
                }
            }
        }

        private async void SearchKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await LoadKhachHangData();
                e.SuppressKeyPress = true; 
            }
        }

        private async void cbChuaThe_KH_CheckedChanged(object sender, EventArgs e)
        {
            await LoadKhachHangData();
        }

        private async void btnThem_KH_Click(object sender, EventArgs e)
        {
            string newMaKH = await GenerateNextMaKH();
            if (newMaKH == null) return; // Error occurred during generation

            InitializeDatabaseConnection();

            string query = @"
                INSERT INTO KhachHang (MaKH, hoten, DonVi, DiaChi, dienthoai, hopdong, chungloai, hinhanh)
                VALUES (@makh, '', '', '', '', '', '', NULL)"; // Insert with empty strings and NULL for image

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@makh", newMaKH);

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Đã thêm khách hàng mới với Mã KH: {newMaKH}. Vui lòng chọn dòng này và nhấn Cập nhật để điền thông tin chi tiết.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadKhachHangData(); // Refresh the DataGridView
                        // Optionally, select the newly added row
                        foreach (DataGridViewRow row in dgvKhachHang_KH.Rows)
                        {
                            if (row.Cells["Mã KH"].Value?.ToString() == newMaKH)
                            {
                                dgvKhachHang_KH.CurrentCell = row.Cells[0];
                                row.Selected = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm khách hàng mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm khách hàng mới: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<string> GenerateNextMaKH()
        {
            string maxMaKH = "000000"; // Default if no existing customers

            try
            {
                InitializeDatabaseConnection();
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                string query = "SELECT MAX(MaKH) FROM KhachHang";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = await command.ExecuteScalarAsync();
                    if (result != DBNull.Value && result != null && !string.IsNullOrEmpty(result.ToString()))
                    {
                        maxMaKH = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy Mã khách hàng mới nhất: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Indicate failure
            }

            // New logic to handle alphanumeric MaKH
            try
            {
                // Regex to separate numeric prefix and string suffix
                Match match = Regex.Match(maxMaKH, @"^(\d+)(.*)$");

                if (match.Success)
                {
                    string numericPartStr = match.Groups[1].Value;
                    string suffixPart = match.Groups[2].Value;

                    if (int.TryParse(numericPartStr, out int numericPart))
                    {
                        numericPart++;
                        // Format back to the original length with leading zeros
                        string newNumericPart = numericPart.ToString(new string('0', numericPartStr.Length));
                        return newNumericPart + suffixPart;
                    }
                }

                // Fallback for purely numeric or other formats
                if (int.TryParse(maxMaKH, out int numericMaKH))
                {
                    numericMaKH++;
                    return numericMaKH.ToString("D6");
                }
                else
                {
                    MessageBox.Show("Mã KH hiện tại không đúng định dạng. Không thể tự động tăng. Mã KH cuối: " + maxMaKH, "Lỗi định dạng Mã KH", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý tạo Mã KH mới: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private async void btnUpdate_KH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedMaKH))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            InitializeDatabaseConnection();
            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            // Check for duplicate license plate
            string checkDuplicateBienSoQuery = "SELECT COUNT(*) FROM KhachHang WHERE hopdong = @hopdong AND MaKH != @makh";
            using (SqlCommand checkCmd = new SqlCommand(checkDuplicateBienSoQuery, connection))
            {
                checkCmd.Parameters.AddWithValue("@hopdong", txtBienSo_KH.Text.Trim());
                checkCmd.Parameters.AddWithValue("@makh", _selectedMaKH);
                int duplicateCount = (int)await checkCmd.ExecuteScalarAsync();
                if (duplicateCount > 0)
                {
                    MessageBox.Show("Biển số này đã tồn tại cho một khách hàng khác. Vui lòng nhập biển số khác.", "Lỗi trùng lặp biển số", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string query = @"
                UPDATE KhachHang
                SET hoten = @hoten, DonVi = @donvi, DiaChi = @diachi, dienthoai = @dienthoai, hopdong = @hopdong, chungloai = @chungloai
                WHERE MaKH = @makh";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@makh", _selectedMaKH);
                    command.Parameters.AddWithValue("@hoten", txtHoTen_KH.Text);
                    command.Parameters.AddWithValue("@donvi", txtDonVi_KH.Text);
                    command.Parameters.AddWithValue("@diachi", txtDiaChi_KH.Text);
                    command.Parameters.AddWithValue("@dienthoai", txtDienThoai_KH.Text);
                    command.Parameters.AddWithValue("@hopdong", txtBienSo_KH.Text);
                    command.Parameters.AddWithValue("@chungloai", txtHieuXe_KH.Text);
                    // hinhanh is not updated via UI, so it's omitted

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadKhachHangData(); // Refresh the DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng để cập nhật hoặc không có thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_KH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedMaKH))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng có Mã KH: {_selectedMaKH} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                InitializeDatabaseConnection();

                try
                {
                    ShowLoading(); // Show loading indicator
                    if (connection.State != ConnectionState.Open)
                    {
                        await connection.OpenAsync();
                    }

                    // Check if the customer has any associated monthly cards
                    string checkCardsQuery = "SELECT COUNT(*) FROM TheThang WHERE MaKH = @makh";
                    using (SqlCommand checkCmd = new SqlCommand(checkCardsQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@makh", _selectedMaKH);
                        int cardCount = (int)await checkCmd.ExecuteScalarAsync();

                        if (cardCount > 0)
                        {
                            MessageBox.Show("Không thể xóa khách hàng này vì họ có thẻ tháng liên quan. Vui lòng xóa tất cả thẻ tháng của khách hàng trước.", "Lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Prevent deletion
                        }
                    }

                    // If no cards, proceed with deletion
                    string deleteQuery = "DELETE FROM KhachHang WHERE MaKH = @makh";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@makh", _selectedMaKH);

                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Clear textboxes after deletion
                            _selectedMaKH = string.Empty; // Clear selected MaKH
                            txtHoTen_KH.Clear();
                            txtDiaChi_KH.Clear();
                            txtDonVi_KH.Clear();
                            txtBienSo_KH.Clear();
                            txtHieuXe_KH.Clear();
                            txtDienThoai_KH.Clear();
                            await LoadKhachHangData(); // Refresh the DataGridView
                            await LoadTheThangData("", true, false, false, null); // Also refresh monthly cards, clearing the list
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    HideLoading(); // Hide loading indicator
                }
            }
        }

        private string ExportKhachHangToExcel(DataTable dataTable, String filename)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            Excel.Range headerRange = null;
            Excel.Range dataRange = null;

            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.Sheets[1];

                int columnCount = dataTable.Columns.Count;
                int rowCount = dataTable.Rows.Count;

                object[] header = new object[columnCount];
                for (int col = 0; col < columnCount; col++)
                {
                    header[col] = dataTable.Columns[col].ColumnName;
                }
                headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, columnCount]];
                headerRange.Value = header;
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                Marshal.ReleaseComObject(headerRange);

                object[,] data = new object[rowCount, columnCount];
                for (int row = 0; row < rowCount; row++)
                {
                    for (int col = 0; col < columnCount; col++)
                    {
                        data[row, col] = dataTable.Rows[row][col]?.ToString() ?? "";
                    }
                }
                dataRange = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[rowCount + 1, columnCount]];
                dataRange.Value = data;
                Marshal.ReleaseComObject(dataRange);

                worksheet.Columns.AutoFit();

                string serverAddress = txtServer;
                string sharedFolderValue = Properties.Settings.Default.SharedFolder;

                int index = serverAddress.IndexOf(@"\SQLEXPRESS", StringComparison.OrdinalIgnoreCase);
                if (index != -1)
                {
                    serverAddress = serverAddress.Remove(index, @"\SQLEXPRESS".Length).Trim();
                }
                string networkPath = Path.Combine("\\" + serverAddress, sharedFolderValue);

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.InitialDirectory = networkPath;
                    sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";
                    sfd.Title = "Lưu file Excel danh sách khách hàng";
                    sfd.FileName = $"XUAT-DU-LIEU-DANH-SACH-KHACH-HANG-{DateTime.Now:dd-MM-yyyy}.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(sfd.FileName);
                        return sfd.FileName;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            finally
            {
                if (workbook != null)
                {
                    workbook.Close(false);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                }

                if (headerRange != null) Marshal.ReleaseComObject(headerRange);
                if (dataRange != null) Marshal.ReleaseComObject(dataRange);
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private async void btnExportExcel_KH_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang_KH.DataSource == null || !(dgvKhachHang_KH.DataSource is DataTable) || ((DataTable)dgvKhachHang_KH.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu khách hàng để xuất ra Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowLoading();
            try
            {
                DataTable dataTable = (DataTable)dgvKhachHang_KH.DataSource;
                string exportedFilePath = await RunSTATask<string>(() => ExportKhachHangToExcel(dataTable, "DANH-SACH-KHACH-HANG"));

                // This code runs *after* the background task is complete
                HideLoading(); // Hide loading indicator first

                if (!string.IsNullOrEmpty(exportedFilePath))
                {
                    kh_export_path = Path.GetDirectoryName(exportedFilePath);
                    MessageBox.Show(this, "Xuất dữ liệu khách hàng ra Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // If exportedFilePath is null, it means the user cancelled the SaveFileDialog. Do nothing.
            }
            catch (Exception ex)
            {
                HideLoading(); // Ensure loading is hidden on error
                MessageBox.Show(this, $"Lỗi khi xuất dữ liệu khách hàng ra Excel: {ex.InnerException?.Message ?? ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMo_KH_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(kh_export_path))
            {
                if (Directory.Exists(kh_export_path))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(kh_export_path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể mở thư mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Thư mục không tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chưa có đường dẫn thư mục nào được lưu. Vui lòng xuất file Excel trước.", "Thông báo", MessageBoxButtons.OK); 
            }
        }

        #endregion

        #region Thẻ Tháng (Monthly Cards) Tab

        private async Task LoadTheThangData(string searchTerm = "", bool searchByCardID = true, bool showExpired = false, bool showLocked = false, List<string> maKHFilters = null)
        {
            const int maxParametersPerBatch = 2000; // SQL Server limit is 2100, use 2000 for safety

            var allResults = new DataTable(); // DataTable to collect results from all batches

            // InitializeDatabaseConnection(); // Ensure connection is open

            var whereClauses = new List<string>();
            var parameters = new List<SqlParameter>();

            string query = @"
                SELECT
                    tt.SoTT AS 'Số thẻ',
                    tt.soxe AS 'Biển số',
                    kh.DonVi AS 'Đơn vị',
                    kh.DiaChi AS 'Địa chỉ',
                    kh.hoten AS 'Họ tên',
                    tt.CardID AS 'Mã thẻ',
                    tt.MaLoaiThe AS 'Loại thẻ',
                    tt.NgayBD AS 'Ngày bắt đầu',
                    tt.NgayKT AS 'Ngày kết thúc',
                    tt.nguoicap AS 'Người cấp',
                    tt.giatien AS 'Giá tiền',
                    tt.datcoc AS 'Đặt cọc',
                    kh.dienthoai AS 'Điện thoại',
                    kh.chungloai AS 'Chủng loại'
                FROM
                    TheThang tt
                INNER JOIN
                    KhachHang kh ON tt.MaKH = kh.MaKH";



            // Conditional TTrang filter based on showLocked
            if (showLocked)
            {
                whereClauses.Add("tt.TTrang = 5");
            }
            else
            {
                whereClauses.Add("tt.TTrang = 1");
            }

            // Conditional NgayKT filter based on showExpired
            if (showExpired)
            {
                whereClauses.Add("tt.NgayKT < GETDATE()");
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                if (searchByCardID)
                {
                    whereClauses.Add("tt.SoTT LIKE @searchTerm");
                }
                else // Search by license plate
                {
                    whereClauses.Add("tt.soxe LIKE @searchTerm");
                }
                parameters.Add(new SqlParameter("@searchTerm", "%" + searchTerm + "%"));
            }


            // Handle MaKH filters with batching
            if (maKHFilters != null && maKHFilters.Any() && maKHFilters.Count > maxParametersPerBatch)
            {
                // Batching is required for maKHFilters
                for (int i = 0; i < maKHFilters.Count; i += maxParametersPerBatch)
                {
                    List<string> currentBatch = maKHFilters.Skip(i).Take(maxParametersPerBatch).ToList();
                    
                    // Create batch-specific parameters and where clause
                    var batchParameters = new List<SqlParameter>();
                    var batchMaKHParamNames = currentBatch.Select((makh, idx) => $"@maKHFilter{idx}").ToList();
                    string batchMaKHWhereClause = $"tt.MaKH IN ({string.Join(", ", batchMaKHParamNames)})";
                    for (int idx = 0; idx < currentBatch.Count; idx++)
                    {
                        batchParameters.Add(new SqlParameter($"@maKHFilter{idx}", currentBatch[idx]));
                    }

                    // Clone other parameters and where clauses to avoid modifying them for the next batch
                    var currentBatchWhereClauses = new List<string>(whereClauses);
                    currentBatchWhereClauses.Add(batchMaKHWhereClause);

                    // Construct the full query for the current batch
                    string batchQuery = query;
                    if (currentBatchWhereClauses.Any())
                    {
                        batchQuery += " WHERE " + string.Join(" AND ", currentBatchWhereClauses);
                    }

                    DataTable batchDataTable = await _ExecuteTheThangQueryAndLoadData(batchQuery, batchParameters, connection);
                    if (allResults.Rows.Count == 0) // If it's the first batch, copy structure
                    {
                        allResults = batchDataTable.Clone();
                    }
                    foreach (DataRow row in batchDataTable.Rows)
                    {
                        allResults.ImportRow(row);
                    }
                }
            }
            else // No batching required (maKHFilters is null/empty or small)
            {
                // If maKHFilters is present but small enough, add its clause to whereClauses
                if (maKHFilters != null && maKHFilters.Any())
                {
                    var maKHParamNames = maKHFilters.Select((makh, index) => $"@maKHFilter{index}").ToList();
                    whereClauses.Add($"tt.MaKH IN ({string.Join(", ", maKHParamNames)})");
                    for (int i = 0; i < maKHFilters.Count; i++)
                    {
                        parameters.Add(new SqlParameter($"@maKHFilter{i}", maKHFilters[i]));
                    }
                }

                // Proceed with existing whereClauses and parameters
                string finalQuery = query;
                if (whereClauses.Any())
                {
                    finalQuery += " WHERE " + string.Join(" AND ", whereClauses);
                }
                allResults = await _ExecuteTheThangQueryAndLoadData(finalQuery, parameters, connection);
            }

            dgvTheThang_KH.DataSource = allResults;

            // Automatically select the row if only one exists
            if (allResults.Rows.Count == 1)
            {
                dgvTheThang_KH.Rows[0].Selected = true;
                dgvTheThang_KH.CurrentCell = dgvTheThang_KH.Rows[0].Cells[0];
                PopulateTheThangDetails(dgvTheThang_KH.Rows[0]);
            }

            // Count active monthly cards (TTrang = 1)
            string countQuery = "SELECT COUNT(*) FROM TheThang WHERE TTrang = 1";
            try
            {
                 if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }
                using (SqlCommand countCommand = new SqlCommand(countQuery, connection))
                {
                    object result = await countCommand.ExecuteScalarAsync();
                    if (result != null && result != DBNull.Value)
                    {
                        int count = Convert.ToInt32(result);
                        txtCountTT.Text = $"Số lượng: {count}";
                    }
                    else
                    {
                        txtCountTT.Text = "Số lượng: 0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đếm thẻ tháng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Connection management is assumed to be handled by the caller or InitializeDatabaseConnection()
            }
        }

        private async Task<DataTable> _ExecuteTheThangQueryAndLoadData(string query, List<SqlParameter> parameters, SqlConnection connection)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandTimeout = 120; // 2 minutes timeout
                    command.Parameters.AddRange(parameters.ToArray());
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu thẻ tháng (nội bộ): {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }

        private void PopulateTheThangDetails(DataGridViewRow row)
        {
            // Populate dtTu_TT with "Ngày bắt đầu"
            if (row.Cells["Ngày bắt đầu"].Value != null && DateTime.TryParse(row.Cells["Ngày bắt đầu"].Value.ToString(), out DateTime ngayBD))
            {
                dtTu_TT.Value = ngayBD;
            }
            else
            {
                dtTu_TT.Value = DateTime.Now; // Default to current date if parsing fails
            }

            // Populate dtDen_TT with "Ngày kết thúc"
            if (row.Cells["Ngày kết thúc"].Value != null && DateTime.TryParse(row.Cells["Ngày kết thúc"].Value.ToString(), out DateTime ngayKT))
            {
                dtDen_TT.Value = ngayKT;
            }
            else
            {
                dtDen_TT.Value = DateTime.Now; // Default to current date if parsing fails
            }

            // Populate txtBienSo_TT with "Biển số"
            txtBienSo_TT.Text = row.Cells["Biển số"].Value?.ToString();

            // Populate cbbLoai_TTr and cbbLoaiThe_TT with "Loại thẻ"
            string maLoaiThe = row.Cells["Loại thẻ"].Value?.ToString();
            if (!string.IsNullOrEmpty(maLoaiThe))
            {
                cbbLoai_TTr.SelectedValue = maLoaiThe;
                cbbLoaiThe_TT.SelectedValue = maLoaiThe;
            }
            else
            {
                cbbLoai_TTr.SelectedIndex = -1; // Clear selection
                cbbLoaiThe_TT.SelectedIndex = -1; // Clear selection
            }
        }

        private void dgvTheThang_KH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTheThang_KH.Rows[e.RowIndex];
                PopulateTheThangDetails(row);
            }
        }

        private DataGridViewRow GetSelectedTheThangRow()
        {
            if (dgvTheThang_KH.CurrentRow == null || dgvTheThang_KH.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn một thẻ tháng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return dgvTheThang_KH.CurrentRow;
        }

        private async void btnUpdateBienSo_KH_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = GetSelectedTheThangRow();
            if (selectedRow == null) return;

            string cardID = selectedRow.Cells["Mã thẻ"].Value?.ToString();
            string soTT = selectedRow.Cells["Số thẻ"].Value?.ToString();
            string newBienSo = txtBienSo_TT.Text.Trim();

            if (string.IsNullOrEmpty(cardID) || string.IsNullOrEmpty(soTT))
            {
                MessageBox.Show("Không thể xác định thẻ tháng để cập nhật. Vui lòng chọn một thẻ hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                string query = "UPDATE TheThang SET soxe = @newBienSo WHERE CardID = @cardID AND SoTT = @soTT";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newBienSo", newBienSo);
                    command.Parameters.AddWithValue("@cardID", cardID);
                    command.Parameters.AddWithValue("@soTT", soTT);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật biển số thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadTheThangData(maKHFilters: new List<string> { _selectedMaKH }); // Refresh data
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thẻ tháng để cập nhật hoặc không có thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật biển số: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdateLoaiThe_KH_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = GetSelectedTheThangRow();
            if (selectedRow == null) return;

            string cardID = selectedRow.Cells["Mã thẻ"].Value?.ToString();
            string soTT = selectedRow.Cells["Số thẻ"].Value?.ToString();
            string newMaLoaiThe = cbbLoaiThe_TT.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(cardID) || string.IsNullOrEmpty(soTT) || string.IsNullOrEmpty(newMaLoaiThe))
            {
                MessageBox.Show("Không thể xác định thẻ tháng hoặc loại thẻ mới để cập nhật. Vui lòng chọn một thẻ hợp lệ và loại thẻ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                string query = "UPDATE TheThang SET MaLoaiThe = @newMaLoaiThe WHERE CardID = @cardID AND SoTT = @soTT";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newMaLoaiThe", newMaLoaiThe);
                    command.Parameters.AddWithValue("@cardID", cardID);
                    command.Parameters.AddWithValue("@soTT", soTT);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật loại thẻ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadTheThangData(maKHFilters: new List<string> { _selectedMaKH }); // Refresh data
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thẻ tháng để cập nhật hoặc không có thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật loại thẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdateDate_KH_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = GetSelectedTheThangRow();
            if (selectedRow == null) return;

            string cardID = selectedRow.Cells["Mã thẻ"].Value?.ToString();
            string soTT = selectedRow.Cells["Số thẻ"].Value?.ToString();
            DateTime newNgayBD = dtTu_TT.Value;
            DateTime newNgayKT = dtDen_TT.Value;

            if (string.IsNullOrEmpty(cardID) || string.IsNullOrEmpty(soTT))
            {
                MessageBox.Show("Không thể xác định thẻ tháng để cập nhật. Vui lòng chọn một thẻ hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newNgayBD > newNgayKT)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.", "Lỗi ngày", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                string query = "UPDATE TheThang SET NgayBD = @newNgayBD, NgayKT = @newNgayKT WHERE CardID = @cardID AND SoTT = @soTT";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newNgayBD", newNgayBD);
                    command.Parameters.AddWithValue("@newNgayKT", newNgayKT);
                    command.Parameters.AddWithValue("@cardID", cardID);
                    command.Parameters.AddWithValue("@soTT", soTT);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật ngày hiệu lực thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadTheThangData(maKHFilters: new List<string> { _selectedMaKH }); // Refresh data
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thẻ tháng để cập nhật hoặc không có thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật ngày hiệu lực: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGiaHan_TT_Click(object sender, EventArgs e)
        {
            if (dgvTheThang_KH.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một thẻ để gia hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime newNgayKT = dtDen_TT.Value;
            int selectedCount = dgvTheThang_KH.SelectedRows.Count;

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn gia hạn {selectedCount} thẻ đã chọn đến ngày {newNgayKT:dd/MM/yyyy} không?", "Xác nhận gia hạn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No)
            {
                return;
            }

            List<string> soTTList = new List<string>();
            foreach (DataGridViewRow row in dgvTheThang_KH.SelectedRows)
            {
                string soTT = row.Cells["Số thẻ"].Value?.ToString();
                if (!string.IsNullOrEmpty(soTT))
                {
                    soTTList.Add(soTT);
                }
            }

            if (soTTList.Count == 0)
            {
                MessageBox.Show("Không có thẻ hợp lệ nào được chọn để gia hạn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ShowLoading();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                int batchSize = 500;
                int totalRowsAffected = 0;
                for (int i = 0; i < soTTList.Count; i += batchSize)
                {
                    var batch = soTTList.Skip(i).Take(batchSize).ToList();
                    if (!batch.Any()) continue;

                    List<string> paramNames = new List<string>();
                    SqlCommand command = new SqlCommand();
                    command.CommandTimeout = 120; // 2 minutes timeout
                    for (int j = 0; j < batch.Count; j++)
                    {
                        string paramName = "@soTT" + j;
                        paramNames.Add(paramName);
                        command.Parameters.AddWithValue(paramName, batch[j]);
                    }

                    string query = $"UPDATE TheThang SET NgayKT = @newNgayKT WHERE SoTT IN ({string.Join(", ", paramNames)})";
                    command.CommandText = query;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@newNgayKT", newNgayKT);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    totalRowsAffected += rowsAffected;
                }

                if (totalRowsAffected > 0)
                {
                    MessageBox.Show($"Gia hạn thành công cho {totalRowsAffected} thẻ!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await PerformTheThangSearch(); // Refresh data
                }
                else
                {
                    MessageBox.Show("Không có thẻ nào được gia hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gia hạn thẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HideLoading();
            }
        }

        private async void btnKhoaThe_TT_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = GetSelectedTheThangRow();
            if (selectedRow == null) return;

            string cardID = selectedRow.Cells["Mã thẻ"].Value?.ToString();
            string soTT = selectedRow.Cells["Số thẻ"].Value?.ToString();

            if (string.IsNullOrEmpty(cardID) || string.IsNullOrEmpty(soTT))
            {
                MessageBox.Show("Không thể xác định thẻ tháng để khóa. Vui lòng chọn một thẻ hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn khóa thẻ có Mã thẻ: {cardID} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            SqlTransaction transaction = null;
            bool connectionOpenedHere = false;

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                    connectionOpenedHere = true;
                }
                transaction = connection.BeginTransaction();

                // Update TheThang.TTrang to 5 (Locked)
                string updateTheThangQuery = "UPDATE TheThang SET TTrang = 5 WHERE CardID = @cardID AND SoTT = @soTT";
                using (SqlCommand cmdTheThang = new SqlCommand(updateTheThangQuery, connection, transaction))
                {
                    cmdTheThang.Parameters.AddWithValue("@cardID", cardID);
                    cmdTheThang.Parameters.AddWithValue("@soTT", soTT);
                    await cmdTheThang.ExecuteNonQueryAsync();
                }

                // Update Active.trangthai to 5 (Locked)
                //string updateActiveQuery = "UPDATE Active SET trangthai = 5 WHERE sttthe = @soTT";
                //using (SqlCommand cmdActive = new SqlCommand(updateActiveQuery, connection, transaction))
                //{
                //    cmdActive.Parameters.AddWithValue("@soTT", soTT);
                //    await cmdActive.ExecuteNonQueryAsync();
                //}

                transaction.Commit();
                MessageBox.Show("Khóa thẻ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadTheThangData(maKHFilters: new List<string> { _selectedMaKH }); // Refresh data
            }
            catch (Exception ex)
            {
                if(transaction != null) transaction.Rollback();
                MessageBox.Show($"Lỗi khi khóa thẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connectionOpenedHere && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private async void btnThuHoiThe_TT_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = GetSelectedTheThangRow();
            if (selectedRow == null) return;

            string cardID = selectedRow.Cells["Mã thẻ"].Value?.ToString();
            string soTT = selectedRow.Cells["Số thẻ"].Value?.ToString();

            if (string.IsNullOrEmpty(cardID) || string.IsNullOrEmpty(soTT))
            {
                MessageBox.Show("Không thể xác định thẻ tháng để thu hồi. Vui lòng chọn một thẻ hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn thu hồi thẻ có Số: {soTT} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            SqlTransaction transaction = null;
            bool connectionOpenedHere = false;

            try
            {
                ShowLoading(); // Show loading indicator
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    connectionOpenedHere = true;
                }
                transaction = connection.BeginTransaction();

                // Update Active.trangthai to 1 (Active/Reclaimed)
                string updateActiveQuery = "UPDATE Active SET trangthai = 1 WHERE sttthe = @soTT";
                using (SqlCommand cmdActive = new SqlCommand(updateActiveQuery, connection, transaction))
                {
                    cmdActive.Parameters.AddWithValue("@soTT", soTT);
                    cmdActive.ExecuteNonQuery();
                }

                // Delete from TheThang table
                string deleteTheThangQuery = "DELETE FROM TheThang WHERE CardID = @cardID AND SoTT = @soTT";
                using (SqlCommand cmdTheThang = new SqlCommand(deleteTheThangQuery, connection, transaction))
                {
                    cmdTheThang.Parameters.AddWithValue("@cardID", cardID);
                    cmdTheThang.Parameters.AddWithValue("@soTT", soTT);
                    cmdTheThang.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Thu hồi thẻ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadTheThangData(maKHFilters: new List<string> { _selectedMaKH });               
                    await LoadTheTrongData();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Lỗi khi thu hồi thẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HideLoading(); // Hide loading indicator
                if (connectionOpenedHere && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private async void btnBaoMatThe_TT_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = GetSelectedTheThangRow();
            if (selectedRow == null) return;

            string cardID = selectedRow.Cells["Mã thẻ"].Value?.ToString();
            string soTT = selectedRow.Cells["Số thẻ"].Value?.ToString();

            if (string.IsNullOrEmpty(cardID) || string.IsNullOrEmpty(soTT))
            {
                MessageBox.Show("Không thể xác định thẻ tháng để báo mất. Vui lòng chọn một thẻ hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn báo mất thẻ có Mã thẻ: {cardID} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            SqlTransaction transaction = null;
            bool connectionOpenedHere = false;

            try
            {
                ShowLoading(); // Show loading indicator
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    connectionOpenedHere = true;
                }
                transaction = connection.BeginTransaction();

                // Update TheThang.TTrang to 9 (Lost/Stolen)
                string updateTheThangQuery = "DELETE TheThang WHERE CardID = @cardID AND SoTT = @soTT";
                using (SqlCommand cmdTheThang = new SqlCommand(updateTheThangQuery, connection, transaction))
                {
                    cmdTheThang.Parameters.AddWithValue("@cardID", cardID);
                    cmdTheThang.Parameters.AddWithValue("@soTT", soTT);
                    cmdTheThang.ExecuteNonQuery();
                }

                // Update Active.trangthai to 0 (Lost/Inactive)
                string updateActiveQuery = "UPDATE Active SET trangthai = 0 WHERE sttthe = @soTT";
                using (SqlCommand cmdActive = new SqlCommand(updateActiveQuery, connection, transaction))
                {
                    cmdActive.Parameters.AddWithValue("@soTT", soTT);
                    cmdActive.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Báo mất thẻ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadTheThangData(maKHFilters: new List<string> { _selectedMaKH }); // Refresh data
                await LoadTheTrongData();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Lỗi khi báo mất thẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HideLoading(); // Hide loading indicator
                if (connectionOpenedHere && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private async void txtThe_TT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await PerformTheThangSearch();
                e.SuppressKeyPress = true;
            }
        }

        private async void rbSoThe_TT_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSoThe_TT.Checked)
            {
                rbBienSo_TT.Checked = false;
                await PerformTheThangSearch();
            }
        }

        private async void rbBienSo_TT_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBienSo_TT.Checked)
            {
                rbSoThe_TT.Checked = false;
                await PerformTheThangSearch();
            }
        }

        private async Task PerformTheThangSearch()
        {
            string searchTerm = txtThe_TT.Text.Trim();
            bool searchByCardID = rbSoThe_TT.Checked;
            bool showExpired = cbExDate_TT.Checked; // Get state of cbExDate_TT
            bool showLocked = cbKhoa_TT.Checked;   // Get state of cbKhoa_TT
            await LoadTheThangData(searchTerm, searchByCardID, showExpired, showLocked);
        }

        private async void cbExDate_TT_CheckedChanged(object sender, EventArgs e)
        {
            await PerformTheThangSearch();
        }

        private async void cbKhoa_TT_CheckedChanged(object sender, EventArgs e)
        {
            await PerformTheThangSearch();
        }

        private string ExportTheThangToExcel(DataTable dataTable, String filename)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            Excel.Range headerRange = null;
            Excel.Range dataRange = null;

            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.Sheets[1];

                int columnCount = dataTable.Columns.Count;
                int rowCount = dataTable.Rows.Count;

                object[] header = new object[columnCount];
                for (int col = 0; col < columnCount; col++)
                {
                    header[col] = dataTable.Columns[col].ColumnName;
                }
                headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, columnCount]];
                headerRange.Value = header;
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                Marshal.ReleaseComObject(headerRange);

                object[,] data = new object[rowCount, columnCount];
                for (int row = 0; row < rowCount; row++)
                {
                    for (int col = 0; col < columnCount; col++)
                    {
                        data[row, col] = dataTable.Rows[row][col]?.ToString() ?? "";
                    }
                }
                dataRange = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[rowCount + 1, columnCount]];
                dataRange.Value = data;
                Marshal.ReleaseComObject(dataRange);

                worksheet.Columns.AutoFit();

                string serverAddress = txtServer;
                string sharedFolderValue = Properties.Settings.Default.SharedFolder;

                int index = serverAddress.IndexOf(@"\SQLEXPRESS", StringComparison.OrdinalIgnoreCase);
                if (index != -1)
                {
                    serverAddress = serverAddress.Remove(index, @"\SQLEXPRESS".Length).Trim();
                }
                string networkPath = Path.Combine("\\" + serverAddress, sharedFolderValue);

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.InitialDirectory = networkPath;
                    sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";
                    sfd.Title = "Lưu file Excel danh sách thẻ tháng";
                    sfd.FileName = $"XUAT-DU-LIEU-DANH-SACH-THE-THANG-{DateTime.Now:dd-MM-yyyy}.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(sfd.FileName);
                        return sfd.FileName;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            finally
            {
                if (workbook != null)
                {
                    workbook.Close(false);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                }

                if (headerRange != null) Marshal.ReleaseComObject(headerRange);
                if (dataRange != null) Marshal.ReleaseComObject(dataRange);
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private async void btnExportExcel_TT_Click(object sender, EventArgs e)
        {
            if (dgvTheThang_KH.DataSource == null || !(dgvTheThang_KH.DataSource is DataTable) || ((DataTable)dgvTheThang_KH.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu thẻ tháng để xuất ra Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowLoading();
            try
            {
                DataTable dataTable = (DataTable)dgvTheThang_KH.DataSource;
                string exportedFilePath = await RunSTATask<string>(() => ExportTheThangToExcel(dataTable, "DANH-SACH-THE-THANG"));

                HideLoading();

                if (!string.IsNullOrEmpty(exportedFilePath))
                {
                    tt_export_path = Path.GetDirectoryName(exportedFilePath);
                    MessageBox.Show(this, "Xuất dữ liệu thẻ tháng ra Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                HideLoading();
                MessageBox.Show(this, $"Lỗi khi xuất dữ liệu thẻ tháng ra Excel: {ex.InnerException?.Message ?? ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMo_TT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tt_export_path))
            {
                if (Directory.Exists(tt_export_path))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(tt_export_path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể mở thư mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Thư mục không tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chưa có đường dẫn thư mục nào được lưu. Vui lòng xuất file Excel trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnMoThe_TT_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = GetSelectedTheThangRow();
            if (selectedRow == null) return;

            string soTT = selectedRow.Cells["Số thẻ"].Value?.ToString();
            if (string.IsNullOrEmpty(soTT))
            {
                MessageBox.Show("Không thể xác định thẻ để mở khóa. Vui lòng chọn một thẻ hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                InitializeDatabaseConnection();
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                // Check current status
                int currentTTrang = -1;
                string checkStatusQuery = "SELECT TTrang FROM TheThang WHERE SoTT = @soTT";
                using (SqlCommand checkCmd = new SqlCommand(checkStatusQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@soTT", soTT);
                    object result = checkCmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        currentTTrang = Convert.ToInt32(result);
                    }
                }

                if (currentTTrang != 5)
                {
                    MessageBox.Show("Thẻ này không bị khóa. Không cần thực hiện hành động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn mở khóa thẻ có Số thẻ: {soTT} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.No) return;

                string updateQuery = "UPDATE TheThang SET TTrang = 1 WHERE SoTT = @soTT";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@soTT", soTT);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Mở khóa thẻ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await PerformTheThangSearch(); // Refresh data to show the change
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thẻ để mở khóa hoặc không có thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở khóa thẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Thẻ Trống (Empty Cards) / Cấp Thẻ (Card Issuance)

        private async Task LoadTheTrongData(string searchTerm = "")
        {
            // InitializeDatabaseConnection(); // Ensure connection is open

            string query = @"
                SELECT
                    sttthe AS 'Số thẻ',
                    CardID AS 'Mã thẻ'
                FROM
                    Active
                WHERE trangthai = 1"; // Assuming 'Active' is the table name

            var whereClauses = new List<string>();
            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                whereClauses.Add("sttthe LIKE @searchTerm");
                parameters.Add(new SqlParameter("@searchTerm", searchTerm + "%"));
            }

            if (whereClauses.Any())
            {
                query += " AND " + string.Join(" AND ", whereClauses);
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandTimeout = 120; // 2 minutes timeout
                    command.Parameters.AddRange(parameters.ToArray());
                    DataTable dataTable = new DataTable();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        dataTable.Load(reader);
                    }

                    dgvTheTrong_KH.SuspendLayout();
                    dgvTheTrong_KH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    dgvTheTrong_KH.DataSource = dataTable;
                    dgvTheTrong_KH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Auto-fill columns
                    dgvTheTrong_KH.ResumeLayout();

                    // If exactly one row is returned, automatically select it and trigger CellClick
                    if (dataTable.Rows.Count == 1)
                    {
                        dgvTheTrong_KH.CurrentCell = dgvTheTrong_KH.Rows[0].Cells[0];
                        dgvTheTrong_KH.Rows[0].Selected = true;
                        dgvTheTrong_KH_CellClick(dgvTheTrong_KH, new DataGridViewCellEventArgs(0, 0)); // Simulate click on the first cell
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu thẻ trống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void dgvTheTrong_KH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTheTrong_KH.Rows[e.RowIndex];

                _selectedCardID = row.Cells["Mã thẻ"].Value?.ToString();
                _selectedSTT = Convert.ToInt32(row.Cells["Số thẻ"].Value);
            }
        }

        private async Task PerformTheTrongSearch()
        {
            string searchTerm = txtThe_TTr.Text.Trim();
            await LoadTheTrongData(searchTerm);
        }

        private async void txtThe_TTr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await PerformTheTrongSearch();
                e.SuppressKeyPress = true;
            }
        }

        private async void btnCapThe_TTr_Click(object sender, EventArgs e)
        {
            // 2. Lấy dữ liệu vào biến tạm (tránh bị Clear UI làm mất dữ liệu)
            string maKH = _selectedMaKH;
            string cardID = _selectedCardID;
            string soTT = _selectedSTT.ToString();
            string maLoaiThe = cbbLoai_TTr.Text.Trim();
            DateTime ngayBD = dtTu_TTr.Value;
            DateTime ngayKT = dtDen_TTr.Value;
            string soxe = txtBienSo_TTr.Text.Trim();
            int tTrang = 1; // Active
            string giatien = "0";
            string datcoc = "0";
            string nguoicap = "admin";

            // 3. Kiểm tra dữ liệu bắt buộc
            if (string.IsNullOrEmpty(maKH) || string.IsNullOrEmpty(soTT) ||
                string.IsNullOrEmpty(cardID) || string.IsNullOrEmpty(maLoaiThe))
            {
                MessageBox.Show(
                    $"Không thể lấy đủ thông tin cần thiết để cấp thẻ.\n\n" +
                    "Vui lòng chọn Khách hàng và Số thẻ muốn cấp!:\n",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return; // Không chạy tiếp
            }

            //4.Thao tác Database với Transaction
            SqlTransaction transaction = null;
            bool connectionOpenedHere = false;

            try
            {
                InitializeDatabaseConnection(); // Đảm bảo connection được khởi tạo

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                connectionOpenedHere = true;
            }

            // Check if MaKH already has a card in TheThang
            string checkMaKHQuery = "SELECT COUNT(*) FROM TheThang WHERE MaKH = @MaKH AND TTrang = 1";
            using (SqlCommand checkMaKHCmd = new SqlCommand(checkMaKHQuery, connection))
            {
                checkMaKHCmd.Parameters.AddWithValue("@MaKH", maKH);
                int existingMaKHCount = (int)checkMaKHCmd.ExecuteScalar();
                if (existingMaKHCount > 0)
                {
                    MessageBox.Show($"Mã khách hàng '{maKH}' này đã có thẻ tháng. Mỗi khách hàng chỉ được có một thẻ tháng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    connectionOpenedHere = true;
                }

                // Check for uniqueness in TheThang before inserting
                string checkUniqueQuery = "SELECT COUNT(*) FROM TheThang WHERE SoTT = @SoTT OR CardID = @CardID";
                using (SqlCommand checkUniqueCmd = new SqlCommand(checkUniqueQuery, connection))
                {
                    checkUniqueCmd.Parameters.AddWithValue("@SoTT", soTT);
                    checkUniqueCmd.Parameters.AddWithValue("@CardID", cardID);
                    int existingCount = (int)checkUniqueCmd.ExecuteScalar();
                    if (existingCount > 0)
                    {
                        MessageBox.Show("Số thẻ hoặc Mã thẻ đã tồn tại trong bảng Thẻ Tháng. Vui lòng kiểm tra lại.", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Exit the method if not unique
                    }
                }

                transaction = connection.BeginTransaction();

                // 4a. Insert vào TheThang
                string insertTheThangQuery = @"
            INSERT INTO TheThang (CardID, SoTT, MaKH, TTrang, MaLoaiThe, NgayBD, NgayKT, soxe, nguoicap, giatien, datcoc)
            VALUES (@CardID, @SoTT, @MaKH, @TTrang, @MaLoaiThe, @NgayBD, @NgayKT, @soxe, @nguoicap, @giatien, @datcoc)";

                using (SqlCommand cmdInsert = new SqlCommand(insertTheThangQuery, connection, transaction))
                {
                    cmdInsert.Parameters.AddWithValue("@CardID", cardID);
                    cmdInsert.Parameters.AddWithValue("@SoTT", soTT);
                    cmdInsert.Parameters.AddWithValue("@MaKH", maKH);
                    cmdInsert.Parameters.AddWithValue("@TTrang", tTrang);
                    cmdInsert.Parameters.AddWithValue("@MaLoaiThe", maLoaiThe);
                    cmdInsert.Parameters.AddWithValue("@NgayBD", ngayBD);
                    cmdInsert.Parameters.AddWithValue("@NgayKT", ngayKT);
                    cmdInsert.Parameters.AddWithValue("@soxe", soxe);
                    cmdInsert.Parameters.AddWithValue("@nguoicap", nguoicap);
                    cmdInsert.Parameters.AddWithValue("@giatien", giatien);
                    cmdInsert.Parameters.AddWithValue("@datcoc", datcoc);

                    cmdInsert.ExecuteNonQuery();
                }

                // 4b. Update Active table
                string updateActiveQuery = "UPDATE Active SET trangthai = 2 WHERE CardID = @CardID";
                using (SqlCommand cmdUpdateActive = new SqlCommand(updateActiveQuery, connection, transaction))
                {
                    cmdUpdateActive.Parameters.AddWithValue("@CardID", cardID);
                    cmdUpdateActive.ExecuteNonQuery();
                }

                transaction.Commit();

                MessageBox.Show("Cấp thẻ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 5. Load lại dữ liệu
                await LoadTheThangData("", true, false, false, null);
                await LoadTheTrongData();

                // 6. Clear UI
                txtThe_TTr.Clear();
                txtBienSo_TTr.Clear();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Lỗi khi cấp thẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connectionOpenedHere && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        #endregion

        #region Tra Cứu Thẻ (Card Lookup) Tab

        private void LoadActiveDataGrid(string soThe = "")
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "SELECT sttthe AS 'Số thẻ', CardID as 'Mã thẻ', trangthai AS 'Trạng thái' FROM Active";
                var parameters = new List<SqlParameter>();
                var whereClauses = new List<string>();

                if (!string.IsNullOrEmpty(soThe))
                {
                    whereClauses.Add("sttthe LIKE @soThe");
                    parameters.Add(new SqlParameter("@soThe", soThe + "%"));
                }

                if (whereClauses.Any())
                {
                    query += " WHERE " + string.Join(" AND ", whereClauses);
                }


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandTimeout = 120; // 2 minutes timeout
                    if (parameters.Any())
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                    }

                    // 4. Sử dụng using cho SqlDataAdapter
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();

                        // Fill() tự động xử lý DataReader nội bộ
                        adapter.Fill(dataTable);
                        guna2DataGridView3.SuspendLayout();
                        guna2DataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                        guna2DataGridView3.DataSource = dataTable;
                        guna2DataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        guna2DataGridView3.ResumeLayout();
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show($"Lỗi khi tải dữ liệu thẻ Active: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async void btnTim_TTT_Click(object sender, EventArgs e)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // 1. Reset UI elements
            txtMaThe_TTT.Clear();
            txtTinhTrang_TTT1.Text = "Chưa tìm kiếm";
            txtTinhTrang_TTT2.Text = "Chưa tìm kiếm";
            guna2DataGridView3.DataSource = null;
            btnBaoMat_TTT.Enabled = false;
            btnKhoiPhuc_TTT.Enabled = false;

            string soThe = txtSoThe_TTT.Text.Trim();

            if (string.IsNullOrEmpty(soThe))
            {
                MessageBox.Show("Vui lòng nhập Số thẻ để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadActiveDataGrid(); // Load all cards if search is cleared
                return;
            }

            try
            {
                InitializeDatabaseConnection();
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string cardID = "";
                int trangThai = -1;

                // 2. Query Active table
                string queryActive = "SELECT CardID, trangthai FROM Active WHERE sttthe = @soThe";
                using (SqlCommand cmdActive = new SqlCommand(queryActive, connection))
                {
                    cmdActive.Parameters.AddWithValue("@soThe", soThe);
                    using (SqlDataReader readerActive = cmdActive.ExecuteReader())
                    {
                        if (readerActive.Read())
                        {
                            cardID = readerActive["CardID"].ToString();
                            trangThai = Convert.ToInt32(readerActive["trangthai"]);
                        }
                    } // readerActive is closed here
                }

                // 3. Process the results
                if (trangThai != -1)
                {
                    txtMaThe_TTT.Text = cardID;

                    switch (trangThai)
                    {
                        case 0:
                            txtTinhTrang_TTT1.Text = "Thẻ mất";
                            txtTinhTrang_TTT2.Text = "Không áp dụng";
                            btnBaoMat_TTT.Enabled = false;
                            btnKhoiPhuc_TTT.Enabled = true;
                            break;
                        case 1:
                            txtTinhTrang_TTT1.Text = "Thẻ lượt";
                            txtTinhTrang_TTT2.Text = "Không áp dụng";
                            btnBaoMat_TTT.Enabled = true;
                            btnKhoiPhuc_TTT.Enabled = false;
                            break;
                        case 2:
                            txtTinhTrang_TTT1.Text = "Thẻ tháng";
                            btnBaoMat_TTT.Enabled = true;
                            btnKhoiPhuc_TTT.Enabled = false;
                            // Now query TheThang for the second status
                            string queryTheThang = "SELECT TTrang FROM TheThang WHERE SoTT = @soThe";
                            using (SqlCommand cmdTheThang = new SqlCommand(queryTheThang, connection))
                            {
                                cmdTheThang.Parameters.AddWithValue("@soThe", soThe);
                                object result = cmdTheThang.ExecuteScalar();

                                if (result != null)
                                {
                                    int ttrang = Convert.ToInt32(result);
                                    switch (ttrang)
                                    {
                                        case 1:
                                            txtTinhTrang_TTT2.Text = "Đang sử dụng";
                                            break;
                                        case 5:
                                            txtTinhTrang_TTT2.Text = "Đang bị khóa";
                                            btnBaoMat_TTT.Enabled = false; // Cannot report a locked card as lost
                                            btnKhoiPhuc_TTT.Enabled = true; // Can restore a locked card
                                            break;
                                        default:
                                            txtTinhTrang_TTT2.Text = "Trạng thái không xác định";
                                            break;
                                    }
                                }
                                else
                                {
                                    txtTinhTrang_TTT2.Text = "Lỗi: Không tìm thấy trong TheThang";
                                }
                            }
                            break;
                        default:
                            txtTinhTrang_TTT1.Text = "Trạng thái không xác định";
                            txtTinhTrang_TTT2.Text = "Không áp dụng";
                            break;
                    }

                    // 4. Update the DataGridView to show only the found card
                    LoadActiveDataGrid(soThe);
                }
                else
                {
                    txtTinhTrang_TTT1.Text = "Không tìm thấy thẻ";
                    txtTinhTrang_TTT2.Text = "Không áp dụng";
                    MessageBox.Show("Không tìm thấy thông tin cho số thẻ này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi truy vấn dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }



        private (string soTT, string cardID) GetCardIdentifiers(string soTheInput, string maTheInput)
        {
            string soTT = string.Empty;
            string cardID = string.Empty;

            InitializeDatabaseConnection();
            if (connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (string.Empty, string.Empty);
            }

            string query = "SELECT sttthe, CardID FROM Active WHERE ";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(soTheInput))
            {
                query += "sttthe = @soThe";
                parameters.Add(new SqlParameter("@soThe", soTheInput));
            }
            else if (!string.IsNullOrEmpty(maTheInput))
            {
                query += "CardID = @maThe";
                parameters.Add(new SqlParameter("@maThe", maTheInput));
            }
            else
            {
                return (string.Empty, string.Empty); // Should not happen if initial check is done
            }

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            soTT = reader["sttthe"].ToString();
                            cardID = reader["CardID"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy thông tin thẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return (soTT, cardID);
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async void btnBaoMat_TTT_Click(object sender, EventArgs e)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            string soTheInput = txtSoThe_TTT.Text.Trim();
            string maTheInput = txtMaThe_TTT.Text.Trim();

            if (string.IsNullOrEmpty(soTheInput) && string.IsNullOrEmpty(maTheInput))
            {
                MessageBox.Show("Vui lòng nhập Số thẻ hoặc Mã thẻ để báo mất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            (string soTT, string cardID) = GetCardIdentifiers(soTheInput, maTheInput);

            if (string.IsNullOrEmpty(soTT) || string.IsNullOrEmpty(cardID))
            {
                MessageBox.Show("Không tìm thấy thẻ với thông tin đã nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn báo mất thẻ có Số thẻ: {soTT} - Mã thẻ: {cardID} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            SqlTransaction transaction = null;
            bool connectionOpenedHere = false;

            try
            {
                ShowLoading(); // Show loading indicator
                InitializeDatabaseConnection();
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    connectionOpenedHere = true;
                }
                transaction = connection.BeginTransaction();

                // Update TheThang.TTrang to 9 (Lost/Stolen)
                string updateTheThangQuery = "UPDATE TheThang SET TTrang = 9 WHERE CardID = @cardID AND SoTT = @soTT";
                using (SqlCommand cmdTheThang = new SqlCommand(updateTheThangQuery, connection, transaction))
                {
                    cmdTheThang.Parameters.AddWithValue("@cardID", cardID);
                    cmdTheThang.Parameters.AddWithValue("@soTT", soTT);
                    cmdTheThang.ExecuteNonQuery();
                }

                // Update Active.trangthai to 0 (Lost/Inactive)
                string updateActiveQuery = "UPDATE Active SET trangthai = 0 WHERE sttthe = @soTT";
                using (SqlCommand cmdActive = new SqlCommand(updateActiveQuery, connection, transaction))
                {
                    cmdActive.Parameters.AddWithValue("@soTT", soTT);
                    cmdActive.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Báo mất thẻ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Optionally refresh related data or clear fields
                txtTinhTrang_TTT1.Text = "Thẻ mất";
                txtTinhTrang_TTT2.Text = "Trạng thái không xác định"; // TheThang.TTrang = 9 is not directly mapped to a display string here
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Lỗi khi báo mất thẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HideLoading(); // Hide loading indicator
                if (connectionOpenedHere && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async void btnKhoiPhuc_TTT_Click(object sender, EventArgs e)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            string soTheInput = txtSoThe_TTT.Text.Trim();
            string maTheInput = txtMaThe_TTT.Text.Trim();

            if (string.IsNullOrEmpty(soTheInput) && string.IsNullOrEmpty(maTheInput))
            {
                MessageBox.Show("Vui lòng nhập Số thẻ hoặc Mã thẻ để khôi phục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            (string soTT, string cardID) = GetCardIdentifiers(soTheInput, maTheInput);

            if (string.IsNullOrEmpty(soTT) || string.IsNullOrEmpty(cardID))
            {
                MessageBox.Show("Không tìm thấy thẻ với thông tin đã nhập trong bảng Active.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn khôi phục thẻ có Số thẻ: {soTT} -  Mã thẻ: {cardID} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            SqlTransaction transaction = null;
            bool connectionOpenedHere = false;

            try
            {
                InitializeDatabaseConnection();
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    connectionOpenedHere = true;
                }
                transaction = connection.BeginTransaction();

                // --- Step 1: Check if card exists in TheThang ---
                string checkTheThangQuery = "SELECT COUNT(*) FROM TheThang WHERE SoTT = @soTT OR CardID = @cardID";
                int theThangCount;
                using (SqlCommand checkCmd = new SqlCommand(checkTheThangQuery, connection, transaction))
                {
                    checkCmd.Parameters.AddWithValue("@soTT", soTT);
                    checkCmd.Parameters.AddWithValue("@cardID", cardID);
                    theThangCount = (int)checkCmd.ExecuteScalar();
                }

                if (theThangCount > 0)
                {
                    // --- Scenario A: Card exists in TheThang. Now check Active.trangthai = 2 ---
                    string checkActiveStatusQuery = "SELECT trangthai FROM Active WHERE sttthe = @soTT OR CardID = @cardID";
                    int activeTrangThai = -1; // Default to an invalid state
                    using (SqlCommand checkActiveCmd = new SqlCommand(checkActiveStatusQuery, connection, transaction))
                    {
                        checkActiveCmd.Parameters.AddWithValue("@soTT", soTT);
                        checkActiveCmd.Parameters.AddWithValue("@cardID", cardID);
                        object result = checkActiveCmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            activeTrangThai = Convert.ToInt32(result);
                        }
                    }

                    if (activeTrangThai == 2)
                    {
                        // Update TheThang.TTrang to 1
                        string updateTheThangQuery = "UPDATE TheThang SET TTrang = 1 WHERE SoTT = @soTT OR CardID = @cardID";
                        using (SqlCommand cmdTheThang = new SqlCommand(updateTheThangQuery, connection, transaction))
                        {
                            cmdTheThang.Parameters.AddWithValue("@soTT", soTT);
                            cmdTheThang.Parameters.AddWithValue("@cardID", cardID);
                            cmdTheThang.ExecuteNonQuery();
                        }
                        MessageBox.Show("Khôi phục thẻ thành công! Trạng thái thẻ tháng đã được cập nhật.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTinhTrang_TTT1.Text = "Thẻ tháng"; // Assuming 2 means "Thẻ tháng"
                        txtTinhTrang_TTT2.Text = "Đang sử dụng"; // Assuming 1 means "Đang sử dụng"
                    }
                    else
                    {
                        // Card exists in TheThang but Active.trangthai is not 2.
                        // This is an edge case not explicitly covered by user's request.
                        // For now, I will just inform the user.
                        MessageBox.Show($"Thẻ tồn tại trong bảng Thẻ Tháng nhưng trạng thái trong Active không phải là 'Thẻ tháng' (trạng thái hiện tại: {activeTrangThai}). Không thực hiện thay đổi nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // --- Scenario B: Card does NOT exist in TheThang ---
                    // Update Active.trangthai to 1
                    string updateActiveQuery = "UPDATE Active SET trangthai = 1 WHERE sttthe = @soTT OR CardID = @cardID";
                    using (SqlCommand cmdActive = new SqlCommand(updateActiveQuery, connection, transaction))
                    {
                        cmdActive.Parameters.AddWithValue("@soTT", soTT);
                        cmdActive.Parameters.AddWithValue("@cardID", cardID);
                        cmdActive.ExecuteNonQuery();
                    }
                    MessageBox.Show("Khôi phục thẻ thành công! Thẻ đã sẵn sàng để được cấp lại.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTinhTrang_TTT1.Text = "Thẻ lượt";
                    txtTinhTrang_TTT2.Text = "Không có dữ liệu"; // Since it's not in TheThang
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Lỗi khi khôi phục thẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connectionOpenedHere && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void txtSoThe_TTT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnTim_TTT_Click(btnTim_TTT, new EventArgs());
            }
        }

        private void txtMaThe_TTT_KeyDown(object sender, KeyEventArgs e) 
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    e.SuppressKeyPress = true;
            //    btnTim_TTT_Click(btnTim_TTT, new EventArgs());
            //}
        }

        private void ExportActiveToExcel(DataTable dataTable)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            Excel.Range headerRange = null;
            Excel.Range dataRange = null;

            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.Sheets[1];

                int columnCount = dataTable.Columns.Count;
                int rowCount = dataTable.Rows.Count;

                object[] header = new object[columnCount];
                for (int col = 0; col < columnCount; col++)
                {
                    header[col] = dataTable.Columns[col].ColumnName;
                }
                headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, columnCount]];
                headerRange.Value = header;
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                Marshal.ReleaseComObject(headerRange);

                object[,] data = new object[rowCount, columnCount];
                for (int row = 0; row < rowCount; row++)
                {
                    for (int col = 0; col < columnCount; col++)
                    {
                        data[row, col] = dataTable.Rows[row][col]?.ToString() ?? "";
                    }
                }
                dataRange = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[rowCount + 1, columnCount]];
                dataRange.Value = data;
                Marshal.ReleaseComObject(dataRange);

                worksheet.Columns.AutoFit();

                string serverAddress = txtServer;
                string sharedFolderValue = Properties.Settings.Default.SharedFolder;

                int index = serverAddress.IndexOf(@"\SQLEXPRESS", StringComparison.OrdinalIgnoreCase);
                if (index != -1)
                {
                    serverAddress = serverAddress.Remove(index, @"\SQLEXPRESS".Length).Trim();
                }
                string networkPath = Path.Combine("\\" + serverAddress, sharedFolderValue);

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.InitialDirectory = networkPath;
                    sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";
                    sfd.Title = "Lưu file Excel danh sách Active";
                    sfd.FileName = $"XUAT-DANH-SACH-ACTIVE-{DateTime.Now:ddMMyyyy}.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Xuất dữ liệu Active ra Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        active_export_path = sfd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất dữ liệu Active ra Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (workbook != null) workbook.Saved = true;
            }
            finally
            {
                if (excelApp != null)
                {
                    excelApp.ScreenUpdating = true;
                    excelApp.DisplayAlerts = true;
                    excelApp.Calculation = Excel.XlCalculation.xlCalculationAutomatic;
                }

                if (headerRange != null) Marshal.ReleaseComObject(headerRange);
                if (dataRange != null) Marshal.ReleaseComObject(dataRange);
                if (worksheet != null)
                {
                    Marshal.ReleaseComObject(worksheet);
                    worksheet = null;
                }
                if (workbook != null)
                {
                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                    workbook = null;
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                    excelApp = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }

        private async void btnExport_TTT_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView3.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu 'Active' để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowLoading();
            try
            {
                string exportedFilePath = await RunSTATask(() => ExportDataGridViewToExcel(guna2DataGridView3, "DANH-SACH-TOAN-BO-THE"));

                if (!string.IsNullOrEmpty(exportedFilePath))
                {
                    active_export_path = exportedFilePath; // Store the path
                    MessageBox.Show("Xuất dữ liệu 'Active' ra Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HideLoading();
            }
        }

        private void btnOpen_TTT_Click(object sender, EventArgs e)
        {
            OpenExportedFileDirectory(active_export_path);
        }

        #endregion

        #region Doanh Thu (Revenue) Tab

        private void DoanhThu_Load()
        {
            progressBarExport.Visible = false;
            progressBarExport.Value = 0;

            SetInitialControlStates();

            // Set dateTimeStart to the first day of the current month
            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimeStart.Value = firstDayOfMonth;
            dateTimeEnd.Value = firstDayOfMonth; // Or DateTime.Now, depending on desired default end date

            // Set timeTimeStart and timeTimeEnd to 00:00:00
            timeTimeStart.Value = new DateTime(firstDayOfMonth.Year, firstDayOfMonth.Month, firstDayOfMonth.Day, 06, 0, 0);
            timeTimeEnd.Value = new DateTime(firstDayOfMonth.Year, firstDayOfMonth.Month, firstDayOfMonth.Day, 06, 0, 0);

            // Set custom format for time pickers
            timeTimeStart.Format = DateTimePickerFormat.Custom;
            timeTimeEnd.Format = DateTimePickerFormat.Custom;
            timeTimeStart.CustomFormat = "HH:mm:ss";
            timeTimeEnd.CustomFormat = "HH:mm:ss";
            timeTimeStart.ShowUpDown = true;
            timeTimeEnd.ShowUpDown = true;

            // Set custom format for date pickers to dd-MM-yyyy
            dateTimeStart.Format = DateTimePickerFormat.Custom;
            dateTimeStart.CustomFormat = "dd-MM-yyyy";
            dateTimeEnd.Format = DateTimePickerFormat.Custom;
            dateTimeEnd.CustomFormat = "dd-MM-yyyy";

            // Load LoaiThe data for all relevant combo boxes
            LoadLoaiTheData();
            LoadActiveDataGrid();

            // Set "All" as selected for cmbTypeDoanhThu (it's already added in LoadLoaiTheData at index 0)
            if (cmbTypeDoanhThu.Items.Count > 0)
            {
                cmbTypeDoanhThu.SelectedIndex = 0;
            }

            // Set "All" as selected for cbbXeRa (it's already added in LoadLoaiTheData at index 0)
            if (cbbXeRa.Items.Count > 0)
            {
                cbbXeRa.SelectedIndex = 0;
            }

            // Set "All" as selected for cbbXeVao (it's already added in LoadLoaiTheData at index 0)
            if (cbbXeVao.Items.Count > 0)
            {
                cbbXeVao.SelectedIndex = 0;
            }
            // Set "All" as selected for cbb_XR_KHAC (it's already added in LoadLoaiTheData at index 0)
            if (cbb_XR_KHAC.Items.Count > 0)
            {
                cbb_XR_KHAC.SelectedIndex = 0;
            }
            // Set "All" as selected for cbb_XV_KHAC (it's already added in LoadLoaiTheData at index 0)
            if (cbb_XV_KHAC.Items.Count > 0)
            {
                cbb_XV_KHAC.SelectedIndex = 0;
            }

            // Initialize Xe Ra tab controls
            dtXeRaTuDate.Value = firstDayOfMonth;
            dtXeRaDenDate.Value = firstDayOfMonth;
            dtXeRaTuTime.Value = new DateTime(firstDayOfMonth.Year, firstDayOfMonth.Month, firstDayOfMonth.Day, 0, 0, 0);
            dtXeRaDenTime.Value = new DateTime(firstDayOfMonth.Year, firstDayOfMonth.Month, firstDayOfMonth.Day, 0, 0, 0);

            dtXeRaTuTime.Format = DateTimePickerFormat.Custom;
            dtXeRaDenTime.Format = DateTimePickerFormat.Custom;
            dtXeRaTuTime.CustomFormat = "HH:mm:ss";
            dtXeRaDenTime.CustomFormat = "HH:mm:ss";
            dtXeRaTuTime.ShowUpDown = true;
            dtXeRaDenTime.ShowUpDown = true;

            dtXeRaTuDate.Format = DateTimePickerFormat.Custom;
            dtXeRaTuDate.CustomFormat = "dd-MM-yyyy";
            dtXeRaDenDate.Format = DateTimePickerFormat.Custom;
            dtXeRaDenDate.CustomFormat = "dd-MM-yyyy";

            // Initialize Xe Vao tab controls
            dtXeVaoTuDate.Value = firstDayOfMonth;
            dtXeVaoDenDate.Value = firstDayOfMonth;
            dtXeVaoTuTime.Value = new DateTime(firstDayOfMonth.Year, firstDayOfMonth.Month, firstDayOfMonth.Day, 0, 0, 0);
            dtXeVaoDenTime.Value = new DateTime(firstDayOfMonth.Year, firstDayOfMonth.Month, firstDayOfMonth.Day, 0, 0, 0);

            dtXeVaoTuTime.Format = DateTimePickerFormat.Custom;
            dtXeVaoDenTime.Format = DateTimePickerFormat.Custom;
            dtXeVaoTuTime.CustomFormat = "HH:mm:ss";
            dtXeVaoDenTime.CustomFormat = "HH:mm:ss";
            dtXeVaoTuTime.ShowUpDown = true;
            dtXeVaoDenTime.ShowUpDown = true;

            dtXeVaoTuDate.Format = DateTimePickerFormat.Custom;
            dtXeVaoTuDate.CustomFormat = "dd-MM-yyyy";
            dtXeVaoDenDate.Format = DateTimePickerFormat.Custom;
            dtXeVaoDenDate.CustomFormat = "dd-MM-yyyy";
        }

        private void SetInitialControlStates()
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            // The "All" option and SelectedIndex for cmbTypeDoanhThu, cbbXeRa, cbbXeVao are now handled in DoanhThu_Load()
            // after LoadLoaiTheData() has populated them.
        }

        private void LoadLoaiTheData()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "SELECT MaLoaiThe, LoaiThe FROM LoaiThe";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Bảng 'LoaiThe' không có dữ liệu. Vui lòng kiểm tra cơ sở dữ liệu.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Exit if no data
                        }

                        // Add "All" option to the DataTable
                        DataRow allRow = dataTable.NewRow();
                        allRow["MaLoaiThe"] = ALL_MATERIAL_TYPE;
                        allRow["LoaiThe"] = ALL_MATERIAL_TYPE;
                        dataTable.Rows.InsertAt(allRow, 0);

                        cbbLoai_TTr.DataSource = dataTable;
                        cbbLoai_TTr.DisplayMember = "MaLoaiThe"; // Display the 'MaLoaiThe' column
                        cbbLoai_TTr.ValueMember = "MaLoaiThe"; // Use 'MaLoaiThe' as the actual value

                        // Create a new DataTable for cbbLoaiThe_TT to avoid issues with shared DataSource
                        DataTable dataTableForCbbLoaiThe_TT = dataTable.Copy();
                        cbbLoaiThe_TT.DataSource = dataTableForCbbLoaiThe_TT;
                        cbbLoaiThe_TT.DisplayMember = "MaLoaiThe"; // Display the 'MaLoaiThe' column
                        cbbLoaiThe_TT.ValueMember = "MaLoaiThe"; // Use 'MaLoaiThe' as the actual value

                        // Create a new DataTable for cmbTypeDoanhThu
                        DataTable dataTableForCmbTypeDoanhThu = dataTable.Copy();
                        cmbTypeDoanhThu.DataSource = dataTableForCmbTypeDoanhThu;
                        cmbTypeDoanhThu.DisplayMember = "MaLoaiThe";
                        cmbTypeDoanhThu.ValueMember = "MaLoaiThe";

                        // Create a new DataTable for cbbXeVao
                        DataTable dataTableForCbbXeVao = dataTable.Copy();
                        cbbXeVao.DataSource = dataTableForCbbXeVao;
                        cbbXeVao.DisplayMember = "MaLoaiThe";
                        cbbXeVao.ValueMember = "MaLoaiThe";

                        // Create a new DataTable for cbbXeRa
                        DataTable dataTableForCbbXeRa = dataTable.Copy();
                        cbbXeRa.DataSource = dataTableForCbbXeRa;
                        cbbXeRa.DisplayMember = "MaLoaiThe";
                        cbbXeRa.ValueMember = "MaLoaiThe";

                        // Create a new DataTable for comboBox1 (cbb_XR_KHAC)
                        DataTable dataTableForCbb_XR_KHAC = dataTable.Copy();
                        cbb_XR_KHAC.DataSource = dataTableForCbb_XR_KHAC;
                        cbb_XR_KHAC.DisplayMember = "MaLoaiThe";
                        cbb_XR_KHAC.ValueMember = "MaLoaiThe";

                        DataTable dataTableForCbb_XV_KHAC = dataTable.Copy();
                        cbb_XV_KHAC.DataSource = dataTableForCbb_XV_KHAC;
                        cbb_XV_KHAC.DisplayMember = "MaLoaiThe";
                        cbb_XV_KHAC.ValueMember = "MaLoaiThe";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu loại thẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async void btnRevenue_Click(object sender, EventArgs e)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            ShowLoading();
            try
            {
                DateTime startDateFromPicker = dateTimeStart.Value;
                DateTime endDateFromPicker = dateTimeEnd.Value;
                DateTime startTimeFromPicker = timeTimeStart.Value;
                DateTime endTimeFromPicker = timeTimeEnd.Value;

                DateTime fullStartDateTime = new DateTime(
                    startDateFromPicker.Year,
                    startDateFromPicker.Month,
                    startDateFromPicker.Day,
                    startTimeFromPicker.Hour,
                    startTimeFromPicker.Minute,
                    startTimeFromPicker.Second);

                DateTime fullEndDateTime = new DateTime(
                    endDateFromPicker.Year,
                    endDateFromPicker.Month,
                    endDateFromPicker.Day,
                    endTimeFromPicker.Hour,
                    endTimeFromPicker.Minute,
                    endTimeFromPicker.Second);

                string selectedMaterialType = cmbTypeDoanhThu.Text.Trim();

                string query = @"
SELECT
    Ra.STTThe AS 'Số thẻ',
    Ra.CardID AS 'Mã thẻ',
    Vao.NgayVao AS 'Ngày vào',
    CONVERT(varchar, DATEADD(second, Vao.ThoiGian, 0), 108) AS 'Thời gian vào',
    Ra.NgayRa AS 'Ngày ra',
    CONVERT(varchar, DATEADD(second, Ra.THoiGianRa, 0), 108) AS 'Thời gian ra',
    Ra.MaLoaiThe AS 'Loại thẻ',
    Ra.GiaTien AS 'Tiền thu',
    Ra.IDXe AS 'IDXe',
    Ra.IDMat AS 'Mã mặt',
    Ra.soxe AS 'Biển số vào',
    Ra.soxera AS 'Biển số ra'
FROM
[dbo].[Ra]
INNER JOIN [dbo].[Vao] ON Ra.IDXe = Vao.IDXe
                WHERE 1=1 AND GiaTien > 0";

                query += @" AND (
                    CAST(NgayRa AS DATETIME) +
                    CAST(
                        RIGHT('0' + CAST(GioRa / 1000000 AS VARCHAR(2)), 2) + ':' +
                        RIGHT('0' + CAST((GioRa / 10000) % 100 AS VARCHAR(2)), 2) + ':' +
                        RIGHT('0' + CAST((GioRa / 100) % 100 AS VARCHAR(2)), 2) + '.' +
                        RIGHT('0' + CAST(GioRa % 100 AS VARCHAR(2)), 2)
                    AS DATETIME)
                ) BETWEEN @fullStartDateTime AND @fullEndDateTime";

                if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
                {
                    query += " AND Ra.MaLoaiThe = @MaterialType";
                }

                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandTimeout = 120; // 2 minutes timeout
                        command.Parameters.AddWithValue("@fullStartDateTime", fullStartDateTime);
                        command.Parameters.AddWithValue("@fullEndDateTime", fullEndDateTime);

                        if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
                        {
                            command.Parameters.AddWithValue("@MaterialType", selectedMaterialType);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dgvResults.SuspendLayout();
                            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                            dgvResults.DataSource = dataTable;
                            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvResults.ResumeLayout();

                            int rowCount = dataTable.Rows.Count;
                            txtCount.Text = rowCount.ToString("N0");

                            if (dataTable.Rows.Count > 0)
                            {
                                btnUpdate.Enabled = true;
                                btnDelete.Enabled = true;
                            }
                            else
                            {
                                btnUpdate.Enabled = false;
                                btnDelete.Enabled = false;
                            }

                            decimal totalGiaTien = 0;

                            if (dataTable.Columns.Contains("Tiền thu"))
                            {
                                foreach (DataRow row in dataTable.Rows)
                                {
                                    if (row["Tiền thu"] != DBNull.Value && decimal.TryParse(row["Tiền thu"].ToString(), out decimal giaTien))
                                    {
                                        totalGiaTien += giaTien;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Column 'Tiền thu' not found in query results. Cannot calculate sum.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            txtSum.Text = totalGiaTien.ToString("N0") + " VNĐ";
                            txtCount.Text = dataTable.Rows.Count.ToString("N0");
                            btnExportRevenue.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Query error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                HideLoading();
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (PasswordPromptForm passwordForm = new PasswordPromptForm())
            {
                DialogResult result = passwordForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string enteredPassword = passwordForm.EnteredPassword;

                    if (enteredPassword == DynamicPassword)
                    {
                        EvenDelete();
                    }
                    else
                    {
                        MessageBox.Show("Sai mật khẩu. Vui lòng thử lại", "Xác thực không thành công!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Cancel.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async void EvenDelete()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Chưa kết nối với cơ sở dữ liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvResults.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dòng để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedCount = dgvResults.SelectedRows.Count;
            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa {selectedCount} dòng dữ liệu đã chọn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgvResults.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    rowsToDelete.Add(row);
                }
            }

            if (rowsToDelete.Count == 0)
            {
                MessageBox.Show("Không có dòng hợp lệ nào được chọn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int batchSize = 1000; // Optimized batch size for inserting into temp table
            int totalRowsAffected = 0; // To store the count from the final DELETE statement
            SqlTransaction transaction = null;
            bool connectionOpenedHere = false;

            try
            {
                ShowLoading();
                InitializeDatabaseConnection();

                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                    connectionOpenedHere = true;
                }

                // Start a single transaction for the entire operation
                transaction = connection.BeginTransaction();

                // 1. Create Temporary Table
                string createTempTableQuery = @"
                    IF OBJECT_ID('tempdb..#TempDeleteIDs') IS NOT NULL DROP TABLE #TempDeleteIDs;
                    CREATE TABLE #TempDeleteIDs (
                        CardID NVARCHAR(50) NOT NULL,
                        IDXe NVARCHAR(50) NOT NULL,
                        IDMat NVARCHAR(50) NOT NULL
                    );";
                using (SqlCommand createTempCmd = new SqlCommand(createTempTableQuery, connection, transaction))
                {
                    await createTempCmd.ExecuteNonQueryAsync();
                }

                // 2. Insert IDs into Temporary Table in batches
                for (int i = 0; i < rowsToDelete.Count; i += batchSize)
                {
                    var batch = rowsToDelete.Skip(i).Take(batchSize).ToList();
                    if (!batch.Any()) continue;

                    StringBuilder insertValues = new StringBuilder();
                    List<SqlParameter> insertParameters = new List<SqlParameter>();
                    int paramIndex = 0;

                    foreach (var row in batch)
                    {
                        string cardId = row.Cells["Mã thẻ"].Value?.ToString();
                        string idXe = row.Cells["IDXe"].Value?.ToString();
                        string idMat = row.Cells["IDMat"].Value?.ToString();

                        if (string.IsNullOrEmpty(cardId) || string.IsNullOrEmpty(idXe) || string.IsNullOrEmpty(idMat))
                        {
                            continue;
                        }

                        string cardIdParam = "@cardId" + paramIndex;
                        string idXeParam = "@idXe" + paramIndex;
                        string idMatParam = "@idMat" + paramIndex;

                        if (insertValues.Length > 0)
                        {
                            insertValues.Append(", ");
                        }
                        insertValues.Append($"({cardIdParam}, {idXeParam}, {idMatParam})");

                        insertParameters.Add(new SqlParameter(cardIdParam, cardId));
                        insertParameters.Add(new SqlParameter(idXeParam, idXe));
                        insertParameters.Add(new SqlParameter(idMatParam, idMat));

                        paramIndex++;
                    }

                    if (insertValues.Length == 0) continue;

                    string insertTempTableQuery = $"INSERT INTO #TempDeleteIDs (CardID, IDXe, IDMat) VALUES {insertValues.ToString()}";
                    using (SqlCommand insertTempCmd = new SqlCommand(insertTempTableQuery, connection, transaction))
                    {
                        insertTempCmd.Parameters.AddRange(insertParameters.ToArray());
                        await insertTempCmd.ExecuteNonQueryAsync();
                    }
                }

                // 3. Perform the actual DELETE using JOIN with the temporary table
                string deleteQuery = @"
                    DELETE R
                    FROM [dbo].[Ra] R
                    INNER JOIN #TempDeleteIDs T ON R.CardID = T.CardID AND R.IDXe = T.IDXe AND R.IDMat = T.IDMat;";
                using (SqlCommand finalDeleteCmd = new SqlCommand(deleteQuery, connection, transaction))
                {
                    totalRowsAffected = await finalDeleteCmd.ExecuteNonQueryAsync();
                }

                // 4. Drop the temporary table (optional, but good practice)
                string dropTempTableQuery = "DROP TABLE #TempDeleteIDs;";
                using (SqlCommand dropTempCmd = new SqlCommand(dropTempTableQuery, connection, transaction))
                {
                    await dropTempCmd.ExecuteNonQueryAsync();
                }

                transaction.Commit();

                MessageBox.Show($"Đã xóa thành công {totalRowsAffected} dòng dữ liệu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRevenue_Click(this, EventArgs.Empty); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Lỗi khi xóa dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HideLoading();
                if (connectionOpenedHere && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async void btnQuery_Click(object sender, EventArgs e)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            ShowLoading();
            try
            {
                // Giữ nguyên việc lấy giá trị từ Date/Time Pickers
                DateTime startDateFromPicker = dateTimeStart.Value;
                DateTime endDateFromPicker = dateTimeEnd.Value;
                DateTime startTimeFromPicker = timeTimeStart.Value;
                DateTime endTimeFromPicker = timeTimeEnd.Value;

                DateTime fullStartDateTime = new DateTime(
                    startDateFromPicker.Year,
                    startDateFromPicker.Month,
                    startDateFromPicker.Day,
                    startTimeFromPicker.Hour,
                    startTimeFromPicker.Minute,
                    startTimeFromPicker.Second);

                DateTime fullEndDateTime = new DateTime(
                    endDateFromPicker.Year,
                    endDateFromPicker.Month,
                    endDateFromPicker.Day,
                    endTimeFromPicker.Hour,
                    endTimeFromPicker.Minute,
                    endTimeFromPicker.Second);

                string selectedMaterialType = cmbTypeDoanhThu.Text.Trim();

                // *** PHẦN SỬA ĐỔI QUAN TRỌNG: Câu truy vấn SQL để tương thích mọi phiên bản ***
                string query = @"
SELECT
    Ra.STTThe AS 'Số thẻ',
    Ra.CardID AS 'Mã thẻ',
    Vao.NgayVao AS 'Ngày vào',
    CONVERT(varchar, DATEADD(second, Vao.ThoiGian, 0), 108) AS 'Thời gian vào',
    Ra.NgayRa AS 'Ngày ra',
    CONVERT(varchar, DATEADD(second, Ra.THoiGianRa, 0), 108) AS 'Thời gian ra',
    Ra.MaLoaiThe AS 'Loại thẻ',
    Ra.GiaTien AS 'Tiền thu',
    Ra.IDXe,
    Ra.IDMat,
    Ra.soxe AS 'Biển số vào',
    Ra.soxera AS 'Biển số ra'
FROM
[dbo].[Ra]
INNER JOIN [dbo].[Vao] ON Ra.IDXe = Vao.IDXe
                WHERE 1=1 ";

                query += @" AND (
                    CAST(NgayRa AS DATETIME) +
                    CAST(
                        RIGHT('0' + CAST(GioRa / 1000000 AS VARCHAR(2)), 2) + ':' +
                        RIGHT('0' + CAST((GioRa / 10000) % 100 AS VARCHAR(2)), 2) + ':' +
                        RIGHT('0' + CAST((GioRa / 100) % 100 AS VARCHAR(2)), 2) + '.' +
                        RIGHT('0' + CAST(GioRa % 100 AS VARCHAR(2)), 2)
                    AS DATETIME)
                ) BETWEEN @fullStartDateTime AND @fullEndDateTime";

                // Giữ nguyên logic thêm điều kiện lọc theo loại vật liệu
                if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
                {
                    query += " AND Ra.MaLoaiThe = @MaterialType";
                }

                // Giữ nguyên ORDER BY
                query += " ORDER BY NgayRa ASC, GioRa ASC;";

                // Giữ nguyên khối try-catch-finally và logic đổ dữ liệu vào dgvResults
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandTimeout = 120; // 2 minutes timeout
                        command.Parameters.AddWithValue("@fullStartDateTime", fullStartDateTime);
                        command.Parameters.AddWithValue("@fullEndDateTime", fullEndDateTime);

                        if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
                        {
                            command.Parameters.AddWithValue("@MaterialType", selectedMaterialType);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dgvResults.SuspendLayout();
                            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                            dgvResults.DataSource = dataTable;
                            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvResults.ResumeLayout();

                            if (dataTable.Rows.Count > 0)
                            {
                                btnUpdate.Enabled = true;
                                btnDelete.Enabled = true;
                            }
                            else
                            {
                                btnUpdate.Enabled = false;
                                btnDelete.Enabled = false;
                            }

                            decimal totalGiaTien = 0;

                            if (dataTable.Columns.Contains("Tiền thu"))
                            {
                                foreach (DataRow row in dataTable.Rows)
                                {
                                    if (row["Tiền thu"] != DBNull.Value && decimal.TryParse(row["Tiền thu"].ToString(), out decimal giaTien))
                                    {
                                        totalGiaTien += giaTien;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Column 'Tiền thu' not found in query results. Cannot calculate sum.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            txtSum.Text = totalGiaTien.ToString("N0") + " VNĐ";
                            txtCount.Text = dataTable.Rows.Count.ToString("N0");
                            btnExportRevenue.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Query error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                HideLoading();
            }
        }

        private async Task<DataTable> ExecuteRevenueQuery(DateTime fullStartDateTime, DateTime fullEndDateTime, string selectedMaterialType = ALL_MATERIAL_TYPE)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                string query = @"
SELECT
    Ra.STTThe AS 'Số thẻ',
    Ra.CardID AS 'Mã thẻ',
    Vao.NgayVao AS 'Ngày vào',
    CONVERT(varchar, DATEADD(second, Vao.ThoiGian, 0), 108) AS 'Thời gian vào',
    Ra.NgayRa AS 'Ngày ra',
    CONVERT(varchar, DATEADD(second, Ra.THoiGianRa, 0), 108) AS 'Thời gian ra',
    Ra.MaLoaiThe AS 'Loại thẻ',
    Ra.GiaTien AS 'Tiền thu',
    Ra.IDXe,
    Ra.IDMat,
    Ra.soxe AS 'Biển số vào',
    Ra.soxera AS 'Biển số ra'
FROM
[dbo].[Ra]
INNER JOIN [dbo].[Vao] ON Ra.IDXe = Vao.IDXe
                WHERE 1=1 AND GiaTien > 0";

                query += @" AND (
                CAST(NgayRa AS DATETIME) +
                CAST(
                    RIGHT('0' + CAST(GioRa / 1000000 AS VARCHAR(2)), 2) + ':' +
                    RIGHT('0' + CAST((GioRa / 10000) % 100 AS VARCHAR(2)), 2) + ':' +
                    RIGHT('0' + CAST((GioRa / 100) % 100 AS VARCHAR(2)), 2) + '.' +
                    RIGHT('0' + CAST(GioRa % 100 AS VARCHAR(2)), 2)
                AS DATETIME)
            ) BETWEEN @fullStartDateTime AND @fullEndDateTime";

                if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != ALL_MATERIAL_TYPE)
                {
                    query += " AND Ra.MaLoaiThe = @MaterialType";
                }

                query += " ORDER BY NgayRa ASC, GioRa ASC;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandTimeout = 120; // 2 minutes timeout
                    command.Parameters.AddWithValue("@fullStartDateTime", fullStartDateTime);
                    command.Parameters.AddWithValue("@fullEndDateTime", fullEndDateTime);

                    if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != ALL_MATERIAL_TYPE)
                    {
                        command.Parameters.AddWithValue("@MaterialType", selectedMaterialType);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi truy vấn dữ liệu doanh thu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async void btnUpdate_Click(object sender, EventArgs e)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            if (connection == null)
            {
                MessageBox.Show("Chưa khởi tạo kết nối. Vui lòng kết nối trước.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Vui lòng chọn đúng một dòng để cập nhật.", "Lỗi chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvResults.SelectedRows[0];
            if (row.IsNewRow) return;

            string cardId = row.Cells["Mã thẻ"].Value?.ToString();
            string idXe = row.Cells["IDXe"].Value?.ToString();
            string idMat = row.Cells["Mã mặt"].Value?.ToString();

            if (string.IsNullOrEmpty(cardId) || string.IsNullOrEmpty(idXe) || string.IsNullOrEmpty(idMat))
            {
                MessageBox.Show("Không thể xác định dòng cần cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool openedHere = false;
            try
            {
                // Mở connection nếu cần (nhớ đóng lại nếu do hàm này mở)
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    openedHere = true;
                }

                using (SqlTransaction trans = connection.BeginTransaction())
                {
                    // 2) Chuẩn bị update (lấy các cột cần update từ dgv)
                    Dictionary<string, string> columnMapping = new Dictionary<string, string>
                        {
                            { "Số thẻ", "STTThe" },
                            { "Loại thẻ", "MaLoaiThe" },
                            { "Tiền thu", "GiaTien" },
                            { "Biển số vào", "soxe" },
                            { "Biển số ra", "soxera" }
                        };

                    List<string> updateFields = new List<string>();
                    using (SqlCommand updateCmd = new SqlCommand())
                    {
                        updateCmd.Connection = connection;
                        updateCmd.Transaction = trans;

                        foreach (DataGridViewColumn column in dgvResults.Columns)
                        {
                            string columnName = column.Name;

                            // Skip primary key columns and read-only columns
                            if (columnName == "Mã thẻ" || columnName == "IDXe" || columnName == "IDMat" || columnName == "Ngày ra" || columnName == "Thời gian ra" || columnName == "Ngày vào" || columnName == "Thời gian vào")
                                continue;

                            if (!columnMapping.TryGetValue(columnName, out string dbColumnName))
                                continue;

                            object value = row.Cells[columnName].Value ?? DBNull.Value;
                            string paramName = $"@param_{dbColumnName}";
                            updateFields.Add($"[{dbColumnName}] = {paramName}");

                            // Nếu bạn muốn chắc chắn kiểu tham số chính xác, bạn có thể dùng Add và chỉ định SqlDbType ở đây
                            updateCmd.Parameters.AddWithValue(paramName, value);
                        }

                        if (updateFields.Count == 0)
                        {
                            MessageBox.Show("Không có dữ liệu nào để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            trans.Rollback();
                            return;
                        }

                        string updateQuery = $"\n                            UPDATE [dbo].[Ra]\n                            SET {string.Join(", ", updateFields)}\n                            WHERE CardID = @cardId AND IDXe = @idXe AND IDMat = @idMat;";

                        updateCmd.CommandText = updateQuery;
                        updateCmd.Parameters.AddWithValue("@cardId", cardId);
                        updateCmd.Parameters.AddWithValue("@idXe", idXe);
                        updateCmd.Parameters.AddWithValue("@idMat", idMat);

                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            trans.Commit();
                            MessageBox.Show("Cập nhật thành công.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            trans.Rollback();
                            MessageBox.Show("Không có dòng nào được cập nhật.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
                        
            catch (Exception ex)
            {
                try { connection?.Close(); } catch { }
                MessageBox.Show($"Lỗi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (openedHere && connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        private string ExportDataTableToExcel(DataTable dataTable, String filename, DateTime fullStartDateTime, DateTime fullEndDateTime)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            Excel.Range headerRange = null; 
            Excel.Range dataRange = null;   

            try
            {
                excelApp = new Excel.Application();

                workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.Sheets[1];

                int columnCount = dataTable.Columns.Count;
                int rowCount = dataTable.Rows.Count;

                object[] header = new object[columnCount];
                for (int col = 0; col < columnCount; col++)
                {
                    header[col] = dataTable.Columns[col].ColumnName;
                }
                headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, columnCount]];
                headerRange.Value = header;
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                Marshal.ReleaseComObject(headerRange); 

                object[,] data = new object[rowCount, columnCount];
                for (int row = 0; row < rowCount; row++)
                {
                    for (int col = 0; col < columnCount; col++)
                    {
                        data[row, col] = dataTable.Rows[row][col]?.ToString() ?? "";
                    }
                }
                dataRange = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[rowCount + 1, columnCount]];
                dataRange.Value = data;
                Marshal.ReleaseComObject(dataRange); 

                worksheet.Columns.AutoFit();

                string serverAddress = txtServer;
                string sharedFolderValue = Properties.Settings.Default.SharedFolder;

                int index = serverAddress.IndexOf(@"\SQLEXPRESS", StringComparison.OrdinalIgnoreCase);
                if (index != -1)
                {
                    serverAddress = serverAddress.Remove(index, @"\SQLEXPRESS".Length).Trim();
                }
                string networkPath = Path.Combine("\\" + serverAddress, sharedFolderValue);

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.InitialDirectory = networkPath;

                    sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";
                    sfd.Title = "Lưu file Excel";
                    if (filename == "DANH-SACH-THE-THANG")
                    {
                        sfd.FileName = "XUAT-DU-LIEU-" + filename + "-DEN-NGAY" + DateTime.Now.ToString("-dd-MM-yyyy") + ".xlsx";
                    }
                    else if (filename == "DOANH-THU-VANG-LAI")
                    {
                        string startDate = fullStartDateTime.ToString("ddMMyyyy");
                        string startTime = fullStartDateTime.ToString("HHmmss");
                        string endDate = fullEndDateTime.ToString("ddMMyyyy");
                        string endTime = fullEndDateTime.ToString("HHmmss");
                        sfd.FileName = $"XUAT-DU-LIEU-DOANH-THU-TU-{startDate}-{startTime}-DEN-{endDate}-{endTime}.xlsx";
                    }
                    else if (filename == "DOANH-THU-THANG")
                    {
                        sfd.FileName = $"XUAT-DU-LIEU-DOANH-THU-THANG-{fullStartDateTime:MMyyyy}.xlsx";
                    }
                    else if (filename == "DOANH-THU-NAM")
                    {
                        sfd.FileName = $"XUAT-DU-LIEU-DOANH-THU-NAM-{fullStartDateTime:yyyy}.xlsx";
                    }
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(sfd.FileName);
                        return sfd.FileName;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            finally
            {
                if (workbook != null)
                {
                    workbook.Close(false);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                }

                if (headerRange != null) Marshal.ReleaseComObject(headerRange);
                if (dataRange != null) Marshal.ReleaseComObject(dataRange);
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private async void btnExportRevenue_Click(object sender, EventArgs e)
        {
            if (dgvResults.DataSource == null || !(dgvResults.DataSource is DataTable) || ((DataTable)dgvResults.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất ra Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowLoading();
            try
            {
                DataTable dataTable = (DataTable)dgvResults.DataSource;

                DateTime startDateFromPicker = dateTimeStart.Value;
                DateTime endDateFromPicker = dateTimeEnd.Value;
                DateTime startTimeFromPicker = timeTimeStart.Value;
                DateTime endTimeFromPicker = timeTimeEnd.Value;

                DateTime fullStartDateTime = new DateTime(
                    startDateFromPicker.Year,
                    startDateFromPicker.Month,
                    startDateFromPicker.Day,
                    startTimeFromPicker.Hour,
                    startTimeFromPicker.Minute,
                    startTimeFromPicker.Second);

                DateTime fullEndDateTime = new DateTime(
                    endDateFromPicker.Year,
                    endDateFromPicker.Month,
                    endDateFromPicker.Day,
                    endTimeFromPicker.Hour,
                    endTimeFromPicker.Minute,
                    endTimeFromPicker.Second);

                string reportType = "DOANH-THU-VANG-LAI"; // Default
                if (dgvResults.Columns.Contains("Ngày") && dgvResults.Columns.Contains("Tổng tiền"))
                {
                    reportType = "DOANH-THU-THANG";
                }
                else if (dgvResults.Columns.Contains("Tháng") && dgvResults.Columns.Contains("Tổng tiền"))
                {
                    reportType = "DOANH-THU-NAM";
                }

                string exportedFilePath = await RunSTATask<string>(() => ExportDataTableToExcel(dataTable, reportType, fullStartDateTime, fullEndDateTime));

                HideLoading();

                if (!string.IsNullOrEmpty(exportedFilePath))
                {
                    dt_export_path = Path.GetDirectoryName(exportedFilePath);
                    MessageBox.Show(this, "Xuất dữ liệu ra Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                HideLoading();
                MessageBox.Show(this, $"Lỗi khi xuất dữ liệu hoặc truy vấn: {ex.InnerException?.Message ?? ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMo_DT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dt_export_path))
            {
                if (Directory.Exists(dt_export_path))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(dt_export_path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể mở thư mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Thư mục không tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chưa có đường dẫn thư mục nào được lưu. Vui lòng xuất file Excel trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Xe Vào (Incoming Vehicles) Tab

        private void txtSoTheXeVao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLocXeVao.PerformClick();
                ((Control)sender).Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBienSoXeVao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLocXeVao.PerformClick();
                ((Control)sender).Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void dgvXeVao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    if (dgvXeVao.CurrentRow != null)
                    {
                        LoadImagesFromXeVaoRow(dgvXeVao.CurrentRow);
                    }
                }));
            }
        }

        private async void btnXoaXeVao_Click(object sender, EventArgs e)
        {
            if (dgvXeVao.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một xe vào để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Assuming only one row can be selected for deletion
            DataGridViewRow selectedRow = dgvXeVao.SelectedRows[0];

            string idXe = selectedRow.Cells["IDXe"].Value?.ToString();
            string cardID = selectedRow.Cells["Mã thẻ"].Value?.ToString(); // 'Mã thẻ' is the alias for Vao.CardID

            if (string.IsNullOrEmpty(idXe) || string.IsNullOrEmpty(cardID))
            {
                MessageBox.Show("Không thể xác định thông tin xe vào để xóa. Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa xe vào có IDXe: {idXe} và Mã thẻ: {cardID} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
            {
                return;
            }

            SqlTransaction transaction = null;
            bool connectionOpenedHere = false;

            try
            {
                ShowLoading(); // Show loading indicator
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    connectionOpenedHere = true;
                }

                transaction = connection.BeginTransaction();

                string deleteQuery = "DELETE FROM [dbo].[Vao] WHERE IDXe = @idXe AND CardID = @cardID";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection, transaction))
                {
                    command.Parameters.AddWithValue("@idXe", idXe);
                    command.Parameters.AddWithValue("@cardID", cardID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        transaction.Commit();
                        MessageBox.Show("Xóa xe vào thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadXeVaoData(); // Refresh the DataGridView
                    }
                    else
                    {
                        transaction.Rollback();
                        MessageBox.Show("Không tìm thấy xe vào để xóa hoặc không có thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Lỗi khi xóa xe vào: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HideLoading(); // Hide loading indicator
                if (connectionOpenedHere && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private async void btnLocXeVao_Click(object sender, EventArgs e)
        {
            ShowLoading();
            try
            {
                await LoadXeVaoData();
            }
            finally
            {
                HideLoading();
            }
        }

        private async Task LoadXeVaoData()
        {
            // InitializeDatabaseConnection(); // Ensure connection is open

            DateTime startDateFromPicker = dtXeVaoTuDate.Value;
            DateTime endDateFromPicker = dtXeVaoDenDate.Value;
            DateTime startTimeFromPicker = dtXeVaoTuTime.Value;
            DateTime endTimeFromPicker = dtXeVaoDenTime.Value;

            DateTime fullStartDateTime = new DateTime(
                startDateFromPicker.Year,
                startDateFromPicker.Month,
                startDateFromPicker.Day,
                startTimeFromPicker.Hour,
                startTimeFromPicker.Minute,
                startTimeFromPicker.Second);

            DateTime fullEndDateTime = new DateTime(
                endDateFromPicker.Year,
                endDateFromPicker.Month,
                endDateFromPicker.Day,
                endTimeFromPicker.Hour,
                endTimeFromPicker.Minute,
                endTimeFromPicker.Second);

            string selectedMaterialType = cbbXeVao.Text.Trim();
            string soTheXeVao = txtSoTheXeVao.Text.Trim();
            string bienSoXeVao = txtBienSoXeVao.Text.Trim();

            string query = @"
        SELECT
            Vao.STTThe AS 'Số thẻ',
            Vao.CardID AS 'Mã thẻ',
            Vao.NgayVao AS 'Ngày vào',
            CONVERT(varchar, DATEADD(second, Vao.ThoiGian, 0), 108) AS 'Thời gian vào',
            Vao.MaLoaiThe AS 'Loại thẻ',
            Vao.IDXe,
            Vao.IDMat,
            Vao.soxe AS 'Biển số vào'
        FROM [dbo].[Vao] AS Vao
        LEFT JOIN [dbo].[Ra] AS Ra ON Vao.IDXe = Ra.IDXe
        WHERE Ra.IDXe IS NULL";

            // Add date/time filter
            query += @" AND (
                CAST(Vao.NgayVao AS DATETIME) +
                CAST(CONVERT(varchar, DATEADD(second, Vao.ThoiGian, 0), 108) AS DATETIME)
            ) BETWEEN @fullStartDateTime AND @fullEndDateTime";

            // Add card number filter
            if (!string.IsNullOrEmpty(soTheXeVao))
            {
                query += " AND Vao.STTThe LIKE @soTheXeVao";
            }

            // Add license plate filter
            if (!string.IsNullOrEmpty(bienSoXeVao))
            {
                query += " AND Vao.soxe LIKE @bienSoXeVao";
            }

            // Add material type filter
            if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
            {
                query += " AND Vao.MaLoaiThe = @MaterialType";
            }

            query += " ORDER BY Vao.NgayVao DESC, Vao.ThoiGian DESC;";

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandTimeout = 120; // 2 minutes timeout
                    command.Parameters.AddWithValue("@fullStartDateTime", fullStartDateTime);
                    command.Parameters.AddWithValue("@fullEndDateTime", fullEndDateTime);

                    if (!string.IsNullOrEmpty(soTheXeVao))
                    {
                        command.Parameters.AddWithValue("@soTheXeVao", "%" + soTheXeVao + "%");
                    }
                    if (!string.IsNullOrEmpty(bienSoXeVao))
                    {
                        command.Parameters.AddWithValue("@bienSoXeVao", "%" + bienSoXeVao + "%");
                    }
                    if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
                    {
                        command.Parameters.AddWithValue("@MaterialType", selectedMaterialType);
                    }

                    DataTable dataTable = new DataTable();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        dataTable.Load(reader);
                    }

                    dgvXeVao.SuspendLayout();
                    dgvXeVao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    dgvXeVao.DataSource = dataTable;
                    dgvXeVao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvXeVao.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi truy vấn dữ liệu xe vào: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvXeVao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadImagesFromXeVaoRow(dgvXeVao.Rows[e.RowIndex]);
            }
        }

        private void LoadImagesFromXeVaoRow(DataGridViewRow row)
        {
            // Clear exit images and info
            ptHinhMatRa.Image = GetBlackImage(ptHinhMatRa.Width, ptHinhMatRa.Height);
            ptHinhXeRa.Image = GetBlackImage(ptHinhXeRa.Width, ptHinhXeRa.Height);
            txtInfoRa.Text = "Thông tin ra: ";

            string idXe = "";
            DateTime ngayVao;
            // Update Info TextBoxes
            try
            {
                // --- Info Vào ---
                idXe = row.Cells["IDXe"].Value?.ToString();
                if (!string.IsNullOrEmpty(idXe) && idXe.Length >= 8 &&
                    DateTime.TryParseExact(idXe.Substring(0, 8), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out ngayVao) &&
                    TimeSpan.TryParse(row.Cells["Thời gian vào"].Value?.ToString(), out TimeSpan timeVao))
                {
                    txtInfoVaoVao.Text = $"Thông tin vào: Ngày {ngayVao.Day} tháng {ngayVao.Month} năm {ngayVao.Year} Thời gian: {timeVao.Hours} giờ {timeVao.Minutes} phút {timeVao.Seconds} giây";
                }
                else
                {
                    txtInfoVaoVao.Text = "Thông tin vào: Không có dữ liệu";
                }
            }
            catch (Exception)
            {
                txtInfoVaoVao.Text = "Thông tin vào: Lỗi định dạng dữ liệu";
            }

            if (row == null || row.Cells["IDMat"] == null || row.Cells["IDXe"] == null ||
                row.Cells["Mã thẻ"] == null || row.Cells["Ngày vào"] == null || row.Cells["Thời gian vào"] == null)
            {
                // Clear picture boxes if data is incomplete or row is null
                ptHinhMatVaoVao.Image = GetBlackImage(ptHinhMatVaoVao.Width, ptHinhMatVaoVao.Height);
                ptHinhXeVaoVao.Image = GetBlackImage(ptHinhXeVaoVao.Width, ptHinhXeVaoVao.Height);
                toolTip1.SetToolTip(ptHinhMatVaoVao, "Dữ liệu hàng không đầy đủ.");
                toolTip1.SetToolTip(ptHinhXeVaoVao, "Dữ liệu hàng không đầy đủ.");
                return;
            }

            string idMat = row.Cells["IDMat"].Value?.ToString();
            idXe = row.Cells["IDXe"].Value?.ToString();
            string cardId = row.Cells["Mã thẻ"].Value?.ToString(); // Lấy CardID

            // Attempt to parse NgayVao
            if (!DateTime.TryParse(row.Cells["Ngày vào"].Value?.ToString(), out ngayVao))
            {
                ptHinhMatVaoVao.Image = GetBlackImage(ptHinhMatVaoVao.Width, ptHinhMatVaoVao.Height);
                ptHinhXeVaoVao.Image = GetBlackImage(ptHinhXeVaoVao.Width, ptHinhXeVaoVao.Height);
                toolTip1.SetToolTip(ptHinhMatVaoVao, "Không thể phân tích ngày vào.");
                toolTip1.SetToolTip(ptHinhXeVaoVao, "Không thể phân tích ngày vào.");
                return;
            }

            string gioVaoString = row.Cells["Thời gian vào"].Value?.ToString();

            if (string.IsNullOrEmpty(gioVaoString))
            {
                ptHinhMatVaoVao.Image = GetBlackImage(ptHinhMatVaoVao.Width, ptHinhMatVaoVao.Height);
                ptHinhXeVaoVao.Image = GetBlackImage(ptHinhXeVaoVao.Width, ptHinhXeVaoVao.Height);
                toolTip1.SetToolTip(ptHinhMatVaoVao, "Không thể phân tích giờ vào.");
                toolTip1.SetToolTip(ptHinhXeVaoVao, "Không thể phân tích giờ vào.");
                return;
            }

            string folderPath = Properties.Settings.Default.SharedFolder;
            if (!string.IsNullOrEmpty(folderPath) && folderPath.StartsWith(@"\") && !folderPath.StartsWith(@"\\"))
            {
                folderPath = @"\\" + folderPath;
            }

            string yearMonthDay = ngayVao.ToString("yyyyMMdd");
            string fileNameMat = idMat + cardId;
            string fileNameXe = idXe + cardId;

            string imageMatVaoPath = Path.Combine(folderPath, "in", "mat", yearMonthDay, fileNameMat + ".jpg");
            string imageXeVaoPath = Path.Combine(folderPath, "in", "xe", yearMonthDay, fileNameXe + ".jpg");

            if (string.IsNullOrWhiteSpace(folderPath))
            {
                ptHinhMatVaoVao.Image = GetBlackImage(ptHinhMatVaoVao.Width, ptHinhMatVaoVao.Height);
                ptHinhXeVaoVao.Image = GetBlackImage(ptHinhXeVaoVao.Width, ptHinhXeVaoVao.Height);
                toolTip1.SetToolTip(ptHinhMatVaoVao, "Đường dẫn thư mục hình ảnh không được để trống.");
                toolTip1.SetToolTip(ptHinhXeVaoVao, "Đường dẫn thư mục hình ảnh không được để trống.");
                return;
            }

            LoadImageIntoPictureBox(ptHinhMatVaoVao, imageMatVaoPath);
            LoadImageIntoPictureBox(ptHinhXeVaoVao, imageXeVaoPath);
        }

        #endregion

        #region Xe Ra (Outgoing Vehicles) Tab

        private void txtSoTheXeRa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLocXeRa.PerformClick();
                ((Control)sender).Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBienSoXeRa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLocXeRa.PerformClick();
                ((Control)sender).Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void dgvXeRa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Allow the DataGridView to handle the navigation first
                // Then load images for the newly selected row
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    if (dgvXeRa.CurrentRow != null)
                    {
                        LoadImagesFromSelectedRow(dgvXeRa.CurrentRow);
                    }
                }));
            }
        }

        private async Task LoadXeRaData()
        {
            // InitializeDatabaseConnection(); // Ensure connection is open

            DateTime startDateFromPicker = dtXeRaTuDate.Value;
            DateTime endDateFromPicker = dtXeRaDenDate.Value;
            DateTime startTimeFromPicker = dtXeRaTuTime.Value;
            DateTime endTimeFromPicker = dtXeRaDenTime.Value;

            DateTime fullStartDateTime = new DateTime(
                startDateFromPicker.Year,
                startDateFromPicker.Month,
                startDateFromPicker.Day,
                startTimeFromPicker.Hour,
                startTimeFromPicker.Minute,
                startTimeFromPicker.Second);

            DateTime fullEndDateTime = new DateTime(
                endDateFromPicker.Year,
                endDateFromPicker.Month,
                endDateFromPicker.Day,
                endTimeFromPicker.Hour,
                endTimeFromPicker.Minute,
                endTimeFromPicker.Second);

            string selectedMaterialType = cbbXeRa.Text.Trim();
            string soTheXeRa = txtSoTheXeRa.Text.Trim();
            string bienSoXeRa = txtBienSoXeRa.Text.Trim();

            string query = @"
SELECT
    Ra.STTThe AS 'Số thẻ',
    Ra.CardID AS 'Mã thẻ',
    Vao.NgayVao AS 'Ngày vào',
    CONVERT(varchar, DATEADD(second, Vao.ThoiGian, 0), 108) AS 'Thời gian vào',
    Ra.NgayRa AS 'Ngày ra',
    CONVERT(varchar, DATEADD(second, Ra.THoiGianRa, 0), 108) AS 'Thời gian ra',
    Ra.MaLoaiThe AS 'Loại thẻ',
    Ra.GiaTien AS 'Tiền thu',
    Ra.IDXe AS 'IDXe',
    Ra.IDMat AS 'IDMat',
    Ra.soxe AS 'Biển số vào',
    Ra.soxera AS 'Biển số ra'
FROM
[dbo].[Ra]
INNER JOIN [dbo].[Vao] ON Ra.IDXe = Vao.IDXe
                WHERE 1=1 "; 

            query += @" AND (
                CAST(NgayRa AS DATETIME) +
                CAST(
                    RIGHT('0' + CAST(GioRa / 1000000 AS VARCHAR(2)), 2) + ':' +
                    RIGHT('0' + CAST((GioRa / 10000) % 100 AS VARCHAR(2)), 2) + ':' +
                    RIGHT('0' + CAST((GioRa / 100) % 100 AS VARCHAR(2)), 2) + '.' +
                    RIGHT('0' + CAST(GioRa % 100 AS VARCHAR(2)), 2)
                AS DATETIME)
            ) BETWEEN @fullStartDateTime AND @fullEndDateTime";

            // Add card number filter
            if (!string.IsNullOrEmpty(soTheXeRa))
            {
                query += " AND Ra.STTThe LIKE @soTheXeRa";
            }

            // Add license plate filter
            if (!string.IsNullOrEmpty(bienSoXeRa))
            {
                query += " AND (Ra.soxe LIKE @bienSoXeRa OR Ra.soxera LIKE @bienSoXeRa)";
            }

            // Add material type filter
            if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
            {
                query += " AND Ra.MaLoaiThe = @MaterialType";
            }

            query += " ORDER BY Ra.NgayRa DESC, Ra.GioRa DESC;";

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandTimeout = 120; // 2 minutes timeout
                    command.Parameters.AddWithValue("@fullStartDateTime", fullStartDateTime);
                    command.Parameters.AddWithValue("@fullEndDateTime", fullEndDateTime);

                    if (!string.IsNullOrEmpty(soTheXeRa))
                    {
                        command.Parameters.AddWithValue("@soTheXeRa", "%" + soTheXeRa + "%");
                    }
                    if (!string.IsNullOrEmpty(bienSoXeRa))
                    {
                        command.Parameters.AddWithValue("@bienSoXeRa", "%" + bienSoXeRa + "%");
                    }
                    if (!string.IsNullOrEmpty(selectedMaterialType) && selectedMaterialType.ToUpper() != "ALL")
                    {
                        command.Parameters.AddWithValue("@MaterialType", selectedMaterialType);
                    }

                    DataTable dataTable = new DataTable();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        dataTable.Load(reader);
                    }

                    dgvXeRa.SuspendLayout();
                    dgvXeRa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    dgvXeRa.DataSource = dataTable;
                    // Hide specific columns
                    if (dgvXeRa.Columns.Contains("Mã thẻ"))
                    {
                        dgvXeRa.Columns["Mã thẻ"].Visible = false;
                    }
                    if (dgvXeRa.Columns.Contains("IDXe"))
                    {
                        dgvXeRa.Columns["IDXe"].Visible = false;
                    }
                    if (dgvXeRa.Columns.Contains("IDMat"))
                    {
                        dgvXeRa.Columns["IDMat"].Visible = false;
                    }
                    dgvXeRa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvXeRa.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu xe ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private async void btnLocXeRa_Click(object sender, EventArgs e)
        {
            ShowLoading();
            try
            {
                await LoadXeRaData();
            }
            finally
            {
                HideLoading();
            }
        }

        private void dgvXeRa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadImagesFromSelectedRow(dgvXeRa.Rows[e.RowIndex]);
            }
        }

        private void LoadImagesFromSelectedRow(DataGridViewRow row)
        {
            string idXe = "";
            DateTime ngayVao;
            // Update Info TextBoxes
            try
            {
                // --- Info Vào ---
                idXe = row.Cells["IDXe"].Value?.ToString();
                if (!string.IsNullOrEmpty(idXe) && idXe.Length >= 8 &&
                    DateTime.TryParseExact(idXe.Substring(0, 8), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out ngayVao) &&
                    TimeSpan.TryParse(row.Cells["Thời gian vào"].Value?.ToString(), out TimeSpan timeVao))
                {
                    txtInfoVao.Text = $"Thông tin vào: Ngày {ngayVao.Day} tháng {ngayVao.Month} năm {ngayVao.Year} Thời gian: {timeVao.Hours} giờ {timeVao.Minutes} phút {timeVao.Seconds} giây";
                }
                else
                {
                    txtInfoVao.Text = "Thông tin vào: Không có dữ liệu";
                }

                // --- Info Ra ---
                if (DateTime.TryParse(row.Cells["Ngày ra"].Value?.ToString(), out DateTime ngayRa) &&
                    TimeSpan.TryParse(row.Cells["Thời gian ra"].Value?.ToString(), out TimeSpan timeRa))
                {
                    txtInfoRa.Text = $"Thông tin ra: Ngày {ngayRa.Day} tháng {ngayRa.Month} năm {ngayRa.Year} Thời gian: {timeRa.Hours} giờ {timeRa.Minutes} phút {timeRa.Seconds} giây";
                }
                else
                {
                    txtInfoRa.Text = "Thông tin ra: Không có dữ liệu";
                }
            }
            catch (Exception)
            {
                txtInfoVao.Text = "Thông tin vào: Lỗi định dạng dữ liệu";
                txtInfoRa.Text = "Thông tin ra: Lỗi định dạng dữ liệu";
            }

            // Clear picture boxes if data is incomplete or row is null
            ptHinhMatRa.Image = GetBlackImage(ptHinhMatRa.Width, ptHinhMatRa.Height);
            ptHinhXeRa.Image = GetBlackImage(ptHinhXeRa.Width, ptHinhXeRa.Height);
            toolTip1.SetToolTip(ptHinhMatRa, "Dữ liệu hàng không đầy đủ.");
            string idMat = row.Cells["IDMat"].Value?.ToString();
            idXe = row.Cells["IDXe"].Value?.ToString();
            string cardId = row.Cells["Mã thẻ"].Value?.ToString(); // Lấy CardID

            if (string.IsNullOrEmpty(idMat) || string.IsNullOrEmpty(idXe) || string.IsNullOrEmpty(cardId))
            {
                ptHinhMatRa.Image = GetBlackImage(ptHinhMatRa.Width, ptHinhMatRa.Height);
                ptHinhXeRa.Image = GetBlackImage(ptHinhXeRa.Width, ptHinhXeRa.Height);
                toolTip1.SetToolTip(ptHinhMatRa, "Dữ liệu hình ảnh không đầy đủ (IDMat, IDXe, Mã thẻ).");
                toolTip1.SetToolTip(ptHinhXeRa, "Dữ liệu hình ảnh không đầy đủ (IDMat, IDXe, Mã thẻ).");
                return;
            }



            // Attempt to parse NgayVao
            if (!DateTime.TryParse(row.Cells["Ngày vào"].Value?.ToString(), out ngayVao))
            {
                ptHinhMatRa.Image = GetBlackImage(ptHinhMatRa.Width, ptHinhMatRa.Height);
                ptHinhXeRa.Image = GetBlackImage(ptHinhXeRa.Width, ptHinhXeRa.Height);
                toolTip1.SetToolTip(ptHinhMatRa, "Không thể phân tích ngày vào.");
                toolTip1.SetToolTip(ptHinhXeRa, "Không thể phân tích ngày vào.");
                return;
            }

            string gioVaoString = row.Cells["Thời gian vào"].Value?.ToString();

            if (string.IsNullOrEmpty(gioVaoString))
            {
                ptHinhMatRa.Image = GetBlackImage(ptHinhMatRa.Width, ptHinhMatRa.Height);
                ptHinhXeRa.Image = GetBlackImage(ptHinhXeRa.Width, ptHinhXeRa.Height);
                toolTip1.SetToolTip(ptHinhMatRa, "Không thể phân tích giờ vào.");
                toolTip1.SetToolTip(ptHinhXeRa, "Không thể phân tích giờ vào.");
                ptHinhMatVao.Image = GetBlackImage(ptHinhMatVao.Width, ptHinhMatVao.Height);
                ptHinhXeVao.Image = GetBlackImage(ptHinhXeVao.Width, ptHinhXeVao.Height);
                toolTip1.SetToolTip(ptHinhMatRa, "Không thể phân tích giờ vào.");
                toolTip1.SetToolTip(ptHinhXeRa, "Không thể phân tích giờ vào.");
                return;
            }

            string folderPath = Properties.Settings.Default.SharedFolder;
            if (!string.IsNullOrEmpty(folderPath) && folderPath.StartsWith(@"\") && !folderPath.StartsWith(@"\\"))
            {
                folderPath = @"\\" + folderPath;
            }

            string yearMonthDay = ngayVao.ToString("yyyyMMdd");
            // Tạo tên tệp hình ảnh theo định dạng: ngayVao (yyyyMMdd) + gioVaoFormatted (HHmmss) + CardID
            string fileNameMat = idMat + cardId;
            string fileNameXe = idXe + cardId;

            //string imageMatPath = Path.Combine("\\192.168.1.99\Hinh", "out", "mat", yearMonthDay, fileNameMat + ".jpg");
            //string imageXePath = Path.Combine("\\192.168.1.99\Hinh", "out", "xe", yearMonthDay, fileNameXe + ".jpg");
            string imageMatPath = Path.Combine(folderPath, "out", "mat", yearMonthDay, fileNameMat + ".jpg");
            string imageXePath = Path.Combine(folderPath, "out", "xe", yearMonthDay, fileNameXe + ".jpg");
            string imageMatVaoPath = Path.Combine(folderPath, "in", "mat", yearMonthDay, fileNameMat + ".jpg");
            string imageXeVaoPath = Path.Combine(folderPath, "in", "xe", yearMonthDay, fileNameXe + ".jpg");

            if (string.IsNullOrWhiteSpace(folderPath))
            {
                // Thay vì MessageBox.Show, đặt hình ảnh là màu đen
                ptHinhMatRa.Image = GetBlackImage(ptHinhMatRa.Width, ptHinhMatRa.Height);
                ptHinhXeRa.Image = GetBlackImage(ptHinhXeRa.Width, ptHinhXeRa.Height);
                toolTip1.SetToolTip(ptHinhMatRa, "Đường dẫn thư mục hình ảnh không được để trống.");
                toolTip1.SetToolTip(ptHinhXeRa, "Đường dẫn thư mục hình ảnh không được để trống.");
                ptHinhMatVao.Image = GetBlackImage(ptHinhMatVao.Width, ptHinhMatVao.Height);
                ptHinhXeVao.Image = GetBlackImage(ptHinhXeVao.Width, ptHinhXeVao.Height);
                toolTip1.SetToolTip(ptHinhMatVao, "Đường dẫn thư mục hình ảnh không được để trống.");
                toolTip1.SetToolTip(ptHinhXeVao, "Đường dẫn thư mục hình ảnh không được để trống.");
                return;
            }
            else
            {

            }


            LoadImageIntoPictureBox(ptHinhMatVao, imageMatVaoPath);
            LoadImageIntoPictureBox(ptHinhXeVao, imageXeVaoPath);
            LoadImageIntoPictureBox(ptHinhMatRa, imageMatPath);
            LoadImageIntoPictureBox(ptHinhXeRa, imageXePath);
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLocXeRa.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void dgvXeRa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void btnXoaXeRa_Click(object sender, EventArgs e)
        {
            using (PasswordPromptForm passwordForm = new PasswordPromptForm())
            {
                DialogResult result = passwordForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string enteredPassword = passwordForm.EnteredPassword;

                    if (enteredPassword == DynamicPassword)
                    {
                        EvenDeleteXeRa();
                    }
                    else
                    {
                        MessageBox.Show("Sai mật khẩu. Vui lòng thử lại", "Xác thực không thành công!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Cancel.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void EvenDeleteXeRa()
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Chưa kết nối với cơ sở dữ liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvXeRa.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dòng để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedCount = dgvXeRa.SelectedRows.Count;
            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa {selectedCount} dòng dữ liệu đã chọn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgvXeRa.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    rowsToDelete.Add(row);
                }
            }

            if (rowsToDelete.Count == 0)
            {
                MessageBox.Show("Không có dòng hợp lệ nào được chọn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int batchSize = 700; // Optimized batch size for inserting into temp table, considering SQL Server 2100 parameter limit
            int totalRowsAffected = 0;
            SqlTransaction transaction = null;
            bool connectionOpenedHere = false;

            try
            {
                ShowLoading();
                InitializeDatabaseConnection();

                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                    connectionOpenedHere = true;
                }

                transaction = connection.BeginTransaction();

                // 1. Create Temporary Table
                string createTempTableQuery = @"
                    IF OBJECT_ID('tempdb..#TempDeleteIDsXeRa') IS NOT NULL DROP TABLE #TempDeleteIDsXeRa;
                    CREATE TABLE #TempDeleteIDsXeRa (
                        CardID NVARCHAR(50) NOT NULL,
                        IDXe NVARCHAR(50) NOT NULL,
                        IDMat NVARCHAR(50) NOT NULL
                    );";
                using (SqlCommand createTempCmd = new SqlCommand(createTempTableQuery, connection, transaction))
                {
                    await createTempCmd.ExecuteNonQueryAsync();
                }

                // 2. Insert IDs into Temporary Table in batches
                for (int i = 0; i < rowsToDelete.Count; i += batchSize)
                {
                    var batch = rowsToDelete.Skip(i).Take(batchSize).ToList();
                    if (!batch.Any()) continue;

                    StringBuilder insertValues = new StringBuilder();
                    List<SqlParameter> insertParameters = new List<SqlParameter>();
                    int paramIndex = 0;

                    foreach (var row in batch)
                    {
                        string cardId = row.Cells["Mã thẻ"].Value?.ToString();
                        string idXe = row.Cells["IDXe"].Value?.ToString();
                        string idMat = row.Cells["IDMat"].Value?.ToString();

                        if (string.IsNullOrEmpty(cardId) || string.IsNullOrEmpty(idXe) || string.IsNullOrEmpty(idMat))
                        {
                            continue;
                        }

                        string cardIdParam = "@cardId" + paramIndex;
                        string idXeParam = "@idXe" + paramIndex;
                        string idMatParam = "@idMat" + paramIndex;

                        if (insertValues.Length > 0)
                        {
                            insertValues.Append(", ");
                        }
                        insertValues.Append($"({cardIdParam}, {idXeParam}, {idMatParam})");

                        insertParameters.Add(new SqlParameter(cardIdParam, cardId));
                        insertParameters.Add(new SqlParameter(idXeParam, idXe));
                        insertParameters.Add(new SqlParameter(idMatParam, idMat));

                        paramIndex++;
                    }

                    if (insertValues.Length == 0) continue;

                    string insertTempTableQuery = $"INSERT INTO #TempDeleteIDsXeRa (CardID, IDXe, IDMat) VALUES {insertValues.ToString()}";
                    using (SqlCommand insertTempCmd = new SqlCommand(insertTempTableQuery, connection, transaction))
                    {
                        insertTempCmd.Parameters.AddRange(insertParameters.ToArray());
                        await insertTempCmd.ExecuteNonQueryAsync();
                    }
                }

                // User requested to remove ITKHA logging, so the logging step is removed.

                // 3. Perform the actual DELETE from [dbo].[Ra] using JOIN with the temporary table
                string deleteQuery = @"
                    DELETE R
                    FROM [dbo].[Ra] R
                    INNER JOIN #TempDeleteIDsXeRa T ON R.CardID = T.CardID AND R.IDXe = T.IDXe AND R.IDMat = T.IDMat;";
                using (SqlCommand finalDeleteCmd = new SqlCommand(deleteQuery, connection, transaction))
                {
                    totalRowsAffected = await finalDeleteCmd.ExecuteNonQueryAsync();
                }

                // 4. Drop the temporary table
                string dropTempTableQuery = "DROP TABLE #TempDeleteIDsXeRa;";
                using (SqlCommand dropTempCmd = new SqlCommand(dropTempTableQuery, connection, transaction))
                {
                    await dropTempCmd.ExecuteNonQueryAsync();
                }

                transaction.Commit();

                MessageBox.Show($"Đã xóa thành công {totalRowsAffected} dòng dữ liệu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadXeRaData(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Lỗi khi xóa dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HideLoading();
                if (connectionOpenedHere && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        private async void btnRevenueMonth_Click(object sender, EventArgs e)
        {
            ShowLoading();
            try
            {
                using (InputPromptForm inputForm = new InputPromptForm("Nhập tháng và năm (MM/YYYY):", "Doanh thu theo tháng"))
                {
                    if (inputForm.ShowDialog() == DialogResult.OK)
                    {
                        string input = inputForm.InputText.Trim();

                        if (!DateTime.TryParseExact(input, "MM/yyyy",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out DateTime monthYear))
                        {
                            MessageBox.Show("Định dạng không hợp lệ. Vui lòng nhập theo MM/YYYY.",
                                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Lấy giờ người dùng chọn
                        DateTime uiTimeStart = timeTimeStart.Value;
                        DateTime uiTimeEnd = timeTimeEnd.Value;

                        DataTable monthlyRevenueData = new DataTable();
                        monthlyRevenueData.Columns.Add("Ngày", typeof(string));
                        monthlyRevenueData.Columns.Add("Tiền thu", typeof(decimal));

                        decimal totalMonthlyRevenue = 0;

                        int daysInMonth = DateTime.DaysInMonth(monthYear.Year, monthYear.Month);

                        for (int day = 1; day <= daysInMonth; day++)
                        {
                            DateTime currentDay = new DateTime(monthYear.Year, monthYear.Month, day);

                            DateTime startTime = new DateTime(
                                currentDay.Year, currentDay.Month, currentDay.Day,
                                uiTimeStart.Hour, uiTimeStart.Minute, uiTimeStart.Second);

                            DateTime endTime = new DateTime(
                                currentDay.Year, currentDay.Month, currentDay.Day,
                                uiTimeEnd.Hour, uiTimeEnd.Minute, uiTimeEnd.Second);

                            if (endTime <= startTime)
                                endTime = endTime.AddDays(1);

                            DataTable dailyData = await ExecuteRevenueQuery(startTime, endTime);

                            decimal totalDailyRevenue = 0;

                            if (dailyData != null && dailyData.Columns.Contains("Tiền thu"))
                            {
                                foreach (DataRow row in dailyData.Rows)
                                {
                                    if (row["Tiền thu"] != DBNull.Value &&
                                        decimal.TryParse(row["Tiền thu"].ToString(), out decimal giaTien))
                                    {
                                        totalDailyRevenue += giaTien;
                                    }
                                }
                            }

                            monthlyRevenueData.Rows.Add(
                                currentDay.ToString("dd/MM/yyyy"),
                                Math.Round(totalDailyRevenue, 0)
                            );

                            totalMonthlyRevenue += totalDailyRevenue;
                        }

                        dgvResults.DataSource = monthlyRevenueData;
                        dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Format hiển thị
                        dgvResults.Columns["Ngày"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvResults.Columns["Tiền thu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvResults.Columns["Tiền thu"].DefaultCellStyle.Format = "N0";

                        txtSum.Text = totalMonthlyRevenue.ToString("N0") + " VNĐ";
                        txtCount.Text = monthlyRevenueData.Rows.Count.ToString("N0");
                        btnExportRevenue.Enabled = true;
                    }
                }
            }
            finally
            {
                HideLoading();
            }
        }

        private async void btnRevenueYear_Click(object sender, EventArgs e)
        {
            ShowLoading();
            try
            {
                using (InputPromptForm inputForm = new InputPromptForm("Nhập năm (YYYY):", "Doanh thu theo năm"))
                {
                    if (inputForm.ShowDialog() == DialogResult.OK)
                    {
                        string input = inputForm.InputText.Trim();

                        if (!int.TryParse(input, out int year) || year < 1900 || year > 2100)
                        {
                            MessageBox.Show("Năm không hợp lệ. Vui lòng nhập theo YYYY (ví dụ: 2025).",
                                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Lấy giờ người dùng chọn
                        DateTime uiTimeStart = timeTimeStart.Value;
                        DateTime uiTimeEnd = timeTimeEnd.Value;

                        DataTable yearlyRevenueData = new DataTable();
                        yearlyRevenueData.Columns.Add("Tháng", typeof(string));
                        yearlyRevenueData.Columns.Add("Tổng tiền", typeof(decimal));

                        decimal totalYearlyRevenue = 0;

                        for (int month = 1; month <= 12; month++)
                        {
                            DateTime firstDay = new DateTime(year, month, 1);
                            int days = DateTime.DaysInMonth(year, month);

                            DateTime startTime = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day,
                                                              uiTimeStart.Hour, uiTimeStart.Minute, uiTimeStart.Second);

                            DateTime endTime = new DateTime(firstDay.Year, firstDay.Month, days,
                                                            uiTimeEnd.Hour, uiTimeEnd.Minute, uiTimeEnd.Second);

                            if (endTime <= startTime)
                                endTime = endTime.AddDays(1);

                            DataTable monthlyData = await ExecuteRevenueQuery(startTime, endTime);

                            decimal totalMonthlyRevenue = 0;

                            if (monthlyData != null && monthlyData.Columns.Contains("Tiền thu"))
                            {
                                foreach (DataRow row in monthlyData.Rows)
                                {
                                    if (row["Tiền thu"] != DBNull.Value &&
                                        decimal.TryParse(row["Tiền thu"].ToString(), out decimal giaTien))
                                    {
                                        totalMonthlyRevenue += giaTien;
                                    }
                                }
                            }

                            yearlyRevenueData.Rows.Add(
                                $"Tháng {month}/{year}",
                                Math.Round(totalMonthlyRevenue, 0)
                            );

                            totalYearlyRevenue += totalMonthlyRevenue;
                        }

                        dgvResults.DataSource = yearlyRevenueData;
                        dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Format hiển thị
                        dgvResults.Columns["Tháng"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvResults.Columns["Tổng tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvResults.Columns["Tổng tiền"].DefaultCellStyle.Format = "N0";

                        txtSum.Text = totalYearlyRevenue.ToString("N0") + " VNĐ";
                        txtCount.Text = yearlyRevenueData.Rows.Count.ToString("N0");
                        btnExportRevenue.Enabled = true;
                    }
                }
            }
            finally
            {
                HideLoading();
            }
        }

        private void btnHideProgram_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void btnBackUp_Click(object sender, EventArgs e)
        {
            string databaseName = Properties.Settings.Default.DatabaseName;
            if (string.IsNullOrWhiteSpace(databaseName))
            {
                MessageBox.Show("Không thể xác định tên cơ sở dữ liệu từ cài đặt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string backupFileName = $"{databaseName}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Backup Files (*.bak)|*.bak|All files (*.*)|*.*";
                sfd.Title = "Chọn vị trí để sao lưu cơ sở dữ liệu";
                sfd.FileName = backupFileName;

                string sharedFolderPath = Properties.Settings.Default.SharedFolder;
                if (Directory.Exists(sharedFolderPath))
                {
                    sfd.InitialDirectory = sharedFolderPath;
                }

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string destBackupFile = sfd.FileName;
                    ShowLoading();
                    try
                    {
                        string serverAddress = Properties.Settings.Default.ServerAddress;
                        string uid = Properties.Settings.Default.Username;
                        string password = Properties.Settings.Default.Password;

                        // It's best practice to connect to the 'master' database to perform a backup.
                        var builder = new SqlConnectionStringBuilder
                        {
                            DataSource = serverAddress,
                            InitialCatalog = "master", // Connect to master DB for backup operation
                            IntegratedSecurity = string.IsNullOrWhiteSpace(uid),
                            TrustServerCertificate = true
                        };

                        if (!builder.IntegratedSecurity)
                        {
                            builder.UserID = uid;
                            builder.Password = password;
                        }

                        using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                        {
                            await conn.OpenAsync();

                            string backupCmd = $@"
                                BACKUP DATABASE [{databaseName}]
                                TO DISK = N'{destBackupFile}'
                                WITH INIT, STATS = 10";

                            using (SqlCommand cmd = new SqlCommand(backupCmd, conn))
                            {
                                cmd.CommandTimeout = 7200; // 2 hours timeout for large databases
                                await cmd.ExecuteNonQueryAsync();
                            }
                        }

                                                    MessageBox.Show(
                                                        $"Đã sao lưu cơ sở dữ liệu '{databaseName}' thành công đến:\n{destBackupFile}",
                                                        "Sao lưu thành công",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information);
                                                    _lastBackupFolderPath = Path.GetDirectoryName(destBackupFile);                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi trong quá trình sao lưu: {ex.Message}", "Lỗi sao lưu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        HideLoading();
                    }
                }
            }
        }

        private void Connection_InfoMessage_Backup(object sender, SqlInfoMessageEventArgs e)
        {
            // Các thông báo STATS sẽ có dạng "XX percent processed."
            // Chúng ta cần phân tích chuỗi này để lấy phần trăm.
            string message = e.Message;
            // Kiểm tra xem thông báo có chứa thông tin tiến độ hay không
            if (message.Contains("percent processed."))
            {
                // Sử dụng Regex để trích xuất số phần trăm
                System.Text.RegularExpressions.Match match =
                    System.Text.RegularExpressions.Regex.Match(message, @"^(\d+) percent processed.$");

                if (match.Success)
                {
                    if (int.TryParse(match.Groups[1].Value, out int percentComplete))
                    {
                        // Cập nhật ProgressBar trên UI Thread
                        // Cần dùng Invoke vì sự kiện này được gọi từ một thread khác (do Task.Run)
                        if (this.progressBarExport.InvokeRequired)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                // Đảm bảo giá trị trong khoảng hợp lệ [0, 100]
                                progressBarExport.Value = Math.Min(100, Math.Max(0, percentComplete));
                            });
                        }
                        else
                        {
                            progressBarExport.Value = Math.Min(100, Math.Max(0, percentComplete));
                        }
                    }
                }
            }
        }

        private void btnOpenBackup_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_lastBackupFolderPath))
            {
                if (Directory.Exists(_lastBackupFolderPath))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(_lastBackupFolderPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể mở thư mục '{_lastBackupFolderPath}': {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Thư mục '{_lastBackupFolderPath}' không tồn tại. Vui lòng kiểm tra lại.", "Thư mục không tồn tại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chưa có đường dẫn sao lưu nào được ghi nhận. Vui lòng thực hiện sao lưu trước.", "Không có đường dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region Excel Export Helpers

        private void OpenExportedFileDirectory(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                if (File.Exists(filePath))
                {
                    try
                    {
                        string directoryPath = Path.GetDirectoryName(filePath);
                        System.Diagnostics.Process.Start(directoryPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể mở thư mục. Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("File không tồn tại. Vui lòng xuất file trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chưa có file nào được xuất. Vui lòng xuất file Excel trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string ExportDataGridViewToExcel(DataGridView dgv, string defaultFileName)
        {
            // Convert DataGridView to DataTable
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    dt.Columns.Add(column.HeaderText);
                }
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Visible)
                {
                    DataRow dataRow = dt.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.OwningColumn.Visible)
                        {
                            // Ensure value is not null before adding
                            dataRow[cell.OwningColumn.HeaderText] = cell.Value ?? DBNull.Value;
                        }
                    }
                    dt.Rows.Add(dataRow);
                }
            }

            if (dt.Rows.Count == 0)
            {
                return null; // Return null to indicate no data, caller will show message
            }

            // Export DataTable to Excel
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            string finalFilePath = null;

            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                    Title = "Lưu file Excel",
                    FileName = $"{defaultFileName}-{DateTime.Now:dd-MM-yyyy}.xlsx"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    excelApp = new Excel.Application();
                    workbook = excelApp.Workbooks.Add();
                    Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                    // Headers
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                    }

                    // Data
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                        }
                    }
                    
                    worksheet.Columns.AutoFit();

                    workbook.SaveAs(sfd.FileName);
                    finalFilePath = sfd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (workbook != null) workbook.Close(false);
                if (excelApp != null) excelApp.Quit();
                
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);
            }

            return finalFilePath;
        }

        #endregion
        private void btnMoXeRa_Click(object sender, EventArgs e)
        {
            OpenExportedFileDirectory(lastXeRaExportPath);
        }

        private async void btnXuatXeRa_Click(object sender, EventArgs e)
        {
            if (dgvXeRa.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu 'Xe Ra' để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowLoading();
            try
            {
                string exportedFilePath = await RunSTATask(() => ExportDataGridViewToExcel(dgvXeRa, "DANH-SACH-XE-RA"));

                if (!string.IsNullOrEmpty(exportedFilePath))
                {
                    lastXeRaExportPath = exportedFilePath;
                    MessageBox.Show("Xuất dữ liệu 'Xe Ra' ra Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HideLoading();
            }
        }

        private void btnMoXeVao_Click(object sender, EventArgs e)
        {
            OpenExportedFileDirectory(lastXeVaoExportPath);
        }

        private async void btnXuatXeVao_Click(object sender, EventArgs e)
        {
            if (dgvXeVao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu 'Xe Vào' để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowLoading();
            try
            {
                string exportedFilePath = await RunSTATask(() => ExportDataGridViewToExcel(dgvXeVao, "DANH-SACH-XE-VAO"));

                if (!string.IsNullOrEmpty(exportedFilePath))
                {
                    lastXeVaoExportPath = exportedFilePath;
                    MessageBox.Show("Xuất dữ liệu 'Xe Vào' ra Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HideLoading();
            }
        }
    }
}
