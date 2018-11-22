﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Euler30
{
    class Digit
    {
        public byte[] digits;
        public ulong num;

        private StringBuilder sb;

        public Digit(int count)
        {
            digits = new byte[count];
            num = 0;
            sb = new StringBuilder(count);
            sb.Length = count;
        }

        public bool increment()
        {
            num += 1;

            byte uebertrag = 1;
            byte i = 0;

            while (i < digits.Length && uebertrag > 0)
            {
                if (digits[i] == 9)
                {
                    digits[i] = 0;
                    uebertrag = 1;
                }
                else
                {
                    digits[i] += 1;
                    uebertrag = 0;
                }
                ++i;
            }

            return uebertrag == 0;
        }
        public override string ToString()
        {
            int j = 0;
            for (int i=digits.Length-1; i >= 0; --i)
            {
                sb[j] = (char)(digits[i] + 0x30);
                j += 1;
            }
            return sb.ToString();
        }
    }
    class DigitGen : IEnumerator<Digit>
    {
        Digit IEnumerator<Digit>.Current => digit;

        public object Current => digit;

        private Digit digit;

        public DigitGen(int numDigits)
        {
            digit = new Digit(numDigits);
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return digit.increment();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

    }
}
