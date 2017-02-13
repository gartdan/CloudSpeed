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
            speedTester.Start();
        }

        static void ReportSpeed(string speed)
        {
            Console.Clear();
            Console.Write(speed);
        }
    }
}
