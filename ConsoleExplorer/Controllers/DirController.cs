using ConsoleExplorer.Models;
using System;
using System.IO;
using System.Linq;

namespace ConsoleExplorer.Controllers
{
    class DirController : DirManager
    {
        private string _name;

        public DirController() { }
        public DirController(string name)
        {
            _name = name;
        }

        public override void ReadDir(string dirPath)
        {
            if (!Directory.Exists(dirPath))
                Console.WriteLine($"Директорії не існує за даним шляхом: {dirPath}");
            else
            {
                var files = Directory.EnumerateFiles(dirPath);
                var directories = Directory.EnumerateDirectories(dirPath);
                if (!files.Any() && !directories.Any())
                    Console.WriteLine("Директорія порожня.");
                else
                {
                    Console.WriteLine("Вміст директорії: ");
                    foreach (var dir in directories)
                        Console.WriteLine("Директорія: " + Path.GetFileName(dir));

                    foreach (var file in files)
                        Console.WriteLine("Файл: " + Path.GetFileName(file));
                }
            }
        }

        public override void CreateDir(string dirPath)
        {
            if (Directory.Exists(dirPath))
                Console.WriteLine($"Директорія вже існує за даним шляхом: {dirPath}");
            else
            {
                Directory.CreateDirectory(dirPath);
                Console.WriteLine($"Директорія {_name} була успішно створеня за даним шляхом: {dirPath}");
            }
        }

        public override void DeleteDir(string dirPath)
        {
            if (!Directory.Exists(dirPath))
                Console.WriteLine($"Директорія не існує за даним шляхом: {dirPath}");
            else
            {
                Directory.Delete(dirPath, true);
                Console.WriteLine($"Директорія була успішно видалена за даним шляхом: {dirPath}");
            }
        }
    }
}
