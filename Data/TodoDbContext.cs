using Microsoft.EntityFrameworkCore;
using TodoMinimalApi.Models;

namespace TodoMinimalApi.Data;

public class TodoDbContext : DbContext
{
    public DbSet<Todo> Todos { get; set; } = null!;
    public TodoDbContext(DbContextOptions options) : base(options)
    {
    }
}

