using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Printer
    {
        public void Print(Inventory inventory)
        {
            Console.WriteLine(inventory.ToString());
        }
    }
}
