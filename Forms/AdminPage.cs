using System;
using System.Windows.Forms;
using Muhammed.UI;

namespace Muhammed.Forms
{
    /// <summary>
    /// Страница «Админ-панель» (только для администратора).
    /// Три плитки открывают уже готовые окна:
    /// «Блюда» — MenuForm, «Пользователи» — UsersForm, «Отчёт по выручке» — ReportForm.
    /// </summary>
    public partial class AdminPage : UserControl
    {
        public AdminPage()
        {
            InitializeComponent();

            // Единое оформление: цвета и шрифты берутся из класса Theme
            Theme.ApplyToPage(this);
            Theme.StyleHeader(lblTitle);
            Theme.StyleMuted(lblSubtitle);
            // Плитки: заголовок — Text, описание — AccessibleDescription (заданы в конструкторе формы)
            Theme.StyleTileButton(btnDishes, Theme.IconMenu);
            Theme.StyleTileButton(btnUsers, Theme.IconUsers);
            Theme.StyleTileButton(btnReport, Theme.IconReport);
        }

        /// <summary>«Блюда»: окно управления меню (добавить, изменить, удалить).</summary>
        private void btnDishes_Click(object sender, EventArgs e)
        {
            using (MenuForm form = new MenuForm())
            {
                form.ShowDialog(FindForm());
            }
        }

        /// <summary>«Пользователи»: список пользователей, смена роли, удаление.</summary>
        private void btnUsers_Click(object sender, EventArgs e)
        {
            using (UsersForm form = new UsersForm())
            {
                form.ShowDialog(FindForm());
            }
        }

        /// <summary>«Отчёт по выручке»: отчёт за день.</summary>
        private void btnReport_Click(object sender, EventArgs e)
        {
            using (ReportForm form = new ReportForm())
            {
                form.ShowDialog(FindForm());
            }
        }
    }
}
