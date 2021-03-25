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
    public partial class Form1 : Form
    {
        History_message ourHistory = new History_message("Программа готова к работе");

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            Matrix A = new Matrix('A', 0, 0, Category.none, null);
            Matrix B = new Matrix('B', 0, 0, Category.none, null);
            Matrix C = new Matrix('C', 0, 0, Category.none, null);
            ourHistory = ourHistory.Add("Матрица успешно загружена");
            ourHistory = ourHistory.Add("Произошла ошибка при загрузке");
            textBox1.Text = ourHistory.Print(3);
        }

        private void закрепитьПоверхДургихОконToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        // Сохранение матрицы в файл
        // На вход принимает матрицу и историю сообщений
        // На выходе ничего не возвращает
        private void Save_m(Matrix M, History_message ourHistory)
        {
            // Если отменено сохранение, то выходит из функции
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            
            string filename = saveFileDialog1.FileName;
            ourHistory.Add("Сохранение матрицы " + M.Name);
            
            StreamWriter f = null;
            try
            {
                f = new StreamWriter(filename);
            }
            catch
            {
                ourHistory.Add("Ошибка при сохранении");
            }
            
            /*
             Добавить строки в файл с помощью f.WriteLine("Строка");
                Первая строка: размерность
                Вторая строка: значение V
                Третья строка: тип матрицы
                Следующую строки: строки с элементами через пробел
             */
            
            f.Close();
            ourHistory.Add("Матрица сохранена по адресу " + filename);
        }
    }
}
