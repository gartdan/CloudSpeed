using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Speed.Lib.Geolocation
{
    public class Geolocator
    {
        private static readonly string LatLongUrl = "https://dcgwhereismy.azurewebsites.net/api/LatLongFunction";
        private static readonly string LatLongJsonUrl = "https://dcgwhereismy.azurewebsites.net/api/LatLongJson";
        private static readonly string AzureRegionsUrl = "";

        public async Task<LatLong> GetLatLong()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(LatLongUrl);
                if(!string.IsNullOrEmpty(response))
                {
                    var parts = response.Split(',');
                    return new LatLong()
                    {
                        Latitude = parts[0],
                        Longitude = parts[1]
                    };
                }
            }
            return null;
        }
    }

    public class LatLong
    {
        public string Latitude { get; set; }
        public string  Longitude { get; set; }
    }
}
