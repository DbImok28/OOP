using System;
using System.Text.Json;

namespace lab5
{
    [Serializable]
    public class Ball : BaseHit, IHit
    {
        public override string ToString()
        {
            return $"Ball: Waight = {Weight}";
        }
        public override bool Equals(object obj)
        {
            if(obj is Ball ball)
            {
                return ball.Weight == Weight;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Weight;
        }
        public Ball()
        {
            Weight = 400;
            Name = "Ball";
        }
        public Ball(int weight)
        {
            Weight = weight;
            Name = "Ball";
        }

        public void Hit()
        {
            Console.WriteLine("Hit the ball");
        }

        public override void BaseHiting()
        {
            Hit();
        }

        public override void Use()
        {
            Hit();
        }
        public int Weight { get; set; }
    }
}
