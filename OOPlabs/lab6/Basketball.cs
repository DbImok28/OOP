using System;

namespace lab6
{
    public class Basketball : Ball
    {
        public Basketball(int weight = 800) : base(weight)
        {
            Price = 25;
        }
        public override string ToString()
        {
            return $"Basketball: Price = {Price}, Waight = {Weight}";
        }
        public override void Use()
        {
            Console.WriteLine("Hit the Basketball");
        }
    }
}
