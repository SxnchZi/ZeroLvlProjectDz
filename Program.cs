using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    /// <summary>
    /// Основное меню
    /// </summary>
    static void Main(string[] args)
    {
        var presenter = new ToDoListPresenter();
        var fileHelper = new fileRWHelper();
        presenter.toDoList = fileHelper.ReadListFromTxt("data.txt");
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
                    if (presenter.CompleteTask(taskID) == 0)
                    {
                        Console.WriteLine("Задача выполнена!");
                    }
                    else Console.WriteLine("Задачи с указанным ID не существует.");
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Введите ID задачи, которую нужно удалить: ");
                    taskID = int.Parse(Console.ReadLine());
                    if (presenter.DeleteTask(taskID) == 0)
                    {
                        Console.WriteLine("Задача удалена!");
                    }
                    else Console.WriteLine("Задачи с указанным ID не существует.");
                    presenter.ResN();
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;
                case 4:
                    presenter.ResN();
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Какие задачи вы хотите посмотреть?");
                        Console.WriteLine("1. Вывести все задачи");
                        Console.WriteLine("2. Вывести только выполненные задачи");
                        Console.WriteLine("3. Вывести только невыполненные задачи");
                        Console.WriteLine("4. Выход");
                        int choice1 = int.Parse(Console.ReadLine());
                        switch (choice1)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Ваши задачи: ");
                                presenter.OutputInfo();
                                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Выполненные задачи: ");
                                presenter.ComletedOnly();
                                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                                Console.ReadKey();
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Невыполненные задачи: ");
                                presenter.NotComletedOnly();
                                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                                Console.ReadKey();
                                break;
                            case 4:
                                break;
                            default:
                                Console.WriteLine("Неверный выбор. Попробуйте снова...");
                                Console.ReadKey();
                                break;
                        }
                        if(choice1 == 4)
                        {
                            break;
                        }
                    }
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey(); 
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Введите название файла и расширение (Н: 'data.txt'): ");
                    string filePath = Console.ReadLine();
                    if (filePath.EndsWith(".txt"))
                    {
                        fileHelper.SaveListToTxt(presenter.toDoList, filePath);
                        Console.WriteLine("Список сохранён в текстовый файл. ");
                    }
                    else if (filePath.EndsWith(".dat"))
                    {
                        fileHelper.SaveListToDat(presenter.toDoList, filePath);
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
                        presenter.toDoList = fileHelper.ReadListFromTxt(filePathIn);
                        Console.WriteLine("Список загружен из текстового файла. ");
                    }
                    else if (filePathIn.EndsWith(".dat"))
                    {
                        presenter.toDoList = fileHelper.ReadListFromDat(filePathIn);
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
                    fileHelper.SaveListToTxt(presenter.toDoList, "data.txt");
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

