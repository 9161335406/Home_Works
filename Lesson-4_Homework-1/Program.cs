using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4_Homework_1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите количество объектов");
            int count = int.Parse(Console.ReadLine());
            string[] fullName = new string[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите фамилию объекта");
                string lastName = Console.ReadLine();
                Console.WriteLine("Введите имя объекта");
                string firstName = Console.ReadLine();
                Console.WriteLine("Введите отчество объекта");
                string patronymic = Console.ReadLine();

                fullName[i] = GetFullName(lastName, firstName, patronymic);

                Console.Clear();
            }

            Console.WriteLine();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(fullName[i]);
            }

            Console.ReadKey();

        }

        public static string GetFullName(string lastName, string firstName, string patronymic)
        {
            string FullName = lastName + " " + firstName + " " + patronymic;
            return FullName;
        }
    }
}
