using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_MyUtils
{
    public static class OutputHelpers
    {
        public static void PrintInfo(int homeworNumber, string fio)
        {
            Console.WriteLine($"Домашняя работа. Урок: {homeworNumber}");

            Console.WriteLine($"Студент: {fio}");

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++\n");
        }
    }
}
