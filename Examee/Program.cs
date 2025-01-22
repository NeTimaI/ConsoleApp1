using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lim = 10000000;
            int count = 0;

            for (int i = 4; i < lim; i++)
            {
                if (ProverPolProst(i))
                {
                    count++;
                }
            }
            Console.WriteLine($"Количество полупростых чисел до 10 000 000:{count}");
            Console.ReadKey();
        }
        static bool ProverPolProst(int n)
        {
            if (n < 4) return false;

            int CountDelit = 0;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                while (n % i == 0)
                {
                    CountDelit++;
                    n /= i;
                }
                if (CountDelit > 2) return false;
            }
            if (n > 1)
            {
                CountDelit++;
            }
            return CountDelit == 2;
        }
    }
}