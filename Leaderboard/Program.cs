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
            ed.PostScore(leaderboard);
            cosmin.PostScore(leaderboard);
            leaderboard.Publish();
        }
    }

    internal class Leaderboard
    {
        private List<ScorePosting> Scores = new List<ScorePosting>();

        public void AddScore(ScorePosting scorePosting)
        {
            Scores.Add(scorePosting);
        }

        public void Publish()
        {
            Scores.Sort(Sorter);

            foreach (var each in Scores)
            {
                Console.WriteLine(each.ToString());
            }

        }

        private static int Sorter(ScorePosting first, ScorePosting second)
        {
            return second.CompareTo(first);
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

        private ScorePosting ScorePosting
        {
            get
            {
                return new ScorePosting(Name, Score);
            }
        }

        public void PostScore(Leaderboard leaderboard)
        {
            leaderboard.AddScore(ScorePosting);
        }
    }

    internal class ScorePosting : IComparable<ScorePosting>
    {
        private readonly string _name;
        private readonly int _score;

        public ScorePosting(string name, int score)
        {
            _name = name;
            _score = score;
        }

        public int CompareTo(ScorePosting other)
        {
            return _score.CompareTo(other._score);
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
