using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speed.Lib.Azure
{
    public class ValidRegions
    {
        public static List<Tuple<string, AzureRegions>> Regions = new List<Tuple<string, AzureRegions>>()
        {
            new Tuple<string, AzureRegions>("westus", AzureRegions.WestUS),
            new Tuple<string, AzureRegions>("centralus", AzureRegions.CentralUS),
            new Tuple<string, AzureRegions>("eastus", AzureRegions.EastUS),
            new Tuple<string, AzureRegions>("southcentralus", AzureRegions.SouthCentralUS),
            new Tuple<string, AzureRegions>("northcentralus", AzureRegions.NorthCentralUS),
        };

        public static readonly string DefaultRegion = "westus";

        public static bool IsValidRegion(string region)
        {
            return Regions.Where(x => x.Item1 == region).Count() == 1;
        }

        

        public static AzureRegions GetRegionFromString(string region)
        {
            if (!IsValidRegion(region))
                throw new ArgumentException(region);
            return Regions.First(x => x.Item1 == region).Item2;
        }

        public static string GetRegionString(AzureRegions region)
        {
            var pair = Regions.FirstOrDefault(x => x.Item2 == region);
            if (pair == null)
                throw new ArgumentException("invalid region");
            return pair.Item1;
        }


    }
}
