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
            Console.WriteLine("Введите число:");
            var n = double.Parse(Console.ReadLine());
            if (n % 5 == 0)
            {
                Console.WriteLine("Кртано 5");
            }
            else if (n % 7 == 0)
            {
                Console.WriteLine("Кратно 7");
            }
            else 
            { 
                Console.WriteLine("Не кратно 7 и 5"); 
            }
            Console.ReadKey();
        }
    }
}
