using System;
using System.Collections.Generic;
using System.Linq;

namespace CET2007_Assignment
{
    /// <summary>
    /// Provides a main point of execution for the application.
    /// </summary>
    /// <remarks>The <c>Program</c> class contains only a <c>Main</c> method, which initializes features
    /// such as logging, sample game and player data, and the user interface.</remarks>
    internal class Program
    {
        static void Main()
        {
            var logger = Logger.GetInstance(); // initialize logger singleton
            logger.Log("Application", "Started");

            var games = new List<GameLibrary> // sample game data
            {
                new GameLibrary("The Witcher 3", "RPG", 2015),
                new GameLibrary("Cyberpunk 2077", "RPG", 2020),
                new GameLibrary("Minecraft", "Sandbox", 2011),
                new GameLibrary("Among Us", "Party", 2018),
                new GameLibrary("Hades", "Roguelike", 2020)
            };

            var players = new List<PlayerStats> // sample player data
            {
                new PlayerStats("Alice", 0, 150, 12000),
                new PlayerStats("Bob", 1, 200, 18000),
                new PlayerStats("Charlie", 2, 100, 8000)
            };

            var gm = new GameManagement();
            var pm = new PlayerManager();

            var ui = new UserInterface(games, players, gm, pm);
            ui.Run();

            logger.Log("Application", "Ended");
            logger.SaveLogToFile();
        }
    }
}
