using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Project_Euler_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int sum = 0;
            for (int i = 1; i < 100; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine(sum);
            Console.WriteLine($"Dauer: {watch.ElapsedMilliseconds}ms");

            Console.ReadKey();
        }
    }
}
