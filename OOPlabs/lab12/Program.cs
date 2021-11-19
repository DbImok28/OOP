using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Reflector.AssemblyName());
            Console.WriteLine(Reflector.HavePublicConstructor());
            Console.WriteLine("\nIs public:");
            foreach (var item in Reflector.GetPublicMethods())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nMethods and prop:");
            foreach (var item in Reflector.GetMethodsInfo())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nInterfaces:");
            foreach (var item in Reflector.GetImplementedInterfaces())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nreturn int:");
            foreach (var item in Reflector.MethodsRetunedType("System.Console",0.GetType()))
            {
                Console.WriteLine(item);
            }
            var prt = new Printer();
            Reflector.LoadAndInvoke(prt, "Print", "PrintMsg.txt");
            Reflector.InvokeMethod(prt, "Print", "world");


            Printer prt2 = (Printer)Reflector.Create("lab12.Printer");
            prt2.Print("Creaded");
            Console.ReadKey();
        }
    }
}
