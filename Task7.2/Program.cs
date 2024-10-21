using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Task7._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите x:");

            var x = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите y");
            
            var y = int.Parse(Console.ReadLine());

            if (Cheak(x,y))
            {
                Console.WriteLine("Точки принадлежат фигуре");
            }
            else { Console.WriteLine("Точки не принадлжеат фигуре"); }
            Console.ReadKey();
        }

        static bool Cheak( int x, int y )
        {
            return (x >= 2 && y >= 0) || (x >= 1 && y <= -1);
        }
    }
}
