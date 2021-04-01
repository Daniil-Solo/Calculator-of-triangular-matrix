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
// ---------------Объявление главных структур-------------
        History_message ourHistory = new History_message("Программа готова к работе");
        Matrix A = new Matrix('A', 0, 0, Category.none, null);
        Matrix B = new Matrix('B', 0, 0, Category.none, null);
        Matrix C = new Matrix('C', 0, 0, Category.none, null);

        public Main_menu()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

//----------------------Сервис---------------------------------
        private void закрепитьПоверхДургихОконToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }
        private void очиститьИсториюСообщений_Click(object sender, EventArgs e)
        {
            ourHistory = ourHistory.Clear_history();
            UpdateInfo();
        }
        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateInfo();
        }
        private void очиститьВсеМатрицы_Click(object sender, EventArgs e)
        {
            
        }
        private void очиститьМатрицуАToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A = new Matrix('A', 0, 0, Category.none, null);

            // А
            this.GridView_A.Rows.Clear();  // удаление всех строк
            int count = this.GridView_A.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                this.GridView_A.Columns.RemoveAt(0);
            }

            ourHistory = ourHistory.Add("Матрица А была очищена!");
            UpdateInfo();
        }
        private void очиститьМатрицуВToolStripMenuItem_Click(object sender, EventArgs e)
        {
            B = new Matrix('B', 0, 0, Category.none, null);
            
            // В
            this.GridView_B.Rows.Clear();  // удаление всех строк
            int count = this.GridView_B.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                this.GridView_B.Columns.RemoveAt(0);
            }

            ourHistory = ourHistory.Add("Матрица В была очищена!");
            UpdateInfo();
        }

        private void очиститьМатрицуСToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C = new Matrix('C', 0, 0, Category.none, null);

            // С
            this.GridView_C.Rows.Clear();  // удаление всех строк
            int count = this.GridView_C.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                this.GridView_C.Columns.RemoveAt(0);
            }

            ourHistory = ourHistory.Add("Матрица С была очищена!");
            UpdateInfo();
        }

        private void очиститьВсеМатрицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A = new Matrix('A', 0, 0, Category.none, null);
            B = new Matrix('B', 0, 0, Category.none, null);
            C = new Matrix('C', 0, 0, Category.none, null);

            // А
            this.GridView_A.Rows.Clear();  // удаление всех строк
            int count = this.GridView_A.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                this.GridView_A.Columns.RemoveAt(0);
            }
            // В
            this.GridView_B.Rows.Clear();  // удаление всех строк
            count = this.GridView_B.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                this.GridView_B.Columns.RemoveAt(0);
            }
            // С
            this.GridView_C.Rows.Clear();  // удаление всех строк
            count = this.GridView_C.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                this.GridView_C.Columns.RemoveAt(0);
            }

            ourHistory = ourHistory.Add("Все матрицы были очищены!");
            UpdateInfo();
        }

        // -------------------Кнопки сохранения матриц--------------------
        private void safe_A_Click(object sender, EventArgs e)
        {
            Save_m(A, ref ourHistory);
            UpdateInfo();
        }

        private void safe_B_Click(object sender, EventArgs e)
        {
            Save_m(B, ref ourHistory);
            UpdateInfo();
        }

        private void safe_C_Click(object sender, EventArgs e)
        {
            Save_m(C, ref ourHistory);
            UpdateInfo();
        }

// ----------------Комбобоксы выбора способа задания матриц---------------------
        private void comboBox_A1_SelectedIndexChanged(object sender, EventArgs e)
        {
            A = New_m(comboBox_A1.SelectedIndex, A);
            UpdateInfo();
        }

        private void comboBox_B1_SelectedIndexChanged(object sender, EventArgs e)
        {
            B = New_m(comboBox_B1.SelectedIndex, B);
            UpdateInfo();
        }

// ----------------Комбобоксы выбора способа печати матрицы-----------------------
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
            // Вызов метода для отображения
            Output f5 = new Output();
            f5.Show();
        }

