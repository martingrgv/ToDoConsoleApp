using ToDoConsoleApp.Interfaces;
using ToDoConsoleApp.Models;
using ToDoConsoleApp.Services;

namespace ToDoConsoleApp.UI
{
    internal class Menu : IMenu
    {
        Controller _controller;

        public Menu()
        {
            _controller = new Controller();
        }

        public void Run()
        {
            Greeter greeter = new Greeter(_controller.ItemsCount, _controller.GetItemsStr());
            greeter.Greet();

            PrintCommands();


            while (true)
            {
                try
                {
                    Console.Write("Operation: ");
                    int choice = int.Parse(Console.ReadLine());

                    Console.WriteLine();

                    switch(choice)
                    {
                        case 1:
                            ReadItems();
                            break;
                        case 2:
                            WriteItem();
                            break;
                        case 3:
                            UpdateItem();
                            break;
                        case 4:
                            DeleteItem();
                            break;
                        case 5:
                            DeleteAll();
                            break;
                        case 6:
                            Console.Clear();
                            PrintCommands();
                            break;
                        case 7:
                            greeter.Farewell();
                            return;
                    }

                    Console.WriteLine();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid operation! Try again.");
                }
            }
        }

        private void ReadItems()
        {
            if (!_controller.HasItems)
            {
                Console.WriteLine("You have no tasks!");
                return;
            }

            Console.WriteLine("Tasks");
            Console.WriteLine("-----");

            Console.WriteLine(_controller.GetItemsStr());
        }

        private void WriteItem()
        {
            Console.WriteLine("Create Task");
            Console.WriteLine("-----------");

            Console.WriteLine("Enter task:");
            string task = Console.ReadLine();

            _controller.WriteItem(task);
        }

        private void UpdateItem()
        {
            Console.WriteLine("Rename Task");
            Console.WriteLine("-----------");

            Console.Write("Enter task index: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            TodoItem item = _controller.GetItemByIndex(index);
            Console.WriteLine("Enter new name:");
            string newTaskName = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("Are you sure you want to rename this task? y/n");
            Console.WriteLine($"--{item.TaskName}");

            char choice = char.Parse(Console.ReadLine().ToLower());

            if (choice == 'y')
            {
                _controller.UpdateItem(item.Id, newTaskName);
            }
            else
            {
                Console.WriteLine("Aborting task.");
            }
        }

        private void DeleteItem()
        {
            Console.WriteLine("Delete Task");
            Console.WriteLine("-----------");

            if (!_controller.HasItems)
            {
                Console.WriteLine("You have no tasks!");
                return;
            }

            Console.Write("Enter task index: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            TodoItem item = _controller.GetItemByIndex(index);

            Console.WriteLine("Are you sure you want to remove this task? y/n");
            Console.WriteLine($"--{item.TaskName}");

            char choice = char.Parse(Console.ReadLine().ToLower());

            if (choice == 'y')
            {
                _controller.DeleteItemById(item.Id);
            }
            else
            {
                Console.WriteLine("Aborting task.");
            }
        }

        private void DeleteAll()
        {
            Console.WriteLine("Are you sure you want to remove all tasks? y/n");

            char choice = char.Parse(Console.ReadLine().ToLower());

            if (choice == 'y')
            {
                _controller.DeleteAll();
            }
            else
            {
                Console.WriteLine("Aborting task.");
            }
        }

        private void PrintCommands()
        {
            Console.WriteLine("What would you like to do?");

            string[] commands = { "Show tasks", "Create new task", "Rename task", "Remove task", "Remove all tasks", "Clear", "Exit" };

            for (int i = 0; i < commands.Length; i++)
            {
                Console.WriteLine($"{i+1} - {commands[i]}");
            }
        }
    }
}
