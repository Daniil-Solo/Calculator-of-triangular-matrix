using System;
using System.IO;
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
    enum Category
    {
        none = 0,
        top_left,
        top_right,
        bot_left,
        bot_right
    }
    public partial class Main_menu : Form
    {
        History_message ourHistory = new History_message("Программа готова к работе");
        Matrix A = new Matrix('A', 0, 0, Category.none, null);
        Matrix B = new Matrix('B', 0, 0, Category.none, null);
        Matrix C = new Matrix('C', 0, 0, Category.none, null);
        int kol_sms = 10;// количество выводимых сообщений

        public Main_menu()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void закрепитьПоверхДургихОконToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        private void ShowMatrixA()
        {
            int width = this.Size.Width;
            int height = this.Size.Height;
            int n = 3;
            int m = 3;
            if (A.N != 0)
            {
                // очистка
                this.GridView_A.Rows.Clear();  // удаление всех строк
                int count = this.GridView_A.Columns.Count;
                for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
                {
                    this.GridView_A.Columns.RemoveAt(0);
                }
                // создание новой
                DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[m];
                for (int i = 0; i < m; i++)
                {
                    column[i] = new DataGridViewTextBoxColumn(); // выделяем память для объекта
                    column[i].HeaderText = i.ToString();
                    column[i].Name = i.ToString();
                }
                // задание новой
                this.GridView_A.Columns.AddRange(column); // добавление столбцов
                for (int i = 0; i < n; i ++)
                {
                    object[] row = new object[m];
                    for (int j = 0; j < m; j++)
                        row[j] = Operations.getElement(i, j, A);
                    GridView_A.Rows.Add(row);// добавление строк
                }
            }
        }
        private void ShowMatrixB()
        {
            int width = this.Size.Width;
            int height = this.Size.Height;
            int n = 3;
            int m = 3;
            if (A.N != 0)
            {
                // очистка
                this.GridView_A.Rows.Clear();  // удаление всех строк
                int count = this.GridView_A.Columns.Count;
                for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
                {
                    this.GridView_A.Columns.RemoveAt(0);
                }
                // создание новой
                DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[m];
                for (int i = 0; i < m; i++)
                {
                    column[i] = new DataGridViewTextBoxColumn(); // выделяем память для объекта
                    column[i].HeaderText = i.ToString();
                    column[i].Name = i.ToString();
                }
                // задание новой
                this.GridView_A.Columns.AddRange(column); // добавление столбцов
                for (int i = 0; i < n; i++)
                {
                    object[] row = new object[m];
                    for (int j = 0; j < m; j++)
                        row[j] = Operations.getElement(i, j, A);
                    GridView_A.Rows.Add(row);// добавление строк
                }
            }
        }


        // Создание матрицы
        // Принимает на вход способ создания, историю сообщения и имя матрицы
        // Возвращает ссылку на новую матрицу
        // Пример вызова: Matrix A = Form1.New_m(i, Our_history, A.Name);
        private Matrix New_m(int sp, Matrix M)
        {
            DataTransfer.dataNull();
            switch (sp)
            {
                case 0: // c клавиатуры

                    ourHistory = ourHistory.Add("Матрица " + M.Name + " создается способом: считывание с клавиатуры");
                    Input_keyb f2 = new Input_keyb();
                    f2.ShowDialog();
                    Input_hand f3 = new Input_hand();
                    f3.ShowDialog();

                    break;
                case 1: // из текстового файла

                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return M;
                    ourHistory = ourHistory.Add("Матрица " + M.Name + " создается способом: считывание из текстового файла");
                    string filename = openFileDialog1.FileName;
                    M.OpenFromFileToDataTransfer(filename, ref ourHistory);
                    break;
                case 2: // случайным образом

                    ourHistory = ourHistory.Add("Матрица " + M.Name + " создается способом: случайное задание");
                    Input_rand f4 = new Input_rand();
                    f4.ShowDialog();

                    break;
                default:
                    // pass
                    return M;
            }
            if (DataTransfer.isFull())
            {
                ourHistory = ourHistory.Add("Матрица успешно создана");
                int n = (int)DataTransfer.data[0];
                double v = (double)DataTransfer.data[1];
                Category type = (Category)DataTransfer.data[2];
                double[] packed_form = (double[])DataTransfer.data[3];
                Matrix tempMatrix = new Matrix(M.Name, n, v, type, packed_form);
                DataTransfer.dataNull();
                return tempMatrix;
            }
            else
            {
                ourHistory = ourHistory.Add("Матрица не создана");
                DataTransfer.dataNull();
                return new Matrix(M.Name, 0, 0, Category.none, null);
            }
        }

        // Сохранение матрицы в файл
        // На вход принимает матрицу и историю сообщений
        // На выходе ничего не возвращает
        // Пример вызова: Save_m(A, ourHistory)
        private void Save_m(Matrix M, ref History_message ourHistory)
        {
            // Если отменено сохранение, то выходит из функции
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            M.Save(filename, ref ourHistory);
        }

        private void safe_A_Click(object sender, EventArgs e)
        {
            Save_m(A, ref ourHistory);
            message_history.Text = ourHistory.Print(kol_sms);
        }

        private void safe_B_Click(object sender, EventArgs e)
        {
            Save_m(B, ref ourHistory);
            message_history.Text = ourHistory.Print(kol_sms);
        }

        private void safe_C_Click(object sender, EventArgs e)
        {
            Save_m(C, ref ourHistory);
            message_history.Text = ourHistory.Print(kol_sms);
        }

        private void comboBox_A1_SelectedIndexChanged(object sender, EventArgs e)
        {
            A = New_m(comboBox_A1.SelectedIndex, A);
        }

        private void comboBox_B1_SelectedIndexChanged(object sender, EventArgs e)
        {
            B = New_m(comboBox_B1.SelectedIndex, B);
        }

        private void comboBox_A2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Вызов метода для отображения 
            Output f5 = new Output();
            f5.Show();
        }

        private void comboBox_B2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Вызов метода для отображения
            Output f5 = new Output();
            f5.Show();
        }

        private void comboBox_C2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Output f5 = new Output();
            f5.Show();
        }

        private void AplusB_Click(object sender, EventArgs e)
        {
           message_history.Text = ourHistory.Print(10);
        }

        private void A_on_B_Click(object sender, EventArgs e)
        {
            ShowMatrixA();
        }

        private void obrA_Click(object sender, EventArgs e)
        {
            message_history.Text = A.Name.ToString() + ": размерность = " + A.N.ToString() + " тип = " + A.Type.ToString() + " значение V = " + A.V.ToString() + "\r\n";
            message_history.Text += B.Name.ToString() + ": размерность = " + B.N.ToString() + " тип = " + B.Type.ToString() + " значение V = " + B.V.ToString() + "\r\n";
            message_history.Text += C.Name.ToString() + ": размерность = " + C.N.ToString() + " тип = " + C.Type.ToString() + " значение V = " + C.V.ToString() + "\r\n";

        }
    }   
}