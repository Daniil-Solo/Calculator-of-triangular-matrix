using System;
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

        public static double Determinant (Matrix A, ref History_message history)
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
        
        
        
        public static Matrix Reverse_A(Matrix A, Matrix C, ref History_message history)
        {
            double detA = Determinant(A, ref history);
            Matrix TempMatrix = new Matrix('C', A.N, A.V, A.Type, null);
            if (detA == Double.NaN)
            {
                return C;
            }
            else if (detA == 0)
            {
                history = history.Add("Определитель равен 0");
            }
            else
            {
                // Обратная матрица
                double[] packedForm = new double[A.N * (A.N + 1) / 2];
                for (int i = 0; i < A.N; i++)
                {
                    for (int j = 0; j < A.N; j++)
                    {
                        if(isV(i, j, A))
                        {
                            // пропускаем
                        }
                        else
                        {
                            packedForm[getIndexK(i, j, A)] = getReverseElement(i, j, A, detA);
                        }

                    }
                }

                     
            }
            return TempMatrix;   
        }
        
        public static double getReverseElement(int i, int j, Matrix A, double Det)
        {
            double result = 0;

            result *= Math.Pow(-1.0, i + j + 2);
            return result;
        }


    }

}
