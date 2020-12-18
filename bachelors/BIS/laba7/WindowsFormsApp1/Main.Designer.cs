namespace WindowsFormsApp1
{
    partial class Main
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
            this.згенеруватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.кодуванняToolStripMenuItem,
            this.проПрограмуToolStripMenuItem,
            this.згенеруватиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(933, 31);
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
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(47, 27);
            this.файлToolStripMenuItem.Text = "&File";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(181, 28);
            this.сохранитьToolStripMenuItem.Text = "Save";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(181, 28);
            this.сохранитьКакToolStripMenuItem.Text = "Save as";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // откритьToolStripMenuItem
            // 
            this.откритьToolStripMenuItem.Name = "откритьToolStripMenuItem";
            this.откритьToolStripMenuItem.Size = new System.Drawing.Size(181, 28);
            this.откритьToolStripMenuItem.Text = "Open";
            this.откритьToolStripMenuItem.Click += new System.EventHandler(this.откритьToolStripMenuItem_Click);
            // 
            // закритьToolStripMenuItem
            // 
            this.закритьToolStripMenuItem.Name = "закритьToolStripMenuItem";
            this.закритьToolStripMenuItem.Size = new System.Drawing.Size(181, 28);
            this.закритьToolStripMenuItem.Text = "Close";
            this.закритьToolStripMenuItem.Click += new System.EventHandler(this.закритьToolStripMenuItem_Click);
            // 
            // друкToolStripMenuItem
            // 
            this.друкToolStripMenuItem.Name = "друкToolStripMenuItem";
            this.друкToolStripMenuItem.Size = new System.Drawing.Size(181, 28);
            this.друкToolStripMenuItem.Text = "Print";
            this.друкToolStripMenuItem.Click += new System.EventHandler(this.друкToolStripMenuItem_Click);
            // 
            // вихідToolStripMenuItem1
            // 
            this.вихідToolStripMenuItem1.Name = "вихідToolStripMenuItem1";
            this.вихідToolStripMenuItem1.Size = new System.Drawing.Size(181, 28);
            this.вихідToolStripMenuItem1.Text = "Exit";
            this.вихідToolStripMenuItem1.Click += new System.EventHandler(this.вихідToolStripMenuItem1_Click);
            // 
            // кодуванняToolStripMenuItem
            // 
            this.кодуванняToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шифруванняToolStripMenuItem,
            this.дишифруванняToolStripMenuItem});
            this.кодуванняToolStripMenuItem.Name = "кодуванняToolStripMenuItem";
            this.кодуванняToolStripMenuItem.Size = new System.Drawing.Size(72, 27);
            this.кодуванняToolStripMenuItem.Text = "&Cipher";
            // 
            // шифруванняToolStripMenuItem
            // 
            this.шифруванняToolStripMenuItem.Name = "шифруванняToolStripMenuItem";
            this.шифруванняToolStripMenuItem.Size = new System.Drawing.Size(181, 28);
            this.шифруванняToolStripMenuItem.Text = "Encrypt";
            this.шифруванняToolStripMenuItem.Click += new System.EventHandler(this.шифруванняToolStripMenuItem_Click);
            // 
            // дишифруванняToolStripMenuItem
            // 
            this.дишифруванняToolStripMenuItem.Name = "дишифруванняToolStripMenuItem";
            this.дишифруванняToolStripMenuItem.Size = new System.Drawing.Size(181, 28);
            this.дишифруванняToolStripMenuItem.Text = "Decrypt";
            this.дишифруванняToolStripMenuItem.Click += new System.EventHandler(this.дишифруванняToolStripMenuItem_Click);
            // 
            // проПрограмуToolStripMenuItem
            // 
            this.проПрограмуToolStripMenuItem.Name = "проПрограмуToolStripMenuItem";
            this.проПрограмуToolStripMenuItem.Size = new System.Drawing.Size(140, 27);
            this.проПрограмуToolStripMenuItem.Text = "&About program";
            this.проПрограмуToolStripMenuItem.Click += new System.EventHandler(this.проПрограмуToolStripMenuItem_Click);
            // 
            // згенеруватиToolStripMenuItem
            // 
            this.згенеруватиToolStripMenuItem.Name = "згенеруватиToolStripMenuItem";
            this.згенеруватиToolStripMenuItem.Size = new System.Drawing.Size(125, 27);
            this.згенеруватиToolStripMenuItem.Text = "&Generate KEY";
            this.згенеруватиToolStripMenuItem.Click += new System.EventHandler(this.згенеруватиToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(14, 88);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(905, 417);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(574, 34);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(60, 22);
            this.checkBox7.TabIndex = 10;
            this.checkBox7.Text = "RSA";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.Click += new System.EventHandler(this.checkBox7_Click);
            // 
            // textBox33
            // 
            this.textBox33.BackColor = System.Drawing.SystemColors.Control;
            this.textBox33.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox33.Font = new System.Drawing.Font("Ravie", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox33.ForeColor = System.Drawing.Color.Navy;
            this.textBox33.Location = new System.Drawing.Point(546, 12);
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new System.Drawing.Size(401, 63);
            this.textBox33.TabIndex = 55;
            this.textBox33.Text = "RSA Cipher";
            this.textBox33.TextChanged += new System.EventHandler(this.textBox33_TextChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.textBox33);
            this.Controls.Add(this.checkBox7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(347, 456);
            this.Name = "Main";
            this.Text = "RSA cipher";
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

        int number_decryption = 0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.ToolStripMenuItem згенеруватиToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox33;
    }
}

