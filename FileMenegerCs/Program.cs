﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMenegerCs
{
    internal class Program
    {
        const int WINDOW_HEIGHT = 30;
        const int WINDOW_WIDTH = 120;
        private static string currentDir = Directory.GetCurrentDirectory();

        public static string destinationDir { get; private set; }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.Title = "MyFileMeneger";

            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);
            Console.SetBufferSize(WINDOW_WIDTH, WINDOW_HEIGHT);


            DrawWindow(0, 0, WINDOW_WIDTH, 18);
            DrawWindow(0, 18, WINDOW_WIDTH, 8);

            UpdateConsole();

            Console.ReadKey(true);
        }
        static void UpdateConsole()
        {
            DrawConsole(currentDir, 0, 26, WINDOW_WIDTH, 3);

            ProcessEnterCommand(WINDOW_WIDTH);
        }

        static (int left, int top) GetCursorPosition()
        {
            return (Console.CursorLeft, Console.CursorTop);
        }

        static void ProcessEnterCommand(int width)
        {
            (int left, int top) = GetCursorPosition();
            StringBuilder command = new StringBuilder();
            char key;
            do
            {
                key = Console.ReadKey().KeyChar;

                if (key != 8 && key != 13)

                    command.Append(key);

                (int currentLeft, int currentTop) = GetCursorPosition();

                if (currentLeft == width - 2)
                {
                    Console.SetCursorPosition(currentLeft - 1, top);
                    Console.Write(" ");
                    Console.SetCursorPosition(currentLeft - 1, top);
                }
                if (key == (char)8/*ConsoleKey.Backspace*/)
                {
                    if (command.Length > 0)
                        command.Remove(command.Length - 1, 1);

                    if (currentLeft >= left)
                    {
                        Console.SetCursorPosition(currentLeft, top);
                        Console.Write(" ");
                        Console.SetCursorPosition(currentLeft, top);
                    }
                    else
                    {
                        Console.SetCursorPosition(left, top);
                    }
                }
            }

            while (key != (char)13);
            ParseCommandString(command.ToString());
        }
        static void ParseCommandString(string command)
        {
            string[] commandParams = command.ToLower().Split(' ');


            if (commandParams.Length > 0)
            {
                //string dir = null;


                switch (commandParams[0])
                {
                    case "cd":

                        if (commandParams.Length > 1 && Directory.Exists(commandParams[1]))
                        {
                            currentDir = commandParams[1];
                        }

                        break;

                    case "ls":

                        if (commandParams.Length > 1 && Directory.Exists(commandParams[1]))
                        {
                            if (commandParams.Length > 3 && commandParams[2] == "-p" && int.TryParse(commandParams[3], out int n))
                            {
                                DrawTree(new DirectoryInfo(commandParams[1]), n);
                            }
                            else
                            {
                                DrawTree(new DirectoryInfo(commandParams[1]), 1);
                            }
                        }
                        break;

                    case "copyDir":
                        {
                            if (commandParams.Length > 2 && Directory.Exists(commandParams[1]))
                            {
                                if (CopyDir(commandParams[1], commandParams[2]))
                                {
                                    Console.WriteLine($"{commandParams[1]} copied to: {commandParams[2]}");
                                }

                            
                            }

                               

                        }

                        break;

                    case "cpF":
                        {

                        }

                        break;

                    case "delDir":
                        {
                            DelDirectory(commandParams);
                        }

                        break;

                    case "delF":
                        {
                            DelFile(commandParams);
                        }

                        break;
                }

            }
            UpdateConsole();

        }/// <summary>
         /// Удаление директории
         /// </summary>
         /// <param name="commandParams"></param>
         /// <returns>message</returns>
        internal static string DelDirectory(string[] commandParams)
        {
            string message;

            if (commandParams.Length > 1 && Directory.Exists(commandParams[1]))
            {
                Directory.Delete(commandParams[1], true);

                message = "Директория успешно удалена!";

            }
            else

                message = "Директория не существует";

            return message;

        }/// <summary>
         /// Удаление файла
         /// </summary>
         /// <param name="commandParams"></param>
         /// <returns>message</returns>
        internal static string DelFile(string[] commandParams)
        {
            string message;

            if (commandParams.Length > 1 && File.Exists(commandParams[1]))
            {
                File.Delete(commandParams[1]);

                message = "Файл успешно удален!";
            }
            else

                message = "Файл не существует";

            return message;
        }
        /// <summary>
        /// Копирование директории
        /// </summary>
        /// <param name="initial"></param>
        /// <param name="assignment"></param>
        /// <returns></returns>
        internal static string CopyDir(string initial, string assignment, bool v)
        {
            string message;

            if (Directory.Exists(initial))

            {
                var dir = new DirectoryInfo(initial);

                DirectoryInfo[] dirs = dir.GetDirectories();

                Directory.CreateDirectory(assignment);

                foreach (DirectoryInfo subDir in dirs)

                {

                    string newDestinationDir = Path.Combine(assignment, subDir.Name);

                    CopyDir(subDir.FullName, newDestinationDir);

                }

                message = "Директория успешно скопирована";
            }
            else
                message = "Неверные параметры";

            return message;
        }
        /// <summary>
        /// Копирование файла
        /// </summary>
        /// <param name="initial"></param>
        /// <param name="assignment"></param>
        /// <returns></returns>
        internal static string CopyFile(string initial, string assignment)
        {
            string message;

            if (File.Exists(initial) && Directory.Exists(assignment))
            {
                FileInfo file = new FileInfo(initial);

                string targetFilePath = Path.Combine(assignment, file.Name);

                file.CopyTo(targetFilePath);

                message = "Файл успешно скопирован";

            }
            else

                message = "Неверные параметры";

               return message;
        }

        /// <summary>
        /// Перемещение директории
        /// </summary>
        /// <param name="commandParams"></param>
        /// <returns></returns>
        internal static string MoveDir(string[] commandParams)
        {
            string message;

            if (Directory.Exists(commandParams[1]) && !Directory.Exists(commandParams[2]))
            {
                Directory.Move(commandParams[1], commandParams[2]);

                message = "Директория успешно перемещена";

            }
            else

                message = "Директория не существует";

            return message;

        }

        internal static string MoveFile(string[] commandParams)
        {
            string message;

            if (File.Exists(commandParams[1]))
            {

                FileInfo file = new FileInfo(commandParams[1]);

                string targetFilePath = Path.Combine(commandParams[2], file.Name);
               
                file.MoveTo(targetFilePath);

            }
                message = "Файл успешно перемещен";

                return message;
        }

            /// <summary>
            /// Отрисовать дерево каталогов
            /// </summary>
            /// <param name="dir">Директория</param>
            /// <param name="page">Страница</param>
            static void DrawTree(DirectoryInfo dir, int page)
        {
            StringBuilder tree = new StringBuilder();
            GetTree(tree, dir, "", true);
            DrawWindow(0, 0, WINDOW_WIDTH, 18);
            (int currentLeft, int currentTop) = GetCursorPosition();
            int pageLines = 16;
            string[] lines = tree.ToString().Split(new char[] { '\n' });
            int pageTotal = (lines.Length + pageLines - 1) / pageLines;
            if (page > pageTotal)
                page = pageTotal;


            for (int i = (page - 1) * pageLines, counter = 0; i < page * pageLines; i++, counter++)
            {
                if (lines.Length - 1 > i)
                {
                    Console.SetCursorPosition(currentLeft + 1, currentTop + 1 + counter);
                    Console.WriteLine(lines[i]);
                }
            }

            //Подвал

            string footer = $"╡ {page} of {pageTotal} ╞";

            Console.SetCursorPosition(WINDOW_WIDTH / 2 - footer.Length / 2, 17);

            Console.WriteLine(footer);
        }

        static void GetTree(StringBuilder tree, DirectoryInfo dir, string indent, bool lastDirectory)
        {
            tree.Append(indent);
            if (lastDirectory)
            {
                tree.Append("└─");
                indent += "  ";
            }
            else
            {
                tree.Append("├─");
                indent += "│ ";
            }

            tree.Append($"{dir.Name}\n"); //<---------------------- ПЕРЕХОД НА СЛЕД СТРОКУ


            //TODO: Добавляем отображение файлов

            FileInfo[] subFiles = dir.GetFiles();

            for (int i = 0; i < subFiles.Length; i++)
            {
                if (i == subFiles.Length - 1)
                {
                    tree.Append($"{indent}└─{subFiles[i].Name}\n");
                }
                else
                {
                    tree.Append($"{indent}├─{subFiles[i].Name}\n");
                }

            }
            DirectoryInfo[] subDirects = dir.GetDirectories();

            for (int i = 0; i < subDirects.Length; i++)

                GetTree(tree, subDirects[i], indent, i == subDirects.Length - 1);
        }

        private static void DrawConsole(string dir, int x, int y, int width, int height)
        {
            DrawWindow(x, y, width, height);
            Console.SetCursorPosition(x + 1, y + height / 2);
            Console.Write($"{dir}>");
        }

        private static void DrawWindow(int x, int y, int width, int height)
        {

            Console.SetCursorPosition(x, y);

            //header - шапка

            Console.Write("╔");

            for (int i = 0; i < width - 2; i++)

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
            //footer - подвал

            Console.Write("╚");

            for (int i = 0; i < width - 2; i++)

                Console.Write("═");

            Console.Write("╝");

            Console.SetCursorPosition(x, y);

        }

    }
}
