using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_of_triangular_matrix
{
    class Matrix
    {
        private int n;
        private double v;
        private Category type;
        private double[] packed_form;
        private DataTable table;
        
        public Matrix(int n, double V, Category type, double[] packed_form)
        {
            this.n = n;
            this.v = V;
            this.type = type;
            this.packed_form = packed_form;
            this.table = null;
        }

        public int N { get; }
        public double V { get; }
        public Category Type { get; }
        public double[] Packed_form { get; }
        public DataTable Table { get; set; } 

        public static Matrix New_m(int sp, History_message Our_history)
        {
            DataTransfer.dataNull();
            switch (sp)
            {
                case 0: // c клавиатуры

                    // Form1.Hide()
                    // Form2.Show() - считываем инфу в DataTransfer
                    //      -> Form2.Hide()
                    //         Form3.Show() - считываем инфу в DataTransfer
                    //              -> Form3.Hide()
                    //                 Form1.Show()
                    break;
                case 1: // из текстового файла

                    // Вызов проводника
                    // Попытка считывания - обработчик исключения
                    // Считываем инфу в DataTransfer
                    // Или ничего не считываем
                    break;
                case 2: // случайным образом
                    // Form1.Hide()
                    // Form2.Show() - считываем инфу в DataTransfer
                    //      -> Form2.Hide()
                    //         Form3.Show() - считываем инфу в DataTransfer
                    //              -> Form3.Hide()
                    //                 Form1.Show()

                    break;
                default:


                    break;
            }
            if (DataTransfer.isFull())
            {
                // формируется сообщение об успешной записи
                // формируется сообщение о типе
                // добавление сообщения в Our_history
                int n = (int)DataTransfer.data[0];
                double v = (double)DataTransfer.data[1];
                Category type = (Category)DataTransfer.data[2];
                double[] packed_form = (double[])DataTransfer.data[3];
                Matrix tempMatrix = new Matrix(n, v, type, packed_form);
                return tempMatrix;
            }
            else
            {
                // формируется сообщение о неудаче
                // формируется сообщение о типе
                // добавление сообщения в Our_history
                return new Matrix(0, 0, Category.none, null);
            }
        }
    }
}
