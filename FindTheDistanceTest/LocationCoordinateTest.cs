using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindTheDistance;

namespace FindTheDistanceTest
{
    [TestClass]
    public class LocationCoordinateTest
    {

        [TestMethod]
        public void LocationHasEmptyNameTest()
        {
            var location = new Location("", new Coordinate(46, -78.89));
            var expected = "N/A -- No Location Name Provided!";
            var result = location.Name;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LocationHasValidNameTest()
        {
            var location = new Location("Greensboro, NC", new Coordinate(45, 123.22));
            var expected = "Greensboro, NC";
            var result = location.Name;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CoordinateLatitudeOutOfRangeTest()
        {
            var coordinateWithBadLatitudeValue = new Coordinate(122, 55);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LatitudeGreaterThan90Test()
        {
            try
            {
                var coordinateWithBadLatitudeValue = new Coordinate(122, 55);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("The Latitude cannot be greater than 90. Please adjust the value accordingly!", ex.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LatitudeLessThanNeg90Test()
        {
            try
            {
                var coordinateWithBadLatitudeValue = new Coordinate(-122, 55);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("The Latitude cannot be less than -90. Please adjust the value accordingly!", ex.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LongitudeGreaterThan180Test()
        {
            try
            {
                var coordinateWithBadLatitudeValue = new Coordinate(55, 355);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("The Longitude cannot be greater than 180. Please adjust the value accordingly!", ex.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LongitudeLessThanNeg180Test()
        {
            try
            {
                var coordinateWithBadLatitudeValue = new Coordinate(44.22, -325);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("The Longitude cannot be less than -180. Please adjust the value accordingly!", ex.Message);
                throw;
            }
        }
    }
}


