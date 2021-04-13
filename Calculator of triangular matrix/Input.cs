﻿using System;
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

// Справка
        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void Input_Load(object sender, EventArgs e)
        {
            ActiveControl = comboBox_type;
            comboBox_type.SelectedIndex = 0;
        }

        private void button_make_Click(object sender, EventArgs e)
        {
            int n;
            double V;
            Category type;
            bool success;

            // проверяем категорию
            type = ServiceFunctions.TransformCategory(comboBox_type.SelectedIndex);
            success = type != Category.none;
            if (!success)
            {
                MessageBox.Show("Ошибка!\nНе выбран тип матрицы!");
                comboBox_type.Focus();
                return;
            }
            // проверяем введенную размерность
            success = Int32.TryParse(textBox_n.Text, out n);
            if(!success)
            {
                MessageBox.Show("Ошибка!\nНе верно введена размерность!");
                textBox_n.Text = "";
                textBox_n.Focus();
                return;
            }
            if (n <= 1)
            {
                MessageBox.Show("Ошибка!\nРазмерность должна быть больше 1!");
                textBox_n.Text = "";
                textBox_n.Focus();
                return;
            }
            // проверяем введенное значение V
            success = Double.TryParse(textBox_V.Text, out V);
            if(!success)
            {
                success = Double.TryParse(textBox_V.Text.Replace('.', ','), out V);
                if (!success)
                {
                    MessageBox.Show("Ошибка!\nНе верно введено значение V!");
                    textBox_V.Text = "";
                    textBox_V.Focus();
                    return;
                }
            }
            
            // Отправляем данные
            DataTransfer.data[0] = n;
            DataTransfer.data[1] = V;
            DataTransfer.data[2] = type;
            
            // уничтожаем текущую форму
            this.Dispose();
        }

        // обработка нажатий на кнопку энтер в элементах
        private void comboBox_type_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox_n.SelectionStart = 0;
                textBox_n.SelectionLength = textBox_n.Text.Length;
                textBox_n.Focus();
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
                button_make_Click(sender, e);
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Triangular matrix help.chm");
        }

        private void способыВводаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpNavigator navigator = HelpNavigator.Topic;
            Help.ShowHelp(this, "Triangular matrix help.chm", navigator, "Newtopic10.htm");
        }

        private void типМатрицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpNavigator navigator = HelpNavigator.Topic;
            Help.ShowHelp(this, "Triangular matrix help.chm", navigator, "Newtopic4.htm");
        }

        private void размерностьМатрицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpNavigator navigator = HelpNavigator.Topic;
            Help.ShowHelp(this, "Triangular matrix help.chm", navigator, "Newtopic3.htm");
        }

        private void значениеVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpNavigator navigator = HelpNavigator.Topic;
            Help.ShowHelp(this, "Triangular matrix help.chm", navigator, "V.htm");
        }
    }
}
