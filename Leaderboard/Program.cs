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
        private List<Player> Scores = new List<Player>();

        public void AddScore(Player scorePosting)
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

        private static int Sorter(Player first, Player second)
        {
            return second.CompareTo(first);
        }
    }

    // What's the score of the design of this class?
    internal class Player : IComparable<Player>
    {
        public Player(int score, string name)
        {
            Score = score;
            Name = name;
        }

        private int Score { get; set; }
        private string Name { get; set; }

        public void PostScore(Leaderboard leaderboard)
        {
            leaderboard.AddScore(this);
        }

        public int CompareTo(Player other)
        {
            return Score.CompareTo(other.Score);
        }

        public override string ToString()
        {
            return string.Format("{0} scored {1}", Name, Score);
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
