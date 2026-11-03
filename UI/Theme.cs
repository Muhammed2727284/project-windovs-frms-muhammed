using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Muhammed.Models;

namespace Muhammed.UI
{
    /// <summary>
    /// Единое оформление всех окон программы: цвета, шрифты, иконки и методы,
    /// которые красят формы, кнопки, поля ввода и таблицы.
    ///
    /// Тема применяется в конструкторе формы ПОСЛЕ InitializeComponent().
    /// Поэтому файлы .Designer.cs остаются обычными и открываются в конструкторе VS,
    /// а цвета не нужно задавать вручную в каждой форме.
    ///
    /// Скруглённые кнопки, поля и карточки рисуются в обработчиках события Paint:
    /// стандартные элементы WinForms умеют только прямоугольники.
    /// </summary>
    public static class Theme
    {
        // ===== Цвета (тёплая «кофейная» палитра) =====

        /// <summary>Фон окон — тёплый молочный.</summary>
        public static readonly Color Background = Color.FromArgb(251, 246, 239);

        /// <summary>Фон «карточек»: верхней панели, таблиц, полей ввода.</summary>
        public static readonly Color Surface = Color.White;

        /// <summary>Основной цвет текста — тёмный шоколад.</summary>
        public static readonly Color Text = Color.FromArgb(59, 42, 32);

        /// <summary>Второстепенный текст: подсказки, подписи.</summary>
        public static readonly Color TextMuted = Color.FromArgb(150, 128, 110);

        /// <summary>Боковое меню — эспрессо.</summary>
        public static readonly Color Sidebar = Color.FromArgb(43, 29, 22);

        /// <summary>Пункт бокового меню под курсором мыши.</summary>
        public static readonly Color SidebarHover = Color.FromArgb(68, 48, 37);

        /// <summary>Текст пунктов бокового меню.</summary>
        public static readonly Color SidebarText = Color.FromArgb(236, 222, 205);

        /// <summary>Иконки и подписи в боковом меню (приглушённые).</summary>
        public static readonly Color SidebarMuted = Color.FromArgb(160, 134, 113);

        /// <summary>Акцентный цвет (карамель) — главные кнопки и активный пункт меню.</summary>
        public static readonly Color Accent = Color.FromArgb(217, 130, 43);

        /// <summary>Акцентный цвет при наведении мыши (темнее).</summary>
        public static readonly Color AccentHover = Color.FromArgb(190, 108, 30);

        /// <summary>Очень светлый акцент: фон иконок на плитках, галочки.</summary>
        public static readonly Color AccentSoft = Color.FromArgb(252, 236, 215);

        /// <summary>Обычные кнопки — латте.</summary>
        public static readonly Color Secondary = Color.FromArgb(243, 231, 216);

        /// <summary>Обычные кнопки при наведении мыши.</summary>
        public static readonly Color SecondaryHover = Color.FromArgb(233, 215, 193);

        /// <summary>«Опасные» кнопки (удаление) — терракота.</summary>
        public static readonly Color Danger = Color.FromArgb(201, 79, 58);

        /// <summary>«Опасные» кнопки при наведении мыши.</summary>
        public static readonly Color DangerHover = Color.FromArgb(174, 61, 43);

        /// <summary>Шапка таблицы — светлая карамель.</summary>
        public static readonly Color GridHeader = Color.FromArgb(244, 227, 207);

        /// <summary>Текст шапки таблицы.</summary>
        public static readonly Color GridHeaderText = Color.FromArgb(107, 74, 51);

        /// <summary>Цвет каждой второй строки таблицы.</summary>
        public static readonly Color GridAlternate = Color.FromArgb(253, 249, 244);

        /// <summary>Выделенная строка таблицы.</summary>
        public static readonly Color GridSelection = Color.FromArgb(250, 226, 196);

        /// <summary>Тонкие линии: разделители строк, рамки карточек.</summary>
        public static readonly Color Line = Color.FromArgb(238, 226, 212);

