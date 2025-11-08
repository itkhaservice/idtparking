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
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            textBox1.Text = "" +
                "Sử dụng những câu lệnh này để dùng ở Bảng truy vấn và nhấn Enter để thực thi" +
                "\r" +
                "\n" +
                "Lấy toàn bộ danh sách các bảng dữ liệu" +
                "\r" +
                "\n" +
                "SELECT table_name FROM information_schema.tables WHERE table_type = 'BASE TABLE'" +
                "\r" +
                "\n" +
                "Lấy dữ liệu ở một bảng ví dụ" +
                "\r" +
                "\n" +
                "SELECT * FROM Ra1" +
                "\n" +
                "\r" +
                "\n" +
                "Lấy toàn bộ các IP đang lắng nghe" +
                "\r" +
                "\n" +
                "EXEC xp_cmdshell 'ipconfig';";
        }
    }
}
