using HomeWork_MyUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8_Homework1
{
    class Program
    {
        static void Main(string[] args)

        {

            OutputHelpers.PrintInfo(8, "Разумных Игорь Александрович");

//#if DEBUG

//            Console.Title = Properties.Settings.Default.ApplicationNameDebug;

//#else
 
//            Console.Title = Properties.Settings.Default.ApplicationName;


//#endif
//            Console.WriteLine($"Настройка UserSettings1: {Properties.Settings.Default.UserSettings1}");
//            Console.WriteLine($"Настройка UserSettings2: {Properties.Settings.Default.UserSettings2}");

//            Console.Write("Укажите значение UserSettings1: ");
//            Properties.Settings.Default.UserSettings1 = int.Parse(Console.ReadLine());
//            Properties.Settings.Default.Save();

//            Console.WriteLine();

//            Console.Write("Укажите значение UserSettings2: ");
//            Properties.Settings.Default.UserSettings2 = Console.ReadLine();
            
//            //Properties.Settings.Default.UserSettings1 = 100;
//            //Properties.Settings.Default.UserSettings2 = "MySettings"; 

//            Console.WriteLine($"Настройка UserSettings1: {Properties.Settings.Default.UserSettings1}");
//            Console.WriteLine($"Настройка UserSettings2: {Properties.Settings.Default.UserSettings2}");



            Console.ReadKey(true);
        }
    }

}
    
