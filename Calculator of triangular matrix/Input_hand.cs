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
        double[] packedForm = null;
        Matrix TempMatrix = new Matrix('_', 
                                        (int)DataTransfer.data[0], 
                                        (double)DataTransfer.data[1], 
                                        (Category)DataTransfer.data[2], 
                                       null);
        int globalStolbec = 0;
        int globalStroka = 0;
        
        public Input_hand()
        {
            InitializeComponent();

            packedForm = new double[TempMatrix.N * (TempMatrix.N + 1) / 2];
            for (int i = 0; i < TempMatrix.N * (TempMatrix.N + 1) / 2; i++)
                packedForm[i] = Double.NaN;
            createGridView();
            if (Operations.isV(globalStroka, globalStolbec, TempMatrix))
                globalStolbec = TempMatrix.N - 1;
            SelectElement(globalStroka, globalStolbec);
            ActiveControl = textBox_input;
        }

        private void button_ready_Click(object sender, EventArgs e)
        {
            bool success = true;
            int missIndex = -1;
            for (int i = 0; i < TempMatrix.N * (TempMatrix.N + 1) / 2 && success; i++)
            {
                if (Double.IsNaN(packedForm[i]))
                {
                    success = false;
                    missIndex = i;
                }
            }
            if (success)
            {
                DataTransfer.data[3] = packedForm;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Ошибка\nОбнаружена незаполненная ячейка");
                int[] missIndexes = GetMissIndexes(missIndex, TempMatrix);
                globalStroka = missIndexes[0];
                globalStolbec = missIndexes[1];
                SelectElement(globalStroka, globalStolbec);
            }
            
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            double Znachenie;
            bool success;
            success = Double.TryParse(textBox_input.Text, out Znachenie);
            if(!success)
            {
                MessageBox.Show("Ошибка!\nНе верное значение!");
                textBox_input.Text = "";
                textBox_input.Focus();
                return;
            }
            dataGridView[globalStolbec, globalStroka].Value = Znachenie;
            packedForm[Operations.getIndexK(globalStroka, globalStolbec, TempMatrix)] = Znachenie;
            globalStolbec++;
            if(globalStolbec == TempMatrix.N || Operations.isV(globalStroka, globalStolbec, TempMatrix))
            {
                globalStolbec = 0;
                globalStroka++;
                if(globalStroka == TempMatrix.N)
                {
                    globalStroka--;
                    globalStolbec = TempMatrix.N - 1;
                    if (Operations.isV(globalStroka, globalStolbec, TempMatrix))
                        globalStolbec = 0;
                }
                else if (Operations.isV(globalStroka, globalStolbec, TempMatrix))
                {
                    while (Operations.isV(globalStroka, globalStolbec, TempMatrix))
                    {
                        globalStolbec++;
                    }
                }
            }
            SelectElement(globalStroka, globalStolbec);
            textBox_input.Focus();
            textBox_input.SelectionStart = 0;
            textBox_input.SelectionLength = textBox_input.Text.Length;
        }
        

        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object head = this.dataGridView.Rows[e.RowIndex].HeaderCell.Value;
            if (head == null)
                this.dataGridView.Rows[e.RowIndex].HeaderCell.Value =
                    (e.RowIndex).ToString();
        }

        private void button_up_Click(object sender, EventArgs e)
        {
            if (globalStroka != 0)
            {
                globalStroka--;
                if(Operations.isV(globalStroka, globalStolbec, TempMatrix))
                {
                    globalStroka++;
                }
                else
                {
                    SelectElement(globalStroka, globalStolbec);
                }
                
            }
            
        }

        private void button_right_Click(object sender, EventArgs e)
        {
            if (globalStolbec != TempMatrix.N-1)
            {
                globalStolbec++;
                if (Operations.isV(globalStroka, globalStolbec, TempMatrix))
                {
                    globalStolbec--;
                }
                else
                {
                    SelectElement(globalStroka, globalStolbec);
                }
            }
        }

        private void button_down_Click(object sender, EventArgs e)
        {
            if (globalStroka != TempMatrix.N - 1)
            {
                globalStroka++;
                if (Operations.isV(globalStroka, globalStolbec, TempMatrix))
                {
                    globalStroka--;
                }
                else
                {
                    SelectElement(globalStroka, globalStolbec);
                }
            }
        }

        private void button_left_Click(object sender, EventArgs e)
        {
            if (globalStolbec != 0)
            {
                globalStolbec--;
                if (Operations.isV(globalStroka, globalStolbec, TempMatrix))
                {
                    globalStolbec++;
                }
                else
                {
                    SelectElement(globalStroka, globalStolbec);
                }
            }
        }

        private void createGridView()
        {
            DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[TempMatrix.N];
            for (int i = 0; i < TempMatrix.N; i++)
            {
                column[i] = new DataGridViewTextBoxColumn(); // выделяем память для объекта
                column[i].HeaderText = i.ToString();
                column[i].Name = i.ToString();
            }
            // задание новой
            this.dataGridView.Columns.AddRange(column); // добавление столбцов
            for (int i = 0; i < TempMatrix.N; i++)
            {
                object[] row = new object[TempMatrix.N];
                for (int j = 0; j < TempMatrix.N; j++)
                    if (Operations.isV(i, j, TempMatrix))
                        row[j] = TempMatrix.V;
                dataGridView.Rows.Add(row);// добавление строк
            }
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void SelectElement(int stroka, int stolbec)
        {
            dataGridView.CurrentCell = dataGridView.Rows[stroka].Cells[stolbec];
            labelElement.Text = "A[" + globalStroka.ToString() + "][" + globalStolbec.ToString() + "]=";
        }

        private void Input_hand_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)
            {
                button_right_Click(sender, e);
                SelectElement(10, 10);
            }
            else if(e.KeyCode == Keys.Left)
            {
                button_left_Click(sender, e);
            }
            else if(e.KeyCode == Keys.Down)
            {
                button_down_Click(sender, e);
            }
            else if(e.KeyCode == Keys.Up)
            {
                button_up_Click(sender, e);
            }
        }


        private int[] GetMissIndexes(int k, Matrix M)
        {
            bool notfound = true;
            int[] result = new int[2];
            for(int i = 0; i < M.N && notfound; i++)
                for(int j = 0; j < M.N && notfound; j++)
                {
                    if(!Operations.isV(i, j, M) && k == Operations.getIndexK(i, j, M))
                    {
                        result[0] = i;
                        result[1] = j;
                        notfound = false;
                    }
                }
            return result;
        }

        private void textBox_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_add_Click(sender, e);
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (MouseButtons != System.Windows.Forms.MouseButtons.None)
                SelectElement(globalStroka, globalStolbec);
        }

        private void Input_hand_Load(object sender, EventArgs e)
        {
        }
    }
}
