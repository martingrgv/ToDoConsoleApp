namespace ToDoConsoleApp.Models
{
    internal class TodoItem
    {
        public int Id { get; set; }
        public string TaskName { get; set; }

        public override string ToString()
        {
            return TaskName;
        }
    }
}
