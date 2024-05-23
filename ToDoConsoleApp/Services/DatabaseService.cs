﻿using Microsoft.Data.SqlClient;
using ToDoConsoleApp.Interfaces.Services;
using ToDoConsoleApp.Models;

namespace ToDoConsoleApp.Services
{
    internal class DatabaseService : IDbService
    {
        string _conStr;

        public DatabaseService(string connection)
        {
            _conStr = connection;
        }

        public int DeleteById(int id)
        {
            SqlConnection connection = new SqlConnection(_conStr);
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("DELETE FROM TodoItems WHERE Id = @id;", connection);
                command.Parameters.AddWithValue("@id", id);

                return command.ExecuteNonQuery();
            }
        }

        public List<TodoItem> Read()
        {
            List<TodoItem> todos = new List<TodoItem>();

            SqlConnection connection = new SqlConnection(_conStr);
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT Id, TaskName FROM TodoItems;", connection);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string taskName = (string)reader["TaskName"];

                        todos.Add(new TodoItem() 
                            { Id = id, TaskName = taskName }
                        );
                    }
                }
            }

            return todos;
        }

        public void Truncate()
        {
            SqlConnection connection = new SqlConnection(_conStr);
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("TRUNCATE TABLE TodoItems", connection);
                command.ExecuteNonQuery();
            }
        }

        public int Update(int id, string taskName)
        {
            SqlConnection connection = new SqlConnection(_conStr);
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand($"UPDATE TodoItems SET TaskName = @taskName WHERE Id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@taskName", taskName);

                return command.ExecuteNonQuery();
            }
        }

        public int Write(string task)
        {
            SqlConnection connection = new SqlConnection(_conStr);
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand($"INSERT INTO TodoItems(TaskName) VALUES('{task}')", connection);
                return command.ExecuteNonQuery();
            }
        }
    }
}
