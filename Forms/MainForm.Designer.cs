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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnNavAdmin = new System.Windows.Forms.Button();
            this.btnNavOrders = new System.Windows.Forms.Button();
            this.btnNavNewOrder = new System.Windows.Forms.Button();
            this.btnNavMenu = new System.Windows.Forms.Button();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.pnlTopLine = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblCafeName = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlSidebar
            //
            this.pnlSidebar.Controls.Add(this.btnNavAdmin);
            this.pnlSidebar.Controls.Add(this.btnNavOrders);
            this.pnlSidebar.Controls.Add(this.btnNavNewOrder);
            this.pnlSidebar.Controls.Add(this.btnNavMenu);
            this.pnlSidebar.Controls.Add(this.lblLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 680);
            this.pnlSidebar.TabIndex = 0;
            //
            // btnNavAdmin
            //
            this.btnNavAdmin.Location = new System.Drawing.Point(0, 256);
            this.btnNavAdmin.Name = "btnNavAdmin";
            this.btnNavAdmin.Size = new System.Drawing.Size(220, 50);
            this.btnNavAdmin.TabIndex = 4;
            this.btnNavAdmin.Text = "Админ-панель";
            this.btnNavAdmin.UseVisualStyleBackColor = true;
            this.btnNavAdmin.Click += new System.EventHandler(this.btnNavAdmin_Click);
            //
            // btnNavOrders
            //
            this.btnNavOrders.Location = new System.Drawing.Point(0, 206);
            this.btnNavOrders.Name = "btnNavOrders";
            this.btnNavOrders.Size = new System.Drawing.Size(220, 50);
            this.btnNavOrders.TabIndex = 3;
            this.btnNavOrders.Text = "Заказы";
            this.btnNavOrders.UseVisualStyleBackColor = true;
            this.btnNavOrders.Click += new System.EventHandler(this.btnNavOrders_Click);
            //
            // btnNavNewOrder
            //
            this.btnNavNewOrder.Location = new System.Drawing.Point(0, 156);
            this.btnNavNewOrder.Name = "btnNavNewOrder";
            this.btnNavNewOrder.Size = new System.Drawing.Size(220, 50);
            this.btnNavNewOrder.TabIndex = 2;
            this.btnNavNewOrder.Text = "Новый заказ";
            this.btnNavNewOrder.UseVisualStyleBackColor = true;
            this.btnNavNewOrder.Click += new System.EventHandler(this.btnNavNewOrder_Click);
            //
            // btnNavMenu
            //
            this.btnNavMenu.Location = new System.Drawing.Point(0, 106);
            this.btnNavMenu.Name = "btnNavMenu";
            this.btnNavMenu.Size = new System.Drawing.Size(220, 50);
            this.btnNavMenu.TabIndex = 1;
            this.btnNavMenu.Text = "Меню кафе";
            this.btnNavMenu.UseVisualStyleBackColor = true;
            this.btnNavMenu.Click += new System.EventHandler(this.btnNavMenu_Click);
            //
            // lblLogo
            //
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(220, 92);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "Уют";
            this.lblLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.lblLogo_Paint);
            //
            // pnlTop
            //
            this.pnlTop.Controls.Add(this.lblAvatar);
            this.pnlTop.Controls.Add(this.lblGreeting);
            this.pnlTop.Controls.Add(this.pnlTopLine);
            this.pnlTop.Controls.Add(this.btnLogout);
            this.pnlTop.Controls.Add(this.lblUserRole);
            this.pnlTop.Controls.Add(this.lblUserName);
            this.pnlTop.Controls.Add(this.lblCafeName);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(220, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(880, 72);
            this.pnlTop.TabIndex = 1;
            //
            // lblAvatar
            //
            this.lblAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvatar.Location = new System.Drawing.Point(710, 14);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(44, 44);
            this.lblAvatar.TabIndex = 6;
            this.lblAvatar.Paint += new System.Windows.Forms.PaintEventHandler(this.lblAvatar_Paint);
            //
            // lblGreeting
            //
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Location = new System.Drawing.Point(22, 42);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(83, 15);
            this.lblGreeting.TabIndex = 5;
            this.lblGreeting.Text = "Добрый день!";
            //
            // pnlTopLine
            //
            this.pnlTopLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTopLine.Location = new System.Drawing.Point(0, 71);
            this.pnlTopLine.Name = "pnlTopLine";
            this.pnlTopLine.Size = new System.Drawing.Size(880, 1);
            this.pnlTopLine.TabIndex = 4;
            //
            // btnLogout
            //
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Location = new System.Drawing.Point(766, 19);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(96, 34);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Выйти";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // lblUserRole
            //
            this.lblUserRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserRole.Location = new System.Drawing.Point(380, 37);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(320, 18);
            this.lblUserRole.TabIndex = 2;
            this.lblUserRole.Text = "Роль";
            this.lblUserRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblUserName
            //
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(380, 17);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(320, 20);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "ФИО пользователя";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblCafeName
            //
            this.lblCafeName.AutoSize = true;
            this.lblCafeName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCafeName.Location = new System.Drawing.Point(18, 12);
            this.lblCafeName.Name = "lblCafeName";
            this.lblCafeName.Size = new System.Drawing.Size(138, 25);
            this.lblCafeName.TabIndex = 0;
            this.lblCafeName.Text = "Кофейня «Уют»";
            //
            // pnlContent
            //
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(220, 72);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(880, 608);
            this.pnlContent.TabIndex = 2;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1020, 640);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учёт заказов кафе";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnNavAdmin;
        private System.Windows.Forms.Button btnNavOrders;
        private System.Windows.Forms.Button btnNavNewOrder;
        private System.Windows.Forms.Button btnNavMenu;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.Panel pnlTopLine;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblCafeName;
        private System.Windows.Forms.Panel pnlContent;
    }
}
