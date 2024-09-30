using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int A = Convert.ToInt32(Console.ReadLine());
            int first = A / 100;
            int second = (A / 10) % 10;
            int third = A % 10;
            int itog = (first * 100) + (third * 10) + second;
            Console.WriteLine(itog);
            Console.ReadKey();
        }
    }
}
