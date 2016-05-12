using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindTheDistance;

namespace FindTheDistanceTest
{
    [TestClass]
    public class DistanceMathTests
    {
        [TestMethod]
        public void CalculateDistanceValidCoordinatesTest()
        {
            var math = new DistanceMath();
            var origin = new Coordinate(0, 0);
            var durhamCoordinate = new Coordinate(36, -78.89);

            var result = math.CalculateDistance(origin, durhamCoordinate);
            var actual = 9009.85;

            Assert.AreEqual(result, actual);
        }
    }
}
