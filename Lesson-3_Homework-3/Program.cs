using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3_Homework_3
{/// <summary>
 /// Запуск строки в обратном порядке
 /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello world";
            Console.WriteLine(text);
            string rev = "";
            for (int i = 1; i <= text.Length; i++)
            {
                rev += text[text.Length - i];
            }
            Console.WriteLine(rev);

            Console.ReadKey();
        }
    }
}