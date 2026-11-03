using System.Collections.Generic;
using Muhammed.Models;

namespace Muhammed.Services
{
    /// <summary>
    /// Логика работы со списком заказов: фильтр по статусу и поиск по столу.
    /// </summary>
    public static class OrderService
    {
        /// <summary>
        /// Возвращает заказы, подходящие под условия, — новые сверху.
        /// </summary>
        /// <param name="orders">Все заказы.</param>
        /// <param name="status">Нужный статус или null — «все статусы».</param>
        /// <param name="tableNumber">Нужный стол или null — «все столы».</param>
        public static List<Order> Filter(List<Order> orders, OrderStatus? status, int? tableNumber)
        {
            List<Order> result = new List<Order>();

            foreach (Order order in orders)
            {
                // Если статус задан и не совпадает — заказ пропускаем
                if (status != null && order.Status != status.Value)
                {
                    continue;
                }

                // Если стол задан и не совпадает — заказ пропускаем
                if (tableNumber != null && order.TableNumber != tableNumber.Value)
                {
                    continue;
                }

                result.Add(order);
            }

            // Сортировка по номеру заказа: от большего к меньшему (новые сверху)
            result.Sort(delegate (Order a, Order b) { return b.Id.CompareTo(a.Id); });
            return result;
        }
    }
}
