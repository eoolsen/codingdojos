using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisScore
{
    public class Match
    {
        private Set currentSet;
        readonly List<Set> playedSets = new List<Set>();
        private int playerOneSets;
        private int playerTwoSets;
        private bool MatchIsOver { get { return playerOneSets == 3 || playerTwoSets == 3; } }

        public Match()
        {
            InitializeNewSet();
        }

        private void InitializeNewSet()
        {
            currentSet = new Set();
            currentSet.PlayerOneWins += PlayerOneWinsSet;
            currentSet.PlayerTwoWins += PlayerTwoWinsSet;
        }

        private void PlayerOneWinsSet()
        {
            playerOneSets++;
            playedSets.Add(currentSet);
            InitializeNewSet();
        }

        private void PlayerTwoWinsSet()
        {
            playerTwoSets++;
            playedSets.Add(currentSet);
            InitializeNewSet();
        }

        public void PlayerOneWinsPoint()
        {
            if (MatchIsOver)
                throw new Exception("Match already ended.");
            this.currentSet.PlayerOneWinsPoint();
        }

        public void PlayerTwoWinsPoint()
        {
            if (MatchIsOver)
                throw new Exception("Match already ended.");
            this.currentSet.PlayerTwoWinsPoint();
        }

        public string Score()
        {
            StringBuilder score = new StringBuilder();

            score.Append(playedSets.Select(s => s.Score()).Aggregate((s, t) => s + ", " + t));
            
            if(!MatchIsOver)
                score.Append(", " + currentSet.Score());

            return score.ToString();
        }
    }
}
