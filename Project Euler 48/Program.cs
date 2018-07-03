using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using flo = BigFloat;

namespace Project_Euler_48
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            flo sum = 0;
            for (int i = 1; i <= 1000; i++)
            {
                sum += flo.Pow(i, i);
            }

            Console.WriteLine($"Number length: {sum.ToString().Length}");
            Console.WriteLine($"Last 10 Digits: {sum.ToString().Substring(sum.ToString().Length - 10, 10)}");
            Console.WriteLine($"Time: {watch.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }
    }
}
