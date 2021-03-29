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
                // место для вызова окошка с ошибкой 
                return;
            }
            success = Int32.TryParse(textBox_n.Text, out n);
            if (!success)
            {
                // место для вызова окошка с ошибкой 
                textBox_n.Text = "";
                return;
            }
            success = Double.TryParse(textBox_V.Text, out V);
            if (!success)
            {
                // место для вызова окошка с ошибкой 
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

            for (int i = 0; i < size; i++)
                packed_form[i] = 2*i;
            // Заполнение массива случайными значениями

            return packed_form;
        }
    }
}
