using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // GAME LIBRARY & PLAYER STATS MANAGER

            // Sample data for testing

            List<GameLibrary> games = new List<GameLibrary> {
                new GameLibrary("The Witcher 3", "RPG", 2015)
                , new GameLibrary("Cyberpunk 2077", "RPG", 2020)
                , new GameLibrary("Minecraft", "Sandbox", 2011)
                , new GameLibrary("Among Us", "Party", 2018)
                , new GameLibrary("Hades", "Roguelike", 2020)
            };

            // Sample player stats

            List<PlayerStats> players = new List<PlayerStats> {
                new PlayerStats("Alice", 150, 12000)
                , new PlayerStats("Bob", 200, 18000)
                , new PlayerStats("Charlie", 100, 8000)
            };

            // Display header

            Console.WriteLine(" === Game Library & Player Stats Manager ===");

            // Display player stats

            Console.WriteLine("\n--- Player Statistics ---");

            foreach (var player in players)
            {
                Console.WriteLine($"Player: {player.PlayerName}, Games Played: {player.GamesPlayed}, Total Score: {player.TotalScore}");
            }

            // Display games

            Console.WriteLine("\n--- Game Library ---");

            foreach (var game in games)
            {
                Console.WriteLine($"Name: {game.Name}, Genre: {game.Genre}, Year: {game.Year}");
            }
        }

    }

    class PlayerStats
    {
        // Public read-only properties so callers can access the data
        public string PlayerName { get; }
        public int GamesPlayed { get; }
        public int TotalScore { get; }

        public PlayerStats(string sPlayerName, int iGamesPlayed, int iTotalScore)
        {
            PlayerName = sPlayerName;
            GamesPlayed = iGamesPlayed;
            TotalScore = iTotalScore;
        }

        // Optional: override ToString() if you prefer using "{player}" directly
        public override string ToString() => PlayerName;
    }

    // GameLibrary class representing a game in the library
    class GameLibrary : IComparable<GameLibrary>
    {
        // Public read-only properties
        public string Name { get; }
        public string Genre { get; }
        public int Year { get; }

        public GameLibrary(string sName, string sGenre, int iYear)
        {
            Name = sName;
            Genre = sGenre;
            Year = iYear;
        }

        // Implement CompareTo to satisfy IComparable<T>
        public int CompareTo(GameLibrary other)
        {
            if (other == null) return 1;
            return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() => Name;
    }
}
