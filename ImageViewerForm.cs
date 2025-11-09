using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDT_PARKING
{
    public partial class ImageViewerForm : Form
    {
        private List<string> _imagePaths;
        private int _currentIndex;
        private PictureBox _pictureBox; // Declare PictureBox here

        public ImageViewerForm(List<string> imagePaths, int startIndex)
        {
            InitializeComponent();
            _imagePaths = imagePaths;
            _currentIndex = startIndex;

            // Initialize PictureBox
            _pictureBox = new PictureBox();
            _pictureBox.Dock = DockStyle.Fill;
            _pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(_pictureBox);

            this.KeyDown += ImageViewerForm_KeyDown;
            this.KeyPreview = true; // Allow form to receive key events before controls

            LoadImage();
        }

        private void LoadImage()
        {
            if (_imagePaths == null || _imagePaths.Count == 0 || _currentIndex < 0 || _currentIndex >= _imagePaths.Count)
            {
                _pictureBox.Image = null;
                this.Text = "Image Viewer - No Image";
                return;
            }

            string imagePath = _imagePaths[_currentIndex];
            try
            {
                if (File.Exists(imagePath))
                {
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        _pictureBox.Image = Image.FromStream(fs);
                    }
                    this.Text = $"Image Viewer - {_currentIndex + 1}/{_imagePaths.Count} - {Path.GetFileName(imagePath)}";
                }
                else
                {
                    _pictureBox.Image = null;
                    this.Text = $"Image Viewer - {_currentIndex + 1}/{_imagePaths.Count} - Image Not Found";
                }
            }
            catch (Exception ex)
            {
                _pictureBox.Image = null;
                this.Text = $"Image Viewer - {_currentIndex + 1}/{_imagePaths.Count} - Error Loading Image";
                Console.WriteLine($"Error loading image {imagePath}: {ex.Message}");
            }
        }

        private void ImageViewerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_imagePaths == null || _imagePaths.Count <= 1) return;

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
            {
                _currentIndex = (_currentIndex - 1 + _imagePaths.Count) % _imagePaths.Count;
                LoadImage();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
            {
                _currentIndex = (_currentIndex + 1) % _imagePaths.Count;
                LoadImage();
                e.Handled = true;
            }
        }
    }
}
