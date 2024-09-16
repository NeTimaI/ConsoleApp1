using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace po
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введие первое число");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введие второе число");
            int b = int.Parse(Console.ReadLine());
          
            Console.WriteLine("Cумма равна=" + (a+b));

            Console.ReadKey();
        }
    }

}
