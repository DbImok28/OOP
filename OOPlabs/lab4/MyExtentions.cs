using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    static class MyExtentions
    {
        public static void SplitString(this string str, int length)
        {
            str.Take(length);
        }
        public static int ElementsCount(this MyList<int> list)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                count += list[i];
            }
            return count;
        }
    }
}
