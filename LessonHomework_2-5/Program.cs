using System;

namespace LessonHomework_2_5
{
    class Program
    {/// <summary>
    /// Программа выбора зимнего месяца
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число от 1 до 3");

            string message = Month();

            Console.WriteLine(message);

            Console.ReadKey();
        }
        internal static int GetRandom()
        {
            Random r = new Random();

            int temp = r.Next(-3, 5);

           return temp;
        }/// <summary>
        /// Метод вывода сообщения "Дождливая зима"
        /// </summary>
        /// <returns></returns>
        public static string Month()
        {
            int temp = GetRandom();
            int number = Convert.ToInt32(Console.ReadLine());
            string message = "";
            switch (number)
            {
                case 1:
                    Console.WriteLine($"December:  {temp}");

                    break;

                case 2:
                    Console.WriteLine($"Ynuary:  {temp}");

                    break;

                case 3:
                    Console.WriteLine($"February:  {temp}");

                    break;

                default:
                    Console.WriteLine("Введён не зимний месяц");

                    break;
            }
            if (temp > 0)
              message = "Дождливая зима";

            return message;
        }
    }
}





