
namespace Calculator_of_triangular_matrix
{
    partial class Output
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
            this.dataGridViewOutput = new System.Windows.Forms.DataGridView();
            this.label_matrix = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.Down = new System.Windows.Forms.Button();
            this.Left = new System.Windows.Forms.Button();
            this.Right = new System.Windows.Forms.Button();
            this.labelDiapazon = new System.Windows.Forms.Label();
            this.Up = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutput)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewOutput, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_matrix, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.111111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.88889F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(650, 422);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridViewOutput
            // 
            this.dataGridViewOutput.AllowUserToAddRows = false;
            this.dataGridViewOutput.AllowUserToDeleteRows = false;
            this.dataGridViewOutput.AllowUserToResizeRows = false;
            this.dataGridViewOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOutput.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewOutput.Location = new System.Drawing.Point(134, 41);
            this.dataGridViewOutput.MultiSelect = false;
            this.dataGridViewOutput.Name = "dataGridViewOutput";
            this.dataGridViewOutput.ReadOnly = true;
            this.dataGridViewOutput.RowHeadersWidth = 51;
            this.dataGridViewOutput.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewOutput.RowTemplate.Height = 24;
            this.dataGridViewOutput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewOutput.Size = new System.Drawing.Size(513, 378);
            this.dataGridViewOutput.TabIndex = 1;
            this.dataGridViewOutput.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridViewOutput_RowPrePaint);
            this.dataGridViewOutput.SelectionChanged += new System.EventHandler(this.dataGridViewOutput_SelectionChanged);
            // 
            // label_matrix
            // 
            this.label_matrix.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label_matrix, 2);
            this.label_matrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_matrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_matrix.Location = new System.Drawing.Point(3, 0);
            this.label_matrix.Name = "label_matrix";
            this.label_matrix.Size = new System.Drawing.Size(644, 38);
            this.label_matrix.TabIndex = 0;
            this.label_matrix.Text = "Матрица А";
            this.label_matrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Down, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.Left, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.Right, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.labelDiapazon, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.Up, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 41);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(125, 378);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Диапазон страницы";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Down
            // 
            this.Down.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Down.Location = new System.Drawing.Point(3, 181);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(119, 61);
            this.Down.TabIndex = 3;
            this.Down.Text = "Вниз на страницу";
            this.Down.UseVisualStyleBackColor = true;
            this.Down.Click += new System.EventHandler(this.Down_Click);
            // 
            // Left
            // 
            this.Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Left.Location = new System.Drawing.Point(3, 248);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(119, 61);
            this.Left.TabIndex = 4;
            this.Left.Text = "Влево на страницу";
            this.Left.UseVisualStyleBackColor = true;
            this.Left.Click += new System.EventHandler(this.Left_Click);
            // 
            // Right
            // 
            this.Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Right.Location = new System.Drawing.Point(3, 315);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(119, 61);
            this.Right.TabIndex = 5;
            this.Right.Text = "Вправо на страницу";
            this.Right.UseVisualStyleBackColor = true;
            this.Right.Click += new System.EventHandler(this.Right_Click);
            // 
            // labelDiapazon
            // 
            this.labelDiapazon.AutoSize = true;
            this.labelDiapazon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDiapazon.Location = new System.Drawing.Point(3, 37);
            this.labelDiapazon.Name = "labelDiapazon";
            this.labelDiapazon.Size = new System.Drawing.Size(119, 74);
            this.labelDiapazon.TabIndex = 1;
            this.labelDiapazon.Text = "По горизонтали [1000: 1200]\r\nПо вертикали [200: 400]";
            // 
            // Up
            // 
            this.Up.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Up.Location = new System.Drawing.Point(3, 114);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(119, 61);
            this.Up.TabIndex = 2;
            this.Up.Text = "Вверх на страницу";
            this.Up.UseVisualStyleBackColor = true;
            this.Up.Click += new System.EventHandler(this.Up_Click);
            // 
            // Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 422);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(490, 279);
            this.Name = "Output";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Печать значений";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Output_FormClosing);
            this.Load += new System.EventHandler(this.Output_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutput)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_matrix;
        private System.Windows.Forms.DataGridView dataGridViewOutput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Down;
        private System.Windows.Forms.Button Left;
        private System.Windows.Forms.Button Right;
        private System.Windows.Forms.Label labelDiapazon;
        private System.Windows.Forms.Button Up;
    }
}