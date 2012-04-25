using System;
using System.Text;

namespace TennisScore
{
    internal class Set
    {
        private Game currentGame;
        private int playerOneGames;
        private int playerTwoGames;
        internal event Action PlayerOneWins = delegate { };
        internal event Action PlayerTwoWins = delegate { };
        private bool SetIsOver
        {
            get 
            {
                if (this.currentGame is Tiebreak && this.currentGame.GameOver)
                    return true;

                return (playerOneGames > 5 || playerTwoGames > 5) && Math.Abs(playerOneGames - playerTwoGames) > 1;
            }
        }

        internal Set()
        {
            InitializeCurrentGame();
        }

        private void InitializeCurrentGame()
        {
            if (playerTwoGames == playerOneGames && playerOneGames == 6)
                currentGame = new Tiebreak();
            else
                currentGame = new Game();
            currentGame.PlayerOneWins += PlayerOneWinsGame;
            currentGame.PlayerTwoWins += PlayerTwoWinsGame;
        }

        private void PlayerTwoWinsGame()
        {
            playerTwoGames++;

            if (this.currentGame is Tiebreak || this.SetIsOver)
                PlayerTwoWins();
            else
                InitializeCurrentGame();
        }

        private void PlayerOneWinsGame()
        {
            playerOneGames++;
            if (this.currentGame is Tiebreak || this.SetIsOver)
                PlayerOneWins();
            else
                InitializeCurrentGame();
        }

        internal void PlayerOneWinsPoint()
        {
            this.currentGame.PlayerOneWinsPoint();
        }

        internal void PlayerTwoWinsPoint()
        {
            this.currentGame.PlayerTwoWinsPoint();
        }

        internal string Score()
        {
            StringBuilder score = new StringBuilder();
            score.Append(string.Format("{0} - {1}", playerOneGames, playerTwoGames));
            if (!SetIsOver)
                score.Append(", " + currentGame.Score());

            return score.ToString();
        }
    }
}
