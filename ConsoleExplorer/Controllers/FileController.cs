using ConsoleExplorer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleExplorer.Controlers
{
    class FileController : FileManager
    {      
        public override void ReadFile(string filePath)
        {
            if(!File.Exists(filePath))
                Console.WriteLine($"Файла не існує за даним шляхом: {filePath}");
            else
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
        }

        public override void WriteFile(string filePath)
        {
            if (!File.Exists(filePath))
                Console.WriteLine($"Файла не існує за даним шляхом: {filePath}");
            else
            {
                Console.Write("Введіть, що хочете дописати до файлу: ");
                string words = Console.ReadLine();
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(words);
                }
            }
        }

        public override void CreateFile(string filePath)
        {
            if(File.Exists(filePath))
                Console.WriteLine($"Файл уже існує за даним шляхом: {filePath}");
            else
            {
                using (FileStream fs = File.Create(filePath))
                {
                    Console.WriteLine($"Файл успішно створено, за шляхом: {filePath}");
                }
            }
        }

        public override void DeleteFile(string filePath)
        {
            if (!File.Exists(filePath))
                Console.WriteLine($"Файла не існує за даним шляхом: {filePath}");
            else
            {
                File.Delete(filePath);
                Console.WriteLine($"Файл успішно видалено, за шляхом: {filePath}");
            }
        }

        public override void CopyFile(string filePath)
        {
            if (!File.Exists(filePath))
                Console.WriteLine($"Файла не існує за даним шляхом: {filePath}");
            else
            {
                try
                {
                    Console.Write("Тепер введіть новий шлях, куди будете копіювати файл: ");
                    string newPath = Console.ReadLine();
                    File.Copy(filePath, newPath, true);
                    Console.WriteLine($"Файл успішно скопійовано, за шляхом: {newPath}");
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("Директорію не було знайдено!");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Не введено новий шлях!");
                }
                catch (IOException)
                {
                    Console.WriteLine("Шлях введено не вірно!");
                }
            }
        }

        public override void MoveFile(string filePath)
        {
            if (!File.Exists(filePath))
                Console.WriteLine($"Файла не існує за даним шляхом: {filePath}");
            else
            {
                try
                {
                    Console.Write("Тепер введіть новий шлях, куди будете переміщувати файл: ");
                    string newPath = Console.ReadLine();
                    File.Move(filePath, newPath);
                    Console.WriteLine($"Файл успішно переміщено, за шляхом: {newPath}");
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("Директорію не було знайдено!");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Не введено новий шлях!");
                }
                catch(IOException) 
                {
                    Console.WriteLine("Шлях введено не вірно!");
                }
            }
        }

        public override void SearchFile(string filePath, string input)
        {
            List<string> files = new List<string>();

            if(!Directory.Exists(filePath))
                Console.WriteLine($"Директорії не існує за даним шляхом: {filePath}");
            else
            {
                try
                {
                    if (input.Contains("."))
                        files = (from f in Directory.EnumerateFiles(filePath, $"*{input}", SearchOption.AllDirectories) select f).ToList();
                    else
                        files = (from f in Directory.EnumerateFiles(filePath, $"{input}*.?", SearchOption.AllDirectories) select f).ToList();
                    foreach(string f in files)
                        Console.WriteLine(f);
                }
                catch(ArgumentNullException)
                {
                    Console.WriteLine("Не введено дані!");
                }

            }
        }
    }
}
