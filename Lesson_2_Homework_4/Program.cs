using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2_Homework_4
{
    class Receipt
    {/// <summary>
    /// Чек кассовый
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            Receipt receipt = new Receipt();

            receipt.nameShop = "ООО \"Лира\"";
            receipt.Date = DateTime.Now;
            receipt.Total = 14780;
            receipt.Print();

            Console.ReadKey();
        }
        private string nameShop;

        private DateTime date;

        private int total;

        public int Total
        {
            get { return total; }
            set { total = value; }
        } 

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string NameShop
        {
            get { return nameShop; }
            set { nameShop = value; }
        }

        public void Print()
        {
            Console.WriteLine("*** " + nameShop + "***");
            Console.WriteLine("***Добро пожаловать!***");
            Console.WriteLine("*** " + Date + "***");
            Console.WriteLine("***ФИО: Щербинин С.Е***");
            Console.WriteLine("***Итого: " + Total + "***");
            Console.WriteLine( "***СПАСИБО ЗА ПОКУПКУ***");
        }
    }
}
