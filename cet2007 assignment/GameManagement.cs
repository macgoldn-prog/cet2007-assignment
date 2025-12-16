using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CET2007_Assignment
{
    internal class GameManagement
    {
        private readonly string jsonFilePath;
        private readonly Logger logger;
        private readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };

        public GameManagement()
        {
            jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "games.json");
            logger = Logger.GetInstance();
        }

        // 
        public void LoadFromJson(List<GameLibrary> games)
        {
            if (games == null) throw new ArgumentNullException(nameof(games));
            if (!File.Exists(jsonFilePath))
            {
                logger.Log("GameManagement", $"No games.json found at {jsonFilePath}");
                return;
            }

            try
            {
                var json = File.ReadAllText(jsonFilePath);
                var loaded = JsonSerializer.Deserialize<List<GameLibrary>>(json);
                if (loaded == null)
                {
                    logger.Log("GameManagement", "Deserialized games.json returned null.");
                    return;
                }

                games.Clear();
                games.AddRange(loaded);
                logger.Log("GameManagement", $"Loaded {games.Count} games from games.json");
            }
            catch (System.Text.Json.JsonException jex)
            {
                logger.Log("GameManagement", $"Corrupt games.json: {jex.Message}");
                Console.WriteLine($"Problem: saved games file is corrupt: {jex.Message}");
            }
            catch (Exception ex)
            {
                logger.Log("GameManagement", $"Failed to load games.json: {ex.Message}");
                Console.WriteLine($"Problem: could not load saved games: {ex.Message}");
            }
        }


        public void ManageGameLibrary(List<GameLibrary> games)
        {
            //load games from json
            LoadFromJson(games);

            while (true)
            {
                Console.WriteLine("\nGame Management: Manage Game Library");
                Console.WriteLine("1. Add game");
                Console.WriteLine("2. Remove game by name");
                Console.WriteLine("3. Save and exit");
                Console.WriteLine("4. Exit without saving");
                Console.Write("Choice: ");
                var input = Console.ReadLine();
                if (input == "1")
                {
                    Console.Write("Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Genre: ");
                    var genre = Console.ReadLine();
                    Console.Write("Year: ");
                    if (!int.TryParse(Console.ReadLine(), out var year))
                    {
                        Console.WriteLine("Invalid year.");
                        continue;
                    }
                    games.Add(new GameLibrary(name, genre, year));
                    Console.WriteLine("Game added.");
                }
                else if (input == "2")
                {
                    Console.Write("Enter game name to remove: ");
                    var name = Console.ReadLine();
                    var toRemove = games.Find(g => string.Equals(g.Name, name, StringComparison.OrdinalIgnoreCase));
                    if (toRemove != null)
                    {
                        games.Remove(toRemove);
                        Console.WriteLine("Game removed.");
                    }
                    else
                    {
                        Console.WriteLine("Game not found.");
                    }
                }
                else if (input == "3")
                {
                    try
                    {
                        SaveGamesToJson(games);
                        Console.WriteLine($"Games saved to {jsonFilePath}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to save: {ex.Message}");
                        logger.Log("GameManagement", $"Failed to save games.json: {ex.Message}");
                    }
                    return;
                }
                else if (input == "4")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }

        private void SaveGamesToJson(List<GameLibrary> games)
        {
            var json = JsonSerializer.Serialize(games, jsonOptions);
            File.WriteAllText(jsonFilePath, json);
            logger.Log("GameManagement", $"Saved {games.Count} games to games.json");
        }
    }

    class Report
    {
        private readonly Logger loggerInstance;

        public Report()
        {
            loggerInstance = Logger.GetInstance();
        }

        private void Summary(List<ReportLog> log)
        {
            if (log.Count == 0)
            {
                loggerInstance.Log("Report", "No data to generate report.");
                return;
            }
            // summary report
        }
    }
}