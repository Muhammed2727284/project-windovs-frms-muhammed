using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Muhammed.Models;
using Muhammed.Services;
using Muhammed.UI;

namespace Muhammed.Forms
{
    /// <summary>
    /// Окно создания и редактирования заказа.
    /// Если в конструктор передан null — создаётся новый заказ,
    /// иначе редактируется переданный.
    /// </summary>
    public partial class OrderForm : Form
    {
        /// <summary>Заказ, который редактируем (null — если создаём новый).</summary>
        private Order editingOrder;

        /// <summary>
        /// Позиции заказа, с которыми работает окно.
        /// Это копия: если нажать «Отмена», настоящий заказ не изменится.
        /// </summary>
        private List<OrderItem> items = new List<OrderItem>();

        public OrderForm(Order order)
        {
            InitializeComponent();
            editingOrder = order;

            // Единое оформление: цвета и шрифты берутся из класса Theme
            Theme.ApplyToForm(this);
            Theme.StylePrimaryButton(btnSaveOrder);
            Theme.StylePrimaryButton(btnAddItem);
            Theme.SetIcon(btnAddItem, Theme.IconAdd);
            Theme.SetIcon(btnSaveOrder, Theme.IconCheck);
            Theme.SetIcon(btnRemoveItem, Theme.IconDelete);
            Theme.StyleMuted(lblHint);
            lblTotal.ForeColor = Theme.Accent;

            // Заполняем выпадающий список блюдами из меню
            foreach (Dish dish in DataService.Dishes)
            {
                cmbDish.Items.Add(dish);
            }
            if (cmbDish.Items.Count > 0)
            {
                cmbDish.SelectedIndex = 0;
            }

            if (editingOrder == null)
            {
                Text = "Новый заказ";
                lblOrderInfo.Text = "Новый заказ";
            }
            else
            {
                Text = "Заказ №" + editingOrder.Id;
                lblOrderInfo.Text = "Заказ №" + editingOrder.Id +
                    " от " + editingOrder.CreatedAt.ToString("dd.MM.yyyy HH:mm") +
                    ", статус: " + editingOrder.Status;
                numTable.Value = editingOrder.TableNumber;

                // Копируем позиции, чтобы не менять заказ до нажатия «Сохранить»
                foreach (OrderItem item in editingOrder.Items)
                {
                    OrderItem copy = new OrderItem();
                    copy.DishId = item.DishId;
                    copy.DishName = item.DishName;
                    copy.Price = item.Price;
                    copy.Quantity = item.Quantity;
                    items.Add(copy);
                }
            }

            RefreshItems();
        }

        /// <summary>
        /// Заново заполняет таблицу позиций и пересчитывает итог.
        /// </summary>
        private void RefreshItems()
        {
            dgvItems.Rows.Clear();
            foreach (OrderItem item in items)
            {
                dgvItems.Rows.Add(item.DishName, item.Price.ToString("N2"), item.Quantity, item.Sum.ToString("N2"));
            }
            UpdateTotal();
        }

        /// <summary>Считает итоговую сумму заказа и показывает её внизу окна.</summary>
        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (OrderItem item in items)
            {
                total += item.Sum;
            }
            lblTotal.Text = "Итого: " + total.ToString("N2") + " ₽";
        }

        /// <summary>
        /// Кнопка «Добавить»: добавляет выбранное блюдо в заказ.
        /// Если это блюдо уже есть в заказе — увеличивает его количество.
        /// </summary>
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbDish.Items.Count == 0)
            {
                ShowError("Меню пустое. Сначала добавьте блюда в меню.");
                return;
            }

            Dish dish = cmbDish.SelectedItem as Dish;
            if (dish == null)
            {
                ShowError("Выберите блюдо.");
                return;
            }

            int quantity = (int)numQuantity.Value;
            if (quantity < 1 || quantity > 99)
            {
                ShowError("Количество должно быть от 1 до 99.");
                return;
            }

            // Ищем такое же блюдо (тот же номер и та же цена) среди уже добавленных
            OrderItem existing = null;
            foreach (OrderItem item in items)
            {
                if (item.DishId == dish.Id && item.Price == dish.Price)
                {
                    existing = item;
                    break;
                }
            }

            if (existing != null)
            {
                if (existing.Quantity + quantity > 99)
                {
                    ShowError("Нельзя заказать больше 99 порций одного блюда.");
                    return;
                }
                existing.Quantity += quantity;
            }
            else
            {
                items.Add(new OrderItem(dish, quantity));
            }

            RefreshItems();
            numQuantity.Value = 1; // сбрасываем количество для следующего блюда
        }

        /// <summary>Кнопка «Убрать позицию»: удаляет выделенную строку из заказа.</summary>
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvItems.CurrentRow == null)
            {
                ShowError("Выберите позицию, которую нужно убрать.");
                return;
            }

            items.RemoveAt(dgvItems.CurrentRow.Index);
            RefreshItems();
        }

        /// <summary>
        /// Проверка количества, которое пользователь ввёл прямо в таблице.
        /// Если ввод неверный — показываем сообщение и не даём уйти из ячейки (e.Cancel = true).
        /// </summary>
        private void dgvItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Проверяем только столбец «Количество» и только если его сейчас редактируют
            if (e.ColumnIndex != colItemQuantity.Index || !dgvItems.IsCurrentCellInEditMode)
            {
                return;
            }

            int quantity;
            if (!int.TryParse(Convert.ToString(e.FormattedValue), out quantity) || quantity < 1 || quantity > 99)
            {
                ShowError("Количество должно быть целым числом от 1 до 99.");
                e.Cancel = true;
            }
        }

        /// <summary>
        /// После изменения количества в таблице обновляем позицию, её сумму и итог.
        /// (Rows.Clear() здесь вызывать нельзя, поэтому меняем только одну строку.)
        /// </summary>
        private void dgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != colItemQuantity.Index)
            {
                return;
            }

            DataGridViewRow row = dgvItems.Rows[e.RowIndex];
            OrderItem item = items[e.RowIndex];
            item.Quantity = int.Parse(Convert.ToString(row.Cells[colItemQuantity.Index].Value));
            row.Cells[colItemSum.Index].Value = item.Sum.ToString("N2");
            UpdateTotal();
        }

        /// <summary>
        /// Кнопка «Сохранить заказ»: проверяет ввод и сохраняет заказ в файл.
        /// </summary>
        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            int table = (int)numTable.Value;
            if (table < 1)
            {
                ShowError("Укажите номер стола (число больше 0).");
                numTable.Focus();
                return;
            }

            if (items.Count == 0)
            {
                ShowError("Добавьте в заказ хотя бы одно блюдо.");
                return;
            }

            foreach (OrderItem item in items)
            {
                if (item.Quantity < 1 || item.Quantity > 99)
                {
                    ShowError("У блюда «" + item.DishName + "» неверное количество (нужно от 1 до 99).");
                    return;
                }
            }

            if (editingOrder == null)
            {
                // Новый заказ: следующий номер, статус «Новый», текущее время (ставится в конструкторе Order)
                Order order = new Order();
                order.Id = DataService.NextOrderId();
                order.TableNumber = table;
                order.Items = items;
                DataService.Orders.Add(order);
            }
            else
            {
                // Существующий заказ: номер, дата и статус остаются прежними
                editingOrder.TableNumber = table;
                editingOrder.Items = items;
            }

            DataService.SaveOrders();
            DialogResult = DialogResult.OK; // форма закроется сама
        }

        /// <summary>Показывает сообщение об ошибке ввода.</summary>
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
