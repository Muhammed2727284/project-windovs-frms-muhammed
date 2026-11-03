namespace Muhammed.Models
{
    /// <summary>
    /// Блюдо из меню кафе.
    /// Класс должен иметь публичный конструктор без параметров
    /// и публичные свойства с get/set — это нужно для XmlSerializer.
    /// </summary>
    public class Dish
    {
        /// <summary>Уникальный номер блюда.</summary>
        public int Id { get; set; }

        /// <summary>Название блюда, например «Борщ».</summary>
        public string Name { get; set; }

        /// <summary>Категория блюда, например «Супы».</summary>
        public string Category { get; set; }

        /// <summary>Цена в рублях. Тип decimal — для денег он точнее, чем double.</summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Пустой конструктор (нужен XmlSerializer).
        /// Строки сразу делаем пустыми, чтобы не было null.
        /// </summary>
        public Dish()
        {
            Name = "";
            Category = "";
        }

        /// <summary>
        /// Текст блюда для выпадающих списков, например «Борщ (Супы) — 250,00 ₽».
        /// ComboBox сам вызывает ToString(), чтобы показать объект.
        /// </summary>
        public override string ToString()
        {
            return Name + " (" + Category + ") — " + Price.ToString("N2") + " ₽";
        }
    }
}
