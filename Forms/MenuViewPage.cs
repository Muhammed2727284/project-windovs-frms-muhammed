using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Muhammed.Models;
using Muhammed.Services;
using Muhammed.UI;

namespace Muhammed.Forms
{
    /// <summary>
    /// Страница «Меню кафе»: просмотр блюд с фильтром по категории.
    /// Доступна всем. Редактировать здесь ничего нельзя —
    /// блюда меняются в «Админ-панель» → «Блюда».
    /// </summary>
    public partial class MenuViewPage : UserControl
    {
        /// <summary>Текст пункта «все категории» в фильтре.</summary>
        private const string AllCategories = "Все категории";

        public MenuViewPage()
        {
            InitializeComponent();

            // Единое оформление: цвета и шрифты берутся из класса Theme
            Theme.ApplyToPage(this);
            Theme.StyleHeader(lblTitle);
            Theme.StyleMuted(lblCount);
            Theme.StyleMuted(lblHint);

            lblHint.Text = CurrentUser.IsAdmin
                ? "Изменить меню можно в разделе «Админ-панель» → «Блюда»."
                : "Изменить меню может только администратор.";

            // Фильтр: «Все категории» + все категории, которые есть в меню (без повторов)
            cmbCategory.Items.Add(AllCategories);
            List<string> categories = new List<string>();
            foreach (Dish dish in DataService.Dishes)
            {
                if (!categories.Contains(dish.Category))
                {
                    categories.Add(dish.Category);
                }
            }
            categories.Sort();
            foreach (string category in categories)
            {
                cmbCategory.Items.Add(category);
            }
            cmbCategory.SelectedIndex = 0; // вызовет RefreshDishes() через SelectedIndexChanged
        }

        /// <summary>
        /// Заполняет таблицу блюдами выбранной категории.
        /// Сортировка: по категории, внутри категории — по названию.
        /// </summary>
        private void RefreshDishes()
        {
            string category = cmbCategory.SelectedItem as string;
            bool all = category == null || category == AllCategories;

            List<Dish> dishes = new List<Dish>();
            foreach (Dish dish in DataService.Dishes)
            {
                if (all || dish.Category == category)
                {
                    dishes.Add(dish);
                }
            }
            dishes.Sort(CompareDishes);

            dgvDishes.Rows.Clear();
            foreach (Dish dish in dishes)
            {
                dgvDishes.Rows.Add(dish.Name, dish.Category, dish.Price.ToString("N2"));
            }
            dgvDishes.CurrentCell = null; // ничего не выделяем: это просто просмотр

            lblCount.Text = "Показано блюд: " + dishes.Count + " из " + DataService.Dishes.Count;
        }

        /// <summary>Правило сортировки: сначала по категории, потом по названию.</summary>
        private static int CompareDishes(Dish a, Dish b)
        {
            int result = string.Compare(a.Category, b.Category, StringComparison.CurrentCulture);
            if (result == 0)
            {
                result = string.Compare(a.Name, b.Name, StringComparison.CurrentCulture);
            }
            return result;
        }

        /// <summary>Смена категории — сразу обновляем таблицу.</summary>
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDishes();
        }
    }
}
