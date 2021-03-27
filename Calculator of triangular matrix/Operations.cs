using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_of_triangular_matrix
{
    class Operations
    {
        
        public static int Ind(int i, int j, Category type, int n)
        {
            int k=0;
            switch (type)
            {
                case Category.top_right:// правый верхний
                    k = n * i - i * (i - 1) / 2 + j;
                    break;
                case Category.top_left://левый верхний
                    k = n * i - i * (i + 1) / 2 + j;
                    break;
                case Category.bot_left://левый нижний
                    k = i * (i + 3) / 2 + j - n + 1;
                    break;
                case Category.bot_right://правый нижний
                    k = i * (i + 1) / 2 + j;
                    break;
            }
            return k;
        }


        public static Matrix Summ(Matrix A, Matrix B, Matrix C, History_message history)
        {
            if (A.Type == B.Type && A.N == B.N)
            {
                history.Add("Выполнение операции A+B");
                int sizePackedForm = A.N * (A.N + 1) / 2;
                Matrix Result = new Matrix('C', A.N, A.V + B.V, A.Type, new double[sizePackedForm]);
            
                for (int i = 0; i < sizePackedForm; i++)
                {
                    Result.Packed_form[i]=A.Packed_form[i]+B.Packed_form[i];
                }
                history.Add("Операция успешно выполнена");
                return Result;
            }
            else
            {
                history.Add("Не совпадает типы ил размерности матриц");
                return C;
            }
        }

     public static Matrix Subtraction(Matrix A, Matrix B)
        {

            if (A.Type == B.Type && A.N == B.N)
            {
                history.Add("Выполнение операции A-B");
                int sizePackedForm = A.N * (A.N + 1) / 2;
                Matrix Result = new Matrix('C', A.N, A.V-B.V, A.Type, new double[sizePackedForm]);

                for (int i = 0; i < sizePackedForm; i++)
                {
                    Result.Packed_form[i] = A.Packed_form[i]-B.Packed_form[i];
                }
                history.Add("Операция успешно выполнена");
                return Result;
            }
            else
            {
                history.Add("Не совпадает типы или размерности матриц");
                return C;
            }
        }

        public static Matrix Multiply(Matrix A, Matrix B)
        {
            /*Найти умножение матрицы
            Создать новую матрицу
            Через 1 функцию переводить i j в k
            Проверка принадлежносит элемента к значимым
            Если значимый то обращание к функции и брать из packed_form
            если нет то из v
            */
        }

        public static Matrix Reverse_A(Matrix A)
        {
            /*найти определитель матрицы
            если равен 0, то вывести сообщение 
            если не равен 0, то считаем обратную матрицу
            найти алгооритм*/
        }

        public static Matrix Reverse_B(Matrix B)
        {
        }

        public static void Replace_A_B(ref Matrix A,ref Matrix B)
        {
            Matrix C = A;
            A = B;
            B = C;
        }

        public static void Replace_A_C(ref Matrix A, ref Matrix C)
        {
            Matrix B = A;
            A = C;
            C = B;
        }

        public static void Replace_B_C(ref Matrix B, ref Matrix C)
        {
            Matrix A = B;
            B = C;
            C = A;
        }
    }
}
