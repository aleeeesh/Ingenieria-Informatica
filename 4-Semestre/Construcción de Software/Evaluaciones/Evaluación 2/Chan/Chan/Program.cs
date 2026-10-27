using System;
using System.Windows.Forms;
using GanaderaChan.Presentacion;

namespace GanaderaChan
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormVentas());
        }
    }
}
