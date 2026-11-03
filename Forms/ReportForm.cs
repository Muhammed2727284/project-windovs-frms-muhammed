using System;
using System.Windows.Forms;
using Muhammed.Models;
using Muhammed.Services;

namespace Muhammed.Forms
{
    /// <summary>
    /// Окно «Отчёт за день»: количество заказов и выручка за выбранную дату.
    /// </summary>
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();

            // По умолчанию показываем отчёт за сегодня.
            // Сначала ставим дату, потом явно строим отчёт
            // (если дата и так сегодняшняя, событие ValueChanged не сработает).
            dtpDate.Value = DateTime.Today;
            ShowReport();
        }

        /// <summary>При смене даты пересчитываем отчёт.</summary>
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            ShowReport();
        }

        /// <summary>Считает отчёт за выбранную дату и выводит цифры на форму.</summary>
        private void ShowReport()
        {
            DailyReport report = ReportService.BuildDailyReport(dtpDate.Value);

            lblTotalOrders.Text = report.TotalOrders.ToString();
            lblPaidOrders.Text = report.PaidCount.ToString();
            lblRevenue.Text = report.Revenue.ToString("N2") + " ₽";

            lblNewCount.Text = report.NewCount.ToString();
            lblCookingCount.Text = report.CookingCount.ToString();
            lblReadyCount.Text = report.ReadyCount.ToString();
            lblPaidCount.Text = report.PaidCount.ToString();
        }
    }
}
