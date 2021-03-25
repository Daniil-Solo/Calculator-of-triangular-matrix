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
                int sizePackedForm = A.N * (A.N + 1) / 2;
                Matrix Result = new Matrix('C', A.N, A.V + B.V, A.Type, new double[sizePackedForm]);
            
                for (int i = 0; i < sizePackedForm; i++)
                {
                    Result.Packed_form[i]=A.Packed_form[i]+B.Packed_form[i];
                }
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

            Matrix C = new Matrix
            {
                v = A.v,
                n = A.n,
                Type = A.Type
            };
            for (int i = 0; i < A.n; i++)
            {
                C.Packed_form[i] = A.Packed_form[i] - B.Packed_form[i];
            }
            return C;
        }

        public static Matrix Multiply(Matrix A, Matrix B)
        {

        }

        public static Matrix Reverse_A(Matrix A)
        {
        }

        public static Matrix Reverse_B(Matrix B)
        {
        }

        public static Matrix Replace_A_B(Matrix A, Matrix B)
        {
        }

        public static Matrix Replace_A_C(Matrix A, Matrix B)
        {
        }

        public static Matrix Replace_B_C(Matrix A, Matrix B)
        {
        }
    }
}
