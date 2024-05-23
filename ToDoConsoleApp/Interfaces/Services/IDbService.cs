using ToDoConsoleApp.Models;

namespace ToDoConsoleApp.Interfaces.Services
{
    internal interface IDbService
    {
        List<TodoItem> Read();
        int Write(string task);
        int Update(int id, string taskName);
        int DeleteById(int id);
        void Truncate();
    }
}
