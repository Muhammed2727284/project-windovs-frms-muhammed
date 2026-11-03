using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Muhammed.Models;
using Muhammed.Services;
using Muhammed.UI;

namespace Muhammed.Forms
{
    /// <summary>
    /// Окно «Блюда» (админ-панель): список блюд, добавление, изменение и удаление.
    /// </summary>
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();

            // Единое оформление: цвета и шрифты берутся из класса Theme
            Theme.ApplyToForm(this);
            Theme.StylePrimaryButton(btnAdd);
            Theme.SetIcon(btnAdd, Theme.IconAdd);
            Theme.SetIcon(btnEdit, Theme.IconEdit);
            Theme.StyleDangerButton(btnDelete);
            Theme.SetIcon(btnDelete, Theme.IconDelete);

            RefreshDishes();
        }

        /// <summary>
        /// Заново заполняет таблицу блюдами из DataService.Dishes.
        /// Блюда сортируются по категории, а внутри категории — по названию.
        /// </summary>
        /// <param name="selectId">Номер блюда, которое нужно выделить после обновления (0 — не выделять).</param>
        private void RefreshDishes(int selectId = 0)
        {
            List<Dish> sorted = new List<Dish>(DataService.Dishes);
            sorted.Sort(CompareDishes);

            dgvDishes.Rows.Clear();
            foreach (Dish dish in sorted)
            {
                int rowIndex = dgvDishes.Rows.Add(dish.Id, dish.Name, dish.Category, dish.Price.ToString("N2"));
                if (dish.Id == selectId)
                {
                    dgvDishes.CurrentCell = dgvDishes.Rows[rowIndex].Cells[colDishName.Index];
                }
            }

            // Если ничего выделять не нужно — снимаем выделение
            if (selectId == 0)
            {
                dgvDishes.CurrentCell = null;
            }

            lblCount.Text = "Блюд в меню: " + DataService.Dishes.Count;
        }

        /// <summary>
        /// Защита: менять меню может только администратор,
        /// даже если окно откроют не из админ-панели.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("Изменять меню может только администратор.", "Нет доступа",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
        }

        /// <summary>
        /// При открытии окна таблица сама выделяет первую строку.
        /// Снимаем это выделение, чтобы пользователь выбрал блюдо сам.
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            dgvDishes.CurrentCell = null;
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

        /// <summary>
        /// Возвращает блюдо из выделенной строки таблицы.
        /// Если ничего не выделено — показывает сообщение и возвращает null.
        /// </summary>
        private Dish GetSelectedDish()
        {
            if (dgvDishes.CurrentRow == null)
            {
                MessageBox.Show("Выберите блюдо в таблице.", "Меню",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            int id = Convert.ToInt32(dgvDishes.CurrentRow.Cells[colDishId.Index].Value);
            return DataService.FindDish(id);
        }

        /// <summary>Кнопка «Добавить»: открывает пустую форму блюда.</summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (DishEditForm form = new DishEditForm(null))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    DataService.Dishes.Add(form.Result);
                    DataService.SaveMenu();
                    RefreshDishes(form.Result.Id);
                }
            }
        }

        /// <summary>Кнопка «Изменить»: открывает форму с данными выбранного блюда.</summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSelectedDish();
        }

        /// <summary>Двойной клик по строке — то же самое, что «Изменить».</summary>
        private void dgvDishes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // -1 — это клик по заголовку столбца
            {
                EditSelectedDish();
            }
        }

        /// <summary>Открывает форму изменения для выделенного блюда.</summary>
        private void EditSelectedDish()
        {
            Dish dish = GetSelectedDish();
            if (dish == null)
            {
                return;
            }

            using (DishEditForm form = new DishEditForm(dish))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    // Форма уже изменила объект dish, осталось сохранить файл
                    DataService.SaveMenu();
                    RefreshDishes(dish.Id);
                }
            }
        }

        /// <summary>Кнопка «Удалить»: удаляет выбранное блюдо после подтверждения.</summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Dish dish = GetSelectedDish();
            if (dish == null)
            {
                return;
            }

            DialogResult answer = MessageBox.Show(
                "Удалить блюдо «" + dish.Name + "» из меню?\n\n" +
                "Уже созданные заказы не изменятся.",
                "Удаление блюда",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                DataService.Dishes.Remove(dish);
                DataService.SaveMenu();
                RefreshDishes();
            }
        }
    }
}
