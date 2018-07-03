using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler_31
{
    class Program
    {
        private static readonly int[] coins = { 1, 2, 5, 10, 20, 50, 100, 200 };

        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int amount = 0; // 1, weil 2€ nur ein mal verwendet wird

            for (int a = 200; a >= 0; a -= 200)
            {
                for (int b = a; b >= 0; b -= 100)
                {
                    for (int c = b; c >= 0; c -= 50)
                    {
                        for (int d = c; d >= 0; d -= 20)
                        {
                            for (int e = d; e >= 0; e -= 10)
                            {
                                for (int f = e; f >= 0; f -= 5)
                                {
                                    for (int g = f; g >= 0; g -= 2)
                                    {
                                        amount++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Amount: {amount}");
            Console.WriteLine($"Dauer: {watch.ElapsedMilliseconds}");
            Console.ReadKey();
        }

    }
}
