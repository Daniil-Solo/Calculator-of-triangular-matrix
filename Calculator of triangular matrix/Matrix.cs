using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_of_triangular_matrix
{
    class Matrix
    {
        int n;
        double V;
        char type;  //----------------------------------------FIX ME
        double[] packed_form;
        DataTable table;
        
        public Matrix()
        {
            this.n = 0;
            this.V = 0;
            this.type = '0'; //---------------------------------FIX ME
            this.packed_form = null;
            this.table = null;
        }

        public static Matrix New_m(int sp, char name_m)
        {
            //--------------------------------------------------FIX ME
        }
    }
}
