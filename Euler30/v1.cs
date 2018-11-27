using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Euler30
{
    class v1
    {
        public static void Run6digits(int power)
        {
            ulong[] POW5 = Misc.genPowCachel(power);

            ulong sum = 0;
            ulong currNum = 0;

            for (uint a = 0; a < 10; ++a)
            {
                ulong powA = POW5[a];
                for (uint b = 0; b < 10; ++b)
                {
                    ulong SumAB = powA + POW5[b];
                    for (uint c = 0; c < 10; ++c)
                    {
                        ulong sumABC = SumAB + POW5[c];
                        for (uint d = 0; d < 10; ++d)
                        {
                            ulong SumABCD = sumABC + POW5[d];
                            for (uint e = 0; e < 10; ++e)
                            {
                                ulong SumABCDE = SumABCD + POW5[e];
                                for (uint f = 0; f < 10; ++f)
                                {
                                    ulong powered = SumABCDE + POW5[f];

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
            Console.WriteLine($"sum = {sum,10}");
        }
        public static void Run10digits()
        {
            uint[] POW = Misc.genPowCachei(9);

            ulong sum = 0;
            ulong currNum = 0;
            uint[] powSum = new uint[10];

            for (uint a = 0; a < 10; ++a)
            {
                powSum[0] = POW[a];
                for (uint b = 0; b < 10; ++b)
                {
                    powSum[1] = powSum[0] + POW[b];
                    for (uint c = 0; c < 10; ++c)
                    {
                        powSum[2] = powSum[1] + POW[c];
                        for (uint d = 0; d < 10; ++d)
                        {
                            powSum[3] = powSum[2] + POW[d];
                            for (uint e = 0; e < 10; ++e)
                            {
                                powSum[4] = powSum[3] + POW[e];
                                for (uint f = 0; f < 10; ++f)
                                {
                                    powSum[5] = powSum[4] + POW[f];
                                    for (uint g = 0; g < 10; ++g)
                                    {
                                        powSum[6] = powSum[5] + POW[g];
                                        for (uint h = 0; h < 10; ++h)
                                        {
                                            powSum[7] = powSum[6] + POW[h];
                                            for (uint i = 0; i < 10; ++i)
                                            {
                                                powSum[8] = powSum[7] + POW[i];
                                                for (uint j = 0; j < 10; ++j)
                                                {
                                                    powSum[9] = powSum[8] + POW[j];
                                                    if (currNum == powSum[9])
                                                    {
                                                        Console.Out.WriteLine($"currNum {currNum,10} = powered {a}{b}{c}{d}{e}{f}");
                                                        sum += powSum[9];
                                                    }
                                                    currNum += 1;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            sum -= 1;
            Console.WriteLine($"sum = {sum,10}");
        }
    }
}
