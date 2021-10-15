using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public class Matrix
    {
        public Matrix(int[,] mat)
        {
            if(mat == null)
            {
                throw new ArgumentNullException(nameof(mat));
            }
            if(mat.Length == 0)
            {
                throw new ArgumentException("array is empty");
            }
            Mat = mat;
        }
        public int this[int i, int j]
        {
            get
            {
                if(i < 0 || j < 0 || i*j > Mat.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return Mat[i, j];
            }
            set
            {
                if (i < 0 || j < 0 || i * j > Mat.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                Mat[i, j] = value;
            }
        }
        public int[,] Mat { get; set; }
    }
}
