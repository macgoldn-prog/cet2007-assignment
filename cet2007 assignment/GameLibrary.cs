using System;

namespace CET2007_Assignment
{
    internal class GameLibrary : IComparable<GameLibrary>
    {
        // Public read-only properties
        public string Name { get; }
        public string Genre { get; }
        public int Year { get; }

        public GameLibrary(string sName, string sGenre, int iYear)
        {
            Name = sName;
            Genre = sGenre;
            Year = iYear;
        }

        // Implement CompareTo to satisfy IComparable<T>
        public int CompareTo(GameLibrary other)
        {
            if (other == null) return 1;
            return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() => Name;
    }
}