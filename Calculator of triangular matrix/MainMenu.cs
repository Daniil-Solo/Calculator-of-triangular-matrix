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
        readonly int n_sms = 20;
        bool startSelected = false;

        public Main_menu()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            GridView_A.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            GridView_B.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            GridView_C.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        
        private void Main_menu_Load(object sender, EventArgs e)
        {
            comboBox_A1.SelectedIndex = 0;
            comboBox_A2.SelectedIndex = 0;
            comboBox_B1.SelectedIndex = 0;
            comboBox_B2.SelectedIndex = 0;
            comboBox_C2.SelectedIndex = 0;
            toolStripComboBoxEpsilon.SelectedIndex = 3;
        }

//----------------------Сервис---------------------------------
        private void закрепитьПоверхДургихОконToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }
        private void toolStripComboBoxEpsilon_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Epsilon.value = toolStripComboBoxEpsilon.SelectedIndex;
            ShowMatrixA();
            ShowMatrixB();
            ShowMatrixC();
        }
        private void сохранитьИсториюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MometalShowMessage("Сохранение истории");
            saveFileDialog1.FileName = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MometalShowMessage("Сохранение приостановлено");
                return;
            }
                
            string filename = saveFileDialog1.FileName;
            ourHistory.Save(filename);
            MometalShowMessage("История сохранена по адресу " + filename);
        }
        private void очиститьИсториюСообщений_Click(object sender, EventArgs e)
        {
            ourHistory = ourHistory.Clear_history();
            message_history.Text = ourHistory.Print(n_sms);
        }
        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateInfo();
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
            ShowMatrixA();
            labelMatrixShow();
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
            ShowMatrixB();
            labelMatrixShow();
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
            ShowMatrixC();
            labelMatrixShow();
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
            if (ServiceFunctions.CheckMatrix(A))
            {
                MometalShowMessage("Сохранение матрицы A");
                Save_m(A, ref ourHistory);
            }
            else
                MometalShowMessage("Для сохранения матрица должна быть задана");
            UpdateInfo();
        }

        private void safe_B_Click(object sender, EventArgs e)
        {
            if (ServiceFunctions.CheckMatrix(B))
            {
                MometalShowMessage("Сохранение матрицы B");
                Save_m(B, ref ourHistory);
            }
            else
                MometalShowMessage("Для сохранения матрица должна быть задана");
            UpdateInfo();
        }

        private void safe_C_Click(object sender, EventArgs e)
        {
            if (ServiceFunctions.CheckMatrix(C))
            {
                MometalShowMessage("Сохранение матрицы C");
                Save_m(C, ref ourHistory);
            }
            else 
                MometalShowMessage("Для сохранения матрица должна быть задана");
            UpdateInfo();
        }

// ----------------Комбобоксы выбора способа задания матриц---------------------
        private void comboBox_A1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (startSelected)
            {
                A = New_m(comboBox_A1.SelectedIndex, A);
                UpdateInfo();
            }
            
        }

        private void comboBox_B1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (startSelected)
            {
                B = New_m(comboBox_B1.SelectedIndex, B);
                UpdateInfo();
            }
            else
            {
                startSelected = true;
            }
        }

// ----------------Комбобоксы выбора способа печати матрицы-----------------------
        private void comboBox_A2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (A.N != 0)
            {
                // Вызов метода для отображения 
                MometalShowMessage("Выполняется подготовка к печати матрицы А. Пожалуйста подождите...");
                Output f5 = new Output();
                DataTransfer.data[0] = A;
                DataTransfer.data[1] = comboBox_A2.SelectedIndex;
                f5.Show();
            }
        }

        private void comboBox_B2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (B.N != 0)
            {
                // Вызов метода для отображения
                MometalShowMessage("Выполняется подготовка к печати матрицы B. Пожалуйста подождите...");
                Output f5 = new Output();
                DataTransfer.data[0] = B;
                DataTransfer.data[1] = comboBox_B2.SelectedIndex;
                f5.Show();
            }
        }

        private void comboBox_C2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (C.N != 0)
            {
                // Вызов метода для отображения
                MometalShowMessage("Выполняется подготовка к печати матрицы C. Пожалуйста подождите...");
                Output f5 = new Output();
                DataTransfer.data[0] = C;
                DataTransfer.data[1] = comboBox_C2.SelectedIndex;
                f5.Show();
            }
        }

