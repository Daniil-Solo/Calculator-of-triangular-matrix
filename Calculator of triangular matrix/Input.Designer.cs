﻿
namespace Calculator_of_triangular_matrix
{
    partial class Input_keyb
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_make = new System.Windows.Forms.Button();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.label_V = new System.Windows.Forms.Label();
            this.label_n = new System.Windows.Forms.Label();
            this.textBox_V = new System.Windows.Forms.TextBox();
            this.textBox_n = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.способыВводаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типМатрицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размерностьМатрицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.значениеVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.80851F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.19149F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 598F));
            this.tableLayoutPanel1.Controls.Add(this.button_make, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_type, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_V, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_n, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_V, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox_n, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 33);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.62712F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.37288F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 269);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_make
            // 
            this.button_make.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_make.Location = new System.Drawing.Point(3, 190);
            this.button_make.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_make.Name = "button_make";
            this.button_make.Size = new System.Drawing.Size(378, 75);
            this.button_make.TabIndex = 3;
            this.button_make.Text = "Создать";
            this.button_make.UseVisualStyleBackColor = true;
            this.button_make.Click += new System.EventHandler(this.button_make_Click);
            // 
            // comboBox_type
            // 
            this.comboBox_type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Items.AddRange(new object[] {
            "Нижний-правый",
            "Верхний-правый",
            "Нижний-левый",
            "Верхний-левый"});
            this.comboBox_type.Location = new System.Drawing.Point(3, 4);
            this.comboBox_type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(378, 28);
            this.comboBox_type.TabIndex = 0;
            this.comboBox_type.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_type_KeyDown);
            // 
            // label_V
            // 
            this.label_V.AutoSize = true;
            this.label_V.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_V.Location = new System.Drawing.Point(3, 117);
            this.label_V.Name = "label_V";
            this.label_V.Size = new System.Drawing.Size(378, 35);
            this.label_V.TabIndex = 4;
            this.label_V.Text = "Значение V";
            // 
            // label_n
            // 
            this.label_n.AutoSize = true;
            this.label_n.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_n.Location = new System.Drawing.Point(3, 43);
            this.label_n.Name = "label_n";
            this.label_n.Size = new System.Drawing.Size(378, 32);
            this.label_n.TabIndex = 5;
            this.label_n.Text = "Размерность";
            // 
            // textBox_V
            // 
            this.textBox_V.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_V.Location = new System.Drawing.Point(3, 156);
            this.textBox_V.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_V.Name = "textBox_V";
            this.textBox_V.Size = new System.Drawing.Size(378, 26);
            this.textBox_V.TabIndex = 6;
            this.textBox_V.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_V_KeyDown);
            // 
            // textBox_n
            // 
            this.textBox_n.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_n.Location = new System.Drawing.Point(3, 79);
            this.textBox_n.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_n.Name = "textBox_n";
            this.textBox_n.Size = new System.Drawing.Size(378, 26);
            this.textBox_n.TabIndex = 7;
            this.textBox_n.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_n_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(384, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem,
            this.способыВводаToolStripMenuItem,
            this.типМатрицыToolStripMenuItem,
            this.размерностьМатрицыToolStripMenuItem,
            this.значениеVToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.помощьToolStripMenuItem.Text = "Помощь";
            this.помощьToolStripMenuItem.Click += new System.EventHandler(this.помощьToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(298, 34);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // способыВводаToolStripMenuItem
            // 
            this.способыВводаToolStripMenuItem.Name = "способыВводаToolStripMenuItem";
            this.способыВводаToolStripMenuItem.Size = new System.Drawing.Size(298, 34);
            this.способыВводаToolStripMenuItem.Text = "Способы ввода";
            this.способыВводаToolStripMenuItem.Click += new System.EventHandler(this.способыВводаToolStripMenuItem_Click);
            // 
            // типМатрицыToolStripMenuItem
            // 
            this.типМатрицыToolStripMenuItem.Name = "типМатрицыToolStripMenuItem";
            this.типМатрицыToolStripMenuItem.Size = new System.Drawing.Size(298, 34);
            this.типМатрицыToolStripMenuItem.Text = "Тип матрицы";
            this.типМатрицыToolStripMenuItem.Click += new System.EventHandler(this.типМатрицыToolStripMenuItem_Click);
            // 
            // размерностьМатрицыToolStripMenuItem
            // 
            this.размерностьМатрицыToolStripMenuItem.Name = "размерностьМатрицыToolStripMenuItem";
            this.размерностьМатрицыToolStripMenuItem.Size = new System.Drawing.Size(298, 34);
            this.размерностьМатрицыToolStripMenuItem.Text = "Размерность матрицы";
            this.размерностьМатрицыToolStripMenuItem.Click += new System.EventHandler(this.размерностьМатрицыToolStripMenuItem_Click);
            // 
            // значениеVToolStripMenuItem
            // 
            this.значениеVToolStripMenuItem.Name = "значениеVToolStripMenuItem";
            this.значениеVToolStripMenuItem.Size = new System.Drawing.Size(298, 34);
            this.значениеVToolStripMenuItem.Text = "Значение V";
            this.значениеVToolStripMenuItem.Click += new System.EventHandler(this.значениеVToolStripMenuItem_Click);
            // 
            // Input_keyb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 302);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Input_keyb";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ввод с клавиатуры";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Input_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.Button button_make;
        private System.Windows.Forms.Label label_V;
        private System.Windows.Forms.Label label_n;
        private System.Windows.Forms.ToolStripMenuItem типМатрицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem размерностьМатрицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem значениеVToolStripMenuItem;
        public System.Windows.Forms.TextBox textBox_n;
        public System.Windows.Forms.TextBox textBox_V;
        public System.Windows.Forms.ComboBox comboBox_type;
        private System.Windows.Forms.ToolStripMenuItem способыВводаToolStripMenuItem;
    }
}