using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_1
{ 
    internal class Program
    {
       static void Main(string[] args)
       {
        double firstValue, secondValue, thirdValue; //Расчёт среднесуточной температуры
            Console.WriteLine("Введите 1 значение");
            firstValue = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите 2 значение");
            secondValue = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите 3 значение");
            thirdValue = double.Parse(Console.ReadLine());
            double result = (firstValue + secondValue + thirdValue) / 2;
            Console.WriteLine("Среднесуточная температура = " + result);
       
            Console.ReadKey();
       } 
    }
}
