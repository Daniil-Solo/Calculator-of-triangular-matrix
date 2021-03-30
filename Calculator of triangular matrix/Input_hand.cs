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
    public partial class Input_hand : Form
    {
        public Input_hand()
        {
            InitializeComponent();
        }

        private void button_ready_Click(object sender, EventArgs e)
        {
            int n = (int)DataTransfer.data[0];
            int size_packedform = n * (n + 1) / 2;
            DataTransfer.data[3] = new double[size_packedform];
            this.Dispose();
        }

        private void textBox_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Ошибка!\nНе верное значение!");
            //MessageBox.Show("Ошибка!\nВ этом месте уже стоит фиктивный элемент!");
        }
    }
}
