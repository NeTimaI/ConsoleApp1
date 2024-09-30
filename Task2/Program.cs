using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите внешний диаметр:");
            Double A = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите внутренний диаметр:");
            Double B = Convert.ToDouble(Console.ReadLine());
            double C = (Math.PI / 4) * ((A * A) - (B * B));
            Console.WriteLine("Площадь(S) =" + Math.Round(C, 2));
            Console.ReadKey();
        }
    }
}
