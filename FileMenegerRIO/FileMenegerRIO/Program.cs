using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMenegerRIO
{
    class Program
    {
        const int WINDOW_HEIGHT = 30;
        const int WINDOW_WIDTH = 120;
        private static int WINDOW_HEIGHT;
        private static int WINDOW_WIDTH;
        private static string currentDir = Directory.GetCurrentDirectory();

        static void Main(string[] args)
        {
            WINDOW_HEIGHT = Properties.Settings.Default.W_height;
            WINDOW_WIDTH = Properties.Settings.Default.W_width;

            if (Directory.Exists(Properties.Settings.Default.Path))
            {
                currentDir = Properties.Settings.Default.Path;
            }
            else
            {
                currentDir = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
            }

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Title = "FileManager";

            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);
            Console.SetBufferSize(WINDOW_WIDTH, WINDOW_HEIGHT);

            DrawWindow(0, 0, WINDOW_WIDTH, 18);
            DrawWindow(0, 18, WINDOW_WIDTH, 8);

            User_interface.DrawWindow(0, 0, WINDOW_WIDTH, 18);
            User_interface.DrawWindow(0, 18, WINDOW_WIDTH, 8);

            User_interface.Greeting();
            UpdateConsole();


            Console.ReadKey(true);
        }

        static void UpdateConsole()
        {
            DrawConsole(currentDir, 0, 26, WINDOW_WIDTH, 3);
            User_interface.DrawConsole(currentDir, 0, 26, WINDOW_WIDTH, 3);
            ProcessEnterCommand(WINDOW_WIDTH);
        }
        static void UpdateConsole()
        {

        }
           return (Console.CursorLeft, Console.CursorTop);
        }

    /// <summary>
    /// Процесс обработки комманды Enter
    /// </summary>
    /// <param name="width"></param>

    static void ProcessEnterCommand(int width)
    {
        (int left, int top) = GetCursorPosition();
        (int left, int top) = User_interface.GetCursorPosition();
        StringBuilder command = new StringBuilder();
        char key;
        do


    }
    }
}
