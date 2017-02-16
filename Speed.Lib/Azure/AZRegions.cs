using Newtonsoft.Json;
using Speed.Lib.Geolocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Speed.Lib.Azure
{
  
    public class AZRegionInfo
    {
        public string displayName { get; set; }
        public string id { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string name { get; set; }
        public object subscriptionId { get; set; }

        public string DistanceAway { get; set; }

        public LatLong LatLong {
            get
            {
                return new LatLong(latitude, longitude);
            }
        }
    }

    public class AZRegions
    {
        private static readonly string RegionsJson = "https://dcgspeedcentralus.blob.core.windows.net/files/azregions.json";

        public async Task<IList<AZRegionInfo>> GetRegions()
        {
            string json = string.Empty;
            var result = new List<AZRegionInfo>();
            using (var httpClient = new HttpClient())
            {
                json = await httpClient.GetStringAsync(RegionsJson);
                result = JsonConvert.DeserializeObject<List<AZRegionInfo>>(json);
                return result;
            }
        }

        public async Task<IList<AZRegionInfo>> GetSortedRegions(LatLong source)
        {
            var regions = await GetRegions();
            regions.ToList().ForEach(x => x.DistanceAway = x.LatLong.DistanceTo(source).ToString());
            var sorted = regions.OrderBy(x => x.LatLong.DistanceTo(source));
            return sorted.ToList();
        }

        public async Task<AZRegionInfo> GetClosestRegion(LatLong source)
        {
            var regions = await GetSortedRegions(source);
            return regions[0];
        }
    }
}