        /// <summary>Рамка поля ввода.</summary>
        public static readonly Color InputBorder = Color.FromArgb(222, 205, 186);

        // ===== Шрифты =====
        // Размер обычного шрифта 9 — такой же, как был в формах.
        // Если его поменять, WinForms пересчитает размеры всех элементов (AutoScaleMode.Font).

        /// <summary>Обычный текст.</summary>
        public static readonly Font Regular = new Font("Segoe UI", 9F);

        /// <summary>Жирный текст (подписи, шапка таблицы).</summary>
        public static readonly Font Bold = new Font("Segoe UI", 9F, FontStyle.Bold);

        /// <summary>Полужирный текст кнопок.</summary>
        public static readonly Font ButtonFont = new Font("Segoe UI Semibold", 9F);

        /// <summary>Заголовок раздела.</summary>
        public static readonly Font Header = new Font("Segoe UI", 15F, FontStyle.Bold);

        /// <summary>Крупный заголовок (название кафе).</summary>
        public static readonly Font Title = new Font("Segoe UI", 18F, FontStyle.Bold);

        /// <summary>Пункты бокового меню.</summary>
        public static readonly Font SidebarFont = new Font("Segoe UI Semibold", 10.5F);

        /// <summary>Заголовок плитки админ-панели.</summary>
        public static readonly Font TileFont = new Font("Segoe UI", 12F, FontStyle.Bold);

        /// <summary>Шрифт иконок, встроенный в Windows 10/11.</summary>
        public static readonly Font IconFont = new Font("Segoe MDL2 Assets", 12F);

        /// <summary>Крупные иконки (плитки).</summary>
        public static readonly Font IconFontLarge = new Font("Segoe MDL2 Assets", 18F);

        // ===== Иконки (символы шрифта Segoe MDL2 Assets) =====

        /// <summary>Книга — «Меню кафе», «Блюда».</summary>
        public const string IconMenu = "";

        /// <summary>Плюс — «Новый заказ».</summary>
        public const string IconAdd = "";

        /// <summary>Планшет со списком — «Заказы».</summary>
        public const string IconOrders = "";

        /// <summary>Шестерёнка — «Админ-панель».</summary>
        public const string IconSettings = "";

        /// <summary>Люди — «Пользователи».</summary>
        public const string IconUsers = "";

        /// <summary>Документ с графиком — «Отчёт».</summary>
        public const string IconReport = "";

        /// <summary>Кнопка питания — «Выйти».</summary>
        public const string IconLogout = "";

        /// <summary>Корзина — «Удалить».</summary>
        public const string IconDelete = "";

        /// <summary>Карандаш — «Изменить», «Открыть».</summary>
        public const string IconEdit = "";

        /// <summary>Лупа — «Найти».</summary>
        public const string IconSearch = "";

        /// <summary>Галочка — «Сохранить», «Изменить статус».</summary>
        public const string IconCheck = "";

        // ===== Названия =====

        /// <summary>Название кафе в программе.</summary>
        public const string CafeName = "Кофейня «Уют»";

        /// <summary>Короткое название для логотипа в боковом меню.</summary>
        public const string CafeShortName = "Уют";

        // ===== Формы и страницы =====

        /// <summary>
        /// Оформляет форму целиком: фон, шрифт, положение по центру
        /// и все элементы внутри (кнопки, таблицы, поля ввода, группы).
        /// </summary>
        public static void ApplyToForm(Form form)
        {
            form.BackColor = Background;
            form.ForeColor = Text;
            form.Font = Regular;

            // Диалоги (CenterParent) открываются по центру окна-владельца,
            // все остальные окна — по центру экрана
            if (form.StartPosition != FormStartPosition.CenterParent)
            {
                form.StartPosition = FormStartPosition.CenterScreen;
            }

            ApplyToControls(form.Controls);
        }

