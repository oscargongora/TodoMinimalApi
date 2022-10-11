using Microsoft.EntityFrameworkCore;
using TodoMinimalApi.Apis;
using TodoMinimalApi.Apis.Interfaces;
using TodoMinimalApi.Data;
using TodoMinimalApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDbContext>(options =>
{
    options.UseSqlite($"Data Source={Path.Join(Environment.CurrentDirectory, "Todos.db")}");
});

builder.Services.AddTransient<IApi, TodoApi>();

var app = builder.Build();

var apis = app.Services.GetServices<IApi>();

foreach (var api in apis)
{
    if (api is null) throw new InvalidProgramException("Api not found");
    api.Register(app);
}

app.Run();