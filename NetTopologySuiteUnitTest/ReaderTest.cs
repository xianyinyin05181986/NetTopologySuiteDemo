using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTopologySuiteClassLib;
using System;
using System.IO;

namespace NetTopologySuiteUnitTest
{
    [TestClass]
    public class ReaderTest
    {
        [TestMethod]
        public void ThrowFileNotFoundExceptionWhenPathIsInvalid()
        {
            // Arrange
            string path = @"jdjdkfa";
            FileReader fileReader = new FileReader();
            // Act and Assert
            Assert.ThrowsException<FileNotFoundException>(() => { fileReader.SetupReader(path); });
        }
        [TestMethod]
        public void SetupReaderTest()
        {
            // Arrange
            string path = @"C:\Users\vts-developer\Downloads\ShapeFile\ShapeFile\points.shp";
            FileReader fileReader = new FileReader();
            // Act and Assert
            fileReader.SetupReader(path);
        }

        [TestMethod]
        public void ThroInvalidOperationExceptionWhenAttributeNameIsEmpty()
        {
            // Arrange
            string path = @"C:\Users\vts-developer\Downloads\ShapeFile\ShapeFile\points.shp";
            string errorAttribute = "";
            FileReader fileReader = new FileReader();
            // Act and Assert
            Assert.ThrowsException<InvalidOperationException>(() => { fileReader.GetAttributeValueSum(errorAttribute, path); });
        }
        [TestMethod]
        public void LoggingDoesnotFailWhileReadingValidShapeFile()
        {
            // Arrange
            string path = @"C:\Users\vts-developer\Downloads\ShapeFile\ShapeFile\points.shp";
            string attribute = "value1";
            FileReader fileReader = new FileReader();
            // Act and Assert
            Assert.IsNotNull(fileReader.GetAttributeValueSum(attribute, path));
        }

        [TestMethod]
        public void GetLogMessageAfterExecuteTheMethod()
        {

            // Arrange
            string path = @"C:\Users\vts-developer\Downloads\ShapeFile\ShapeFile\points.shp";
            string attribute = "value1";
            FileReader fileReader = new FileReader();

            // Act 
            fileReader.GetAttributeValueSum(attribute, path);
            // Assert
            Assert.IsNotNull(fileReader.ShowLog());
        }

    }
}
