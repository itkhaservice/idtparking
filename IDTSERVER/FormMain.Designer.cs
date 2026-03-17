namespace IDTSERVER
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tlpLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTopCamera = new Guna.UI2.WinForms.Guna2Panel();
            this.tlpCameras = new System.Windows.Forms.TableLayoutPanel();
            this.pbCam1 = new System.Windows.Forms.PictureBox();
            this.pbCam2 = new System.Windows.Forms.PictureBox();
            this.pbCam3 = new System.Windows.Forms.PictureBox();
            this.pbCam4 = new System.Windows.Forms.PictureBox();
            this.pnlMiddleInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.tlpGates = new System.Windows.Forms.TableLayoutPanel();
            this.gateLeft = new IDTSERVER.ParkingGateSection();
            this.gateRight = new IDTSERVER.ParkingGateSection();
            this.pnlBottomSnapshots = new Guna.UI2.WinForms.Guna2Panel();
            this.tlpSnapshots = new System.Windows.Forms.TableLayoutPanel();
            this.pbSnap1 = new System.Windows.Forms.PictureBox();
            this.pbSnap2 = new System.Windows.Forms.PictureBox();
            this.pbSnap3 = new System.Windows.Forms.PictureBox();
            this.pbSnap4 = new System.Windows.Forms.PictureBox();
            
            this.tlpLayout.SuspendLayout();
            this.pnlTopCamera.SuspendLayout();
            this.tlpCameras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam4)).BeginInit();
            this.pnlMiddleInfo.SuspendLayout();
            this.tlpGates.SuspendLayout();
            this.pnlBottomSnapshots.SuspendLayout();
            this.tlpSnapshots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap4)).BeginInit();
            this.SuspendLayout();

            // tlpLayout
            this.tlpLayout.ColumnCount = 1;
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.Controls.Add(this.pnlTopCamera, 0, 0);
            this.tlpLayout.Controls.Add(this.pnlMiddleInfo, 0, 1);
            this.tlpLayout.Controls.Add(this.pnlBottomSnapshots, 0, 2);
            this.tlpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpLayout.Name = "tlpLayout";
            this.tlpLayout.RowCount = 3;
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpLayout.Size = new System.Drawing.Size(1280, 720);

            // pnlTopCamera
            this.pnlTopCamera.Controls.Add(this.tlpCameras);
            this.pnlTopCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopCamera.FillColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.pnlTopCamera.Padding = new System.Windows.Forms.Padding(5);

            // tlpCameras
            this.tlpCameras.ColumnCount = 4;
            this.tlpCameras.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCameras.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCameras.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCameras.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCameras.Controls.Add(this.pbCam1, 0, 0);
            this.tlpCameras.Controls.Add(this.pbCam2, 1, 0);
            this.tlpCameras.Controls.Add(this.pbCam3, 2, 0);
            this.tlpCameras.Controls.Add(this.pbCam4, 3, 0);
            this.tlpCameras.Dock = System.Windows.Forms.DockStyle.Fill;

            // PictureBoxes Camera Live
            this.pbCam1.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            this.pbCam1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCam1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCam1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCam1.Margin = new System.Windows.Forms.Padding(2);

            this.pbCam2.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            this.pbCam2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCam2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCam2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCam2.Margin = new System.Windows.Forms.Padding(2);

            this.pbCam3.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            this.pbCam3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCam3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCam3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCam3.Margin = new System.Windows.Forms.Padding(2);

            this.pbCam4.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            this.pbCam4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCam4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCam4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCam4.Margin = new System.Windows.Forms.Padding(2);

            // pnlMiddleInfo
            this.pnlMiddleInfo.Controls.Add(this.tlpGates);
            this.pnlMiddleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddleInfo.FillColor = System.Drawing.Color.White;
            this.pnlMiddleInfo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);

            this.tlpGates.ColumnCount = 2;
            this.tlpGates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGates.Controls.Add(this.gateLeft, 0, 0);
            this.tlpGates.Controls.Add(this.gateRight, 1, 0);
            this.tlpGates.Dock = System.Windows.Forms.DockStyle.Fill;

            // pnlBottomSnapshots
            this.pnlBottomSnapshots.Controls.Add(this.tlpSnapshots);
            this.pnlBottomSnapshots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottomSnapshots.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.pnlBottomSnapshots.Padding = new System.Windows.Forms.Padding(5);

            // tlpSnapshots
            this.tlpSnapshots.ColumnCount = 4;
            this.tlpSnapshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSnapshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSnapshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSnapshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSnapshots.Controls.Add(this.pbSnap1, 0, 0);
            this.tlpSnapshots.Controls.Add(this.pbSnap2, 1, 0);
            this.tlpSnapshots.Controls.Add(this.pbSnap3, 2, 0);
            this.tlpSnapshots.Controls.Add(this.pbSnap4, 3, 0);
            this.tlpSnapshots.Dock = System.Windows.Forms.DockStyle.Fill;

            // PictureBoxes Snapshot
            this.pbSnap1.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pbSnap1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSnap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSnap1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSnap1.Margin = new System.Windows.Forms.Padding(2);

            this.pbSnap2.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pbSnap2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSnap2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSnap2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSnap2.Margin = new System.Windows.Forms.Padding(2);

            this.pbSnap3.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pbSnap3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSnap3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSnap3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSnap3.Margin = new System.Windows.Forms.Padding(2);

            this.pbSnap4.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pbSnap4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSnap4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSnap4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSnap4.Margin = new System.Windows.Forms.Padding(2);

            // FormMain
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.tlpLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.tlpLayout.ResumeLayout(false);
            this.pnlTopCamera.ResumeLayout(false);
            this.tlpCameras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCam1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam4)).EndInit();
            this.pnlMiddleInfo.ResumeLayout(false);
            this.tlpGates.ResumeLayout(false);
            this.pnlBottomSnapshots.ResumeLayout(false);
            this.tlpSnapshots.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap4)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLayout;
        private Guna.UI2.WinForms.Guna2Panel pnlTopCamera;
        private System.Windows.Forms.TableLayoutPanel tlpCameras;
        private System.Windows.Forms.PictureBox pbCam1;
        private System.Windows.Forms.PictureBox pbCam2;
        private System.Windows.Forms.PictureBox pbCam3;
        private System.Windows.Forms.PictureBox pbCam4;
        private Guna.UI2.WinForms.Guna2Panel pnlMiddleInfo;
        private System.Windows.Forms.TableLayoutPanel tlpGates;
        private IDTSERVER.ParkingGateSection gateLeft;
        private IDTSERVER.ParkingGateSection gateRight;
        private Guna.UI2.WinForms.Guna2Panel pnlBottomSnapshots;
        private System.Windows.Forms.TableLayoutPanel tlpSnapshots;
        private System.Windows.Forms.PictureBox pbSnap1;
        private System.Windows.Forms.PictureBox pbSnap2;
        private System.Windows.Forms.PictureBox pbSnap3;
        private System.Windows.Forms.PictureBox pbSnap4;
    }
}
