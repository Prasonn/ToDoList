using Microsoft.EntityFrameworkCore;
using ToDoListProj01.Models;

namespace TodoApi.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    // Configure the model-to-table mappings
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Explicitly mapping the TodoList class to the ToDoListTbl table
        modelBuilder.Entity<TodoList>()
            .ToTable("ToDoListTbl");

        // Explicitly mapping the UserCls class to the UserTbl table
        modelBuilder.Entity<UserCls>()
            .ToTable("UserTbl");
    }

    // DbSet properties
    public DbSet<TodoList> TodoItems { get; set; } = null!;  // Ensure this is non-nullable
    public DbSet<UserCls> UserCls { get; set; } = null!;     // Fix nullability to non-nullable
}
