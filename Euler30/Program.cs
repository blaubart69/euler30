using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler30
{
    class Program
    {
        static ulong pow5(ulong x)
        {
            return x * x * x * x * x;
        }

        static void Main(string[] args)
        {
            ulong sum = 0;
            ulong currNum = 0;
            for (uint a=0; a < 10; ++a)
            {
                ulong powA = pow5(a);
                for (uint b = 0; b < 10; ++b)
                {
                    ulong SumAB = powA + pow5(b);
                    for (uint c = 0; c < 10; ++c)
                    {
                        ulong sumABC = SumAB + pow5(c);
                        for (uint d = 0; d < 10; ++d)
                        {
                            ulong SumABCD = sumABC + pow5(d);
                            for (uint e = 0; e < 10; ++e)
                            {
                                ulong SumABCDE = SumABCD + pow5(e);
                                for (uint f = 0; f < 10; ++f)
                                {
                                    ulong SumABCDEF = SumABCDE + pow5(f);
                                    for (uint g = 0; g < 10; ++g)
                                    {
                                        ulong powered = SumABCDEF + pow5(g);

                                        if (currNum > 1 && currNum == powered)
                                        {
                                            Console.Out.WriteLine($"currNum {currNum} = powered {a}+{b}+{c}+{d}+{e}+{f}+{g}");
                                            sum += powered;
                                        }

                                        currNum += 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(sum);
        }

        private static ulong calcNum(uint a, uint b, uint c, uint d, uint e, uint f, uint g)
        {
            return
                a * 1000000
                + b * 100000
                + c * 10000
                + d * 1000
                + e * 100
                + f * 10
                + g;
        }
    }
}
