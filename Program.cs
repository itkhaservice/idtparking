using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDT_PARKING
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (FormCaiDat mainForm = new FormCaiDat())
            {
                Application.Run(mainForm);
            }
        }
    }
}
