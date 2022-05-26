using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4_Homework_4
{
    class Program
    {/// <summary>
     ///Расчёт числа Фибоначчи
     /// </summary>
     /// <param name="a"></param>
     /// <returns></returns>
        static int Fibonachi(int a)
        {
            if (a == 0 || a == 1) return a;
           
           return Fibonachi(a - 1) + Fibonachi(a - 2);
        }
        /// <summary>
        /// Вывод значения числа фибоначчи
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Введите порядковый номер числа:");
            int x = Convert.ToInt32(Console.ReadLine());
            int a = Fibonachi(x);
            Console.WriteLine($"Число Фибоначчи:{a}");
            Console.ReadKey();
        }
    }
}
