using System;

namespace LessonHomework_7_1
{
    internal class Program
    {
             //Исходный код.
            static void Main(string[] args)
            {
                string secret = "some secret password";
                Console.WriteLine("Введите пароль:");
                string input = Console.ReadLine();
                if (input == secret)
                {
                    Console.WriteLine("Welcome!");
                }

                Console.ReadKey(true);
            }

        //////////////////////////////////////////////////////

            //Код с изменениями условий.
            //private static void Main(string[] args)
            //{ 
            //   string str = "some secret password";
            //   Console.WriteLine("Введите пароль:");
            //   if (!(Console.ReadLine() == str))
            //   Console.WriteLine("Welcome!");
            //   Console.ReadKey(true);
            //}

        
    }
}
