using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Muhammed.Models;
using Muhammed.Services;
using Muhammed.UI;

namespace Muhammed.Forms
{
    /// <summary>
    /// Страница «Заказы» главного окна: таблица заказов, фильтр, поиск,
    /// смена статуса, создание, открытие и удаление заказа.
    /// Раньше всё это было на главной форме; логика перенесена без изменений.
    /// Удалять заказы может только администратор.
    /// </summary>
    public partial class OrdersPage : UserControl
    {
        /// <summary>Текст пункта «все статусы» в фильтре.</summary>
        private const string AllStatuses = "Все";

        /// <summary>
        /// Флаг «сейчас идёт заполнение формы».
        /// Пока он true, обработчики событий не обновляют таблицу лишний раз.
        /// </summary>
        private bool isLoading = true;

        public OrdersPage()
        {
            InitializeComponent();

            // Единое оформление: цвета и шрифты берутся из класса Theme
            Theme.ApplyToPage(this);
            Theme.StyleHeader(lblTitle);
            Theme.StylePrimaryButton(btnNewOrder);
            Theme.StyleDangerButton(btnDeleteOrder);
            Theme.StylePrimaryButton(btnChangeStatus);
            Theme.StyleMuted(lblCount);
            Theme.SetIcon(btnNewOrder, Theme.IconAdd);
            Theme.SetIcon(btnOpenOrder, Theme.IconEdit);
            Theme.SetIcon(btnDeleteOrder, Theme.IconDelete);
            Theme.SetIcon(btnSearch, Theme.IconSearch);
            Theme.SetIcon(btnChangeStatus, Theme.IconCheck);

            // Статус в таблице показываем цветной плашкой
            Theme.EnableStatusBadges(dgvOrders, colStatus);

            // Удаление заказа — только для администратора
            btnDeleteOrder.Visible = CurrentUser.IsAdmin;

            // Фильтр: «Все» + все статусы
            cmbFilter.Items.Add(AllStatuses);
            // Список «Новый статус»: все статусы
            foreach (OrderStatus status in Enum.GetValues(typeof(OrderStatus)))
            {
                cmbFilter.Items.Add(status);
                cmbNewStatus.Items.Add(status);
            }
            cmbFilter.SelectedIndex = 0;
            cmbNewStatus.SelectedIndex = 0;

            isLoading = false;
            RefreshOrders();
        }

