using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Speed.Lib.Geolocation;
using Speed.Lib.Azure;
using System.Threading.Tasks;

namespace Speed.Tests
{
    [TestClass]
    public class GeolocatorTests
    {
        [TestMethod]
        public void GetDistanceTest()
        {
            var source = new LatLong("32.9697", "-96.80322");
            var dest = new LatLong("29.46786", "-98.53506");
            var result = source.DistanceTo(dest, 'K');
            Assert.IsTrue(result >= 420 && result <= 425);
        }

        [TestMethod]
        public void GetAzureRegionsTest()
        {
            var sut = new AZRegions();
            var regions = Task.Run(async () => await sut.GetRegions()).Result;
            Assert.IsTrue(regions.Count > 0);
        }

        [TestMethod]
        public void GetClosestAzureRegionTest()
        {
            var sut = new AZRegions();
            var seattle = new LatLong("47.606209", "-122.332071");
            var regions = Task.Run(async () => await sut.GetSortedRegions(seattle)).Result;
            Assert.IsTrue(regions.Count > 0);
            var firstRegion = regions[0];
            Assert.AreEqual("westus2", firstRegion.name);
        }


    }
}
