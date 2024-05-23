using Microsoft.EntityFrameworkCore;

namespace MyImportantStuff.Models
{
    public class TodoContext : DbContext
    {
        private const string _connectionString = "Server=WILLSONSCODER;Database=Todo;Integrated Security=True;TrustServerCertificate=true";

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
