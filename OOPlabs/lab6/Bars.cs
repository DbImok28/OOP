using System;

namespace lab6
{
    public class Bars : SportInventory
    {
        public Bars()
        {
            Price = 85;
        }
        public override string ToString()
        {
            return $"Bars: Price = {Price}";
        }
        public override void Use()
        {
            Console.WriteLine("Pulled myself up on the uneven bars");
        }
    }
}
