using System;

namespace TennisScore
{
    internal class Tiebreak : Game
    {
        internal override bool GameOver
        {
            get
            {
                return (playerOneScore >= 7 || playerTwoScore >= 7) && Math.Abs(playerTwoScore - playerOneScore) > 1;
            }
        }

        internal override string Score()
        {
            return playerOneScore + " - " + playerTwoScore;
        }
    }
}
