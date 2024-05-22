using ToDoConsoleApp.UI;
using ToDoConsoleApp.Services;
using ToDoConsoleApp.Interfaces.Services;

namespace ToDoConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Run();
        }
    }
}
