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

        private static string currentDir = Directory.GetCurrentDirectory();

        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.Title = "FileManager";

            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);

            Console.SetBufferSize(WINDOW_WIDTH, WINDOW_HEIGHT);

            Decoration.DrawWindow(0, 0, WINDOW_WIDTH, 18);

            Decoration.DrawWindow(0, 18, WINDOW_WIDTH, 8);

            UpdateConsole();

            Console.ReadKey(true);
        }
        static void UpdateConsole()
        {
            Decoration.DrawConsole(currentDir, 0, 26, WINDOW_WIDTH, 3);

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

                                Functional.DrawTree(new DirectoryInfo(commandParams[1]), n);

                            }

                            else
                            {

                                Functional.DrawTree(new DirectoryInfo(commandParams[1]), 1);

                            }
                        }
                        break;

                    case "mv":

                        if (commandParams.Length > 1 && Directory.Exists(commandParams[1]))

                            if (commandParams.Length == 3)
                            {
                                Console.SetCursorPosition(2, +2);

                                if (Directory.Exists(commandParams[1]))
                                {

                                    DirectoryInfo dirInfo = new DirectoryInfo(commandParams[1]);

                                    commandParams[2] = commandParams[2] + "\\" + dirInfo.Name;

                                    Console.WriteLine(Functional.MoveDirOrFile(commandParams));

                                }

                                if (File.Exists(commandParams[1]) && Directory.Exists(commandParams[2]))
                                {

                                    Console.WriteLine(Functional.MoveDirOrFile(commandParams));

                                }
                                else

                                    UpdateConsole();
                            }
                        break;

                    case "":

                    case "rm":
                        if (commandParams.Length > 1 && File.Exists(commandParams[1]))
                        {
                            Functional.DeleteFile(commandParams[1]);
                        }
                        break;
                    case "file":
                        if (commandParams.Length > 1 && File.Exists(commandParams[1]))
                        {
                            Functional.FileInfo(commandParams[1]);
                        }
                        break;
                    case "cat":
                        if (commandParams.Length > 1 && File.Exists(commandParams[1]))
                        {
                            Functional.CatFile(commandParams[1]);
                        }

                        break;
                    case "dir":
                        if (commandParams.Length > 1 && Directory.Exists(commandParams[1]))
                        {
                            Functional.DirInfo(commandParams[1]);
                        }

                        break;
                    case "cp":
                        if (commandParams.Length > 2 && File.Exists(commandParams[1]))
                        {
                            Functional.CopyFile(commandParams[1], commandParams[2]);
                        }

                        break;
                    case "cpdir":
                        if (commandParams.Length > 2 && Directory.Exists(commandParams[1]))
                        {
                            if (Functional.CopyDir(commandParams[1], commandParams[2]))
                            {
                                Console.WriteLine($"{commandParams[1]} copied to: {commandParams[2]}");
                            }

                        }

                        break;
                    case "deldir":
                        if (commandParams.Length > 1 && Directory.Exists(commandParams[1]))
                        {
                            Functional.DelDir(commandParams[1], false);
                        }
                        if (commandParams.Length > 2 && commandParams[1] == "-r" && Directory.Exists(commandParams[2]))
                        {
                            Functional.DelDir(commandParams[2], true);
                        }

                        break;
                    case "help":
                        if (commandParams.Length == 1)
                        {
                            Decoration.Help();
                        }

                        break;
                    default:

                        break;
                }
            }
        }
    }
}

