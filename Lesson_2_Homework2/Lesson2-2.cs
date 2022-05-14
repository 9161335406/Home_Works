using System;

namespace Homework2_2
{
    class EnumDemo
    {
        enum mesyac { Январь, Февраль, Март, Апрель, Май, Июнь, Июль, Август, Сентябрь, Октябрь, Ноябрь, Декабрь };
        static void Main()
        { 
            Console.WriteLine("Введите номер месяца");
            int n = int.Parse(Console.ReadLine());
            if (n < 1 || n > 12)
                Console.WriteLine("Некорректный номер!"); //Такого месяца не существует
            else
                Console.WriteLine("Месяц под номером {0}: {1}", n, (mesyac)(n - 1));
            Console.ReadKey();
        }
    }
}

        
   

