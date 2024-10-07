using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tack04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите дейёствительное число x:");
            var x = double.Parse(Console.ReadLine());
            var y = MyFunction(x);
            Console.WriteLine($"f(x) = {y}");
            Console.ReadKey();
        }
        static double MyFunction(double x)
        {
            return Math.Sqrt((x * x - 1) / (x * x + 1)) + 1;
        }
    }
    }
}
