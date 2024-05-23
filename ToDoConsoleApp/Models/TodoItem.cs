namespace ToDoConsoleApp.Models
{
    internal class TodoItem
    {
        public int Id { get; set; }
        public string TodoName { get; set; }

        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return TodoName;
        }
    }
}
