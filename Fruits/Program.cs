using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fruits
{
    internal static class Program
    {
        public static Form1 indexForm = null;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            indexForm = new Form1();
            Application.Run(indexForm);
        }
    }
}
