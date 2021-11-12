using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class Program
    {
        public static void Print<T>(IEnumerable<T> coll)
        {
            foreach (var item in coll)
            {
                Console.Write(item);
                Console.Write(' ');
            }
            Console.WriteLine();
        }
        // 1
        static void Main(string[] args)
        {
            string[] months = new string[] {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            };
            var a1 = months.Where(x => x.Length == 4);
            var a2 = months.OrderBy(x=>x);
            var a3 = months.Where(x => x.Contains('u') && x.Length > 4);

            Print(a1);
            Print(a2);
            Print(a3);
            // 2
            List<Bus> buses = new List<Bus>
            {
                new Bus("b1", 1, new DateTime(2020,7,2)),
                new Bus("b2", 5, new DateTime(2020,5,13)),
                new Bus("b3", 3, new DateTime(2019,3,4)),
                new Bus("b4", 2, new DateTime(2019,2,4)),
                new Bus("b5", 5, new DateTime(2021,2,2)),
                new Bus("b6", 5, new DateTime(2021,2,2)),
                new Bus("b7", 1, new DateTime(2018,9,23)),
                new Bus("b8", 3, new DateTime(2021,1,8)),
                new Bus("b9", 4, new DateTime(2017,7,17)),
                new Bus("b10", 5, new DateTime(2015,1,18)),

            };
            /*
             * список автобусов для заданного номера маршрута; 
             * список автобусов, которые эксплуатируются больше заданного срока; 
             * минимальный по пробегу автобус 
             * последние два автобуса 
             * максимальные по пробегу 
             * упорядоченный список автобусов по номеру
            */
            var l1 = from bus in buses where bus.Number == 5 select bus;
            var l2 = buses.Where(x => x.Time > new DateTime(2020, 1, 1));
            var l3 = buses.Min(x => x.Time);
            var l4 = buses.Where((_, index) => index >= buses.Count-2);
            var l5 = buses.GroupBy(x=>x.Time).OrderByDescending(x=>x.Key).First();
            var l6 = buses.OrderBy(x => x.Number);
            Print(l1);
            Print(l2);
            Console.WriteLine(l3);
            Print(l4);
            Print(l5);
            Print(l6);


            var my = buses.GroupBy(x => x.Number).OrderByDescending(x => x.Key).Where(x => x.Key % 2 == 0).Last().Key;
            Console.WriteLine(my);

            var nums = new int[]{ 1,2,3};
            var m1 = buses.Join(nums, x => x.Number, x => x, (bus, num) => num.ToString() + " - " + bus.ToString() + "\n");
            Print(m1);
            //*
            Console.ReadKey();
        }
    }
}
