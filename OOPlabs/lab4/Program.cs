using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list1 = new MyList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);

            MyList<int> list2 = new MyList<int>();
            list2.Add(4);
            list2.Add(5);
            list2.Add(6);

            MyList<int> list = list1 + list2;
            list.Print();

            list[2] = 0;
            Console.WriteLine(list[2]);
            Console.WriteLine(list[4]);

            bool t = list1 < list2;
            Console.WriteLine(list1);
            Console.WriteLine(list2);

            string str = "hello";
            str.SplitString(3);
            Console.WriteLine(str);

            Console.WriteLine(list.ElementsCount());



            Console.ReadKey();
        }
    }
}
