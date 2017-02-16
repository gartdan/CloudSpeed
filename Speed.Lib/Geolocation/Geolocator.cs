using Newtonsoft.Json;
using Speed.Lib.Azure;
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
                    return new LatLong(parts[0], parts[1]);
                }
            }
            return null;
        }

        public async Task<AZRegionInfo> GetClosestRegion()
        {
            var myLocation = await GetLatLong();
            var regions = new AZRegions();
            return await regions.GetClosestRegion(myLocation);
        }

        public async Task<LocationDetails> GetLocationDetails()
        {
            using(var client = new HttpClient())
            {
                var json = await client.GetStringAsync(LatLongJsonUrl);
                dynamic data = JsonConvert.DeserializeObject(json);
                var locationDetails = new LocationDetails();
                locationDetails.City = data.city;
                locationDetails.CountryCode = data.country_code;
                locationDetails.CountryName = data.country_name;
                locationDetails.LatLong = new LatLong(Convert.ToString(data.latitude), Convert.ToString(data.longitude)); 
                locationDetails.ZipCode = data.zip_code;
                locationDetails.RegionCode = data.region_code;
                locationDetails.RegionName = data.region_name;
                return locationDetails;
            }
        }

        public async Task<RegionInfo> GetAzureRegions()
        {
            return null;
        }
    }

    public class LatLong
    {
        public string Latitude { get; set; }
        public string  Longitude { get; set; }

        public LatLong(string lat, string longitude)
        {
            this.Latitude = lat;
            this.Longitude = longitude;
        }

        public double DistanceTo(LatLong destination, char format)
        {
            return LatLongDistanceCalculator.DistanceTo(
                this.Latitude.ToDouble(), this.Longitude.ToDouble(),
                destination.Latitude.ToDouble(), destination.Longitude.ToDouble(), format);
        }

        public double DistanceTo(LatLong destination)
        {
            return DistanceTo(destination, 'K');
        }

    }

    public class LocationDetails
    {
        public LatLong LatLong { get; set; }
        public string CountryName { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string ZipCode { get; set; }
    }
}
