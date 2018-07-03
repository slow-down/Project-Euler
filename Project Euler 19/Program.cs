using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

/*
    You are given the following information, but you may prefer to do some research for yourself.

        1 Jan 1900 was a Monday.
        30 days has September, April, June and November.
        All the rest have 31,
        Saving February alone,
        Which has 28, rain or shine.
        And on leap years, 29.
        A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

    How many Sundays fell on the first of the month during the 20th century (1 Jan 1901 to 31 Dec 2000)?
 */

namespace Project_Euler_19
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            Console.WriteLine(CountSundays());

            Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }

        private static int CountSundays()
        {
            int sundays = 0;
            for (int year = 1901; year <= 2000; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    if (new DateTime(year, month, 1).DayOfWeek == DayOfWeek.Sunday)
                    {
                        sundays++;
                    }

                }
            }
            return sundays;
        }

        private static int DaysOfMonth(int month)
        {
            switch (month)
            {
                case 2: return IsLeapYear(month) ? 29 : 28;
                case 4: case 6: case 9:
                    return 30;
                case 11: return 30;
                default: return 31;
            }
        }

        private static bool IsLeapYear(int year)
        {
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
            return false;
        }

    }
}