// -------------Кнопки операций----------------------
        private void AplusB_Click(object sender, EventArgs e)
        {
            if (Check2Matrix(A, B))
                C = Operations.Summ(A, B, C, ref ourHistory);
            else ourHistory = ourHistory.Add("Матрицы не заданы");
            UpdateInfo();
        }
        private void AminB_Click(object sender, EventArgs e)
        {
            if (Check2Matrix(A, B))
                C = Operations.Subtraction(A, B, C, ref ourHistory);
            else ourHistory = ourHistory.Add("Матрицы не заданы");
            UpdateInfo();
        }
        private void AmultB_Click(object sender, EventArgs e)
        {
            if (Check2Matrix(A, B))
                C = Operations.Multiply(A, B, C, ref ourHistory);
            else ourHistory = ourHistory.Add("Матрицы не заданы");
            UpdateInfo();
        }
        private void A_on_B_Click(object sender, EventArgs e)
        {
            if (Check1Matrix(A, B))
                Operations.Replace_A_B(ref A, ref B, ref ourHistory);
            else ourHistory = ourHistory.Add("Матрицы не заданы");
            UpdateInfo();
        }
        private void A_on_C_Click(object sender, EventArgs e)
        {
            if (Check1Matrix(A, C))
                Operations.Replace_A_B(ref A, ref C, ref ourHistory);
            else ourHistory = ourHistory.Add("Матрицы не заданы");
            UpdateInfo();
        }
        private void B_on_C_Click(object sender, EventArgs e)
        {
            if (Check1Matrix(B, C))
                Operations.Replace_A_B(ref B, ref C, ref ourHistory);
            else ourHistory = ourHistory.Add("Матрицы не заданы");
            UpdateInfo();
        }
        private void obrA_Click(object sender, EventArgs e)
        {
            //if (CheckMatrix(A))
                
            //else ourHistory = ourHistory.Add("Матрица А не задана");
            //UpdateInfo();
        }
        private void obrB_Click(object sender, EventArgs e)
        {
            //if (CheckMatrix(B))

            //else ourHistory = ourHistory.Add("Матрица В не задана");
            //UpdateInfo();
        }

        // ------------------ Служебные функции----------------
        private void UpdateInfo()
        {
            ShowMatrixA();
            ShowMatrixB();
            ShowMatrixC();
            labelMatrixShow();
            message_history.Text = ourHistory.Print(10);
        }

        private void labelMatrixShow()
        {
            if (A.N != 0)
            {
                type_n_A.Text = "Тип: " + A.Type.ToString() + "\n\rРазмерность: " + A.N.ToString();
            }
            else
            {
                type_n_A.Text = "Тип: нет \n\r Размерность: нет";
            }
            if (B.N != 0)
            {
                type_n_B.Text = "Тип: " + B.Type.ToString() + "\n\rРазмерность: " + B.N.ToString();
            }
            else
            {
                type_n_B.Text = "Тип: нет \n\r Размерность: нет";
            }
            if (C.N != 0)
            {
                type_n_C.Text = "Тип: " + C.Type.ToString() + "\n\rРазмерность: " + C.N.ToString();
            }
            else
            {
                type_n_C.Text = "Тип: нет \n\r Размерность: нет";
            }

        }

        // Создание матрицы
        // Принимает на вход способ создания, историю сообщения и имя матрицы
        // Возвращает ссылку на новую матрицу
        // Пример вызова: Matrix A = Form1.New_m(i, Our_history, A.Name);
        private Matrix New_m(int sp, Matrix M)
        {
            DataTransfer.dataNull();
            if (sp == 0)// c клавиатуры
            {
                ourHistory = ourHistory.Add("Матрица " + M.Name + " создается способом: считывание с клавиатуры");
                Input_keyb f2 = new Input_keyb();
                f2.ShowDialog();
                if (DataTransfer.isFull(3))
                {
                    Input_hand f3 = new Input_hand();
                    f3.ShowDialog();
                }
            }
            else if (sp == 1)// из текстового файла
            {
                openFileDialog1.FileName = "";
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return M;
                ourHistory = ourHistory.Add("Матрица " + M.Name + " создается способом: считывание из текстового файла");
                string filename = openFileDialog1.FileName;
                M.OpenFromFileToDataTransfer(filename, ref ourHistory);
            }
            else if (sp == 2)// случайным образом
            {
                ourHistory = ourHistory.Add("Матрица " + M.Name + " создается способом: случайное задание");
                Input_rand f4 = new Input_rand();
                f4.ShowDialog();
            }
            else
            {
                return M;
            }
                    
            if (DataTransfer.isFull(4) )
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
                return M;
            }
        }
        
        // Сохранение матрицы в файл
        // На вход принимает матрицу и историю сообщений
        // На выходе ничего не возвращает
        // Пример вызова: Save_m(A, ourHistory)
        private void Save_m(Matrix M, ref History_message ourHistory)
        {
            saveFileDialog1.FileName = "";
            // Если отменено сохранение, то выходит из функции
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            M.Save(filename, ref ourHistory);
        }

        // Отображение матрицы А
        private void ShowMatrixA()
        {
            int[] size = ElementsCheck(Size.Width, Size.Height, A.N);
            int n = size[0];
            int m = size[1];
            // очистка
            this.GridView_A.Rows.Clear();  // удаление всех строк
            int count = this.GridView_A.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                this.GridView_A.Columns.RemoveAt(0);
            }
            if (A.Type != Category.none && n*m > 0)
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
                this.GridView_A.Columns.AddRange(column); // добавление столбцов
                for (int i = 0; i < n && i < A.N; i ++)
                {
                    object[] row = new object[m];
                    for (int j = 0; j < m; j++)
                        row[j] = Operations.getElement(i, j, A);
                    GridView_A.Rows.Add(row);// добавление строк
                }
            }
        }

        // Отображение матрицы В
        private void ShowMatrixB()
        {
            int[] size = ElementsCheck(Size.Width, Size.Height, B.N);
            int n = size[0];
            int m = size[1];
            // очистка
            this.GridView_B.Rows.Clear();  // удаление всех строк
            int count = this.GridView_B.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                this.GridView_B.Columns.RemoveAt(0);
            }
            if (B.Type != Category.none && n * m > 0)
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
                this.GridView_B.Columns.AddRange(column); // добавление столбцов
                for (int i = 0; i < n && i < B.N; i++)
                {
                    object[] row = new object[m];
                    for (int j = 0; j < m; j++)
                        row[j] = Operations.getElement(i, j, B);
                    GridView_B.Rows.Add(row);// добавление строк
                }
            }
        }

        // Отображение матрицы С
        private void ShowMatrixC()
        {
            int[] size = ElementsCheck(Size.Width, Size.Height, C.N);
            int n = size[0];
            int m = size[1];
            // очистка
            this.GridView_C.Rows.Clear();  // удаление всех строк
            int count = this.GridView_C.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                this.GridView_C.Columns.RemoveAt(0);
            }
            if (C.Type != Category.none && n * m > 0)
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
                this.GridView_C.Columns.AddRange(column); // добавление столбцов
                for (int i = 0; i < n && i < C.N; i++)
                {
                    object[] row = new object[m];
                    for (int j = 0; j < m; j++)
                        row[j] = Operations.getElement(i, j, C);
                    GridView_C.Rows.Add(row);// добавление строк
                }
            }
        }

        private bool Check2Matrix(Matrix M,Matrix K) //проверка: 2 матрицы не пустые
        {
            bool success = false;
            if ((M.Type != Category.none) && (K.Type != Category.none))
            { success = true; }
            return success;
        }
        private bool Check1Matrix(Matrix M, Matrix K) //проверка: хотя бы 1 матрица не пустая
        {
            bool success = false;
            if ((M.Type != Category.none) || (K.Type != Category.none))
            { success = true; }
            return success;
        }
        private bool CheckMatrix(Matrix M) //проверка: 1 матрица не пустая
        {
            bool success = false;
            if (M.Type != Category.none)
            { success = true; }
            return success;
        }
        private int[] ElementsCheck(int W, int H, int n)//Количество строк и столбцов котрое можно вывести
        {
            int[] size = new int[2];
            size[0] = H / 65;
            size[1] = W / 300;
            if (size[0] > n)
                size[0] = n;
            if (size[1] > n)
                size[1] = n;
            return size;
        }

        private void Main_menu_Resize(object sender, EventArgs e)
        {
            ShowMatrixA();
            ShowMatrixB();
            ShowMatrixC();
        }
    }
}