        /// <summary>
        /// Оформляет страницу (UserControl), которая показывается внутри главной формы.
        /// </summary>
        public static void ApplyToPage(UserControl page)
        {
            page.BackColor = Background;
            page.ForeColor = Text;
            page.Font = Regular;
            ApplyToControls(page.Controls);
        }

        /// <summary>
        /// Обходит элементы и оформляет каждый по его типу.
        /// Метод рекурсивный: заходит внутрь панелей и групп.
        /// </summary>
        private static void ApplyToControls(Control.ControlCollection controls)
        {
            // Копируем список: StyleTextBox меняет размеры, а коллекцию при обходе лучше не трогать
            Control[] list = new Control[controls.Count];
            controls.CopyTo(list, 0);

            foreach (Control control in list)
            {
                if (control is Button)
                {
                    StyleButton((Button)control);
                }
                else if (control is DataGridView)
                {
                    StyleGrid((DataGridView)control);
                }
                else if (control is TextBox)
                {
                    StyleTextBox((TextBox)control);
                }
                else if (control is GroupBox)
                {
                    StyleCard((GroupBox)control);
                }
                else if (control is ComboBox)
                {
                    ComboBox combo = (ComboBox)control;
                    combo.FlatStyle = FlatStyle.Flat;
                    combo.BackColor = Surface;
                    combo.ForeColor = Text;
                    RegisterInput(combo);
                }
                else if (control is NumericUpDown)
                {
                    NumericUpDown number = (NumericUpDown)control;
                    number.BorderStyle = BorderStyle.None;
                    number.BackColor = Surface;
                    RegisterInput(number);
                }
                else if (control is Label)
                {
                    // Прозрачный фон: подпись не закрывает скруглённые рамки и карточки под собой
                    control.BackColor = Color.Transparent;
                }
                else if (control is CheckBox)
                {
                    CheckBox check = (CheckBox)control;
                    check.FlatStyle = FlatStyle.Flat;
                    check.FlatAppearance.BorderColor = InputBorder;
                    check.FlatAppearance.CheckedBackColor = AccentSoft;
                    check.Cursor = Cursors.Hand;
                }

                // Внутри панели или группы тоже могут быть элементы
                if (control.Controls.Count > 0 && !(control is DataGridView) && !(control is NumericUpDown))
                {
                    ApplyToControls(control.Controls);
                }
            }
        }

        // ===== Рисование скруглённых фигур =====

