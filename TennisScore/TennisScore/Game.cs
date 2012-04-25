using System;
using System.Collections.Generic;

namespace TennisScore
{
    internal class Game
    {
        protected int playerOneScore;
        protected int playerTwoScore;
        private static readonly Dictionary<int, string> pointTranslation = new Dictionary<int, string> { { 0, "love" }, { 1, "15" }, { 2, "30" }, { 3, "40" } };
        
        internal event Action PlayerOneWins = delegate { };
        internal event Action PlayerTwoWins = delegate { };

        internal virtual bool GameOver
        {
            get 
            {
                return (playerOneScore >= 4 || playerTwoScore >= 4) && Math.Abs(playerTwoScore - playerOneScore) > 1;
            }
        }

        internal void PlayerOneWinsPoint()
        {
            playerOneScore++;
            if (GameOver)
                PlayerOneWins();
        }

        internal void PlayerTwoWinsPoint()
        {
            playerTwoScore++;

            if (GameOver)
                PlayerTwoWins();
        }

        internal virtual string Score()
        {
            if(GameOver)
                return playerOneScore > playerTwoScore ? "player one wins" : "player two wins";

            if (playerOneScore == playerTwoScore)
                return playerOneScore < 4 ? pointTranslation[playerOneScore] + " all" : "deuce";

            if (playerOneScore < 4 && playerTwoScore < 4)
                return pointTranslation[playerOneScore] + " - " + pointTranslation[playerTwoScore]; 

            return playerOneScore > playerTwoScore ? "advantage player one" : "advantage player two";
          }
    }
}
