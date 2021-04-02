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

        public Output()
        {
            InitializeComponent();
        }

        private void Output_Load(object sender, EventArgs e)
        {
            CurrentMatrix = (Matrix)DataTransfer.data[0];
            mode_show = (int)DataTransfer.data[1];
            DataTransfer.dataNull();
            label_matrix.Text = "Матрица " + CurrentMatrix.Name;
            if (mode_show == 0)
            {
                this.Text = "Печать значений";
                // печать значений
                ShowMatrix(CurrentMatrix);
            }
            else
            {
                this.Text = "Печать значений и адресов";
                // печать адрессов
                ShowMatrixAdress(CurrentMatrix);
            }
            
        }

        private void label_matrix_Click(object sender, EventArgs e)
        {

        }
        private void ShowMatrix(Matrix A)
        {
            int n = A.N;
            int m = A.N;
            // очистка
            this.dataGridViewOutput.Rows.Clear();  // удаление всех строк
            int count = this.dataGridViewOutput.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                this.dataGridViewOutput.Columns.RemoveAt(0);
            }
            if (A.Type != Category.none)
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
            int n = A.N;
            int m = A.N;
            // очистка
            this.dataGridViewOutput.Rows.Clear();  // удаление всех строк
            int count = this.dataGridViewOutput.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                this.dataGridViewOutput.Columns.RemoveAt(0);
            }
            if (A.Type != Category.none)
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
                    uint Adress;
                    for (int i = 0; i < n && i < A.N; i++)
                    {

                        object[] row = new object[m];
                        for (int j = 0; j < m; j++)
                        {
                            if (Operations.isV(i, j, A))
                            {
                                fixed (double* p = &A.v)
                                {
                                    Adress = (uint)p;
                                    row[j] = A.V + " | " + Adress;
                                }
                            }
                            else
                            {
                                fixed (double* p = &A.Packed_form[Operations.getIndexK(i, j, A)])
                                {
                                    Adress = (uint)p;
                                    row[j] = Operations.getElement(i, j, A) + " | " + Adress;
                                }
                            }
                            
                        }
                        dataGridViewOutput.Rows.Add(row);// добавление строк

                    }
                }
            }
        }

        private void dataGridViewOutput_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
