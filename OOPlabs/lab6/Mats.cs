using System;

namespace lab6
{
    public class Mats : SportInventory 
    {
        public Mats()
        {
            Price = 40;
        }
        public override string ToString()
        {
            return $"Mats: Price = {Price}";
        }
        public override void Use()
        {
            Console.WriteLine("Lie on the mats");
        }
    }
}
