using Speed.Lib;
using Speed.Lib.Azure;
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
            string region = GetClosestRegion();
            if (args.Length > 0)
            {
                region = args[0];
                if (!ValidRegions.IsValidRegion(region))
                {
                    Console.WriteLine("not a valid region. defaulting to westus" + region);
                    region = ValidRegions.DefaultRegion;
                } else
                {
                    Print("Region set to:" + region);
                }
                    
            }
            var speedTester = new SpeedTester();
            
            speedTester.TestCompleteEvent += (o, e) => ReportSpeed(speedTester.LastDownloadSpeed);
            speedTester.ErrorEvent += (o, e) => ReportError(speedTester.ErrorMessage);
            speedTester.Start();
        }

        private static string GetClosestRegion()
        {
            return "westus";
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
