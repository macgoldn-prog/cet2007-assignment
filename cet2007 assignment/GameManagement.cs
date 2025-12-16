using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CET2007_Assignment
{
    /// <summary>
    /// large class to keep management in one place - apologies to those who despise this //
    /// </summary>
    internal class GameManagement // the management of the overall game library
    {
        private readonly string jsonFilePath; // link to games.json
        private readonly Logger logger;
        private readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions { };

        public GameManagement() // constructor
        {
            jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "games.json"); // sets path to games.json - change this if you want to games it elsewhere (!!! json only)
            logger = Logger.GetInstance();
        }
        public void LoadFromJson(List<GameLibrary> games) // loads games from games.json
        {
            if (games == null) throw new ArgumentNullException(nameof(games)); // null check
            if (!File.Exists(jsonFilePath))
            {
                logger.Log("GameManagement", $"No games.json found at {jsonFilePath}");
                return;
            }

            try // try to read and deserialize json
            {
                var json = File.ReadAllText(jsonFilePath);
                var loaded = JsonSerializer.Deserialize<List<GameLibrary>>(json);
                if (loaded == null)
                {
                    logger.Log("GameManagement", "Deserialized games.json returned null."); // log if deserialization fails
                    return;
                }

                games.Clear();
                games.AddRange(loaded);
                logger.Log("GameManagement", $"Loaded {games.Count} games from games.json"); // log success
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
                Console.WriteLine("\nGame Management: Manage Game Library"); // menu
                Console.WriteLine("1. Add game");
                Console.WriteLine("2. Remove game by name");
                Console.WriteLine("3. Save and exit");
                Console.WriteLine("4. Exit without saving");
                Console.Write("Choice: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
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
                            break;
                        }

                    case "2":
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
                            break;
                        }

                    case "3":
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

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
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
}