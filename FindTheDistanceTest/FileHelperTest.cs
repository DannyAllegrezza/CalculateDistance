using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindTheDistance;

namespace FindTheDistanceTest
{
    [TestClass]
    public class FileHelperTest
    {
        [TestMethod]
        public void FileReadProperlyTest()
        {
            var fileHelper = new FileHelper();
            var locationData = fileHelper.ReadTextFile("../../../FindTheDistance/Data/location data.txt");
            Assert.IsTrue(locationData != null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MissingFileLocationTest()
        {
            var fileHelper = new FileHelper();
            var locationData = fileHelper.ReadTextFile("");
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void BadFileLocationTest()
        {
            var fileHelper = new FileHelper();
            var locationData = fileHelper.ReadTextFile("/data/test.txt");
        }
    }
}
