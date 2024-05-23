using ToDoConsoleApp.Interfaces.Services;

namespace ToDoConsoleApp.Services
{
    internal class Greeter
    {
        int _itemsCount;
        string _itemsStr;

        public Greeter(int itemsCount, string items)
        {
            _itemsCount = itemsCount;
            _itemsStr = items;
        }

        public void Greet()
        {
            if (_itemsCount == 0)
            {
                Console.WriteLine("Welcome to 'Your List of Importants' v1.0");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Welcome back, User");
            Console.WriteLine("------------------");

            Console.WriteLine($"You have {_itemsCount} uncompleted tasks.");
            Console.WriteLine();
            Console.WriteLine(_itemsStr);

            Console.WriteLine();
        }

        public void Farewell()
        {
            Console.WriteLine("Good Bye!");
        }
    }
}
