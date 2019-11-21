using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTopologySuiteClassLib;

namespace NetTopologySuiteUnitTest
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void AccessLog()
        {
            // Create an instance to test:
            Logger logger = new Logger();
            // Act and assert
            Assert.IsTrue(logger.Log is object);

        }
        [TestMethod]
        public void UpdateLogMessage()
        {
            // Arrange
            string expected = "this value should be ";
            Logger logger = new Logger();
            // Act 
            logger.Log = expected;
            // Assert
            Assert.AreEqual<string>(logger.Log, expected);
        }
    }
}
