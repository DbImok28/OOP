using System;
using System.Diagnostics;

namespace lab7
{
    internal class Program
    {
        public static int Divide(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        private static void Main(string[] args)
        {
            try
            {
                try
                {
                    Matrix mat = new Matrix(null);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                try
                {
                    Matrix mat = new Matrix(new int[0, 0]);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                try
                {
                    Matrix mat = new Matrix(new int[,] { { 1, 2, 3 }, { 1, 6, 5 }, { 7, 7, 4 } });
                    Console.WriteLine(mat[-2, 3]);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                try
                {
                    Matrix mat = new Matrix(new int[,] { { 1, 2, 3 }, { 1, 6, 5 }, { 7, 7, 4 } });
                    Console.WriteLine(mat[1002, 30000]);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                try
                {
                    int b = 2;
                    int a = b / 0;
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Finally");
            }

            try
            {
                Console.WriteLine(Divide(2, 0));
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"code: {e.HResult}, { e.Message}, {e.Source}, {e.StackTrace}");
            }
            finally
            {
                Console.WriteLine("Divide");
            }

            int a1 = 4;
            int a2 = 2;
            Debug.Assert(a2 != 0);
            Debug.Equals(a1, a2);
            Debug.WriteLine("Debug");
            Console.WriteLine(a1 / a2);

            Debugger.Log(1, "test", "my message\n");

            Console.ReadKey();
        }
    }
}