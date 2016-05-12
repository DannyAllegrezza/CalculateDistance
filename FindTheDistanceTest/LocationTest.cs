using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindTheDistance;

namespace FindTheDistanceTest
{
    [TestClass]
    public class LocationTest
    {
        [TestMethod]
        public void ValidToStringTest()
        {
            var location = new Location("Durham NC", new Coordinate(36, -78.89));
            var expected = "Durham NC, 36, -78.89 - Distance from Origin (0, 0): 9009.85";
            var actual = location.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
