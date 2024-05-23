using System.ComponentModel.DataAnnotations;

namespace MyImportantStuff.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string TodoName { get; set; }
        public bool IsCompleted { get; set; }
    }
}
