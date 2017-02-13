using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Speed.Lib;

namespace Speed.Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void DownloadFileProvider_EastUSReturnsCorrectUrl()
        {
            var expected = "https://dcgspeedeastus.blob.core.windows.net/files/1MB.dat";
            var sut = new DownloadFileUrlProvider();
            var actual = sut.GetUrl(AzureRegions.EastUS);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void NetworkSpeedProvider_DownloadsAndReturnsSpeed()
        {
            var speedProvider = new NetworkSpeedProvider(new DownloadFileUrlProvider());
            var speed = speedProvider.GetInternetSpeed("westus");
            System.Diagnostics.Debug.WriteLine(speed);
            Assert.IsTrue(speed > 0.0d);
        }

        [TestMethod]
        public void NetworkStringFormatter_FormatsMegabytes()
        {
            var sut = new SpeedFormatter();
            var result = sut.GetSpeed(23442345355234);
            Assert.IsTrue(result.EndsWith("MB/s"), result);
        }

        [TestMethod]
        public void NetworkStringFormatter_FormatsKilobytes()
        {
            var sut = new SpeedFormatter();
            var result = sut.GetSpeed(234444);
            Assert.IsTrue(result.EndsWith("KB/s"), result);
        }
    }
}
