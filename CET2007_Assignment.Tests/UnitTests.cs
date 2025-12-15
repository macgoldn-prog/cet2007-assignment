using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using CET2007_Assignment;

namespace CET2007_Assignment.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void GameLibrarySortsAlphabetically()
        {
            var a = new GameLibrary("Alpha", "Genre", 2000);
            var b = new GameLibrary("Beta", "Genre", 2001);

     
            Assert.IsTrue(a.CompareTo(b) < 0);
            Assert.IsTrue(b.CompareTo(a) > 0);
        }

        [TestMethod]
        public void GameLibraryNameReturnTest()
        {
            var g = new GameLibrary("MyGame", "Arcade", 1999);
            Assert.AreEqual("MyGame", g.ToString());
        }

        [TestMethod]
        public void ReportLogTesT()
        {
            var before = DateTime.UtcNow;
            var r = new ReportLog("test message");
            var after = DateTime.UtcNow;

            Assert.IsTrue(r.Timestamp >= before.AddSeconds(-1) && r.Timestamp <= after.AddSeconds(1),
                $"Timestamp {r.Timestamp:o} not within expected range ({before:o} - {after:o})");
            Assert.AreEqual("test message", r.Message);
        }

        [TestMethod]
        public void Logger_GetInstanceTest()
        {
            var inst1 = Logger.GetInstance();
            var inst2 = Logger.GetInstance();
            Assert.IsNotNull(inst1);
            Assert.AreSame(inst1, inst2);

            inst1.Log("UnitTest", "Logger test message");
            inst1.Log("Simple message");
        }

        [TestMethod]
        public void GameManagement_LoadFromJsonandFile()
        {
        
            var jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "games.json");
            var sampleJson = "[{\"Name\":\"Game A\",\"Genre\":\"Action\",\"Year\":2000},{\"Name\":\"Game B\",\"Genre\":\"Puzzle\",\"Year\":2005}]";
            File.WriteAllText(jsonPath, sampleJson);

            try
            {
                var gm = new GameManagement();
                var games = new List<GameLibrary>();
                gm.LoadFromJson(games);

                Assert.AreEqual(2, games.Count);
                Assert.AreEqual("Game A", games[0].Name);
                Assert.AreEqual("Game B", games[1].Name);
            }
            finally
            {
           
                if (File.Exists(jsonPath))
                {
                    try { File.Delete(jsonPath); } 
                    catch {  }
                }
            }
        }
    }
}