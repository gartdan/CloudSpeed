using Speed.Lib;
using Speed.Lib.Azure;
using Speed.Lib.Geolocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speed.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var region = Task.Run(async() => await GetClosestRegion()).Result;
            var regionName = region.name;
            PrintRegionDetails(region);
            if (args.Length > 0)
            {
                var input = args[0];
                if (input == "/q")
                    return;
                else
                    regionName = input;    
            }

            if (!ValidRegions.IsValidRegion(regionName))
            {
                Console.WriteLine("not a valid region. defaulting to westus" + regionName);
                regionName = ValidRegions.DefaultRegion;
            }
            else
            {
                Print("Region set to:" + regionName);
            }

            var speedTester = new SpeedTester(regionName);
            speedTester.TestCompleteEvent += (o, e) => ReportSpeed(speedTester.LastDownloadSpeed);
            speedTester.ErrorEvent += (o, e) => ReportError(speedTester.ErrorMessage);
            speedTester.Start();
        }

        private static void PrintRegionDetails(AZRegionInfo region)
        {
            Console.Clear();
            Console.WriteLine($"Closest Azure Region is: {region.name}. It is {region.DistanceAway} KM away");
            System.Threading.Thread.Sleep(1000);
        }

        private static async Task<AZRegionInfo> GetClosestRegion()
        {
            var geolocator = new Geolocator();
            var closestRegion = await geolocator.GetClosestRegion();
            return closestRegion;
        }

        static void ReportError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Print(message);
        }

        static void ReportSpeed(string speed)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Print(speed);
        }

        private static void Print(string speed)
        {
            Console.Clear();
            Console.Write(speed);
        }
    }
}
