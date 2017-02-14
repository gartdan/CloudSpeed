using Speed.Lib;
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
            var speedTester = new SpeedTester();
            speedTester.TestCompleteEvent += (o, e) => ReportSpeed(speedTester.LastDownloadSpeed);
            speedTester.ErrorEvent += (o, e) => ReportError(speedTester.ErrorMessage);
            speedTester.Start();
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
