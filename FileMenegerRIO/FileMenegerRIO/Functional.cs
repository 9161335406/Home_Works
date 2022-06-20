using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMenegerRIO
{
    public class Functional
    {
        const int WINDOW_HEIGHT = 30;
        const int WINDOW_WIDTH = 120;
        private static string log;
        /// <summary>
        /// Создаем дерево каталогов и файлов через метод GetTree
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="dir"></param>
        /// <param name="indent"></param>
        /// <param name="lastDirectory"></param>
        public static void GetTree(StringBuilder tree, DirectoryInfo dir, string indent, bool lastDirectory)
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
        /// <summary>
        /// Отрисовка дерева каталогов
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="page"></param>
        public static void DrawTree(DirectoryInfo dir, int page)
        {
            StringBuilder tree = new StringBuilder();
            GetTree(tree, dir, "", true);
            Decoration.DrawWindow(0, 0, WINDOW_WIDTH, 18);
            GetTree(tree, dir, "", true);
            Decoration.DrawWindow(0, 0, WINDOW_WIDTH, 18);
            (int currentLeft, int currentTop) = Decoration.GetCursorPosition();
            string[] lines = tree.ToString().Split(new char[] { '\n' });
            Console.WriteLine(lines);

        }
        public static string MoveDirOrFile(string[] commandParams)
        {
            string message;

            if (File.Exists(commandParams[1]))
            {
                FileInfo file = new FileInfo(commandParams[1]);

                string targetFilePath = Path.Combine(commandParams[2], file.Name);

                file.MoveTo(targetFilePath);

                message = "Файл успешно перемещен";
            }
            else if (Directory.Exists(commandParams[1]) && !Directory.Exists(commandParams[2]))
            {
                Directory.Move(commandParams[1], commandParams[2]);

                message = "Директория успешно перемещена";
            }
            else

                message = "Директория/файл не существует";

            return message;
        }



        /// <summary>
        /// Реализован метод удаления файлов
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteFile(string path)
        {
            Decoration.DrawWindow(0, 18, WINDOW_WIDTH, 8);
            Console.SetCursorPosition(1, 19);
            try
            {
                File.Delete(path);
                Console.WriteLine(path);
                Console.SetCursorPosition(1, 20);
                Console.WriteLine("Deleted");
                log += $"{Environment.NewLine} Процесс удаления произошел успешено";
            }
            catch (Exception ex)
            {
                Console.SetCursorPosition(1, 20);
                Console.WriteLine(ex.Message);
                log += $"{Environment.NewLine} Во время удаления файла произошла ошибка";
            }
            finally
            {
                File.WriteAllText("random_name_exception.txt", log);
            }

        }
        /// <summary>
        /// Реализован метод вывода информации о файле
        /// </summary>
        /// <param name="path"></param>
        public static void FileInfo(string path)
        {
            Decoration.DrawWindow(0, 18, WINDOW_WIDTH, 8);
            Console.SetCursorPosition(1, 19);
            try
            {
                FileInfo fi = new FileInfo(path);
                Console.WriteLine("Path: " + fi.FullName);
                Console.SetCursorPosition(1, 20);
                Console.WriteLine("Size(bytes): " + fi.Length.ToString());
                Console.SetCursorPosition(1, 21);
                Console.WriteLine("Created: " + fi.CreationTime);
                Console.SetCursorPosition(1, 22);
                Console.WriteLine("Last Modified: " + fi.LastWriteTime);
                log += $"{Environment.NewLine} Процесс вывода информации о файле прошел успешно";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                log += $"{Environment.NewLine} Во время вывода информаци о файле произошла ошибка";
            }
            finally
            {
                File.WriteAllText("random_name_exception.txt", log);
            }
        }
        /// <summary>
        /// Реализован метод вывода текста файла на экран
        /// </summary>
        /// <param name="path"></param>
        public static void CatFile(string path)
        {
            Decoration.DrawWindow(0, 0, WINDOW_WIDTH, 18);
            (int x, int y) = Decoration.GetCursorPosition();
            int count = 0;
            int firstLine = y;
            try
            {
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (count == 15)
                    {
                        Console.SetCursorPosition(x + 1, ++y);
                        Console.Write("======Для продолжения нажмите любую клавишу=====");
                        count = 0;
                        y = firstLine;
                        Console.ReadKey(true);
                    }
                    Console.SetCursorPosition(x + 1, ++y);
                    Console.Write(lines[i]);
                    count++;
                }
                log += $"{Environment.NewLine} Успешно";
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                File.WriteAllText("random_name_exception.txt", log);
            }
        }
        /// <summary>
        /// Реализован метод вывода информации о директориях
        /// </summary>
        /// <param name="path"></param>
        public static void DirInfo(string path)
        {
            Decoration.DrawWindow(0, 18, WINDOW_WIDTH, 8);
            Console.SetCursorPosition(1, 19);
            try
            {
                string[] files = Directory.GetFiles(path);
                string[] folders = Directory.GetDirectories(path);
                DateTime dateTime = Directory.GetCreationTime(path);
                Console.WriteLine("Папка: " + path);
                Console.SetCursorPosition(1, 20);
                Console.WriteLine($"Создан: {dateTime} Файлов: {files.Length} Папок: {folders.Length}");
                log += $"{Environment.NewLine} Успешно";
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                File.WriteAllText("random_name_exception.txt", log);
            }

        }

        /// <summary>
        /// Реализован метод копирования файлов
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void CopyFile(string source, string target)
        {
            Decoration.DrawWindow(0, 18, WINDOW_WIDTH, 8);
            Console.SetCursorPosition(1, 19);
            try
            {
                File.Copy(source, target);
                Console.WriteLine($"{source} copied to: {target}");
                log += $"{Environment.NewLine} Успешно";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                log += $"{Environment.NewLine} Не Успешно";
            }
            finally
            {
                File.WriteAllText("random_name_exception.txt", log);
            }

        }
        /// <summary>
        /// Реализован метод копирования директорий
        /// </summary>
        /// <param name="sourceFolder"></param>
        /// <param name="destFolder"></param>
        /// <returns></returns>
        public static bool CopyDir(string sourceFolder, string destFolder)
        {
            Decoration.DrawWindow(0, 18, WINDOW_WIDTH, 8);
            Console.SetCursorPosition(1, 19);
            try
            {
                if (!Directory.Exists(destFolder))
                    Directory.CreateDirectory(destFolder);
                string[] files = Directory.GetFiles(sourceFolder);
                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);
                    string dest = Path.Combine(destFolder, name);
                    File.Copy(file, dest);
                }
                string[] folders = Directory.GetDirectories(sourceFolder);
                foreach (string folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    string dest = Path.Combine(destFolder, name);
                    CopyDir(folder, dest);
                }
                return true;// Console.WriteLine($"{sourceFolder} copied to: {destFolder}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
            finally
            {
                File.WriteAllText("random_name_exception.txt", log);
            }

        }
        /// <summary>
        /// Реализован метод удаления директории
        /// </summary>
        /// <param name="path"></param>
        /// <param name="recurs"></param>
        public static void DelDir(string path, bool recurs)
        {
            Decoration.DrawWindow(0, 18, WINDOW_WIDTH, 8);
            Console.SetCursorPosition(1, 19);
            try
            {
                Directory.Delete(path, true);
                Console.WriteLine($" Directory {path} deleted");
                log += $"{Environment.NewLine} Успешно";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                log += $"{Environment.NewLine} Не Успешно";
            }
            finally
            {
                File.WriteAllText("random_name_exception.txt", log);
            }

        }


    }
}




