using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3_Homework_4
{ /// <summary>
/// Морской бой, вывод на консоль.
/// </summary>
    internal class Sea_​​battle
    {
        static void Main(string[] args)
        {
            int[,] Pole = new int[10, 10];
            int rows = Pole.GetLength(0);
            int columns = Pole.GetLength(1);
            //Однопалубные корабли
            Pole[2, 2] = 1;
            Pole[8, 2] = 1;
            Pole[0, 5] = 1;
            Pole[9, 0] = 1;
            //Двухпалубные корабли
            Pole[3, 4] = 1;
            Pole[3, 2] = 1;
            Pole[6, 4] = 1;
            Pole[6, 5] = 1;
            Pole[8, 4] = 1;
            Pole[8, 5] = 1;
            //Трёхпалубные корабли
            Pole[2, 8] = 1;
            Pole[3, 8] = 1;
            Pole[4, 8] = 1;
            Pole[9, 9] = 1;
            Pole[8, 9] = 1;
            Pole[7, 9] = 1;
            //Четырёхпалубный корабль
            Pole[0, 0] = 1;
            Pole[1, 0] = 1;
            Pole[2, 0] = 1;
            Pole[3, 0] = 1;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {

                    if (Pole[i, j] != 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(0 + " ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("X ");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
