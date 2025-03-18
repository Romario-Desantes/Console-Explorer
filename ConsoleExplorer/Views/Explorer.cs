using ConsoleExplorer.Controlers;
using ConsoleExplorer.Controllers;
using System;
using System.Text;

namespace ConsoleExplorer
{
    class Explorer
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DirController directoryController = new DirController();
            FileController fileController = new FileController();
            while (true) 
            {
                Console.WriteLine("Опції:");
                Console.WriteLine("1. Перегляд директорії.");
                Console.WriteLine("2. Додавання директорії.");
                Console.WriteLine("3. Видалення директорії.");
                Console.WriteLine("4. Перегляд файлу.");
                Console.WriteLine("5. Дописування файлу.");
                Console.WriteLine("6. Створення файлу.");
                Console.WriteLine("7. Видалення файлу.");
                Console.WriteLine("8. Копіювання файлу.");
                Console.WriteLine("9. Переміщення файлу.");
                Console.WriteLine("10. Вихід.");

                Console.WriteLine("_________________________________________________________________");

                Console.Write("Оберіть опцію: ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.Write("Введіть шлях розташування директорії: ");
                        directoryController.ReadDir(Console.ReadLine());
                        break;
                    case "2":
                        Console.Write("Введіть ім'я для директорії: ");
                        directoryController = new DirController(Console.ReadLine());
                        Console.Write("Введіть шлях створення для нової директорії: ");
                        directoryController.CreateDir(Console.ReadLine());
                        break;
                    case "3":
                        Console.Write("Введіть шлях для видалення директорії: ");
                        directoryController.DeleteDir(Console.ReadLine());
                        break;
                    case "4":
                        Console.Write("Введіть шляx розташування файлу: ");
                        fileController.ReadFile(Console.ReadLine());
                        Console.WriteLine("Вміст файлу: ");
                        break;
                    case "5":
                        Console.Write("Введіть шляx для дописання файлу: ");
                        fileController.WriteFile(Console.ReadLine());
                        break;
                    case "6":
                        Console.Write("Введіть шлях по якому буде створено файл: ");
                        fileController.CreateFile(Console.ReadLine());
                        break;
                    case "7":
                        Console.Write("Введіть шлях по якому буде видалено файл: ");
                        fileController.DeleteFile(Console.ReadLine());
                        break;
                    case "8":
                        Console.Write("Введіть шлях до файлу, який хочете скопіювати: ");
                        fileController.CopyFile(Console.ReadLine());
                        break;
                    case "9":
                        Console.Write("Введіть шлях до файлу, який хочете перемістити: ");
                        fileController.MoveFile(Console.ReadLine());
                        break;
                    case "10":
                        Console.WriteLine("Завершення програми!");
                        return;
                    default:
                        Console.WriteLine("Введено не правильну опцію!");
                        break;
                }
            }
            
        }
    }
}
