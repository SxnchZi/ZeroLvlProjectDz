using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    List<Task> toDoList = new List<Task>();

    /// <summary>
    /// Сохранение списка задач в текстовый файл
    /// </summary>
    static void SaveListToTxt(List<Task> toDoList, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            foreach (var task in toDoList)
            {
                writer.WriteLine($"{task.Id},{task.Name},{task.IsCompleted}");
            }
        }
    }

    /// <summary>
    /// Сохранение списка задач в бинарный файл
    /// </summary>
    static void SaveListToDat(List<Task> toDoList, string filePath)
    {
        using (var writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            foreach (var task in toDoList)
            {
                writer.Write(task.Name);
                writer.Write(task.IsCompleted);
            }
        }
    }

    /// <summary>
    /// Загрузка списка задач из текстового файла
    /// </summary>
    static List<Task> ReadListFromTxt(string filePath)
    {
        var result = new List<Task>();
        using (var reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(',');
                if (parts.Length == 3 && int.TryParse(parts[0], out int Id))
                {
                    result.Add(new Task { Id = Id, Name = parts[1], IsCompleted = bool.Parse(parts[2]) });
                }
            }
        }
        return result;
    }

    /// <summary>
    /// Загрузка списка задач из бинарного файла
    /// </summary>
    static List<Task> ReadListFromDat(string filePath)
    {
        var result = new List<Task>();
        using (var reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                result.Add(new Task { Name = reader.ReadString(), IsCompleted = false });
            }
        }
        return result;
    }

    /// <summary>
    /// Основное меню
    /// </summary>
    static void Main(string[] args)
    {
        Program program = new Program();
        var presenter = new ToDoListPresenter();
        presenter.toDoList = ReadListFromTxt("data.txt");
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Отметить выполненную задачу");
            Console.WriteLine("3. Удалить задачу");
            Console.WriteLine("4. Вывести список задач");
            Console.WriteLine("5. Сохранить список в файл");
            Console.WriteLine("6. Загрузить список из файла");
            Console.WriteLine("7. Выход");
            Console.WriteLine("\n   Введите номер пункта: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Введите задачу: ");
                    string taskName = Console.ReadLine();
                    presenter.InputInfo(taskName);
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Введите ID задачи для завершения: ");
                    int taskID = int.Parse(Console.ReadLine());
                    presenter.CompleteTask(taskID);
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Введите ID задачи, которую нужно удалить: ");
                    taskID = int.Parse(Console.ReadLine());
                    presenter.DeleteTask(taskID);
                    presenter.ResN();
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;
                case 4:
                    presenter.ResN();
                    presenter.OutputInfo();
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey(); 
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Введите название файла и расширение (Н: 'data.txt'): ");
                    string filePath = Console.ReadLine();
                    if (filePath.EndsWith(".txt"))
                    {
                        Program.SaveListToTxt(presenter.toDoList, filePath);
                        Console.WriteLine("Список сохранён в текстовый файл. ");
                    }
                    else if (filePath.EndsWith(".dat"))
                    {
                        Program.SaveListToDat(presenter.toDoList, filePath);
                        Console.WriteLine("Список сохранён в бинарный файл. ");
                    }
                    else
                    {
                        Console.WriteLine("Расширение файла указано неверно!");
                    }
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;
                case 6:
                    Console.WriteLine("Введите название файла и расширение (Н: 'data.txt'): ");
                    string filePathIn = Console.ReadLine();
                    if (filePathIn.EndsWith(".txt"))
                    {
                        presenter.toDoList = ReadListFromTxt(filePathIn);
                        Console.WriteLine("Список загружен из текстового файла. ");
                    }
                    else if (filePathIn.EndsWith(".dat"))
                    {
                        presenter.toDoList = ReadListFromDat(filePathIn);
                        Console.WriteLine("Список загружен из бинарного файла. ");
                    }
                    else
                    {
                        Console.WriteLine("Название файла введено неверно или такого файла не существует!");
                    }
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;
                case 7:
                    Console.Clear();
                    Program.SaveListToTxt(presenter.toDoList, "data.txt");
                    Console.WriteLine("Программа завершила свою работу. Введённые данные были сохранены в стд. файл data.txt");
                    return; // Выход из цикла
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова...");
                    Console.ReadKey(); 
                    break;
            }
        }
    }
}

