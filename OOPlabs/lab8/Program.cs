using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab5;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            list.Add(2);
            list.Add(3);
            list.Add(5);
            if(list.Find(out int item, x => x % 2 == 0))
            {
                Console.WriteLine(item);
            }
            if (list.TryGet(out int item2, 4))
            {
                Console.WriteLine(item2);
            }

            MyList<Basketball> list2 = new MyList<Basketball>();
            list2.Add(new Basketball(200));
            list2.Add(new Basketball(600));
            list2.Add(new Basketball(1000));
            if (list2.Find(out var item3, x => x.Weight == 600))
            {
                Console.WriteLine(item);
            }

            list.Save("list.txt");
            MyList<int> list3 = new MyList<int>();
            list3.Load("list.txt", x => Convert.ToInt32(x));
            list3.Print();
            Console.ReadKey();
        }
    }
}
