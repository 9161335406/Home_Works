using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4_Homework_2
{/// <summary>
/// Вывод суммы элементов массива.
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
          Console.Write("Введите кол-во элементов массива:\t");

          int elementsCount = int.Parse(Console.ReadLine());

          int[] numbArray = new int[elementsCount];

            for (int i = 0; i < numbArray.Length; i++)
            {
                Console.Write($"\nВведите элементы массива {i}:\t ");

                numbArray[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();

            Console.WriteLine("Вывод элементов массива:");

            for (int i = 0; i < numbArray.Length; i++)
            {
                Console.Write(" ");

                Console.Write(numbArray[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Вывод суммы элементов массива:");

            int result = Sum(numbArray);

            Console.WriteLine(result);
        }
        static int Sum(int[] myArray, int i = 0)
        {
            if (i >= myArray.Length)
                return 0;

            return myArray[i] = Sum(myArray, i + 1);
        }
    }
}
