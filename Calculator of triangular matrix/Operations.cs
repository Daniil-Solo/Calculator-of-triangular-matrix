﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_of_triangular_matrix
{
    class Operations
    {
//-------------- Функция для получения индекса к в сжатой форме--------------
// Предупреждение: функция корректно работает, если M[i, j] является значимым
// Принимает на вход i, j - номер строки и столбца в матрице, саму матрицу
// Возвращает индекс элемента в сжатой форме матрицы

        public static int getIndexK(int i, int j, Matrix M)
        {
            if (M.Type == Category.bot_left)
            {
                return M.N * i - i * (i + 1) / 2 + j;
            }
            else if (M.Type == Category.top_right)
            {
                return i * (i + 1) / 2 + j;
            }
            else if (M.Type == Category.bot_right)
            {
                return M.N * i - i * (i - 1) / 2 + j;
            }
            else if (M.Type == Category.top_left)
            {
                return (i + 1) * i / 2 + j - (M.N - i - 1);
            }
            else
            {
                return -1;
            }
        }

//-------------- Функция для проверки элемента на значимость--------------
// Принимает на вход i, j - номер строки и столбца в матрице, саму матрицу
// Возвращает true, если элемент M[i, j] должен быть НЕЗНАЧИМЫМ
// Возвращает false, если элемент M[i, j] должен быть ЗНАЧИМЫМ

        public static bool isV(int i, int j, Matrix M)
        {
            if (M.Type == Category.bot_left)
            {
                return (j < i);
            }
            else if (M.Type == Category.top_right)
            {
                return !(j < i + 1);
            }
            else if (M.Type == Category.bot_right)
            {
                return !(j < M.N - i);
            }
            else if (M.Type == Category.top_left)
            {
                return (j < M.N - i - 1);
            }
            else
            {
                return false;
            }
        }

//-------------- Функция для возвращения значения элемента матрицы--------------
// Принимает на вход i, j - номер строки и столбца в матрице, саму матрицу
// Возвращает значение элемента из сжатой формы матрицы М

        public static double getElement(int i, int j, Matrix M)
        {
            if (M.Type == Category.bot_left)
            {
                if (j < i)
                {
                    return M.V;
                }
                else
                {
                    int k = M.N * i - i * (i + 1) / 2 + j; // выведенная формула
                    return M.Packed_form[k];
                }
            }
            else if (M.Type == Category.top_right)
            {
                if (j < i + 1)
                {
                    int k = i * (i + 1) / 2 + j; // выведенная формула
                    return M.Packed_form[k];
                }
                else
                {
                    return M.V;
                }
            }
            else if (M.Type == Category.bot_right)
            {
                if (j < M.N - i)
                {
                    int k = M.N * i - i * (i - 1) / 2 + j;// выведенная формула
                    return M.Packed_form[k];
                }
                else
                {
                    return M.V;
                }
            }
            else if (M.Type == Category.top_left)
            {
                if (j < M.N - i - 1)
                {
                    return M.V;
                }
                else
                {
                    int k = (i + 1) * i / 2 + j - (M.N - i - 1); // выведенная формула
                    return M.Packed_form[k];
                }
            }
            else
            {
                return Double.NaN;
            }
        }

//-------------- Функция суммирования матриц А и В--------------
// Предупреждение: История сообщений передается по ссылке, так как она изменяется
// Принимает на вход матрицы A, B, C, историю сообщений
// Возвращает результат сложения двух матриц, если равны размерности и типы матриц A, B
// Возвращает матрицу С, если не совпадают размерности или типы матриц A, B
       
        public static Matrix Summ(Matrix A, Matrix B, Matrix C, ref History_message history)
        {
            if (A.Type == B.Type && A.N == B.N)
            {
                history = history.Add("Выполнение операции A+B");
                int sizePackedForm = A.N * (A.N + 1) / 2;
                Matrix Result = new Matrix('C', A.N, A.V + B.V, A.Type, new double[sizePackedForm]);
            
                for (int i = 0; i < sizePackedForm; i++)
                {
                    Result.Packed_form[i] = A.Packed_form[i] + B.Packed_form[i];
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

//-------------- Функция разности матриц А и В--------------
// Предупреждение: История сообщений передается по ссылке, так как она изменяется
// Принимает на вход матрицы A, B, C, историю сообщений
// Возвращает результат вычитания двух матриц, если равны размерности и типы матриц A, B
// Возвращает матрицу С, если не совпадают размерности или типы матриц A, B

        public static Matrix Subtraction(Matrix A, Matrix B, Matrix C, ref History_message history)
        {

            if (A.Type == B.Type && A.N == B.N)
            {
                history = history.Add("Выполнение операции A-B");
                int sizePackedForm = A.N * (A.N + 1) / 2;
                Matrix Result = new Matrix('C', A.N, A.V-B.V, A.Type, new double[sizePackedForm]);

                for (int i = 0; i < sizePackedForm; i++)
                {
                    Result.Packed_form[i] = A.Packed_form[i] - B.Packed_form[i];
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

//-------------- Функция умножения матриц А и В--------------
// Предупреждение: История сообщений передается по ссылке, так как она изменяется
// Принимает на вход матрицы A, B, C, историю сообщений
// Возвращает результат умножения двух матриц, если равны размерности и типы матриц A, B и при этом значения V равны 0
// Возвращает матрицу С, если не совпадают размерности или типы матриц A, B        

         public static Matrix Multiply(Matrix A, Matrix B, Matrix C, ref History_message history)
         {
            history = history.Add("Выполнение операции A*B");
            if ((A.Type == B.Type) && (A.N == B.N) && (B.V == 0) && (A.V == 0))
	        {
                int sizePackedForm = A.N * (A.N + 1) / 2;
                Matrix Result = new Matrix('C', A.N, A.V, A.Type, new double[sizePackedForm]);
                for (int i = 0; i < Result.N; i++)
                    for (int j = 0; j < Result.N; j++)
                    {
                        if(!isV(i, j, Result))
                        {
                            Result.Packed_form[getIndexK(i, j, Result)] = 0;
                            for (int k = 0; k < Result.N; k++)
                            {
                                double aik = 0, bkj = 0;
                                if (!isV(i, k, A))
                                {
                                    aik = getElement(i, k, A);
                                }
                                if (!isV(k, j, B))
                                {
                                    bkj = getElement(k, j, B);
                                }
                                Result.Packed_form[getIndexK(i, j, Result)] += aik * bkj;
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

//-------------- Функция нахождения определителя матрицы --------------
// Предупреждение: История сообщений передается по ссылке, так как она изменяется
// Принимает на вход матрицы A, историю сообщений
// Возвращает определитель матрицы, если тип не nonе и V равно 0
// Возвращает Nan, если не известен тип или V не равно 0        

        public static double DeterminantR (Matrix A, ref History_message history)
        {
            double Det = 1;
            history = history.Add("Выполнение операции |A|");
            if (A.Type == Category.none)
            {
                history = history.Add("Матрица не определена");
                return Double.NaN;
            }
            else
            {
                if (A.V != 0)
                {
                    history = history.Add("Значение V должно быть равно 0");
                    return Double.NaN;
                }
                else
                {
                    if (A.Type == Category.bot_left || A.Type == Category.top_right)
                    {
                        for (int i = 0; i < A.N; i++)
                            Det *= getElement(i, i, A);
                        return Det;
                    }
                    else
                    {
                        for (int i = 0; i < A.N; i++)
                            Det *= getElement(A.N - 1 - i, i, A);
                        return Det * -1;
                    }
                }
            }
           

                
        }

//-------------- Функция перестановки матриц --------------
// Предупреждение: История сообщений и матрицы передаются по ссылке, так как они изменяются
// Принимает на вход 2 матрицы, историю сообщений
// Возвращает определитель матрицы, если тип не nonе и V равно 0
// Возвращает Nan, если не известен тип или V не равно 0     
        public static void Replace_A_B(ref Matrix A,ref Matrix B, ref History_message history)
        {
            history = history.Add("Выполнение операции " + A.Name + "<->" + B.Name);
            Matrix C = A;
            A = new Matrix(A.Name, B.N, B.V, B.Type, B.Packed_form);
            B = new Matrix(B.Name, C.N, C.V, C.Type, C.Packed_form);
            history = history.Add("Операция успешно выполнена");
        }


        public static Matrix Reverse(Matrix A, Matrix C, ref History_message history)
        {
            double detA = DeterminantR(A, ref history);
            double[, ] TempMatrica;
            if (detA == Double.NaN)
            {
                return C;
            }
            else if (detA == 0)
            {
                history = history.Add("Определитель равен 0");
                return C;
            }
            else
            {
                history = history.Add("Определитель равен " + detA.ToString());
                TempMatrica = getMatricaFromMatrix(A);
                double[,] ResultMatrica = new double[A.N, A.N];
                for (int i = 0; i < A.N; i++)
                {
                    for (int j = 0; j < A.N; j++)
                    {
                          ResultMatrica[i, j] = Math.Pow(-1.0, i + j + 2) * 
                            Determinant(getMatricaFromMatrica(i, j, TempMatrica, A.N-1), A.N-1) / detA;
                    }
                }

                Matrix TempMatrix = new Matrix('C', A.N, A.V, A.Type, null);
                history = history.Add("Операция успешно выполнена");
                ResultMatrica = getTMatrica(ResultMatrica, A.N);

                if (A.Type == Category.top_left)
                    TempMatrix.Type = Category.bot_right;
                else if (A.Type == Category.bot_right)
                    TempMatrix.Type = Category.top_left;

                TempMatrix.Packed_form = PackMatrica(TempMatrix, ResultMatrica);
                return TempMatrix;
            }
              
        }
        public static double[, ] getTMatrica(double[, ] matrix, int n)
        {
            for (int i = 0; i < n; i++)
                for (int j = i; j < n; j++)
                {
                    double temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }
            return matrix;
        }
        public static double[,] getMatricaFromMatrix(Matrix A)
        {
            double[,] matrix = new double[A.N, A.N];
            for (int tempi = 0; tempi < A.N; tempi++)
                for (int tempj = 0; tempj < A.N; tempj++)
                    matrix[tempi, tempj] = getElement(tempi, tempj, A);
            return matrix;
        }
        public static double Determinant(double[,] matrix, int n)
        {
            if (n == 1)
                return matrix[0, 0];
            else if (n == 2)
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            else
            {
                int pow = 1;
                double result = 0;
                for(int i = 0; i < n; i++)
                {
                    result += pow * matrix[0, i] * Determinant(getMatricaFromMatrica(0, i, matrix, n-1), n-1);
                    pow = -pow;
                }
                return result;
            }
        }
        public static double[,] getMatricaFromMatrica(int i, int j, double[, ] matrix, int n)
        { 
            int reali = 0, realj = 0;
            double[,] matrixResult = new double[n, n];
            for(int tempi = 0; tempi < n+1; tempi++)
            {
                if(tempi == i)
                {
                    // пропускаем
                }
                else
                {
                    for (int tempj = 0; tempj < n+1; tempj++)
                    {
                        if (tempj == j)
                        {
                            // пропускаем
                        }
                        else
                        {
                            matrixResult[reali, realj] = matrix[tempi, tempj];
                            realj++;
                        }
                    }
                    realj = 0;
                    reali++;
                }
            }
            return matrixResult;
        }

        public static double[] PackMatrica(Matrix M, double[,] ResultMatrica)
        {
            double[] packedForm = new double[M.N * (M.N + 1) / 2];
            int k = 0;
            for (int i = 0; i < M.N; i++)
                for (int j = 0; j < M.N; j++)
                {
                    if (isV(i, j, M))
                    {
                        // пропустить
                    }
                    else
                    {
                        packedForm[k] = ResultMatrica[i, j];
                        k++;
                    }
                }
            return packedForm;
        }

    }

}
