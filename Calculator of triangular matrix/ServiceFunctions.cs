using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_of_triangular_matrix
{
    static class ServiceFunctions
    {

        // функция удаления нулей на конце числа при выводе
        public static String DeletZerosInEndString(String fullForm)
        {
            int n = fullForm.Length;
            String result = "";
            int index = fullForm.IndexOf(',');
            if(index < 0)
                return fullForm;
            for (int i = fullForm.Length-1; i >= index; i--)
            {
                if (fullForm[i] == '0')
                    n--;
                else
                    break;
            }
            if (index == n - 1)
                n--;
            for (int i = 0; i < n; i++)
                result += fullForm[i];
            return result;  
        }
        //1,34000
        // index = 1
        // n = 4

        // функция для возвращения типа исходя из индекса
        public static Category TransformCategory(int index)
        {
            if (index == 0)
            {
                return Category.bot_right;
            }
            else if (index == 1)
            {
                return Category.top_right;
            }
            else if (index == 2)
            {
                return Category.bot_left;
            }
            else if (index == 3)
            {
                return Category.top_left;
            }
            else
            {
                return Category.none;
            }
        }

        // функция для возвращения пропущенных индексов
        public static int[] GetMissIndexes(int k, Matrix M)
        {
            bool notfound = true;
            int[] result = new int[2];
            for (int i = 0; i < M.N && notfound; i++)
                for (int j = 0; j < M.N && notfound; j++)
                {
                    if (!Operations.isV(i, j, M) && k == Operations.getIndexK(i, j, M))
                    {
                        result[0] = i;
                        result[1] = j;
                        notfound = false;
                    }
                }
            return result;
        }

        // функция для возвращения массива со случайными значениями в указанном диапзоне
        public static double[] rand_array(int size, double D1, double D2)
        {
            double[] packed_form = new double[size];
            Random rnd = new Random(); //Создание объекта для генерации чисел
            for (int i = 0; i < size; i++) // Заполнение массива случайными значениями
            {
                packed_form[i] = D1 + rnd.NextDouble() * (D2 - D1);
            }

            return packed_form;
        }
        // функция для возвращения русского названия типа
        public static string labelMatrix(Matrix M)
        {
            String str = "Тип: " + getRusType(M) + "\n\rРазмерность: ";
            if (M.N != 0)
                str += M.N.ToString();
            else
                str += "нет";
            return str;
        }
        public static string getRusType(Matrix M)
        {
            if (M.Type.ToString() == "top_left") return "Верхний-левый";
            else if (M.Type.ToString() == "top_right") return "Верхний-правый";
            else if (M.Type.ToString() == "bot_left") return "Нижний-левый";
            else if (M.Type.ToString() == "bot_right") return "Нижний-правый";
            else return "нет";
        }

        //проверка: 2 матрицы не пустые
        public static bool Check2Matrix(Matrix M, Matrix K) 
        {
            bool success = false;
            if ((M.Type != Category.none) && (K.Type != Category.none))
            { success = true; }
            return success;
        }
        //проверка: хотя бы 1 матрица не пустая
        public static bool Check1Matrix(Matrix M, Matrix K)
        { 
            bool success = false;
            if ((M.Type != Category.none) || (K.Type != Category.none))
            { success = true; }
            return success;
        }
        //проверка: 1 матрица не пустая
        public static bool CheckMatrix(Matrix M) 
        {
            bool success = false;
            if (M.Type != Category.none)
            { success = true; }
            return success;
        }
    }
}
