using Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler_39
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int maxIndex = 0;
            int maxP = 0;

            for (int i = 0; i <= 1000; i++)
            {
                int max = 0;
                for (double a = 0; a <= i; a++)
                {
                    for (double b = a + 1; b <= i; b++)
                    {
                        if (a + b > i) break;
                        double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                        if (a + b + c > i) break;
                        if (a + b + c == i)
                        {
                            max++;
                        }
                    }
                }
                if (max > maxP)
                {
                    maxP = max;
                    maxIndex = i;
                }
            }

            Console.WriteLine($"Max index: {maxIndex}");
            Console.WriteLine($"Max value of p: {maxP}");
            Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }

    }
}
