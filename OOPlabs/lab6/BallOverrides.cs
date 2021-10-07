using System;

namespace lab6
{
    public partial class Ball : BaseHit, IHit
    {
        public override string ToString()
        {
            return $"Ball: Price = {Price}, Waight = {Weight}";
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
        public override void BaseHiting()
        {
            Hit();
        }
        public override void Use()
        {
            Hit();
        }
    }
}
