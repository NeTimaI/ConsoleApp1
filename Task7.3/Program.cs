using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7._3
{
    internal class Program
    {
        static void DecodePosition(string notation, out int x, out int y)
        {
            x = notation[0] - 'a' + 1; // 'a' = 1, 'b' = 2, ...
            y = int.Parse(notation[1].ToString());
        }

        // Проверка, атакует ли ладья клетку
        static bool RookCanAttack(int rookX, int rookY, int targetX, int targetY)
        {
            return rookX == targetX || rookY == targetY;
        }

        // Проверка, атакует ли ферзь клетку
        static bool QueenCanAttack(int queenX, int queenY, int targetX, int targetY)
        {
            return queenX == targetX || queenY == targetY || Math.Abs(queenX - targetX) == Math.Abs(queenY - targetY);
        }

        // Проверка, может ли белая фигура безопасно сделать ход
        static bool CanWhiteMove(int whiteX, int whiteY, int blackX, int blackY, int targetX, int targetY)
        {
            // Проверка, не совпадает ли позиция целевого хода с позицией чёрной фигуры
            if (targetX == blackX && targetY == blackY)
                return false;

            // Проверка, может ли белая фигура (ладья) атаковать целевую клетку
            if (!RookCanAttack(whiteX, whiteY, targetX, targetY))
                return false;

            // Проверка, не находится ли целевая клетка под атакой чёрной фигуры (ферзь)
            if (QueenCanAttack(blackX, blackY, targetX, targetY))
                return false;

            return true;
        }

        static void Main()
        {
            Console.Write("Введите позицию белой ладьи (например, a1): ");
            string whitePos = Console.ReadLine();
            DecodePosition(whitePos, out int whiteX, out int whiteY);

            Console.Write("Введите позицию черного ферзя (например, h8): ");
            string blackPos = Console.ReadLine();
            DecodePosition(blackPos, out int blackX, out int blackY);

            // Проверка корректности начальных данных
            if ((whiteX == blackX && whiteY == blackY) || QueenCanAttack(blackX, blackY, whiteX, whiteY) || RookCanAttack(whiteX, whiteY, blackX, blackY))
            {
                Console.WriteLine("Некорректные данные или фигуры находятся под боем друг друга.");
                return;
            }

            Console.Write("Введите позицию для предполагаемого хода белой ладьи (например, b2): ");
            string targetPos = Console.ReadLine();
            DecodePosition(targetPos, out int targetX, out int targetY);

            // Проверка возможности хода
            bool canMove = CanWhiteMove(whiteX, whiteY, blackX, blackY, targetX, targetY);
            Console.WriteLine(canMove ? "Ход возможен." : "Ход невозможен.");
            Console.ReadKey();
        }
    
    }
}

