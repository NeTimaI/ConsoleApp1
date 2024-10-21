using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число N");
            var n = int.Parse(Console.ReadLine());
            if (isTrue(n))
            { Console.WriteLine("Число n кратно 5 или 7"); }
            else
            {
                Console.WriteLine("Число не кратно 5 или 7");
            }
            Console.ReadKey();
        }
        static bool isTrue(int n)
        {
            return n % 5 == 0 | n % 7 == 0; 
        } 
    }
}
