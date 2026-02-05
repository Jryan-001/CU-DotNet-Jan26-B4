using System.Collections.Generic;

namespace SortedDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, string> leaderboard = new SortedDictionary<double, string>();
            leaderboard.Add(55.42, "SwiftRacer");
            leaderboard.Add(52.10, "SpeedDemon");
            leaderboard.Add(58.91, "SteadyEddie");
            leaderboard.Add(51.05, "TurboTom");

            foreach (var item in leaderboard)
            {
                Console.WriteLine($"{item.Key:f2}" + " - " +item.Value);
            }

            Console.WriteLine($"Gold Medal Time - {leaderboard.Keys.First()}");
            double k = 0;
            foreach(var item in leaderboard)
            {
                if(item.Value == "SteadyEddie") k = item.Key;
            }
            leaderboard.Remove(k);
            leaderboard.Add(54.00, "SteadyEddie");

            foreach (var item in leaderboard)
            {
                Console.WriteLine($"{item.Key:f2}" + " - " + item.Value);
            }
            Console.WriteLine("\"SteadyEddie\" improved his time to 54.00.");
        }
    }
}
