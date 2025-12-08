using System;
using System.Data.SqlClient;

namespace CET2007_Assignment
{
    internal class Admin
    {

        private readonly Logger logger;
        // Add and remove games from library

        public Admin(Logger logger) { 
            this.logger = logger;

        }

        public void ManageGameLibrary()
        {
            Console.WriteLine("--- Admin: Manage Game Library ---");
            Console.WriteLine("1. Add Game");
            Console.WriteLine("2. Remove Game");
            Console.Write("Enter choice: ");
            string adminChoice = Console.ReadLine();
            if (adminChoice == "1")
            {
                // Add game logic
                Console.Write("Enter game name: ");
                string name = Console.ReadLine();
                logger.Log("Admin", $"Adding game: {name}");
                Console.Write("Enter game genre: ");
                string genre = Console.ReadLine();
                logger.Log("Admin", $"Game genre: {genre}");
                Console.Write("Enter game year: ");
                int year = int.Parse(Console.ReadLine());
                logger.Log("Admin", $"Game year: {year}");
                // Add the new game to the library (not implemented)
                Console.WriteLine($"Game '{name}' added to the library.");
                logger.Log("Admin", $"Game '{name}' added to the library.");
            }
            else if (adminChoice == "2")
            {
                // Remove game logic
                Console.Write("Enter game name to remove: ");
                string nameToRemove = Console.ReadLine();
                logger.Log("Admin", $"Removing game: {nameToRemove}");
                // Remove the game from the library (not implemented)
                Console.WriteLine($"Game '{nameToRemove}' removed from the library.");
                logger.Log("Admin", $"Game '{nameToRemove}' removed from the library.");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                logger.Log("Admin", "Invalid choice in ManageGameLibrary");
            }
        }
        // Update player statistics
        // Add new players
    }
}