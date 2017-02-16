using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speed.Lib
{
    public static class StringExtensions
    {
        public static double ToDouble(this string str)
        {
            return Convert.ToDouble(str);
        }
    }
}
