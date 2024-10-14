using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст на языке:");
            var text = Console.ReadLine();

            Console.WriteLine("На Азбуке морза это будет");
            Console.WriteLine(Trans(text));

            Console.ReadLine();
        }
        static string Trans(string s)
        {
            return s
                .Replace("Z","2")
                .Replace("Y","`/")
                .Replace("X","><")
                .Replace("W",@"\/\/")
                .Replace("V",@"\/")
                .Replace("U","|_|")
                .Replace("T","7")
                .Replace("S","5")
                .Replace("R","|2")
                .Replace("Q","9")
                .Replace("P","|>")
                .Replace("O","0")
                .Replace("N",@"|\|")
                .Replace("M",@"|\/|")
                .Replace("L","1")
                .Replace("K","|<")
                .Replace("J",")")
                .Replace("I","!")
                .Replace("H","|-|")
                .Replace("G","6")
                .Replace("F","|=")
                .Replace("E","3")
                .Replace("D","|)")
                .Replace("C", "(")
                .Replace("B", "8")
                .Replace("A", "4");
        }
    }
}
