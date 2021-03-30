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

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label_n_Click(object sender, EventArgs e)
        {

        }

        private void button_ready_Click(object sender, EventArgs e)
        {
            int n;
            double V;
            Category type;
            double[] packed_form;
            bool success;

            // проверка на условие принадлежности категории
            switch (comboBox_type.SelectedIndex)
            {
                case 0:
                    success = true;
                    type = Category.bot_right;
                    break;
                case 1:
                    success = true;
                    type = Category.top_right;
                    break;

                case 2:
                    success = true;
                    type = Category.bot_left;
                    break;

                case 3:
                    success = true;
                    type = Category.top_left;
                    break;
                default:
                    success = false;
                    type = Category.none;
                    break;
            }
            if (!success)
            {
                MessageBox.Show("Ошибка!\nНе выбран тип матрицы!");
                return;
            }
            success = Int32.TryParse(textBox_n.Text, out n);
            if (!success)
            {
                MessageBox.Show("Ошибка!\nНе верно введена размерность!");
                textBox_n.Text = "";
                return;
            }
            success = Double.TryParse(textBox_V.Text, out V);
            if (!success)
            {
                MessageBox.Show("Ошибка!\nНе верно введено значение V!");
                textBox_V.Text = "";
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
            double x;

            for (int i = 0; i < size; i++) // Заполнение массива случайными значениями
            {
                packed_form[i] = (double) rnd.Next()/1000d;
                if( rnd.Next(1,4) == 1 )
                    packed_form[i] = -packed_form[i];
            }

            return packed_form;
        }

        private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
