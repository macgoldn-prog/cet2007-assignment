using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using CET2007_Assignment;


namespace CET2007Assignment_Tests
{
    [TestClass]
    public class LoggerTests
    {

        [TestMethod]
        public void Logger_GetInstance_IsSingleton()
        {

            // checks if the same instance is returned more than once
            var first = Logger.GetInstance();
            var second = Logger.GetInstance();

            Assert.IsNotNull(first);
            Assert.AreSame(first, second);
        }
    }
}
