using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using flo = BigFloat;

namespace Project_Euler_56
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            // a^b
            // a 1-100
            // b 1-100
            flo max = 0;

            for (int a = 1; a < 100; a++)
            {
                for (int b = 1; b < 100; b++)
                {
                    flo sum = SumOfDigits(flo.Pow(a, b));
                    if (sum > max) max = sum;
                }
            }

            Console.WriteLine($"Biggest sum: {max}");
            Console.WriteLine($"Dauer: {watch.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }

        private static flo SumOfDigits(flo num)
        {
            flo sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num = num.Divide(10).Floor();
            }

            return sum;
        }
    }
}
