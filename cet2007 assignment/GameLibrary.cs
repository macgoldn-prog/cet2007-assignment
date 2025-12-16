using System;

namespace CET2007_Assignment
{
    public class GameLibrary : IComparable<GameLibrary>
    {

        public string Name { get; }
        public string Genre { get; }
        public int Year { get; }


        public GameLibrary(string name, string genre, int year)
        {
            Name = name;
            Genre = genre;
            Year = year;
        }


        public int CompareTo(GameLibrary other)
        {
            if (other == null) return 1;
            return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() => Name;
    }
}