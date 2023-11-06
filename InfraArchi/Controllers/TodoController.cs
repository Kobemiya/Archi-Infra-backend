using InfraArchi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfraArchi.Controllers;

public class TodoInput
{
    public string? Description { get; set; }
    public string? Name { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly TodoDbContext _todoDbContext;

    public TodoController(TodoDbContext todoDbContext)
    {
        _todoDbContext = todoDbContext;
    }

    [HttpGet]
    public List<Todo> FetchAllTodos()
    {
        return _todoDbContext.Todos.ToList();
    }

    [HttpPost]
    public Todo AddTodo(TodoInput todoInput)
    {
        var newTodo = new Todo { Description = todoInput.Description, Name = todoInput.Name };
        _todoDbContext.Todos.Add(newTodo);
        _todoDbContext.SaveChanges();
        return newTodo;
    }

    [HttpPut("{id}")]
    public Todo? UpdateTodo(int id, TodoInput todoInput)
    {
        var toUpdate = _todoDbContext.Todos.Find(id);
        if (toUpdate == null)
            return null;
        toUpdate.Description = todoInput.Description;
        toUpdate.Name = todoInput.Name;
        _todoDbContext.SaveChanges();
        return toUpdate;
    }

    [HttpDelete("{id}")]
    public Todo? DeleteTodo(int id)
    {
        var toDelete = _todoDbContext.Todos.Find(id);
        if (toDelete == null)
            return null;
        _todoDbContext.Todos.Remove(toDelete);
        _todoDbContext.SaveChanges();
        return toDelete;
    }
}