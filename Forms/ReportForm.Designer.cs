namespace Muhammed.Forms
{
    partial class ReportForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.lblTotalOrdersCaption = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.lblPaidOrdersCaption = new System.Windows.Forms.Label();
            this.lblPaidOrders = new System.Windows.Forms.Label();
            this.lblRevenueCaption = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.grpByStatus = new System.Windows.Forms.GroupBox();
            this.lblNewCaption = new System.Windows.Forms.Label();
            this.lblNewCount = new System.Windows.Forms.Label();
            this.lblCookingCaption = new System.Windows.Forms.Label();
            this.lblCookingCount = new System.Windows.Forms.Label();
            this.lblReadyCaption = new System.Windows.Forms.Label();
            this.lblReadyCount = new System.Windows.Forms.Label();
            this.lblPaidCaption = new System.Windows.Forms.Label();
            this.lblPaidCount = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpSummary.SuspendLayout();
            this.grpByStatus.SuspendLayout();
            this.SuspendLayout();
            //
            // lblDate
            //
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 18);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(35, 15);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Дата:";
            //
            // dtpDate
            //
            this.dtpDate.Location = new System.Drawing.Point(60, 14);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 23);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            //
            // grpSummary
            //
            this.grpSummary.Controls.Add(this.lblTotalOrdersCaption);
            this.grpSummary.Controls.Add(this.lblTotalOrders);
            this.grpSummary.Controls.Add(this.lblPaidOrdersCaption);
            this.grpSummary.Controls.Add(this.lblPaidOrders);
            this.grpSummary.Controls.Add(this.lblRevenueCaption);
            this.grpSummary.Controls.Add(this.lblRevenue);
            this.grpSummary.Location = new System.Drawing.Point(12, 50);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(356, 106);
            this.grpSummary.TabIndex = 2;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "Итоги дня";
            //
            // lblTotalOrdersCaption
            //
            this.lblTotalOrdersCaption.AutoSize = true;
            this.lblTotalOrdersCaption.Location = new System.Drawing.Point(12, 26);
            this.lblTotalOrdersCaption.Name = "lblTotalOrdersCaption";
            this.lblTotalOrdersCaption.Size = new System.Drawing.Size(88, 15);
            this.lblTotalOrdersCaption.TabIndex = 0;
            this.lblTotalOrdersCaption.Text = "Всего заказов:";
            //
            // lblTotalOrders
            //
            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrders.Location = new System.Drawing.Point(180, 26);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(14, 15);
            this.lblTotalOrders.TabIndex = 1;
            this.lblTotalOrders.Text = "0";
            //
            // lblPaidOrdersCaption
            //
            this.lblPaidOrdersCaption.AutoSize = true;
            this.lblPaidOrdersCaption.Location = new System.Drawing.Point(12, 50);
            this.lblPaidOrdersCaption.Name = "lblPaidOrdersCaption";
            this.lblPaidOrdersCaption.Size = new System.Drawing.Size(103, 15);
            this.lblPaidOrdersCaption.TabIndex = 2;
            this.lblPaidOrdersCaption.Text = "Из них оплачено:";
            //
            // lblPaidOrders
            //
            this.lblPaidOrders.AutoSize = true;
            this.lblPaidOrders.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPaidOrders.Location = new System.Drawing.Point(180, 50);
            this.lblPaidOrders.Name = "lblPaidOrders";
            this.lblPaidOrders.Size = new System.Drawing.Size(14, 15);
            this.lblPaidOrders.TabIndex = 3;
            this.lblPaidOrders.Text = "0";
            //
            // lblRevenueCaption
            //
            this.lblRevenueCaption.AutoSize = true;
            this.lblRevenueCaption.Location = new System.Drawing.Point(12, 74);
            this.lblRevenueCaption.Name = "lblRevenueCaption";
            this.lblRevenueCaption.Size = new System.Drawing.Size(58, 15);
            this.lblRevenueCaption.TabIndex = 4;
            this.lblRevenueCaption.Text = "Выручка:";
            //
            // lblRevenue
            //
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRevenue.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblRevenue.Location = new System.Drawing.Point(180, 74);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(46, 15);
            this.lblRevenue.TabIndex = 5;
            this.lblRevenue.Text = "0,00 ₽";
            //
            // grpByStatus
            //
            this.grpByStatus.Controls.Add(this.lblNewCaption);
            this.grpByStatus.Controls.Add(this.lblNewCount);
            this.grpByStatus.Controls.Add(this.lblCookingCaption);
            this.grpByStatus.Controls.Add(this.lblCookingCount);
            this.grpByStatus.Controls.Add(this.lblReadyCaption);
            this.grpByStatus.Controls.Add(this.lblReadyCount);
            this.grpByStatus.Controls.Add(this.lblPaidCaption);
            this.grpByStatus.Controls.Add(this.lblPaidCount);
            this.grpByStatus.Location = new System.Drawing.Point(12, 164);
            this.grpByStatus.Name = "grpByStatus";
            this.grpByStatus.Size = new System.Drawing.Size(356, 130);
            this.grpByStatus.TabIndex = 3;
            this.grpByStatus.TabStop = false;
            this.grpByStatus.Text = "Заказы по статусам";
            //
            // lblNewCaption
            //
            this.lblNewCaption.AutoSize = true;
            this.lblNewCaption.Location = new System.Drawing.Point(12, 26);
            this.lblNewCaption.Name = "lblNewCaption";
            this.lblNewCaption.Size = new System.Drawing.Size(42, 15);
            this.lblNewCaption.TabIndex = 0;
            this.lblNewCaption.Text = "Новый:";
            //
            // lblNewCount
            //
            this.lblNewCount.AutoSize = true;
            this.lblNewCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNewCount.Location = new System.Drawing.Point(180, 26);
            this.lblNewCount.Name = "lblNewCount";
            this.lblNewCount.Size = new System.Drawing.Size(14, 15);
            this.lblNewCount.TabIndex = 1;
            this.lblNewCount.Text = "0";
            //
            // lblCookingCaption
            //
            this.lblCookingCaption.AutoSize = true;
            this.lblCookingCaption.Location = new System.Drawing.Point(12, 50);
            this.lblCookingCaption.Name = "lblCookingCaption";
            this.lblCookingCaption.Size = new System.Drawing.Size(66, 15);
            this.lblCookingCaption.TabIndex = 2;
            this.lblCookingCaption.Text = "Готовится:";
            //
            // lblCookingCount
            //
            this.lblCookingCount.AutoSize = true;
            this.lblCookingCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCookingCount.Location = new System.Drawing.Point(180, 50);
            this.lblCookingCount.Name = "lblCookingCount";
            this.lblCookingCount.Size = new System.Drawing.Size(14, 15);
            this.lblCookingCount.TabIndex = 3;
            this.lblCookingCount.Text = "0";
            //
            // lblReadyCaption
            //
            this.lblReadyCaption.AutoSize = true;
            this.lblReadyCaption.Location = new System.Drawing.Point(12, 74);
            this.lblReadyCaption.Name = "lblReadyCaption";
            this.lblReadyCaption.Size = new System.Drawing.Size(40, 15);
            this.lblReadyCaption.TabIndex = 4;
            this.lblReadyCaption.Text = "Готов:";
            //
            // lblReadyCount
            //
            this.lblReadyCount.AutoSize = true;
            this.lblReadyCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReadyCount.Location = new System.Drawing.Point(180, 74);
            this.lblReadyCount.Name = "lblReadyCount";
            this.lblReadyCount.Size = new System.Drawing.Size(14, 15);
            this.lblReadyCount.TabIndex = 5;
            this.lblReadyCount.Text = "0";
            //
            // lblPaidCaption
            //
            this.lblPaidCaption.AutoSize = true;
            this.lblPaidCaption.Location = new System.Drawing.Point(12, 98);
            this.lblPaidCaption.Name = "lblPaidCaption";
            this.lblPaidCaption.Size = new System.Drawing.Size(55, 15);
            this.lblPaidCaption.TabIndex = 6;
            this.lblPaidCaption.Text = "Оплачен:";
            //
            // lblPaidCount
            //
            this.lblPaidCount.AutoSize = true;
            this.lblPaidCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPaidCount.Location = new System.Drawing.Point(180, 98);
            this.lblPaidCount.Name = "lblPaidCount";
            this.lblPaidCount.Size = new System.Drawing.Size(14, 15);
            this.lblPaidCount.TabIndex = 7;
            this.lblPaidCount.Text = "0";
            //
            // lblNote
            //
            this.lblNote.ForeColor = System.Drawing.Color.Gray;
            this.lblNote.Location = new System.Drawing.Point(12, 302);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(240, 34);
            this.lblNote.TabIndex = 4;
            this.lblNote.Text = "В выручку входят только оплаченные заказы.";
            //
            // btnClose
            //
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(268, 304);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            //
            // ReportForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(380, 346);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.grpByStatus);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отчёт за день";
            this.grpSummary.ResumeLayout(false);
            this.grpSummary.PerformLayout();
            this.grpByStatus.ResumeLayout(false);
            this.grpByStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.GroupBox grpSummary;
        private System.Windows.Forms.Label lblTotalOrdersCaption;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblPaidOrdersCaption;
        private System.Windows.Forms.Label lblPaidOrders;
        private System.Windows.Forms.Label lblRevenueCaption;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.GroupBox grpByStatus;
        private System.Windows.Forms.Label lblNewCaption;
        private System.Windows.Forms.Label lblNewCount;
        private System.Windows.Forms.Label lblCookingCaption;
        private System.Windows.Forms.Label lblCookingCount;
        private System.Windows.Forms.Label lblReadyCaption;
        private System.Windows.Forms.Label lblReadyCount;
        private System.Windows.Forms.Label lblPaidCaption;
        private System.Windows.Forms.Label lblPaidCount;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Button btnClose;
    }
}
