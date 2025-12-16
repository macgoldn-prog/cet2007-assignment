namespace CET2007_Assignment
{
    internal class PlayerStats
    {
        public string PlayerName { get; } // read only public properties
        public int GamesPlayed { get; }
        public int TotalScore { get; }

        public int Id { get; }

        public PlayerStats(string sPlayerName, int ID, int iGamesPlayed, int iTotalScore) // constructor
        {
            PlayerName = sPlayerName;
            GamesPlayed = iGamesPlayed;
            TotalScore = iTotalScore;
            Id = ID;
        }


        public override string ToString() => PlayerName; 
    }
}