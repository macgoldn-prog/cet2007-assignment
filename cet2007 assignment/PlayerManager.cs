using System;
using System.Collections.Generic;

namespace CET2007_Assignment
{
    internal class PlayerManager
    {
        private readonly Logger logger;

        public PlayerManager()
        {
            logger = Logger.GetInstance();
        }

        public void SortByTotalScoreDesc(List<PlayerStats> players)
        {
            if (players == null) throw new ArgumentNullException(nameof(players));
            players.Sort((a, b) => b.TotalScore.CompareTo(a.TotalScore));
            logger.Log("PlayerManager", $"Sorted {players.Count} players by TotalScore desc");
        }

        public PlayerStats SearchByName(List<PlayerStats> players, string name)
        {
            if (players == null) throw new ArgumentNullException(nameof(players));
            if (string.IsNullOrWhiteSpace(name)) return null;
            var found = players.Find(p => string.Equals(p.PlayerName, name, StringComparison.OrdinalIgnoreCase));
            logger.Log("PlayerManager", found != null ? $"Found player by name: {name}" : $"Player not found by name: {name}");
            return found;
        }

        public PlayerStats SearchByIdLinear(List<PlayerStats> players, int id)
        {
            if (players == null) throw new ArgumentNullException(nameof(players));
            foreach (var p in players)
            {
                if (p.Id == id)
                {
                    logger.Log("PlayerManager", $"Linear search found player id {id}");
                    return p;
                }
            }
            logger.Log("PlayerManager", $"Linear search did not find player id {id}");
            return null;
        }

        public PlayerStats SearchByIdBinary(List<PlayerStats> players, int id)
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