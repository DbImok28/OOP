using System;

namespace lab5
{
    // Скамейка
    public class Bench : Inventory
    {
        public override string ToString()
        {
            return "Bench";
        }
        public override void Use()
        {
            Console.WriteLine("Sat on the bench");
        }
    }
}
