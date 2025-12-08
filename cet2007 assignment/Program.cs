using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Current status of manager:
// - Can view player statistics sorted by total score descending
//  - Can view game library sorted alphabetically by name
// - User can choose to view either player stats or game library
// - Displays player rank based on total score

// To Do:
// - Add functionality to add/remove games from library
// - Add functionality to update player statistics
// - Implement data persistence (save/load from file)
// - Add search functionality for games and players

namespace CET2007_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialising the logger for logging events

            Logger logger = Logger.GetInstance();
            logger.Log("Application", "Manager started");


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
                new PlayerStats("Alice", 000000, 150, 12000)
                , new PlayerStats("Bob", 000001, 200, 18000)
                , new PlayerStats("Charlie", 000002, 100, 8000)
            };

            // Sort players numerically by total score descending
            players = players.OrderByDescending(p => p.TotalScore).ToList();

            // Sort games alphabetically by name
            games.Sort();

            // Display header

            Console.WriteLine(" === Game Library & Player Stats Manager ===\n");

            // User decision to view either player stats or game library

            Console.WriteLine("Select an option:");
            Console.WriteLine("1. View Player Statistics");
            Console.WriteLine("2. View Game Library");
            Console.WriteLine("3. Search player");
            Console.WriteLine("4. Admin Functionality (Add/Remove Games, Add/Update Player Stats)");

            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine(choice);

            logger.Log("User", $"Selected option {choice}");

            if (choice == "1")
            {
                Console.WriteLine("\n--- Viewing Player Statistics ---");
                foreach (var player in players)
                {
                    Console.WriteLine($"\nPlayer: {player.PlayerName}, Games Played: {player.GamesPlayed}, Total Score: {player.TotalScore}");

                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("\n--- Viewing Game Library ---");
                foreach (var game in games)
                {
                    Console.WriteLine($"\nName: {game.Name}, Genre: {game.Genre}, Year: {game.Year}");
                }
            }
            else if (choice == "3")
            {
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
            }
            else if (choice == "4")
            {
                Console.WriteLine("\n--- Admin Functionality ---");
                Admin admin = new Admin();
                admin.ManageGameLibrary();
                foreach (var game in games)
                {
                    Console.WriteLine($"\nName: {game.Name}, Genre: {game.Genre}, Year: {game.Year}");
                }
            }
            else if (choice == "5")
            {

                Console.WriteLine("\n--- Data Persistence ---");
            }

            else
            {
                Console.WriteLine("Invalid choice. Please restart the program and select either 1 or 2.");
            }

            Console.WriteLine("\nWould you like to generate a report?");
            string sReport = Console.ReadLine().ToLowerInvariant();
            if (sReport == "yes")
            {
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
            }

            logger.Log("Application", "Manager ended, saving log to file");
            logger.SaveLogToFile();

        }



        // GameLibrary class representing a game in the library


        class SearchFunctionality
        {


        }

        class Report
        {
            private Logger logger;
            private string ReportPath = "reportlog.txt";

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
                // Generate summary report
            }


        }

    }
}
