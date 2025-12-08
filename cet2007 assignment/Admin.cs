using System;

namespace CET2007_Assignment
{
    internal class Admin
    {
        private readonly Logger logger;

        public Admin()
        {
            this.logger = Logger.GetInstance();
        }

        public void ManageGameLibrary()
        {
            Console.WriteLine("--- Admin: Manage Game Library ---");
            Console.WriteLine("1. Add Game");
            Console.WriteLine("2. Remove Game");
            Console.Write("Enter choice: ");
            string adminChoice = Console.ReadLine()?.Trim();

            switch (adminChoice)
            {
                case "1":
                    Console.Write("Enter game name: ");
                    string name = Console.ReadLine();
                    logger.Log("Admin", $"Adding game: {name}");

                    Console.Write("Enter game genre: ");
                    string genre = Console.ReadLine();
                    logger.Log("Admin", $"Game genre: {genre}");

                    Console.Write("Enter game year: ");
                    string yearInput = Console.ReadLine();
                    int year;
                    if (!int.TryParse(yearInput, out year))
                    {
                        Console.WriteLine("Invalid year.");
                        logger.Log("Admin", "Invalid year input.");
                        break;
                    }
                    logger.Log("Admin", $"Game year: {year}");

                    Console.WriteLine($"Game '{name}' added to the library.");
                    logger.Log("Admin", $"Game '{name}' added to the library.");
                    break;

                case "2":
                    Console.Write("Enter game name to remove: ");
                    string nameToRemove = Console.ReadLine();
                    logger.Log("Admin", $"Removing game: {nameToRemove}");
                    Console.WriteLine($"Game '{nameToRemove}' removed from the library.");
                    logger.Log("Admin", $"Game '{nameToRemove}' removed from the library.");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    logger.Log("Admin", "Invalid choice in ManageGameLibrary");
                    break;
            }
        }
    }
}