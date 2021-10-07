using System;

namespace lab5
{
    public class Mats : SportInventory 
    {
        public override string ToString()
        {
            return "Mats";
        }
        public override void Use()
        {
            Console.WriteLine("Lie on the mats");
        }
    }
}
