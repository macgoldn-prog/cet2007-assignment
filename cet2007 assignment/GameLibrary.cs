using System;

namespace CET2007_Assignment
{
    public class GameLibrary : IComparable<GameLibrary> // allows comparison for the sorting algorithm later
    {

        public string Name { get; } // public read only
        public string Genre { get; }
        public int Year { get; }


        public GameLibrary(string name, string genre, int year) // constructor 
        { 
            Name = name;
            Genre = genre;
            Year = year;
        }


        public int CompareTo(GameLibrary other) // comparison method for sorting
        {
            if (other == null) return 1;
            return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() => Name;
    }
}