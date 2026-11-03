using System;

namespace Muhammed.Models
{
    /// <summary>
    /// Итоги за один день: сколько заказов и сколько денег получено.
    /// Заполняется в ReportService.BuildDailyReport().
    /// </summary>
    public class DailyReport
    {
        /// <summary>День, за который сделан отчёт.</summary>
        public DateTime Date { get; set; }

        /// <summary>Всего заказов за день (с любым статусом).</summary>
        public int TotalOrders { get; set; }

        /// <summary>Выручка: сумма только оплаченных заказов.</summary>
        public decimal Revenue { get; set; }

        /// <summary>Количество заказов со статусом «Новый».</summary>
        public int NewCount { get; set; }

        /// <summary>Количество заказов со статусом «Готовится».</summary>
        public int CookingCount { get; set; }

        /// <summary>Количество заказов со статусом «Готов».</summary>
        public int ReadyCount { get; set; }

        /// <summary>Количество заказов со статусом «Оплачен».</summary>
        public int PaidCount { get; set; }
    }
}
