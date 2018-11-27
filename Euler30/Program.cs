using System;

namespace Euler30
{
    class Program
    {
        static void Main(string[] args)
        {
            //v2.Run(int.Parse(args[0]));  
            //v1.Run6digits(5);
            //v1.Run10digits();
            ulong sum = Simd.Run(9);

            Console.WriteLine($"sum: {sum}");
        }
    }
}
