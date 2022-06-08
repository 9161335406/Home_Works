using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonHomework_6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Вызываем массив процессов

            foreach (Process process in Process.GetProcesses())
            {
                Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName}");//Имена и id процессов.
            }
            Console.WriteLine();

            string name = string.Empty;

            while (name != "q") //Реализуем в цикл
            {
                Console.WriteLine("Укажите имя или id процесса(нажмите q для выхода): ");

                name = Console.ReadLine();

                if (int.TryParse(name, out int id))
                {
                    process1.KillId(id);
                }
                else
                {
                    process1.KillName(name);
                }
            }
        }
    }

}

