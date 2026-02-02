using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace IDT_PARKING
{
    public static class ToolTipManager
    {
        /// <summary>
        /// Khởi tạo và thiết lập các ToolTip cho các điều khiển trên Form.
        /// Bạn có thể thêm các dòng code mới tại đây để mở rộng tooltip trong tương lai.
        /// </summary>
        /// <param name="mainForm">Tham chiếu đến Form chính</param>
        /// <param name="toolTipComponent">Thành phần ToolTip được sử dụng</param>
        public static void InitializeToolTips(FormMain mainForm, ToolTip toolTipComponent)
        {
            if (mainForm == null || toolTipComponent == null) return;

            // Truy cập các control thông thông qua phương thức Find hoặc Reflection vì chúng là private
            // Cách an toàn nhất là tìm control theo tên trong Form
            
            SetToolTip(mainForm, toolTipComponent, "btnThem_KH", "Thêm dòng dữ liệu Khách hàng trống");
            
            // Ví dụ thêm sau này:
            // SetToolTip(mainForm, toolTipComponent, "btnUpdate_KH", "Cập nhật thông tin khách hàng");
            // SetToolTip(mainForm, toolTipComponent, "btnMoQuery", "Mở khóa các tính năng nâng cao cho kỹ thuật viên");
        }

        private static void SetToolTip(FormMain form, ToolTip tt, string controlName, string message)
        {
            Control[] controls = form.Controls.Find(controlName, true);
            if (controls.Length > 0)
            {
                tt.SetToolTip(controls[0], message);
            }
        }
    }
}
