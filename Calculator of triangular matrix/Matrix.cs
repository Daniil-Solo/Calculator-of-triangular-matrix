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
    // Поля
        private char name;
        private int n;
        private double v;
        private Category type;
        private double[] packed_form;
        private DataTable table;
    
    // Конструктор    
        public Matrix(char name, int n, double V, Category type, double[] packed_form)
        {
            this.name = name;
            this.n = n;
            this.v = V;
            this.type = type;
            this.packed_form = packed_form;
            this.table = null;
        }

    // Аксессоры
        public char Name { get { return name; } }
        public int N { get { return n; } }
        public double V { get { return v; } }
        public Category Type { get { return type; } }
        public double[] Packed_form { get { return packed_form; } }
        public DataTable Table { get { return table; } set { table = value; } }

    // Методы

        // Создание матрицы
        // Принимает на вход способ создания, историю сообщения и имя матрицы
        // Возвращает ссылку на новую матрицу
        public static Matrix New_m(int sp, History_message Our_history, char name)
        {
            DataTransfer.dataNull();
            switch (sp)
            {
                case 0: // c клавиатуры

                    Our_history.Add("Матрица" + name + "успешно создана");
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
                    // pass
                    break;
            }
            if (DataTransfer.isFull())
            {
                Our_history.Add("Матрица успешно создана");
                int n = (int)DataTransfer.data[0];
                double v = (double)DataTransfer.data[1];
                Category type = (Category)DataTransfer.data[2];
                double[] packed_form = (double[])DataTransfer.data[3];
                Matrix tempMatrix = new Matrix(name, n, v, type, packed_form);
                return tempMatrix;
            }
            else
            {
                Our_history.Add("Матрица не создана");
                return new Matrix(name, 0, 0, Category.none, null);
            }
        }
    }
}
