using System;

namespace lab6
{
    public partial class Ball : BaseHit, IHit
    {
        public Ball(int weight = 400)
        {
            Weight = weight;
            Price = 15;
        }

        public void Hit()
        {
            Console.WriteLine("Hit the ball");
        }
        public int Weight;
    }
}
