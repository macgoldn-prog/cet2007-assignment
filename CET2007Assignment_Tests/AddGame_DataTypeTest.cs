using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CET2007Assignment_Tests
{
    [TestClass]
    public class AddGame_DataTypeTest
    {
        [TestMethod]
        public void YearInput_IntegerTest()
        {
            // checks if the year input is able to pass as an integer
            string userInput = "2021";
            bool parsed = int.TryParse(userInput, out int year);

            Assert.IsTrue(parsed, "Expected the year string to parse to an integer.");
            Assert.AreEqual(2021, year);
        }

        [TestMethod]
        public void NameAndGenre_AreStrings()
        {
            // checks if the name and genre inputs are strings and not empty
            string nameInput = "NewGame";
            string genreInput = "Action";

            Assert.IsInstanceOfType(nameInput, typeof(string), "Name input is not a string.");
            Assert.IsInstanceOfType(genreInput, typeof(string), "Genre input is not a string.");

            Assert.IsFalse(string.IsNullOrWhiteSpace(nameInput), "Name input should not be empty or whitespace.");
            Assert.IsFalse(string.IsNullOrWhiteSpace(genreInput), "Genre input should not be empty or whitespace.");
        }
    }
}