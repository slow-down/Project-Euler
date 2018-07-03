using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler_44
{
    class Program
    {
        private const int maxCache = 2200;
        private static int[] values = new int[maxCache];

        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            // Fill the cache
            for (int n = 1; n <= maxCache; n++)
            {
                values[n - 1] = (n * ((3 * n) - 1)) / 2;
            }

            int lowestDifference = int.MaxValue;

            for (int i = 0; i < maxCache - 1; i++)
            {
                for (int j = i + 1; j < maxCache; j++)
                {
                    int sum = values[i] + values[j];
                    bool Pj = IsPentagonal(sum);
                    if (!Pj) continue;

                    int diff = Math.Abs(values[i] - values[j]);
                    bool Pk = IsPentagonal(diff);

                    if (diff < lowestDifference) lowestDifference = diff;
                }
            }

            Console.WriteLine($"Lowest Difference D: {lowestDifference}");
            Console.WriteLine($"Dauer: {watch.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }

        private static bool IsPentagonal(int num)
        {
            foreach (var value in values)
            {
                if (value > num) return false;
                if (num == value) return true;
            }
            return false;
        }
    }
}
