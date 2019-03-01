using System;
using System.Windows.Forms;

namespace RoboRadio
{
    static class Program
    {
        public static MainWindow MainWindowVirtual;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainWindowVirtual = new MainWindow();

            Functions.CheckStartExceptions();

            Application.Run(MainWindowVirtual);            
        }
    }
}
