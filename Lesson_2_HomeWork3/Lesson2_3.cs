using System;

namespace Lesson_2_HomeWork3
{
    class Lesson2_3
    {
        static void Main(string[] args)
        {
            int a;
            Console.Write("Введите число:");
            a = Console.Read();
            if (a % 2 == 0)         //Делится на 2 без остатка
            {
                Console.WriteLine("Число чётное");
            }
            else
            {
                Console.WriteLine("Число нечётное");
            }
            Console.ReadKey();
        }
    }
}