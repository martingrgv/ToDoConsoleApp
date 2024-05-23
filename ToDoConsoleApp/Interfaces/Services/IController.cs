using ToDoConsoleApp.Models;

namespace ToDoConsoleApp.Interfaces.Services
{
    internal interface IController
    {
        int ItemsCount { get; }
        bool HasItems { get; }
        string GetItemsStr();
        TodoItem GetItemByIndex(int id);
        void WriteItems(string[] tasks);
        void WriteItem(string task);
        void UpdateItem(int id, string newTaskName);
        void DeleteItemById(int id);
        void DeleteAll();
    }
}
