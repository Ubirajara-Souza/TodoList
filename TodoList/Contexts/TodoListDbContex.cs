using Microsoft.EntityFrameworkCore;
using TodoList.EntityConfigs;
using TodoList.Models;

namespace TodoList.Contexts
{
    public class TodoListDbContex : DbContext
    {
        public DbSet<TodoListModel> TodoList => Set<TodoListModel>();

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=todo-list;User Id=bira;Password=avila160197;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TodoListEntityConfig());
        }
    }
}
