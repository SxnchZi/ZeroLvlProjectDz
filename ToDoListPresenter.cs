class ToDoListPresenter
{
    /// <summary>
    /// Список объектов класса Task
    /// </summary>
    public List<Task> toDoList;
    /// <summary>
    /// Переменная для обновления ID задач (Н: после удаления задачи номера выставляются заново)
    /// </summary>
    public int xID;

    public ToDoListPresenter()
    {
        toDoList = new List<Task>();
        xID = 1;
    }

    /// <summary>
    /// Ввод новой задачи
    /// </summary>
    public void InputInfo(string taskName)
    {
        toDoList.Add(new Task { Id = xID++, Name = taskName });
    }

    /// <summary>
    /// Вывод задач на экран по запросу пользователя
    /// </summary>
    public void OutputInfo() // Просмотр задач
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Какие задачи вы хотите посмотреть?");
            Console.WriteLine("1. Вывести все задачи");
            Console.WriteLine("2. Вывести только выполненные задачи");
            Console.WriteLine("3. Вывести только невыполненные задачи");
            Console.WriteLine("4. Выход");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Ваши задачи: ");
                    for (int i = 0; i < toDoList.Count; i++)
                    {
                        Console.WriteLine($"{toDoList[i].Id}. {toDoList[i].Name} {(toDoList[i].IsCompleted ? "[Completed]" : "[Not Completed]")} ");
                    }
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Выполненные задачи: ");
                    for (int i = 0; i < toDoList.Count; i++)
                    {
                        if (toDoList[i].IsCompleted == true)
                        {
                            Console.WriteLine($"{toDoList[i].Id}. {toDoList[i].Name} {(toDoList[i].IsCompleted ? "[Completed]" : "[Not Completed]")} ");
                        }
                        else continue;
                    }
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Невыполненные задачи: ");
                    for (int i = 0; i < toDoList.Count; i++)
                    {
                        if (toDoList[i].IsCompleted == false)
                        {
                            Console.WriteLine($"{toDoList[i].Id}. {toDoList[i].Name} {(toDoList[i].IsCompleted ? "[Completed]" : "[Not Completed]")} ");
                        }
                        else continue;
                    }
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова...");
                    Console.ReadKey();
                    break;
                }
            }
    }

    /// <summary>
    /// Функция для отметки выполненных задач
    /// </summary>
    public void CompleteTask(int taskId)
    {
        var task = toDoList.FirstOrDefault(t => t.Id == taskId);
        if (task != null)
        {
            task.IsCompleted = true;
            Console.WriteLine("Задача выполнена!");
        }
        else
        {
            Console.WriteLine("Задачи с указанным ID не существует.");
        }
    }

    /// <summary>
    /// Функция для удаления задачи по ID
    /// </summary>
    public void DeleteTask(int taskId)
    {
        var task = toDoList.FirstOrDefault(t => t.Id == taskId);
        if (task != null)
        {
            toDoList.Remove(task);
            Console.WriteLine("Задача удалена!");
        }
        else
        {
            Console.WriteLine("Задачи с указанным ID не существует.");
        }
    }

    /// <summary>
    /// Выставление ID заново 
    /// </summary>
    public void ResN()
    {
        int nID = 1;
        foreach (var task in toDoList)
        {
            task.Id = nID++;
        }
    }
}