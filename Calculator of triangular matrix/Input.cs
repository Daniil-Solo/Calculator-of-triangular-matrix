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


            success = Int32.TryParse(textBox_n.Text, out n);
            if(!success)
            {
                // окошко с ошибкой 
                textBox_n.Text = "";
                return;
            }
            success = Double.TryParse(textBox_V.Text, out V);
            if(!success)
            {
                // окно с ошибкой
                textBox_V.Text = "";
                return;
            }

            DataTransfer.data[0] = n;
            DataTransfer.data[1] = V;
            //DataTransfer.data[2] = type;

            // Открытие формы Input_hand
        }
    }
}
