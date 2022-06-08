using System;

namespace lessonHomework_3_1
{
    internal class Lesson3
    { /// <summary>
    /// Вывод массива по диагонали
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[,] array = new int[5, 5];
            array[0, 1] = 1;
            array[1, 2] = 1;
            array[2, 3] = 1;
            array[3, 4] = 1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    Console.Write(array[i, j] + "  ");
                }
                Console.WriteLine();

            }
            Console.ReadKey();
        }
    }

}
