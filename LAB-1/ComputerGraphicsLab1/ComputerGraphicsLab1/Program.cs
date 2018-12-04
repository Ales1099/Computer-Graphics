using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ComputerGraphicsLab1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //Console.WriteLine("jdkdj");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ComputerGraphicLab1());
        }
    }
}
