namespace chatick
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.listUsers = new System.Windows.Forms.ListBox();
            this.dxghToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьФайлзащищенныйРежимToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveChatFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВФайлзащищенныйРежимToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearChatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветШрифтаЧатаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показыватьМойНикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показыватьУчастниковЧатаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показыватьПредупрежденияБезопасностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.чтоТакоеЗащищенныйРежимToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.профильToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.получитьНикиВсехУастниковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.чатToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.историяСообщенийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(12, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(399, 305);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.MouseLeave += new System.EventHandler(this.textBox1_MouseLeave);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(420, 338);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 22);
            this.button3.TabIndex = 3;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(417, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ник: ";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(12, 338);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(399, 23);
            this.textBox3.TabIndex = 10;
            this.textBox3.Visible = false;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // clearChatToolStripMenuItem
            // 
            this.clearChatToolStripMenuItem.Name = "clearChatToolStripMenuItem";
            this.clearChatToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(417, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Участники чата:";
            // 
            // listUsers
            // 
            this.listUsers.FormattingEnabled = true;
            this.listUsers.Location = new System.Drawing.Point(420, 68);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(112, 264);
            this.listUsers.TabIndex = 13;
            this.listUsers.DoubleClick += new System.EventHandler(this.listUsers_DoubleClick);
            // 
            // dxghToolStripMenuItem
            // 
            this.dxghToolStripMenuItem.Name = "dxghToolStripMenuItem";
            this.dxghToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.dxghToolStripMenuItem.Text = "dxgh";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.видToolStripMenuItem,
            this.чатToolStripMenuItem,
            this.профильToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(547, 25);
            this.menuStrip2.TabIndex = 14;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip2_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьФайлToolStripMenuItem,
            this.открытьФайлзащищенныйРежимToolStripMenuItem,
            this.saveChatFromFileToolStripMenuItem,
            this.сохранитьВФайлзащищенныйРежимToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 21);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // открытьФайлToolStripMenuItem
            // 
            this.открытьФайлToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("открытьФайлToolStripMenuItem.Image")));
            this.открытьФайлToolStripMenuItem.Name = "открытьФайлToolStripMenuItem";
            this.открытьФайлToolStripMenuItem.Size = new System.Drawing.Size(272, 24);
            this.открытьФайлToolStripMenuItem.Text = "Открыть";
            this.открытьФайлToolStripMenuItem.Click += new System.EventHandler(this.открытьФайлToolStripMenuItem_Click);
            // 
            // открытьФайлзащищенныйРежимToolStripMenuItem
            // 
            this.открытьФайлзащищенныйРежимToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("открытьФайлзащищенныйРежимToolStripMenuItem.Image")));
            this.открытьФайлзащищенныйРежимToolStripMenuItem.Name = "открытьФайлзащищенныйРежимToolStripMenuItem";
            this.открытьФайлзащищенныйРежимToolStripMenuItem.Size = new System.Drawing.Size(272, 24);
            this.открытьФайлзащищенныйРежимToolStripMenuItem.Text = "Открыть(защищенный режим)";
            this.открытьФайлзащищенныйРежимToolStripMenuItem.Click += new System.EventHandler(this.открытьФайлзащищенныйРежимToolStripMenuItem_Click);
            // 
            // saveChatFromFileToolStripMenuItem
            // 
            this.saveChatFromFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveChatFromFileToolStripMenuItem.Image")));
            this.saveChatFromFileToolStripMenuItem.Name = "saveChatFromFileToolStripMenuItem";
            this.saveChatFromFileToolStripMenuItem.Size = new System.Drawing.Size(272, 24);
            this.saveChatFromFileToolStripMenuItem.Text = "Сохранить";
            this.saveChatFromFileToolStripMenuItem.Click += new System.EventHandler(this.saveChatFromFileToolStripMenuItem_Click);
            // 
            // сохранитьВФайлзащищенныйРежимToolStripMenuItem
            // 
            this.сохранитьВФайлзащищенныйРежимToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("сохранитьВФайлзащищенныйРежимToolStripMenuItem.Image")));
            this.сохранитьВФайлзащищенныйРежимToolStripMenuItem.Name = "сохранитьВФайлзащищенныйРежимToolStripMenuItem";
            this.сохранитьВФайлзащищенныйРежимToolStripMenuItem.Size = new System.Drawing.Size(272, 24);
            this.сохранитьВФайлзащищенныйРежимToolStripMenuItem.Text = "Сохранить(защищенный режим)";
            this.сохранитьВФайлзащищенныйРежимToolStripMenuItem.Click += new System.EventHandler(this.сохранитьВФайлзащищенныйРежимToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("выходToolStripMenuItem.Image")));
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(272, 24);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearChatToolStripMenuItem1});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.editToolStripMenuItem.Text = "Правка";
            // 
            // clearChatToolStripMenuItem1
            // 
            this.clearChatToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("clearChatToolStripMenuItem1.Image")));
            this.clearChatToolStripMenuItem1.Name = "clearChatToolStripMenuItem1";
            this.clearChatToolStripMenuItem1.Size = new System.Drawing.Size(155, 24);
            this.clearChatToolStripMenuItem1.Text = "Очистить чат";
            this.clearChatToolStripMenuItem1.Click += new System.EventHandler(this.clearChatToolStripMenuItem1_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.цветШрифтаЧатаToolStripMenuItem,
            this.показыватьМойНикToolStripMenuItem,
            this.показыватьУчастниковЧатаToolStripMenuItem,
            this.показыватьПредупрежденияБезопасностиToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // цветШрифтаЧатаToolStripMenuItem
            // 
            this.цветШрифтаЧатаToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("цветШрифтаЧатаToolStripMenuItem.Image")));
            this.цветШрифтаЧатаToolStripMenuItem.Name = "цветШрифтаЧатаToolStripMenuItem";
            this.цветШрифтаЧатаToolStripMenuItem.Size = new System.Drawing.Size(340, 24);
            this.цветШрифтаЧатаToolStripMenuItem.Text = "Шрифт чата";
            this.цветШрифтаЧатаToolStripMenuItem.Click += new System.EventHandler(this.цветШрифтаЧатаToolStripMenuItem_Click);
            // 
            // показыватьМойНикToolStripMenuItem
            // 
            this.показыватьМойНикToolStripMenuItem.Checked = true;
            this.показыватьМойНикToolStripMenuItem.CheckOnClick = true;
            this.показыватьМойНикToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.показыватьМойНикToolStripMenuItem.Name = "показыватьМойНикToolStripMenuItem";
            this.показыватьМойНикToolStripMenuItem.Size = new System.Drawing.Size(340, 24);
            this.показыватьМойНикToolStripMenuItem.Text = "Показывать мой ник";
            this.показыватьМойНикToolStripMenuItem.Click += new System.EventHandler(this.показыватьМойНикToolStripMenuItem_Click);
            // 
            // показыватьУчастниковЧатаToolStripMenuItem
            // 
            this.показыватьУчастниковЧатаToolStripMenuItem.Checked = true;
            this.показыватьУчастниковЧатаToolStripMenuItem.CheckOnClick = true;
            this.показыватьУчастниковЧатаToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.показыватьУчастниковЧатаToolStripMenuItem.Name = "показыватьУчастниковЧатаToolStripMenuItem";
            this.показыватьУчастниковЧатаToolStripMenuItem.Size = new System.Drawing.Size(340, 24);
            this.показыватьУчастниковЧатаToolStripMenuItem.Text = "Показывать участников чата";
            this.показыватьУчастниковЧатаToolStripMenuItem.Click += new System.EventHandler(this.показыватьУчастниковЧатаToolStripMenuItem_Click);
            // 
            // показыватьПредупрежденияБезопасностиToolStripMenuItem
            // 
            this.показыватьПредупрежденияБезопасностиToolStripMenuItem.Checked = true;
            this.показыватьПредупрежденияБезопасностиToolStripMenuItem.CheckOnClick = true;
            this.показыватьПредупрежденияБезопасностиToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.показыватьПредупрежденияБезопасностиToolStripMenuItem.Name = "показыватьПредупрежденияБезопасностиToolStripMenuItem";
            this.показыватьПредупрежденияБезопасностиToolStripMenuItem.Size = new System.Drawing.Size(340, 24);
            this.показыватьПредупрежденияБезопасностиToolStripMenuItem.Text = "Показывать предупреждения безопасности";
            this.показыватьПредупрежденияБезопасностиToolStripMenuItem.Click += new System.EventHandler(this.показыватьПредупрежденияБезопасностиToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.чтоТакоеЗащищенныйРежимToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(70, 21);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // чтоТакоеЗащищенныйРежимToolStripMenuItem
            // 
            this.чтоТакоеЗащищенныйРежимToolStripMenuItem.Name = "чтоТакоеЗащищенныйРежимToolStripMenuItem";
            this.чтоТакоеЗащищенныйРежимToolStripMenuItem.Size = new System.Drawing.Size(270, 24);
            this.чтоТакоеЗащищенныйРежимToolStripMenuItem.Text = "Что такое защищенный режим?";
            this.чтоТакоеЗащищенныйРежимToolStripMenuItem.Click += new System.EventHandler(this.чтоТакоеЗащищенныйРежимToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("оПрограммеToolStripMenuItem.Image")));
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(270, 24);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // профильToolStripMenuItem
            // 
            this.профильToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.информацияToolStripMenuItem,
            this.получитьНикиВсехУастниковToolStripMenuItem});
            this.профильToolStripMenuItem.Name = "профильToolStripMenuItem";
            this.профильToolStripMenuItem.Size = new System.Drawing.Size(75, 21);
            this.профильToolStripMenuItem.Text = "Профиль";
            // 
            // информацияToolStripMenuItem
            // 
            this.информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
            this.информацияToolStripMenuItem.Size = new System.Drawing.Size(265, 24);
            this.информацияToolStripMenuItem.Text = "Информация";
            this.информацияToolStripMenuItem.Click += new System.EventHandler(this.информацияToolStripMenuItem_Click);
            // 
            // получитьНикиВсехУастниковToolStripMenuItem
            // 
            this.получитьНикиВсехУастниковToolStripMenuItem.Name = "получитьНикиВсехУастниковToolStripMenuItem";
            this.получитьНикиВсехУастниковToolStripMenuItem.Size = new System.Drawing.Size(265, 24);
            this.получитьНикиВсехУастниковToolStripMenuItem.Text = "Получить ники всех участников";
            this.получитьНикиВсехУастниковToolStripMenuItem.Click += new System.EventHandler(this.ПолучитьНикиВсехУастниковToolStripMenuItem_Click);
            // 
            // чатToolStripMenuItem
            // 
            this.чатToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.историяСообщенийToolStripMenuItem});
            this.чатToolStripMenuItem.Name = "чатToolStripMenuItem";
            this.чатToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.чатToolStripMenuItem.Text = "Чат";
            // 
            // историяСообщенийToolStripMenuItem
            // 
            this.историяСообщенийToolStripMenuItem.Name = "историяСообщенийToolStripMenuItem";
            this.историяСообщенийToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
            this.историяСообщенийToolStripMenuItem.Text = "История сообщений";
            this.историяСообщенийToolStripMenuItem.Click += new System.EventHandler(this.ИсторияСообщенийToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 365);
            this.Controls.Add(this.listUsers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip2;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(563, 426);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Narrow chat";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TextChanged += new System.EventHandler(this.Form1_TextChanged);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListBox listUsers;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dxghToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveChatFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearChatToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВФайлзащищенныйРежимToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьФайлзащищенныйРежимToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem чтоТакоеЗащищенныйРежимToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показыватьУчастниковЧатаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показыватьМойНикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цветШрифтаЧатаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показыватьПредупрежденияБезопасностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem профильToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem получитьНикиВсехУастниковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem чатToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem историяСообщенийToolStripMenuItem;
    }
}

