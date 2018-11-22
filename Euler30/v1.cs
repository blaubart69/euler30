using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler30
{
    class v1
    {
        public static void Run()
        {
            ulong[] POW5 = Misc.genPowCache(5);

            ulong sum = 0;
            ulong currNum = 0;
            ulong adds = 0;

            for (uint a = 0; a < 10; ++a)
            {
                ulong powA = POW5[a];
                for (uint b = 0; b < 10; ++b)
                {
                    ulong SumAB = powA + POW5[b];   ++adds;
                    for (uint c = 0; c < 10; ++c)
                    {
                        ulong sumABC = SumAB + POW5[c]; ++adds;
                        for (uint d = 0; d < 10; ++d)
                        {
                            ulong SumABCD = sumABC + POW5[d]; ++adds;
                            for (uint e = 0; e < 10; ++e)
                            {
                                ulong SumABCDE = SumABCD + POW5[e]; ++adds;
                                for (uint f = 0; f < 10; ++f)
                                {
                                    ulong powered = SumABCDE + POW5[f]; ++adds;

                                    if (currNum == powered)
                                    {
                                        Console.Out.WriteLine($"currNum {currNum,10} = powered {a}{b}{c}{d}{e}{f}");
                                        sum += powered;
                                    }

                                    currNum += 1;
                                }
                            }
                        }
                    }
                }
            }
            sum -= 1;
            Console.WriteLine($"sum-1 = {sum,10}, adds performed: {adds:N0}");
        }
    }
}
