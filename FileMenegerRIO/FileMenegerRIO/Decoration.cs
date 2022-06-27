using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMenegerRIO
{
    class Decoration
    {
        const int WINDOW_HEIGHT = 30;
        const int WINDOW_WIDTH = 120;

        /// <summary>
        /// Отрисовываем окно с помощью метода
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>

        public static void DrawWindow(int x, int y, int width, int height)
        {
            Console.SetCursorPosition(x, y);
            // header - шапка
            Console.Write("╔");
            for (int i = 0; i < width - 2; i++) // 2 - уголки
                Console.Write("═");
            Console.Write("╗");

            Console.SetCursorPosition(x, y + 1);
            for (int i = 0; i < height - 2; i++)
            {
                Console.Write("║");
                for (int j = x + 1; j < x + width - 1; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("║");
            }

            // footer - подвал
            Console.Write("╚");
            for (int i = 0; i < width - 2; i++) // 2 - уголки
                Console.Write("═");
            Console.Write("╝");
            Console.SetCursorPosition(x, y + 1);
        }

        /// <summary>
        /// Отрисовываем консоль
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void DrawConsole(string dir, int x, int y, int width, int height)
        {
            DrawWindow(x, y, width, height);
            Console.SetCursorPosition(x + 1, y + height / 2);
            Console.Write($"{dir}>");
        }

        public static (int left, int top) GetCursorPosition()
        {
            return (Console.CursorLeft, Console.CursorTop);
        }

        /// <summary>
        /// Реализовываем метод help()
        /// </summary>

        public static void Help()
        {
            DrawWindow(0, 0, WINDOW_WIDTH, 18);
            (int x, int y) = Decoration.GetCursorPosition();
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write("Примеры использования команд:");
            Console.SetCursorPosition(x + 1, y + 2);
            Console.Write("cd C:\\Source - изменение текущего каталога");
            Console.SetCursorPosition(x + 1, y + 3);
            Console.Write("ls C:\\Souce -p n - вывод дерева подкаталогов и файлов постранично, где n- номер страницы");
            Console.SetCursorPosition(x + 1, y + 4);
            Console.Write("rm C:\\Source\\filename.ext - удаление файла ");
            Console.SetCursorPosition(x + 1, y + 5);
            Console.Write("file C:\\Source\\filename.ext - вывод информации о файле ");
            Console.SetCursorPosition(x + 1, y + 6);
            Console.Write("dir C:\\Source - вывод информации о каталоге ");
            Console.SetCursorPosition(x + 1, y + 7);
            Console.Write("cp C:\\Source\\filename1.ext D:\\Source\\filename2.ext - копирование файлов ");
            Console.SetCursorPosition(x + 1, y + 8);
            Console.Write("cpdir C:\\Source D:\\Source2 - копирование каталогов  ");
            Console.SetCursorPosition(x + 1, y + 9);
            Console.Write("deldir C:\\Source  - удаление каталога  ");
            Console.SetCursorPosition(x + 1, y + 10);
            Console.Write("deldir -r C:\\Source - удаление каталога рекурсивно  ");
            Console.SetCursorPosition(x + 1, y + 11);
            Console.Write("cat C:\\Source\\filename.ext - вывод на экран текста файла");


        }
        /// <summary>
        /// Реализован метод Приветствия Greeting()
        /// </summary>
        public static void Greeting()
        {
            //UI.DrawWindow(0, 0, WINDOW_WIDTH, 18);
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Введите help в коммандной строке  для справки о командах");
        }

    }

}
