using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using flo = BigFloat;

namespace Project_Euler_53
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int sum = 0;

            for (int n = 1; n <= 100; n++)
            {
                for (int r = 1; r < n; r++)
                {
                    if (Combinatoric(n, r) > 1000000) sum++;
                }
            }

            Console.WriteLine($"Amount: {sum}");
            Console.WriteLine($"Dauer: {watch.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }

        private static flo Factorial(int num)
        {
            flo n = 1;
            for (int i = 2; i <= num; i++)
            {
                n *= i;
            }
            return n;
        }

        private static flo Combinatoric(int n, int r)
        {
            // n choose r
            return (Factorial(n)) / (Factorial(r) * Factorial(n - r));
        }

    }
}
