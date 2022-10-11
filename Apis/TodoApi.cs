using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoMinimalApi.Apis.Interfaces;
using TodoMinimalApi.Data;
using TodoMinimalApi.Models;

namespace TodoMinimalApi.Apis;

public class TodoApi : ITodoApi
{
    public TodoApi()
    {

    }

    public Task<IResult> Delete(TodoDbContext todoDb, Guid Id)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult> Get(TodoDbContext todoDb)
    {
        var todos = await todoDb.Todos.ToListAsync();
        return Results.Ok(todos);
    }

    public Task<IResult> GetById(TodoDbContext todoDb, Guid Id)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult> Post(TodoDbContext todoDb, Todo todo)
    {
        try
        {
            Todo newTodo = new()
            {
                Id = Guid.NewGuid(),
                Title = todo.Title,
                CreateDate = DateTime.Now,
                Completed = false
            };
            await todoDb.Todos.AddAsync(newTodo);
            await todoDb.SaveChangesAsync();
            return Results.Ok(newTodo.Id);
        }
        catch (System.Exception exception)
        {
            return Results.BadRequest(exception.Message);
        }
    }

    public Task<IResult> Put(TodoDbContext todoDb, Guid Id, Todo model)
    {
        throw new NotImplementedException();
    }

    public void Register(WebApplication app)
    {
        app.MapGet("/api/todos", Get);
        app.MapGet("/api/todos/{id}", GetById);
        app.MapPost("/api/todos", Post);
        app.MapPut("/api/todos/{id}", Put);
        app.MapDelete("/api/todos/{id}", Delete);
    }
}