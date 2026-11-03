using System;
using System.Windows.Forms;
using Muhammed.Forms;
using Muhammed.Services;

namespace Muhammed
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Сначала загружаем меню и заказы из XML-файлов,
            // и только потом открываем главную форму
            DataService.Load();

            Application.Run(new MainForm());
        }
    }
}
