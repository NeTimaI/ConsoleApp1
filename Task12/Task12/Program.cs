using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            if (!TryInputNumber("Введите число a", out a))
            {
                Console.ReadKey();
                return;
            }

            int b = 0;
            if (!TryInputNumber("Введите число b", out b))
            {
                Console.ReadKey();
                return;
            }

            if (a <= 0 || a > b)
            {
                Console.WriteLine("Условие 0 < a <= b не выполняется");
                Console.ReadKey();
                return;
            }

            var product = 1;

            for (var i = a; i <= b; i++)
                product *= i;

            Console.WriteLine($"Произведение чисел от {a} до {b} равно {product}");

            Console.ReadKey();
        }

        static bool TryInputNumber(string message, out int number)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();

            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Ошибка ввода");
                return false;
            }

            return true;
        }
        static void PrintMatric(int[,] matrix)
        {
            for (int i = 0; i< matrix.GetLength(0); i++)
             Console.WriteLine($"{matrix[i, 0],2}");

            Console.WriteLine();
        }
    }
}
    
 