        /// <summary>
        /// Заново заполняет таблицу заказов с учётом фильтра и поиска.
        /// </summary>
        /// <param name="selectId">Номер заказа, который нужно выделить после обновления (0 — первый).</param>
        public void RefreshOrders(int selectId = 0)
        {
            // 1. Читаем фильтр по статусу
            OrderStatus? status = null;
            if (cmbFilter.SelectedItem is OrderStatus)
            {
                status = (OrderStatus)cmbFilter.SelectedItem;
            }

            // 2. Читаем номер стола для поиска (пустое поле — все столы)
            int? table = null;
            string tableText = txtSearchTable.Text.Trim();
            if (tableText != "")
            {
                int number;
                if (!int.TryParse(tableText, out number) || number < 1)
                {
                    MessageBox.Show("Номер стола должен быть числом больше 0.", "Поиск",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSearchTable.Focus();
                    txtSearchTable.SelectAll();
                    return;
                }
                table = number;
            }

            // 3. Получаем подходящие заказы и выводим их в таблицу
            List<Order> orders = OrderService.Filter(DataService.Orders, status, table);

            dgvOrders.Rows.Clear();
            foreach (Order order in orders)
            {
                int rowIndex = dgvOrders.Rows.Add(
                    order.Id,
                    order.CreatedAt.ToString("dd.MM.yyyy HH:mm"),
                    order.TableNumber,
                    order.Status.ToString(),
                    order.Total.ToString("N2"));

                if (order.Id == selectId)
                {
                    dgvOrders.CurrentCell = dgvOrders.Rows[rowIndex].Cells[colId.Index];
                }
            }

            lblCount.Text = "Показано заказов: " + orders.Count + " из " + DataService.Orders.Count;
        }

        /// <summary>
        /// Возвращает заказ из выделенной строки.
        /// Если ничего не выделено — показывает сообщение и возвращает null.
        /// </summary>
        private Order GetSelectedOrder()
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("Выберите заказ в таблице.", "Заказы",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            int id = Convert.ToInt32(dgvOrders.CurrentRow.Cells[colId.Index].Value);
            return DataService.FindOrder(id);
        }

        // ===== Кнопки над таблицей =====

        /// <summary>
        /// Создание нового заказа. Публичный, потому что его вызывает
        /// и пункт бокового меню «Новый заказ» на главной форме.
        /// </summary>
        public void NewOrder()
        {
            if (DataService.Dishes.Count == 0)
            {
                string hint = CurrentUser.IsAdmin
                    ? "Сначала добавьте блюда: «Админ-панель» → «Блюда»."
                    : "Обратитесь к администратору, чтобы он добавил блюда.";
                MessageBox.Show("Меню пустое. " + hint, "Новый заказ",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (OrderForm form = new OrderForm(null))
            {
                if (form.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    RefreshOrders(DataService.NextOrderId() - 1); // выделяем только что созданный заказ
                }
            }
        }

        /// <summary>«Новый заказ»: открывает пустую форму заказа.</summary>
        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            NewOrder();
        }

        /// <summary>«Открыть»: открывает выбранный заказ для изменения.</summary>
        private void btnOpenOrder_Click(object sender, EventArgs e)
        {
            OpenSelectedOrder();
        }

        /// <summary>Двойной клик по строке — то же самое, что «Открыть».</summary>
        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // -1 — это клик по заголовку столбца
            {
                OpenSelectedOrder();
            }
        }

        /// <summary>Открывает форму заказа для выделенной строки.</summary>
        private void OpenSelectedOrder()
        {
            Order order = GetSelectedOrder();
            if (order == null)
            {
                return;
            }

            using (OrderForm form = new OrderForm(order))
            {
                if (form.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    RefreshOrders(order.Id);
                }
            }
        }

        /// <summary>«Удалить»: удаляет выбранный заказ после подтверждения (только администратор).</summary>
        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            // Кнопка у сотрудника скрыта, но проверяем права ещё раз — на всякий случай
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("Удалять заказы может только администратор.", "Нет доступа",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Order order = GetSelectedOrder();
            if (order == null)
            {
                return;
            }

            DialogResult answer = MessageBox.Show(
                "Удалить заказ №" + order.Id + " (стол " + order.TableNumber + ")?",
                "Удаление заказа",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                DataService.Orders.Remove(order);
                DataService.SaveOrders();
                RefreshOrders();
            }
        }

        // ===== Поиск и фильтр =====

        /// <summary>Смена фильтра по статусу — сразу обновляем таблицу.</summary>
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                RefreshOrders();
            }
        }

        /// <summary>«Найти»: применяем поиск по столу.</summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshOrders();
        }

        /// <summary>
        /// Enter в поле «Номер стола» — то же, что «Найти».
        /// (У страницы нет AcceptButton, как у формы, поэтому ловим клавишу сами.)
        /// </summary>
        private void txtSearchTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // без системного «бип»
                RefreshOrders();
            }
        }

        /// <summary>«Сбросить»: очищаем фильтр и поиск, показываем все заказы.</summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            isLoading = true; // чтобы смена фильтра не обновляла таблицу дважды
            cmbFilter.SelectedIndex = 0;
            txtSearchTable.Text = "";
            isLoading = false;
            RefreshOrders();
        }

        // ===== Статус заказа =====

        /// <summary>
        /// При выборе другой строки показываем её текущий статус в списке «Новый статус».
        /// </summary>
        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null)
            {
                return;
            }

            int id = Convert.ToInt32(dgvOrders.CurrentRow.Cells[colId.Index].Value);
            Order order = DataService.FindOrder(id);
            if (order != null)
            {
                cmbNewStatus.SelectedItem = order.Status;
            }
        }

        /// <summary>«Изменить статус»: ставит выбранному заказу новый статус.</summary>
        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            Order order = GetSelectedOrder();
            if (order == null)
            {
                return;
            }

            OrderStatus newStatus = (OrderStatus)cmbNewStatus.SelectedItem;
            if (order.Status == newStatus)
            {
                MessageBox.Show("У заказа №" + order.Id + " уже статус «" + newStatus + "».", "Статус",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            order.Status = newStatus;
            DataService.SaveOrders();
            RefreshOrders(order.Id);
        }
    }
}
