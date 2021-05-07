using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway.Projects.Extensions
{
    public static class Extensions
    {

        public static string AddDefaultValue(this string s)
        {
            
             return "The quick brown fox jumps over the lazy dog.";
        }

        public static string AddAnchalData(this string s)
        {
            return "Anchal Lama";
        }

        public static string AddHimanshuData(this string s)
        {
            return "Himanshu Tiwari";
        }
        public static int Increaseby1(this int i)
        {
            return i+1;
        }

        public static int IncreasebyNum(this int i, int number)
        {
            return i + number;
        }
    }
}
