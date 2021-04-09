using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_of_triangular_matrix
{
    static class ServiceFunctions
    {
       public static String DeletZerosInEndString(String fullForm)
       {
            int n = fullForm.Length;
            String result = "";
            for (int i = fullForm.Length-1; i >= 0; i--)
            {
                if (fullForm[i] == '0')
                    n--;
                else
                    break;
            }
            // 12,100
            // 4
            for (int i = 0; i < n; i++)
                result += fullForm[i];
            if (n == 0)
                result = "0";
            return result;
       }
    }
}
