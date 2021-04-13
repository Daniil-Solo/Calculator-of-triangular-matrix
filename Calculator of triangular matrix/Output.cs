using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_of_triangular_matrix
{
    public partial class Output : Form
    {
        Matrix CurrentMatrix;
        int mode_show;
        int prirost;
        int left, right, up, down;


        public Output()
        {
            InitializeComponent();
            dataGridViewOutput.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void Output_Load(object sender, EventArgs e)
        {
            CurrentMatrix = (Matrix)DataTransfer.data[0];
            mode_show = (int)DataTransfer.data[1];
            DataTransfer.dataNull();
            label_matrix.Text = "Матрица " + CurrentMatrix.Name;
            
            prirost = 50;
            left = 0;
            right = left + prirost;
            up = 0;
            down = up + prirost;
            
            if (mode_show == 0)
            {
                this.Text = "Печать значений";
                ShowMatrix(CurrentMatrix);
            }
            else
            {
                this.Text = "Печать значений и адресов";
                ShowMatrixAdress(CurrentMatrix);
            }
            labelDiapzonShow();
        }


        private void ShowMatrix(Matrix A)
        {
            int n = prirost;
            int m = prirost;
            if (isLastYPage())
                n = A.N % prirost;
            if (n == 0)
                n = A.N;
            if (isLastXPage())
                m = A.N % prirost;
            if (m == 0)
                m = A.N;
            // очистка
            this.dataGridViewOutput.Rows.Clear();  // удаление всех строк
            int count = this.dataGridViewOutput.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                this.dataGridViewOutput.Columns.RemoveAt(0);
            }

            // создание новой
            DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[m];
            for (int i = 0; i < m; i++)
            {
                column[i] = new DataGridViewTextBoxColumn(); // выделяем память для объекта
                column[i].HeaderText = (i + 1 + left).ToString();
                column[i].Name = (i + 1 + left).ToString();
            }
            // задание новой
            this.dataGridViewOutput.Columns.AddRange(column); // добавление столбцов
            for (int i = 0; i < n; i++)
            {
                object[] row = new object[m];
                for (int j = 0; j < m; j++)
                    row[j] = ServiceFunctions.DeletZerosInEndString(String.Format("{0:F" + Epsilon.value.ToString() + "}", Operations.getElement(up+i, left+j, A)));
                dataGridViewOutput.Rows.Add(row);// добавление строк
            }
            foreach (DataGridViewColumn col in dataGridViewOutput.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
         private void ShowMatrixAdress(Matrix A)
        {
            int n = prirost;
            int m = prirost;
            if (isLastYPage())
                n = A.N % prirost;
            if (n == 0)
                n = A.N;
            if (isLastXPage())
                m = A.N % prirost;
            if (m == 0)
                m = A.N;
            // очистка
            this.dataGridViewOutput.Rows.Clear();  // удаление всех строк
            int count = this.dataGridViewOutput.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                this.dataGridViewOutput.Columns.RemoveAt(0);
            }
            // создание новой
            DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[m];
            for (int i = 0; i < m; i++)
            {
                column[i] = new DataGridViewTextBoxColumn(); // выделяем память для объекта
                column[i].HeaderText = (i + 1 + left).ToString();
                column[i].Name = (i + 1 + left).ToString();
            }
            // задание новой
            this.dataGridViewOutput.Columns.AddRange(column); // добавление столбцов
            unsafe {
                uint Adress;
                for (int i = 0; i < n && i < A.N; i++)
                {
                    object[] row = new object[m];
                    for (int j = 0; j < m; j++)
                    {
                        if (Operations.isV(i + up, j + left, A))
                        {
                            fixed (double* p = &A.v)
                            {
                                Adress = (uint)p;
                                row[j] = ServiceFunctions.DeletZerosInEndString(
                                    String.Format("{0:F" + Epsilon.value.ToString() + "}", A.V))
                                    + " | " + "0x" + Adress.ToString("X2");
                            }
                        }
                        else
                        {
                            fixed (double* p = &A.Packed_form[Operations.getIndexK(i + up, j + left, A)])
                            {
                                Adress = (uint)p;
                                row[j] = ServiceFunctions.DeletZerosInEndString(
                                    String.Format("{0:F" + Epsilon.value.ToString() + "}", 
                                    Operations.getElement(i + up, j + left, A))) + " | " + "0x" + Adress.ToString("X2");
                            }
                        }
                            
                    }
                    dataGridViewOutput.Rows.Add(row);// добавление строк
                }
                foreach (DataGridViewColumn col in dataGridViewOutput.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }


        private void dataGridViewOutput_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object head = this.dataGridViewOutput.Rows[e.RowIndex].HeaderCell.Value;
            if (head == null)
                this.dataGridViewOutput.Rows[e.RowIndex].HeaderCell.Value =
                    (e.RowIndex+up+1).ToString();
        }

// ---------------Кноки перемещения-----------------
        private void Up_Click(object sender, EventArgs e)
        {
            up -= prirost;
            down -= prirost;
            if (up < 0)
            {
                up += prirost;
                down += prirost;
                return;
            }
            BlockButton();
            ShowChange();
        }
        private void Down_Click(object sender, EventArgs e)
        {
            if (isLastYPage())
                return;
            down += prirost;
            up += prirost;
            BlockButton();
            ShowChange();
        }
        private void Left_Click(object sender, EventArgs e)
        {
            left -= prirost;
            right -= prirost;
            if (left < 0)
            {
                left += prirost;
                right += prirost;
                return;
            }
            BlockButton();
            ShowChange();
        }
        private void Right_Click(object sender, EventArgs e)
        {
            if (isLastXPage())
                return;
            left += prirost;
            right += prirost;
            BlockButton();
            ShowChange();
        }

        private void Output_FormClosing(object sender, FormClosingEventArgs e)
        {
            // очистка
            this.dataGridViewOutput.Rows.Clear();  // удаление всех строк
            int count = this.dataGridViewOutput.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                this.dataGridViewOutput.Columns.RemoveAt(0);
            }
        }

        private void dataGridViewOutput_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ((DataGridView)sender).SelectedCells[0].Selected = false;
            }
            catch { }
        }

// ------------Отобразить диапазон---------------
        private void labelDiapzonShow()
        {
            if (isLastXPage())
            {
                if(CurrentMatrix.N % prirost == 0)
                    labelDiapazon.Text = "По горизонтали\n\r[" + (left + 1).ToString() + "; " + (left + CurrentMatrix.N).ToString() + "]\n\r";
                else
                    labelDiapazon.Text = "По горизонтали\n\r[" + (left + 1).ToString() + "; " + (left + CurrentMatrix.N % prirost).ToString() + "]\n\r";
            }
            else
                labelDiapazon.Text = "По горизонтали\n\r[" + (left + 1).ToString() + "; " + right.ToString() + "]\n\r";
            
            if (isLastYPage())
            {
                if (CurrentMatrix.N % prirost == 0)
                    labelDiapazon.Text += "По вертикали\n\r[" + (up + 1).ToString() + "; " + (up + CurrentMatrix.N).ToString() + "]";
                else
                    labelDiapazon.Text += "По вертикали\n\r[" + (up + 1).ToString() + "; " + (up + CurrentMatrix.N % prirost).ToString() + "]";
            }
            else
                labelDiapazon.Text += "По вертикали\n\r[" + (up + 1).ToString() + "; " + down.ToString() + "]";
        }

// --------- Проверка на последнюю страницу---------
        private bool isLastXPage()
        {
            return (left + prirost > CurrentMatrix.N || right == CurrentMatrix.N);
        }
        private bool isLastYPage()
        {
            return (up + prirost > CurrentMatrix.N || down == CurrentMatrix.N);
        }

// -----------Показать изменения-----------------
        private void ShowChange()
        {
            labelDiapzonShow();
            if (mode_show == 0)
                ShowMatrix(CurrentMatrix);
            else
                ShowMatrixAdress(CurrentMatrix);
            BlockButton();
        }

//--------Блокировка/Разблокировка кнопок--------
        private void BlockButton()
        {
            Up.Enabled = !Up.Enabled;
            Down.Enabled = !Down.Enabled;
            Left.Enabled = !Left.Enabled;
            Right.Enabled = !Right.Enabled;
        }
    }
}
