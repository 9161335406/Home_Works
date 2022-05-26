using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4_Homework_2
{
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

            Console.WriteLine($"Сумма элементов массива: " + GetSumm());
        }

        static int GetSumm(int[]nArr, int i)
        {
            int rez = 0;
            int[] nArr = new int[]nArr;
            for (i = 0; i < nArr.Length; i++)
            {
                nArr[i] = i;

            }
            Console.WriteLine("Содержимое массива: ");
            for (i = 0; i < nArr.Length; i++)
            {
                Console.WriteLine(nArr[i]);
                rez = nArr.Sum();
            }
            Console.WriteLine("Сумма: ");

            return (rez);
        }
    }
}