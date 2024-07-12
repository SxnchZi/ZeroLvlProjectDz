public class fileRWHelper 
{
    public List<Task> toDoList = new List<Task>();

    /// <summary>
    /// Сохранение списка задач в текстовый файл
    /// </summary>
    public void SaveListToTxt(List<Task> toDoList, string filePath)
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
    public void SaveListToDat(List<Task> toDoList, string filePath)
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
    public List<Task> ReadListFromTxt(string filePath)
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
    public List<Task> ReadListFromDat(string filePath)
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
}
