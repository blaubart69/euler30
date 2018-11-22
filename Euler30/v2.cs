using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler30
{
    class v2
    {
        public static void Run(int power)
        {
            for (ulong i = 1; i < 10; ++i)
            {
                ulong max = Misc.pow(9, power) * i;
                Console.WriteLine($"power={power}, digits={i}, max={max}");
            }

            ulong[] powers = Misc.genPowCache(power);

            int lenDig = 6;

            IEnumerator<Digit> gen = new DigitGen(lenDig);

            ulong allsum = 0;
            while (gen.MoveNext())
            {
                ulong sum = 0;
                for (int i=0; i < lenDig; ++i)
                {
                    sum += powers[gen.Current.digits[i]];
                }

                if (gen.Current.num == sum)
                {
                    Console.WriteLine($"{gen.Current}");
                    allsum += sum;
                }
            }
            allsum -= 1;

            Console.WriteLine($"digits {lenDig}, allsum-1 {allsum}");
        }
    }
}
