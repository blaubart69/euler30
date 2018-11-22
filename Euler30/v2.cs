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
            int countDigits = 1;
            for (; countDigits < 20; ++countDigits)
            {
                ulong maxNumber = Misc.pow(9, power) * (ulong)countDigits;
                int maxDigits = Misc.digits(maxNumber);
                Console.WriteLine($"power={power}, digits={countDigits}, maxNumber (9^{power}*{countDigits})={maxNumber}, digits of maxNumber={maxDigits}");
                if (countDigits > maxDigits)
                {
                    --countDigits;
                    break;
                }
            }

            ulong[] powers = Misc.genPowCache(power);
            Console.WriteLine($"calculating up to {countDigits} digits");
            NumberGen numGen = new NumberGen(countDigits);

            ulong allsum = 0;
            while (numGen.increment())
            {
                ulong sum = 0;
                for (int i=0; i < countDigits; ++i)
                {
                    sum += powers[numGen.digits[i]];
                }

                if (numGen.num == sum)
                {
                    Console.WriteLine($"{numGen}");
                    allsum += sum;
                }
            }
            allsum -= 1;

            Console.WriteLine($"digits {countDigits}, allsum-1 {allsum}");
        }
    }
}
