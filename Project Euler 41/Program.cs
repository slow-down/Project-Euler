using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler_41
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            string str = "1234567890";
            char[] arr = str.ToCharArray();
            GetPer(arr);
            Console.ReadKey();
        }

        private static bool IsPrime(long num)
        {
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        private static void GetPer(char[] list)
        {
            int x = list.Length - 1;
            GetPer(list, 0, x);
        }

        private static List<long> GetPer(char[] list, int k, int m)
        {
            List<long> nums = new List<long>();

            if (k == m)
            {
                nums.Add(Convert.ToInt32(list));
                //Console.WriteLine(list);
            }
            else
            {
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
            }

            return nums;
        }

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
