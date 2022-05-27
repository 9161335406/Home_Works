using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_Homework_3
{
    class Program
    {/// <summary>
     /// Запись массива в бинарный файл.
     /// </summary>
     /// <param name="args"></param>
        public static void Main(string[] args)
        {//Вводим с консоли произвольные числа от 0 до 255 и записываем в их в файл.
            Console.Write("Введите кол- во элементов массива :\t");
            byte elements = byte.Parse(Console.ReadLine());
            Console.WriteLine("Введите числа от 0 до 255:\t");
            {
                byte[] array = new byte[elements];//Объявляем массив.

                for (byte i = 0; i < array.Length; i++)
                {
                    array[i] = byte.Parse(Console.ReadLine());//Ввод значений массива.
                }
                File.WriteAllBytes("bytes.bin", array);//Записываем массив в файл.
                _ = File.ReadAllBytes("bytes.bin");

                for (byte i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");//показ полученного массива.
                }
                Console.ReadKey();
            }
        }

    }
}

   
