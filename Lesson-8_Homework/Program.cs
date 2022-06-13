using HomeworkMyUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8_Homework
{
    internal class Sample1
    {

        public static void Main(string[] args)
        {
            OutputHelpers.PrintInfo(8, "Разумных Игорь Александрович");
#if DEBUG
            Console.Title = Properties.Settings.Default.ApplicationNameDebug;
#else
             Console.Title = Properties.Settings.Default.ApplicationName;
#endif
            Console.WriteLine(Properties.Settings.Default.UsersSettings1);
            Console.WriteLine(Properties.Settings.Default.UsersSettings2);


            Properties.Settings.Default.UsersSettings1 = 1000;
            Properties.Settings.Default.UsersSettings2 = "Hello student";
            Properties.Settings.Default.Save();

            Console.Write(  "Укажите значение UsersSettings1: ");

            Properties.Settings.Default.UsersSettings1 = int.Parse(Console.ReadLine());

            Console.Write("Укажите значение UsersSettings2: ");

            Properties.Settings.Default.UsersSettings2 = Console.ReadLine();

            Console.WriteLine(Properties.Settings.Default.UsersSettings1);
            Console.WriteLine(Properties.Settings.Default.UsersSettings2);
            Properties.Settings.Default.Save();

            Console.ReadKey(true);

        }
    }
}


