using Speed.Lib.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speed.Lib
{
    public class DownloadFileUrlProvider : IDownloadFileUrlProvider
    {
        private static readonly string UrlFormat = "https://dcgspeed{0}.blob.core.windows.net/files/1MB.dat";

        public string GetUrl(AzureRegions region)
        {
            return GetUrlByRegion(ValidRegions.GetRegionString(region));
        }

        public string GetUrlByRegion(string region)
        {
            return string.Format(UrlFormat, region);
        }

 
    }

    public enum AzureRegions
    {
        WestUS,
        NorthCentralUS,
        CentralUS,
        EastUS,
        SouthCentralUS,
        WestCentralUS, WestUS2,
        EastUS2,
        EastAsia, SoutheastAsia,
        NorthEurope, WestEurope,
        JapanWest, JapanEast,
        BrazilSouth, AustraliaEast, AustrailiaWest,
        CanadaCentral, CanadaEast,
        SouthIndia, CentralIndia,
        UKWest,
        KoreaCentral, KoreaSouth

    }
}
