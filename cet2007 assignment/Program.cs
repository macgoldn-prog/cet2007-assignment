using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// removed to do list

namespace CET2007_Assignment
{
    internal class Program
    {
        static void Main()
        {
            // Logger is a singleton, instantiate it once

            Logger logger = Logger.GetInstance();
            logger.Log("Application", "Started");


            // GAME LIBRARY & PLAYER STATS MANAGER

            // sample data within program to simulate a source of data to work with for screencast demo


            List<GameLibrary> games = new List<GameLibrary> {
                new GameLibrary("The Witcher 3", "RPG", 2015)
                , new GameLibrary("Cyberpunk 2077", "RPG", 2020)
                , new GameLibrary("Minecraft", "Sandbox", 2011)
                , new GameLibrary("Among Us", "Party", 2018)
                , new GameLibrary("Hades", "Roguelike", 2020)
            };

            List<PlayerStats> players = new List<PlayerStats> {
                new PlayerStats("Alice", 000000, 150, 12000)
                , new PlayerStats("Bob", 000001, 200, 18000)
                , new PlayerStats("Charlie", 000002, 100, 8000)
            };

            // sort players numerically by total score descending
            players = players.OrderByDescending(p => p.TotalScore).ToList();

            // sort games alphabetically by name
            games.Sort();

            var gameManagement = new GameManagement();
            gameManagement.LoadFromJson(games);
            games.Sort();

            // header

            Console.WriteLine(" === Game Library & Player Stats Manager ===\n");

            // view either player stats or game library

            Console.WriteLine("Select an option:");
            Console.WriteLine("1. View Player Statistics");
            Console.WriteLine("2. View Game Library");
            Console.WriteLine("3. Search player");
            Console.WriteLine("4. Game Management (Add/Remove Games, Add/Update Player Stats)");

            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine(choice);

            logger.Log("User", $"Selected option {choice}");

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n--- Viewing Player Statistics ---");
                    foreach (var player in players)
                    {
                        Console.WriteLine($"\nPlayer: {player.PlayerName}, Games Played: {player.GamesPlayed}, Total Score: {player.TotalScore}");

                    }
                    break;

                case "2":
                    Console.WriteLine("\n--- Viewing Game Library ---");
                    foreach (var game in games)
                    {
                        Console.WriteLine($"\nName: {game.Name}, Genre: {game.Genre}, Year: {game.Year}");
                    }
                    break;

                case "3":
                    Console.WriteLine("\n--- Search Player ---");
                    Console.Write("Enter player name to search: ");
                    string searchName = Console.ReadLine();
                    var foundPlayer = players.FirstOrDefault(p => p.PlayerName.Equals(searchName, StringComparison.OrdinalIgnoreCase));
                    if (foundPlayer != null)
                    {
                        Console.WriteLine($"\nPlayer found: {foundPlayer.PlayerName}, Games Played: {foundPlayer.GamesPlayed}, Total Score: {foundPlayer.TotalScore}");
                    }
                    else
                    {
                        Console.WriteLine("\nPlayer not found.");
                    }
                    break;

                case "4":
                    Console.WriteLine("\n--- Game Management ---");
                    GameManagement gameManagement2 = new GameManagement();
                    gameManagement2.ManageGameLibrary(games); // Pass the 'games' list as required
                    foreach (var game in games)
                    {
                        Console.WriteLine($"\nName: {game.Name}, Genre: {game.Genre}, Year: {game.Year}");
                    }
                    break;

                case "5":
                    Console.WriteLine("\n--- Data Persistence ---");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please restart the program and select either 1 or 2.");
                    break;
            }

            Console.WriteLine("\nWould you like to generate a report?");
            string sReport = Console.ReadLine().ToLowerInvariant();

            switch (sReport)
            {
                case "yes":
                    Console.WriteLine("\n--- Player Top Score Ranking ---");
                    foreach (var player in players)
                    {
                        Console.WriteLine($"\nPlayer: {player.PlayerName}, Games Played: {player.GamesPlayed}, Total Score: {player.TotalScore}");

                        // Display the player's rank
                        int rank = players.IndexOf(player) + 1;
                        Console.WriteLine($"Rank: {rank}");

                    }
                    Console.WriteLine("\n--- Most Active Players ---");
                    var mostActivePlayers = players.OrderByDescending(p => p.GamesPlayed).Take(3);
                    foreach (var player in mostActivePlayers)
                    {
                        Console.WriteLine($"\nPlayer: {player.PlayerName}, Games Played: {player.GamesPlayed}, Total Score: {player.TotalScore}");
                    }
                    break;

                default:
                    // no report requested
                    break;
            }

            logger.Log("Application", "Manager ended, saving log to file");
            logger.SaveLogToFile();

        }

        class Report
        {
            private readonly Logger logger;

            public Report()
            {
                logger = Logger.GetInstance();
            }

            private void Summary(List<ReportLog> log)
            {
                if (log.Count == 0)
                {
                    logger.Log("Report", "No data to generate report.");
                    return;
                }
                // summary report
            }


        }

        static PlayerStats SearchPlayerByIdLinear(List<PlayerStats> players, int id)
        {
            if (players == null) throw new ArgumentNullException(nameof(players));
            return players.Find(p => p.Id == id);
        }

        static PlayerStats SearchPlayerByIdBinary(List<PlayerStats> players, int id)
        {
            if (players == null) throw new ArgumentNullException(nameof(players));

            players.Sort((a, b) => a.Id.CompareTo(b.Id));
            int left = 0, right = players.Count - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (players[mid].Id == id) return players[mid];
                if (players[mid].Id < id) left = mid + 1;
                else right = mid - 1;
            }
            return null;
        }
    }
}
