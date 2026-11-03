using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Muhammed.Models
{
    /// <summary>
    /// Заказ: стол, время, статус и список блюд.
    /// </summary>
    public class Order
    {
        /// <summary>Номер заказа (уникальный, растёт по порядку).</summary>
        public int Id { get; set; }

        /// <summary>Дата и время создания заказа.</summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>Номер стола.</summary>
        public int TableNumber { get; set; }

        /// <summary>Текущий статус заказа.</summary>
        public OrderStatus Status { get; set; }

        /// <summary>Позиции заказа (блюда и количество).</summary>
        public List<OrderItem> Items { get; set; }

        /// <summary>
        /// Итоговая сумма заказа = сумма всех позиций.
        /// Считается автоматически, в файл не сохраняется ([XmlIgnore]).
        /// </summary>
        [XmlIgnore]
        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (OrderItem item in Items)
                {
                    total += item.Sum;
                }
                return total;
            }
        }

        /// <summary>
        /// Пустой конструктор (нужен XmlSerializer).
        /// Новый заказ по умолчанию: статус «Новый», текущее время, пустой список блюд.
        /// </summary>
        public Order()
        {
            CreatedAt = DateTime.Now;
            Status = OrderStatus.Новый;
            Items = new List<OrderItem>();
        }
    }
}
