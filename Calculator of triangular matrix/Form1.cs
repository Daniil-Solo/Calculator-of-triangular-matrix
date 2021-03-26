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
        
        public Main_menu()
        {
            InitializeComponent();
            Matrix A = new Matrix(0, 0, Category.none, null);
            Matrix B = new Matrix(0, 0, Category.none, null);
            Matrix C = new Matrix(0, 0, Category.none, null);
            History_message ourHistory = new History_message("Программа готова к работе");
            ourHistory = ourHistory.Add("Матрица успешно загружена");
            ourHistory = ourHistory.Add("Произошла ошибка при загрузке");
            message_history.Text = ourHistory.Print(3);
        }

        private void закрепитьПоверхДургихОконToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}
