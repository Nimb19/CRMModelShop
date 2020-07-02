namespace CrmUi
{
    partial class FormMain
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.ceoyjcnbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sellerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sellerAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computerModetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbProducts = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCart = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bPay = new System.Windows.Forms.Button();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.bUpdate = new System.Windows.Forms.Button();
            this.labelCost = new System.Windows.Forms.Label();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ceoyjcnbToolStripMenuItem,
            this.computerModetToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(647, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // ceoyjcnbToolStripMenuItem
            // 
            this.ceoyjcnbToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productToolStripMenuItem,
            this.sellerToolStripMenuItem,
            this.customerToolStripMenuItem,
            this.checkToolStripMenuItem});
            this.ceoyjcnbToolStripMenuItem.Name = "ceoyjcnbToolStripMenuItem";
            this.ceoyjcnbToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.ceoyjcnbToolStripMenuItem.Text = "Сущности";
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productAddToolStripMenuItem});
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.productToolStripMenuItem.Text = "Товар";
            this.productToolStripMenuItem.Click += new System.EventHandler(this.ProductToolStripMenuItem_Click);
            // 
            // productAddToolStripMenuItem
            // 
            this.productAddToolStripMenuItem.Name = "productAddToolStripMenuItem";
            this.productAddToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.productAddToolStripMenuItem.Text = "Добавить";
            this.productAddToolStripMenuItem.Click += new System.EventHandler(this.ProductAddToolStripMenuItem_Click);
            // 
            // sellerToolStripMenuItem
            // 
            this.sellerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sellerAddToolStripMenuItem});
            this.sellerToolStripMenuItem.Name = "sellerToolStripMenuItem";
            this.sellerToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.sellerToolStripMenuItem.Text = "Продавец";
            this.sellerToolStripMenuItem.Click += new System.EventHandler(this.SellerToolStripMenuItem_Click);
            // 
            // sellerAddToolStripMenuItem
            // 
            this.sellerAddToolStripMenuItem.Name = "sellerAddToolStripMenuItem";
            this.sellerAddToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.sellerAddToolStripMenuItem.Text = "Добавить";
            this.sellerAddToolStripMenuItem.Click += new System.EventHandler(this.SellerAddToolStripMenuItem_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerAddToolStripMenuItem});
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.customerToolStripMenuItem.Text = "Покупатель";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.CustomerToolStripMenuItem_Click);
            // 
            // customerAddToolStripMenuItem
            // 
            this.customerAddToolStripMenuItem.Name = "customerAddToolStripMenuItem";
            this.customerAddToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.customerAddToolStripMenuItem.Text = "Добавить";
            this.customerAddToolStripMenuItem.Click += new System.EventHandler(this.CustomerAddToolStripMenuItem_Click);
            // 
            // checkToolStripMenuItem
            // 
            this.checkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkAddToolStripMenuItem});
            this.checkToolStripMenuItem.Name = "checkToolStripMenuItem";
            this.checkToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.checkToolStripMenuItem.Text = "Чек";
            this.checkToolStripMenuItem.Click += new System.EventHandler(this.CheckToolStripMenuItem_Click);
            // 
            // checkAddToolStripMenuItem
            // 
            this.checkAddToolStripMenuItem.Name = "checkAddToolStripMenuItem";
            this.checkAddToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.checkAddToolStripMenuItem.Text = "Добавить";
            // 
            // computerModetToolStripMenuItem
            // 
            this.computerModetToolStripMenuItem.Name = "computerModetToolStripMenuItem";
            this.computerModetToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.computerModetToolStripMenuItem.Text = "Моделирование";
            this.computerModetToolStripMenuItem.Click += new System.EventHandler(this.ComputerModetToolStripMenuItem_Click);
            // 
            // lbProducts
            // 
            this.lbProducts.FormattingEnabled = true;
            this.lbProducts.Location = new System.Drawing.Point(12, 79);
            this.lbProducts.Name = "lbProducts";
            this.lbProducts.Size = new System.Drawing.Size(265, 472);
            this.lbProducts.TabIndex = 2;
            this.lbProducts.DoubleClick += new System.EventHandler(this.lbProducts_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Товары:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Корзина:";
            // 
            // lbCart
            // 
            this.lbCart.FormattingEnabled = true;
            this.lbCart.Location = new System.Drawing.Point(356, 79);
            this.lbCart.Name = "lbCart";
            this.lbCart.Size = new System.Drawing.Size(279, 394);
            this.lbCart.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 486);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Итоговая цена: ";
            // 
            // bPay
            // 
            this.bPay.Location = new System.Drawing.Point(356, 511);
            this.bPay.Name = "bPay";
            this.bPay.Size = new System.Drawing.Size(279, 40);
            this.bPay.TabIndex = 7;
            this.bPay.Text = "Оплатить";
            this.bPay.UseVisualStyleBackColor = true;
            this.bPay.Click += new System.EventHandler(this.BPay_Click);
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(9, 37);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(90, 13);
            this.linkLabel.TabIndex = 8;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "Авторизоваться";
            this.linkLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // bUpdate
            // 
            this.bUpdate.Location = new System.Drawing.Point(172, 50);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(105, 23);
            this.bUpdate.TabIndex = 9;
            this.bUpdate.Text = "Обновить";
            this.bUpdate.UseVisualStyleBackColor = true;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.Location = new System.Drawing.Point(438, 486);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(28, 13);
            this.labelCost.TabIndex = 10;
            this.labelCost.Text = "0,00";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 563);
            this.Controls.Add(this.labelCost);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.bPay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbCart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbProducts);
            this.Controls.Add(this.menuStrip2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная форма";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem ceoyjcnbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sellerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productAddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sellerAddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerAddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkAddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computerModetToolStripMenuItem;
        private System.Windows.Forms.ListBox lbProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbCart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bPay;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Label labelCost;
    }
}

