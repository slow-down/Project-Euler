using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using flo = BigFloat;

namespace Project_Euler_29
{
    class Program
    {
        static void Main(string[] args)
        {
            DistinctPowers(100, 100);

            Console.ReadKey();
        }

        private static void DistinctPowers(int maxA, int maxB)
        {
            List<flo> list = new List<flo>();

            for (int a = 2; a <= maxA; a++)
            {
                for (int b = 2; b <= maxB; b++)
                {
                    flo pow = flo.Pow(a, b);
                    list.Add(pow);
                    Console.Write($"{a}^{b}={pow}, ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var ls = RemoveDupes(list);

            foreach (var item in ls)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine($"\nCount: {ls.Count}");
        }

        private static List<flo> RemoveDupes(List<flo> list)
        {
            var tmp = list;
            tmp.Sort();

            for (int i = list.Count - 1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    // dupe found
                    if (list[i] == list[j])
                    {
                        list.RemoveAt(i);
                    }
                }
            }

            return list;
        }
    }
}
