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
            new Tuple<string, AzureRegions>("westus2", AzureRegions.WestUS2),
            new Tuple<string, AzureRegions>("eastus2", AzureRegions.EastUS2),


            new Tuple<string, AzureRegions>("centralus", AzureRegions.CentralUS),
            new Tuple<string, AzureRegions>("eastus", AzureRegions.EastUS),
            new Tuple<string, AzureRegions>("southcentralus", AzureRegions.SouthCentralUS),
            new Tuple<string, AzureRegions>("northcentralus", AzureRegions.NorthCentralUS),
            new Tuple<string, AzureRegions>("westcentralus", AzureRegions.WestCentralUS),

            new Tuple<string, AzureRegions>("northeurope", AzureRegions.NorthEurope),
            new Tuple<string, AzureRegions>("westeurope", AzureRegions.WestEurope),

            new Tuple<string, AzureRegions>("japanwest", AzureRegions.JapanWest),
            new Tuple<string, AzureRegions>("japaneast", AzureRegions.JapanEast),

            new Tuple<string, AzureRegions>("brazilsouth", AzureRegions.BrazilSouth),
            new Tuple<string, AzureRegions>("australiaeast", AzureRegions.AustraliaEast),

            new Tuple<string, AzureRegions>("southindia", AzureRegions.SouthIndia),
            new Tuple<string, AzureRegions>("centralindia", AzureRegions.CentralIndia),

            new Tuple<string, AzureRegions>("canadacentral", AzureRegions.CanadaCentral),
            new Tuple<string, AzureRegions>("canadaeast", AzureRegions.CanadaEast),

            new Tuple<string, AzureRegions>("ukwest", AzureRegions.UKWest),
            new Tuple<string, AzureRegions>("koreacentral", AzureRegions.KoreaCentral),
            new Tuple<string, AzureRegions>("koreasouth", AzureRegions.KoreaSouth),










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
