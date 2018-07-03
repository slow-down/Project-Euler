using System;
using System.Numerics;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Shared
{
    public static class Maul
    {
        public static int[] GetAllPrimes(int n)
        {
            bool[] nums = new bool[n];

            // Fill array
            for (int i = 2; i < n; i++)
            {
                nums[i] = true;
            }

            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (nums[i])
                {
                    for (int j = 0; j < n; j += i)
                    {
                        nums[j] = false;
                    }
                }
            }

            List<int> primes = new List<int>();
            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i])
                {
                    primes.Add(i);
                }
            }
            return primes.ToArray();
        }

    }
}