        /// <summary>
        /// Создаёт контур прямоугольника со скруглёнными углами.
        /// Контур нужно освободить (using), когда он больше не нужен.
        /// </summary>
        public static GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);                 // левый верхний угол
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);         // правый верхний
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);  // правый нижний
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);         // левый нижний
            path.CloseFigure();
            return path;
        }

        /// <summary>Заливает скруглённый прямоугольник цветом (со сглаживанием краёв).</summary>
        public static void FillRounded(Graphics g, Rectangle r, int radius, Color color)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = RoundedRect(r, radius))
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillPath(brush, path);
            }
        }

        /// <summary>Рисует рамку скруглённого прямоугольника (со сглаживанием краёв).</summary>
        public static void DrawRounded(Graphics g, Rectangle r, int radius, Color color, float width)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = RoundedRect(r, radius))
            using (Pen pen = new Pen(color, width))
            {
                g.DrawPath(pen, path);
            }
        }

        /// <summary>true, если курсор мыши сейчас над элементом.</summary>
        private static bool IsMouseOver(Control control)
        {
            return control.Enabled && control.ClientRectangle.Contains(control.PointToClient(Control.MousePosition));
        }

        // ===== Кнопки =====

        /// <summary>
        /// Общие настройки кнопки: плоская, без рамки, курсор-рука,
        /// цвет фона и цвет при наведении. Сама кнопка рисуется скруглённой
        /// в обработчике PaintRoundedButton.
        /// </summary>
        private static void StyleFlat(Button button, Color back, Color hover, Color fore)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.UseVisualStyleBackColor = false;
            button.BackColor = back;
            button.ForeColor = fore;
            button.FlatAppearance.MouseOverBackColor = hover;
            button.FlatAppearance.MouseDownBackColor = hover;
            button.Cursor = Cursors.Hand;
            button.Font = ButtonFont;

            // Сначала отписываемся, чтобы при повторном оформлении обработчик не добавился дважды
            button.Paint -= PaintRoundedButton;
            button.Paint += PaintRoundedButton;
        }

        /// <summary>Обычная (второстепенная) кнопка: латте, тёмный текст.</summary>
        public static void StyleButton(Button button)
        {
            StyleFlat(button, Secondary, SecondaryHover, Text);
        }

        /// <summary>Главная кнопка окна («Сохранить», «Войти»): карамель, белый текст.</summary>
        public static void StylePrimaryButton(Button button)
        {
            StyleFlat(button, Accent, AccentHover, Color.White);
        }

        /// <summary>Кнопка удаления: терракота, белый текст.</summary>
        public static void StyleDangerButton(Button button)
        {
            StyleFlat(button, Danger, DangerHover, Color.White);
        }

        /// <summary>
        /// Добавляет кнопке иконку слева от текста.
        /// Иконка хранится в свойстве Tag, её рисуют обработчики Paint.
        /// </summary>
        public static void SetIcon(Button button, string icon)
        {
            button.Tag = icon;
            button.Invalidate();
        }

        /// <summary>
        /// Рисует кнопку со скруглёнными углами: фон (с учётом наведения мыши),
        /// иконку (если есть) и текст.
        /// </summary>
        private static void PaintRoundedButton(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            Graphics g = e.Graphics;

            // Цвет фона: обычный, при наведении или «бледный» для недоступной кнопки
            Color back = button.BackColor;
            Color fore = button.ForeColor;
            if (!button.Enabled)
            {
                back = Line;
                fore = TextMuted;
            }
            else if (IsMouseOver(button))
            {
                back = button.FlatAppearance.MouseOverBackColor;
            }

            // Углы кнопки закрашиваем цветом родителя, затем рисуем скруглённый фон
            g.Clear(button.Parent != null ? button.Parent.BackColor : Background);
            Rectangle rect = new Rectangle(0, 0, button.Width - 1, button.Height - 1);
            FillRounded(g, rect, 8, back);

            // Иконка + текст по центру кнопки (или от левого края, если TextAlign слева)
            string icon = button.Tag as string;
            Size textSize = TextRenderer.MeasureText(button.Text, button.Font);
            int iconWidth = icon != null ? 22 : 0;
            int contentWidth = iconWidth + textSize.Width;

            int x;
            if (button.TextAlign == ContentAlignment.MiddleLeft)
            {
                x = button.Padding.Left + 12;
            }
            else
            {
                x = (button.Width - contentWidth) / 2;
            }

            if (icon != null)
            {
                Rectangle iconRect = new Rectangle(x, 0, iconWidth, button.Height);
                TextRenderer.DrawText(g, icon, IconFont, iconRect, fore,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            }

            Rectangle textRect = new Rectangle(x + iconWidth, 0, button.Width - x - iconWidth, button.Height);
            TextRenderer.DrawText(g, button.Text, button.Font, textRect, fore,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        // ===== Плитки админ-панели =====

        /// <summary>
        /// Большая кнопка-плитка: белая карточка с тенью, круглая иконка,
        /// заголовок (Text) и описание (AccessibleDescription).
        /// При наведении рамка и иконка становятся карамельными.
        /// </summary>
        public static void StyleTileButton(Button button, string icon)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.UseVisualStyleBackColor = false;
            button.BackColor = Surface;
            button.FlatAppearance.MouseOverBackColor = Surface;
            button.FlatAppearance.MouseDownBackColor = Surface;
            button.Cursor = Cursors.Hand;
            button.Tag = icon;

            button.Paint -= PaintRoundedButton; // обычное рисование кнопки не нужно
            button.Paint -= PaintTile;
            button.Paint += PaintTile;
        }

        /// <summary>Рисует плитку админ-панели.</summary>
        private static void PaintTile(object sender, PaintEventArgs e)
        {
            Button tile = (Button)sender;
            Graphics g = e.Graphics;
            bool hover = IsMouseOver(tile);

            g.Clear(tile.Parent.BackColor);

            // Мягкая тень под карточкой и сама карточка
            Rectangle card = new Rectangle(2, 1, tile.Width - 5, tile.Height - 6);
            Rectangle shadow = card;
            shadow.Offset(0, 3);
            FillRounded(g, shadow, 14, Color.FromArgb(hover ? 40 : 20, 120, 80, 40));
            FillRounded(g, card, 14, hover ? Color.FromArgb(255, 252, 247) : Surface);
            DrawRounded(g, card, 14, hover ? Accent : Line, hover ? 1.5f : 1f);

            // Круглая иконка слева
            Rectangle circle = new Rectangle(card.X + 20, card.Y + (card.Height - 52) / 2, 52, 52);
            using (SolidBrush brush = new SolidBrush(hover ? Accent : AccentSoft))
            {
                g.FillEllipse(brush, circle);
            }
            TextRenderer.DrawText(g, tile.Tag as string, IconFontLarge, circle, hover ? Color.White : Accent,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);

            // Заголовок и описание справа от иконки
            int textX = circle.Right + 16;
            int textWidth = card.Right - textX - 12;
            Rectangle titleRect = new Rectangle(textX, card.Y + card.Height / 2 - 26, textWidth, 24);
            Rectangle descRect = new Rectangle(textX, card.Y + card.Height / 2, textWidth, 36);
            TextRenderer.DrawText(g, tile.Text, TileFont, titleRect, Text,
                TextFormatFlags.Left | TextFormatFlags.Bottom | TextFormatFlags.EndEllipsis);
            TextRenderer.DrawText(g, tile.AccessibleDescription, Regular, descRect, TextMuted,
                TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.WordBreak);
        }

        // ===== Боковое меню =====

        /// <summary>
        /// Пункт бокового меню: «таблетка» с иконкой и текстом.
        /// Активный пункт заливается карамельным цветом.
        /// </summary>
        public static void StyleSidebarButton(Button button, string icon)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.UseVisualStyleBackColor = false;
            button.BackColor = Sidebar;
            button.ForeColor = SidebarText;
            button.FlatAppearance.MouseOverBackColor = Sidebar;
            button.FlatAppearance.MouseDownBackColor = Sidebar;
            button.Cursor = Cursors.Hand;
            button.Font = SidebarFont;
            button.Tag = icon;

            button.Paint -= PaintRoundedButton;
            button.Paint -= PaintSidebarButton;
            button.Paint += PaintSidebarButton;
        }

        /// <summary>
        /// Отмечает активный пункт бокового меню.
        /// Признак «активный» — свойство ForeColor = белый; по нему рисует PaintSidebarButton.
        /// </summary>
        public static void SetActiveSidebarButton(Button[] buttons, Button active)
        {
            foreach (Button button in buttons)
            {
                button.ForeColor = button == active ? Color.White : SidebarText;
                button.Invalidate();
            }
        }

        /// <summary>Рисует пункт бокового меню.</summary>
        private static void PaintSidebarButton(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            Graphics g = e.Graphics;
            bool active = button.ForeColor == Color.White;
            bool hover = IsMouseOver(button);

            g.Clear(Sidebar);

            // «Таблетка» с отступами от краёв меню
            Rectangle pill = new Rectangle(12, 4, button.Width - 24, button.Height - 8);
            if (active)
            {
                FillRounded(g, pill, 10, Accent);
            }
            else if (hover)
            {
                FillRounded(g, pill, 10, SidebarHover);
            }

            Color textColor = active || hover ? Color.White : SidebarText;
            Color iconColor = active || hover ? Color.White : SidebarMuted;

            Rectangle iconRect = new Rectangle(pill.X + 14, pill.Y, 26, pill.Height);
            TextRenderer.DrawText(g, button.Tag as string, IconFont, iconRect, iconColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);

            Rectangle textRect = new Rectangle(pill.X + 50, pill.Y, pill.Width - 50, pill.Height);
            TextRenderer.DrawText(g, button.Text, button.Font, textRect, textColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        // ===== Поля ввода =====

        /// <summary>
        /// Поле ввода со скруглённой рамкой.
        /// Своя рамка у TextBox убирается, а скруглённую рисует родитель (PaintInputBorders).
        /// Поле в фокусе подсвечивается карамельной рамкой.
        /// </summary>
        private static void StyleTextBox(TextBox textBox)
        {
            if (textBox.BorderStyle == BorderStyle.None || textBox.Parent == null)
            {
                return; // уже оформлено
            }

            // Без рамки поле становится ниже. Сдвигаем его так, чтобы текст остался по центру
            // прежнего места, и сужаем — внутри рамки нужен отступ слева и справа.
            // (PreferredHeight — высота, которую поле примет без рамки; Height обновляется позже)
            int oldHeight = textBox.Height;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Top += (oldHeight - textBox.PreferredHeight) / 2;
            textBox.Left += 6;
            textBox.Width -= 12;
            textBox.BackColor = Surface;
            textBox.ForeColor = Text;
            RegisterInput(textBox);
        }

        /// <summary>
        /// Подключает поле ввода (TextBox, ComboBox, NumericUpDown) к рисованию
        /// скруглённых рамок: рамку рисует родитель, а при смене фокуса она перерисовывается.
        /// </summary>
        private static void RegisterInput(Control input)
        {
            if (input.Parent == null)
            {
                return;
            }

            input.Parent.Paint -= PaintInputBorders;
            input.Parent.Paint += PaintInputBorders;

            input.Enter -= InputFocusChanged;
            input.Enter += InputFocusChanged;
            input.Leave -= InputFocusChanged;
            input.Leave += InputFocusChanged;
        }

        /// <summary>Фокус поля изменился — перерисовываем рамки у родителя.</summary>
        private static void InputFocusChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (control.Parent != null)
            {
                control.Parent.Invalidate();
            }
        }

        /// <summary>
        /// Рисует скруглённые рамки вокруг всех полей ввода внутри контейнера.
        /// Поле в фокусе обводится карамельным цветом.
        /// </summary>
        private static void PaintInputBorders(object sender, PaintEventArgs e)
        {
            Control parent = (Control)sender;
            foreach (Control control in parent.Controls)
            {
                if (!control.Visible)
                {
                    continue;
                }

                // Насколько рамка шире самого поля
                Size margin;
                TextBox textBox = control as TextBox;
                if (textBox != null && textBox.BorderStyle == BorderStyle.None)
                {
                    margin = new Size(6, 5); // у поля без рамки нужен отступ для текста
                }
                else if (control is ComboBox || control is NumericUpDown)
                {
                    margin = new Size(3, 3);
                }
                else
                {
                    continue; // это не поле ввода
                }

                // ContainsFocus — фокус может быть во внутреннем поле NumericUpDown
                bool focused = control.ContainsFocus;
                Rectangle r = control.Bounds;
                r.Inflate(margin);
                FillRounded(e.Graphics, r, 7, Surface);
                DrawRounded(e.Graphics, r, 7, focused ? Accent : InputBorder, focused ? 1.6f : 1f);
            }
        }

        // ===== Карточки (группы) =====

        /// <summary>
        /// Группа (GroupBox) в виде белой карточки со скруглёнными углами
        /// и заголовком вместо стандартной серой рамки.
        /// </summary>
        public static void StyleCard(GroupBox group)
        {
            group.BackColor = Surface;
            group.ForeColor = Text;
            group.Paint -= PaintCard;
            group.Paint += PaintCard;
        }

        /// <summary>Рисует карточку поверх стандартной рамки группы.</summary>
        private static void PaintCard(object sender, PaintEventArgs e)
        {
            GroupBox group = (GroupBox)sender;
            Graphics g = e.Graphics;

            g.Clear(group.Parent.BackColor);
            Rectangle card = new Rectangle(0, 0, group.Width - 1, group.Height - 1);
            FillRounded(g, card, 12, Surface);
            DrawRounded(g, card, 12, Line, 1f);

            TextRenderer.DrawText(g, group.Text, Bold, new Point(12, 4), GridHeaderText);
        }

        // ===== Градиентная шапка (окна входа и регистрации) =====

        /// <summary>
        /// Панель-шапка с тёплым градиентом и декоративными кругами.
        /// Надписи на панели делаются прозрачными, чтобы градиент был виден под ними.
        /// </summary>
        public static void StyleGradientHeader(Panel panel)
        {
            panel.Paint -= PaintGradientHeader;
            panel.Paint += PaintGradientHeader;
            foreach (Control control in panel.Controls)
            {
                if (control is Label)
                {
                    control.BackColor = Color.Transparent;
                }
            }
        }

        /// <summary>Рисует градиент и круги шапки.</summary>
        private static void PaintGradientHeader(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Graphics g = e.Graphics;
            Rectangle r = panel.ClientRectangle;
            if (r.Width == 0 || r.Height == 0)
            {
                return;
            }

            using (LinearGradientBrush brush = new LinearGradientBrush(r,
                Sidebar, Color.FromArgb(128, 76, 42), 30f))
            {
                g.FillRectangle(brush, r);
            }

            // Полупрозрачные круги — «пар над чашкой»
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush light = new SolidBrush(Color.FromArgb(20, 255, 255, 255)))
            using (SolidBrush accent = new SolidBrush(Color.FromArgb(90, Accent)))
            {
                g.FillEllipse(light, r.Width - 110, -50, 170, 170);
                g.FillEllipse(light, -60, r.Height - 50, 130, 130);
                g.FillEllipse(accent, r.Width - 62, r.Height - 34, 44, 44);
                g.FillEllipse(accent, 26, 18, 14, 14);
            }
        }

        // ===== Аватар =====

        /// <summary>
        /// Рисует круглый аватар с инициалами (например, «ИИ» для «Иванов Иван»).
        /// </summary>
        public static void DrawAvatar(Graphics g, Rectangle r, string fullName)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (LinearGradientBrush brush = new LinearGradientBrush(r, Accent, AccentHover, 45f))
            {
                g.FillEllipse(brush, r);
            }
            TextRenderer.DrawText(g, GetInitials(fullName), Bold, r, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
        }

        /// <summary>Первые буквы первых двух слов ФИО в верхнем регистре.</summary>
        public static string GetInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return "?";
            }

            string[] words = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string initials = words[0].Substring(0, 1);
            if (words.Length > 1)
            {
                initials += words[1].Substring(0, 1);
            }
            return initials.ToUpper();
        }

        // ===== Подписи =====

        /// <summary>Заголовок раздела: крупный жирный тёмный текст.</summary>
        public static void StyleHeader(Label label)
        {
            label.Font = Header;
            label.ForeColor = Text;
        }

        /// <summary>Подсказка: приглушённый текст.</summary>
        public static void StyleMuted(Label label)
        {
            label.ForeColor = TextMuted;
        }

        // ===== Таблицы =====

        /// <summary>
        /// Оформляет таблицу: без лишних линий, цветная шапка,
        /// чередование цвета строк, выделение строки целиком,
        /// столбцы растянуты по ширине таблицы.
        /// Вызывать до заполнения таблицы строками.
        /// </summary>
        public static void StyleGrid(DataGridView grid)
        {
            grid.BorderStyle = BorderStyle.None;
            grid.BackgroundColor = Surface;
            grid.GridColor = Line;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // только линии между строками
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AllowUserToResizeRows = false;
            grid.RowTemplate.Height = 36;

            // Шапка: без системного стиля Windows, иначе наши цвета не применятся
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 40;
            grid.ColumnHeadersDefaultCellStyle.BackColor = GridHeader;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = GridHeaderText;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = GridHeader; // шапка не «подсвечивается»
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = GridHeaderText;
            grid.ColumnHeadersDefaultCellStyle.Font = Bold;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

            // Обычные и чередующиеся строки
            grid.DefaultCellStyle.BackColor = Surface;
            grid.DefaultCellStyle.ForeColor = Text;
            grid.DefaultCellStyle.SelectionBackColor = GridSelection;
            grid.DefaultCellStyle.SelectionForeColor = Text;
            grid.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            grid.AlternatingRowsDefaultCellStyle.BackColor = GridAlternate;

            // Растягиваем столбцы по ширине таблицы.
            // Чтобы узкие столбцы (например, «Стол») остались узкими,
            // доля ширины (FillWeight) берётся из ширины, заданной в конструкторе формы.
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (column.AutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
                {
                    column.FillWeight = 220; // главный столбец (название) — самый широкий
                }
                else
                {
                    column.FillWeight = column.Width;
                }
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet; // берётся из таблицы
            }
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ===== Цветные плашки статусов =====

        /// <summary>
        /// Цвета плашки для статуса заказа: фон и текст.
        /// Новый — синий, Готовится — янтарный, Готов — зелёный, Оплачен — серо-коричневый.
        /// </summary>
        public static void GetStatusColors(OrderStatus status, out Color back, out Color fore)
        {
            switch (status)
            {
                case OrderStatus.Новый:
                    back = Color.FromArgb(225, 237, 252);
                    fore = Color.FromArgb(41, 98, 168);
                    break;
                case OrderStatus.Готовится:
                    back = Color.FromArgb(255, 239, 207);
                    fore = Color.FromArgb(176, 106, 12);
                    break;
                case OrderStatus.Готов:
                    back = Color.FromArgb(222, 243, 226);
                    fore = Color.FromArgb(38, 125, 60);
                    break;
                default: // Оплачен
                    back = Color.FromArgb(236, 230, 224);
                    fore = Color.FromArgb(110, 92, 78);
                    break;
            }
        }

        /// <summary>
        /// Включает цветные плашки статусов в столбце таблицы.
        /// Ячейка рисуется вручную в событии CellPainting.
        /// </summary>
        public static void EnableStatusBadges(DataGridView grid, DataGridViewColumn statusColumn)
        {
            statusColumn.Tag = "status"; // метка: в этом столбце рисуем плашки
            grid.CellPainting -= PaintStatusCell;
            grid.CellPainting += PaintStatusCell;
        }

        /// <summary>Рисует ячейку статуса как цветную «таблетку» с текстом.</summary>
        private static void PaintStatusCell(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || !"status".Equals(grid.Columns[e.ColumnIndex].Tag))
            {
                return; // шапку и другие столбцы рисует сама таблица
            }

            OrderStatus status;
            string text = Convert.ToString(e.Value);
            if (!Enum.TryParse(text, out status))
            {
                return;
            }

            // Всё, кроме текста (фон, выделение, линии), рисует сама таблица
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            Color back;
            Color fore;
            GetStatusColors(status, out back, out fore);

            Size textSize = TextRenderer.MeasureText(text, Bold);
            Rectangle badge = new Rectangle(
                e.CellBounds.X + 8,
                e.CellBounds.Y + (e.CellBounds.Height - 24) / 2,
                textSize.Width + 16,
                24);
            FillRounded(e.Graphics, badge, 12, back);
            TextRenderer.DrawText(e.Graphics, text, Bold, badge, fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            e.Handled = true; // ячейка нарисована, стандартное рисование не нужно
        }
    }
}
