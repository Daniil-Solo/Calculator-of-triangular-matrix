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


        // Создание матрицы
        // Принимает на вход способ создания, историю сообщения и имя матрицы
        // Возвращает ссылку на новую матрицу
        // Пример вызова: Matrix A = Form1.New_m(i, Our_history, A.Name);
        private Matrix New_m(int sp, History_message ourHistory, Matrix M)
        {
            DataTransfer.dataNull();
            switch (sp)
            {
                case 0: // c клавиатуры

                    ourHistory.Add("Матрица " + M.Name + " создается способом: считывание с клавиатуры");
                    // Form1.Hide()
                    // Form2.Show() - считываем инфу в DataTransfer
                    //      -> Form2.Hide()
                    //         Form3.Show() - считываем инфу в DataTransfer
                    //              -> Form3.Hide()
                    //                 Form1.Show()
                    break;
                case 1: // из текстового файла

                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return M;
                    ourHistory.Add("Матрица " + M.Name + " создается способом: считывание из текстового файла");
                    string filename = openFileDialog1.FileName;
                    M.OpenFromFileToDataTransfer(filename, ourHistory);
                    break;
                case 2: // случайным образом

                    ourHistory.Add("Матрица " + M.Name + " создается способом: случайное задание");
                    // Form1.Hide()
                    // Form2.Show() - считываем инфу в DataTransfer
                    //      -> Form2.Hide()
                    //         Form3.Show() - считываем инфу в DataTransfer
                    //              -> Form3.Hide()
                    //                 Form1.Show()
                    break;
                default:
                    // pass
                    break;
            }
            if (DataTransfer.isFull())
            {
                ourHistory.Add("Матрица успешно создана");
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
                ourHistory.Add("Матрица не создана");
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
        }
    }
}
