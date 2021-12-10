using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace lab16
{
    class Program
    {
        public static List<uint> SimpleNumbersEratosthenes(uint n)
        {
            var numbers = new List<uint>();
            for (var i = 2u; i < n; i++)
            {
                numbers.Add(i);
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2u; j < n; j++)
                {
                    numbers.Remove(numbers[i] * j);
                }
            }

            return numbers;
        }
        public static int Sum(int a, int b)
        {
            Thread.Sleep(100);
            return a + b;
        }
        public static int Multiply(int a, int b)
        {
            Thread.Sleep(200);
            return a * b;
        }
        public static int Div(int a, int b)
        {
            Thread.Sleep(400);
            return a / b;
        }
        public static void Supplier(ref BlockingCollection<string> coll, int waitTime, params string[] products)
        {
            Random r = new Random();
            while (true)
            {
                Thread.Sleep(waitTime);
                coll.Add(products[r.Next(0, products.Length)]);
            }
        }
        public static void Customer(ref BlockingCollection<string> coll, int waitTime)
        {
            Random r = new Random();
            string item;
            while (true)
            {
                Thread.Sleep(waitTime);

                if (coll.TryTake(out item))
                {
                    Console.WriteLine(item);
                }
                else
                {
                    Console.WriteLine("exit!!!");
                    break;
                }
            }
        }
        public static async Task<int> GetNumberAsynk()
        {
            return await GetNumber(10);
        }
        public static Task<int> GetNumber(int num)
        {
            return Task.Run(() =>
                {
                Thread.Sleep(100);
                return num;
                }
            );
        }
        public static void Main(string[] args)
        {
            // 1
            var time = new Stopwatch();
            time.Start();
            var taskNum = Task.Run(() => SimpleNumbersEratosthenes(1000));
            Console.WriteLine(taskNum.IsCompleted);
            Console.WriteLine(taskNum.Status);
            taskNum.Wait();
            time.Stop();
            Console.WriteLine($"Time work: {time.Elapsed.Milliseconds}ms");

            // 2
            var cencelToken = new CancellationTokenSource();
            var taskNum2 = Task.Run(() => SimpleNumbersEratosthenes(10000), cencelToken.Token);
            Console.WriteLine(taskNum2.IsCompleted);
            Console.WriteLine(taskNum2.Status);
            cencelToken.Cancel();

            // 3
            var task_sum = new Task<int>(() => Sum(2, 4));              // 6
            var task_mult = new Task<int>(() => Multiply(3, 5));        // 15
            var task_div = new Task<int>(() => Div(16, 4));             // 4
            task_div.ContinueWith((task) => Console.WriteLine("slow"));

            task_sum.Start();
            task_mult.Start();
            task_div.Start();

            task_mult.GetAwaiter().OnCompleted(() => Console.WriteLine("mult"));

            task_sum.Wait();
            task_mult.Wait();

            Console.WriteLine(task_sum.Result + task_mult.Result + task_div.GetAwaiter().GetResult());

            // 4
            var numbers = new int[1000000];
            time.Start();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = (i + 1) * (i - 1);
            }
            time.Stop();
            Console.WriteLine($"Simple: {time.ElapsedMilliseconds}ms");
            // -
            time.Start();
            Parallel.For(0, numbers.Length, (i) =>
            {
                numbers[i] = (i + 1) * (i - 1);
            }
            );
            time.Stop();
            Console.WriteLine($"Parallel: {time.ElapsedMilliseconds}ms");

            // 6
            Parallel.Invoke(() => Console.Write("hello"), () => Console.Write(" "), () => Console.Write("world"), () => Console.WriteLine("!"));

            // 8
            var task_num = GetNumberAsynk();
            task_num.Wait();
            Console.WriteLine(task_num.Result);

            // 7
            Console.ReadKey();
            var warehouse = new BlockingCollection<string>();

            var token = new CancellationTokenSource();
            Task.Run(() => Supplier(ref warehouse, 300, "car", "bus"), token.Token);
            Task.Run(() => Supplier(ref warehouse, 250, "gas stove", "electric stove", "refrigerator"), token.Token);
            Task.Run(() => Supplier(ref warehouse, 250, "banana", "apricot", "peach", "lime"), token.Token);
            Task.Run(() => Supplier(ref warehouse, 150, "chair", "sofa", "lamp"), token.Token);
            Task.Run(() => Supplier(ref warehouse, 150, "pears", "pineapple"), token.Token);

            for (int i = 0; i < 10; i++)
            {
                Task.Run(() => Customer(ref warehouse, 200), token.Token);
            }
            Console.ReadKey();
        }
    }
}
