using System;
using System.Collections.Generic;
using System.Linq;

namespace CET2007_Assignment
{
    internal class UserInterface
    {
        private readonly List<GameLibrary> games;
        private readonly List<PlayerStats> players;
        private readonly GameManagement gameManagement;
        private readonly PlayerManager playerManager;
        private readonly Logger logger;

        public UserInterface(List<GameLibrary> games, List<PlayerStats> players, GameManagement gm, PlayerManager pm)
        {
            this.games = games ?? throw new ArgumentNullException(nameof(games));
            this.players = players ?? throw new ArgumentNullException(nameof(players));
            gameManagement = gm ?? throw new ArgumentNullException(nameof(gm));
            playerManager = pm ?? throw new ArgumentNullException(nameof(pm));
            logger = Logger.GetInstance();
        }

        public void Run()
        {
            // Prepare data
            playerManager.SortByTotalScoreDesc(players);
            games.Sort();

            Console.WriteLine(" === Game Library & Player Stats Manager ===\n");

            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. View Player Statistics");
                Console.WriteLine("2. View Game Library");
                Console.WriteLine("3. Search player by name");
                Console.WriteLine("4. Game Management (Add/Remove Games, Save)");
                Console.WriteLine("5. Search player by ID");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                var choice = Console.ReadLine();

                logger.Log("User", $"Selected option {choice}");

                switch (choice)
                {
                    case "1":
                        ShowPlayers();
                        break;
                    case "2":
                        ShowGames();
                        break;
                    case "3":
                        SearchPlayerByName();
                        break;
                    case "4":
                        gameManagement.ManageGameLibrary(games);
                        break;
                    case "5":
                        SearchPlayerById();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

                AskGenerateReport();
            }
        }

        private void ShowPlayers()
        {
            Console.WriteLine("\n--- Viewing Player Statistics ---");
            foreach (var player in players)
            {
                Console.WriteLine($"\nPlayer: {player.PlayerName}, Games Played: {player.GamesPlayed}, Total Score: {player.TotalScore}, ID: {player.Id}");
            }
        }

        private void ShowGames()
        {
            Console.WriteLine("\n--- Viewing Game Library ---");
            foreach (var game in games)
            {
                Console.WriteLine($"\nName: {game.Name}, Genre: {game.Genre}, Year: {game.Year}");
            }
        }

        private void SearchPlayerByName()
        {
            Console.WriteLine("\n--- Search Player ---");
            Console.Write("Enter player name to search: ");
            var searchName = Console.ReadLine() ?? string.Empty;
            var found = playerManager.SearchByName(players, searchName);
            if (found != null)
            {
                Console.WriteLine($"\nPlayer found: {found.PlayerName}, Games Played: {found.GamesPlayed}, Total Score: {found.TotalScore}, ID: {found.Id}");
            }
            else
            {
                Console.WriteLine("\nPlayer not found.");
            }
        }

        private void SearchPlayerById()
        {
            Console.WriteLine("\n--- Search Player by ID ---");
            Console.Write("Enter player ID: ");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out var id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var linear = playerManager.SearchByIdLinear(players, id);
            Console.WriteLine(linear != null ? $"Linear search: Found {linear.PlayerName}" : "Linear search: Not found");

            var binary = playerManager.SearchByIdBinary(players, id);
            Console.WriteLine(binary != null ? $"Binary search: Found {binary.PlayerName}" : "Binary search: Not found");
        }

        private void AskGenerateReport()
        {
            Console.WriteLine("\nWould you like to generate a simple top-score report? (yes/no)");
            var sReport = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant();
            if (sReport == "yes")
            {
                Console.WriteLine("\n--- Player Top Score Ranking ---");
                playerManager.SortByTotalScoreDesc(players);
                for (int i = 0; i < players.Count; i++)
                {
                    var p = players[i];
                    Console.WriteLine($"\nRank {i + 1}: Player: {p.PlayerName}, Games Played: {p.GamesPlayed}, Total Score: {p.TotalScore}");
                }

                Console.WriteLine("\n--- Most Active Players ---");
                var mostActive = players.OrderByDescending(p => p.GamesPlayed).Take(3);
                foreach (var p in mostActive)
                {
                    Console.WriteLine($"\nPlayer: {p.PlayerName}, Games Played: {p.GamesPlayed}, Total Score: {p.TotalScore}");
                }
            }
        }
    }
}