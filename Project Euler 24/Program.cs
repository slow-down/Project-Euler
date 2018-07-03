using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


/*
    A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. 
    If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:

    012   021   102   120   201   210

    What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
*/

namespace Project_Euler_24
{
    class Program
    {
        private const int min = 48;
        private const int max = 58;
        private static int[] nums = new int[10000000];
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            //Run();  // 27sek
            var result = GetPermutations(Enumerable.Range(0, 10), 10);

            int i = 1;
            foreach (var item in result)
            {
                if(i++ == 1000000)
                {
                    foreach (var ch in item)
                    {
                        Console.Write(ch);
                    }
                    Console.WriteLine();
                    break;
                }
            }


            Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        private static void Run()
        {
            int count = 1;

            for (int a = min; a < max; a++)
            {
                for (int b = min; b < max; b++)
                {
                    for (int c = min; c < max; c++)
                    {
                        for (int d = min; d < max; d++)
                        {
                            for (int e = min; e < max; e++)
                            {
                                for (int f = min; f < max; f++)
                                {
                                    for (int g = min; g < max; g++)
                                    {
                                        for (int h = min; h < max; h++)
                                        {
                                            for (int i = min; i < max; i++)
                                            {
                                                for (int j = min; j < max; j++)
                                                {
                                                    if (a == b || a == c || a == d || a == e || a == f || a == g || a == h || a == i || a == j ||
                                                        b == c || b == d || b == e || b == f || b == g || b == h || b == i || b == j ||
                                                        c == d || c == e || c == f || c == g || c == h || c == i || c == j ||
                                                        d == e || d == f || d == g || d == h || d == i || d == j ||
                                                        e == f || e == g || e == h || e == i || e == j ||
                                                        f == g || f == h || f == i || f == j ||
                                                        g == h || g == i || g == j ||
                                                        h == i || h == j ||
                                                        i == j) continue;

                                                    if(count % 10000 == 0) Console.WriteLine(count);
                                                    if (count == 1000000)
                                                    {
                                                        Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}", (char)a, (char)b, (char)c, (char)d, (char)e, (char)f, (char)g, (char)h, (char)i, (char)j);
                                                        Console.WriteLine("Finish");
                                                        return;
                                                    }
                                                    count++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


    }
}
