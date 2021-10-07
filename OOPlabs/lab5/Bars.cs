using System;

namespace lab5
{
    public class Bars : SportInventory
    {
        public override string ToString()
        {
            return "Bars";
        }
        public override void Use()
        {
            Console.WriteLine("Pulled myself up on the uneven bars");
        }
    }
}
