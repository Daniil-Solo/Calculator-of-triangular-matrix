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
    public partial class Input_rand : Form
    {
        public Input_rand()
        {
            InitializeComponent();
            
        }
        private void Input_rand_Load(object sender, EventArgs e)
        {
            ActiveControl = comboBox_type;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }
        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button_ready_Click(object sender, EventArgs e)
        {
            int n;
            double V;
            Category type;
            double[] packed_form;
            bool success;

            // проверяем категорию
            type = TransformCategory(comboBox_type.SelectedIndex);
            success = type != Category.none;
            if (!success)
            {
                MessageBox.Show("Ошибка!\nНе выбран тип матрицы!");
                comboBox_type.Focus();
                return;
            }
            // проверяем введенную размерность
            success = Int32.TryParse(textBox_n.Text, out n);
            if (!success)
            {
                MessageBox.Show("Ошибка!\nНе верно введена размерность!");
                textBox_n.Text = "";
                textBox_n.Focus();
                return;
            }
            success = Double.TryParse(textBox_V.Text, out V);
            if (!success)
            {
                MessageBox.Show("Ошибка!\nНе верно введено значение V!");
                textBox_V.Text = "";
                textBox_V.Focus();
                return;
            }

            // заполнение случайными значениями
            packed_form = rand_array(n * (n + 1) / 2);

            // Отправка данных
            DataTransfer.data[0] = n;
            DataTransfer.data[1] = V;
            DataTransfer.data[2] = type;
            DataTransfer.data[3] = packed_form;

            // Возвращение на старую форму
            this.Dispose();
        }
        private double[] rand_array(int size)
        {
            double[] packed_form = new double[size];
            Random rnd = new Random(); //Создание объекта для генерации чисел

            for (int i = 0; i < size; i++) // Заполнение массива случайными значениями
            {
                packed_form[i] = (double) rnd.Next()/1000d;
                if( rnd.Next(1,3) == 1 )
                    packed_form[i] = -packed_form[i];
            }

            return packed_form;
        }
        private Category TransformCategory(int index)
        {
            if (index == 0)
            {
                return Category.bot_right;
            }
            else if (index == 1)
            {
                return Category.top_right;
            }
            else if (index == 2)
            {
                return Category.bot_left;
            }
            else if (index == 3)
            {
                return Category.top_left;
            }
            else
            {
                return Category.none;
            }
        }


        private void textBox_n_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox_V.SelectionStart = 0;
                textBox_V.SelectionLength = textBox_V.Text.Length;
                textBox_V.Focus();
            }
        }
        private void textBox_V_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_ready_Click(sender, e);
            }
        }

        private void comboBox_type_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox_n.SelectionStart = 0;
                textBox_n.SelectionLength = textBox_n.Text.Length;
                textBox_n.Focus();
            }
        }
    }
}
