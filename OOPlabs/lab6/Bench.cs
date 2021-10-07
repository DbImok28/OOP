using System;

namespace lab6
{
    // Скамейка
    public class Bench : Inventory
    {
        public Bench()
        {
            Price = 12;
        }
        public override string ToString()
        {
            return $"Bench: Price = {Price}";
        }
        public override void Use()
        {
            Console.WriteLine("Sat on the bench");
        }
    }
}
