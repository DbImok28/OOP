using System;

namespace lab6
{
    public sealed class Tennis : SportGame
    {
        public override void Play()
        {
            Console.WriteLine("Play tennis");
            gameState = GameState.Start;
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
            return gameState == GameState.Start ? "Tennis: game is started" : "Tennis: game is not started";
        }
        
        public IHit Ball;
    }
}
