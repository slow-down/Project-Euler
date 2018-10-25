using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler_30
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = Stopwatch.StartNew();

            var sum = 0;
            var limit = Pow(9, 5) * 6;

            for (int i = 2; i < limit; i++)
            {
                var tmpI = i;
                var tmpSum = 0;

                while (tmpI > 0)
                {
                    tmpSum += Pow(tmpI % 10, 5);
                    tmpI /= 10;
                }

                if (tmpSum == i)
                    sum += i;
            }


            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Finished in {timer.Elapsed.TotalMilliseconds:F4}ms");
            Console.ReadKey();
        }

        private static int Pow(int a, int b)
        {
            var result = a;

            for (int i = 1; i < b; i++)
            {
                result *= a;
            }

            return result;
        }

    }
}
