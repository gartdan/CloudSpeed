using Speed.Lib.Azure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Speed.Lib
{
    public class NetworkSpeedProvider
    {
        private IDownloadFileUrlProvider _fileProvider;

        public NetworkSpeedProvider(IDownloadFileUrlProvider fileProvider)
        {
            this._fileProvider = fileProvider;
        }

        public double GetInternetSpeed(AzureRegions region)
        {
            return GetInternetSpeed(ValidRegions.GetRegionString(region));
        }

        public double GetInternetSpeed(string region)
        {
            using (var webClient = new WebClient())
            {
                var sw = new Stopwatch();
                sw.Start();
                var data = webClient.DownloadData(this._fileProvider.GetUrlByRegion(region));
                sw.Stop();
                var elapsed = sw.ElapsedMilliseconds;
                var bytesPerSecond = Convert.ToDouble(data.Length) / (Convert.ToDouble(sw.ElapsedMilliseconds) / 1000d);
                return Math.Round(bytesPerSecond, 2);
            }
        }
    }
}
