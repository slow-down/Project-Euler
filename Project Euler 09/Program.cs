using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

/* 
    A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
    a² + b² = c²

    For example, 3² + 4² = 9 + 16 = 25 = 5².

    There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    Find the product abc.

    Answer = 31875000
 */

namespace Project_Euler_09
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            Console.WriteLine(FindPythagoreanTriplet(1000));

            Console.WriteLine($"Dauer: {watch.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }


        private static int FindPythagoreanTriplet(int expectedSum)
        {
            for (int b = 2; b < expectedSum; b++)
            {
                for (int a = 1; a < b; a++)
                {
                    int c = (int)Math.Sqrt((a * a) + (b * b));

                    if (a + b + c == expectedSum && IsPythagorean(a, b, c)) return a * b * c;
                }
            }
            return -1;
        }


        private static bool IsPythagorean(int a, int b, int c)
        {
            return (a * a) + (b * b) == (c * c);
        }
    }
}
