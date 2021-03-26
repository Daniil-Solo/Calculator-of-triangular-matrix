using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_of_triangular_matrix
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_menu());
        }
    }
    public static class DataTransfer
    {
        public static object[] data;
        
        public static void dataNull()
        {
            for (int i = 0; i < 4; i++)
                data[i] = null;
        }
        public static bool isFull()
        {
            bool result = true;
            for (int i = 0; i < 4; i++)
                result &= (data[i] != null);
            return result;
        }
    }
}
