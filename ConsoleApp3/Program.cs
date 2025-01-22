using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    namespace Task_11
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Введите число элементов массива:");
                int n;
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Ошибка ввода");
                    Console.ReadKey();
                    return;
                }
                var numbers = new double[n];
                var rnd = new Random();

                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = rnd.NextDouble();
                }
                PrintArray(numbers);

                NormalArray(numbers);

                Console.WriteLine($"Сумма произведений a[i] * i = pas {CaluculateExp(numbers)}");

                PrintArray(GetAverage(numbers));

                Console.ReadKey();
            }
            static void PrintArray(double[] array)
            {
                foreach (var element in array)
                    Console.Write($"{element:F4} ");
            }
            static void NormalArray(double[] array)
            {
                if (array.Length == 0)
                    return;

                double sum = 0;

                foreach (var element in array)
                    sum += element;
                if (sum == 0)
                    return;

                for (int i = 0; i < array.Length; i++)
                    array[i] /= sum;
            }
            static double CaluculateExp(double[] probalti)
            {
                double reasult = 0;

                for (int i = 0; i < probalti.Length; i++)
                    reasult = +probalti[i] * 1;
                return reasult;
            }
            static double[] GetAverage(double[] array)
            {
                double[] resault = new double[array.Length];

                double sum = 0;
                double part = 0;

                for (var k = 0; k < array.Length; k++)
                {
                    part += array[k] * array[k];
                    resault[k] = part / (k + 1);
                }
                return resault;
                }
            }
        }
    }
