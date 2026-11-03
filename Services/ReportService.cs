using System;
using System.Collections.Generic;
using Muhammed.Models;

namespace Muhammed.Services
{
    /// <summary>
    /// Подсчёт отчётов по заказам.
    /// </summary>
    public static class ReportService
    {
        /// <summary>
        /// Строит отчёт за указанный день по всем заказам из DataService.
        /// </summary>
        public static DailyReport BuildDailyReport(DateTime day)
        {
            return BuildDailyReport(day, DataService.Orders);
        }

        /// <summary>
        /// Строит отчёт за указанный день по переданному списку заказов.
        /// Заказ относится к тому дню, когда он был создан.
        /// В выручку попадают только заказы со статусом «Оплачен».
        /// </summary>
        public static DailyReport BuildDailyReport(DateTime day, List<Order> orders)
        {
            DailyReport report = new DailyReport();
            report.Date = day.Date;

            foreach (Order order in orders)
            {
                // .Date отбрасывает время, остаётся только дата
                if (order.CreatedAt.Date != day.Date)
                {
                    continue;
                }

                report.TotalOrders++;

                switch (order.Status)
                {
                    case OrderStatus.Новый:
                        report.NewCount++;
                        break;
                    case OrderStatus.Готовится:
                        report.CookingCount++;
                        break;
                    case OrderStatus.Готов:
                        report.ReadyCount++;
                        break;
                    case OrderStatus.Оплачен:
                        report.PaidCount++;
                        report.Revenue += order.Total;
                        break;
                }
            }

            return report;
        }
    }
}
