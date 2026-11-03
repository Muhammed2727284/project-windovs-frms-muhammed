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

            // Сначала загружаем меню, заказы и пользователей из XML-файлов
            DataService.Load();

            // При первом запуске (пользователей ещё нет) создаём администратора admin / admin123
            AuthService.EnsureDefaultAdmin();

            // Цикл «вход → главное окно».
            // «Выйти» на главном окне возвращает к окну входа,
            // а закрытие любого окна крестиком завершает программу.
            while (true)
            {
                using (LoginForm login = new LoginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                    {
                        return; // окно входа закрыли — выходим из программы
                    }
                }

                MainForm main = new MainForm();
                Application.Run(main);

                if (!main.LogoutRequested)
                {
                    return; // главное окно закрыли крестиком — выходим из программы
                }
            }
        }
    }
}
