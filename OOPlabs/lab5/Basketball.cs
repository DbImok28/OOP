using System;

namespace lab5
{
    public class Basketball : Ball
    {
        public Basketball(int weight = 800) : base(weight)
        {

        }
        public override string ToString()
        {
            return $"Basketball: Waight = {Weight}";
        }
        public override void Use()
        {
            Console.WriteLine("Hit the Basketball");
        }
    }
}
