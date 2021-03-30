
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 532F));
            this.tableLayoutPanel1.Controls.Add(this.button_make, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_type, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_V, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_n, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_V, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox_n, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.62712F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.37288F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(341, 214);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_make
            // 
            this.button_make.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_make.Location = new System.Drawing.Point(105, 165);
            this.button_make.Name = "button_make";
            this.button_make.Size = new System.Drawing.Size(131, 40);
            this.button_make.TabIndex = 3;
            this.button_make.Text = "Создать";
            this.button_make.UseVisualStyleBackColor = true;
            this.button_make.Click += new System.EventHandler(this.button_make_Click);
            // 
            // comboBox_type
            // 
            this.comboBox_type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Items.AddRange(new object[] {
            "Нижний-правый",
            "Верхний-правый",
            "Нижний-левый",
            "Верхний-левый"});
            this.comboBox_type.Location = new System.Drawing.Point(3, 3);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(335, 24);
            this.comboBox_type.TabIndex = 0;
            this.comboBox_type.Text = "Тип матрицы...";
            // 
            // label_V
            // 
            this.label_V.AutoSize = true;
            this.label_V.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_V.Location = new System.Drawing.Point(3, 92);
            this.label_V.Name = "label_V";
            this.label_V.Size = new System.Drawing.Size(335, 24);
            this.label_V.TabIndex = 4;
            this.label_V.Text = "Значение V";
            // 
            // label_n
            // 
            this.label_n.AutoSize = true;
            this.label_n.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_n.Location = new System.Drawing.Point(3, 34);
            this.label_n.Name = "label_n";
            this.label_n.Size = new System.Drawing.Size(335, 24);
            this.label_n.TabIndex = 5;
            this.label_n.Text = "Размерность";
            // 
            // textBox_V
            // 
            this.textBox_V.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_V.Location = new System.Drawing.Point(3, 119);
            this.textBox_V.Name = "textBox_V";
            this.textBox_V.Size = new System.Drawing.Size(335, 22);
            this.textBox_V.TabIndex = 6;
            this.textBox_V.TextChanged += new System.EventHandler(this.textBox_V_TextChanged);
            // 
            // textBox_n
            // 
            this.textBox_n.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_n.Location = new System.Drawing.Point(3, 61);
            this.textBox_n.Name = "textBox_n";
            this.textBox_n.Size = new System.Drawing.Size(335, 22);
            this.textBox_n.TabIndex = 7;
            this.textBox_n.TextChanged += new System.EventHandler(this.textBox_n_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(341, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem,
            this.типМатрицыToolStripMenuItem,
            this.размерностьМатрицыToolStripMenuItem,
            this.значениеVToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.помощьToolStripMenuItem.Text = "Помощь";
            this.помощьToolStripMenuItem.Click += new System.EventHandler(this.помощьToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // типМатрицыToolStripMenuItem
            // 
            this.типМатрицыToolStripMenuItem.Name = "типМатрицыToolStripMenuItem";
            this.типМатрицыToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.типМатрицыToolStripMenuItem.Text = "Тип матрицы";
            // 
            // размерностьМатрицыToolStripMenuItem
            // 
            this.размерностьМатрицыToolStripMenuItem.Name = "размерностьМатрицыToolStripMenuItem";
            this.размерностьМатрицыToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.размерностьМатрицыToolStripMenuItem.Text = "Размерность матрицы";
            // 
            // значениеVToolStripMenuItem
            // 
            this.значениеVToolStripMenuItem.Name = "значениеVToolStripMenuItem";
            this.значениеVToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.значениеVToolStripMenuItem.Text = "Значение V";
            // 
            // Input_keyb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 242);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Input_keyb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ввод матрицы с клавиатуры";
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
    }
}