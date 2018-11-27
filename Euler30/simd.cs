using System;
using System.Numerics;

namespace Euler30
{
    class Simd
    {
        public static ulong Run(int powerToCalc)
        {
            uint[] pow = new uint[16];
            for (uint i = 0; i < 16; ++i)
            {
                if (i < 10)
                {
                    pow[i] = Misc.pow(i, powerToCalc);
                }
                else
                {
                    pow[i] = 0;
                }
            }

            Vector<uint>[] p10 = new Vector<uint>[10];
            p10[0] = new Vector<uint>(pow[1] - pow[0]);
            p10[1] = new Vector<uint>(pow[2] - pow[1]);
            p10[2] = new Vector<uint>(pow[3] - pow[2]);
            p10[3] = new Vector<uint>(pow[4] - pow[3]);
            p10[4] = new Vector<uint>(pow[5] - pow[4]);
            p10[5] = new Vector<uint>(pow[6] - pow[5]);
            p10[6] = new Vector<uint>(pow[7] - pow[6]);
            p10[7] = new Vector<uint>(pow[8] - pow[7]);
            p10[8] = new Vector<uint>(pow[9] - pow[8]);
            p10[9] = new Vector<uint>(pow[0] - pow[9]);


            /*
            Vector<uint> vSeq = new Vector<uint>(new uint[16] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0x80000000, 0x80000000, 0x80000000, 0x80000000, 0x80000000, 0x80000000 });
            Vector<uint> vPow = new Vector<uint>(pow);
            */
            Vector<uint> vSeq07 = new Vector<uint>(new uint[8] { 0, 1, 2, 3, 4, 5, 6, 7 });
            Vector<uint> vSeq89 = new Vector<uint>(new uint[8] { 8, 9, 0x80000000, 0x80000000, 0x80000000, 0x80000000, 0x80000000, 0x80000000 });
            Vector<uint> vPow07 = new Vector<uint>(pow, 0);
            Vector<uint> vPow89 = new Vector<uint>(pow, 8);

            Vector<uint> vTen = new Vector<uint>(10);
            Vector<uint> vSum = Vector<uint>.Zero;

            Console.WriteLine($"Vector.IsHardwareAccelerated: {Vector.IsHardwareAccelerated}, Vector<uint>.Count: {Vector<uint>.Count}");

            for (int a = 0; a < 10; a++)
            {
                for (int b = 0; b < 10; b++)
                {
                    for (int c = 0; c < 10; c++)
                    {
                        for (int d = 0; d < 10; d++)
                        {
                            for (int e = 0; e < 10; e++)
                            {
                                for (int f = 0; f < 10; f++)
                                {
                                    for (int g = 0; g < 10; g++)
                                    {
                                        for (int h = 0; h < 10; h++)
                                        {
                                            for (int i = 0; i < 10; i++)
                                            {
                                                Vector<uint> vEqu;
                                                //
                                                // 0..7
                                                //
                                                vEqu = Vector.Equals(vSeq07, vPow07);
                                                vEqu = Vector.BitwiseAnd(vEqu, vPow07);
                                                vSum = Vector.Add(vSum, vEqu);
                                                //
                                                // 8..9
                                                //
                                                vEqu = Vector.Equals(vSeq89, vPow89);
                                                vEqu = Vector.BitwiseAnd(vEqu, vPow89);
                                                vSum = Vector.Add(vSum, vEqu);
                                                //
                                                // seq++
                                                //
                                                vSeq07 = Vector.Add(vSeq07, vTen);
                                                vSeq89 = Vector.Add(vSeq89, vTen);
                                                //
                                                // pow++
                                                //
                                                vPow07 = Vector.Add(vPow07, p10[i]);
                                                vPow89 = Vector.Add(vPow89, p10[i]);
                                            }
                                            vPow07 = Vector.Add(vPow07, p10[h]);
                                            vPow89 = Vector.Add(vPow89, p10[h]);
                                        }
                                        vPow07 = Vector.Add(vPow07, p10[g]);
                                        vPow89 = Vector.Add(vPow89, p10[g]);
                                    }
                                    vPow07 = Vector.Add(vPow07, p10[f]);
                                    vPow89 = Vector.Add(vPow89, p10[f]);
                                }
                                vPow07 = Vector.Add(vPow07, p10[e]);
                                vPow89 = Vector.Add(vPow89, p10[e]);
                            }
                            vPow07 = Vector.Add(vPow07, p10[d]);
                            vPow89 = Vector.Add(vPow89, p10[d]);
                        }
                        vPow07 = Vector.Add(vPow07, p10[c]);
                        vPow89 = Vector.Add(vPow89, p10[c]);
                    }
                    vPow07 = Vector.Add(vPow07, p10[b]);
                    vPow89 = Vector.Add(vPow89, p10[b]);
                }
                vPow07 = Vector.Add(vPow07, p10[a]);
                vPow89 = Vector.Add(vPow89, p10[a]);
            }

            ulong sum = 0;
            for (int i=0; i< Vector<uint>.Count; ++i)
            {
                sum += vSum[i];
            }

            return sum - 1;
        }
    }
}
