using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler_45
{
    class Program
    {
        private static List<long> triangle = new List<long>();
        private static List<long> pentagonal = new List<long>();
        private static List<long> hexagonal = new List<long>();

        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            GenerateTriangles();
            GeneratePentagonals();
            GenerateHexagonals();

            for (int t = 285; t < triangle.Count; t++)
            {
                for (int p = 165; p < pentagonal.Count; p++)
                {
                    if (pentagonal[p] > triangle[t]) break;
                    if (pentagonal[p] < triangle[t]) continue;

                    for (int h = 143; h < hexagonal.Count; h++)
                    {
                        if (hexagonal[h] > triangle[t]) break;
                        if (hexagonal[h] < triangle[t]) continue;

                        if (triangle[t] == pentagonal[p] && triangle[t] == hexagonal[h])
                        {
                            Console.WriteLine($"T: {t + 1} - P: {p + 1} - H: {h + 1} - Value: {triangle[t]}");
                            goto END;
                        }
                    }
                }
            }

            END:
            Console.WriteLine("------------");
            Console.WriteLine(triangle[triangle.Count - 1]);
            Console.WriteLine(pentagonal[pentagonal.Count - 1]);
            Console.WriteLine(hexagonal[hexagonal.Count - 1]);
            Console.WriteLine($"Dauer: {watch.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }

        private static void GenerateTriangles()
        {
            for (long n = 1; ; n++)
            {
                long num = n * (n + 1) / 2;
                if (num < 0)
                {
                    return;
                }
                triangle.Add(num);
            }
        }

        private static void GeneratePentagonals()
        {
            for (long n = 1; ; n++)
            {
                long num = n * ((3 * n) - 1) / 2;
                if (num < 0) return;
                pentagonal.Add(num);
            }
        }

        private static void GenerateHexagonals()
        {
            for (long n = 1; ; n++)
            {
                long num = n * ((2 * n) - 1);
                if (num < 0) return;
                hexagonal.Add(num);
            }
        }



    }
}
