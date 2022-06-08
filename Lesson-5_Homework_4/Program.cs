using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RekordFile1
{
    class Program
    {/// <summary>
     /// Сохранение дерева в текстовый файл.
     /// </summary>
     /// <param name="dir"></param>
     /// <returns></returns>
        static void RekordFile1(string dir, bool exist)
        {
            string text = JsonConvert.SerializeObject(dir);

            if (File.Exists(text))
            {
                File.WriteAllText("redme.txt", "text");
            }
        }
        /// <summary>
        /// Отображение файлов.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="indent"></param>
        static void PrintFiles(StringBuilder f, DirectoryInfo dir, string indent)
        {
            FileInfo[] subFiles = dir.GetFiles();

            for (int i = 0; i < subFiles.Length; i++)
            {
                if (i == subFiles.Length - 1)

                {
                    f.Append($"{indent}└─{subFiles[i].Name}\n");
                }
                else

                {
                    f.Append($"{indent}├─{subFiles[i].Name}\n");
                }
            }
        }

        static void PrintDir(DirectoryInfo dir, string indent, bool lastDirectory)
        {
            Console.Write(indent);
            Console.Write(lastDirectory ? "└─" : "├─");
            indent += lastDirectory ? " " : "│";
            Console.WriteLine(dir.Name);


            DirectoryInfo[] subDirs = dir.GetDirectories();

            for (int i = 0; i < subDirs.Length; i++)
            {
                PrintDir(subDirs[i], indent, i == subDirs.Length - 1);
            }
        }/// <summary>
         /// Вывод информации и дерева каталога.
         /// </summary>
         /// <param name="args"></param>
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            FileInfo f = new FileInfo(AppDomain.CurrentDomain.BaseDirectory);

            if (f.Exists) //Если указанный файл существует, то выводим о нём информацию.
            {
                Console.WriteLine("FullName      : {0}", f.FullName);      // Полное Имя файла. (включая путь).
                Console.WriteLine("Name          : {0}", f.Name);          // Имя файла. (НЕ включая путь).
                Console.WriteLine("CreationTime  : {0}", f.CreationTime);  // Время создания файла.
                Console.WriteLine("LastAccessTime: {0}", f.LastAccessTime);// Время последнего доступа к файлу.
                Console.WriteLine("LastWriteTime : {0}", f.LastWriteTime); // Время последнего изменения файлов
                Console.WriteLine();
            }
            else
            {


                if (dir.Exists) // Если указанная директория существует, то выводим о ней информацию.
                {
                    Console.WriteLine("FullName      : {0}", dir.FullName);              // Полное Имя директории, (включая путь).
                    Console.WriteLine("Name          : {0}", dir.Name);                  // Имя директории, (НЕ включая путь).
                    Console.WriteLine("Parent        : {0}", dir.Parent);                // Родительская директория. 
                    Console.WriteLine("CreationTime  : {0}", dir.CreationTime);          // Время создания директории.
                    Console.WriteLine("Attributes    : {0}", dir.Attributes.ToString()); // Аттрибуты.
                    Console.WriteLine("Root          : {0}", dir.Root);                  // Корневой диск, на котором находится директория.
                    Console.WriteLine("LastAccessTime: {0}", dir.LastAccessTime);        // Время последнего доступа к директории.
                    Console.WriteLine("LastWriteTime : {0}", dir.LastWriteTime);         // Время последнего изменения файлов в директории.                 
                }
                else
                {
                    Console.WriteLine("Директория с именем: {0}  не существует.", dir.FullName);
                }
                Console.WriteLine(dir);

                Console.WriteLine();

                PrintDir(new DirectoryInfo(@"C:\repos\C_sharp_GB\RekordFile1"), "", true);

                PrintFiles(f.Name);

                Console.ReadKey(true);
            }
        }
    }
}