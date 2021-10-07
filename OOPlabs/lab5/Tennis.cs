using System;

namespace lab5
{
    public sealed class Tennis : SportGame
    {
        public override void Play()
        {
            Console.WriteLine("Play tennis");
            IsStarted = true;
            HitBall();
        }
        public void HitBall()
        {
            Ball.Hit();
        }
        public Tennis(IHit ball)
        {
            Ball = ball;
        }
        public override string ToString()
        {
            return IsStarted ? "Tennis: game is started" : "Tennis: game is not started";
        }
        
        public bool IsStarted = false;
        public IHit Ball;
    }
}
