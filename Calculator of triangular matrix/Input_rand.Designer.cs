
namespace Calculator_of_triangular_matrix
{
    partial class Input_rand
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заполнениеСлучайнымиЧисламиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типМатрицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размерностьМатрицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.label_n = new System.Windows.Forms.Label();
            this.textBox_n = new System.Windows.Forms.TextBox();
            this.label_V = new System.Windows.Forms.Label();
            this.textBox_V = new System.Windows.Forms.TextBox();
            this.button_ready = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(338, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem,
            this.заполнениеСлучайнымиЧисламиToolStripMenuItem,
            this.типМатрицыToolStripMenuItem,
            this.размерностьМатрицыToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.помощьToolStripMenuItem.Text = "Помощь";
            this.помощьToolStripMenuItem.Click += new System.EventHandler(this.помощьToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(391, 34);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // заполнениеСлучайнымиЧисламиToolStripMenuItem
            // 
            this.заполнениеСлучайнымиЧисламиToolStripMenuItem.Name = "заполнениеСлучайнымиЧисламиToolStripMenuItem";
            this.заполнениеСлучайнымиЧисламиToolStripMenuItem.Size = new System.Drawing.Size(391, 34);
            this.заполнениеСлучайнымиЧисламиToolStripMenuItem.Text = "Заполнение случайными числами";
            // 
            // типМатрицыToolStripMenuItem
            // 
            this.типМатрицыToolStripMenuItem.Name = "типМатрицыToolStripMenuItem";
            this.типМатрицыToolStripMenuItem.Size = new System.Drawing.Size(391, 34);
            this.типМатрицыToolStripMenuItem.Text = "Тип матрицы";
            // 
            // размерностьМатрицыToolStripMenuItem
            // 
            this.размерностьМатрицыToolStripMenuItem.Name = "размерностьМатрицыToolStripMenuItem";
            this.размерностьМатрицыToolStripMenuItem.Size = new System.Drawing.Size(391, 34);
            this.размерностьМатрицыToolStripMenuItem.Text = "Размерность матрицы";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.52518F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.47482F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel1.Controls.Add(this.comboBox_type, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_n, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_n, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_V, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox_V, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button_ready, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.18367F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.81633F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(338, 187);
            this.tableLayoutPanel1.TabIndex = 1;
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
            this.comboBox_type.Location = new System.Drawing.Point(3, 4);
            this.comboBox_type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(374, 28);
            this.comboBox_type.TabIndex = 2;
            this.comboBox_type.Text = "Тип матрицы...";
            this.comboBox_type.SelectedIndexChanged += new System.EventHandler(this.comboBox_type_SelectedIndexChanged);
            // 
            // label_n
            // 
            this.label_n.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_n.AutoSize = true;
            this.label_n.Location = new System.Drawing.Point(3, 30);
            this.label_n.Name = "label_n";
            this.label_n.Size = new System.Drawing.Size(109, 20);
            this.label_n.TabIndex = 3;
            this.label_n.Text = "Размерность";
            this.label_n.Click += new System.EventHandler(this.label_n_Click);
            // 
            // textBox_n
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_n, 3);
            this.textBox_n.Location = new System.Drawing.Point(3, 52);
            this.textBox_n.Name = "textBox_n";
            this.textBox_n.Size = new System.Drawing.Size(373, 26);
            this.textBox_n.TabIndex = 0;
            // 
            // label_V
            // 
            this.label_V.AutoSize = true;
            this.label_V.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_V.Location = new System.Drawing.Point(3, 88);
            this.label_V.Name = "label_V";
            this.label_V.Size = new System.Drawing.Size(374, 19);
            this.label_V.TabIndex = 4;
            this.label_V.Text = "Значение V";
            // 
            // textBox_V
            // 
            this.textBox_V.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_V.Location = new System.Drawing.Point(3, 106);
            this.textBox_V.Name = "textBox_V";
            this.textBox_V.Size = new System.Drawing.Size(374, 26);
            this.textBox_V.TabIndex = 5;
            // 
            // button_ready
            // 
            this.button_ready.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_ready.Location = new System.Drawing.Point(3, 135);
            this.button_ready.Name = "button_ready";
            this.button_ready.Size = new System.Drawing.Size(374, 61);
            this.button_ready.TabIndex = 1;
            this.button_ready.Text = "Готово";
            this.button_ready.UseVisualStyleBackColor = true;
            this.button_ready.Click += new System.EventHandler(this.button_ready_Click);
            // 
            // Input_rand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 269);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Input_rand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заполнение случайными числами";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заполнениеСлучайнымиЧисламиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типМатрицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem размерностьМатрицыToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox_n;
        private System.Windows.Forms.Button button_ready;
        private System.Windows.Forms.ComboBox comboBox_type;
        private System.Windows.Forms.Label label_n;
        private System.Windows.Forms.Label label_V;
        private System.Windows.Forms.TextBox textBox_V;
    }
}