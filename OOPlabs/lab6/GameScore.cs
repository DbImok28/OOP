using System;

namespace lab6
{
    public struct GameScore
    {
        public GameScore(int team1 = 0, int team2 = 0)
        {
            Team1 = team1;
            Team2 = team2;
        }
        public int Team1;
        public int Team2;
    }
}
