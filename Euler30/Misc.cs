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
        public static ulong[] genPowCache(int power)
        {
            ulong[] POW = new ulong[10];
            for (ulong i = 0; i < 10; ++i)
            {
                POW[i] = Misc.pow(i, power);
            }

            return POW;
        }
    }
}
