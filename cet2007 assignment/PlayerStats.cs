namespace CET2007_Assignment
{
    internal class PlayerStats
    {
        // Public read-only properties so callers can access the data
        public string PlayerName { get; }
        public int GamesPlayed { get; }
        public int TotalScore { get; }

        public int Id { get; }

        public PlayerStats(string sPlayerName, int ID, int iGamesPlayed, int iTotalScore)
        {
            PlayerName = sPlayerName;
            GamesPlayed = iGamesPlayed;
            TotalScore = iTotalScore;
            Id = ID;
        }


        public override string ToString() => PlayerName;
    }
}