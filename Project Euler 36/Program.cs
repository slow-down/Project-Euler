using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler_36
{
    class Program
    {
        static void Main(string[] args)
        {
            long sum = 0;
            for (int i = 0; i < 1000000; i++)
            {
                string bin = DecToBin(i);
                bool palinDec = IsPalindrom(i.ToString());
                bool palinBin = IsPalindrom(bin);
                if (palinDec && palinBin)
                {
                    sum += i;
                }
            }
            Console.WriteLine($"Sum: {sum}");

            Console.ReadKey();
        }

        private static string DecToBin(int dec)
        {
            if (dec == 0) return "0";
            StringBuilder builder = new StringBuilder();

            while (dec > 0)
            {
                builder.Append(dec % 2);
                dec /= 2;
            }

            return new string(builder.ToString().Reverse().ToArray());
        }

        private static bool IsPalindrom(string num)
        {
            if (num.Length == 1)
            {
                return true;
            }

            int max = num.Length / 2;
            for (int i = 0; i < max; i++)
            {
                if (num[i] != num[num.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}
