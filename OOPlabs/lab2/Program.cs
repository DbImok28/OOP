using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab2
{
    class Program
    {
        
        private static (int min, int max, int sum, char first) Test(int[] arr, string str)
        {
            int min = arr.Min();
            int max = arr.Max();
            int sum = arr.Sum();
            char first = str.First();

            return (min, max, sum, first);
        }
        private static int foo1()
        {
            checked
            {
                int i = int.MaxValue;
                return ++i;
            }
        }
        private static int foo2()
        {
            unchecked
            {
                int i = int.MaxValue;
                return ++i;
            }
        }
        static void Main(string[] args)
        {
            {
                //1.1
                byte bt = 1;
                short s = 12;
                int i = 123;
                long l = 1234;

                float f = 12.3f;
                double d = 123.0;
                decimal dec = 1.3m;

                bool b = true;

                char c = 'f';
                string str = "12345";

                object obj = "sadf";

                dynamic dd = 1.2;
                dd = "sdfa";

                //1.2
                s = bt;
                i = s;
                d = f;
                l = bt;
                l = s;

                s = (short)i;
                f = (float)d;
                c = (char)i;
                dec = (decimal)f;
                l = (long)f;

                str = Convert.ToString(i);


                //1.3
                int z = 123;      // class  a value type
                object o = z;     // struct boxing
                int j = (int)o;   // class  unboxing


                // 1.4
                dynamic dyn = 12.5;
                dyn = "hello";
                dyn = true;


                // 1.5
                string str2 = null;
                int? i2 = null;
                if (str2 == null)
                {
                    Console.WriteLine("is null");
                }

                // 1.6
                var h = "123";
                //h = 123;

            }
            {
                string str = "world";
                string str2 = "hello";
                // 2.1
                if ("123" == "hello")
                {
                    Console.WriteLine("y1");
                }
                if (str == str2)
                {
                    Console.WriteLine("y2");
                }

                // 2.2
                string s1 = String.Concat(str, str2);
                string s2 = String.Copy(str2);
                string s3 = str2.Substring(2);
                string[] s4 = str2.Split(',');

                // 2.3
                string str3 = "";
                if (String.IsNullOrEmpty(str3))
                {
                    Console.WriteLine("Is invalid");
                }

                // 2.4
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(12).Append("sadf").Append("12.f");
                stringBuilder.Remove(1, 3);
                stringBuilder.Insert(2, true);
                stringBuilder.ToString();

                Console.WriteLine($"hello: {s1}, {s2}");
                s1 = @"c:\gg\ggg\gg\g";
            }
            {
                // 3.1
                int[,] mat = {
                { 1, 2, 3 },
                { 1, 2, 3 },
                { 1, 2, 3 }
                };
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write($"{mat[i, j]} ");
                    }
                    Console.WriteLine();
                }

                // 3.2
                string[] strs = { "hello", "world" };
                for (int i = 0; i < strs.Length; i++)
                {
                    Console.Write($"{strs[i]} ");
                }
                Console.WriteLine(strs.Length);

                int pos = Convert.ToInt32(Console.ReadLine());
                strs[pos] = Console.ReadLine();

                for (int i = 0; i < strs.Length; i++)
                {
                    Console.Write($"{strs[i]} ");
                }
                Console.WriteLine();

                // 3.3
                int[][] arr = new int[3][];
                arr[0] = new int[2];
                arr[1] = new int[3];
                arr[2] = new int[4];

                for (int j = 0; j < 2; j++)
                {                   
                    arr[0][j] = Convert.ToInt32(Console.ReadLine());
                }
                for (int j = 0; j < 3; j++)
                {
                    arr[1][j] = Convert.ToInt32(Console.ReadLine());
                }
                for (int j = 0; j < 4; j++)
                {
                    arr[2][j] = Convert.ToInt32(Console.ReadLine());
                }

                for (int j = 0; j < 2; j++)
                {
                    Console.Write(arr[0][j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(arr[1][j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(arr[2][j]);
                    Console.Write(' ');
                }
                Console.WriteLine();

                // 3.4
                dynamic d1 = new int[2] { 1, 2 };
                dynamic d2 = "hello";
            }
            {
                // 4.1
                (int, string, char, string, ulong) typle1 = (1, "he", 'l', "lo", 1);
                Console.WriteLine($"1:{typle1.Item1}, 2:{typle1.Item2}, 3:{ typle1.Item3}, 4:{typle1.Item4}, 5:{ typle1.Item5}");

                // 4.2
                var (v1, v2, v3, v4, v5) = typle1;

                var (n1, n2, _, _, n3) = typle1;

                // 4.3
                (int, string, char, string, ulong) typle2 = (9, "12", '4', "55", 10);
                if(typle1 == typle2)
                {
                    Console.WriteLine("equal");
                }
            }
            {
                // 5.1
                (int min, int max, int sum, char first)  = Test(new int[]{ 1,5,3,9,7}, "hello");
                Console.WriteLine(min);
                Console.WriteLine(max);
                Console.WriteLine(sum);
                Console.WriteLine(first);

                // 5.2
                Console.WriteLine(foo1());
                Console.WriteLine(foo2());
            }
            Console.ReadKey();
        }
    }
}
