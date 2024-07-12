public class Task
{
    /// <summary>
    /// Номер поставленной задачи
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Описание посталенной задачи
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Статус выполнения поставленной задачи
    /// </summary>
    public bool IsCompleted { get; set; }
    public Task()
    {
        IsCompleted = false;
    }
}
