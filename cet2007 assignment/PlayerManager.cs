using System;
using System.Collections.Generic;

namespace CET2007_Assignment
{
    internal class PlayerManager
    {
        private readonly Logger logger;

        public PlayerManager()
        {
            logger = Logger.GetInstance(); // get singleton logger instance

        }

        public void SortByTotalScoreDesc(List<PlayerStats> players) // sort players by TotalScore descending
        {
            if (players == null) throw new ArgumentNullException(nameof(players)); // null check
            players.Sort((a, b) => b.TotalScore.CompareTo(a.TotalScore));
            logger.Log("PlayerManager", $"Sorted {players.Count} players by TotalScore descening"); // log sorting action
        }

        public PlayerStats SearchByName(List<PlayerStats> players, string name)
        {
            if (players == null) throw new ArgumentNullException(nameof(players));// null check
            if (string.IsNullOrWhiteSpace(name)) return null;
            var found = players.Find(p => string.Equals(p.PlayerName, name, StringComparison.OrdinalIgnoreCase)); // search by name, case insensitive
            logger.Log("PlayerManager", found != null ? $"Found player by name: {name}" : $"Player not found by name: {name}");
            return found;
        }

        public PlayerStats SearchByIdLinear(List<PlayerStats> players, int id) // linear search by id
        {
            if (players == null) throw new ArgumentNullException(nameof(players)); // null check
            foreach (var p in players)
            { 
                if (p.Id == id) // check id
                {
                    logger.Log("PlayerManager", $"Linear search found player id {id}"); // log found
                    return p;
                }
            }
            logger.Log("PlayerManager", $"Linear search did not find player id {id}");
            return null;
        }

        public PlayerStats SearchByIdBinary(List<PlayerStats> players, int id) // binary search by id
        {
            if (players == null) throw new ArgumentNullException(nameof(players)); 
            // Ensure list sorted by Id
            players.Sort((a, b) => a.Id.CompareTo(b.Id));
            int left = 0, right = players.Count - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (players[mid].Id == id)
                {
                    logger.Log("PlayerManager", $"Binary search found player id {id}");
                    return players[mid];
                }
                if (players[mid].Id < id) left = mid + 1;
                else right = mid - 1;
            }
            logger.Log("PlayerManager", $"Binary search did not find player id {id}");
            return null;
        }
    }
}