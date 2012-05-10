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
            Player ed = new Player();
            ed.Score = 100;
            ed.Name = "Ed";

            Player cosmin = new Player();
            cosmin.Score = 58;
            cosmin.Name = "Cosmin";
            
            var leaderboard = new Leaderboard();
            leaderboard.AddScore(ed.Name, ed.Score);
            leaderboard.AddScore(cosmin.Name, cosmin.Score);
            leaderboard.Scores.Sort(Sorter);
            
            foreach (var each in leaderboard.Scores)
            {
                Console.WriteLine(string.Format("{0} scored {1}", each.Key, each.Value)); 
            }
        }

        static int Sorter(KeyValuePair<string, int> first, KeyValuePair<string, int> second )
        {
            return second.Value.CompareTo(first.Value);
        }
    }

    internal class Leaderboard
    {
        public List<KeyValuePair<string, int>> Scores = new List<KeyValuePair<string, int>>();

        public void AddScore(string name, int score)
        {
            Scores.Add(new KeyValuePair<string, int>(name, score));
        }
    }

    // What's the score of the design of this class?
    internal class Player
    {
        public int Score;
        public string Name;
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
