using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение x для функции y=f(x)");
            var x = double.Parse(Console.ReadLine());

            Console.WriteLine($"f({x}) = {MyFunction(x)}");
        }
            static double MyFunction(double x)
            {
                if (x < -1)
                    return 1;
                else if (x > 1)
                    return -1;
                else 
                    return (x*(-1));
            }
        }
    }