// -------------Кнопки операций----------------------
        // Блокировщик кнопок
        private void BlockButtonsOperations()
        {
            AplusB.Enabled = !AplusB.Enabled;
            AminB.Enabled = !AminB.Enabled;
            AmultB.Enabled = !AmultB.Enabled;
            A_on_B.Enabled = !A_on_B.Enabled;
            A_on_C.Enabled = !A_on_C.Enabled;
            B_on_C.Enabled = !B_on_C.Enabled;
            obrA.Enabled = !obrA.Enabled;
            obrB.Enabled = !obrB.Enabled;
        }
        private void AplusB_Click(object sender, EventArgs e)
        {
            if (ServiceFunctions.Check2Matrix(A, B))
            {
                MometalShowMessage("Выполнение операции A+B");
                BlockButtonsOperations();
                C = Operations.Summ(A, B, C, ref ourHistory);
                ShowOnlyChangesInC();
                BlockButtonsOperations();
            }
            else
            {
                if (A.Type == Category.none && B.Type == Category.none)
                {
                    MometalShowMessage("Ни одна матрица не задана");
                }
                else if (A.Type == Category.none)
                {
                    MometalShowMessage("Матрица А не задана");
                }
                else
                {
                    MometalShowMessage("Матрица B не задана");
                }
            }
        }
        private void AminB_Click(object sender, EventArgs e)
        {
            if (ServiceFunctions.Check2Matrix(A, B))
            {
                MometalShowMessage("Выполнение операции A-B");
                BlockButtonsOperations();
                C = Operations.Subtraction(A, B, C, ref ourHistory);
                ShowOnlyChangesInC();
                BlockButtonsOperations();
            }
            else
            {
                if (A.Type == Category.none && B.Type == Category.none)
                {
                    MometalShowMessage("Ни одна матрица не задана");
                }
                else if (A.Type == Category.none)
                {
                    MometalShowMessage("Матрица А не задана");
                }
                else
                {
                    MometalShowMessage("Матрица B не задана");
                }
            }
        }
        private void AmultB_Click(object sender, EventArgs e)
        {
            if (ServiceFunctions.Check2Matrix(A, B))
            {
                MometalShowMessage("Выполнение операции A*B. Пожалуйста подождите...");
                BlockButtonsOperations();
                C = Operations.Multiply(A, B, C, ref ourHistory);
                ShowOnlyChangesInC();
                BlockButtonsOperations();
            }
            else
            {
                if (A.Type == Category.none && B.Type == Category.none)
                {
                    MometalShowMessage("Ни одна матрица не задана");
                }
                else if (A.Type == Category.none)
                {
                    MometalShowMessage("Матрица А не задана");
                }
                else
                {
                    MometalShowMessage("Матрица B не задана");
                }
            }
        }
        private void A_on_B_Click(object sender, EventArgs e)
        {
            if (ServiceFunctions.Check1Matrix(A, B))
            {
                MometalShowMessage("Выполнение операции " + A.Name + "<->" + B.Name);
                BlockButtonsOperations();
                Operations.Replace_A_B(ref A, ref B, ref ourHistory);
                UpdateInfo();
                BlockButtonsOperations();
            }
            else
                MometalShowMessage("Матрицы А и В не заданы");
            
        }
        private void A_on_C_Click(object sender, EventArgs e)
        {
            if (ServiceFunctions.Check1Matrix(A, C))
            {
                MometalShowMessage("Выполнение операции " + A.Name + "<->" + C.Name);
                BlockButtonsOperations();
                Operations.Replace_A_B(ref A, ref C, ref ourHistory);
                UpdateInfo();
                BlockButtonsOperations();
            }
            else
                MometalShowMessage("Матрицы А и С не заданы");
        }
        private void B_on_C_Click(object sender, EventArgs e)
        {
            if (ServiceFunctions.Check1Matrix(B, C))
            {
                MometalShowMessage("Выполнение операции " + B.Name + "<->" + C.Name);
                BlockButtonsOperations();
                Operations.Replace_A_B(ref B, ref C, ref ourHistory);
                UpdateInfo();
                BlockButtonsOperations();
            }
            else
                MometalShowMessage("Матрицы B и С не заданы");
        }
        private void obrA_Click(object sender, EventArgs e)
        {
            if (ServiceFunctions.CheckMatrix(A))
            {
                MometalShowMessage("Вычисление определителя матрицы A");
                BlockButtonsOperations();
                double detA = Operations.DeterminantReverseMatrix(A, ref ourHistory);
                message_history.Text = ourHistory.Print(n_sms);
                if (!Double.IsNaN(detA) && !Double.IsInfinity(detA))
                {
                    MometalShowMessage("Выполнение операции (A)^-1. Пожалуйста подождите...");
                    C = Operations.Reverse(A, C, ref ourHistory, detA);
                }
                else
                {
                    MometalShowMessage("Обратная матрица не может быть вычислена!");
                }
                ShowOnlyChangesInC();
                BlockButtonsOperations();
            }
            else
                MometalShowMessage("Матрица А не задана");
        }
        private void obrB_Click(object sender, EventArgs e)
        {
            if (ServiceFunctions.CheckMatrix(B))
            {
                MometalShowMessage("Вычисление определителя матрицы B");
                BlockButtonsOperations();
                double detB = Operations.DeterminantReverseMatrix(B, ref ourHistory);
                message_history.Text = ourHistory.Print(n_sms);
                if (!Double.IsNaN(detB) && !Double.IsInfinity(detB))
                {
                    MometalShowMessage("Выполнение операции (B)^-1. Пожалуйста подождите...");
                    C = Operations.Reverse(B, C, ref ourHistory, detB);
                }
                else
                {
                    MometalShowMessage("Обратная матрица не может быть вычислена!");
                }
                ShowOnlyChangesInC();
                BlockButtonsOperations();
            }
            else
                MometalShowMessage("Матрица B не задана");
        }

 // --------------------------- Служебные функции---------------------
    //-----------Отображение---------------      
        // обновление всей информации
        private void UpdateInfo()
        {
            ShowMatrixA();
            ShowMatrixB();
            ShowMatrixC();
            labelMatrixShow();
            message_history.Text = ourHistory.Print(n_sms);
        }
        // показать новое сообщение
        private void MometalShowMessage(String message)
        {
            ourHistory = ourHistory.Add(message);
            message_history.Text = ourHistory.Print(n_sms);
        }
        // обновить только информацию о матрице С
        private void ShowOnlyChangesInC()
        {
            ShowMatrixC();
            message_history.Text = ourHistory.Print(n_sms);
            labelMatrixShow();
        }
        // показать типы и размерности
        private void labelMatrixShow()
        {
            type_n_A.Text = ServiceFunctions.labelMatrix(A);
            type_n_B.Text = ServiceFunctions.labelMatrix(B);
            type_n_C.Text = ServiceFunctions.labelMatrix(C);
        }

