using System.Xml.Serialization;

namespace Muhammed.Models
{
    /// <summary>
    /// Одна позиция заказа: какое блюдо и сколько штук.
    /// Название и цена копируются из меню в момент добавления,
    /// поэтому если позже изменить блюдо в меню, старые заказы не изменятся.
    /// </summary>
    public class OrderItem
    {
        /// <summary>Номер блюда из меню (Dish.Id).</summary>
        public int DishId { get; set; }

        /// <summary>Название блюда (копия на момент заказа).</summary>
        public string DishName { get; set; }

        /// <summary>Цена за одну штуку (копия на момент заказа).</summary>
        public decimal Price { get; set; }

        /// <summary>Количество порций.</summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Сумма по позиции = цена × количество.
        /// Считается автоматически, в файл не сохраняется ([XmlIgnore]).
        /// </summary>
        [XmlIgnore]
        public decimal Sum
        {
            get { return Price * Quantity; }
        }

        /// <summary>Пустой конструктор (нужен XmlSerializer).</summary>
        public OrderItem()
        {
            DishName = "";
        }

        /// <summary>
        /// Создаёт позицию заказа из блюда меню.
        /// </summary>
        /// <param name="dish">Блюдо из меню.</param>
        /// <param name="quantity">Количество порций.</param>
        public OrderItem(Dish dish, int quantity)
        {
            DishId = dish.Id;
            DishName = dish.Name;
            Price = dish.Price;
            Quantity = quantity;
        }
    }
}
