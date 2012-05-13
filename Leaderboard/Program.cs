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

            var loserboard = new Loserboard();
            ed.PostScore(loserboard);
            cosmin.PostScore(loserboard);
            loserboard.Publish();
        }
    }

    internal class Leaderboard : IBoard
    {
        private List<Player> Scores = new List<Player>();

        public void AddScore(Player scorePosting)
        {
            Scores.Add(scorePosting);
        }

        public void Publish()
        {
            Console.WriteLine("The leaderboard is:");
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

    internal class Loserboard : IBoard
    {
        private List<Player> Scores = new List<Player>();

        public void AddScore(Player scorePosting)
        {
            Scores.Add(scorePosting);
        }

        public void Publish()
        {
            Console.WriteLine("The loserboard is: ");
            Scores.Sort(Sorter);

            foreach (var each in Scores)
            {
                Console.WriteLine(each.ToString());
            }

        }

        private static int Sorter(Player first, Player second)
        {
            return first.CompareTo(second);
        }
    }


    internal interface IBoard
    {
        void AddScore(Player player);
    }

    // What's the score of the design of this class?
    internal class Player : IComparable<Player>
    {
        public Player(int score, string name)
        {
            Score = new Score(score);
            Name = new Name(name);
        }

        private Score Score { get; set; }
        private Name Name { get; set; }

        public void PostScore(IBoard leaderboard)
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

        public override string ToString()
        {
            return _name;
        }
    }

    class Score : IComparable<Score>
    {
        private int _value;
        public Score(int value)
        {
            _value = value;
        }

        public int CompareTo(Score score)
        {
            return Convert.ToInt32(_value).CompareTo(Convert.ToInt32(score._value));
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
