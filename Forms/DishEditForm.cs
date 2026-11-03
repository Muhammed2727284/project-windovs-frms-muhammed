using System;
using System.Globalization;
using System.Windows.Forms;
using Muhammed.Models;
using Muhammed.Services;

namespace Muhammed.Forms
{
    /// <summary>
    /// Окно добавления и изменения блюда.
    /// Если в конструктор передан null — добавляется новое блюдо,
    /// иначе редактируется переданное.
    /// </summary>
    public partial class DishEditForm : Form
    {
        /// <summary>Блюдо, которое редактируем (null — если добавляем новое).</summary>
        private Dish editingDish;

        /// <summary>
        /// Результат: новое или изменённое блюдо.
        /// Заполняется, только если пользователь нажал «Сохранить» и ввод верный.
        /// </summary>
        public Dish Result { get; private set; }

        public DishEditForm(Dish dish)
        {
            InitializeComponent();
            editingDish = dish;

            // В список категорий кладём все категории, которые уже есть в меню.
            // Можно выбрать готовую или вписать новую.
            foreach (Dish d in DataService.Dishes)
            {
                if (!cmbCategory.Items.Contains(d.Category))
                {
                    cmbCategory.Items.Add(d.Category);
                }
            }

            if (editingDish == null)
            {
                Text = "Новое блюдо";
            }
            else
            {
                Text = "Изменение блюда";
                txtName.Text = editingDish.Name;
                cmbCategory.Text = editingDish.Category;
                txtPrice.Text = editingDish.Price.ToString("0.##");
            }
        }

        /// <summary>
        /// Кнопка «Сохранить»: проверяем ввод, и если всё верно — закрываем окно с результатом OK.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string category = cmbCategory.Text.Trim();

            // 1. Название не пустое
            if (name == "")
            {
                ShowError("Введите название блюда.");
                txtName.Focus();
                return;
            }

            // 2. Нет другого блюда с таким же названием
            foreach (Dish d in DataService.Dishes)
            {
                if (d != editingDish && string.Equals(d.Name, name, StringComparison.CurrentCultureIgnoreCase))
                {
                    ShowError("Блюдо «" + name + "» уже есть в меню.");
                    txtName.Focus();
                    return;
                }
            }

            // 3. Категория не пустая
            if (category == "")
            {
                ShowError("Введите или выберите категорию.");
                cmbCategory.Focus();
                return;
            }

            // 4. Цена — число больше 0
            decimal price;
            if (!TryParsePrice(txtPrice.Text, out price))
            {
                ShowError("Цена должна быть числом, например 250 или 99,50.");
                txtPrice.Focus();
                return;
            }
            if (price <= 0)
            {
                ShowError("Цена должна быть больше нуля.");
                txtPrice.Focus();
                return;
            }
            if (price > 100000)
            {
                ShowError("Цена слишком большая (максимум 100 000 ₽).");
                txtPrice.Focus();
                return;
            }

            // Всё верно — создаём новое блюдо или меняем старое
            if (editingDish == null)
            {
                Result = new Dish();
                Result.Id = DataService.NextDishId();
            }
            else
            {
                Result = editingDish;
            }
            Result.Name = name;
            Result.Category = category;
            Result.Price = Math.Round(price, 2);

            DialogResult = DialogResult.OK; // форма закроется сама
        }

        /// <summary>
        /// Превращает текст в цену. Подходят и запятая, и точка: «99,5» и «99.5».
        /// Возвращает false, если это не число.
        /// </summary>
        private static bool TryParsePrice(string text, out decimal price)
        {
            string normalized = text.Trim().Replace(',', '.');
            return decimal.TryParse(normalized, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture, out price);
        }

        /// <summary>Показывает сообщение об ошибке ввода.</summary>
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
