using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Da-Da");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ночь,  улица, фонарт, аптека");
            Console.WriteLine("Бессмысленый и тусклый свет");


            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("(c) Александр Блок");

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Da");
            Console.ReadKey();
        }
    }
}
