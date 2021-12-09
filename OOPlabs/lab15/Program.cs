using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab15
{
    class Program
    {
        public static void PrintSimpleNumber(int max)
        {
            using (var f = new StreamWriter("simple.txt"))
            {
                bool isSimle = false;
                for (int i = 2; i < max; i++)
                {
                    isSimle = true;
                    for (int j = 2; j < i / 2; j++)
                    {
                        if (i % j == 0)
                        {
                            isSimle = false;
                        }
                    }
                    if (isSimle)
                    {
                        Console.WriteLine(i);
                        f.WriteLine(i);
                    }
                }
            }
        }
        public static void VeryHardCalculations(int hard, bool even)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == (even ? 0 : 1))
                {
                    Thread.Sleep(hard);
                    Console.WriteLine(i);
                }
            }
        }
        private static object locker = new object();
        private static int nextNum = 0;
        public static void PrintTo(int max)
        {
            while (nextNum < max)
            {
                lock (locker)
                {
                    Console.WriteLine(++nextNum);   
                }
            }
        }

        static void Main(string[] args)
        {
            // 1
            Process[] proc = Process.GetProcesses();
            foreach (var item in proc)
            {
                //Console.WriteLine($"Name: {item.ProcessName}, Priority:{item.BasePriority}, StartTime:{item.StartTime}, StartTime{item.TotalProcessorTime}");
                Console.WriteLine($"Name: {item.ProcessName}, Priority: {item.BasePriority}");
            }

            // 2
            AppDomain dom = AppDomain.CurrentDomain;
            Console.WriteLine();
            Console.WriteLine($"Name: {dom.FriendlyName}, Dir: {dom.BaseDirectory}");

            AppDomain newDom = AppDomain.CreateDomain("MyDom");
            newDom.Load(dom.GetAssemblies()[0].GetName());

            AppDomain.Unload(newDom);

            // 3
            Console.WriteLine("Simple numbers to: ");
            var num = Convert.ToInt32(Console.ReadLine());
            var th1 = new Thread(() => PrintSimpleNumber(num));
            th1.Start();

            // 4
            Console.WriteLine($"Name: {th1.Name}, Priority: {th1.Priority}");
            th1.Join();

            // 5
            Console.WriteLine();
            var th_hard1 = new Thread(() => VeryHardCalculations(100, true));
            var th_hard2 = new Thread(() => VeryHardCalculations(130, false));
            th_hard1.Start();           
            th_hard2.Start();
            th_hard1.Join();
            th_hard2.Join();

            // 6
            Console.WriteLine();
            var th_to1 = new Thread(() => PrintTo(20));
            var th_to2 = new Thread(() => PrintTo(20));
            th_to1.Start();
            th_to2.Start();
            th_to1.Join();
            th_to2.Join();

            // 7
            TimerCallback tm = new TimerCallback((o) => Console.WriteLine($"time, {o}"));
            Timer timer = new Timer(tm, "hello", 0, 2000);
            Console.ReadKey();
        }
    }
}