using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab3;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Bus bus1 = new Bus("Pasa", 1, new DateTime(2020, 6, 20));
            Bus bus2 = new Bus("Lexa", 2, new DateTime(2020, 6, 23));
            Bus busNow = bus1.GetBusNow();
            Console.WriteLine(bus1.Number);
            DateTime endTime;
            bus1.StartOut(out endTime);
            Console.WriteLine(endTime);
            Console.WriteLine(bus1.Equals(bus2));
            Console.WriteLine(bus1 is Bus);

            //2
            Bus[] buses = new Bus[] {new Bus("Vlad", 3, new DateTime(2020, 3, 20)), new Bus("Sana", 4, new DateTime(2020, 2, 20)), new Bus("Peta", 5, new DateTime(2020, 2, 21)) };

            int num = Convert.ToInt32(Console.ReadLine());
            foreach (var item in buses)
            {
                if(item.Number == num)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            DateTime time = Convert.ToDateTime(Console.ReadLine());
            foreach (var item in buses)
            {
                if (item.Time < time)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            //3
            var bus3 = new { Name = "Tom", Number = 8 };
            Console.WriteLine(bus3.GetType());
            Console.WriteLine($"Name: {bus3.Name}, Number: {bus3.Number}");
            Console.ReadKey();
        }
    }
}
