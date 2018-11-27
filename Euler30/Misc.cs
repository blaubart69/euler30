using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler30
{
    class Misc
    {
        public static ulong pow(ulong num, int power)
        {
            ulong pow = num;
            for (int i=0; i < power-1; ++i)
            {
                pow = pow * num;
            }

            return pow;
        }
        public static uint pow(uint num, int power)
        {
            uint pow = num;
            for (int i = 0; i < power - 1; ++i)
            {
                pow = pow * num;
            }

            return pow;
        }
        public static uint[] genPowCachei(int power)
        {
            uint[] POW = new uint[10];
            for (uint i = 0; i < 10; ++i)
            {
                POW[i] = Misc.pow(i, power);
            }

            return POW;
        }
        public static ulong[] genPowCachel(int power)
        {
            ulong[] POW = new ulong[10];
            for (uint i = 0; i < 10; ++i)
            {
                POW[i] = Misc.pow(i, power);
            }

            return POW;
        }
        public static int digits(ulong value)
        {
            return value.ToString().Length;
        }
    }
}
