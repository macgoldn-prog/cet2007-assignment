using Microsoft.VisualStudio.TestTools.UnitTesting;
using CET2007_Assignment;

namespace CET2007Assignment_Tests
{
    [TestClass]
    public class GameLibrary_Test
    {
        [TestMethod]
        public void GameLibrary_ConstructorTest()
        {
            // checks assignment of properties
            var game = new GameLibrary("TestName", "TestGenre", 1999);

            Assert.IsNotNull(game);
            Assert.AreEqual("TestName", game.Name);
            Assert.AreEqual("TestGenre", game.Genre);
            Assert.AreEqual(1999, game.Year);
            Assert.AreEqual("TestName", game.ToString());
        }
    }
}