using Presentacion.Forms;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Forms.FrmLogin());
        }
    }
}