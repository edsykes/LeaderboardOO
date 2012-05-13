using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaderboardApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Player ed = new Player(100, "Ed");
            Player cosmin = new Player(58, "Cosmin");

            var leaderboard = new Leaderboard();
            leaderboard.AddScore(ed.ScorePosting);
            leaderboard.AddScore(cosmin.ScorePosting);
            leaderboard.Scores.Sort(Sorter);

            foreach (var each in leaderboard.Scores)
            {
                Console.WriteLine(each.ToString());
            }
        }

        static int Sorter(ScorePosting first, ScorePosting second)
        {
            return second.Score.CompareTo(first.Score);
        }
    }

    internal class Leaderboard
    {
        public List<ScorePosting> Scores = new List<ScorePosting>();

        public void AddScore(ScorePosting scorePosting)
        {
            Scores.Add(scorePosting);
        }
    }

    // What's the score of the design of this class?
    internal class Player
    {
        public Player(int score, string name)
        {
            Score = score;
            Name = name;
        }

        private int Score { get; set; }
        private string Name { get; set; }

        public ScorePosting ScorePosting
        {
            get
            {
                return new ScorePosting(Name, Score);
            }
        }
    }

    internal class ScorePosting
    {
        private readonly string _name;
        private readonly int _score;
        public int Score { get; private set; }

        public ScorePosting(string name, int score)
        {
            _name = name;
            _score = score;
        }

        public override string ToString()
        {
            return string.Format("{0} scored {1}", _name, _score);
        }
    }

    // We'll use these later
    class Name
    {
        private string _name;
        public Name(string name)
        {
            _name = name;
        }
    }

    class Score
    {
        private int _value;
        public Score(int value)
        {
            _value = value;
        }
    }
}
