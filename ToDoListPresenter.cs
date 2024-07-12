public class ToDoListPresenter
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
    /// Вывод всех задач на экран
    /// </summary>
    public void OutputInfo() // Просмотр задач
    {
        for (int i = 0; i < toDoList.Count; i++)
        {
            Console.WriteLine($"{toDoList[i].Id}. {toDoList[i].Name} {(toDoList[i].IsCompleted ? "[Completed]" : "[Not Completed]")} ");
        }
    }

    /// <summary>
    /// Функция для вывода выполненных задач
    /// </summary>
    public void ComletedOnly()
    {
        for (int i = 0; i < toDoList.Count; i++)
        {
            if (toDoList[i].IsCompleted == true)
            {
                Console.WriteLine($"{toDoList[i].Id}. {toDoList[i].Name} {(toDoList[i].IsCompleted ? "[Completed]" : "[Not Completed]")} ");
            }
            else continue;
        }
    }

    /// <summary>
    /// Функция для вывода невыполненных задач
    /// </summary>
    public void NotComletedOnly()
    {
        for (int i = 0; i < toDoList.Count; i++)
        {
            if (toDoList[i].IsCompleted == false)
            {
                Console.WriteLine($"{toDoList[i].Id}. {toDoList[i].Name} {(toDoList[i].IsCompleted ? "[Completed]" : "[Not Completed]")} ");
            }
            else continue;
        }
    }

    /// <summary>
    /// Функция для отметки выполненных задач
    /// </summary>
    public int CompleteTask(int taskId)
    {
        var task = toDoList.FirstOrDefault(t => t.Id == taskId);
        if (task != null)
        {
            task.IsCompleted = true;
            return 0;
        }
        else
        {
            return 1;
        }
    }

    /// <summary>
    /// Функция для удаления задачи по ID
    /// </summary>
    public int DeleteTask(int taskId)
    {
        var task = toDoList.FirstOrDefault(t => t.Id == taskId);
        if (task != null)
        {
            toDoList.Remove(task);
            return 0;
        }
        else
        {
            return 1;
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