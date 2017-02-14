using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Speed.Lib.Geolocation;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Speed.Tests
{
    [TestClass]
    public class AzureFunctionsTests
    {
        [TestMethod]
        public void GetLatLong()
        { 
            var geo = new Geolocator();
            var result = Task.Run(async () => await geo.GetLatLong()).Result;
            Assert.IsNotNull(result);

        }
    }
}
