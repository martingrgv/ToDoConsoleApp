﻿using ToDoConsoleApp.Models;

namespace ToDoConsoleApp.Interfaces.Services
{
    internal interface IDbService
    {
        List<TodoItem> Read();
        int Write(string task);
        void Update(int id);
        int DeleteById(int id);
        void Truncate();
    }
}
