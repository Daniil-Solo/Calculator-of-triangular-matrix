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

        // Конструктор    
        public Matrix(char name, int n, double V, Category type, double[] packed_form)
        {
            this.name = name;
            this.n = n;
            this.v = V;
            this.type = type;
            this.packed_form = packed_form;
        }

        // Аксессоры
        public char Name { get { return name; } }
        public int N { get { return n; } }
        public double V { get { return v; } set { v = value; } }
        public Category Type { get { return type; } set { type = value; } }
        public double[] Packed_form { get { return packed_form; } set { packed_form = value; } }
               
        
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
                ourHistory = ourHistory.Add("При открытии файла произошла ошибка " + filename);
                return;
            }
            int N;
            double V;
            Category Type;
            double[] PackedForm;
            bool success;
            
            success = Int32.TryParse(f.ReadLine().Trim(), out N);
            if (!success)
            {
                ourHistory = ourHistory.Add("Неверный формат размерности");
                f.Close();
                return;
            }
            if (N <= 1) 
            {
                ourHistory = ourHistory.Add("Размерность должна быть больше 1");
                f.Close();
                return;
            }
            DataTransfer.data[0] = N;
            success = Double.TryParse(f.ReadLine().Trim(), out V);
            if (!success)
            {
                ourHistory = ourHistory.Add("Неверный формат значения V");
                f.Close();
                return;
            }
            DataTransfer.data[1] = V;
            success = Category.TryParse(f.ReadLine().Trim(), out Type);
            if (!success || Type == Category.none)
            {
                ourHistory = ourHistory.Add("Неверный формат типа");
                f.Close();
                return;
            }
            DataTransfer.data[2] = Type;
            PackedForm = new double[N * (N + 1) / 2];
            int k = 0;
            Matrix Temp = new Matrix('_', N, V, Type, null);
            
            for (int i = 0; i < N; i++)
            {
                string line = f.ReadLine();
                if(line == null)
                {
                    ourHistory = ourHistory.Add("Недостаточно строк в файле");
                    f.Close();
                    return;
                }
                line = line.Trim();
                line = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ");
                string[] splittedStroka = line.Split(' ');
                for (int j = 0; j < N; j++)
                {
                    String strElement;
                    try
                    {
                        strElement = splittedStroka[j];
                    }
                    catch
                    {
                        ourHistory = ourHistory.Add("Недостаточно значений в строке " + (4+i).ToString());
                        f.Close();
                        return;
                    }
                    success = Double.TryParse(strElement, out V);
                    if (!success)
                    {
                        ourHistory = ourHistory.Add("Обнаружено значение, не являющееся числом: " + strElement + " в строке " + (4 + i).ToString());
                        f.Close();
                        return;
                    }
                    else
                    {
                        if (Operations.isV(i, j, Temp))
                        {
                            if((double)DataTransfer.data[1] == V)
                            {
                                // пропустить
                            }
                            else
                            {
                                ourHistory = ourHistory.Add("Ожидалось значение V, равное " +
                                    ((double)DataTransfer.data[1]).ToString() + ", а получено значение V, равное " +
                                    V.ToString() + " в строке: " + (4 + i).ToString());
                                f.Close();
                                return;
                            }
                        }
                        else
                        {
                            if (Math.Abs(V) <= 1E-12)
                            {
                                V = 0;
                            }
                            PackedForm[k] = V;
                            k++;
                        }
                    }
                }
                success = false;
                try
                {
                    String _ = splittedStroka[N];
                }
                catch
                {
                    success = true;
                }
                if (!success)
                {
                    ourHistory = ourHistory.Add("Имеются лишние значения в строке " + (4 + i).ToString());
                    f.Close();
                    return;
                }
            }
            if (f.ReadLine() != null)
            {
                ourHistory = ourHistory.Add("Имеются лишние строки в конце файла");
                f.Close();
                return;
            }
            DataTransfer.data[3] = PackedForm;
            f.Close();
        }

        // Сохранение матрицы частично реализовано в коде формы начального окна
        public void Save(string filename, ref History_message ourHistory)
        {
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

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double temp;
                    if(Operations.isV(i, j, this))
                    {
                        temp = V;
                        if (Math.Abs(V) <= 1E-12)
                        {
                            temp = 0;
                        }
                    }
                    else
                    {
                        temp = Packed_form[a];
                        if (Math.Abs(Packed_form[a]) <= 1E-12)
                        {
                            temp = 0;
                        }
                        a++;
                    }
                    f.Write(String.Format("{0:F13}", temp));
                    f.Write("\t");
                }
                f.WriteLine();
            }
            
            f.Close();
            ourHistory = ourHistory.Add("Матрица сохранена по адресу " + filename);
        }

    
           
    }
}
