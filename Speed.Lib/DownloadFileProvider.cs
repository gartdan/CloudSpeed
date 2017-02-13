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
            return GetUrlByRegion(GetRegionString(region));
        }

        public string GetUrlByRegion(string region)
        {
            return string.Format(UrlFormat, region);
        }

        public static string GetRegionString(AzureRegions region)
        {
            switch (region)
            {
                case AzureRegions.CentralUS:
                    return "centralus";
                case AzureRegions.EastUS:
                    return "eastus";
                case AzureRegions.NorthCentralUS:
                    return "northcentral";
                case AzureRegions.SouthCentralUS:
                    return "southcentral";
                case AzureRegions.WestUS:
                    return "westus";
                default:
                    throw new ArgumentException("bad region");
            }
        }
    }

    public enum AzureRegions
    {
        WestUS,
        NorthCentralUS,
        CentralUS,
        EastUS,
        SouthCentralUS
    }
}
