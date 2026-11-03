namespace Muhammed.Forms
{
    partial class MainForm
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
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnOpenOrder = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.lblSearchTable = new System.Windows.Forms.Label();
            this.txtSearchTable = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.lblNewStatus = new System.Windows.Forms.Label();
            this.cmbNewStatus = new System.Windows.Forms.ComboBox();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCount = new System.Windows.Forms.Label();
            this.grpFilter.SuspendLayout();
            this.grpStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            //
            // btnNewOrder
            //
            this.btnNewOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNewOrder.Location = new System.Drawing.Point(12, 12);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(130, 34);
            this.btnNewOrder.TabIndex = 0;
            this.btnNewOrder.Text = "Новый заказ";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            //
            // btnOpenOrder
            //
            this.btnOpenOrder.Location = new System.Drawing.Point(148, 12);
            this.btnOpenOrder.Name = "btnOpenOrder";
            this.btnOpenOrder.Size = new System.Drawing.Size(110, 34);
            this.btnOpenOrder.TabIndex = 1;
            this.btnOpenOrder.Text = "Открыть";
            this.btnOpenOrder.UseVisualStyleBackColor = true;
            this.btnOpenOrder.Click += new System.EventHandler(this.btnOpenOrder_Click);
            //
            // btnDeleteOrder
            //
            this.btnDeleteOrder.Location = new System.Drawing.Point(264, 12);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(110, 34);
            this.btnDeleteOrder.TabIndex = 2;
            this.btnDeleteOrder.Text = "Удалить";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            //
            // btnMenu
            //
            this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu.Location = new System.Drawing.Point(662, 12);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(110, 34);
            this.btnMenu.TabIndex = 3;
            this.btnMenu.Text = "Меню";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            //
            // btnReport
            //
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Location = new System.Drawing.Point(778, 12);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(110, 34);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "Отчёт";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            //
            // grpFilter
            //
            this.grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFilter.Controls.Add(this.lblFilter);
            this.grpFilter.Controls.Add(this.cmbFilter);
            this.grpFilter.Controls.Add(this.lblSearchTable);
            this.grpFilter.Controls.Add(this.txtSearchTable);
            this.grpFilter.Controls.Add(this.btnSearch);
            this.grpFilter.Controls.Add(this.btnReset);
            this.grpFilter.Location = new System.Drawing.Point(12, 56);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(876, 62);
            this.grpFilter.TabIndex = 5;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Поиск и фильтр";
            //
            // lblFilter
            //
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(12, 28);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(46, 15);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Статус:";
            //
            // cmbFilter
            //
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(64, 24);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(130, 23);
            this.cmbFilter.TabIndex = 1;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            //
            // lblSearchTable
            //
            this.lblSearchTable.AutoSize = true;
            this.lblSearchTable.Location = new System.Drawing.Point(214, 28);
            this.lblSearchTable.Name = "lblSearchTable";
            this.lblSearchTable.Size = new System.Drawing.Size(80, 15);
            this.lblSearchTable.TabIndex = 2;
            this.lblSearchTable.Text = "Номер стола:";
            //
            // txtSearchTable
            //
            this.txtSearchTable.Location = new System.Drawing.Point(300, 24);
            this.txtSearchTable.MaxLength = 5;
            this.txtSearchTable.Name = "txtSearchTable";
            this.txtSearchTable.Size = new System.Drawing.Size(70, 23);
            this.txtSearchTable.TabIndex = 3;
            //
            // btnSearch
            //
            this.btnSearch.Location = new System.Drawing.Point(382, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 29);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // btnReset
            //
            this.btnReset.Location = new System.Drawing.Point(478, 21);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(90, 29);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Сбросить";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            //
            // grpStatus
            //
            this.grpStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStatus.Controls.Add(this.lblNewStatus);
            this.grpStatus.Controls.Add(this.cmbNewStatus);
            this.grpStatus.Controls.Add(this.btnChangeStatus);
            this.grpStatus.Location = new System.Drawing.Point(12, 124);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(876, 62);
            this.grpStatus.TabIndex = 6;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Статус выбранного заказа";
            //
            // lblNewStatus
            //
            this.lblNewStatus.AutoSize = true;
            this.lblNewStatus.Location = new System.Drawing.Point(12, 28);
            this.lblNewStatus.Name = "lblNewStatus";
            this.lblNewStatus.Size = new System.Drawing.Size(81, 15);
            this.lblNewStatus.TabIndex = 0;
            this.lblNewStatus.Text = "Новый статус:";
            //
            // cmbNewStatus
            //
            this.cmbNewStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewStatus.FormattingEnabled = true;
            this.cmbNewStatus.Location = new System.Drawing.Point(100, 24);
            this.cmbNewStatus.Name = "cmbNewStatus";
            this.cmbNewStatus.Size = new System.Drawing.Size(130, 23);
            this.cmbNewStatus.TabIndex = 1;
            //
            // btnChangeStatus
            //
            this.btnChangeStatus.Location = new System.Drawing.Point(242, 21);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(140, 29);
            this.btnChangeStatus.TabIndex = 2;
            this.btnChangeStatus.Text = "Изменить статус";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            //
            // dgvOrders
            //
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToResizeRows = false;
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colDate,
            this.colTable,
            this.colStatus,
            this.colTotal});
            this.dgvOrders.Location = new System.Drawing.Point(12, 196);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(876, 340);
            this.dgvOrders.TabIndex = 7;
            this.dgvOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellDoubleClick);
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            //
            // colId
            //
            this.colId.HeaderText = "№ заказа";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 90;
            //
            // colDate
            //
            this.colDate.HeaderText = "Дата и время";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 150;
            //
            // colTable
            //
            this.colTable.HeaderText = "Стол";
            this.colTable.Name = "colTable";
            this.colTable.ReadOnly = true;
            this.colTable.Width = 80;
            //
            // colStatus
            //
            this.colStatus.HeaderText = "Статус";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 120;
            //
            // colTotal
            //
            this.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTotal.HeaderText = "Сумма, ₽";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            //
            // lblCount
            //
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(12, 546);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(116, 15);
            this.lblCount.TabIndex = 8;
            this.lblCount.Text = "Показано заказов: 0";
            //
            // MainForm
            //
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 570);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.btnOpenOrder);
            this.Controls.Add(this.btnNewOrder);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(820, 450);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учёт заказов кафе";
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnOpenOrder;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label lblSearchTable;
        private System.Windows.Forms.TextBox txtSearchTable;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.Label lblNewStatus;
        private System.Windows.Forms.ComboBox cmbNewStatus;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Label lblCount;
    }
}
