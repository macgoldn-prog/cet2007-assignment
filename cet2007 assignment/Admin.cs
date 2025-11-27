using System;

namespace CET2007_Assignment
{
    internal class Admin
    {
        // Add and remove games from library

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
                Console.Write("Enter game genre: ");
                string genre = Console.ReadLine();
                Console.Write("Enter game year: ");
                int year = int.Parse(Console.ReadLine());
                // Add the new game to the library (not implemented)
                Console.WriteLine($"Game '{name}' added to the library.");
            }
            else if (adminChoice == "2")
            {
                // Remove game logic
                Console.Write("Enter game name to remove: ");
                string nameToRemove = Console.ReadLine();
                // Remove the game from the library (not implemented)
                Console.WriteLine($"Game '{nameToRemove}' removed from the library.");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
        // Update player statistics
        // Add new players
    }
}