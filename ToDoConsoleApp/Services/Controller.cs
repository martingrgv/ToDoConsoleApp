using System.Text;
using ToDoConsoleApp.Interfaces.Services;
using ToDoConsoleApp.Models;

namespace ToDoConsoleApp.Services
{
    internal class Controller : IController
    {
        DatabaseService _dbService;

        public Controller()
        {
            _dbService = new DatabaseService(
                "Server=WILLSONSCODER;" +
                "Database=Todo;" +
                "Integrated Security=True;" +
                "TrustServerCertificate=true"
                );
        }

        public bool HasItems => GetItems().Any();

        public int ItemsCount => GetItems().Count;

        public void DeleteAll()
        {
            Console.WriteLine("Successfully completed operation!");
        }

        public void DeleteItemById(int id)
        {
            if (_dbService.DeleteById(id) > 0)
            {
                Console.WriteLine("Successfully completed operation!");
                Console.WriteLine();
                Console.WriteLine(GetItemsStr());
                return;
            }

            throw new InvalidOperationException("Could not complete operation!");
        }

        public TodoItem GetItemByIndex(int id)
        {
            List<TodoItem> items = GetItems();

            if (id < 0 || id >= items.Count)
            {
                throw new InvalidOperationException("Cannot get item with this id.");
            }

            return items[id];
        }

        public List<TodoItem> GetItems()
        {
            return _dbService.Read();
        }

        public string GetItemsStr()
        {
            StringBuilder sb = new StringBuilder();
            List<TodoItem> items = GetItems();

            for (int i = 0; i < items.Count; i++)
            {
                sb.AppendLine($"{i+1}. {items[i]}");
            }

            return sb.ToString().TrimEnd();
        }

        public void UpdateItem(int id, string newTaskName)
        {
            if (_dbService.Update(id, newTaskName) > 0)
            {
                Console.WriteLine("Successfully completed operation!");
                return;
            }

            throw new InvalidOperationException("Could not complete operation!");
        }

        public void WriteItem(string task)
        {
            if (_dbService.Write(task) > 0)
            {
                Console.WriteLine("Successfully completed operation!");
                Console.WriteLine();
                Console.WriteLine(GetItemsStr());
                return;
            }

            throw new InvalidOperationException("Could not complete operation!");
        }

        public void WriteItems(string[] tasks)
        {
            throw new NotImplementedException();
        }
    }
}
