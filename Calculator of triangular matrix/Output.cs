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

        public Output()
        {
            InitializeComponent();
        }

        private void Output_Load(object sender, EventArgs e)
        {
            CurrentMatrix = (Matrix)DataTransfer.data[0];
            int mode_show = (int)DataTransfer.data[0];
            DataTransfer.dataNull();
            ShowMatrix(CurrentMatrix);
        }

        private void label_matrix_Click(object sender, EventArgs e)
        {

        }
        private void ShowMatrix(Matrix A)
        {
            int[] size = ElementsCheck(Size.Width, Size.Height, A.N);
            int n = size[0];
            int m = size[1];
            // очистка
            this.dataGridViewOutput.Rows.Clear();  // удаление всех строк
            int count = this.dataGridViewOutput.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                this.dataGridViewOutput.Columns.RemoveAt(0);
            }
            if (A.Type != Category.none && n * m > 0)
            {

                // создание новой
                DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[m];
                for (int i = 0; i < m; i++)
                {
                    column[i] = new DataGridViewTextBoxColumn(); // выделяем память для объекта
                    column[i].HeaderText = i.ToString();
                    column[i].Name = i.ToString();
                }
                // задание новой
                this.dataGridViewOutput.Columns.AddRange(column); // добавление столбцов
                for (int i = 0; i < n && i < A.N; i++)
                {
                    object[] row = new object[m];
                    for (int j = 0; j < m; j++)
                        row[j] = Operations.getElement(i, j, A);
                    dataGridViewOutput.Rows.Add(row);// добавление строк
                }
            }
        }
         private void ShowMatrixAdress(Matrix A)
        {
            int[] size = ElementsCheck(Size.Width, Size.Height, A.N);
            int n = size[0];
            int m = size[1];
            // очистка
            this.dataGridViewOutput.Rows.Clear();  // удаление всех строк
            int count = this.dataGridViewOutput.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                this.dataGridViewOutput.Columns.RemoveAt(0);
            }
            if (A.Type != Category.none && n * m > 0)
            {

                // создание новой
                DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[m];
                for (int i = 0; i < m; i++)
                {
                    column[i] = new DataGridViewTextBoxColumn(); // выделяем память для объекта
                    column[i].HeaderText = i.ToString();
                    column[i].Name = i.ToString();
                }
                // задание новой
                this.dataGridViewOutput.Columns.AddRange(column); // добавление столбцов
                unsafe {
                    int Numb;
                    double c;
                    string Adress;
                    for (int i = 0; i < n && i < A.N; i++)
                    {

                        object[] row = new object[m];
                        for (int j = 0; j < m; j++)
                        {
                            Numb= Operations.getElementNumber(i, j, A);
                            fixed (double* p = &A.Packed_form[Numb])
                            {
                                c = *p;
                                Adress = c.ToString();
                                row[j] = Operations.getElement(i, j, A) + " | " + Adress;
                            }
                        }
                        dataGridViewOutput.Rows.Add(row);// добавление строк

                    }
                }
            }
        }
        private int[] ElementsCheck(int W, int H, int n)//Количество строк и столбцов котрое можно вывести
        {
            int[] size = new int[2];
            size[0] = H / 20;
            size[1] = W / 100;
            if (size[0] > n)
                size[0] = n;
            if (size[1] > n)
                size[1] = n;
            return size;
        }

        private void Output_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                Output_ResizeEnd(sender, e);
        }

        private void Output_ResizeEnd(object sender, EventArgs e)
        {
            ShowMatrix(CurrentMatrix);
        }
    }
}
