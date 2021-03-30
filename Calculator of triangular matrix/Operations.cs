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
                case Category.bot_left:// правый верхний
                    k = n * i - i * (i + 1) / 2 + j;
                    break;
                case Category.bot_right://левый верхний---------
                    k = i * (i + 3) / 2 + j - (n - 1);
                    break;
                case Category.top_right://левый нижний
                    k = i * (i + 1) / 2 + j;
                    break;
                case Category.top_left://правый нижний----------
                    k = n * i - i * (i - 1) / 2 + j;
                    break;
            }
            return k;
        }
        /*

        public static Matrix Summ(Matrix A, Matrix B, Matrix C, ref History_message history)
        {
            if (A.Type == B.Type && A.N == B.N)
            {
                history = history.Add("Выполнение операции A+B");
                int sizePackedForm = A.N * (A.N + 1) / 2;
                Matrix Result = new Matrix('C', A.N, A.V + B.V, A.Type, new double[sizePackedForm]);
            
                for (int i = 0; i < sizePackedForm; i++)
                {
                    Result.Packed_form[i]=A.Packed_form[i]+B.Packed_form[i];
                }
                history = history.Add("Операция успешно выполнена");
                return Result;
            }
            else
            {
                history = history.Add("Не совпадает типы ил размерности матриц");
                return C;
            }
        }

     public static Matrix Subtraction(Matrix A, Matrix B, Matrix C, ref History_message history)
        {

            if (A.Type == B.Type && A.N == B.N)
            {
                history = history.Add("Выполнение операции A-B");
                int sizePackedForm = A.N * (A.N + 1) / 2;
                Matrix Result = new Matrix('C', A.N, A.V-B.V, A.Type, new double[sizePackedForm]);

                for (int i = 0; i < sizePackedForm; i++)
                {
                    Result.Packed_form[i] = A.Packed_form[i]-B.Packed_form[i];
                }
                history = history.Add("Операция успешно выполнена");
                return Result;
            }
            else
            {
                history = history.Add("Не совпадает типы или размерности матриц");
                return C;
            }
        }

         public static Matrix Multiply(Matrix A, Matrix B, Matrix C, ref History_message history)
        {
            if (A.Type==B.Type && A.N==B.N && B.V == 0 && A.V==0)
	        {
                history = history.Add("Выполнение операции A*B");
                Matrix Result = new Matrix('C', A.N ,0, A.Type, new double[sizePackedForm]);

                for (int i = 0; i < Result.N; i++)
                    for (int j = 0; j < Result.N; j++)
                    {
                        if(Znach(i,j, Result.Type, Result.N))
                        {
                            Result.Packed_form[Ind(i, j, Result.Type, Result.N)] = 0;
                            for (int k = 0; k < Result.N; k++)
                            {
                                double aik = 0;
                                double  bkj = 0;
                                if (Znach(i, k, Result.Type, Result.N))
                                {
                                    aik = A.Packed_form[Ind(i, k, A.Type, A.N)];
                                }
                                if (Znach(k, j, Result.Type, Result.N))
                                {
                                    bkj = A.Packed_form[Ind(k, j, A.Type, A.N)];
                                }
                                Result.Packed_form[Ind(i, j, A.Type, A.N)] += aik * bkj;
                            }
                        }
                    }
                history = history.Add("Операция успешно выполнена");
                return Result;

    }

    else
            {
                history = history.Add("Не совпадают типы или размерности матриц или значения V не равны 0");
                return C;
            }
        }

        public static double Determinant (Matrix A, ref History_message history)
      {
            double Det = 1;
            if(A.Type == bot_left || A.Type== top_right)
            {
                if (A.Type == top_right)
                {
                    for (int i = 0; i < A.N*A.N; i += A.N + 1)
                        Det *= A.Packed_form[i];  
                }
                else
                {
                    int k = 2;
                    for (int i = 0; i < A.N * A.N; i += k)
                    {
                        Det *= A.Packed_form[i];
                        k++;
                    }
                }
                return Det;
            }
           else if (A.Type == bot_right || A.Type == top_left)
            {
                if (A.Type == top_left)
                {
                    for (int i = A.N - 1; i < A.N * A.N; i += A.N - 1)
                        Det *= A.Packed_form[i];
                }
                else
                {
                    int k = 1;
                    for (int i = 0; i < A.N * A.N; i += k)
                    {
                        Det *= A.Packed_form[i];
                        k++;
                    }
                }
                return Det * -1;
            }
            else
                history = history.Add("Матрица не определена");
            return None;
      }

        public static Matrix Reverse_A(Matrix A, Matrix C, ref History_message history)
        {
            найти определитель матрицы
            если равен 0, то вывести сообщение 
            если не равен 0, то считаем обратную матрицу
            найти алгооритм
        }

        public static Matrix Reverse_B(Matrix B, Matrix C, ref History_message history)
        {
        }

        public static void Replace_A_B(ref Matrix A,ref Matrix B, ref History_message history)
        {
            history = history.Add("Выполнение операции A<->B");
            Matrix C = A;
            A = B;
            B = C;
            history = history.Add("Операция успешно выполнена");
        }

        public static void Replace_A_C(ref Matrix A, ref Matrix C, ref History_message history)
        {
            history = history.Add("Выполнение операции A<->C");
            Matrix B = A;
            A = C;
            C = B;
            history = history.Add("Операция успешно выполнена");
        }

        public static void Replace_B_C(ref Matrix B, ref Matrix C, ref History_message history)
        {
            history = history.Add("Выполнение операции B<->C");
            Matrix A = B;
            B = C;
            C = A;
            history = history.Add("Операция успешно выполнена");
        }
        */
    }

}
