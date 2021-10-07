using System;

namespace lab6
{
    public enum GameState
    {
        Start,
        Pause,
        End
    }
    public class SportGame
    {
        public virtual void Play()
        {
            Console.WriteLine("Play the game");
            gameState = GameState.Start;
        }

        public GameState gameState = GameState.End;

        public GameScore gameScore = new GameScore();
    }
}
