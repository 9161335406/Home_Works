using Lucene.Net.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonHomework_2_5
{
    class Program
    {


        static void Main(string[] args)
        {
            Random rnd = new Random();

            int temp = rnd.Next(-5, 5);

            Console.WriteLine(rnd);

            Console.ReadKey();
        }
    }
}