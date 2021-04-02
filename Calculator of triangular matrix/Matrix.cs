using System;
using System.IO;
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
        public double v;
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

        // Создание матрицы с помощью файла
        public void OpenFromFileToDataTransfer(string filename, ref History_message ourHistory)
        {
            StreamReader f = null;
            try
            {
                f = new StreamReader(filename);
            }
            catch
            {
                ourHistory = ourHistory.Add("Ошибка при открытии файла " + filename);
                return;
            }
            int N;
            double V;
            Category Type;
            double[] PackedForm;
            bool success;
            
            success = Int32.TryParse(f.ReadLine(), out N);
            if (!success)
            {
                ourHistory = ourHistory.Add("Неверный формат размерности");
                return;
            }
            DataTransfer.data[0] = N;
            success = Double.TryParse(f.ReadLine(), out V);
            if (!success)
            {
                ourHistory = ourHistory.Add("Неверный формат значения V");
                return;
            }
            DataTransfer.data[1] = V;
            success = Category.TryParse(f.ReadLine(), out Type);
            if (!success || Type == Category.none)
            {
                ourHistory = ourHistory.Add("Неверный формат типа");
                return;
            }
            DataTransfer.data[2] = Type;
            PackedForm = new double[N * (N + 1) / 2];
            int k = 0;
            Matrix Temp = new Matrix('_', N, V, Type, null);
            try 
            {
                for (int i = 0; i < N; i++)
                {
                    string[] splittedStroka = f.ReadLine().Split(' ');
                    for (int j = 0; j < N; j++)
                    {
                        if(!Operations.isV(i, j, Temp))
                        {
                            V = Double.Parse(splittedStroka[j]);
                            PackedForm[k] = V;
                            k++;
                        }
                    } 
                }
            }
            catch
            {
                ourHistory = ourHistory.Add("Недостаточно строк в матрице");
                return;
            }
            DataTransfer.data[3] = PackedForm;
            f.Close();
            ourHistory = ourHistory.Add("Матрица сохранена по адресу " + filename);
        }

        // Сохранение матрицы частично реализовано в коде формы начального окна
        public void Save(string filename, ref History_message ourHistory)
        {
            ourHistory = ourHistory.Add("Сохранение матрицы " + name);
            StreamWriter f = null;
            try
            {
                f = new StreamWriter(filename);
            }
            catch
            {
                ourHistory = ourHistory.Add("Ошибка при сохранении");
                return;
            }
            f.WriteLine(Convert.ToString(n));
            f.WriteLine(Convert.ToString(v));
            f.WriteLine(type);

            int a=0;

            if(type==Category.bot_left)
            for (int i=0; i<n ; i++)
            {
                    for (int j = 0; j < n; j++)
                    {
                        if(j>=i)
                        {
                            f.Write(Convert.ToString(Packed_form[a]));
                            a++;
                        }
                       else
                            f.Write(Convert.ToString(v));
                        f.Write(Convert.ToString(" "));
                    }
                    f.WriteLine();
            }


            if (type == Category.top_left)
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j >= n-i-1)
                        {
                            f.Write(Convert.ToString(Packed_form[a]));
                            a++;
                        }
                        else
                            f.Write(Convert.ToString(v));
                        f.Write(Convert.ToString(" "));
                    }
                    f.WriteLine();
                }
                

            if (type == Category.bot_right)
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j < n-i)
                        {
                            f.Write(Convert.ToString(Packed_form[a]));
                            a++;
                        }
                        else
                            f.Write(Convert.ToString(v));
                        f.Write(Convert.ToString(" "));
                    }
                    f.WriteLine();
                }

            if (type == Category.top_right)
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j <= i)
                        {
                            f.Write(Convert.ToString(Packed_form[a]));
                            a++;
                        }
                        else
                            f.Write(Convert.ToString(v));
                        f.Write(Convert.ToString(" "));
                    }
                    f.WriteLine();
                }

            /*
             Добавить строки в файл с помощью f.WriteLine("Строка");
                Первая строка: размерность
                Вторая строка: значение V
                Третья строка: тип матрицы
                Следующую строки: строки с элементами через пробел
             */

            f.Close();
            ourHistory = ourHistory.Add("Матрица сохранена по адресу " + filename);
        }

    
           
    }
}
