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
    public partial class Input_keyb : Form
    {

        public Input_keyb()
        {
            InitializeComponent();
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void Input_Load(object sender, EventArgs e)
        {

        }

        private void button_make_Click(object sender, EventArgs e)
        {
            int n;
            double V;
            Category type;
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
            if(!success)
            {
                MessageBox.Show("Ошибка!\nНе верно введена размерность!");
                textBox_n.Text = "";
                return;
            }
            success = Double.TryParse(textBox_V.Text, out V);
            if(!success)
            {
                MessageBox.Show("Ошибка!\nНе верно введено значение V!");
                textBox_V.Text = "";
                return;
            }

            DataTransfer.data[0] = n;
            DataTransfer.data[1] = V;
            DataTransfer.data[2] = type;

            // Открытие формы Input_hand
            this.Dispose();
        }
        public void textBox_n_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_V_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
