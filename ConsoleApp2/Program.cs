using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "клавиатура";
            Console.WriteLine($"Из слова \"{s}\" получили");

            var w1 = s
                .Remove(0,6)
                .Remove(1,3) +
                s
                .Remove(0,4)
                .Remove(2,2);
            Console.WriteLine(w1);

            var w2 = ReversString(s
                .Remove(0,7)
                .Remove(2,1))+s.
                Remove(1,8);
            Console.WriteLine(w2);
            Console.ReadKey();
        }
        static string ReversString(string s)
        {
            return new string( s.Reverse().ToArray()); 
        }
    }
}