//----------------Создание и сохранение матриц------------
        // Создание матрицы
        // Принимает на вход способ создания, историю сообщения и имя матрицы
        // Возвращает ссылку на новую матрицу
        // Пример вызова: Matrix A = Form1.New_m(i, Our_history, A.Name);
        private Matrix New_m(int sp, Matrix M)
        {
            DataTransfer.dataNull();
            if (sp == 0)// c клавиатуры
            {
                MometalShowMessage("Матрица " + M.Name + " создается способом: считывание с клавиатуры");
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
                MometalShowMessage("Матрица " + M.Name + " создается способом: считывание из текстового файла. Пожалуйста подождите...");
                string filename = openFileDialog1.FileName;
                MometalShowMessage("Адрес файла: " + filename);
                M.OpenFromFileToDataTransfer(filename, ref ourHistory);
            }
            else if (sp == 2)// случайным образом
            {
                MometalShowMessage("Матрица " + M.Name + " создается способом: случайное задание");
                Input_rand f4 = new Input_rand();
                f4.ShowDialog();
            }
            else
            {
                return M;
            }
                    
            if (DataTransfer.isFull(4) )
            {
                MometalShowMessage("Матрица успешно создана");
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
                MometalShowMessage("Матрица не создана");
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
            {
                MometalShowMessage("Сохранение приостановлено");
                return;
            }
            string filename = saveFileDialog1.FileName;
            M.Save(filename, ref ourHistory);
        }

//-----------------------Отображение матриц--------------------------
        // Отображение матрицы А
        private void ShowMatrixA()
        {
            int n = Math.Min(20, A.N);
            int m = Math.Min(20, A.N);
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
                    column[i].HeaderText = (i+1).ToString();
                    column[i].Name = (i+1).ToString();
                }
                // задание новой
                this.GridView_A.Columns.AddRange(column); // добавление столбцов
                for (int i = 0; i < n && i < A.N; i ++)
                {
                    object[] row = new object[m];
                    for (int j = 0; j < m; j++)
                        row[j] = ServiceFunctions.DeletZerosInEndString(String.Format("{0:F"+Epsilon.value.ToString()+"}" ,Operations.getElement(i, j, A)));
                    GridView_A.Rows.Add(row);// добавление строк
                }
                foreach (DataGridViewColumn col in GridView_A.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        // Отображение матрицы В
        private void ShowMatrixB()
        {
            int n = Math.Min(20, B.N);
            int m = Math.Min(20, B.N);
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
                    column[i].HeaderText = (i+1).ToString();
                    column[i].Name = (i+1).ToString();
                }
                // задание новой
                this.GridView_B.Columns.AddRange(column); // добавление столбцов
                for (int i = 0; i < n && i < B.N; i++)
                {
                    object[] row = new object[m];
                    for (int j = 0; j < m; j++)
                        row[j] = ServiceFunctions.DeletZerosInEndString(String.Format("{0:F" + Epsilon.value.ToString() + "}", Operations.getElement(i, j, B)));
                    GridView_B.Rows.Add(row);// добавление строк
                }
                foreach (DataGridViewColumn col in GridView_B.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        // Отображение матрицы С
        private void ShowMatrixC()
        {
            int n = Math.Min(20, C.N);
            int m = Math.Min(20, C.N);
            // очистка
            this.GridView_C.Rows.Clear();  // удаление всех строк
            int count = this.GridView_C.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                this.GridView_C.Columns.RemoveAt(0);
            }
            if (C.Type != Category.none)
            {
                
                // создание новой
                DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[m];
                for (int i = 0; i < m; i++)
                {
                    column[i] = new DataGridViewTextBoxColumn(); // выделяем память для объекта
                    column[i].HeaderText = (i+1).ToString();
                    column[i].Name = (i+1).ToString();
                }
                // задание новой
                this.GridView_C.Columns.AddRange(column); // добавление столбцов
                for (int i = 0; i < n && i < C.N; i++)
                {
                    object[] row = new object[m];
                    for (int j = 0; j < m; j++)
                        row[j] = ServiceFunctions.DeletZerosInEndString(String.Format("{0:F" + Epsilon.value.ToString() + "}", Operations.getElement(i, j, C)));
                    GridView_C.Rows.Add(row);// добавление строк
                }
                foreach (DataGridViewColumn col in GridView_C.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }


// --------------Рисование номеров строк----------------
        private void GridView_A_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object head = this.GridView_A.Rows[e.RowIndex].HeaderCell.Value;
            if (head == null)
                this.GridView_A.Rows[e.RowIndex].HeaderCell.Value =
                    (e.RowIndex+1).ToString();
        }

        private void GridView_B_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object head = this.GridView_B.Rows[e.RowIndex].HeaderCell.Value;
            if (head == null)
                this.GridView_B.Rows[e.RowIndex].HeaderCell.Value =
                    (e.RowIndex+1).ToString();
        }

        private void GridView_C_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object head = this.GridView_C.Rows[e.RowIndex].HeaderCell.Value;
            if (head == null)
                this.GridView_C.Rows[e.RowIndex].HeaderCell.Value =
                    (e.RowIndex+1).ToString();
        }

//----------------История сообщений скроллинг вниз------------
        private void message_history_TextChanged(object sender, EventArgs e)
        {
            message_history.SelectionStart = message_history.Text.Length;
            message_history.ScrollToCaret();
            message_history.Refresh();
        }


        
//-----------Запрет выделения мышкой-------------------
        private void GridView_A_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ((DataGridView)sender).SelectedCells[0].Selected = false;
            }
            catch { }
        }

        private void GridView_B_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ((DataGridView)sender).SelectedCells[0].Selected = false;
            }
            catch { }
        }

        private void GridView_C_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ((DataGridView)sender).SelectedCells[0].Selected = false;
            }
            catch { }
        }

        private void началоРаботы_Click(object sender, EventArgs e)
        {
            HelpNavigator navigator = HelpNavigator.Topic;
            Help.ShowHelp(this, "Triangular matrix help.chm", navigator, "Newtopic7.htm");
        }

        private void справка_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Triangular matrix help.chm");
        }

        private void обАвторе_Click(object sender, EventArgs e)
        {
            HelpNavigator navigator = HelpNavigator.Topic;
            Help.ShowHelp(this, "Triangular matrix help.chm", navigator, "Newtopic6.htm");
        }
    }
}