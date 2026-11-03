namespace Muhammed.Forms
{
    partial class AdminPage
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnDishes = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(153, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Админ-панель";
            //
            // lblSubtitle
            //
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new System.Drawing.Point(20, 48);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(330, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Управление меню, пользователями и отчёт по выручке";
            //
            // btnDishes
            //
            this.btnDishes.AccessibleDescription = "Добавление, изменение и удаление блюд";
            this.btnDishes.Location = new System.Drawing.Point(18, 84);
            this.btnDishes.Name = "btnDishes";
            this.btnDishes.Size = new System.Drawing.Size(272, 116);
            this.btnDishes.TabIndex = 2;
            this.btnDishes.Text = "Блюда";
            this.btnDishes.UseVisualStyleBackColor = true;
            this.btnDishes.Click += new System.EventHandler(this.btnDishes_Click);
            //
            // btnUsers
            //
            this.btnUsers.AccessibleDescription = "Роли сотрудников и удаление учётных записей";
            this.btnUsers.Location = new System.Drawing.Point(302, 84);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(272, 116);
            this.btnUsers.TabIndex = 3;
            this.btnUsers.Text = "Пользователи";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            //
            // btnReport
            //
            this.btnReport.AccessibleDescription = "Заказы и выручка за выбранный день";
            this.btnReport.Location = new System.Drawing.Point(586, 84);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(272, 116);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "Отчёт по выручке";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            //
            // AdminPage
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnDishes);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "AdminPage";
            this.Size = new System.Drawing.Size(880, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnDishes;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnReport;
    }
}
