using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speed.Lib
{
    public class SpeedFormatter
    {
        private static readonly double Megabyte = 1048576d;
        private static readonly double Kilobyte = 1024d;
        public string GetSpeed(double bytesPerSecond)
        {
            if(bytesPerSecond >= Megabyte)
            {
                return $"{Math.Round(bytesPerSecond / Megabyte, 2)} MB/s";
            }
            else
            {
                return $"{Math.Round(bytesPerSecond / Kilobyte, 2)} KB/s";
            }
        }
    }
}
