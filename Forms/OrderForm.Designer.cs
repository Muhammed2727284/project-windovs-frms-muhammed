namespace Muhammed.Forms
{
    partial class OrderForm
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
            this.lblOrderInfo = new System.Windows.Forms.Label();
            this.lblTable = new System.Windows.Forms.Label();
            this.numTable = new System.Windows.Forms.NumericUpDown();
            this.grpAddDish = new System.Windows.Forms.GroupBox();
            this.lblDish = new System.Windows.Forms.Label();
            this.cmbDish = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSaveOrder = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTable)).BeginInit();
            this.grpAddDish.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            //
            // lblOrderInfo
            //
            this.lblOrderInfo.AutoSize = true;
            this.lblOrderInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblOrderInfo.Location = new System.Drawing.Point(12, 10);
            this.lblOrderInfo.Name = "lblOrderInfo";
            this.lblOrderInfo.Size = new System.Drawing.Size(105, 20);
            this.lblOrderInfo.TabIndex = 0;
            this.lblOrderInfo.Text = "Новый заказ";
            //
            // lblTable
            //
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(12, 46);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(80, 15);
            this.lblTable.TabIndex = 1;
            this.lblTable.Text = "Номер стола:";
            //
            // numTable
            //
            this.numTable.Location = new System.Drawing.Point(110, 43);
            this.numTable.Name = "numTable";
            this.numTable.Size = new System.Drawing.Size(70, 23);
            this.numTable.TabIndex = 2;
            this.numTable.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // grpAddDish
            //
            this.grpAddDish.Controls.Add(this.lblDish);
            this.grpAddDish.Controls.Add(this.cmbDish);
            this.grpAddDish.Controls.Add(this.lblQuantity);
            this.grpAddDish.Controls.Add(this.numQuantity);
            this.grpAddDish.Controls.Add(this.btnAddItem);
            this.grpAddDish.Location = new System.Drawing.Point(12, 78);
            this.grpAddDish.Name = "grpAddDish";
            this.grpAddDish.Size = new System.Drawing.Size(616, 66);
            this.grpAddDish.TabIndex = 3;
            this.grpAddDish.TabStop = false;
            this.grpAddDish.Text = "Добавить блюдо в заказ";
            //
            // lblDish
            //
            this.lblDish.AutoSize = true;
            this.lblDish.Location = new System.Drawing.Point(12, 30);
            this.lblDish.Name = "lblDish";
            this.lblDish.Size = new System.Drawing.Size(43, 15);
            this.lblDish.TabIndex = 0;
            this.lblDish.Text = "Блюдо:";
            //
            // cmbDish
            //
            this.cmbDish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDish.FormattingEnabled = true;
            this.cmbDish.Location = new System.Drawing.Point(64, 26);
            this.cmbDish.Name = "cmbDish";
            this.cmbDish.Size = new System.Drawing.Size(300, 23);
            this.cmbDish.TabIndex = 1;
            //
            // lblQuantity
            //
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(378, 30);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(47, 15);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.Text = "Кол-во:";
            //
            // numQuantity
            //
            this.numQuantity.Location = new System.Drawing.Point(434, 26);
            this.numQuantity.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(56, 23);
            this.numQuantity.TabIndex = 3;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // btnAddItem
            //
            this.btnAddItem.Location = new System.Drawing.Point(502, 22);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(100, 30);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "Добавить";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            //
            // dgvItems
            //
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemName,
            this.colItemPrice,
            this.colItemQuantity,
            this.colItemSum});
            this.dgvItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.dgvItems.Location = new System.Drawing.Point(12, 154);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(616, 240);
            this.dgvItems.TabIndex = 4;
            this.dgvItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellEndEdit);
            this.dgvItems.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvItems_CellValidating);
            //
            // colItemName
            //
            this.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItemName.HeaderText = "Блюдо";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            //
            // colItemPrice
            //
            this.colItemPrice.HeaderText = "Цена, ₽";
            this.colItemPrice.Name = "colItemPrice";
            this.colItemPrice.ReadOnly = true;
            this.colItemPrice.Width = 100;
            //
            // colItemQuantity
            //
            this.colItemQuantity.HeaderText = "Количество";
            this.colItemQuantity.Name = "colItemQuantity";
            this.colItemQuantity.Width = 100;
            //
            // colItemSum
            //
            this.colItemSum.HeaderText = "Сумма, ₽";
            this.colItemSum.Name = "colItemSum";
            this.colItemSum.ReadOnly = true;
            this.colItemSum.Width = 110;
            //
            // btnRemoveItem
            //
            this.btnRemoveItem.Location = new System.Drawing.Point(12, 402);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(140, 30);
            this.btnRemoveItem.TabIndex = 5;
            this.btnRemoveItem.Text = "Убрать позицию";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            //
            // lblHint
            //
            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.Gray;
            this.lblHint.Location = new System.Drawing.Point(160, 409);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(215, 15);
            this.lblHint.TabIndex = 6;
            this.lblHint.Text = "Количество можно изменить в таблице";
            //
            // lblTotal
            //
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(388, 402);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(240, 30);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Итого: 0,00 ₽";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btnSaveOrder
            //
            this.btnSaveOrder.Location = new System.Drawing.Point(398, 446);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(124, 34);
            this.btnSaveOrder.TabIndex = 8;
            this.btnSaveOrder.Text = "Сохранить заказ";
            this.btnSaveOrder.UseVisualStyleBackColor = true;
            this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);
            //
            // btnCancel
            //
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(528, 446);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 34);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            // OrderForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(640, 492);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveOrder);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.grpAddDish);
            this.Controls.Add(this.numTable);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.lblOrderInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Заказ";
            ((System.ComponentModel.ISupportInitialize)(this.numTable)).EndInit();
            this.grpAddDish.ResumeLayout(false);
            this.grpAddDish.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrderInfo;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.NumericUpDown numTable;
        private System.Windows.Forms.GroupBox grpAddDish;
        private System.Windows.Forms.Label lblDish;
        private System.Windows.Forms.ComboBox cmbDish;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemSum;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSaveOrder;
        private System.Windows.Forms.Button btnCancel;
    }
}
