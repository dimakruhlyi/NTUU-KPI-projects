namespace WindowsFormsApp1
{
    partial class Form1
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
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.откритьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закритьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.друкToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.кодуванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шифруванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дишифруванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проПрограмуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.кодуванняToolStripMenuItem,
            this.проПрограмуToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.откритьToolStripMenuItem,
            this.закритьToolStripMenuItem,
            this.друкToolStripMenuItem,
            this.вихідToolStripMenuItem1});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Ф&айл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // откритьToolStripMenuItem
            // 
            this.откритьToolStripMenuItem.Name = "откритьToolStripMenuItem";
            this.откритьToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.откритьToolStripMenuItem.Text = "Открить";
            this.откритьToolStripMenuItem.Click += new System.EventHandler(this.откритьToolStripMenuItem_Click);
            // 
            // закритьToolStripMenuItem
            // 
            this.закритьToolStripMenuItem.Name = "закритьToolStripMenuItem";
            this.закритьToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.закритьToolStripMenuItem.Text = "Закрить";
            this.закритьToolStripMenuItem.Click += new System.EventHandler(this.закритьToolStripMenuItem_Click);
            // 
            // друкToolStripMenuItem
            // 
            this.друкToolStripMenuItem.Name = "друкToolStripMenuItem";
            this.друкToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.друкToolStripMenuItem.Text = "Друк";
            this.друкToolStripMenuItem.Click += new System.EventHandler(this.друкToolStripMenuItem_Click);
            // 
            // вихідToolStripMenuItem1
            // 
            this.вихідToolStripMenuItem1.Name = "вихідToolStripMenuItem1";
            this.вихідToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.вихідToolStripMenuItem1.Text = "Вихід";
            this.вихідToolStripMenuItem1.Click += new System.EventHandler(this.вихідToolStripMenuItem1_Click);
            // 
            // кодуванняToolStripMenuItem
            // 
            this.кодуванняToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шифруванняToolStripMenuItem,
            this.дишифруванняToolStripMenuItem});
            this.кодуванняToolStripMenuItem.Name = "кодуванняToolStripMenuItem";
            this.кодуванняToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.кодуванняToolStripMenuItem.Text = "Крипт&осистема";
            // 
            // шифруванняToolStripMenuItem
            // 
            this.шифруванняToolStripMenuItem.Name = "шифруванняToolStripMenuItem";
            this.шифруванняToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.шифруванняToolStripMenuItem.Text = "Шифрування";
            this.шифруванняToolStripMenuItem.Click += new System.EventHandler(this.шифруванняToolStripMenuItem_Click);
            // 
            // дишифруванняToolStripMenuItem
            // 
            this.дишифруванняToolStripMenuItem.Name = "дишифруванняToolStripMenuItem";
            this.дишифруванняToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.дишифруванняToolStripMenuItem.Text = "Розшифрування";
            this.дишифруванняToolStripMenuItem.Click += new System.EventHandler(this.дишифруванняToolStripMenuItem_Click);
            // 
            // проПрограмуToolStripMenuItem
            // 
            this.проПрограмуToolStripMenuItem.Name = "проПрограмуToolStripMenuItem";
            this.проПрограмуToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.проПрограмуToolStripMenuItem.Text = "Про програм&у";
            this.проПрограмуToolStripMenuItem.Click += new System.EventHandler(this.проПрограмуToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 76);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(776, 362);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.Name = "Form1";
            this.Text = "Шифрування";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проПрограмуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem откритьToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem закритьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem друкToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кодуванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шифруванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дишифруванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem1;
    }
}

