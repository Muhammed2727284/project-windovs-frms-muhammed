using System;
using System.Drawing;
using System.Windows.Forms;
using Muhammed.Services;
using Muhammed.UI;

namespace Muhammed.Forms
{
    /// <summary>
    /// Главное окно после входа — «рамка» программы:
    /// вверху название кафе, ФИО и роль пользователя и кнопка «Выйти»,
    /// слева боковое меню, справа область содержимого.
    /// В область содержимого по нажатию пункта меню кладётся страница (UserControl):
    /// OrdersPage, MenuViewPage или AdminPage.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// true, если окно закрыто кнопкой «Выйти» (тогда Program.cs снова покажет окно входа).
        /// false, если окно закрыли крестиком (тогда программа завершается).
        /// </summary>
        public bool LogoutRequested { get; private set; }

        /// <summary>Все пункты бокового меню — чтобы подсвечивать активный.</summary>
        private Button[] navButtons;

        public MainForm()
        {
            InitializeComponent();

            // Единое оформление: цвета и шрифты берутся из класса Theme
            Theme.ApplyToForm(this);
            pnlSidebar.BackColor = Theme.Sidebar;
            pnlTop.BackColor = Theme.Surface;
            pnlTopLine.BackColor = Theme.Line;
            lblCafeName.ForeColor = Theme.Text;
            lblCafeName.Text = Theme.CafeName;
            Theme.StyleMuted(lblUserRole);
            Theme.StyleMuted(lblGreeting);
            Theme.SetIcon(btnLogout, Theme.IconLogout);

            // Пункты бокового меню: «таблетки» с иконками
            Theme.StyleSidebarButton(btnNavMenu, Theme.IconMenu);
            Theme.StyleSidebarButton(btnNavNewOrder, Theme.IconAdd);
            Theme.StyleSidebarButton(btnNavOrders, Theme.IconOrders);
            Theme.StyleSidebarButton(btnNavAdmin, Theme.IconSettings);
            navButtons = new Button[] { btnNavMenu, btnNavNewOrder, btnNavOrders, btnNavAdmin };

            // Кто вошёл: ФИО и роль в правом верхнем углу, приветствие под названием кафе
            lblUserName.Text = CurrentUser.User.FullName;
            lblUserRole.Text = CurrentUser.User.Role.ToString();
            lblGreeting.Text = GetGreeting() + ", " + GetFirstName(CurrentUser.User.FullName) + "!";
            Text = Theme.CafeName + " — учёт заказов";

            // Админ-панель видна только администратору
            btnNavAdmin.Visible = CurrentUser.IsAdmin;

            // По умолчанию открываем страницу «Заказы»
            ShowOrdersPage();
        }

        /// <summary>Приветствие по времени суток.</summary>
        private static string GetGreeting()
        {
            int hour = DateTime.Now.Hour;
            if (hour >= 5 && hour < 12)
            {
                return "Доброе утро";
            }
            if (hour >= 12 && hour < 18)
            {
                return "Добрый день";
            }
            if (hour >= 18 && hour < 23)
            {
                return "Добрый вечер";
            }
            return "Доброй ночи";
        }

        /// <summary>
        /// Имя для приветствия из ФИО «Фамилия Имя Отчество» — второе слово.
        /// Если слово одно — возвращает его.
        /// </summary>
        private static string GetFirstName(string fullName)
        {
            string[] words = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length >= 2)
            {
                return words[1];
            }
            return words.Length == 1 ? words[0] : "";
        }

        /// <summary>
        /// Рисует логотип в боковом меню: карамельный квадрат с чашкой,
        /// название кафе и подпись «учёт заказов».
        /// </summary>
        private void lblLogo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Theme.Sidebar);

            Rectangle badge = new Rectangle(20, (lblLogo.Height - 44) / 2, 44, 44);
            Theme.FillRounded(g, badge, 12, Theme.Accent);
            using (Font cupFont = new Font("Segoe UI Symbol", 17F))
            {
                // ☕ — символ «горячий напиток» (чашка)
                TextRenderer.DrawText(g, "☕", cupFont, badge, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            }

            using (Font nameFont = new Font("Segoe UI", 15F, FontStyle.Bold))
            {
                TextRenderer.DrawText(g, Theme.CafeShortName, nameFont,
                    new Point(badge.Right + 10, badge.Y - 4), Color.White);
            }
            TextRenderer.DrawText(g, "учёт заказов", Theme.Regular,
                new Point(badge.Right + 12, badge.Y + 25), Theme.SidebarMuted);
        }

        /// <summary>Рисует круглый аватар с инициалами вошедшего пользователя.</summary>
        private void lblAvatar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Theme.Surface);
            Rectangle circle = new Rectangle(1, 1, lblAvatar.Width - 3, lblAvatar.Height - 3);
            string name = CurrentUser.User != null ? CurrentUser.User.FullName : "";
            Theme.DrawAvatar(e.Graphics, circle, name);
        }

        /// <summary>
        /// Показывает страницу в области содержимого и подсвечивает пункт меню.
        /// Старая страница удаляется, поэтому каждая страница при открытии
        /// показывает свежие данные.
        /// </summary>
        private void ShowPage(UserControl page, Button navButton)
        {
            // Удаляем и освобождаем старую страницу
            while (pnlContent.Controls.Count > 0)
            {
                Control old = pnlContent.Controls[0];
                pnlContent.Controls.Remove(old);
                old.Dispose();
            }

            page.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(page);

            Theme.SetActiveSidebarButton(navButtons, navButton);
        }

        /// <summary>Открывает страницу «Заказы» и возвращает её.</summary>
        private OrdersPage ShowOrdersPage()
        {
            OrdersPage page = new OrdersPage();
            ShowPage(page, btnNavOrders);
            return page;
        }

        // ===== Пункты бокового меню =====

        /// <summary>«Меню кафе»: просмотр блюд (доступно всем).</summary>
        private void btnNavMenu_Click(object sender, EventArgs e)
        {
            ShowPage(new MenuViewPage(), btnNavMenu);
        }

        /// <summary>
        /// «Новый заказ»: открывает страницу «Заказы» и сразу окно нового заказа.
        /// После сохранения новый заказ будет выделен в таблице.
        /// </summary>
        private void btnNavNewOrder_Click(object sender, EventArgs e)
        {
            OrdersPage page = ShowOrdersPage();
            page.NewOrder();
        }

        /// <summary>«Заказы»: таблица заказов.</summary>
        private void btnNavOrders_Click(object sender, EventArgs e)
        {
            ShowOrdersPage();
        }

        /// <summary>«Админ-панель»: только для администратора.</summary>
        private void btnNavAdmin_Click(object sender, EventArgs e)
        {
            // Пункт у сотрудника скрыт, но проверяем права ещё раз — на всякий случай
            if (!CurrentUser.IsAdmin)
            {
                return;
            }
            ShowPage(new AdminPage(), btnNavAdmin);
        }

        // ===== Выход =====

        /// <summary>«Выйти»: завершает сеанс и возвращает к окну входа.</summary>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Выйти из учётной записи?", "Выход",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes)
            {
                return;
            }

            CurrentUser.SignOut();
            LogoutRequested = true;
            Close();
        }
    }
}
